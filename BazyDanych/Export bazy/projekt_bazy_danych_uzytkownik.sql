-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: projekt_bazy_danych
-- ------------------------------------------------------
-- Server version	5.7.15-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `uzytkownik`
--

DROP TABLE IF EXISTS `uzytkownik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uzytkownik` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uprawnienia` char(1) NOT NULL,
  `imie` varchar(20) NOT NULL,
  `nazwisko` varchar(20) NOT NULL,
  `telefon` varchar(15) NOT NULL,
  `miejscowosc` varchar(40) NOT NULL,
  `kod_pocztowy` varchar(6) NOT NULL,
  `ulica` varchar(45) NOT NULL,
  `nr_budynku` int(11) NOT NULL,
  `nr_lokalu` int(11) DEFAULT NULL,
  `miejsce_urodzenia` varchar(20) NOT NULL,
  `data_urodzenia` date NOT NULL,
  `plec` char(1) NOT NULL,
  `nr_dowodu` varchar(9) NOT NULL,
  `pesel` varchar(11) NOT NULL,
  `prawo_jazdy` varchar(37) NOT NULL,
  `login` varchar(20) NOT NULL,
  `haslo` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uzytkownik`
--

LOCK TABLES `uzytkownik` WRITE;
/*!40000 ALTER TABLE `uzytkownik` DISABLE KEYS */;
INSERT INTO `uzytkownik` VALUES (1,'M','Łukasz','Gorzelańczyk','606287877','Dąbrowa Górnicza','41-303','Morcinka',16,169,'Sosnowiec','1992-07-05','M','ASW569874','92050707952','B','Bazzby','Test123'),(2,'O','Artur','Janoś','505698874','Katowice','69-856','Piłsudskiego',32,56,'Sosnowiec','1990-01-19','M','ASP987895','90011965985','BE','Kobasek','Test123'),(3,'K','Jan','Kowalski','659874569','Częstochowa','59-025','Podwawelska',5,4,'Zabrze','1996-12-05','K','APS569874','96120598456','C','Test','Test123'),(4,'K','sfg','sdfg','60660606','Poznań','41-303','Poznańska',1,1,'asdf','2016-09-21','K','AWR569875','96988956987','B,C1,D','aaa','aaa'),(5,'M','Jan','Nowak','256985698','Warszawa','56-906','Wyzwoleńców',6,9,'Warszawa','2016-09-22','M','ASD987569','96898752659','C','admin','admin'),(6,'O','Katarzyna','Wcisło','569874563','Wodzisław Śląski','98-569','Rolna',2,3,'Wodzisław Śląski','2016-09-22','K','RTY986985','56987845698','C,D','opiekun','opiekun'),(7,'K','Paweł','Kowalski','658965874','Ogrodzeniec','45-986','Zamkowa',6,9,'Zawiercie','2016-09-22','M','FGH986598','65987856986','B,C,D,DE','kierowca','kierowca');
/*!40000 ALTER TABLE `uzytkownik` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-22 22:05:16
