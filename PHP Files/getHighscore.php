<?php

$hostName = "localhost";
$userName = "root";//id17341149_mridul
$dbName = "unitybackendtutorial";//id17341149_zigzaggame

$conn = new mysqli($hostName, $userName, "", $dbName);
if(!$conn)
    die("Connection Failed" .$conn->connect_error);

$sql1= "SELECT username, score FROM user ORDER BY score DESC LIMIT 8";
$results = $conn->query($sql1);
if($results)
{
    $rows = array();
    while($row= $results->fetch_assoc()){
        $rows[] = $row;
    }

    echo json_encode($rows);
}

?>