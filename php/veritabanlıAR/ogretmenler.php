<?php
require "conn.php";



$sql="SELECT ogretmen_id, ad FROM ogretmen";
$result = $conn->query($sql);
if($result->num_rows > 0)
{
    while($row = $result->fetch_assoc()) 
    {
        echo "".$row["ogretmen_id"]. ",".$row["ad"]."<br>";
    }
}
else{
    echo"0 result";
}