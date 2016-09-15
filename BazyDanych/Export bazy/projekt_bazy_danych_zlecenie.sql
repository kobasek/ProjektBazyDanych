CREATE DATABASE  IF NOT EXISTS `projekt_bazy_danych` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `projekt_bazy_danych`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: projekt_bazy_danych
-- ------------------------------------------------------
-- Server version	5.7.14-log

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
-- Table structure for table `zlecenie`
--

DROP TABLE IF EXISTS `zlecenie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zlecenie` (
  `id` int(11) NOT NULL,
  `planowana_data_rozpoczecia` date NOT NULL,
  `planowana_data_zakonczenia` date NOT NULL,
  `faktyczna_data_rozpoczecia` date DEFAULT NULL,
  `faktyczna_data_zakonczenia` date DEFAULT NULL,
  `stan_licznika_przed` int(11) DEFAULT NULL,
  `stan_licznika_po` int(11) DEFAULT NULL,
  `uwagi_przed` varchar(255) DEFAULT NULL,
  `uwagi_po` varchar(255) DEFAULT NULL,
  `rodzaj_zlecenia` char(1) NOT NULL,
  `koszt` float DEFAULT NULL,
  `powod_anulowania` varchar(255) DEFAULT NULL,
  `stan_zlecenia` char(1) NOT NULL,
  `opieka_id` int(11) NOT NULL,
  `uzytkownik_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `uzytkownik_id` (`uzytkownik_id`),
  KEY `opieka_id` (`opieka_id`),
  CONSTRAINT `zlecenie_ibfk_1` FOREIGN KEY (`uzytkownik_id`) REFERENCES `uzytkownik` (`id`),
  CONSTRAINT `zlecenie_ibfk_2` FOREIGN KEY (`opieka_id`) REFERENCES `opieka` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zlecenie`
--

LOCK TABLES `zlecenie` WRITE;
/*!40000 ALTER TABLE `zlecenie` DISABLE KEYS */;
/*!40000 ALTER TABLE `zlecenie` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-10 11:41:31