<?php
$servername="localhost";
$DBusername="root";
$DBpassword="";
$dbname="dersprogrami";

$conn=new mysqli($servername, $DBusername,$DBpassword,$dbname);

if($conn->  connect_error)  
{
  die("1". $conn->connect_error);
}
