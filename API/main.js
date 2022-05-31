/**
 * TODO(developer): Uncomment these variables before running the sample.
 */
 const projectId = 'team01-350018';
 const location = 'global';
 const textToSpeech = require('@google-cloud/text-to-speech');
 const fs = require('fs');
 const util = require('util');
 var request = require("request");
 const ftp = require("basic-ftp")
 
 var ftp_id = "ftp";
 var ftp_pass = "pass";
 var ftp_host = "server";
 var entries = [];
 let count = 0;
 
 const { TranslationServiceClient } = require('@google-cloud/translate');
 const translationClient = new TranslationServiceClient();
 
 async function asyncCall(req, outfile) {
   const client = new textToSpeech.TextToSpeechClient();
   const [response] = await client.synthesizeSpeech(req);
   const writeFile = util.promisify(fs.writeFile);
   await writeFile(outfile, response.audioContent, 'binary');
   await upload(outfile);
   //upload and save it to db
 }
 
 async function translateText(_text, srcLang, targetLang) {
   const request = {
     parent: `projects/${projectId}/locations/${location}`,
     contents: [_text],
     mimeType: 'text/plain', // mime types: text/plain, text/html
     sourceLanguageCode: srcLang,
     targetLanguageCode: targetLang,
   };
   const [response] = await translationClient.translateText(request);
   for (const translation of response.translations) {
     return `${translation.translatedText}`;
   }
 }
 
 async function getAll() {
   await request("https://soundsofearth.space/web/api/all", function (error, response, body) {
     if (!error && response.statusCode == 200) {
       var datas = body.split("<br>");
       datas.forEach(element => {
         if (!element.includes(".mp3")) { console.log("============" + element); entries.push(element); }
       });
       pushAll();
     }
 
   });
 }
 
 async function pushAll() {
   for (var i = 0; i < entries.length; i++) { if (entries[i] === '') { entries.splice(i, 1); } }
   for (let i = 0; i < entries.length; i++) {
     var translated = "NULL";
     let id = entries[i].split(';')[0];
     let text = entries[i].split(';')[1];
     let country = entries[i].split(';')[2];
     let srcLang = entries[i].split(';')[6];
     console.log(entries[i][2]);
     if (!srcLang.includes("en")) { translated = await translateText(text, srcLang, "en-us"); }
     if (country === undefined) {
     } else {
       let lan = await getLangs(country);
       let outputFile = id + '.mp3';
       let request = {
         input: { text: text },
         voice: { languageCode: country, name: lan, ssmlGender: 'MALE' },
         audioConfig: { audioEncoding: 'MP3' },
       };
       await asyncCall(request, outputFile);
       await saveToDb(outputFile, id, translated);
     }
   }
 }
 
 async function getLangs(code) {
   var language = [];
   const textToSpeech = require('@google-cloud/text-to-speech');
   const client = new textToSpeech.TextToSpeechClient();
   const [result] = await client.listVoices({});
   const voices = result.voices;
   await voices.forEach(voice => {
     voice.languageCodes.forEach(languageCode => {
       language.push(`${voice.name}`);
     });
   })
   const items = language.filter(item => item.indexOf(code) !== -1);
   return items[Math.floor(Math.random() * items.length)];
 };
 
 async function upload($file) {
   const client = new ftp.Client()
   client.ftp.verbose = true
   try {
     await client.access({
       host: ftp_host,
       user: ftp_id,
       password: ftp_pass,
     })
     await client.uploadFrom($file, "public_html/" + $file);
   }
   catch (err) {
     console.log(err)
   }
   client.close()
 }
 
 async function saveToDb(file, id, translated) { 
   translated=translated.replace('!','');
   await request("https://soundsofearth.space/web/api/save/" + file + "/" + id + "/" + encodeURIComponent(translated), function (error, response, body) {
     if (!error && response.statusCode == 200) {
       var datas = body.split("<br>");
       datas.forEach(element => {
         entries.push(element);
       });
     }
   });
 }
 getAll();
 