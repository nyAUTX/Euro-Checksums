DROP TABLE IF EXISTS EuropeSeries;
DROP TABLE IF EXISTS OldSeries;
DROP TABLE IF EXISTS Printery;

CREATE TABLE EuropeSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, printery varchar(255) NOT NULL, country varchar(255) NOT NULL, city varchar(255) NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));
CREATE TABLE OldSeries (id int IDENTITY NOT NULL, code char(1) NOT NULL, country varchar(255) NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));
CREATE TABLE Printery (id int IDENTITY NOT NULL, code char(1) NOT NULL, name varchar(255) NOT NULL, country varchar(255) NOT NULL, city varchar(255) NOT NULL, circulation bit NOT NULL, PRIMARY KEY (id));