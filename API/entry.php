<?php
if (isset($_POST["metin"])) 
{
    $servername = "server";
    $username = "user";
    $password = "pass";
    $code = explode(";", $_POST["country"])[0]; 
    $conn = new mysqli($servername, $username, $password, "userdb"); 
    if ($conn->connect_error) { die("Connection failed: " . $conn->connect_error); } 
    else 
    {
        $sql = "INSERT INTO Entries (text, country,textonly,textlatin) VALUES ('" . $_POST["metin"] . "', '" . $code . "','" . $_POST["metin"] . "', '" . $_POST["latin"] . "')";
            if ($conn->query($sql) === TRUE) { } else { } 
        $conn->close();
    }
}
?>
<!DOCTYPE html>
<html> 
<head>
    <style>  table, th, td {  border: 1px solid black; } </style>
    <link href="https://www.iban.com/country-codes" rel="canonical">
    <link rel="alternate" href="https://www.iban.com/country-codes" hreflang="x-default">
    <link rel="alternate" href="https://www.iban.com/country-codes" hreflang="en">
    <link rel="alternate" href="https://de.iban.com/country-codes" hreflang="de">
    <link rel="alternate" href="https://fr.iban.com/country-codes" hreflang="fr">
    <link rel="alternate" href="https://es.iban.com/country-codes" hreflang="es">
    <link rel="alternate" href="https://pt.iban.com/country-codes" hreflang="pt">
    <link rel="alternate" href="https://nl.iban.com/country-codes" hreflang="nl">
    <link rel="alternate" href="https://it.iban.com/country-codes" hreflang="it"> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/css/bootstrap.min.css" integrity="sha512-oc9+XSs1H243/FRN9Rw62Fn8EtxjEYWHXRvjS43YtueEewbS6ObfXcJNyohjHqVKFPoXXUxwc+q1K7Dee6vv9g==" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="/stylesheets/style.css?v=2"> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha512-SfTiTlX6kk+qitfevl/7LibUOeJWlt9rbyDn92a1DqWOw9vWG2MFoays0sgObmWazO5BQPiFucnnEAjpAB+/Sw==" crossorigin="anonymous">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>
    <script>
        $(function() {
            var availableTags = [
                "af-ZA;South Africa",
                "ar-XA;United Arab Emirates",
                "bg-BG;Bulgaria",
                "bn-IN;India",
                "ca-ES;Spain",
                "cmn-CN;China",
                "cs-CZ;Czech Republic",
                "da-DK;Denmark",
                "de-DE;Germany",
                "el-GR;Greece",
                "en-AU;Australia",
                "en-GB;UK",
                "en-US;US",
                "es-ES;Spain",
                "es-US;Spain",
                "fi-FI;Finland",
                "fil-PH;Philippines",
                "fr-CA;Canada",
                "fr-FR;France",
                "hi-IN;India",
                "hu-HU;Hungary",
                "id-ID;Indonesia",
                "is-IS;Iceland",
                "it-IT;Italy",
                "ja-JP;Japan",
                "ko-KR;South Korea",
                "lv-LV;Latvia",
                "ms-MY;Malaysia",
                "nb-NO;Norway",
                "nl-NL;Netherlands",
                "pl-PL;Poland",
                "pt-BR;Brazil",
                "pt-PT;Portugal",
                "ro-RO;Romania",
                "ru-RU;Russia",
                "sk-SK;Slovakia",
                "sr-RS;Cyrillic",
                "sv-SE;Sweden",
                "th-TH;Thailand",
                "tr-TR;Turkey",
                "uk-UA;Ukraine",
                "vi-VN;Vietnam"
            ];
            $("#country").autocomplete({
                source: availableTags
            });
        });
    </script>
</head>
<h1 style="text-align:center">Dünya Sesi Yükle</h1>
<div class="d-flex justify-content-md-center">
    <form action="entry" method="POST">
    
    <table style="width:100%">
  <tr>
    <td><label>Metin:</label></th>
    <td><input type="text" id="metin" name="metin"></th> 
  </tr>
  <tr>
    <td><label>Latin Metin:</label></td>
    <td> <input id="latin" name="latin"></td> 
  </tr>
  <tr>
    <td> <label>Dil Kodu:</label></td>
    <td><input id="country" name="country"></td> 
  </tr>
</table> 
        <h5 style="text-align:center"><input type="submit" value="Kaydet"></h5>
    </form>
    <br><br>
</div>
<br>
<h1 style="text-align:center">Ülke Kodu Listesi</h1>
<br>
<div class="d-flex justify-content-md-center">
    <table>
        <tbody>
            <tr>
                <th style="text-align:center">Dil</th>
                <th style="text-align:center">Kod</th>
                <th style="text-align:center">Ses</th>
                <th style="text-align:center">Cinsiyet</th>
                <th style="text-align:center">Ornek</th>
            </tr>

            <tr>
                <td>Afrikaans (South Africa)</td>
                <td>af-ZA</td>
                <td>af-ZA-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/af-ZA-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Arabic</td>
                <td>ar-XA</td>
                <td>ar-XA-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ar-XA-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Bengali (India)</td>
                <td>bn-IN</td>
                <td>bn-IN-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/bn-IN-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Bengali (India)</td>
                <td>bn-IN</td>
                <td>bn-IN-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/bn-IN-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Bengali (India)</td>
                <td>bn-IN</td>
                <td>bn-IN-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/bn-IN-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Bengali (India)</td>
                <td>bn-IN</td>
                <td>bn-IN-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/bn-IN-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Bulgarian (Bulgaria)</td>
                <td>bg-BG</td>
                <td>bg-bg-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/bg-bg-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Catalan (Spain)</td>
                <td>ca-ES</td>
                <td>ca-es-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ca-es-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Czech (Czech Republic)</td>
                <td>cs-CZ</td>
                <td>cs-CZ-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cs-CZ-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Czech (Czech Republic)</td>
                <td>cs-CZ</td>
                <td>cs-CZ-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cs-CZ-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Danish (Denmark)</td>
                <td>da-DK</td>
                <td>da-DK-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/da-DK-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Dutch (Netherlands)</td>
                <td>nl-NL</td>
                <td>nl-NL-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nl-NL-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (Australia)</td>
                <td>en-AU</td>
                <td>en-AU-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-AU-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Standard-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Standard-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (UK)</td>
                <td>en-GB</td>
                <td>en-GB-Wavenet-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-GB-Wavenet-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-A</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-G</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-G.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-H</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-H.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-I</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-I.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Standard-J</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Standard-J.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-A</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-G</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-G.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-H</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-H.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-I</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-I.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>English (US)</td>
                <td>en-US</td>
                <td>en-US-Wavenet-J</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/en-US-Wavenet-J.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Standard-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Wavenet-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Filipino (Philippines)</td>
                <td>fil-PH</td>
                <td>fil-PH-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fil-PH-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Finnish (Finland)</td>
                <td>fi-FI</td>
                <td>fi-FI-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fi-FI-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Finnish (Finland)</td>
                <td>fi-FI</td>
                <td>fi-FI-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fi-FI-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (Canada)</td>
                <td>fr-CA</td>
                <td>fr-CA-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-CA-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>French (France)</td>
                <td>fr-FR</td>
                <td>fr-FR-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/fr-FR-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Standard-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Standard-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>German (Germany)</td>
                <td>de-DE</td>
                <td>de-DE-Wavenet-F</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/de-DE-Wavenet-F.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Greek (Greece)</td>
                <td>el-GR</td>
                <td>el-GR-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/el-GR-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Greek (Greece)</td>
                <td>el-GR</td>
                <td>el-GR-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/el-GR-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hindi (India)</td>
                <td>hi-IN</td>
                <td>hi-IN-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hi-IN-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hungarian (Hungary)</td>
                <td>hu-HU</td>
                <td>hu-HU-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hu-HU-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Hungarian (Hungary)</td>
                <td>hu-HU</td>
                <td>hu-HU-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/hu-HU-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Icelandic (Iceland)</td>
                <td>is-IS</td>
                <td>is-is-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/is-is-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Indonesian (Indonesia)</td>
                <td>id-ID</td>
                <td>id-ID-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/id-ID-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Standard-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Wavenet-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Italian (Italy)</td>
                <td>it-IT</td>
                <td>it-IT-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/it-IT-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Standard-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Wavenet-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Japanese (Japan)</td>
                <td>ja-JP</td>
                <td>ja-JP-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ja-JP-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Standard-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Wavenet-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Korean (South Korea)</td>
                <td>ko-KR</td>
                <td>ko-KR-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ko-KR-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Latvian (Latvia)</td>
                <td>lv-LV</td>
                <td>lv-lv-Standard-A</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/lv-lv-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Malay (Malaysia)</td>
                <td>ms-MY</td>
                <td>ms-MY-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ms-MY-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Mandarin Chinese</td>
                <td>cmn-CN</td>
                <td>cmn-CN-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/cmn-CN-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-NO-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-NO-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-no-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-no-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-no-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-no-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Norwegian (Norway)</td>
                <td>nb-NO</td>
                <td>nb-no-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/nb-no-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Polish (Poland)</td>
                <td>pl-PL</td>
                <td>pl-PL-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pl-PL-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Brazil)</td>
                <td>pt-BR</td>
                <td>pt-BR-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-BR-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Brazil)</td>
                <td>pt-BR</td>
                <td>pt-BR-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-BR-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Brazil)</td>
                <td>pt-BR</td>
                <td>pt-BR-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-BR-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Brazil)</td>
                <td>pt-BR</td>
                <td>pt-BR-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-BR-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Portuguese (Portugal)</td>
                <td>pt-PT</td>
                <td>pt-PT-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/pt-PT-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>

            <tr>
                <td>Romanian (Romania)</td>
                <td>ro-RO</td>
                <td>ro-RO-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ro-RO-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Romanian (Romania)</td>
                <td>ro-RO</td>
                <td>ro-RO-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ro-RO-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Standard-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Russian (Russia)</td>
                <td>ru-RU</td>
                <td>ru-RU-Wavenet-E</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/ru-RU-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Serbian (Cyrillic)</td>
                <td>sr-RS</td>
                <td>sr-rs-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sr-rs-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Slovak (Slovakia)</td>
                <td>sk-SK</td>
                <td>sk-SK-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sk-SK-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Slovak (Slovakia)</td>
                <td>sk-SK</td>
                <td>sk-SK-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sk-SK-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (Spain)</td>
                <td>es-ES</td>
                <td>es-ES-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-ES-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Standard-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Spanish (US)</td>
                <td>es-US</td>
                <td>es-US-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/es-US-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Standard-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Standard-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Wavenet-B</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Wavenet-C</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Swedish (Sweden)</td>
                <td>sv-SE</td>
                <td>sv-SE-Wavenet-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/sv-SE-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Thai (Thailand)</td>
                <td>th-TH</td>
                <td>th-TH-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/th-TH-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Standard-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Standard-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Standard-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Wavenet-D</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Turkish (Turkey)</td>
                <td>tr-TR</td>
                <td>tr-TR-Wavenet-E</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/tr-TR-Wavenet-E.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Ukrainian (Ukraine)</td>
                <td>uk-UA</td>
                <td>uk-UA-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/uk-UA-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Ukrainian (Ukraine)</td>
                <td>uk-UA</td>
                <td>uk-UA-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/uk-UA-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Standard-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Standard-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Standard-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Standard-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Standard-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Standard-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Standard-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Standard-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Wavenet-A</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Wavenet-A.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Wavenet-B</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Wavenet-B.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Wavenet-C</td>
                <td>FEMALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Wavenet-C.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
            <tr>
                <td>Vietnamese (Vietnam)</td>
                <td>vi-VN</td>
                <td>vi-VN-Wavenet-D</td>
                <td>MALE</td>
                <td><audio controls="" preload="none">
                        <source src="/text-to-speech/docs/audio/vi-VN-Wavenet-D.wav" type="audio/wav">
                        Your browser does not support the audio element.
                    </audio>
                </td>
            </tr>
        </tbody>
    </table>
</div>

</html>