<?php
require "conn.php";

// POST verilerini alma
$ad = $_POST["ogretmen_id"];

// DELETE sorgusu
$sql = "DELETE FROM ogretmen 
        WHERE ogretmen_id = '$ad'";


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