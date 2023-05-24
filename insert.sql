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