-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 10, 2023 at 03:20 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eduengage`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `admin_id` int(11) NOT NULL,
  `adminUser` varchar(100) NOT NULL,
  `adminPass` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`admin_id`, `adminUser`, `adminPass`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `crosswordpuzzle1`
--

CREATE TABLE `crosswordpuzzle1` (
  `crossPuzzle1_id` int(11) NOT NULL,
  `crossPuzzle1_score` int(11) DEFAULT NULL,
  `Username` varchar(200) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `quiz_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `crosswordpuzzle1`
--

INSERT INTO `crosswordpuzzle1` (`crossPuzzle1_id`, `crossPuzzle1_score`, `Username`, `ID`, `quiz_date`) VALUES
(19, 5, 'ShekinahMarie', 5, '2023-12-10'),
(20, 0, 'ShekinahMarie', 5, '2023-12-10'),
(21, 0, 'ShekinahMarie', 5, '2023-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `crosswordpuzzle2`
--

CREATE TABLE `crosswordpuzzle2` (
  `crossPuzzle2_id` int(11) NOT NULL,
  `crossPuzzle2_score` int(11) DEFAULT NULL,
  `Username` varchar(200) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `quiz_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `crosswordpuzzle2`
--

INSERT INTO `crosswordpuzzle2` (`crossPuzzle2_id`, `crossPuzzle2_score`, `Username`, `ID`, `quiz_date`) VALUES
(9, 5, 'ShekinahMarie', 5, '2023-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `guessinggame1`
--

CREATE TABLE `guessinggame1` (
  `guessingGame1_id` int(11) NOT NULL,
  `guessingGame1_score` int(11) DEFAULT NULL,
  `Username` varchar(200) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `quiz_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guessinggame1`
--

INSERT INTO `guessinggame1` (`guessingGame1_id`, `guessingGame1_score`, `Username`, `ID`, `quiz_date`) VALUES
(8, 4, 'ShekinahMarie', 5, '2023-12-10'),
(9, 4, 'ShekinahMarie', 5, '2023-12-10'),
(10, 3, 'ShekinahMarie', 5, '2023-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `guessinggame2`
--

CREATE TABLE `guessinggame2` (
  `guessingGame2_id` int(11) NOT NULL,
  `guessingGame2_score` int(11) DEFAULT NULL,
  `Username` varchar(200) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `quiz_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guessinggame2`
--

INSERT INTO `guessinggame2` (`guessingGame2_id`, `guessingGame2_score`, `Username`, `ID`, `quiz_date`) VALUES
(7, 4, 'ShekinahMarie', 5, '2023-12-10'),
(8, 1, 'ShekinahMarie', 5, '2023-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `multiplechoice`
--

CREATE TABLE `multiplechoice` (
  `multipleChoice_id` int(11) NOT NULL,
  `multipleChoice_score` int(11) DEFAULT NULL,
  `Username` varchar(200) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `quiz_date` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `multiplechoice`
--

INSERT INTO `multiplechoice` (`multipleChoice_id`, `multipleChoice_score`, `Username`, `ID`, `quiz_date`) VALUES
(12, 3, 'ShekinahMarie', 5, '2023-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `user_information`
--

CREATE TABLE `user_information` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `Birthdate` date NOT NULL,
  `EmailAddress` varchar(100) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_information`
--

INSERT INTO `user_information` (`ID`, `FirstName`, `LastName`, `Birthdate`, `EmailAddress`, `Username`, `Password`) VALUES
(5, 'Rusette Shekinah', 'Araneta', '2004-09-29', 'shekinaharaneta@gmail.com', 'ShekinahMarie', 'ShekinahMarie');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`admin_id`);

--
-- Indexes for table `crosswordpuzzle1`
--
ALTER TABLE `crosswordpuzzle1`
  ADD PRIMARY KEY (`crossPuzzle1_id`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `crosswordpuzzle2`
--
ALTER TABLE `crosswordpuzzle2`
  ADD PRIMARY KEY (`crossPuzzle2_id`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `guessinggame1`
--
ALTER TABLE `guessinggame1`
  ADD PRIMARY KEY (`guessingGame1_id`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `guessinggame2`
--
ALTER TABLE `guessinggame2`
  ADD PRIMARY KEY (`guessingGame2_id`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `multiplechoice`
--
ALTER TABLE `multiplechoice`
  ADD PRIMARY KEY (`multipleChoice_id`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `user_information`
--
ALTER TABLE `user_information`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `admin_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `crosswordpuzzle1`
--
ALTER TABLE `crosswordpuzzle1`
  MODIFY `crossPuzzle1_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `crosswordpuzzle2`
--
ALTER TABLE `crosswordpuzzle2`
  MODIFY `crossPuzzle2_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `guessinggame1`
--
ALTER TABLE `guessinggame1`
  MODIFY `guessingGame1_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `guessinggame2`
--
ALTER TABLE `guessinggame2`
  MODIFY `guessingGame2_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `multiplechoice`
--
ALTER TABLE `multiplechoice`
  MODIFY `multipleChoice_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `user_information`
--
ALTER TABLE `user_information`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `crosswordpuzzle1`
--
ALTER TABLE `crosswordpuzzle1`
  ADD CONSTRAINT `crosswordpuzzle1_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `user_information` (`ID`);

--
-- Constraints for table `crosswordpuzzle2`
--
ALTER TABLE `crosswordpuzzle2`
  ADD CONSTRAINT `crosswordpuzzle2_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `user_information` (`ID`);

--
-- Constraints for table `guessinggame1`
--
ALTER TABLE `guessinggame1`
  ADD CONSTRAINT `guessinggame1_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `user_information` (`ID`);

--
-- Constraints for table `guessinggame2`
--
ALTER TABLE `guessinggame2`
  ADD CONSTRAINT `guessinggame2_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `user_information` (`ID`);

--
-- Constraints for table `multiplechoice`
--
ALTER TABLE `multiplechoice`
  ADD CONSTRAINT `multiplechoice_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `user_information` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
