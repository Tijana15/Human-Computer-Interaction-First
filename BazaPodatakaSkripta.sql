CREATE DATABASE  IF NOT EXISTS `drogerija` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `drogerija`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: drogerija
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `brend`
--

DROP TABLE IF EXISTS `brend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brend` (
  `Naziv` varchar(45) NOT NULL,
  `Kontakt` varchar(45) NOT NULL,
  `ZemljaPorijekla` varchar(45) NOT NULL,
  PRIMARY KEY (`Naziv`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brend`
--

LOCK TABLES `brend` WRITE;
/*!40000 ALTER TABLE `brend` DISABLE KEYS */;
INSERT INTO `brend` VALUES ('Chanel','info@chanel.com','Francuska'),('Clinique','help@clinique.com','SAD'),('Dove','care@dove.com','UK'),('Garnier','contact@garnier.com','Francuska'),('L\'Oreal','contact@loreal.com','Francuska'),('MAC','support@mac.com','Kanada'),('Maybelline','support@maybelline.com','SAD'),('Nivea','info@nivea.com','Njemačka'),('Oral-B','support@oralb.com','SAD'),('Pantene','info@pantene.com','SAD');
/*!40000 ALTER TABLE `brend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brend_dobavljac`
--

DROP TABLE IF EXISTS `brend_dobavljac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brend_dobavljac` (
  `DOBAVLJAČ_IdDobavljač` int NOT NULL,
  `BREND_Naziv` varchar(45) NOT NULL,
  `PocetakRadaZaBrend` datetime NOT NULL,
  `KrajRadaZaBrend` datetime NOT NULL,
  PRIMARY KEY (`DOBAVLJAČ_IdDobavljač`,`BREND_Naziv`),
  KEY `fk_DOBAVLJAČ_has_BREND_BREND1_idx` (`BREND_Naziv`),
  KEY `fk_DOBAVLJAČ_has_BREND_DOBAVLJAČ1_idx` (`DOBAVLJAČ_IdDobavljač`),
  CONSTRAINT `fk_DOBAVLJAČ_has_BREND_BREND1` FOREIGN KEY (`BREND_Naziv`) REFERENCES `brend` (`Naziv`),
  CONSTRAINT `fk_DOBAVLJAČ_has_BREND_DOBAVLJAČ1` FOREIGN KEY (`DOBAVLJAČ_IdDobavljač`) REFERENCES `dobavljač` (`IdDobavljač`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brend_dobavljac`
--

LOCK TABLES `brend_dobavljac` WRITE;
/*!40000 ALTER TABLE `brend_dobavljac` DISABLE KEYS */;
INSERT INTO `brend_dobavljac` VALUES (1,'Nivea','2022-01-01 00:00:00','2023-01-01 00:00:00'),(2,'Dove','2021-06-15 00:00:00','2022-06-15 00:00:00'),(3,'L\'Oreal','2020-03-10 00:00:00','2021-03-10 00:00:00'),(4,'Garnier','2019-11-20 00:00:00','2020-11-20 00:00:00'),(5,'Maybelline','2022-07-25 00:00:00','2023-07-25 00:00:00'),(6,'Pantene','2021-09-30 00:00:00','2022-09-30 00:00:00'),(7,'Clinique','2020-12-15 00:00:00','2021-12-15 00:00:00'),(8,'MAC','2019-04-05 00:00:00','2020-04-05 00:00:00'),(9,'Oral-B','2021-05-20 00:00:00','2022-05-20 00:00:00'),(10,'Chanel','2020-08-10 00:00:00','2021-08-10 00:00:00');
/*!40000 ALTER TABLE `brend_dobavljac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direktor`
--

DROP TABLE IF EXISTS `direktor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `direktor` (
  `ZAPOSLENI_IdZaposlenog` int NOT NULL,
  `NALOG_IdNaloga` int NOT NULL,
  PRIMARY KEY (`ZAPOSLENI_IdZaposlenog`),
  KEY `fk_DIREKTOR_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog`),
  KEY `fk_DIREKTOR_NALOG1_idx` (`NALOG_IdNaloga`),
  CONSTRAINT `fk_DIREKTOR_NALOG1` FOREIGN KEY (`NALOG_IdNaloga`) REFERENCES `nalog` (`IdNaloga`),
  CONSTRAINT `fk_DIREKTOR_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`) REFERENCES `zaposleni` (`IdZaposlenog`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direktor`
--

LOCK TABLES `direktor` WRITE;
/*!40000 ALTER TABLE `direktor` DISABLE KEYS */;
INSERT INTO `direktor` VALUES (11,11);
/*!40000 ALTER TABLE `direktor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dobavljač`
--

DROP TABLE IF EXISTS `dobavljač`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dobavljač` (
  `IdDobavljač` int NOT NULL,
  `Naziv` varchar(45) NOT NULL,
  PRIMARY KEY (`IdDobavljač`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dobavljač`
--

LOCK TABLES `dobavljač` WRITE;
/*!40000 ALTER TABLE `dobavljač` DISABLE KEYS */;
INSERT INTO `dobavljač` VALUES (1,'ABC Dobavljač'),(2,'XYZ Distribucija'),(3,'Beauty Supply'),(4,'Cosmetic World'),(5,'HealthCare Plus'),(6,'Fragrance Distribution'),(7,'Top Beauty'),(8,'Wellness Co'),(9,'HairCare Experts'),(10,'NailArt Supplies');
/*!40000 ALTER TABLE `dobavljač` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kasa`
--

DROP TABLE IF EXISTS `kasa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kasa` (
  `IdKasa` int NOT NULL,
  PRIMARY KEY (`IdKasa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kasa`
--

LOCK TABLES `kasa` WRITE;
/*!40000 ALTER TABLE `kasa` DISABLE KEYS */;
INSERT INTO `kasa` VALUES (1),(2),(3);
/*!40000 ALTER TABLE `kasa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kasa_koristenje`
--

DROP TABLE IF EXISTS `kasa_koristenje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kasa_koristenje` (
  `NALOG_IdNaloga` int NOT NULL,
  `KASA_IdKasa` int NOT NULL,
  `VrijemePocetka` datetime NOT NULL,
  `VrijemeZavrsetka` datetime NOT NULL,
  `IdKoristenjaKase` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IdKoristenjaKase`),
  UNIQUE KEY `VrijemePocetka_UNIQUE` (`VrijemePocetka`),
  UNIQUE KEY `VrijemeZavrsetka_UNIQUE` (`VrijemeZavrsetka`),
  KEY `fk_NALOG_has_KASA_KASA1_idx` (`KASA_IdKasa`),
  KEY `fk_NALOG_has_KASA_NALOG1_idx` (`NALOG_IdNaloga`),
  CONSTRAINT `fk_NALOG_has_KASA_KASA1` FOREIGN KEY (`KASA_IdKasa`) REFERENCES `kasa` (`IdKasa`),
  CONSTRAINT `fk_NALOG_has_KASA_NALOG1` FOREIGN KEY (`NALOG_IdNaloga`) REFERENCES `nalog` (`IdNaloga`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kasa_koristenje`
--

LOCK TABLES `kasa_koristenje` WRITE;
/*!40000 ALTER TABLE `kasa_koristenje` DISABLE KEYS */;
INSERT INTO `kasa_koristenje` VALUES (1,1,'2024-06-15 08:00:00','2024-06-15 16:00:00',1),(2,1,'2024-06-16 08:00:00','2024-06-16 16:00:00',2),(3,2,'2024-06-17 08:00:00','2024-06-17 16:00:00',3),(4,2,'2024-06-18 08:00:00','2024-06-18 16:00:00',4),(5,3,'2024-06-19 08:00:00','2024-06-19 16:00:00',5),(6,3,'2024-06-20 08:00:00','2024-06-20 16:00:00',6),(7,1,'2024-06-21 08:00:00','2024-06-21 16:00:00',7),(8,2,'2024-06-22 08:00:00','2024-06-22 16:00:00',8),(9,3,'2024-06-23 08:00:00','2024-06-23 16:00:00',9),(10,1,'2024-06-24 08:00:00','2024-06-24 16:00:00',10);
/*!40000 ALTER TABLE `kasa_koristenje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kategorija`
--

DROP TABLE IF EXISTS `kategorija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kategorija` (
  `Naziv` varchar(50) NOT NULL,
  `Opis` varchar(200) NOT NULL,
  `IdKategorija` int NOT NULL AUTO_INCREMENT,
  `ODJEL_IdOdjela` int NOT NULL,
  PRIMARY KEY (`IdKategorija`),
  KEY `fk_KATEGORIJA_ODJEL1_idx` (`ODJEL_IdOdjela`),
  CONSTRAINT `fk_KATEGORIJA_ODJEL1` FOREIGN KEY (`ODJEL_IdOdjela`) REFERENCES `odjel` (`IdOdjela`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kategorija`
--

LOCK TABLES `kategorija` WRITE;
/*!40000 ALTER TABLE `kategorija` DISABLE KEYS */;
INSERT INTO `kategorija` VALUES ('Kreme za lice','Kreme za hidrataciju i njegu lica',1,7),('Šamponi','Šamponi za sve tipove kose uključujući masnu i suvu',2,8),('Puderi','Tekući i kompaktni puderi',3,6),('Ruž za usne','Različite nijanse ruževa za usne',4,6),('Parfemi za žene','Razni parfemi za žene',5,5),('Parfemi za muškarce','Razni parfemi za muškarce',6,5),('Lakovi za nokte','Različite boje i vrste lakova za nokte',7,9),('Losioni za tijelo','Losioni za hidrataciju i njegu tijela',8,10),('Zubne paste','Razne vrste zubnih pasti',9,2),('Vitamini','Dodaci prehrani i vitamini',10,3);
/*!40000 ALTER TABLE `kategorija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nabavljanje`
--

DROP TABLE IF EXISTS `nabavljanje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nabavljanje` (
  `DOBAVLJAČ_IdDobavljač` int NOT NULL,
  `DatumNabavke` date NOT NULL,
  `IdNabavke` int NOT NULL AUTO_INCREMENT,
  `ZAPOSLENI_IdZaposlenog` int NOT NULL,
  PRIMARY KEY (`IdNabavke`),
  KEY `fk_DOBAVLJAČ_has_STAVKA_NABAVKE_DOBAVLJAČ1_idx` (`DOBAVLJAČ_IdDobavljač`),
  KEY `fk_NABAVLJANJE_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog`),
  CONSTRAINT `fk_DOBAVLJAČ_has_STAVKA_NABAVKE_DOBAVLJAČ1` FOREIGN KEY (`DOBAVLJAČ_IdDobavljač`) REFERENCES `dobavljač` (`IdDobavljač`),
  CONSTRAINT `fk_NABAVLJANJE_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`) REFERENCES `zaposleni` (`IdZaposlenog`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nabavljanje`
--

LOCK TABLES `nabavljanje` WRITE;
/*!40000 ALTER TABLE `nabavljanje` DISABLE KEYS */;
INSERT INTO `nabavljanje` VALUES (1,'2023-05-10',1,1),(2,'2023-05-12',2,2),(3,'2023-05-15',3,3),(4,'2023-05-18',4,4),(5,'2023-05-20',5,5),(6,'2023-05-22',6,6),(7,'2023-05-25',7,7),(8,'2023-05-28',8,8),(9,'2023-05-30',9,9),(10,'2023-06-01',10,10);
/*!40000 ALTER TABLE `nabavljanje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nalog`
--

DROP TABLE IF EXISTS `nalog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nalog` (
  `KorisnickoIme` varchar(45) NOT NULL,
  `Lozinka` varchar(45) NOT NULL,
  `IdNaloga` int NOT NULL,
  `Tema` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdNaloga`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nalog`
--

LOCK TABLES `nalog` WRITE;
/*!40000 ALTER TABLE `nalog` DISABLE KEYS */;
INSERT INTO `nalog` VALUES ('jovan.jovanovic','jovan123',1,NULL),('milica.petrovic','milica123',2,NULL),('stefan.djordjevic','stefan123',3,'NightTheme'),('ana.markovic','ana123',4,NULL),('nikola.nikolic','nikola123',5,'NormalLightTheme'),('jovana.stojanovic','jovana123',6,NULL),('filip.ilic','filip123',7,'NightTheme'),('mila.pavlovic','mila123',8,NULL),('marko.stankovic','marko123',9,NULL),('jelena.simic','jelena123',10,NULL),('tijana.lazendic','tijana123',11,'NightTheme');
/*!40000 ALTER TABLE `nalog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `odjel`
--

DROP TABLE IF EXISTS `odjel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `odjel` (
  `IdOdjela` int NOT NULL,
  `Naziv` varchar(45) NOT NULL,
  PRIMARY KEY (`IdOdjela`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `odjel`
--

LOCK TABLES `odjel` WRITE;
/*!40000 ALTER TABLE `odjel` DISABLE KEYS */;
INSERT INTO `odjel` VALUES (1,'Kozmetika'),(2,'Lična njega'),(3,'Zdravlje'),(4,'Kućne potrepštine'),(5,'Parfemi'),(6,'Makeup'),(7,'Njega kože'),(8,'Njega kose'),(9,'Njega noktiju'),(10,'Njega tijela');
/*!40000 ALTER TABLE `odjel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poklon_bon`
--

DROP TABLE IF EXISTS `poklon_bon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `poklon_bon` (
  `IdPoklonBona` int NOT NULL AUTO_INCREMENT,
  `PRODAJNI_ARTIKL_PROIZVOD_IdProizvod` int NOT NULL,
  PRIMARY KEY (`IdPoklonBona`),
  KEY `fk_POKLON_BON_PRODAJNI_ARTIKL1_idx` (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`),
  CONSTRAINT `fk_POKLON_BON_PRODAJNI_ARTIKL1` FOREIGN KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`) REFERENCES `prodajni_artikl` (`PROIZVOD_IdProizvod`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poklon_bon`
--

LOCK TABLES `poklon_bon` WRITE;
/*!40000 ALTER TABLE `poklon_bon` DISABLE KEYS */;
INSERT INTO `poklon_bon` VALUES (1,1),(2,3),(3,5),(4,8),(5,9);
/*!40000 ALTER TABLE `poklon_bon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `popust`
--

DROP TABLE IF EXISTS `popust`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `popust` (
  `IdPopust` int NOT NULL,
  `ProcenatPopusta` int NOT NULL,
  `DatumPocetka` datetime NOT NULL,
  `DatumKraja` datetime NOT NULL,
  `BREND_Naziv` varchar(45) DEFAULT NULL,
  `PROIZVOD_IdProizvod` int DEFAULT NULL,
  PRIMARY KEY (`IdPopust`),
  KEY `fk_POPUST_BREND1_idx` (`BREND_Naziv`),
  KEY `fk_POPUST_PROIZVOD1_idx` (`PROIZVOD_IdProizvod`),
  CONSTRAINT `fk_POPUST_BREND1` FOREIGN KEY (`BREND_Naziv`) REFERENCES `brend` (`Naziv`),
  CONSTRAINT `fk_POPUST_PROIZVOD1` FOREIGN KEY (`PROIZVOD_IdProizvod`) REFERENCES `proizvod` (`IdProizvod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `popust`
--

LOCK TABLES `popust` WRITE;
/*!40000 ALTER TABLE `popust` DISABLE KEYS */;
INSERT INTO `popust` VALUES (1,15,'2024-06-01 00:00:00','2024-06-30 23:59:59','Nivea',NULL),(2,20,'2024-07-01 00:00:00','2024-07-31 23:59:59','Maybelline',NULL),(3,10,'2024-06-15 00:00:00','2024-07-15 23:59:59',NULL,3),(4,25,'2024-06-10 00:00:00','2024-07-10 23:59:59',NULL,8),(5,30,'2024-06-20 00:00:00','2024-07-20 23:59:59','Chanel',NULL);
/*!40000 ALTER TABLE `popust` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prodajni_artikl`
--

DROP TABLE IF EXISTS `prodajni_artikl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prodajni_artikl` (
  `Cijena` decimal(10,2) NOT NULL,
  `PROIZVOD_IdProizvod` int NOT NULL,
  `STAVKA_NABAVKE_NABAVLJANJE_IdNabavke` int NOT NULL,
  PRIMARY KEY (`PROIZVOD_IdProizvod`,`STAVKA_NABAVKE_NABAVLJANJE_IdNabavke`),
  KEY `fk_PRODAJNI_ARTIKL_PROIZVOD1_idx` (`PROIZVOD_IdProizvod`),
  KEY `fk_PRODAJNI_ARTIKL_STAVKA_NABAVKE1_idx` (`STAVKA_NABAVKE_NABAVLJANJE_IdNabavke`),
  CONSTRAINT `fk_PRODAJNI_ARTIKL_STAVKA_NABAVKE1` FOREIGN KEY (`STAVKA_NABAVKE_NABAVLJANJE_IdNabavke`) REFERENCES `stavka_nabavke` (`NABAVLJANJE_IdNabavke`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prodajni_artikl`
--

LOCK TABLES `prodajni_artikl` WRITE;
/*!40000 ALTER TABLE `prodajni_artikl` DISABLE KEYS */;
INSERT INTO `prodajni_artikl` VALUES (55.00,1,1),(30.00,2,2),(40.00,3,3),(20.00,4,4),(60.00,5,5),(25.00,6,6),(38.00,7,7),(15.00,8,8),(28.00,9,9),(50.00,10,10);
/*!40000 ALTER TABLE `prodajni_artikl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proizvod`
--

DROP TABLE IF EXISTS `proizvod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proizvod` (
  `Naziv` varchar(20) NOT NULL,
  `Opis` varchar(200) NOT NULL,
  `KoličinaNaStanju` int NOT NULL,
  `Sastav` varchar(200) NOT NULL,
  `IdProizvod` int NOT NULL,
  `KATEGORIJA_IdKategorija` int NOT NULL,
  `BREND_Naziv` varchar(45) NOT NULL,
  PRIMARY KEY (`IdProizvod`),
  KEY `fk_PROIZVOD_KATEGORIJA_idx` (`KATEGORIJA_IdKategorija`),
  KEY `fk_PROIZVOD_BREND1_idx` (`BREND_Naziv`),
  CONSTRAINT `fk_PROIZVOD_BREND1` FOREIGN KEY (`BREND_Naziv`) REFERENCES `brend` (`Naziv`),
  CONSTRAINT `fk_PROIZVOD_KATEGORIJA` FOREIGN KEY (`KATEGORIJA_IdKategorija`) REFERENCES `kategorija` (`IdKategorija`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proizvod`
--

LOCK TABLES `proizvod` WRITE;
/*!40000 ALTER TABLE `proizvod` DISABLE KEYS */;
INSERT INTO `proizvod` VALUES ('Nivea krema za lice','Hidratantna krema za lice',100,'Aqua, Glycerin, Paraffinum Liquidum',1,1,'Nivea'),('Pantene šampon','Šampon za sve tipove kose',200,'Aqua, Sodium Laureth Sulfate, Cocamidopropyl Betaine',2,2,'Pantene'),('Maybelline puder','Velika pokrivna moć',150,'Aqua, Cyclopentasiloxane, Butylene Glycol',3,3,'Maybelline'),('MAC ruž za usne','Ruž za usne,više nijansi',120,'Ricinus Communis Seed Oil, Caprylic/Capric Triglyceride, Beeswax',4,4,'MAC'),('Chanel parfem ženski','Elegantni parfem za žene',50,'Alcohol, Parfum, Aqua',5,5,'Chanel'),('Dove losion','Hidratantni losion za tijelo',180,'Aqua, Glycerin, Stearic Acid',6,8,'Dove'),('Oral-B zubna pasta','Zubna pasta',300,'Aqua, Sorbitol, Hydrated Silica',7,9,'Oral-B'),('Garnier suplementi','Vitaminska bomba hidratacije',100,'Vitamin C, Vitamin D, Magnesium',8,10,'Garnier'),('L\'Oreal lak za nokte','Lak za nokte,razni',250,'Butyl Acetate, Ethyl Acetate, Nitrocellulose',9,7,'L\'Oreal'),('Clinique parfem','Elegantni parfem za muškarce',60,'Alcohol, Parfum, Aqua',10,6,'Clinique');
/*!40000 ALTER TABLE `proizvod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promoter`
--

DROP TABLE IF EXISTS `promoter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `promoter` (
  `IdPromoter` int NOT NULL AUTO_INCREMENT,
  `ZAPOSLENI_IdZaposlenog` int NOT NULL,
  `BREND_Naziv` varchar(45) NOT NULL,
  PRIMARY KEY (`IdPromoter`),
  KEY `fk_PROMOTER_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog`),
  KEY `fk_PROMOTER_BREND1_idx` (`BREND_Naziv`),
  CONSTRAINT `fk_PROMOTER_BREND1` FOREIGN KEY (`BREND_Naziv`) REFERENCES `brend` (`Naziv`),
  CONSTRAINT `fk_PROMOTER_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`) REFERENCES `zaposleni` (`IdZaposlenog`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promoter`
--

LOCK TABLES `promoter` WRITE;
/*!40000 ALTER TABLE `promoter` DISABLE KEYS */;
INSERT INTO `promoter` VALUES (1,1,'Nivea'),(2,2,'L\'Oreal'),(3,3,'Maybelline'),(4,4,'Dove'),(5,5,'Garnier'),(6,6,'Chanel'),(7,7,'Clinique'),(8,8,'MAC'),(9,9,'Pantene'),(10,10,'Oral-B');
/*!40000 ALTER TABLE `promoter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `radnik`
--

DROP TABLE IF EXISTS `radnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `radnik` (
  `JeŠefSmjene` tinyint NOT NULL,
  `ZAPOSLENI_IdZaposlenog` int NOT NULL,
  `ODJEL_IdOdjela` int NOT NULL,
  `NALOG_IdNaloga` int NOT NULL,
  PRIMARY KEY (`ZAPOSLENI_IdZaposlenog`),
  KEY `fk_RADNIK_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog`),
  KEY `fk_RADNIK_ODJEL1_idx` (`ODJEL_IdOdjela`),
  KEY `fk_RADNIK_NALOG1_idx` (`NALOG_IdNaloga`),
  CONSTRAINT `fk_RADNIK_NALOG1` FOREIGN KEY (`NALOG_IdNaloga`) REFERENCES `nalog` (`IdNaloga`),
  CONSTRAINT `fk_RADNIK_ODJEL1` FOREIGN KEY (`ODJEL_IdOdjela`) REFERENCES `odjel` (`IdOdjela`),
  CONSTRAINT `fk_RADNIK_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`) REFERENCES `zaposleni` (`IdZaposlenog`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `radnik`
--

LOCK TABLES `radnik` WRITE;
/*!40000 ALTER TABLE `radnik` DISABLE KEYS */;
INSERT INTO `radnik` VALUES (1,1,1,1),(0,2,2,2),(0,3,3,3),(0,4,4,4),(0,5,5,5),(0,6,6,6),(0,7,7,7),(0,8,8,8),(0,9,9,9),(0,10,10,10);
/*!40000 ALTER TABLE `radnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `račun`
--

DROP TABLE IF EXISTS `račun`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `račun` (
  `IdRačun` int NOT NULL AUTO_INCREMENT,
  `DatumVrijemeIzdavanja` datetime NOT NULL,
  `NacinPlacanja` varchar(45) NOT NULL,
  `Iznos` decimal(10,2) NOT NULL DEFAULT '0.00',
  `KASA_IdKasa` int NOT NULL,
  `NALOG_IdNaloga` int NOT NULL,
  PRIMARY KEY (`IdRačun`),
  KEY `fk_RAČUN_KASA1_idx` (`KASA_IdKasa`),
  KEY `fk_RAČUN_NALOG1_idx` (`NALOG_IdNaloga`),
  CONSTRAINT `fk_RAČUN_KASA1` FOREIGN KEY (`KASA_IdKasa`) REFERENCES `kasa` (`IdKasa`),
  CONSTRAINT `fk_RAČUN_NALOG1` FOREIGN KEY (`NALOG_IdNaloga`) REFERENCES `nalog` (`IdNaloga`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `račun`
--

LOCK TABLES `račun` WRITE;
/*!40000 ALTER TABLE `račun` DISABLE KEYS */;
INSERT INTO `račun` VALUES (1,'2024-06-15 10:30:00','Gotovina',0.00,1,1),(2,'2024-06-15 11:45:00','Kartica',0.00,1,2),(3,'2024-06-16 09:00:00','Gotovina',0.00,2,3),(4,'2024-06-16 14:20:00','Kartica',0.00,3,4),(5,'2024-06-17 13:15:00','Gotovina',0.00,2,5),(6,'2024-06-18 12:00:00','Kartica',0.00,3,6),(7,'2024-06-19 16:30:00','Kartica',0.00,1,7),(8,'2024-06-20 10:00:00','Gotovina',0.00,2,8),(9,'2024-06-21 15:45:00','Kartica',0.00,3,9),(10,'2024-06-22 11:20:00','Gotovina',0.00,1,10),(11,'2025-04-11 16:57:31','System.Windows.Controls.ComboBoxItem: Cash',78.00,1,1),(12,'2025-04-11 17:02:58','Card',40.00,2,1),(13,'2025-04-11 17:31:54','Card',55.00,1,1);
/*!40000 ALTER TABLE `račun` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stavka_nabavke`
--

DROP TABLE IF EXISTS `stavka_nabavke`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stavka_nabavke` (
  `CijenaNabavna` decimal(10,2) NOT NULL,
  `NABAVLJANJE_IdNabavke` int NOT NULL,
  `Kolicina` int NOT NULL,
  PRIMARY KEY (`NABAVLJANJE_IdNabavke`),
  KEY `fk_STAVKA_NABAVKE_NABAVLJANJE1_idx` (`NABAVLJANJE_IdNabavke`),
  CONSTRAINT `fk_STAVKA_NABAVKE_NABAVLJANJE1` FOREIGN KEY (`NABAVLJANJE_IdNabavke`) REFERENCES `nabavljanje` (`IdNabavke`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stavka_nabavke`
--

LOCK TABLES `stavka_nabavke` WRITE;
/*!40000 ALTER TABLE `stavka_nabavke` DISABLE KEYS */;
INSERT INTO `stavka_nabavke` VALUES (50.00,1,100),(25.00,2,150),(30.00,3,120),(15.00,4,200),(40.00,5,80),(20.00,6,160),(35.00,7,90),(18.00,8,140),(22.00,9,110),(45.00,10,70);
/*!40000 ALTER TABLE `stavka_nabavke` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stavka_racun`
--

DROP TABLE IF EXISTS `stavka_racun`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stavka_racun` (
  `Količina` int NOT NULL,
  `CijenaProdajna` decimal(10,2) NOT NULL,
  `PRODAJNI_ARTIKL_PROIZVOD_IdProizvod` int NOT NULL,
  `RAČUN_IdRačun` int NOT NULL,
  PRIMARY KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`,`RAČUN_IdRačun`),
  KEY `fk_STAVKA_RACUN_RAČUN1_idx` (`RAČUN_IdRačun`),
  CONSTRAINT `fk_STAVKA_RACUN_PRODAJNI_ARTIKL1` FOREIGN KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`) REFERENCES `prodajni_artikl` (`PROIZVOD_IdProizvod`),
  CONSTRAINT `fk_STAVKA_RACUN_RAČUN1` FOREIGN KEY (`RAČUN_IdRačun`) REFERENCES `račun` (`IdRačun`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stavka_racun`
--

LOCK TABLES `stavka_racun` WRITE;
/*!40000 ALTER TABLE `stavka_racun` DISABLE KEYS */;
INSERT INTO `stavka_racun` VALUES (2,55.00,1,1),(1,55.00,1,13),(1,30.00,2,2),(3,40.00,3,3),(1,20.00,4,4),(2,60.00,5,5),(1,25.00,6,1),(2,25.00,6,6),(1,25.00,6,12),(3,38.00,7,7),(1,15.00,8,8),(1,15.00,8,12),(4,28.00,9,9),(1,28.00,9,11),(2,50.00,10,10),(1,50.00,10,11);
/*!40000 ALTER TABLE `stavka_racun` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tester`
--

DROP TABLE IF EXISTS `tester`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tester` (
  `PROIZVOD_IdProizvod` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`PROIZVOD_IdProizvod`),
  KEY `fk_TESTER_PROIZVOD1_idx` (`PROIZVOD_IdProizvod`),
  CONSTRAINT `fk_TESTER_PROIZVOD1` FOREIGN KEY (`PROIZVOD_IdProizvod`) REFERENCES `proizvod` (`IdProizvod`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tester`
--

LOCK TABLES `tester` WRITE;
/*!40000 ALTER TABLE `tester` DISABLE KEYS */;
INSERT INTO `tester` VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10);
/*!40000 ALTER TABLE `tester` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zaposleni`
--

DROP TABLE IF EXISTS `zaposleni`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zaposleni` (
  `IdZaposlenog` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(45) NOT NULL,
  `Prezime` varchar(45) NOT NULL,
  `Telefon` varchar(45) NOT NULL,
  `Adresa` varchar(45) NOT NULL,
  `Smjena` varchar(45) NOT NULL,
  `Zaduženje` varchar(45) NOT NULL,
  `Plata` decimal(10,2) NOT NULL,
  `DatumZaposlenja` date NOT NULL,
  PRIMARY KEY (`IdZaposlenog`),
  UNIQUE KEY `IdZaposlenog_UNIQUE` (`IdZaposlenog`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zaposleni`
--

LOCK TABLES `zaposleni` WRITE;
/*!40000 ALTER TABLE `zaposleni` DISABLE KEYS */;
INSERT INTO `zaposleni` VALUES (1,'Jovan','Jovanović','+381641234567','Knez Mihailova 5, Beograd','Prva smjena','Prodaja kozmetike',45000.00,'2023-02-15'),(2,'Milica','Petrović','+381611234567','Njegoševa 10, Novi Sad','Druga smjena','Nabavka robe',50000.00,'2022-09-20'),(3,'Stefan','Đorđević','+381641234567','Cara Dušana 15, Niš','Treća smjena','Računovodstvo',55000.00,'2023-01-10'),(4,'Ana','Marković','+381621234567','Kralja Petra 8, Subotica','Prva smjena','Prodaja parfema',48000.00,'2023-03-05'),(5,'Nikola','Nikolić','+381631234567','Trg Republike 3, Kragujevac','Druga smjena','Marketing',52000.00,'2022-12-12'),(6,'Jovana','Stojanović','+381641234567','Vuka Karadžića 12, Čačak','Prva smjena','Administracija',46000.00,'2023-04-18'),(7,'Filip','Ilić','+381611234567','Gospodar Jevremova 20, Zrenjanin','Treća smjena','IT podrška',58000.00,'2022-11-25'),(8,'Mila','Pavlović','+381621234567','Nikole Pašića 25, Novi Pazar','Prva smjena','Prodaja makeupa',49000.00,'2023-02-28'),(9,'Marko','Stanković','+381631234567','Svetog Save 7, Šabac','Druga smjena','Logistika',51000.00,'2022-10-08'),(10,'Jelena','Simić','+381641234567','Karađorđeva 30, Kraljevo','Treća smjena','Prodaja lijekovaa',56000.00,'2023-01-15'),(11,'Tijana','Lazendić','+38766321449','Gornji Graci bb Mrkonjić Grad','Prva smjena','Direktor',4000.00,'2025-03-11'),(20,'a','a','a','a','a','a',8000.00,'2025-07-15');
/*!40000 ALTER TABLE `zaposleni` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-12 10:47:51
