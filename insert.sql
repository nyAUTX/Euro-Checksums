-- CREATE TABLE Language (languageID int IDENTITY NOT NULL, code char(3) NOT NULL UNIQUE, name varchar(255) NOT NULL UNIQUE, PRIMARY KEY (languageID));
SET IDENTITY_INSERT Language ON;
INSERT INTO Language (languageID, code, name)
VALUES
    (1, 'deu', 'Deutsch'),
    (2, 'eng', 'English');
SET IDENTITY_INSERT Language OFF;

-- CREATE TABLE Countries (id int IDENTITY NOT NULL, code char(3) NOT NULL UNIQUE, PRIMARY KEY (id));
SET IDENTITY_INSERT Countries ON;
INSERT INTO Countries (id, code)
VALUES
    (616, 'POL'),
    (250, 'FRA'),
    (100, 'BUL'),
    (826, 'GBR'),
    (372, 'IRL'),
    (620, 'PRT'),
    (040, 'AUT'),
    (528, 'NLD'),
    (276, 'DEU'),
    (380, 'ITA'),
    (724, 'ESP'),
    (300, 'GRC'),
    (056, 'BEL'),
    (428, 'LVA'),
    (440, 'LTU'),
    (233, 'EST'),
    (246, 'FIN'),
    (246, 'SVK'),
    (196, 'CYP'),
    (705, 'SVN'),
    (578, 'NOR'),
    (752, 'SWE'),
    (208, 'DNK'),
    (442, 'LUX'),
    (203, 'CZE'),
    (705, 'MLT');
SET IDENTITY_INSERT Countries OFF;

-- CREATE TABLE LCountries (countryID int NOT NULL, languageID int NOT NULL, name varchar(255) NOT NULL, PRIMARY KEY (countryID, languageID));
INSERT INTO LCountries (countryID, languageID, name)
VALUES
    (616,1,'Polen'),
    (616,2,'Poland'),
    (250,1,'Frankreich'),
    (250,2,'France'),
    (100,1,'Bulgarien'),
    (100,2,'Bulgaria'),
    (826,1,'Vereinigtes Königreich'),
    (826,2,'United Kingdom'),
    (372,1,'Irland'),
    (372,2,'Ireland'),
    (620,1,'Portugal'),
    (620,2,'Portugal'),
    (040,1,'Österreich'),
    (040,2,'Austria'),
    (528,1,'Niederlande'),
    (528,2,'Netherlands'),
    (276,1,'Deutschland'),
    (276,2,'Germany'),
    (380,1,'Italien'),
    (380,2,'Italy'),
    (724,1,'Spanien'),
    (724,2,'Spain'),
    (300,1,'Griechenland'),
    (300,2,'Greece'),
    (056,1,'Belgien'),
    (056,2,'Belgium'),
    (428,1,'Lettland'),
    (428,2,'Latvia'),
    (440,1,'Litauen'),
    (440,2,'Lithuania'),
    (233,1,'Estland'),
    (233,2,'Estonia'),
    (246,1,'Finnland'),
    (246,2,'Finland'),
    (246,1,'Slowakei'),
    (246,2,'Slovakia'),
    (196,1,'Zypern'),
    (196,2,'Cyprus'),
    (705,1,'Slowenien'),
    (705,2,'Slovenia'),
    (578,1,'Norwegen'),
    (578,2,'Norway'),
    (752,1,'Schweden'),
    (752,2,'Sweden'),
    (208,1,'Dänemark'),
    (208,2,'Denmark'),
    (442,1,'Luxemburg'),
    (442,2,'Luxembourg'),
    (203,1,'Tschechien'),
    (203,2,'Czech Republic'),
    (705,1,'Malta'),
    (705,2,'Malta');

-- CREATE TABLE Cities (id int IDENTITY NOT NULL, code char(6) NOT NULL UNIQUE, PRIMARY KEY (id));
SET IDENTITY_INSERT Cities ON;
INSERT INTO Cities (id, code)
VALUES
    (1, 'PL-WAW'),
    (2, 'FR-CHA'),
    (3, 'BG-SOF'),
    (4, 'GB-LOU'),
    (5, 'GB-GAT'),
    (6, 'PT-CAR'),
    (7, 'AT-VIE'),
    (8, 'NL-HAA'),
    (9, 'DE-BER'),
    (10, 'IT-ROM'),
    (11, 'IE-DUB'),
    (12, 'FR-CHA'),
    (13, 'ES-MAD'),
    (14, 'DE-LEI'),
    (15, 'DE-MUN'),
    (16, 'GR-ATH'),
    (17, 'BE-BRU'),
    (18, 'LV-RIG'),
    (19, 'LT-VIL'),
    (20, 'EE-TAL'),
    (21, 'FI-HEI'),
    (22, 'SK-BRA'),
    (23, 'CY-NIC'),
    (24, 'SI-LJU'),
    (25, 'NO-OSL'),
    (26, 'SE-STO'),
    (27, 'DK-COP'),
    (28, 'LU-LUX'),
    (29, 'CZ-PRA'),
    (30, 'MT-VAL');

-- CREATE TABLE LCities (cityID int NOT NULL, languageID int NOT NULL, name varchar(255) NOT NULL, PRIMARY KEY (cityID, languageID));
INSERT INTO LCities (cityID, languageID, name)
VALUES
    (1,1, 'Warschau'),
    (1,2, 'Warsaw'),
    (2,1, 'Chantepie'),
    (2,2, 'Chantepie'),
    (3,1, 'Sofia'),
    (3,2, 'Sofia'),
    (4,1, 'Loughton'),
    (4,2, 'Loughton'),
    (5,1, 'Gateshead'),
    (5,2, 'Gateshead'),
    (6,1, 'Carregado'),
    (6,2, 'Carregado'),
    (7,1, 'Wien'),
    (7,2, 'Vienna'),
    (8,1, 'Den Haag'),
    (8,2, 'The Hague'),
    (9,1, 'Berlin'),
    (9,2, 'Berlin'),
    (10,1, 'Rom'),
    (10,2, 'Rome'),
    (11,1, 'Dublin'),
    (11,2, 'Dublin'),
    (12,1, 'Chantepie'),
    (12,2, 'Chantepie'),
    (13,1, 'Madrid'),
    (13,2, 'Madrid'),
    (14,1, 'Loughton'),
    (14,2, 'Loughton'),
    (15,1, 'München'),
    (15,2, 'Munich'),
    (16,1, 'Athen'),
    (16,2, 'Athens'),
    (17,1, 'Brüssel'),
    (17,2, 'Brussels'),
    (18,1, 'Riga'),
    (18,2, 'Riga'),
    (19,1, 'Vilnius'),
    (19,2, 'Vilnius'),
    (20,1, 'Tallinn'),
    (20,2, 'Tallinn'),
    (21,1, 'Helsinki'),
    (21,2, 'Helsinki'),
    (22,1, 'Bratislava'),
    (22,2, 'Bratislava'),
    (23,1, 'Nikosia'),
    (23,2, 'Nicosia'),
    (24,1, 'Ljubljana'),
    (24,2, 'Ljubljana'),
    (25,1, 'Oslo'),
    (25,2, 'Oslo'),
    (26,1, 'Stockholm'),
    (26,2, 'Stockholm'),
    (27,1, 'Kopenhagen'),
    (27,2, 'Copenhagen'),
    (28,1, 'Luxemburg'),
    (28,2, 'Luxembourg'),
    (29,1, 'Prag'),
    (29,2, 'Prague'),
    (30,1, 'Valletta'),
    (30,2, 'Valletta');

-- CREATE TABLE EuropeSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, printery varchar(255) NOT NULL, country varchar(255) NOT NULL, city varchar(255) NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));

INSERT INTO EuropeSeries
VALUES
  ('D', 'Polska Wytwórnia Papierów Wartościowych', 'Poland', 'Warsaw', 'FALSE'),
  ('E', 'Oberthur Fiduciaire', 'France', 'Chantepie', 'TRUE'),
  ('F', 'Oberthur Fiduciaire AD Bulgaria', 'Bulgaria', 'Sofia', 'TRUE'),
  ('H', 'De La Rue Currency', 'United Kingdom', 'Loughton', 'FALSE'),
  ('J', 'De La Rue Currency', 'United Kingdom', 'Gateshead', 'FALSE'),
  ('M', 'Valora SA', 'Portugal', 'Carregado', 'TRUE'),
  ('N', 'Österreichische Banknoten- und Sicherheitsdruck GmbH', 'Austria', 'Vienna', 'TRUE'),
  ('P', 'Joh. Enschede Security Printing BV', 'Netherlands', 'Haarlem', 'TRUE'),
  ('R', 'Bundesdruckerei GmbH', 'Germany', 'Berlin', 'TRUE'),
  ('S', 'Banca d’Italia', 'Italy', 'Rome', 'TRUE'),
  ('T', 'Central Bank of Ireland', 'Ireland', 'Dublin', 'TRUE'),
  ('U', 'Banque de France', 'France', 'Chamalières', 'TRUE'),
  ('V', 'IMBISA', 'Spain', 'Madrid', 'TRUE'),
  ('W', 'Giesecke+Devrient GmbH', 'Germany', 'Leipzig', 'TRUE'),
  ('X', 'Giesecke+Devrient GmbH', 'Germany', 'Munich', 'TRUE'),
  ('Y', 'Bank of Greece', 'Greece', 'Athens', 'TRUE'),
  ('Z', 'Nationale Bank van België', 'Belgium', 'Brussels', 'TRUE');

-- CREATE TABLE OldSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, country varchar(255) NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));

INSERT INTO OldSeries (code, country, circulation) VALUES ('B', 'Lithuania', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('C', 'Latvia', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('D', 'Estonia', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('E', 'Slovakia', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('F', 'Malta', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('G', 'Cyprus', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('H', 'Slovenia', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('J', 'United Kingdom', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('K', 'Sweden', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('L', 'Finland', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('M', 'Portugal', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('N', 'Austria', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('P', 'Netherlands', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('R', 'Luxembourg', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('S', 'Italy', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('T', 'Ireland', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('U', 'France', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('V', 'Spain', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('W', 'Denmark', 'FALSE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('X', 'Germany', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('Y', 'Greece', 'TRUE');
INSERT INTO OldSeries (code, country, circulation) VALUES ('Z', 'Belgium', 'TRUE');

-- CREATE TABLE Printery (id int IDENTITY NOT NULL, code char(1) NOT NULL, name varchar(255) NOT NULL, country varchar(255) NOT NULL, city varchar(255) NOT NULL, circulation int NOT NULL, PRIMARY KEY (id));

INSERT INTO Printery (code, name, country, city, circulation) VALUES ('A', 'Bank of England Printing Works', 'United Kingdom', 'Loughton', 'FALSE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('C', 'AB Tumba Bruk', 'Sweden', 'Tumba', 'FALSE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('D', 'Setec Oy', 'Finland', 'Vantaa', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('E', 'Oberthur Technologies', 'France', 'Chantepie', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('F', 'Österreichische Banknoten- und Sicherheitsdruck GmbH', 'Austria', 'Wien', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('G', 'Koninklijke Joh. Enschedé', 'Netherlands', 'Haarlem', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('H', 'De La Rue plc.', 'United Kingdom', 'Gateshead', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('J', 'Istituto Poligrafico e Zecca dello Stato', 'Italy', 'Rom', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('K', 'Central Bank of Ireland', 'Ireland', 'Dublin', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('L', 'Banque de France', 'France', 'Chamalières', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('M', 'Fábrica Nacional de Moneda y Timbre', 'Spain', 'Madrid', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('N', 'Bank von Griechenland', 'Greece', 'Athen', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('P', 'Giesecke+Devrient GmbH', 'Germany', 'München/Leipzig', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('R', 'Thunderstruck', 'Germany', 'Berlin', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('S', 'Danmarks Nationalbank', 'Denmark', 'Kopenhagen', 'FALSE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('T', 'Nationale Bank van België', 'Belgium', 'Brüssel', 'TRUE');
INSERT INTO Printery (code, name, country, city, circulation) VALUES ('U', 'Valora SA', 'Portugal', 'Carregado', 'TRUE');