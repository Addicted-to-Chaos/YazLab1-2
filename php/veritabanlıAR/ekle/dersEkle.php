<?php
require "conn.php";


$dersId=$_POST["ders_id"];
$dersAdi=$_POST["ders_adi"];
$dersSinif=$_POST["ders_sinif"];


$sql="INSERT INTO ders(ders_id,ders_adi,ders_sinif)VALUES('".$ders_id."','".$dersAdi."','".$dersSinif."')";


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
