<?php 
    $hostName = "localhost";
    $userName = "root";
    $dbName = "unitybackendtutorial";

    $conn = new mysqli($hostName, $userName, "", $dbName);

    if(!$conn)
      die("Connection Failed" .$conn->connect_error);

   $userLoginName = $_POST['loginUserName'];
    $userPassword = $_POST['loginUserPassword'];

    $sql1 = "SELECT password, score FROM user Where username = '$userLoginName'";
 
    $results = $conn->query($sql1);
    if($results)
    {
        if($results->num_rows > 0)
        {
            while($row = $results->fetch_assoc())
            {
                //echo $row["password"]." and $userPassword";

               if($row["password"] == $userPassword)
               {
                   echo "Successfull Login,".$row["score"];
               }
               else
               {
                   echo "Wrong Password";
               }
            }
        }
        else
        {
            echo "No user with this username Found";
        }
    }
    else
    {
        echo "UserName does not exist";
    }

    $conn->close();
?>