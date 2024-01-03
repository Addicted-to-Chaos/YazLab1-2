<?php
require "conn.php";



$sql="SELECT ders_programi_id, ders_id, ogretmen_id, derslik_id, gun_id, saat_id, ders_sinif FROM ders_programi WHERE derslik_id = 2;";
$result = $conn->query($sql);
if($result->num_rows > 0)
{
    while($row = $result->fetch_assoc()) 
    {
        echo "".$row["ders_programi_id"]. ",".$row["ders_id"]. ",".$row["ogretmen_id"].",".$row["derslik_id"].",".$row[ "gun_id"]. ",".$row["saat_id"]. ",".$row["ders_sinif"]."<br>";
    }
}
else{
    echo"0 result";
}