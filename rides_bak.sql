-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: rides
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8mb4 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `segments`
--

DROP TABLE IF EXISTS `segments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `segments` (
  `SegmentPK` int(11) NOT NULL AUTO_INCREMENT,
  `SegmentID` varchar(45) NOT NULL,
  `TypeFK` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Intensity` int(11) NOT NULL,
  `CustomFlg` int(11) NOT NULL,
  PRIMARY KEY (`SegmentPK`),
  UNIQUE KEY `SegmentID_UNIQUE` (`SegmentID`),
  KEY `IDX_SEG_TYP_FK_idx` (`TypeFK`),
  CONSTRAINT `IDX_SEG_TYP_FK` FOREIGN KEY (`TypeFK`) REFERENCES `types` (`TypePK`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `segments`
--

LOCK TABLES `segments` WRITE;
/*!40000 ALTER TABLE `segments` DISABLE KEYS */;
INSERT INTO `segments` VALUES (5,'Warmup2_1',25,'90 RPM Warmup',1,0),(6,'Warmup2_2',25,'95 RPM Warmup',1,0),(7,'Warmup2_3',25,'100 RPM Warmup',2,0),(8,'Warmup2_4',25,'105 RPM Warmup',2,0),(9,'Warmup2_5',25,'110 RPM Warmup',3,0),(10,'Warmup2_6',25,'120-130 RPM Warmup',3,0),(11,'Warmup2_7',25,'MAX Warmup',4,0),(12,'ThresholdTest1',25,'Sustained Threshold',4,0),(13,'HRZ1',25,'HRZ1 Easy Riding',1,0),(16,'FoamRoll1',26,'Foam Roll - Calves',2,0),(17,'FoamRoll2',26,'Foam Roll - Hamstrings',2,0),(18,'FoamRoll3',26,'Foam Roll - Quads',2,0),(19,'FoamRoll4',26,'Foam Roll - IT Band',2,0),(20,'FoamRoll5',26,'Foam Roll - Abductor',2,0),(21,'FoamRoll6',26,'Foam Roll - Glutes',2,0),(22,'FoamRoll7',26,'Foam Roll - Back',2,0),(23,'Stretching1',26,'Dynamic Stretching',2,0),(24,'HRZ3',25,'HRZ3 Sweet Spot',3,0),(25,'HRZ2',25,'HRZ2',2,0),(28,'HRZ5',25,'VO2 MAX / HRZ5',5,0),(29,'HRZ5_2',25,'SPRINT 95 RPM+',5,0),(30,'HRZ1_2',25,'HRZ1 Recovery',1,0),(31,'HRZ1_3',25,'HRZ1 Cool Down',1,0),(32,'HRZ4',25,'HRZ4 Threshold',4,0),(33,'Plank001',30,'Normal Plank',3,1),(34,'Plank002',30,'Plank with Reach',3,1),(35,'Plank003',30,'Side-to-Side Plank',3,1),(36,'Plank004',30,'Side Plank with Hip Drop',3,1),(37,'Plank005',30,'Plank Walkdown',3,1),(38,'Plank006',30,'Plank with Opposite Reach',3,1),(39,'Plank007',30,'PPT Plank',3,1),(40,'Plank008',30,'Rest / Recover',1,1),(41,'Spinout1',25,'Increase to near MAX',3,0);
/*!40000 ALTER TABLE `segments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tips`
--

DROP TABLE IF EXISTS `tips`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tips` (
  `TipPK` int(11) NOT NULL AUTO_INCREMENT,
  `TipID` varchar(45) NOT NULL,
  `TypeFK` int(11) NOT NULL,
  `Text` varchar(1000) DEFAULT NULL,
  `CustomFlg` int(11) NOT NULL,
  PRIMARY KEY (`TipPK`),
  UNIQUE KEY `TipID_UNIQUE` (`TipID`),
  KEY `IDX_TIPS_TYPE_FK_idx` (`TypeFK`),
  CONSTRAINT `IDX_TIPS_TYPE_FK` FOREIGN KEY (`TypeFK`) REFERENCES `types` (`TypePK`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tips`
--

LOCK TABLES `tips` WRITE;
/*!40000 ALTER TABLE `tips` DISABLE KEYS */;
INSERT INTO `tips` VALUES (2,'BIKE01',25,'Think about pedaling as if tracing a square.  Push forward along the top, down the frontside, scrape the bottom, then pull back up the backside.',0),(3,'BIKE02',25,'Avoid side to side movement in the knees by keeping core tight - no Gumby riding.',0),(4,'BIKE03',25,'Don\'t let your pelvis slouch. Rotate the hips forward and push the butt back, similar to plank.',0),(5,'BIKE04',25,'Keep the grip on the bars relaxed.  No white knuckles!  Change grips often if needed.',0),(6,'BIKE05',25,'Pay attention!  Are all parts of your form good?  Let go of unneeded thoughts and focus on finishing the effort.',0),(7,'BIKE06',25,'Get on the pedals early - start pushing forward before 12 oclock position.  Feet flat or toes slightly pointed up.',0),(8,'BIKE07',25,'Keep your head up, relax your elbows, shoulders, and hands slightly.  Imagine seeing out of the top of your forehead instead of your eyes.',0),(9,'FOAMROLL1',26,'Move up and down the roll for five to ten reps, holding at the end of each move for a few seconds, then switch sides and repeat.',0),(10,'FOAMROLL2',26,'When you hit a tight spot that is painful or uncomfortable, HOLD on that spot for 30-45 seconds. You should feel the tension release slowly.',0),(11,'FOAMROLL3',26,'Make sure to keep breathing, even when its painful. Holding your breath wont allow the muscles to release and relax.',0),(12,'FOAMROLL4',26,'RELAX the muscle as best you can.  If you are flexing or tensing the muscle group you are trying to roll out, you won\'t feel the trigger points you need to release.',0),(13,'BIKE08',25,'Listen into the \"whirrr\" sound of the trainer.  Try to keep the pitch consistent by maintaining a steady pace.  It should not fluctuate up or down.',0),(14,'BIKE09',25,'Keep your elbows bent to reduce strain on your shoulders and hands, but keep the wrists straight - imagine a straight line from elbow through fingers.',0),(15,'BIKE10',25,'Relax the shoulders and bring them down and away from your ears.  Your head and neck should feel loose and relaxed.',0),(16,'BIKE11',25,'Maintain a neutral spine by keeping your core engaged.  Imagine a straight line from your hips to your shoulders.',0),(17,'BIKE12',25,'Be sure your knee is tracking over the ball of your foot/pedal.  Knees should not be bowing out to the sides.',0),(18,'BIKE13',25,'Check your breathing!  Take full breaths into your diaphragm.  Breathe at a rate that you can sustain consistently depending on the difficulty of the segment.',0),(19,'PRODUCTIVITY1',27,'Focus on one goal at a time.  You have all this time to do this one task!',0),(20,'PRODUCTIVITY2',27,'If you get distracted by something, note down to do it later, rather than doing it now.',0),(21,'PRODUCTIVITY3',27,'Take short breaks if needed to clear your mind and rest, but don\'t start something else.',0),(22,'PRODUCTIVITY4',27,'Before starting something new, quickly think about what the most effecient way to execute it is, then go. Dont overthink it.',0),(23,'PRODUCTIVITY5',27,'Finish your task completely.  If theres time left, take a quick break and relax before the next segment.',0),(24,'PLANK001',30,'Proper plank form means keeping your core and quads tight, and your hips lifted. For stability\'s sake, your feet (or knees) and arms (or elbows) should be shoulder-width apart.',1),(25,'PLANK002',30,'To keep your spine in a neutral position and avoid straining your neck, aim your chin about six inches in front of your body.',1),(26,'PLANK003',30,'As you hold the plank, imagine that you’re extending from the crown of your head through your heels. Lastly, don\'t hold your breath!',1),(27,'PLANK004',30,'It\'s key to remain engaged throughout the entire plank, so don\'t let yourself zone out.  Stick your butt up while you hold (and held, and hold...) a plank, then tuck your butt under.',1);
/*!40000 ALTER TABLE `tips` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `types` (
  `TypePK` int(11) NOT NULL AUTO_INCREMENT,
  `TypeID` varchar(45) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `CustomFlg` int(11) NOT NULL,
  PRIMARY KEY (`TypePK`),
  UNIQUE KEY `TypeID_UNIQUE` (`TypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types`
--

LOCK TABLES `types` WRITE;
/*!40000 ALTER TABLE `types` DISABLE KEYS */;
INSERT INTO `types` VALUES (25,'TYPE0001','Indoor Cycling',0),(26,'TYPE0002','Foam Rolling',0),(27,'TYPE0003','Productivity',0),(28,'TYPE0004','Strength Training',0),(29,'TYPE0005','Lobstering',1),(30,'TYPE0006','Plank',1);
/*!40000 ALTER TABLE `types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wkseg`
--

DROP TABLE IF EXISTS `wkseg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `wkseg` (
  `WkSegPK` int(11) NOT NULL AUTO_INCREMENT,
  `WorkoutFK` int(11) NOT NULL,
  `SegmentFK` int(11) NOT NULL,
  `Duration` int(11) NOT NULL,
  `Sequence` int(11) NOT NULL,
  PRIMARY KEY (`WkSegPK`),
  KEY `IDX_WKSEG_WK_FK_idx` (`WorkoutFK`),
  KEY `IDX_WKSEG_SEG_FK_idx` (`SegmentFK`),
  CONSTRAINT `IDX_WKSEG_SEG_FK` FOREIGN KEY (`SegmentFK`) REFERENCES `segments` (`SegmentPK`),
  CONSTRAINT `IDX_WKSEG_WK_FK` FOREIGN KEY (`WorkoutFK`) REFERENCES `workouts` (`WorkoutPK`)
) ENGINE=InnoDB AUTO_INCREMENT=204 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wkseg`
--

LOCK TABLES `wkseg` WRITE;
/*!40000 ALTER TABLE `wkseg` DISABLE KEYS */;
INSERT INTO `wkseg` VALUES (7,4,5,300,1),(8,4,6,120,2),(9,4,7,120,3),(10,4,8,120,4),(11,4,9,90,5),(12,4,10,30,6),(13,4,5,120,7),(14,4,11,6,8),(15,4,5,60,9),(16,4,11,6,10),(17,4,5,60,11),(18,4,11,6,12),(19,4,5,162,13),(24,5,16,120,1),(25,5,17,120,2),(26,5,18,120,3),(27,5,19,120,4),(28,5,20,120,5),(29,5,21,120,6),(30,5,22,120,7),(31,5,23,300,8),(32,6,5,300,1),(33,6,25,200,2),(34,6,24,100,3),(35,6,11,5,4),(36,6,13,25,5),(37,6,11,5,6),(38,6,13,25,7),(39,6,11,5,8),(40,6,13,145,9),(41,6,24,600,10),(42,6,13,300,11),(43,6,24,600,12),(44,6,13,300,13),(45,6,24,600,14),(46,6,13,600,15),(47,7,25,1200,2),(48,7,24,300,3),(49,7,13,300,4),(50,7,25,300,5),(51,7,24,300,6),(52,7,13,600,7),(53,7,13,600,1),(54,8,12,600,1),(55,8,12,600,2),(56,8,12,600,3),(57,8,13,600,4),(58,9,28,300,1),(59,9,13,300,2),(60,9,28,300,3),(61,9,13,300,4),(62,9,28,300,5),(63,9,13,300,6),(64,9,28,300,7),(65,9,13,300,8),(66,9,28,300,9),(67,9,13,600,10),(68,13,32,60,1),(69,13,30,60,2),(70,13,32,120,3),(71,13,30,120,4),(72,13,32,180,5),(73,13,30,180,6),(74,13,32,240,7),(75,13,30,240,8),(76,13,32,300,9),(77,13,30,240,10),(78,13,32,240,11),(79,13,30,180,12),(80,13,32,180,13),(81,13,30,120,14),(82,13,32,120,15),(83,13,32,60,17),(84,13,31,600,18),(86,13,30,60,16),(87,14,24,2400,1),(88,14,40,300,2),(89,14,33,240,3),(90,14,40,60,4),(91,14,34,240,5),(92,14,40,60,6),(93,14,35,240,7),(94,14,40,60,8),(95,14,38,240,9),(96,14,40,60,10),(97,14,36,240,11),(98,14,40,60,12),(99,14,37,240,13),(100,14,40,60,14),(101,14,39,240,15),(102,14,40,60,16),(103,14,13,300,17),(104,14,25,240,18),(105,14,24,180,19),(106,14,32,120,20),(107,14,28,60,21),(108,14,32,60,22),(109,14,24,60,23),(110,14,25,60,24),(111,14,13,60,25),(112,14,31,600,26),(113,12,29,20,1),(114,12,30,40,2),(115,12,29,20,3),(116,12,30,40,4),(117,12,29,20,5),(118,12,30,40,6),(119,12,29,20,7),(120,12,30,40,8),(121,12,29,20,9),(122,12,30,340,10),(123,12,29,20,11),(124,12,30,40,12),(125,12,29,20,13),(126,12,30,40,14),(127,12,29,20,15),(128,12,30,40,16),(129,12,29,20,17),(130,12,30,40,18),(131,12,29,20,19),(132,12,30,340,20),(133,12,29,20,21),(134,12,30,40,22),(135,12,29,20,23),(136,12,30,40,24),(137,12,29,20,25),(138,12,30,40,26),(139,12,29,20,27),(140,12,30,40,28),(141,12,29,20,29),(142,12,30,340,30),(143,12,29,20,31),(144,12,30,40,32),(145,12,29,20,33),(146,12,30,40,34),(147,12,29,20,35),(148,12,30,40,36),(149,12,29,20,37),(150,12,30,40,38),(151,12,29,20,39),(152,12,30,340,40),(153,12,29,20,41),(154,12,30,40,42),(155,12,29,20,43),(156,12,30,40,44),(157,12,29,20,45),(158,12,30,40,46),(159,12,29,20,47),(160,12,30,40,48),(161,12,29,20,49),(162,12,31,600,50),(163,15,32,600,1),(164,15,30,600,2),(165,15,32,600,3),(166,15,30,600,4),(167,15,32,600,5),(168,15,31,600,6),(169,16,32,1200,1),(170,16,30,600,2),(171,16,32,1200,3),(172,16,30,600,4),(173,17,28,180,1),(174,17,30,300,2),(175,17,28,180,3),(176,17,30,300,4),(177,17,28,180,5),(178,17,30,300,6),(179,17,28,180,7),(180,17,30,300,8),(181,17,28,180,9),(182,17,31,600,10),(183,19,13,300,1),(184,19,25,180,2),(185,19,24,120,3),(186,19,11,5,4),(187,19,13,25,5),(188,19,11,5,6),(189,19,13,25,7),(190,19,11,5,8),(191,19,13,175,9),(192,18,41,30,1),(193,18,11,60,2),(194,18,30,240,3),(195,18,41,30,4),(196,18,11,60,5),(197,18,30,240,6),(198,18,41,30,7),(199,18,11,60,8),(200,18,30,240,9),(201,18,41,30,10),(202,18,11,60,11),(203,18,31,600,12);
/*!40000 ALTER TABLE `wkseg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workouts`
--

DROP TABLE IF EXISTS `workouts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `workouts` (
  `WorkoutPK` int(11) NOT NULL AUTO_INCREMENT,
  `WorkoutID` varchar(45) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `IsWarmupFlg` int(11) NOT NULL,
  PRIMARY KEY (`WorkoutPK`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workouts`
--

LOCK TABLES `workouts` WRITE;
/*!40000 ALTER TABLE `workouts` DISABLE KEYS */;
INSERT INTO `workouts` VALUES (1,'WKLOB','Lobster Workout','Act like a lobster',0),(4,'Warmup2','20-min Warmup','The aim of the session is to progressively increase the intensity, culminating in some very intense six second efforts. You can use the twenty\r\nminute warm-up as a warm-up for intense turbo sessions, or if repeated, as a workout\r\nin itself. Use a relatively high gear, but one that allows use of the same gear throughout. Example: large chainring, halfway up the rear cassette.',1),(5,'SOCCERWARMUP','Soccer Warmup','Foam rolling and stretching to warm up for soccer.',1),(6,'TempoIntervals','Tempo Intervals','Suitable for early stages of training plan or as a light workout.  \r\n\r\nMaintain a cadence of 90 rpm+ during the tempo efforts and look\r\nto ride low - mid HRZ 3 for the majority of each one. Just spin easily\r\nfor the recoveries. ',0),(7,'ZoneBuild','Zone Build','Suitable for early stages of training plan or as a light workout.  \r\n\r\nAim to hit the heart rate zones. Build through the\r\nzone gradually and avoid sudden changes in effort, there will always be\r\na time lag before your heart rate responds. Maintain a 90 rpm+\r\ncadence throughout. ',0),(8,'TresholdTest2','Threshold Test','When done correctly, a threshold test is an extremely hard effort. Ensure you go into this test having had at least one rest day beforehand. Although the test is termed a 20 mins functional threshold test, it is actually performed over 30 mins, with the last 20 mins being where the functional threshold figures are established. It is essential that you complete the full 30 mins, as this allows a steady state effort to be established. If you start too hard and have to stop after 20 mins, then your result will not be valid and you will have to complete another test. You might want to err on the side of conservative pacing the first time you perform the test as you’ll have opportunities to repeat it throughout the plans.',0),(9,'RampedIntervals','Ramped Intervals','High Intensity session for late off-season / pre-season. \r\n Hold 95rpm+ and HRZ/PZ 5 for the efforts, building the cadence for\r\nthe maximal last minute surge. Active recovery should be at 90rpm\r\nwith very low resistance.',0),(10,'NoWorkout','-- No Workout --','Warm Up Only',0),(11,'NoWarmup','-- No Warmup --','Workout Only',1),(12,'2040s','20/40’s','Intense session for build up to competition. Develops your ability to sprint and recover from multiple hard efforts.',0),(13,'PyramidIntervals','Pyramid Intervals','A threshold boosting workout that is excellent for developing your ability to quickly find and maintain this key intensity.\r\n\r\nWhen:  Anytime, both in and out of season.',0),(14,'USRWK001','Trainer Plank Switchoffs','2 Hr session featuring riding and plank sessions',0),(15,'3X10s','3 x 10 Minutes','Whenever you are looking to build up your ability to ride at\r\n“Sweet-Spot” and Threshold.',0),(16,'2X20s','2 x 20 Minutes','A classic indoor trainer session that is hard to beat for raising threshold and learning to stay focused and pace long efforts at this key intensity.',0),(17,'VO2Intervals','VO2 Intervals','As a progression on from tempo, sweet-spot and threshold efforts.  The sustained higher intensity efforts build your focus,\r\nare applicable to steep climbs and will boost your threshold.',0),(18,'SpinOut','Spin Out Session',' Boost leg speed and give you a bit of a shake out without incurring too much fatigue.  ',0),(19,'WUTI','WU TI Warmup','14 minute warm up for easier trainer sessions.',1);
/*!40000 ALTER TABLE `workouts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-19  7:38:27
