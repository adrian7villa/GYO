/*
SQLyog Ultimate v9.63 
MySQL - 5.5.5-10.1.10-MariaDB : Database - gyo
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`gyo` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `gyo`;

/*Table structure for table `cita` */

DROP TABLE IF EXISTS `cita`;

CREATE TABLE `cita` (
  `id_Cita` int(11) NOT NULL AUTO_INCREMENT,
  `Paciente` varchar(100) NOT NULL,
  `Fecha` date NOT NULL,
  `Horario` time NOT NULL,
  `Turno` varchar(20) NOT NULL,
  `Usuario` varchar(100) NOT NULL,
  `Registro` datetime NOT NULL,
  `Motivo` varchar(300) NOT NULL,
  `Tipo` varchar(100) DEFAULT NULL,
  `Observaciones` mediumtext,
  PRIMARY KEY (`id_Cita`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `cita` */

LOCK TABLES `cita` WRITE;

insert  into `cita`(`id_Cita`,`Paciente`,`Fecha`,`Horario`,`Turno`,`Usuario`,`Registro`,`Motivo`,`Tipo`,`Observaciones`) values (1,'VA20171161623567','2017-03-21','14:30:00','1','1','2017-03-14 11:14:14','NUEVO',NULL,NULL),(3,'VA20171161623567','2017-03-21','05:00:00','9','1','2017-03-21 18:40:03','VALORACION',NULL,NULL),(4,'VA20171161623567','2017-05-16','02:30:00','4','1','2017-03-21 18:49:58','VALORACION',NULL,NULL),(5,'VA20171161623567','2017-03-23','01:00:00','1','1','2017-03-23 12:10:45','VALORACION',NULL,NULL),(6,'VA20171161623567','2017-03-24','01:00:00','1','1','2017-03-24 08:22:57','VALORACION',NULL,NULL),(7,'VA20171161623567','2017-03-31','01:30:00','2','1','2017-03-31 17:37:53','VALORACION',NULL,NULL),(8,'VA20171161623567','2017-04-01','01:00:00','1','1','2017-04-01 11:27:25','VALORACION',NULL,NULL),(9,'VA20171161623567','2017-04-17','02:00:00','3','1','2017-04-17 16:06:24','VALORACION',NULL,NULL),(10,'VA20171161623567','2017-04-18','01:00:00','1','1','2017-04-18 13:41:54','VALORACION',NULL,NULL);

UNLOCK TABLES;

/*Table structure for table `cita_cancelada` */

DROP TABLE IF EXISTS `cita_cancelada`;

CREATE TABLE `cita_cancelada` (
  `id_Cita` int(11) NOT NULL AUTO_INCREMENT,
  `Paciente` varchar(100) NOT NULL,
  `Fecha` date NOT NULL,
  `Horario` time NOT NULL,
  `Turno` varchar(20) NOT NULL,
  `Usuario` varchar(100) NOT NULL,
  `Registro` datetime NOT NULL,
  `Motivo` varchar(300) NOT NULL,
  `Tipo` varchar(100) DEFAULT NULL,
  `Observaciones` mediumtext,
  PRIMARY KEY (`id_Cita`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `cita_cancelada` */

LOCK TABLES `cita_cancelada` WRITE;

insert  into `cita_cancelada`(`id_Cita`,`Paciente`,`Fecha`,`Horario`,`Turno`,`Usuario`,`Registro`,`Motivo`,`Tipo`,`Observaciones`) values (2,'VA20171161623567','2017-03-21','02:30:00','4','1','2017-03-21 15:56:10','VALORACION',NULL,NULL);

UNLOCK TABLES;

/*Table structure for table `cita_historial` */

DROP TABLE IF EXISTS `cita_historial`;

CREATE TABLE `cita_historial` (
  `id_Cita` int(11) NOT NULL AUTO_INCREMENT,
  `Paciente` varchar(100) NOT NULL,
  `Fecha` date NOT NULL,
  `Horario` time NOT NULL,
  `Turno` varchar(20) NOT NULL,
  `Usuario` varchar(100) NOT NULL,
  `Registro` datetime NOT NULL,
  `Motivo` varchar(300) NOT NULL,
  `Tipo` varchar(100) DEFAULT NULL,
  `Observaciones` mediumtext,
  PRIMARY KEY (`id_Cita`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `cita_historial` */

LOCK TABLES `cita_historial` WRITE;

UNLOCK TABLES;

/*Table structure for table `datos_facturacion` */

DROP TABLE IF EXISTS `datos_facturacion`;

CREATE TABLE `datos_facturacion` (
  `id_Paciente` varchar(100) NOT NULL,
  `RFC` varchar(15) NOT NULL,
  `Nombre` varchar(300) NOT NULL,
  `Direccion` varchar(400) NOT NULL,
  `Telefono` varchar(100) NOT NULL,
  `Email` varchar(200) NOT NULL,
  `Observaciones` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `datos_facturacion` */

LOCK TABLES `datos_facturacion` WRITE;

UNLOCK TABLES;

/*Table structure for table `datos_pacientes` */

DROP TABLE IF EXISTS `datos_pacientes`;

CREATE TABLE `datos_pacientes` (
  `id_Paciente` varchar(100) NOT NULL,
  `Foto` longblob NOT NULL,
  `Seguro` varchar(300) NOT NULL,
  `Ocupacion` varchar(300) NOT NULL,
  `Estado_Civil` varchar(50) NOT NULL,
  `Religion` varchar(200) NOT NULL,
  `Observaciones` text,
  PRIMARY KEY (`id_Paciente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `datos_pacientes` */

LOCK TABLES `datos_pacientes` WRITE;

UNLOCK TABLES;

/*Table structure for table `dias_festivos` */

DROP TABLE IF EXISTS `dias_festivos`;

CREATE TABLE `dias_festivos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` text NOT NULL,
  `Fecha` date NOT NULL,
  `Observaciones` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `dias_festivos` */

LOCK TABLES `dias_festivos` WRITE;

UNLOCK TABLES;

/*Table structure for table `errores` */

DROP TABLE IF EXISTS `errores`;

CREATE TABLE `errores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `Texto` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `errores` */

LOCK TABLES `errores` WRITE;

UNLOCK TABLES;

/*Table structure for table `horario` */

DROP TABLE IF EXISTS `horario`;

CREATE TABLE `horario` (
  `id_Horario` int(11) NOT NULL AUTO_INCREMENT,
  `Entrada` time NOT NULL,
  `Salida` time NOT NULL,
  `Dias` varchar(300) NOT NULL,
  `Del` date NOT NULL,
  `Al` date NOT NULL,
  `Observaciones` text,
  PRIMARY KEY (`id_Horario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `horario` */

LOCK TABLES `horario` WRITE;

insert  into `horario`(`id_Horario`,`Entrada`,`Salida`,`Dias`,`Del`,`Al`,`Observaciones`) values (1,'13:00:00','17:00:00','1,2,3,4,5','2017-01-01','3000-01-01','Horario Principal'),(2,'09:00:00','10:00:00','1,3,5','2017-01-01','2017-01-16',NULL),(3,'10:00:00','12:00:00','1,4','2017-01-16','2017-01-30',NULL);

UNLOCK TABLES;

/*Table structure for table `incidencias` */

DROP TABLE IF EXISTS `incidencias`;

CREATE TABLE `incidencias` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `RFC` varchar(15) NOT NULL,
  `Motivo` text NOT NULL,
  `Fec_Ini` date NOT NULL,
  `Fec_Fin` date NOT NULL,
  `Observaciones` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `incidencias` */

LOCK TABLES `incidencias` WRITE;

UNLOCK TABLES;

/*Table structure for table `motivo` */

DROP TABLE IF EXISTS `motivo`;

CREATE TABLE `motivo` (
  `id_Motivo` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(300) DEFAULT NULL,
  `Duracion` time NOT NULL,
  `Observaciones` text,
  PRIMARY KEY (`id_Motivo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `motivo` */

LOCK TABLES `motivo` WRITE;

insert  into `motivo`(`id_Motivo`,`Nombre`,`Descripcion`,`Duracion`,`Observaciones`) values (2,'VALORACION','VALORACION DEL PACINETE','01:00:00',NULL);

UNLOCK TABLES;

/*Table structure for table `movimientos` */

DROP TABLE IF EXISTS `movimientos`;

CREATE TABLE `movimientos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(30) NOT NULL,
  `Tabla` varchar(30) NOT NULL,
  `Tipo` text NOT NULL,
  `Observacion` mediumtext NOT NULL,
  `Fecha` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*Data for the table `movimientos` */

LOCK TABLES `movimientos` WRITE;

insert  into `movimientos`(`id`,`Usuario`,`Tabla`,`Tipo`,`Observacion`,`Fecha`) values (1,'1','Citas','Alta De Cita','VA20171161623567 21/03/2017','2017-03-21 15:56:10'),(2,'1','cita_cancelada','Alta De cita','2','0000-00-00 00:00:00'),(3,'1','cita','Baja De cita','2','0000-00-00 00:00:00'),(4,'1','Citas','Alta De Cita','VA20171161623567 21/03/2017','2017-03-21 18:40:03'),(5,'1','Citas','Alta De Cita','VA20171161623567 16/05/2017','2017-03-21 18:49:58'),(6,'1','Citas','Alta De Cita','VA20171161623567 23/03/2017','2017-03-23 12:10:45'),(7,'1','Citas','Alta De Cita','VA20171161623567 24/03/2017','2017-03-24 08:22:57'),(8,'1','Citas','Alta De Cita','VA20171161623567 31/03/2017','2017-03-31 17:37:53'),(9,'1','Citas','Alta De Cita','VA20171161623567 01/04/2017','2017-04-01 11:27:25'),(10,'1','Citas','Alta De Cita','VA20171161623567 17/04/2017','2017-04-17 16:06:24'),(11,'1','Citas','Alta De Cita','VA20171161623567 18/04/2017','2017-04-18 13:41:54');

UNLOCK TABLES;

/*Table structure for table `paciente` */

DROP TABLE IF EXISTS `paciente`;

CREATE TABLE `paciente` (
  `id_Paciente` varchar(100) NOT NULL,
  `RFC` varchar(15) DEFAULT NULL,
  `ApellidoP` varchar(200) NOT NULL,
  `ApellidoM` varchar(200) DEFAULT NULL,
  `Nombre` varchar(300) NOT NULL,
  `Fec_Nac` date DEFAULT NULL,
  `Calle` varchar(300) DEFAULT NULL,
  `No` varchar(10) DEFAULT NULL,
  `Colonia` varchar(200) DEFAULT NULL,
  `CP` varchar(10) DEFAULT NULL,
  `Municipio` varchar(200) DEFAULT NULL,
  `Estado` varchar(200) DEFAULT NULL,
  `Tel_Casa` varchar(50) DEFAULT NULL,
  `Tel_Cel` varchar(50) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Observaciones` text,
  `Referido` varchar(100) DEFAULT NULL,
  `Nom_Ref` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_Paciente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `paciente` */

LOCK TABLES `paciente` WRITE;

insert  into `paciente`(`id_Paciente`,`RFC`,`ApellidoP`,`ApellidoM`,`Nombre`,`Fec_Nac`,`Calle`,`No`,`Colonia`,`CP`,`Municipio`,`Estado`,`Tel_Casa`,`Tel_Cel`,`Email`,`Observaciones`,`Referido`,`Nom_Ref`) values ('VA20171161623567','VIEA870510DU5','VILLASEÑOR','ESTRADA','ADRIAN DAVID','1987-05-10',NULL,NULL,NULL,NULL,NULL,NULL,'311',NULL,NULL,'',NULL,NULL);

UNLOCK TABLES;

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `Usuario` varchar(20) NOT NULL,
  `Nombre` varchar(400) NOT NULL,
  `Password` varchar(15) NOT NULL,
  `Tipo` varchar(50) NOT NULL,
  `Activo` tinyint(1) NOT NULL,
  `Observaciones` longtext,
  PRIMARY KEY (`Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `usuario` */

LOCK TABLES `usuario` WRITE;

insert  into `usuario`(`Usuario`,`Nombre`,`Password`,`Tipo`,`Activo`,`Observaciones`) values ('1','1','1','ADMINISTRADOR',1,NULL),('Adrian','VILLASEÑOR ESTRADA ADRIAN DAVID','1','ADMINISTRADOR',1,NULL);

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
