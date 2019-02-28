-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: mysql.labranet.jamk.fi    Database: L8317_3
-- ------------------------------------------------------
-- Server version	5.1.73

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
-- Table structure for table `HiScore`
--

DROP TABLE IF EXISTS `HiScore`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `HiScore` (
  `ID` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `Score` int(6) DEFAULT NULL,
  `reg_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `PeliID` int(6) unsigned NOT NULL,
  `PelaajaID` int(6) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_PeliID` (`PeliID`),
  KEY `fk_PelaajaID` (`PelaajaID`),
  CONSTRAINT `fk_PeliID` FOREIGN KEY (`PeliID`) REFERENCES `Pelit` (`PeliID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fk_PelaajaID` FOREIGN KEY (`PelaajaID`) REFERENCES `Pelaaja` (`PelaajaID`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HiScore`
--

LOCK TABLES `HiScore` WRITE;
/*!40000 ALTER TABLE `HiScore` DISABLE KEYS */;
INSERT INTO `HiScore` VALUES (1,5,'2018-07-24 10:55:29',1,1),(2,4,'2018-07-24 10:57:57',1,1),(3,7,'2018-07-24 11:03:33',1,2),(4,7,'2018-07-24 11:41:19',1,3),(5,31,'2018-07-24 11:49:36',2,1),(6,116,'2018-07-24 11:51:40',2,2),(7,4,'2018-07-24 13:00:30',2,4),(8,10,'2018-07-24 13:39:05',1,2),(9,96,'2018-07-25 09:41:17',2,5),(10,107,'2018-07-25 09:42:44',2,6),(11,130,'2018-07-25 09:50:10',2,2),(12,145,'2018-07-25 09:57:30',2,2),(13,9,'2018-07-25 10:50:11',2,7),(14,11,'2018-07-25 10:52:09',2,8),(15,3,'2018-07-25 10:52:32',1,9),(16,5,'2018-07-25 11:16:24',1,10),(17,9,'2018-07-25 11:17:25',1,11),(18,2,'2018-07-25 12:33:25',2,8),(19,153,'2018-07-25 12:35:00',2,2),(20,19,'2018-07-25 12:35:31',2,12),(21,12,'2018-07-25 12:35:47',2,13),(22,2,'2018-07-25 12:36:03',2,14),(23,12,'2018-07-25 13:20:48',1,15),(24,141,'2018-07-31 10:25:01',2,16),(25,79,'2018-08-02 07:57:35',2,13),(26,108,'2018-08-02 08:01:30',2,2),(27,127,'2018-08-02 08:05:48',2,2),(28,149,'2018-08-02 08:07:15',2,2),(29,78,'2018-08-10 05:56:25',2,13),(30,157,'2018-08-10 05:58:21',2,17),(31,1,'2018-08-10 06:20:56',1,18),(32,101,'2018-08-10 06:42:38',2,19),(33,170,'2018-08-10 07:12:31',2,2),(34,53,'2018-08-10 07:19:28',1,1),(35,159,'2018-08-10 07:19:32',2,2),(36,2,'2018-08-15 07:02:31',2,9),(37,2,'2018-08-15 07:23:00',2,20),(38,6,'2018-08-15 08:23:34',1,20),(39,16,'2018-08-15 08:24:00',2,20),(40,70,'2018-08-15 08:56:52',2,21),(41,14,'2018-08-15 09:07:26',2,22),(42,76,'2018-08-15 09:08:46',2,23),(43,8,'2018-08-15 09:13:30',1,9),(44,60,'2018-08-15 09:14:23',2,9),(45,1,'2018-08-16 10:21:32',1,24),(46,14,'2018-08-16 10:24:03',2,25),(47,88,'2018-08-16 12:02:16',2,26),(48,101,'2018-08-16 12:03:27',2,26),(49,44,'2018-08-16 12:04:17',2,26),(50,96,'2018-08-16 12:05:47',2,26);
/*!40000 ALTER TABLE `HiScore` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Pelaaja`
--

DROP TABLE IF EXISTS `Pelaaja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Pelaaja` (
  `PelaajaID` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `Nick` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`PelaajaID`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pelaaja`
--

LOCK TABLES `Pelaaja` WRITE;
/*!40000 ALTER TABLE `Pelaaja` DISABLE KEYS */;
INSERT INTO `Pelaaja` VALUES (1,'Iiro'),(2,'Joonas'),(3,'DinkiDinki'),(4,'Null'),(5,'Jotain'),(6,'Tylilyli'),(7,'ASd'),(8,'Juuh'),(9,'Testi'),(10,'Jeesus'),(11,'Mieihanite'),(12,'Seppo'),(13,'Timo'),(14,'Reija'),(15,'Juha'),(16,'Spede'),(17,'DinsDins'),(18,'mietestailentaas'),(19,'Harski'),(20,'asd'),(21,'ihahaa'),(22,'Pulli'),(23,'Esa'),(24,'OPE'),(25,'terve'),(26,'Jake');
/*!40000 ALTER TABLE `Pelaaja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Pelit`
--

DROP TABLE IF EXISTS `Pelit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Pelit` (
  `PeliID` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `PNimi` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`PeliID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pelit`
--

LOCK TABLES `Pelit` WRITE;
/*!40000 ALTER TABLE `Pelit` DISABLE KEYS */;
INSERT INTO `Pelit` VALUES (1,'KorttiPeli'),(2,'NopeusPeli');
/*!40000 ALTER TABLE `Pelit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-17 16:00:10
