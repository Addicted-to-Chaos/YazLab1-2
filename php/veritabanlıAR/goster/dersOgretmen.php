<?php
require "conn.php";



$sql="SELECT ders_ogretmen_id ders_id ogretmen_id FROM ders_ogretmen";
$result = $conn->query($sql);
if($result->num_rows > 0)
{
    while($row = $result->fetch_assoc()) 
    {
        echo "".$row["ders_ogretmen_id"]. ",".$row["ders_id"]. ",".$row["ogretmen_id"]."<br>";
    }
}
else{
    echo"0 result";
}