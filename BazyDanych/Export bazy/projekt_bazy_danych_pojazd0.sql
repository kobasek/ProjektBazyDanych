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
-- Table structure for table `pojazd`
--

DROP TABLE IF EXISTS `pojazd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pojazd` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vin` varchar(17) NOT NULL,
  `pojemnosc_silnika` float NOT NULL,
  `rodzaj_nadwozia` varchar(20) NOT NULL,
  `nr_rejestracyjny` varchar(7) DEFAULT NULL,
  `paliwo` char(1) NOT NULL,
  `koszt` float NOT NULL,
  `elektryczne_szyby` bit(1) NOT NULL,
  `wspomaganie` bit(1) NOT NULL,
  `klimatyzacja` bit(1) NOT NULL,
  `skrzynia_biegow` bit(1) NOT NULL,
  `data_zakupu` date NOT NULL,
  `data_zlomowania` date DEFAULT NULL,
  `model_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `pojazd_ibfk_1` (`model_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pojazd`
--

LOCK TABLES `pojazd` WRITE;
/*!40000 ALTER TABLE `pojazd` DISABLE KEYS */;
INSERT INTO `pojazd` VALUES (1,'Caddy1Auto1234567',2,'Bus','SD13206','D',100000,'','','','','2016-04-25','2016-09-23',5),(2,'Caddy2Auto6789012',2,'Bus','SD13206','D',100000,'','','','','2016-07-25','2016-09-23',5),(3,'Caddy3Auto9876543',2,'Bus','','D',100000,'','','','','2016-08-25',NULL,5),(4,'AudiA3VIN12345678',2,'','SG12345','B',50000,'','','','\0','2016-09-15','2016-09-23',7);
/*!40000 ALTER TABLE `pojazd` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-23 13:49:35
