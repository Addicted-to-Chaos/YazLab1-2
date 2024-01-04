<?php
require "conn.php";

// POST verilerini alma
$ders = $_POST["ders_id"];

// DELETE sorgusu
$sql = "DELETE FROM ders 
        WHERE ders_id = '$ders'";
        

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
