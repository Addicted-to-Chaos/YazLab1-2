<?php
require "conn.php";


$dersOgretmenId=$_POST["ders_ogretmen_id"];
$dersId=$_POST["ders_id"];
$ogretmenId=$_POST["ogretmen_id"];


$sql="INSERT INTO ders_ogretmen(ders_ogretmen_id,ders_id,ogretmen_id)VALUES('".$dersOgretmenId."','".$dersId."','".$ogretmenId."')";


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
