<?php
require "conn.php";


$dersId=$_POST["p_ders_id"];
$derslikId=$_POST["p_derslik_id"];
$ogretmenId=$_POST["p_ogretmen_id"];
$gunId=$_POST["p_gun_id"];
$saatId=$_POST["p_saat_id"];

$sql="CALL EkleDersProgrami('.$dersID.','.$derslikId.','.$ogretmenId.','.$gunId.','.$saatId.')";


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
