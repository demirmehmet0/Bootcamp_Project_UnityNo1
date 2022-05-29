<?php 
$servername = "server";
$username = "user";
$password = "pass";  
// Create connection
$conn = new mysqli($servername, $username, $password,"userdb");

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
else{
    $sql = "Select * FROM Entries";
    $result = $conn->query($sql); 
    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
          echo urldecode($row["EntryID"]). ";" . urldecode($row["text"]). ";" . urldecode($row["country"]). ";" . urldecode($row["textonly"]).";".urldecode($row["textlatin"]).";".urldecode($row["translated"])."<br>";
        }
      } else {
        echo "0 results";
      }
}

$conn->close(); 
?>