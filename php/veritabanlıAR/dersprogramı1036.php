<?php
require "conn.php";



$sql = "SELECT 
        dp.ders_programi_id,
        dp.ders_id,
        dp.ogretmen_id,
        dp.derslik_id,
        dp.gun_id,
        dp.saat_id,
        d.ders_sinif AS ders_sinif
        FROM ders_programi dp
        JOIN ders d ON dp.ders_id = d.ders_id
        WHERE dp.derslik_id = 1";

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