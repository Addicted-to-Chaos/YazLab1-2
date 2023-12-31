<?php
require "conn.php";



$sql="SELECT ders_id, ders_adi, ders_sinif FROM ders";
$result = $conn->query($sql);
if($result->num_rows > 0)
{
    while($row = $result->fetch_assoc()) 
    {
        echo "".$row["ders_id"]. ",".$row["ders_adi"]. ",".$row["ders_sinif"]."<br>";
    }
}
else{
    echo"0 result";
}