-- Insert data into `ODJEL`
INSERT INTO `drogerija`.`ODJEL` (`IdOdjela`, `Naziv`) VALUES
(1, 'Kozmetika'),
(2, 'Lična njega'),
(3, 'Zdravlje'),
(4, 'Kućne potrepštine'),
(5, 'Parfemi'),
(6, 'Makeup'),
(7, 'Njega kože'),
(8, 'Njega kose'),
(9, 'Njega noktiju'),
(10, 'Njega tijela');

-- Insert data into `KATEGORIJA`
INSERT INTO `drogerija`.`KATEGORIJA` (`Naziv`, `Opis`, `IdKategorija`, `ODJEL_IdOdjela`) VALUES
('Kreme za lice', 'Kreme za hidrataciju i njegu lica', 1, 7),
('Šamponi', 'Šamponi za sve tipove kose', 2, 8),
('Puderi', 'Tekući i kompaktni puderi', 3, 6),
('Ruž za usne', 'Različite nijanse ruževa za usne', 4, 6),
('Parfemi za žene', 'Razni parfemi za žene', 5, 5),
('Parfemi za muškarce', 'Razni parfemi za muškarce', 6, 5),
('Lakovi za nokte', 'Različite boje i vrste lakova za nokte', 7, 9),
('Losioni za tijelo', 'Losioni za hidrataciju i njegu tijela', 8, 10),
('Zubne paste', 'Razne vrste zubnih pasti', 9, 2),
('Vitamini', 'Dodaci prehrani i vitamini', 10, 3);

-- Insert data into `BREND`
INSERT INTO `drogerija`.`BREND` (`Naziv`, `Kontakt`, `ZemljaPorijekla`) VALUES
('Nivea', 'info@nivea.com', 'Njemačka'),
('L\'Oreal', 'contact@loreal.com', 'Francuska'),
('Maybelline', 'support@maybelline.com', 'SAD'),
('Dove', 'care@dove.com', 'UK'),
('Garnier', 'contact@garnier.com', 'Francuska'),
('Chanel', 'info@chanel.com', 'Francuska'),
('Clinique', 'help@clinique.com', 'SAD'),
('MAC', 'support@mac.com', 'Kanada'),
('Pantene', 'info@pantene.com', 'SAD'),
('Oral-B', 'support@oralb.com', 'SAD');

INSERT INTO `drogerija`.`DOBAVLJAČ` (`IdDobavljač`, `Naziv`) VALUES
(1, 'ABC Dobavljač'),
(2, 'XYZ Distribucija'),
(3, 'Beauty Supply'),
(4, 'Cosmetic World'),
(5, 'HealthCare Plus'),
(6, 'Fragrance Distribution'),
(7, 'Top Beauty'),
(8, 'Wellness Co'),
(9, 'HairCare Experts'),
(10, 'NailArt Supplies');

-- Insert data into `PROIZVOD`
INSERT INTO `drogerija`.`PROIZVOD` (`IdProizvod`, `Naziv`, `Opis`, `KoličinaNaStanju`, `Sastav`, `KATEGORIJA_IdKategorija`, `BREND_Naziv`) VALUES
(1, 'Nivea krema za lice', 'Hidratantna krema za lice', 100, 'Aqua, Glycerin, Paraffinum Liquidum', 1, 'Nivea'),
(2, 'Pantene šampon', 'Šampon za sve tipove kose', 200, 'Aqua, Sodium Laureth Sulfate, Cocamidopropyl Betaine', 2, 'Pantene'),
(3, 'Maybelline puder', 'Velika pokrivna moć', 150, 'Aqua, Cyclopentasiloxane, Butylene Glycol', 3, 'Maybelline'),
(4, 'MAC ruž za usne', 'Ruž za usne,više nijansi', 120, 'Ricinus Communis Seed Oil, Caprylic/Capric Triglyceride, Beeswax', 4, 'MAC'),
(5, 'Chanel parfem ženski', 'Elegantni parfem za žene', 50, 'Alcohol, Parfum, Aqua', 5, 'Chanel'),
(6, 'Dove losion', 'Hidratantni losion za tijelo', 180, 'Aqua, Glycerin, Stearic Acid', 8, 'Dove'),
(7, 'Oral-B zubna pasta', 'Zubna pasta', 300, 'Aqua, Sorbitol, Hydrated Silica', 9, 'Oral-B'),
(8, 'Garnier suplementi', 'Vitaminska bomba hidratacije', 100, 'Vitamin C, Vitamin D, Magnesium', 10, 'Garnier'),
(9, 'L\'Oreal lak za nokte', 'Lak za nokte,razni', 250, 'Butyl Acetate, Ethyl Acetate, Nitrocellulose', 7, 'L\'Oreal'),
(10, 'Clinique parfem', 'Elegantni parfem za muškarce', 60, 'Alcohol, Parfum, Aqua', 6, 'Clinique');

INSERT INTO `drogerija`.`KASA` (`IdKasa`) VALUES
(1),
(2),
(3);

INSERT INTO drogerija.ZAPOSLENI (IdZaposlenog, Ime, Prezime, Telefon, Adresa, Smjena, Zaduženje, Plata, DatumZaposlenja) 
VALUES
(1, 'Jovan', 'Jovanović', '+381641234567', 'Knez Mihailova 5, Beograd', 'Prva smjena', 'Prodaja kozmetike', 45000.00, '2023-02-15'),
(2, 'Milica', 'Petrović', '+381611234567', 'Njegoševa 10, Novi Sad', 'Druga smjena', 'Nabavka robe', 50000.00, '2022-09-20'),
(3, 'Stefan', 'Đorđević', '+381641234567', 'Cara Dušana 15, Niš', 'Treća smjena', 'Računovodstvo', 55000.00, '2023-01-10'),
(4, 'Ana', 'Marković', '+381621234567', 'Kralja Petra 8, Subotica', 'Prva smjena', 'Prodaja parfema', 48000.00, '2023-03-05'),
(5, 'Nikola', 'Nikolić', '+381631234567', 'Trg Republike 3, Kragujevac', 'Druga smjena', 'Marketing', 52000.00, '2022-12-12'),
(6, 'Jovana', 'Stojanović', '+381641234567', 'Vuka Karadžića 12, Čačak', 'Prva smjena', 'Administracija', 46000.00, '2023-04-18'),
(7, 'Filip', 'Ilić', '+381611234567', 'Gospodar Jevremova 20, Zrenjanin', 'Treća smjena', 'IT podrška', 58000.00, '2022-11-25'),
(8, 'Mila', 'Pavlović', '+381621234567', 'Nikole Pašića 25, Novi Pazar', 'Prva smjena', 'Prodaja makeupa', 49000.00, '2023-02-28'),
(9, 'Marko', 'Stanković', '+381631234567', 'Svetog Save 7, Šabac', 'Druga smjena', 'Logistika', 51000.00, '2022-10-08'),
(10, 'Jelena', 'Simić', '+381641234567', 'Karađorđeva 30, Kraljevo', 'Treća smjena', 'Prodaja lijekova', 56000.00, '2023-01-15'),
(11,'Tijana', 'Lazendić','+38766321449','Gornji Graci bb Mrkonjić Grad','Prva smjena','Direktor',4000.00,'2025-03-11');


INSERT INTO drogerija.TESTER (PROIZVOD_IdProizvod) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);

INSERT INTO drogerija.NABAVLJANJE (DOBAVLJAČ_IdDobavljač, DatumNabavke, ZAPOSLENI_IdZaposlenog) VALUES
(1, '2023-05-10', 1),
(2, '2023-05-12', 2),
(3, '2023-05-15', 3),
(4, '2023-05-18', 4),
(5, '2023-05-20', 5),
(6, '2023-05-22', 6),
(7, '2023-05-25', 7),
(8, '2023-05-28', 8),
(9, '2023-05-30', 9),
(10, '2023-06-01', 10);

-- Insert data into STAVKA_NABAVKE
INSERT INTO drogerija.STAVKA_NABAVKE (CijenaNabavna, NABAVLJANJE_IdNabavke, Kolicina) VALUES
( 50.00, 1, 100),
( 25.00, 2, 150),
( 30.00, 3, 120),
( 15.00, 4, 200),
( 40.00, 5, 80),
( 20.00, 6, 160),
( 35.00, 7, 90),
( 18.00, 8, 140),
( 22.00, 9, 110),
( 45.00, 10, 70);

-- Insert data into PRODAJNI_ARTIKL
INSERT INTO drogerija.PRODAJNI_ARTIKL (Cijena, PROIZVOD_IdProizvod, STAVKA_NABAVKE_NABAVLJANJE_IdNabavke) VALUES
(55.00, 1,  1),
(30.00, 2,  2),
(40.00, 3,  3),
(20.00, 4,  4),
(60.00, 5,  5),
(25.00, 6,  6),
(38.00, 7,  7),
(15.00, 8,  8),
(28.00, 9,  9),
(50.00, 10,  10);


-- Insert data into PROMOTER
INSERT INTO drogerija.PROMOTER (ZAPOSLENI_IdZaposlenog, BREND_Naziv) VALUES
(1, 'Nivea'),
(2, 'L\'Oreal'),
(3, 'Maybelline'),
(4, 'Dove'),
(5, 'Garnier'),
(6, 'Chanel'),
(7, 'Clinique'),
(8, 'MAC'),
(9, 'Pantene'),
(10, 'Oral-B');

INSERT INTO drogerija.NALOG (IdNaloga, KorisnickoIme, Lozinka) 
VALUES
(1, 'jovan.jovanovic', 'jovan123'),
(2, 'milica.petrovic', 'milica123'),
(3, 'stefan.djordjevic', 'stefan123'),
(4, 'ana.markovic', 'ana123'),
(5, 'nikola.nikolic', 'nikola123'),
(6, 'jovana.stojanovic', 'jovana123'),
(7, 'filip.ilic', 'filip123'),
(8, 'mila.pavlovic', 'mila123'),
(9, 'marko.stankovic', 'marko123'),
(10, 'jelena.simic', 'jelena123'),
(11,'tijana.lazendic','tijana123');

INSERT INTO drogerija.RADNIK (JeŠefSmjene, ZAPOSLENI_IdZaposlenog, ODJEL_IdOdjela, NALOG_IdNaloga) 
VALUES
( 1, 1, 1,1),
( 0, 2, 2,2),
( 0, 3, 3,3),
( 0, 4, 4,4),
( 0, 5, 5,5),
( 0, 6, 6,6),
( 0, 7, 7,7),
( 0, 8, 8,8),
( 0, 9, 9,9),
(0, 10, 10,10);

INSERT INTO drogerija.POKLON_BON (IdPoklonBona, PRODAJNI_ARTIKL_PROIZVOD_IdProizvod) VALUES
(1, 1),
(2, 3),
(3, 5),
(4, 8),
(5, 9);

INSERT INTO drogerija.DIREKTOR (ZAPOSLENI_IdZaposlenog,NALOG_IdNaloga) VALUES
(11,11);



INSERT INTO drogerija.POPUST (IdPopust, ProcenatPopusta, DatumPocetka, DatumKraja, BREND_Naziv, PROIZVOD_IdProizvod) VALUES
(1, 15, '2024-06-01 00:00:00', '2024-06-30 23:59:59', 'Nivea', NULL),
(2, 20, '2024-07-01 00:00:00', '2024-07-31 23:59:59', 'Maybelline', NULL),
(3, 10, '2024-06-15 00:00:00', '2024-07-15 23:59:59', NULL, 3),
(4, 25, '2024-06-10 00:00:00', '2024-07-10 23:59:59', NULL, 8),
(5, 30, '2024-06-20 00:00:00', '2024-07-20 23:59:59', 'Chanel', NULL);

INSERT INTO drogerija.RAČUN (IdRačun, DatumVrijemeIzdavanja, NacinPlacanja, KASA_IdKasa, NALOG_IdNaloga) VALUES
(1, '2024-06-15 10:30:00', 'Gotovina', 1, 1),
(2, '2024-06-15 11:45:00', 'Kartica',  1, 2),
(3, '2024-06-16 09:00:00', 'Gotovina',  2, 3),
(4, '2024-06-16 14:20:00', 'Kartica',  3, 4),
(5, '2024-06-17 13:15:00', 'Gotovina', 2, 5),
(6, '2024-06-18 12:00:00', 'Kartica', 3, 6),
(7, '2024-06-19 16:30:00', 'Kartica',1, 7),
(8, '2024-06-20 10:00:00', 'Gotovina',  2, 8),
(9, '2024-06-21 15:45:00', 'Kartica',  3, 9),
(10, '2024-06-22 11:20:00', 'Gotovina',  1, 10);

INSERT INTO drogerija.STAVKA_RACUN (Količina, CijenaProdajna, PRODAJNI_ARTIKL_PROIZVOD_IdProizvod, RAČUN_IdRačun) VALUES
(2, 55.00, 1, 1),
(1, 30.00, 2, 2),
(3, 40.00, 3, 3),
(1, 20.00, 4, 4),
(2, 60.00, 5, 5),
(2, 25.00, 6, 6),
(3, 38.00, 7, 7),
(1, 15.00, 8, 8),
(4, 28.00, 9, 9),
(2, 50.00, 10, 10),
(1, 25.00, 6, 1);


INSERT INTO drogerija.KASA_KORISTENJE (NALOG_IdNaloga, KASA_IdKasa, VrijemePocetka, VrijemeZavrsetka, IdKoristenjaKase) VALUES
(1, 1, '2024-06-15 08:00:00', '2024-06-15 16:00:00', 1),
(2, 1, '2024-06-16 08:00:00', '2024-06-16 16:00:00', 2),
(3, 2, '2024-06-17 08:00:00', '2024-06-17 16:00:00', 3),
(4, 2, '2024-06-18 08:00:00', '2024-06-18 16:00:00', 4),
(5, 3, '2024-06-19 08:00:00', '2024-06-19 16:00:00', 5),
(6, 3, '2024-06-20 08:00:00', '2024-06-20 16:00:00', 6),
(7, 1, '2024-06-21 08:00:00', '2024-06-21 16:00:00', 7),
(8, 2, '2024-06-22 08:00:00', '2024-06-22 16:00:00', 8),
(9, 3, '2024-06-23 08:00:00', '2024-06-23 16:00:00', 9),
(10, 1, '2024-06-24 08:00:00', '2024-06-24 16:00:00', 10);

INSERT INTO `drogerija`.`BREND_DOBAVLJAC` (`DOBAVLJAČ_IdDobavljač`, `BREND_Naziv`, `PocetakRadaZaBrend`, `KrajRadaZaBrend`) VALUES
(1, 'Nivea', '2022-01-01 00:00:00', '2023-01-01 00:00:00'),
(2, 'Dove', '2021-06-15 00:00:00', '2022-06-15 00:00:00'),
(3, 'L\'Oreal', '2020-03-10 00:00:00', '2021-03-10 00:00:00'),
(4, 'Garnier', '2019-11-20 00:00:00', '2020-11-20 00:00:00'),
(5, 'Maybelline', '2022-07-25 00:00:00', '2023-07-25 00:00:00'),
(6, 'Pantene', '2021-09-30 00:00:00', '2022-09-30 00:00:00'),
(7, 'Clinique', '2020-12-15 00:00:00', '2021-12-15 00:00:00'),
(8, 'MAC', '2019-04-05 00:00:00', '2020-04-05 00:00:00'),
(9, 'Oral-B', '2021-05-20 00:00:00', '2022-05-20 00:00:00'),
(10, 'Chanel', '2020-08-10 00:00:00', '2021-08-10 00:00:00');
