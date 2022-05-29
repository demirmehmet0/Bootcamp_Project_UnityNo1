const textToSpeech = require('@google-cloud/text-to-speech');
const fs = require('fs');
const util = require('util');
var request = require("request");
const ftp = require("basic-ftp")

var ftp_id="ftp_user";
var ftp_pass="pass"; 
var ftp_host="server";
var entries = [];
let count = 0;
async function asyncCall(req, outfile) {
    const client = new textToSpeech.TextToSpeechClient();
    const [response] = await client.synthesizeSpeech(req);
    const writeFile = util.promisify(fs.writeFile);
    await writeFile(outfile, response.audioContent, 'binary');
    console.log(`Audio content written to file: ${outfile}`);
    await upload(outfile);
    //upload and save it to db
}
async function getAll() {
    console.log("1");
    await request("https://soundsofearth.space/web/api/all", function (error, response, body) {
        if (!error && response.statusCode == 200) {
            var datas = body.split("<br>");
            datas.forEach(element => {
               if(!element.includes(".")) {console.log("1231231231"); entries.push(element);}
            });
            pushAll();
        }

    });
}
async function pushAll() {
    console.log("1a");
    for (let i = 0; i < entries.length; i++) {
        let id = entries[i].split(';')[0];
        let text = entries[i].split(';')[1];
        let country = entries[i].split(';')[2];
        if(country === undefined ) 
        { 
        }else{ 
            let lan = await getLangs(country);
            let outputFile = id + '.mp3';
            let request = {
                input: { text: text },
                voice: { languageCode: country, name:lan, ssmlGender: 'MALE' },
                audioConfig: { audioEncoding: 'MP3' },
            }; 
                await asyncCall(request, outputFile); 
                await saveToDb(outputFile,id);
        }
        
    }
}

getAll();

async function getLangs(code) {
    console.log("1b")
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
    console.log(items[Math.floor(Math.random() * items.length)])
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
        await client.uploadFrom($file,"public_html/"+$file);
        console.log("=======================================")
    }
    catch(err) {
        console.log(err)
    }
    client.close()
}


async function saveToDb(file,id) {
    await request("https://soundsofearth.space/web/api/save/"+file+"/"+id, function (error, response, body) {
        if (!error && response.statusCode == 200) {
            var datas = body.split("<br>");
            datas.forEach(element => {
                entries.push(element);
            }); 
        }

    });
}