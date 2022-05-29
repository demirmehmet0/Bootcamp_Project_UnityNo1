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
          echo $row["EntryID"]. ";" . $row["text"]. ";" . $row["country"]. ";" . $row["textonly"].";".$row["textlatin"].";".$row["translated"].";".explode("-",$row["country"])[0]."<br>";
        }
      } else {
        echo "0 results";
      }
}

$conn->close(); 
?>