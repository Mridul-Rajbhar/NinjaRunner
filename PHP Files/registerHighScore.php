<?php
    $hostName = "localhost";
    $userName = "root";
    $dbName = "unitybackendtutorial";

    $conn = new mysqli($hostName, $userName, "", $dbName);

    if(!$conn)
      die("Connection Failed" .$conn->connect_error);

    $newHighScore = $_POST['newHighScore'];
    $playerName = $_POST['playerName'];
    
    $sql1 = "UPDATE user SET score = '$newHighScore' Where username = '$playerName'";
    $results = $conn->query($sql1);
    if(!$results)
    {
        echo "Error ". $conn->error;
    }
    else
    {
        echo "Updated highcore";
    }
?>