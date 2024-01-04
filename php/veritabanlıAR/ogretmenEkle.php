<?php
require "conn.php";


$ogretmenId=$_POST["ogretmen_id"];
$ad=$_POST["ad"];


$sql="INSERT INTO ogretmen(ad)VALUES('".$ad."')";


try
{
    $sql=$conn->query($sql);
    if($sql===false)
    {
        die("22". $conn->error);

    }

}
catch(Exception $e)
{
die ("30". $e->getMessage());
}
echo("Basarili");
$conn->close();