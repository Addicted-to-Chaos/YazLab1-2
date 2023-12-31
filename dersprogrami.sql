CREATE DATABASE dersprogrami;

USE dersprogrami;

CREATE TABLE ogretmen (
    ogretmen_id INT PRIMARY KEY AUTO_INCREMENT,
    ad VARCHAR(50)
);

CREATE TABLE ders (
    ders_id INT PRIMARY KEY AUTO_INCREMENT,
    ders_adi VARCHAR(50),
    ders_sinif INT
);

CREATE TABLE derslik (
    derslik_id INT PRIMARY KEY AUTO_INCREMENT,
    derslik_adi VARCHAR(50)
);
/*
CREATE TABLE ders_ogretmen (
    ders_ogretmen_id INT PRIMARY KEY AUTO_INCREMENT,
    ders_id INT,
    ogretmen_id INT,
    FOREIGN KEY (ders_id) REFERENCES ders(ders_id),
    FOREIGN KEY (ogretmen_id) REFERENCES ogretmen(ogretmen_id)
);*/

CREATE TABLE gun (
    gun_id INT PRIMARY KEY AUTO_INCREMENT,
    gun_adi VARCHAR(15) NOT NULL
);

CREATE TABLE saat (
    saat_id INT PRIMARY KEY AUTO_INCREMENT,
    saat_deger VARCHAR(15) NOT NULL
);


CREATE TABLE ders_programi (
    ders_programi_id INT PRIMARY KEY AUTO_INCREMENT,
    ders_id INT,
    ogretmen_id INT,
    derslik_id INT,
    gun_id INT,
    saat_id INT,
    ders_sinif INT, 
    FOREIGN KEY (ders_id) REFERENCES ders(ders_id),
    FOREIGN KEY (ogretmen_id) REFERENCES ogretmen(ogretmen_id),
    FOREIGN KEY (derslik_id) REFERENCES derslik(derslik_id),
    FOREIGN KEY (gun_id) REFERENCES gun(gun_id),
    FOREIGN KEY (saat_id) REFERENCES saat(saat_id)
    
);



-- Gün
INSERT INTO gun (gun_adi) VALUES ('Pazartesi');
INSERT INTO gun (gun_adi) VALUES ('Sali');
INSERT INTO gun (gun_adi) VALUES ('Carsamba');
INSERT INTO gun (gun_adi) VALUES ('Persembe');
INSERT INTO gun (gun_adi) VALUES ('Cuma');

-- Saat
INSERT INTO saat (saat_deger) VALUES ('08:00');
INSERT INTO saat (saat_deger) VALUES ('09:00');
INSERT INTO saat (saat_deger) VALUES ('10:00');
INSERT INTO saat (saat_deger) VALUES ('11:00');
INSERT INTO saat (saat_deger) VALUES ('12:00');
INSERT INTO saat (saat_deger) VALUES ('13:00');
INSERT INTO saat (saat_deger) VALUES ('14:00');
INSERT INTO saat (saat_deger) VALUES ('15:00');
INSERT INTO saat (saat_deger) VALUES ('16:00');
INSERT INTO saat (saat_deger) VALUES ('17:00');

-- Ogretmenler
INSERT INTO ogretmen (ad) VALUES ('Suleyman Eken');
INSERT INTO ogretmen (ad) VALUES ('Yavuz Selim Fatihoglu');
INSERT INTO ogretmen (ad) VALUES ('Serdar Solak');
INSERT INTO ogretmen (ad) VALUES ('Bilgehan Ucar');
INSERT INTO ogretmen (ad) VALUES ('Halil Yigit');
INSERT INTO ogretmen (ad) VALUES ('Onder Yakut');

-- Dersler
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Veritabani Yonetim Sistemleri', 2);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Algoritma ve Programlama', 1);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Bilgisayar Mimari ve Organizasyonu', 3);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Ayrik Matematik', 3);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Elektrik Elektronik Devreler', 2);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Yazilim Gelistirme Lab.', 3);
INSERT INTO ders (ders_adi, ders_sinif) VALUES ('Web Tasarimi', 3);

-- Derslikler
INSERT INTO derslik (derslik_adi) VALUES ('1036');
INSERT INTO derslik (derslik_adi) VALUES ('1040');
INSERT INTO derslik (derslik_adi) VALUES ('1041');
INSERT INTO derslik (derslik_adi) VALUES ('1044');

-- Ders_Ogretmen tablosuna veri ekleme
/* INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (1, 3); 
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (2, 2);
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (3, 5); 
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (4, 1); 
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (5, 4); 
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (6, 1);
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (6, 2);
INSERT INTO ders_ogretmen (ders_id, ogretmen_id) VALUES (7, 6);*/



-- Musaitlik kontrolu procedure

DELIMITER //

CREATE PROCEDURE EkleDersProgrami(
    IN p_ders_id INT,
    IN p_derslik_id INT,
    IN p_ogretmen_id INT,
    IN p_gun_id INT,
    IN p_saat_id INT
)
BEGIN
    DECLARE ogretmen_count INT;
    DECLARE derslik_count INT;
    DECLARE sinif_count INT;

    -- İlgili öğretmenin belirli bir günde ve saatte başka dersi var mı kontrol et
    SELECT COUNT(*) INTO ogretmen_count
    FROM ders_programi
    WHERE ogretmen_id = p_ogretmen_id AND gun_id = p_gun_id AND saat_id = p_saat_id;

    -- İlgili dersligin belirli bir günde ve saatte başka dersi var mı kontrol et
    SELECT COUNT(*) INTO derslik_count
    FROM ders_programi
    WHERE derslik_id = p_derslik_id AND gun_id = p_gun_id AND saat_id = p_saat_id;

    -- İlgili sınıfın belirli bir günde ve saatte başka dersi var mı kontrol et
    SELECT COUNT(*) INTO sinif_count
    FROM ders_programi dp
    JOIN ders d ON dp.ders_id = d.ders_id
    WHERE d.ders_sinif = (SELECT ders_sinif FROM ders WHERE ders_id = p_ders_id)
      AND dp.gun_id = p_gun_id AND dp.saat_id = p_saat_id;

    -- Her üç kontrol de başarılıysa yeni ders programını ekle
    IF ogretmen_count = 0 AND derslik_count = 0 AND sinif_count = 0 THEN
        INSERT INTO ders_programi (ders_id, derslik_id, ogretmen_id, gun_id, saat_id)
        VALUES (p_ders_id, p_derslik_id, p_ogretmen_id, p_gun_id, p_saat_id);
        SELECT 'Ders programına eklendi.' AS result;
    ELSE
        SELECT 'Çakışan bir veri mevcut.' AS result;
    END IF;
END //

DELIMITER ;

-- Programa eklemek icin
-- Sırasi: ders, derslik, ogretmen, gun, saat

CALL EkleDersProgrami(1,1,3,1,1);
CALL EkleDersProgrami(4,2,1,1,4);
CALL EkleDersProgrami(2,2,2,2,1);
CALL EkleDersProgrami(3,2,5,3,2);
CALL EkleDersProgrami(6,3,1,4,5);


-- Ders programı view
CREATE VIEW ders_programi_view AS
SELECT 
    gun.gun_adi AS gun,
    saat.saat_deger AS saat,
    ders.ders_adi AS ders,
    ders.ders_sinif AS sinif, 
    derslik.derslik_adi AS derslik,
    ogretmen.ad AS ogretmen
FROM 
    ders_programi
JOIN gun ON ders_programi.gun_id = gun.gun_id
JOIN saat ON ders_programi.saat_id = saat.saat_id
JOIN ders ON ders_programi.ders_id = ders.ders_id
JOIN derslik ON ders_programi.derslik_id = derslik.derslik_id
JOIN ogretmen ON ders_programi.ogretmen_id = ogretmen.ogretmen_id
ORDER BY 
    ders_programi.gun_id, 
    ders_programi.saat_id;


-- view'ı goruntulemek icin :
-- select * from ders_programi_view;



-- Hangi ogretmen hangi dersi veriyor view
CREATE VIEW ogretmen_ders_view AS
SELECT
    ders.ders_adi AS ders,
    ogretmen.ad AS ogretmen
FROM
    ders_ogretmen
JOIN ders ON ders_ogretmen.ders_id = ders.ders_id
JOIN ogretmen ON ders_ogretmen.ogretmen_id = ogretmen.ogretmen_id;


-- view'ı goruntulemek icin
-- select * from ogretmen_ders_view;


-- Belirli bir dersliğin programını çekmek için
/*
SELECT 
    derslik.derslik_adi AS derslik,
    gun.gun_adi AS gun,
    saat.saat_deger AS saat,
    ders.ders_adi AS ders,
    ders.ders_sinif AS sinif,  -- Include class information
    ogretmen.ad AS ogretmen
FROM 
    ders_programi
JOIN gun ON ders_programi.gun_id = gun.gun_id
JOIN saat ON ders_programi.saat_id = saat.saat_id
JOIN ders ON ders_programi.ders_id = ders.ders_id
JOIN ogretmen ON ders_programi.ogretmen_id = ogretmen.ogretmen_id
JOIN derslik ON ders_programi.derslik_id = derslik.derslik_id
WHERE
    ders_programi.derslik_id = 2
ORDER BY 
    ders_programi.gun_id, 
    ders_programi.saat_id;


*/


-- belirli bir öğretmenin programini cekmek icin 

/*
SELECT
    d.ders_adi AS Ders,
    o.ad AS Ogretmen,
    dl.derslik_adi as Derslik,
    g.gun_adi as Gun,
    s.saat_deger as Saat,
    d.ders_sinif as Sinif
FROM
    ders_programi dp
JOIN ders d ON dp.ders_id = d.ders_id
JOIN ogretmen o ON dp.ogretmen_id = o.ogretmen_id
JOIN derslik dl ON dp.derslik_id = dl.derslik_id
JOIN gun g ON dp.gun_id = g.gun_id
JOIN saat s ON dp.saat_id = s.saat_id
WHERE
    dp.ogretmen_id = 1;
    
*/
;



