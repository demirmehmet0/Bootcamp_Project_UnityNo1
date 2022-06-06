-- phpMyAdmin SQL Dump
-- version 4.6.6deb5ubuntu0.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 29 May 2022, 19:47:16
-- Sunucu sürümü: 5.7.38-0ubuntu0.18.04.1
-- PHP Sürümü: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `admin_aposkadb`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `Entries`
--

CREATE TABLE `Entries` (
  `EntryID` int(11) NOT NULL,
  `text` varchar(2555) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `textonly` varchar(2555) DEFAULT NULL,
  `textlatin` varchar(2555) DEFAULT NULL,
  `translated` varchar(2555) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `Entries`
--

INSERT INTO `Entries` (`EntryID`, `text`, `country`, `textonly`, `textlatin`, `translated`) VALUES
(55, '55.mp3', 'ko-KR', 'ì•ˆë…•í•˜ì„¸ìš” ì¹œêµ¬. ë‚˜ëŠ” í•œêµ­ì— ì‚°ë‹¤', 'annyeonghaseyo chingu. naneun hangug-e sanda', 'Hello%20Friend.%20I%20live%20in%20Korea');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `Entries`
--
ALTER TABLE `Entries`
  ADD PRIMARY KEY (`EntryID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `Entries`
--
ALTER TABLE `Entries`
  MODIFY `EntryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
