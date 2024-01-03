<?php
require "conn.php";

// POST verilerini alma
$derslik = $_POST["derslik_id"];
$gunId = $_POST["gun_id"];
$saatId = $_POST["saat_id"];

// DELETE sorgusu
$sql = "DELETE FROM ders_programi 
        WHERE derslik_id = '.$derslik.' 
        AND gun_id = '.$gunId.' 
        AND saat_id = '.$saatId.'";

try {
    // Sorguyu çalıştırma
    $result = $conn->query($sql);
    
    // Sorgu sonucunu kontrol etme
    if ($result === false) {
        die("Sorgu hatası: " . $conn->error);
    } else {
        echo "Başarılı bir şekilde silindi.";
    }
} catch (Exception $e) {
    die("Hata: " . $e->getMessage());
}

$conn->close();
?>
