SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";
 

CREATE TABLE `Entries` (
  `EntryID` int(11) NOT NULL,
  `text` varchar(2555) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `textonly` varchar(2555) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
 

INSERT INTO `Entries` (`EntryID`, `text`, `country`, `textonly`) VALUES
(51, '51.mp3', 'en-IN', 'This is a test message');
 
ALTER TABLE `Entries`
  ADD PRIMARY KEY (`EntryID`);
 
ALTER TABLE `Entries`
  MODIFY `EntryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52; 