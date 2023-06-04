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
    (703, 'SVK'),
    (196, 'CYP'),
    (705, 'SVN'),
    (578, 'NOR'),
    (752, 'SWE'),
    (208, 'DNK'),
    (442, 'LUX'),
    (203, 'CZE'),
    (470, 'MLT');
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
    (703,1,'Slowakei'),
    (703,2,'Slovakia'),
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
    (470,1,'Malta'),
    (470,2,'Malta');

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
    (12, 'FR-CHE'),
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
    (30, 'MT-VAL'),
    (31, 'SE-TUM'),
    (32, 'FI-VAN'),
    (33, 'NL-HAR');
SET IDENTITY_INSERT Cities OFF;

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
    (12,1, 'Chamalières'),
    (12,2, 'Chamalières'),
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
    (30,2, 'Valletta'),
    (31,1, 'Tumba'),
    (31,2, 'Tumba'),
    (32,1, 'Vantaa'),
    (32,2, 'Vantaa'),
    (33,1, 'Haarlem'),
    (33,2, 'Haarlem');



-- CREATE TABLE EuropeSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, printery varchar(255) NOT NULL, countryID int NOT NULL, cityID int NOT NULL, circulation int NOT NULL, PRIMARY KEY (id));

INSERT INTO EuropeSeries (code, printery, countryID, cityID, circulation)
    VALUES
        ('D', 'Polska Wytwórnia Papierów Wartościowych', 616, 1, 0),
        ('E', 'Oberthur Fiduciaire', 250, 2, 1),
        ('F', 'Oberthur Fiduciaire AD Bulgaria', 100, 3, 1),
        ('H', 'De La Rue Currency', 826, 4, 0),
        ('J', 'De La Rue Currency', 826, 5, 0),
        ('M', 'Valora SA', 620, 6, 1),
        ('N', 'Österreichische Banknoten- und Sicherheitsdruck GmbH', 40, 7, 1),
        ('P', 'Joh. Enschede Security Printing BV', 528, 8, 1),
        ('R', 'Bundesdruckerei GmbH', 276, 9, 1),
        ('S', 'Banca d’Italia', 380, 10, 1),
        ('T', 'Central Bank of Ireland', 372, 11, 1),
        ('U', 'Banque de France', 250, 2, 1),
        ('V', 'IMBISA', 724, 13, 1),
        ('W', 'Giesecke+Devrient GmbH', 276, 14, 1),
        ('X', 'Giesecke+Devrient GmbH', 276, 15, 1),
        ('Y', 'Bank of Greece', 300, 16, 1),
        ('Z', 'Nationale Bank van België', 56, 17, 1);

-- CREATE TABLE OldSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, countryID int NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));

INSERT INTO OldSeries (code, countryID, circulation)
    VALUES
        ('B', 440, 0),
        ('C', 428, 0),
        ('D', 233, 1),
        ('E', 703, 1),
        ('F', 470, 1),
        ('G', 196, 1),
        ('H', 705, 1),
        ('J', 826, 0),
        ('K', 752, 0),
        ('L', 250, 1),
        ('M', 620, 1),
        ('N', 40, 1),
        ('P', 528, 1),
        ('R', 442, 0),
        ('S', 380, 1),
        ('T', 372, 1),
        ('U', 250, 1),
        ('V', 724, 1),
        ('W', 208, 0),
        ('X', 276, 1),
        ('Y', 300, 1),
        ('Z', 56, 1);


-- CREATE TABLE Printery (id int IDENTITY NOT NULL, code char(1) NOT NULL, name varchar(255) NOT NULL, countryID int NOT NULL, cityID int NOT NULL, circulation int NOT NULL, PRIMARY KEY (id));
INSERT INTO Printery (code, name, countryID, cityID, circulation)
    VALUES
        ('A', 'Bank of England Printing Works', 826, 4, 0),
        ('C', 'AB Tumba Bruk', 752, 31, 0),
        ('D', 'Setec Oy', 246, 32, 1),
        ('E', 'Oberthur Technologies', 250, 2, 1),
        ('F', 'Österreichische Banknoten- und Sicherheitsdruck GmbH', 40, 7, 1),
        ('G', 'Koninklijke Joh. Enschedé', 528, 33, 1),
        ('H', 'De La Rue plc.', 826, 5, 1),
        ('J', 'Istituto Poligrafico e Zecca dello Stato', 380, 10, 1),
        ('K', 'Central Bank of Ireland', 372, 11, 1),
        ('L', 'Banque de France', 250, 12, 1),
        ('M', 'Fábrica Nacional de Moneda y Timbre', 724, 13, 1),
        ('N', 'Bank von Griechenland', 300, 16, 1),
        ('P', 'Giesecke+Devrient GmbH', 276, 15, 1),
        ('R', 'Thunderstruck', 276, 9, 1),
        ('S', 'Danmarks Nationalbank', 208, 27, 0),
        ('T', 'Nationale Bank van België', 56, 17, 1),
        ('U', 'Valora SA', 620, 12, 1);


-- CREATE TABLE Texts (textID int IDENTITY NOT NULL, [desc] varchar(255) NOT NULL UNIQUE, PRIMARY KEY (textID));
SET IDENTITY_INSERT Texts ON;
INSERT INTO Texts (textID, [desc])
    VALUES
        (0, 'title'),

        (10, 'oldTitle'),
        (11, 'newTitle'),
        (12, 'oldDescription'),
        (13, 'newDescription'),
        (14, 'changeLanguage'),

        (20, 'serialNo'),
        (21, 'printeryCode'),
        (22, 'checkButton'),
        (23, 'oldCountryResult'),
        (24, 'oldPrinteryResult'),
        (25, 'newResult'),
        (26, 'validSerial'),

        (30, 'error'),
        (31, 'serialFormatError'),
        (32, 'printeryFormatError'),
        (33, 'serialInvalidError'),
        (34, 'printeryInvalidError'),
        (35, 'codeMatchError'),

        (40, 'warning'),
        (41, 'circulationWarning');
SET IDENTITY_INSERT Texts OFF;

-- CREATE TABLE LTexts (textID int NOT NULL, languageID int NOT NULL, text varchar(255) NOT NULL UNIQUE, PRIMARY KEY (textID, languageID));
INSERT INTO LTexts (textID, languageID, text)
    VALUES
        (0, 1, 'Euro - Prüfziffernkontrolle'),
        (0, 2, 'Euro - Serial Number Lookup'),

        (10, 1, 'Alte Geldscheine prüfen'),
        (10, 2, 'Check old banknotes'),
        (11, 1, 'Neue Geldscheine prüfen'),
        (11, 2, 'Check new banknotes'),
        (12, 1, 'z.B. Z60162200226 / T003G1'),
        (12, 2, 'e.g. Z60162200226 / T003G1'),
        (13, 1, 'z.B. ND6617057128 / N022F6'),
        (13, 2, 'e.g. ND6617057128 / N022F6'),
        (14, 1, 'Sprache auswählen'),
        (14, 2, 'Select Language'),

        (20, 1, 'Seriennummer'),
        (20, 2, 'Serial number'),
        (21, 1, 'Plattencode'),
        (21, 2, 'Print office code'),
        (22, 1, 'Geldschein prüfen'),
        (22, 2, 'Check banknote'),
        (23, 1, 'Austellungsland'),
        (23, 2, 'Issuing country'),
        (24, 1, 'Druckerei'),
        (24, 2, 'Print office'),
        (25, 1, 'Druckerei & Austellungsland'),
        (25, 2, 'Print office & Issuing country'),
        (26, 1, 'Geldschein ist GÜLTIG'),
        (26, 2, 'Banknote is VALID'),

        (30, 1, 'Fehler'),
        (30, 2, 'Error'),
        (31, 1, 'Seriennummer hat falsches Format'),
        (31, 2, 'Serial number has wrong format'),
        (32, 1, 'Plattencode hat falsches Format'),
        (32, 2, 'Print office code has wrong format'),
        (33, 1, 'Seriennummer ist UNGÜLTIG'),
        (33, 2, 'Serial number is INVALID'),
        (34, 1, 'Plattencode ist UNGÜLTIG'),
        (34, 2, 'Print office code is UNGÜLTIG'),
        (35, 1, 'Seriennummer und Plattencode passen nicht zusammen'),
        (35, 2, 'Serial number and print office code do not match'),

        (40, 1, 'Warnung'),
        (40, 2, 'Warning'),
        (41, 1, 'Derzeit sind keine Geldscheine durch dieses Land / diese Druckerei im Umlauf'),
        (41, 2, 'Currently there are no banknotes in circulation by this country / print office');

