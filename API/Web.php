<?php
defined('BASEPATH') or exit('No direct script access allowed');

class Web extends CI_Controller
{
    public function index()
    {
        $this->load->view('index.php');
    }
    public function api($data, $file = "-1", $id = "-1",$translatedtext="")
    {
        $servername = "server";
        $username = "user";
        $password = "pass";
        if ($data == "random") {
            $conn = new mysqli($servername, $username, $password, "userdb");
            $sql = "Select * FROM Entries ORDER BY RAND () LIMIT 1";
            $result = $conn->query($sql);
            if ($result->num_rows > 0) {
                // output data of each row
                while ($row = $result->fetch_assoc()) {
                    echo $row["EntryID"]. ";" . $row["text"]. ";" . $row["country"]. ";" . $row["textonly"].";".$row["textlatin"].";".$row["translated"].";".explode("-",$row["country"])[0]."<br>";
                }
            } else {
                echo "0 results";
            }
            $conn->close();
        } else if ($data == "entry") {
            $this->load->view('entry.php');
        } else if ($data == "all") {
            $this->load->view('all.php');
        } else if ($data == "save") {
            $conn = new mysqli($servername, $username, $password, "userdb");
            $sql = "UPDATE Entries set text='" . urldecode($file) . "', translated='".$translatedtext."' WHERE EntryID='" . $id . "'";
            $result = $conn->query($sql);
            $conn->close();
        }
    }
    public function hata()
    {
        echo "test";
    }
}
