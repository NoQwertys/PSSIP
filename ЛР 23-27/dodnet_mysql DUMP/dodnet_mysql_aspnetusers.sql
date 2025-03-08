-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: dodnet_mysql
-- ------------------------------------------------------
-- Server version	9.0.1

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
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('0e5dccce-7b3a-4e40-b75f-a41ad57e1ebc','lorgena.mueller93@ethereal.email','LORGENA.MUELLER93@ETHEREAL.EMAIL','lorgena.mueller93@ethereal.email','LORGENA.MUELLER93@ETHEREAL.EMAIL',1,'AQAAAAIAAYagAAAAEJMf0WUmxkitZfgqtYilJp936fWgmiTNvC3JS1dMGZWBCtbE3bOEj3IU5ZiW65xU+Q==','M36JIUM5OVFC3TBAL6ZAW6U4TUH6OS7Z','31216e3f-d681-405d-9263-cf924300bcf6',NULL,0,0,NULL,1,0),('3c641204-899f-42fd-9d9c-b5daea62e703','nico.bogisich@ethereal.email','NICO.BOGISICH@ETHEREAL.EMAIL','nico.bogisich@ethereal.email','NICO.BOGISICH@ETHEREAL.EMAIL',1,'AQAAAAIAAYagAAAAELNuWXCsSvbaBp0HLO4z4mI0ZAEdIFGtcZAmIQSbjI9STehoFLBkVUwOGF1+vxa1gA==','XYVRZ25QL7YWOLO3SP7AHS2CXDPZXWUU','f493f1d8-29e6-44d2-bf09-9559a9b5acc4',NULL,0,0,NULL,1,0),('8c9ce623-7fe4-497a-a806-c1aa69a8a5d1','User1@gmail.com','USER1@GMAIL.COM','User1@gmail.com','USER1@GMAIL.COM',1,'AQAAAAIAAYagAAAAEDG6OpSme2QPcBbndE6Z4VJyqHrJKAMdYAvDOpxOp+ca2XOlmQuXxSlILz4UxlYgKg==','BBHB3P3UREUZDWF6DUSZU5UAXFTRXW4M','b8989887-3f81-4d61-a7bf-2e789846d57d',NULL,0,0,NULL,1,0),('fdd7e572-572e-41bb-8fa6-954e650d3bd1','lorena.mueller93@ethereal.email','LORENA.MUELLER93@ETHEREAL.EMAIL','lorena.mueller93@ethereal.email','LORENA.MUELLER93@ETHEREAL.EMAIL',1,'AQAAAAIAAYagAAAAEBjD9y+DhGXMbAcgMg1N55lxr3C649aqHCjRC7Jh0MjgiFbuvtX7PJMO5aygLWJ6MA==','XKCTXHTKP77BB6JCA6KN57IEVLXB3T42','92ddcdcf-4518-4b3d-a2c3-fad7d5bdd806',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-08 18:34:17
