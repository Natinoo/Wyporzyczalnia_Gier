-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Cze 06, 2025 at 08:20 AM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wypozyczalnia_gier`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `gry`
--

CREATE TABLE `gry` (
  `id` int(10) UNSIGNED NOT NULL,
  `tytul` varchar(100) NOT NULL,
  `producent` varchar(100) DEFAULT NULL,
  `rok_wydania` year(4) DEFAULT NULL,
  `platforma` varchar(50) DEFAULT NULL,
  `dostepnosc` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `gry`
--

INSERT INTO `gry` (`id`, `tytul`, `producent`, `rok_wydania`, `platforma`, `dostepnosc`) VALUES
(1, 'Wiedźmin 3: Dziki Gon', 'CD Projekt Red', '2015', 'PC/PS4/XONE', 0),
(2, 'Cyberpunk 2077', 'CD Projekt Red', '2020', 'PC/PS5/XSX', 1),
(3, 'The Elder Scrolls V: Skyrim', 'Bethesda', '2011', 'PC/PS3/X360', 1),
(4, 'Grand Theft Auto V', 'Rockstar Games', '2013', 'PC/PS4/XONE', 1),
(5, 'Red Dead Redemption 2', 'Rockstar Games', '2018', 'PC/PS4/XONE', 1),
(6, 'FIFA 23', 'EA Sports', '2022', 'PC/PS5/XSX', 1),
(7, 'Call of Duty: Warzone', 'Infinity Ward', '2020', 'PC/PS4/XONE', 0),
(8, 'Minecraft', 'Mojang', '2011', 'Multiplatforma', 1),
(9, 'The Legend of Zelda: Breath of the Wild', 'Nintendo', '2017', 'Switch', 1),
(10, 'God of War (2018)', 'Santa Monica Studio', '2018', 'PS4', 0),
(11, 'Horizon Zero Dawn', 'Guerrilla Games', '2017', 'PC/PS4', 1),
(13, 'Assassin\'s Creed Valhalla', 'Ubisoft', '2020', 'PC/PS5/XSX', 0),
(14, 'CS:GO', 'VALVE', '2011', 'PC', 1),
(15, 'The Witcher', 'CD Projekt Red', '2007', 'PC', 1),
(16, 'Elden Ring', 'FromSoftware', '2022', 'PC/PS5/XSX', 1),
(17, 'Half-Life 2', 'Valve', '2004', 'PC', 1),
(18, 'Dark Souls III', 'FromSoftware', '2016', 'PC/PS4/XONE', 1),
(19, 'Portal 2', 'Valve', '2011', 'PC', 1),
(20, 'Sekiro: Shadows Die Twice', 'FromSoftware', '2019', 'PC/PS4/XONE', 1),
(21, 'Baldur\'s Gate 3', 'Larian Studios', '2023', 'PC/PS5', 1),
(22, 'Hades', 'Supergiant Games', '2020', 'PC/Switch', 1),
(23, 'The Last of Us Part II', 'Naughty Dog', '2020', 'PS4', 1),
(24, 'Ghost of Tsushima', 'Sucker Punch', '2020', 'PS4/PS5', 1),
(25, 'Death Stranding', 'Kojima Productions', '2019', 'PC/PS4', 1),
(26, 'It Takes Two', 'Hazelight Studios', '2021', 'PC/PS4/XONE', 1),
(27, 'Forza Horizon 5', 'Playground Games', '2021', 'PC/XSX', 1),
(28, 'Starfield', 'Bethesda', '2023', 'PC/XSX', 1),
(29, 'Returnal', 'Housemarque', '2021', 'PS5', 1),
(31, 'Control', 'Remedy Entertainment', '2019', 'PC/PS4/XONE', 1),
(32, 'BioShock Infinite', 'Irrational Games', '2013', 'PC/PS3/X360', 1),
(33, 'Mass Effect 2', 'BioWare', '2010', 'PC/X360', 1),
(34, 'Alan Wake 2', 'Remedy Entertainment', '2023', 'PC/PS5/XSX', 1),
(35, 'Moja wlasna gra', 'brak', '2025', 'PC', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `uzytkownicy`
--

CREATE TABLE `uzytkownicy` (
  `id` int(10) UNSIGNED NOT NULL,
  `login` varchar(100) NOT NULL,
  `email` varchar(255) NOT NULL,
  `haslo` char(64) NOT NULL COMMENT 'SHA2-256 hash',
  `is_admin` tinyint(1) NOT NULL DEFAULT 0,
  `data_rejestracji` datetime NOT NULL DEFAULT current_timestamp(),
  `zaleglosci` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `uzytkownicy`
--

INSERT INTO `uzytkownicy` (`id`, `login`, `email`, `haslo`, `is_admin`, `data_rejestracji`, `zaleglosci`) VALUES
(1, 'admin', 'admin@example.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, '2025-06-03 19:48:55', 0.00),
(2, 'cp', 'cp@gmail.com', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 0, '2025-06-03 20:07:17', 0.00);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wypozyczenia`
--

CREATE TABLE `wypozyczenia` (
  `id` int(10) UNSIGNED NOT NULL,
  `id_gry` int(10) UNSIGNED NOT NULL,
  `id_uzytkownika` int(10) UNSIGNED NOT NULL,
  `data_wypozyczenia` datetime NOT NULL DEFAULT current_timestamp(),
  `planowana_data_zwrotu` date NOT NULL,
  `data_zwrotu` datetime DEFAULT NULL,
  `oplata` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `wypozyczenia`
--

INSERT INTO `wypozyczenia` (`id`, `id_gry`, `id_uzytkownika`, `data_wypozyczenia`, `planowana_data_zwrotu`, `data_zwrotu`, `oplata`) VALUES
(1, 1, 1, '2025-06-04 00:00:00', '2025-06-11', '2025-06-04 14:19:58', NULL),
(2, 1, 1, '2025-06-04 00:00:00', '2025-06-11', '2025-06-04 14:20:19', NULL),
(3, 14, 1, '2025-06-05 16:09:21', '2025-06-12', '2025-06-05 17:24:51', NULL),
(4, 6, 1, '2025-06-05 17:24:58', '2025-06-12', '2025-06-06 07:15:28', NULL),
(5, 9, 1, '2025-06-05 17:25:00', '2025-06-12', '2025-06-06 07:15:16', NULL),
(6, 10, 2, '2025-06-05 17:50:23', '2025-06-12', NULL, NULL),
(7, 13, 2, '2025-06-05 17:51:11', '2025-06-12', NULL, NULL),
(8, 5, 1, '2025-06-06 05:55:33', '2025-07-04', '2025-06-06 07:15:31', NULL),
(9, 16, 1, '2025-06-06 07:15:02', '2025-07-04', '2025-06-06 07:15:24', NULL),
(10, 14, 1, '2025-06-06 07:15:02', '2025-07-04', '2025-06-06 07:15:19', NULL),
(11, 16, 1, '2025-06-06 07:15:40', '2025-07-04', '2025-06-06 07:15:49', NULL),
(12, 14, 1, '2025-06-06 07:15:40', '2025-07-04', '2025-06-06 07:22:30', NULL),
(13, 1, 1, '2025-06-06 07:15:40', '2025-07-04', NULL, NULL),
(14, 7, 1, '2025-06-06 07:22:50', '2025-07-04', NULL, NULL),
(15, 8, 1, '2025-06-06 07:22:50', '2025-07-04', '2025-06-06 07:33:25', NULL),
(16, 15, 1, '2025-06-06 07:22:50', '2025-07-04', '2025-06-06 07:33:25', NULL);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `gry`
--
ALTER TABLE `gry`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_tytul` (`tytul`),
  ADD KEY `idx_dostepnosc` (`dostepnosc`);

--
-- Indeksy dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `idx_login_unique` (`login`),
  ADD KEY `idx_login` (`login`),
  ADD KEY `idx_email` (`email`);

--
-- Indeksy dla tabeli `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_gry` (`id_gry`),
  ADD KEY `idx_data_wypozyczenia` (`data_wypozyczenia`),
  ADD KEY `idx_data_zwrotu` (`data_zwrotu`),
  ADD KEY `idx_aktywne_wypozyczenia` (`id_uzytkownika`,`data_zwrotu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `gry`
--
ALTER TABLE `gry`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  ADD CONSTRAINT `wypozyczenia_ibfk_1` FOREIGN KEY (`id_gry`) REFERENCES `gry` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `wypozyczenia_ibfk_2` FOREIGN KEY (`id_uzytkownika`) REFERENCES `uzytkownicy` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
