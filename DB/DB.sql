-- MySQL dump 10.13  Distrib 8.4.4, for Win64 (x86_64)
--
-- Host: localhost    Database: dbproj
-- ------------------------------------------------------
-- Server version	8.4.3

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `discount`
--

DROP TABLE IF EXISTS `discount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `discount` (
  `idDiscount` int NOT NULL AUTO_INCREMENT,
  `idProduct` int NOT NULL,
  `discount` int NOT NULL,
  `startDate` date DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  PRIMARY KEY (`idDiscount`),
  KEY `discount_product_idx` (`idProduct`),
  CONSTRAINT `discount_product` FOREIGN KEY (`idProduct`) REFERENCES `product` (`idProduct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discount`
--

LOCK TABLES `discount` WRITE;
/*!40000 ALTER TABLE `discount` DISABLE KEYS */;
/*!40000 ALTER TABLE `discount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `game`
--

DROP TABLE IF EXISTS `game`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `game` (
  `idGame` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `developer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idGame`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `game`
--

LOCK TABLES `game` WRITE;
/*!40000 ALTER TABLE `game` DISABLE KEYS */;
INSERT INTO `game` VALUES (1,'Tienda De Ropa Chida','Ozcar'),(2,'Tienda De Ropa Chida','Ozcar');
/*!40000 ALTER TABLE `game` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `idProduct` int NOT NULL AUTO_INCREMENT,
  `idProductCategory` int NOT NULL,
  `idProductRarity` int NOT NULL,
  `idGame` int NOT NULL,
  `imgURL` varchar(200) NOT NULL,
  `name` varchar(45) NOT NULL,
  `salePrice` float DEFAULT NULL,
  `rentPrice` float DEFAULT NULL,
  PRIMARY KEY (`idProduct`),
  KEY `product_productCategory_idx` (`idProductCategory`),
  KEY `product_productRarity_idx` (`idProductRarity`),
  KEY `product_game_idx` (`idGame`),
  CONSTRAINT `product_game` FOREIGN KEY (`idGame`) REFERENCES `game` (`idGame`),
  CONSTRAINT `product_productCategory` FOREIGN KEY (`idProductCategory`) REFERENCES `productcategory` (`idProductCategory`),
  CONSTRAINT `product_productRarity` FOREIGN KEY (`idProductRarity`) REFERENCES `productrarity` (`idProductRarity`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,1,1,1,'https://example.com/camiseta1.jpg','Camiseta Básica Negra',299.99,49.99),(2,1,2,1,'https://example.com/camiseta2.jpg','Camiseta Edición Verano',399.99,69.99),(3,2,3,1,'https://example.com/pantalon1.jpg','Jeans Premium',899.99,149.99),(4,2,1,1,'https://example.com/pantalon2.jpg','Pants Deportivos',449.99,79.99),(5,3,4,1,'https://example.com/zapatos1.jpg','Tenis Exclusivos',1499.99,249.99),(6,3,2,1,'https://example.com/zapatos2.jpg','Sandalias de Verano',599.99,99.99),(7,4,1,1,'https://example.com/accesorio1.jpg','Gorra Clásica',199.99,39.99),(8,4,3,1,'https://example.com/accesorio2.jpg','Collar Deluxe',799.99,129.99),(9,1,4,1,'https://example.com/camiseta3.jpg','Camiseta Colección Limitada',999.99,169.99),(10,2,2,1,'https://example.com/pantalon3.jpg','Shorts Premium',499.99,89.99);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productcategory`
--

DROP TABLE IF EXISTS `productcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productcategory` (
  `idProductCategory` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `descript` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idProductCategory`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productcategory`
--

LOCK TABLES `productcategory` WRITE;
/*!40000 ALTER TABLE `productcategory` DISABLE KEYS */;
INSERT INTO `productcategory` VALUES (1,'Camisetas','Ropa casual y cómoda'),(2,'Pantalones','Pantalones de varios estilos'),(3,'Zapatos','Calzado de moda'),(4,'Accesorios','Complementos de vestir');
/*!40000 ALTER TABLE `productcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productrarity`
--

DROP TABLE IF EXISTS `productrarity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productrarity` (
  `idProductRarity` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `duration` int DEFAULT NULL,
  PRIMARY KEY (`idProductRarity`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productrarity`
--

LOCK TABLES `productrarity` WRITE;
/*!40000 ALTER TABLE `productrarity` DISABLE KEYS */;
INSERT INTO `productrarity` VALUES (1,'Común','Artículos básicos',30),(2,'Raro','Artículos de edición limitada',60),(3,'Épico','Artículos exclusivos',90),(4,'Legendario','Artículos de colección',120);
/*!40000 ALTER TABLE `productrarity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rent`
--

DROP TABLE IF EXISTS `rent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rent` (
  `idRent` int NOT NULL AUTO_INCREMENT,
  `idUser` int unsigned NOT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`idRent`),
  KEY `rent_user_idx` (`idUser`),
  CONSTRAINT `rent_user` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rent`
--

LOCK TABLES `rent` WRITE;
/*!40000 ALTER TABLE `rent` DISABLE KEYS */;
/*!40000 ALTER TABLE `rent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rentdetail`
--

DROP TABLE IF EXISTS `rentdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rentdetail` (
  `idRent` int NOT NULL,
  `idProduct` int NOT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`idRent`,`idProduct`),
  KEY `rentDetail_product_idx` (`idProduct`),
  CONSTRAINT `rentDetail_product` FOREIGN KEY (`idProduct`) REFERENCES `product` (`idProduct`),
  CONSTRAINT `rentDetail_rent` FOREIGN KEY (`idRent`) REFERENCES `rent` (`idRent`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rentdetail`
--

LOCK TABLES `rentdetail` WRITE;
/*!40000 ALTER TABLE `rentdetail` DISABLE KEYS */;
/*!40000 ALTER TABLE `rentdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale` (
  `idSale` int NOT NULL AUTO_INCREMENT,
  `idUser` int unsigned NOT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`idSale`),
  KEY `sale_user_idx` (`idUser`),
  CONSTRAINT `sale_user` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale`
--

LOCK TABLES `sale` WRITE;
/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
INSERT INTO `sale` VALUES (1,11,'2025-05-21'),(2,13,'2025-05-21'),(3,11,'2025-05-21'),(4,3,'2025-05-30');
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saledetail`
--

DROP TABLE IF EXISTS `saledetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saledetail` (
  `idSale` int NOT NULL,
  `idProduct` int NOT NULL,
  `price` float DEFAULT NULL,
  `idDiscount` int DEFAULT NULL,
  PRIMARY KEY (`idSale`,`idProduct`),
  KEY `sellDetail_product_idx` (`idProduct`),
  KEY `saleDetail_discount_idx` (`idDiscount`),
  CONSTRAINT `saleDetail_discount` FOREIGN KEY (`idDiscount`) REFERENCES `discount` (`idDiscount`),
  CONSTRAINT `saleDetail_product` FOREIGN KEY (`idProduct`) REFERENCES `product` (`idProduct`),
  CONSTRAINT `saleDetail_sale` FOREIGN KEY (`idSale`) REFERENCES `sale` (`idSale`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saledetail`
--

LOCK TABLES `saledetail` WRITE;
/*!40000 ALTER TABLE `saledetail` DISABLE KEYS */;
INSERT INTO `saledetail` VALUES (1,1,299.99,NULL),(1,2,399.99,NULL),(1,3,899.99,NULL),(1,4,449.99,NULL),(1,5,1499.99,NULL),(1,6,599.99,NULL),(1,7,199.99,NULL),(1,8,799.99,NULL),(1,9,999.99,NULL),(1,10,499.99,NULL),(2,1,299.99,NULL),(2,2,399.99,NULL),(2,3,899.99,NULL),(2,4,449.99,NULL),(2,5,1499.99,NULL),(2,6,599.99,NULL),(2,7,199.99,NULL),(2,8,799.99,NULL),(2,9,999.99,NULL),(2,10,499.99,NULL),(4,1,299.99,NULL),(4,2,399.99,NULL),(4,3,899.99,NULL),(4,4,449.99,NULL),(4,5,1499.99,NULL);
/*!40000 ALTER TABLE `saledetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `idUser` int unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `passw` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  PRIMARY KEY (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'asd','asd',NULL,NULL,NULL,NULL),(2,'asd','asd',NULL,NULL,NULL,NULL),(3,'jgarcia','pass123','juan.garcia@email.com','Juan','García','1990-05-15'),(4,'mlopez','secure456','maria.lopez@email.com','María','López','1995-08-22'),(5,'carlos_r','pwd789','carlos.rodriguez@email.com','Carlos','Rodríguez','1988-11-30'),(6,'ana_mart','ana2024','ana.martinez@email.com','Ana','Martínez','1992-03-10'),(7,'pedro_s','pedro123','pedro.sanchez@email.com','Pedro','Sánchez','1985-07-18'),(8,'laura_g','laur4567','laura.gomez@email.com','Laura','Gómez','1993-12-05'),(9,'roberto_t','rob3rt0','roberto.torres@email.com','Roberto','Torres','1987-09-25'),(10,'sofia_m','sof1234','sofia.morales@email.com','Sofía','Morales','1991-04-14'),(11,'diego_v','dieg0123','diego.vazquez@email.com','Diego','Vázquez','1994-06-08'),(12,'carmen_r','carm3n','carmen.ruiz@email.com','Carmen','Ruiz','1989-01-20'),(13,'Ozcar','123','oscar.nunez@email.com','Oscar','Núñez','1995-01-01'),(14,'asd','asd',NULL,NULL,NULL,NULL),(15,'asd','asd',NULL,NULL,NULL,NULL),(16,'asd','asd',NULL,NULL,NULL,NULL),(17,'asd','asd',NULL,NULL,NULL,NULL),(18,'asd','asd',NULL,NULL,NULL,NULL),(19,'asd','asd',NULL,NULL,NULL,NULL),(20,'asd','asd',NULL,NULL,NULL,NULL),(21,'asd','asd',NULL,NULL,NULL,NULL),(22,'asd','asd',NULL,NULL,NULL,NULL),(23,'asd','asd',NULL,NULL,NULL,NULL),(24,'asd','asd',NULL,NULL,NULL,NULL),(25,'asd','asd',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-02 11:38:49
