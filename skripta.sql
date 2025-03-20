-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema drogerija
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `drogerija` ;

-- -----------------------------------------------------
-- Schema drogerija
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `drogerija` DEFAULT CHARACTER SET utf8 ;
USE `drogerija` ;

-- -----------------------------------------------------
-- Table `drogerija`.`ODJEL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`ODJEL` (
  `IdOdjela` INT NOT NULL,
  `Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdOdjela`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`KATEGORIJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`KATEGORIJA` (
  `Naziv` VARCHAR(50) NOT NULL,
  `Opis` VARCHAR(200) NOT NULL,
  `IdKategorija` INT NOT NULL,
  `ODJEL_IdOdjela` INT NOT NULL,
  PRIMARY KEY (`IdKategorija`),
  INDEX `fk_KATEGORIJA_ODJEL1_idx` (`ODJEL_IdOdjela` ASC) VISIBLE,
  CONSTRAINT `fk_KATEGORIJA_ODJEL1`
    FOREIGN KEY (`ODJEL_IdOdjela`)
    REFERENCES `drogerija`.`ODJEL` (`IdOdjela`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`BREND`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`BREND` (
  `Naziv` VARCHAR(45) NOT NULL,
  `Kontakt` VARCHAR(45) NOT NULL,
  `ZemljaPorijekla` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Naziv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`PROIZVOD`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`PROIZVOD` (
  `Naziv` VARCHAR(20) NOT NULL,
  `Opis` VARCHAR(200) NOT NULL,
  `KoličinaNaStanju` INT NOT NULL,
  `Sastav` VARCHAR(200) NOT NULL,
  `IdProizvod` INT NOT NULL,
  `KATEGORIJA_IdKategorija` INT NOT NULL,
  `BREND_Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdProizvod`),
  INDEX `fk_PROIZVOD_KATEGORIJA_idx` (`KATEGORIJA_IdKategorija` ASC) VISIBLE,
  INDEX `fk_PROIZVOD_BREND1_idx` (`BREND_Naziv` ASC) VISIBLE,
  CONSTRAINT `fk_PROIZVOD_KATEGORIJA`
    FOREIGN KEY (`KATEGORIJA_IdKategorija`)
    REFERENCES `drogerija`.`KATEGORIJA` (`IdKategorija`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PROIZVOD_BREND1`
    FOREIGN KEY (`BREND_Naziv`)
    REFERENCES `drogerija`.`BREND` (`Naziv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`TESTER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`TESTER` (
  `PROIZVOD_IdProizvod` INT NOT NULL,
  INDEX `fk_TESTER_PROIZVOD1_idx` (`PROIZVOD_IdProizvod` ASC) VISIBLE,
  PRIMARY KEY (`PROIZVOD_IdProizvod`),
  CONSTRAINT `fk_TESTER_PROIZVOD1`
    FOREIGN KEY (`PROIZVOD_IdProizvod`)
    REFERENCES `drogerija`.`PROIZVOD` (`IdProizvod`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`DOBAVLJAČ`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`DOBAVLJAČ` (
  `IdDobavljač` INT NOT NULL,
  `Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdDobavljač`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`ZAPOSLENI`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`ZAPOSLENI` (
  `IdZaposlenog` INT NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(45) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `Telefon` VARCHAR(45) NOT NULL,
  `Adresa` VARCHAR(45) NOT NULL,
  `Smjena` VARCHAR(45) NOT NULL,
  `Zaduženje` VARCHAR(45) NOT NULL,
  `Plata` DECIMAL(10,2) NOT NULL,
  `DatumZaposlenja` DATE NOT NULL,
  PRIMARY KEY (`IdZaposlenog`),
  UNIQUE INDEX `IdZaposlenog_UNIQUE` (`IdZaposlenog` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`NABAVLJANJE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`NABAVLJANJE` (
  `DOBAVLJAČ_IdDobavljač` INT NOT NULL,
  `DatumNabavke` DATE NOT NULL,
  `IdNabavke` INT NOT NULL AUTO_INCREMENT,
  `ZAPOSLENI_IdZaposlenog` INT NOT NULL,
  INDEX `fk_DOBAVLJAČ_has_STAVKA_NABAVKE_DOBAVLJAČ1_idx` (`DOBAVLJAČ_IdDobavljač` ASC) VISIBLE,
  PRIMARY KEY (`IdNabavke`),
  INDEX `fk_NABAVLJANJE_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog` ASC) VISIBLE,
  CONSTRAINT `fk_DOBAVLJAČ_has_STAVKA_NABAVKE_DOBAVLJAČ1`
    FOREIGN KEY (`DOBAVLJAČ_IdDobavljač`)
    REFERENCES `drogerija`.`DOBAVLJAČ` (`IdDobavljač`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_NABAVLJANJE_ZAPOSLENI1`
    FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`)
    REFERENCES `drogerija`.`ZAPOSLENI` (`IdZaposlenog`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`STAVKA_NABAVKE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`STAVKA_NABAVKE` (
  `CijenaNabavna` DECIMAL(10,2) NOT NULL,
  `NABAVLJANJE_IdNabavke` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  PRIMARY KEY (`NABAVLJANJE_IdNabavke`),
  INDEX `fk_STAVKA_NABAVKE_NABAVLJANJE1_idx` (`NABAVLJANJE_IdNabavke` ASC) VISIBLE,
  CONSTRAINT `fk_STAVKA_NABAVKE_NABAVLJANJE1`
    FOREIGN KEY (`NABAVLJANJE_IdNabavke`)
    REFERENCES `drogerija`.`NABAVLJANJE` (`IdNabavke`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`PRODAJNI_ARTIKL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`PRODAJNI_ARTIKL` (
  `Cijena` DECIMAL(10,2) NOT NULL,
  `PROIZVOD_IdProizvod` INT NOT NULL,
  `STAVKA_NABAVKE_NABAVLJANJE_IdNabavke` INT NOT NULL,
  INDEX `fk_PRODAJNI_ARTIKL_PROIZVOD1_idx` (`PROIZVOD_IdProizvod` ASC) VISIBLE,
  PRIMARY KEY (`PROIZVOD_IdProizvod`, `STAVKA_NABAVKE_NABAVLJANJE_IdNabavke`),
  INDEX `fk_PRODAJNI_ARTIKL_STAVKA_NABAVKE1_idx` (`STAVKA_NABAVKE_NABAVLJANJE_IdNabavke` ASC) VISIBLE,
  CONSTRAINT `fk_PRODAJNI_ARTIKL_PROIZVOD1`
    FOREIGN KEY (`PROIZVOD_IdProizvod`)
    REFERENCES `drogerija`.`PROIZVOD` (`IdProizvod`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PRODAJNI_ARTIKL_STAVKA_NABAVKE1`
    FOREIGN KEY (`STAVKA_NABAVKE_NABAVLJANJE_IdNabavke`)
    REFERENCES `drogerija`.`STAVKA_NABAVKE` (`NABAVLJANJE_IdNabavke`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`KASA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`KASA` (
  `IdKasa` INT NOT NULL,
  PRIMARY KEY (`IdKasa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`NALOG`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`NALOG` (
  `KorisnickoIme` VARCHAR(45) NOT NULL,
  `Lozinka` VARCHAR(45) NOT NULL,
  `IdNaloga` INT NOT NULL,
  PRIMARY KEY (`IdNaloga`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`RADNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`RADNIK` (
  `JeŠefSmjene` TINYINT NOT NULL,
  `ZAPOSLENI_IdZaposlenog` INT NOT NULL,
  `ODJEL_IdOdjela` INT NOT NULL,
  `NALOG_IdNaloga` INT NOT NULL,
  INDEX `fk_RADNIK_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog` ASC) VISIBLE,
  INDEX `fk_RADNIK_ODJEL1_idx` (`ODJEL_IdOdjela` ASC) VISIBLE,
  PRIMARY KEY (`ZAPOSLENI_IdZaposlenog`),
  INDEX `fk_RADNIK_NALOG1_idx` (`NALOG_IdNaloga` ASC) VISIBLE,
  CONSTRAINT `fk_RADNIK_ZAPOSLENI1`
    FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`)
    REFERENCES `drogerija`.`ZAPOSLENI` (`IdZaposlenog`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RADNIK_ODJEL1`
    FOREIGN KEY (`ODJEL_IdOdjela`)
    REFERENCES `drogerija`.`ODJEL` (`IdOdjela`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RADNIK_NALOG1`
    FOREIGN KEY (`NALOG_IdNaloga`)
    REFERENCES `drogerija`.`NALOG` (`IdNaloga`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`PROMOTER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`PROMOTER` (
  `IdPromoter` INT NOT NULL AUTO_INCREMENT,
  `ZAPOSLENI_IdZaposlenog` INT NOT NULL,
  `BREND_Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdPromoter`),
  INDEX `fk_PROMOTER_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog` ASC) VISIBLE,
  INDEX `fk_PROMOTER_BREND1_idx` (`BREND_Naziv` ASC) VISIBLE,
  CONSTRAINT `fk_PROMOTER_ZAPOSLENI1`
    FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`)
    REFERENCES `drogerija`.`ZAPOSLENI` (`IdZaposlenog`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PROMOTER_BREND1`
    FOREIGN KEY (`BREND_Naziv`)
    REFERENCES `drogerija`.`BREND` (`Naziv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`POKLON_BON`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`POKLON_BON` (
  `IdPoklonBona` INT NOT NULL,
  `PRODAJNI_ARTIKL_PROIZVOD_IdProizvod` INT NOT NULL,
  PRIMARY KEY (`IdPoklonBona`),
  INDEX `fk_POKLON_BON_PRODAJNI_ARTIKL1_idx` (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod` ASC) VISIBLE,
  CONSTRAINT `fk_POKLON_BON_PRODAJNI_ARTIKL1`
    FOREIGN KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`)
    REFERENCES `drogerija`.`PRODAJNI_ARTIKL` (`PROIZVOD_IdProizvod`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`POPUST`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`POPUST` (
  `IdPopust` INT NOT NULL,
  `ProcenatPopusta` INT NOT NULL,
  `DatumPocetka` DATETIME NOT NULL,
  `DatumKraja` DATETIME NOT NULL,
  `BREND_Naziv` VARCHAR(45) NULL,
  `PROIZVOD_IdProizvod` INT NULL,
  PRIMARY KEY (`IdPopust`),
  INDEX `fk_POPUST_BREND1_idx` (`BREND_Naziv` ASC) VISIBLE,
  INDEX `fk_POPUST_PROIZVOD1_idx` (`PROIZVOD_IdProizvod` ASC) VISIBLE,
  CONSTRAINT `fk_POPUST_BREND1`
    FOREIGN KEY (`BREND_Naziv`)
    REFERENCES `drogerija`.`BREND` (`Naziv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_POPUST_PROIZVOD1`
    FOREIGN KEY (`PROIZVOD_IdProizvod`)
    REFERENCES `drogerija`.`PROIZVOD` (`IdProizvod`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`RAČUN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`RAČUN` (
  `IdRačun` INT NOT NULL AUTO_INCREMENT,
  `DatumVrijemeIzdavanja` DATETIME NOT NULL,
  `NacinPlacanja` VARCHAR(45) NOT NULL,
  `Iznos` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `KASA_IdKasa` INT NOT NULL,
  `NALOG_IdNaloga` INT NOT NULL,
  PRIMARY KEY (`IdRačun`),
  INDEX `fk_RAČUN_KASA1_idx` (`KASA_IdKasa` ASC) VISIBLE,
  INDEX `fk_RAČUN_NALOG1_idx` (`NALOG_IdNaloga` ASC) VISIBLE,
  CONSTRAINT `fk_RAČUN_KASA1`
    FOREIGN KEY (`KASA_IdKasa`)
    REFERENCES `drogerija`.`KASA` (`IdKasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RAČUN_NALOG1`
    FOREIGN KEY (`NALOG_IdNaloga`)
    REFERENCES `drogerija`.`NALOG` (`IdNaloga`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`STAVKA_RACUN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`STAVKA_RACUN` (
  `Količina` INT NOT NULL,
  `CijenaProdajna` DECIMAL(10,2) NOT NULL,
  `PRODAJNI_ARTIKL_PROIZVOD_IdProizvod` INT NOT NULL,
  `RAČUN_IdRačun` INT NOT NULL,
  PRIMARY KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`, `RAČUN_IdRačun`),
  INDEX `fk_STAVKA_RACUN_RAČUN1_idx` (`RAČUN_IdRačun` ASC) VISIBLE,
  CONSTRAINT `fk_STAVKA_RACUN_PRODAJNI_ARTIKL1`
    FOREIGN KEY (`PRODAJNI_ARTIKL_PROIZVOD_IdProizvod`)
    REFERENCES `drogerija`.`PRODAJNI_ARTIKL` (`PROIZVOD_IdProizvod`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_STAVKA_RACUN_RAČUN1`
    FOREIGN KEY (`RAČUN_IdRačun`)
    REFERENCES `drogerija`.`RAČUN` (`IdRačun`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`KASA_KORISTENJE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`KASA_KORISTENJE` (
  `NALOG_IdNaloga` INT NOT NULL,
  `KASA_IdKasa` INT NOT NULL,
  `VrijemePocetka` DATETIME NOT NULL,
  `VrijemeZavrsetka` DATETIME NOT NULL,
  `IdKoristenjaKase` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`IdKoristenjaKase`),
  INDEX `fk_NALOG_has_KASA_KASA1_idx` (`KASA_IdKasa` ASC) VISIBLE,
  INDEX `fk_NALOG_has_KASA_NALOG1_idx` (`NALOG_IdNaloga` ASC) VISIBLE,
  UNIQUE INDEX `VrijemePocetka_UNIQUE` (`VrijemePocetka` ASC) VISIBLE,
  UNIQUE INDEX `VrijemeZavrsetka_UNIQUE` (`VrijemeZavrsetka` ASC) VISIBLE,
  CONSTRAINT `fk_NALOG_has_KASA_NALOG1`
    FOREIGN KEY (`NALOG_IdNaloga`)
    REFERENCES `drogerija`.`NALOG` (`IdNaloga`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_NALOG_has_KASA_KASA1`
    FOREIGN KEY (`KASA_IdKasa`)
    REFERENCES `drogerija`.`KASA` (`IdKasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`BREND_DOBAVLJAC`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`BREND_DOBAVLJAC` (
  `DOBAVLJAČ_IdDobavljač` INT NOT NULL,
  `BREND_Naziv` VARCHAR(45) NOT NULL,
  `PocetakRadaZaBrend` DATETIME NOT NULL,
  `KrajRadaZaBrend` DATETIME NOT NULL,
  PRIMARY KEY (`DOBAVLJAČ_IdDobavljač`, `BREND_Naziv`),
  INDEX `fk_DOBAVLJAČ_has_BREND_BREND1_idx` (`BREND_Naziv` ASC) VISIBLE,
  INDEX `fk_DOBAVLJAČ_has_BREND_DOBAVLJAČ1_idx` (`DOBAVLJAČ_IdDobavljač` ASC) VISIBLE,
  CONSTRAINT `fk_DOBAVLJAČ_has_BREND_DOBAVLJAČ1`
    FOREIGN KEY (`DOBAVLJAČ_IdDobavljač`)
    REFERENCES `drogerija`.`DOBAVLJAČ` (`IdDobavljač`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DOBAVLJAČ_has_BREND_BREND1`
    FOREIGN KEY (`BREND_Naziv`)
    REFERENCES `drogerija`.`BREND` (`Naziv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `drogerija`.`DIREKTOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `drogerija`.`DIREKTOR` (
  `ZAPOSLENI_IdZaposlenog` INT NOT NULL,
  `NALOG_IdNaloga` INT NOT NULL,
  INDEX `fk_DIREKTOR_ZAPOSLENI1_idx` (`ZAPOSLENI_IdZaposlenog` ASC) VISIBLE,
  PRIMARY KEY (`ZAPOSLENI_IdZaposlenog`),
  INDEX `fk_DIREKTOR_NALOG1_idx` (`NALOG_IdNaloga` ASC) VISIBLE,
  CONSTRAINT `fk_DIREKTOR_ZAPOSLENI1`
    FOREIGN KEY (`ZAPOSLENI_IdZaposlenog`)
    REFERENCES `drogerija`.`ZAPOSLENI` (`IdZaposlenog`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DIREKTOR_NALOG1`
    FOREIGN KEY (`NALOG_IdNaloga`)
    REFERENCES `drogerija`.`NALOG` (`IdNaloga`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
