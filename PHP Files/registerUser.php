<?php
    $hostname = "localhost";
    $username = "root";
    $dbName = "unitybackendtutorial";

    $conn = new mysqli($hostname, $username, "", $dbName);
    if(!$conn)
    {die("Connection Failed ".$conn->connect_error);}

    $userSignUpName = $_POST['signUpUserName'];
    $userSignUpPassword = $_POST['signUpUserPassword'];

    $sql1 = "SELECT username FROM user Where username= '$userSignUpName'";
    $result1 = $conn->query($sql1);
    if($result1->num_rows >0)
    {
        echo "Name Already Exist";
    }
    else
    {
        $sql2 = "INSERT INTO user(username, password, score) VALUES ('$userSignUpName','$userSignUpPassword', 0)";
        if($conn->query($sql2))
        {
            echo "Record Inserted";
        }
        else
        {
            echo "Record Not Insterted. ".$conn->error;
        }
    }
?>