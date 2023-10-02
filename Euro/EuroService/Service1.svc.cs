using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace EuroService
{
    public class Service1 : IService1
    {
        private readonly EuroEntities _db = new EuroEntities();

        #region SerialCheck
        public bool CheckOldSerial(string serial)
        {
            if (!CheckOldSerialFormat(serial))
            {
                return false;
            }

            var firstLetter = serial[0];
            var firstLetterValue = char.ToUpper(firstLetter) - 'A' + 1;

            var lastNumber = (int)char.GetNumericValue(serial[11]);

            var sum = 0;
            for (var i = 1; i <= 10; i++)
            {
                var letter = serial[i];

                sum += (int)char.GetNumericValue(letter);
            }

            sum += firstLetterValue;

            var checksum = 8 - sum % 9;

            if (checksum == 0 && lastNumber == 9)
            {
                return true;
            }

            return checksum == lastNumber;
        }


        public bool CheckNewSerial(string serial)
        {
            if (!CheckNewSerialFormat(serial))
            {
                return false;
            }

            var firstLetterValue = char.ToUpper(serial[0]) - 'A' + 1;
            var secondLetterValue = char.ToUpper(serial[1]) - 'A' + 1;
            var lastNumber = (int)char.GetNumericValue(serial[11]);

            var sum = 0;
            for (var i = 2; i <= 10; i++)
            {
                var letter = serial[i];

                sum += (int)char.GetNumericValue(letter);
            }

            sum += firstLetterValue + secondLetterValue;

            var checksum = 7 - sum % 9;

            if (checksum == 0 && lastNumber == 9 || checksum == -1 && lastNumber == 8)
            {
                return true;
            }

            return checksum == lastNumber;
        }
        #endregion

        #region CheckFormats
        public bool CheckOldSerialFormat(string serial)
        {
            return serial.Length == 12
                   && !int.TryParse(serial[0].ToString(), out _)
                   && long.TryParse(serial.Substring(1), out _);
        }

        public bool CheckNewSerialFormat(string serial)
        {
            return serial.Length == 12
                   && !int.TryParse(serial[0].ToString(), out _)
                   && !int.TryParse(serial[1].ToString(), out _)
                   && long.TryParse(serial.Substring(2), out _);
        }

        public bool CheckPrinteryFormat(string print)
        {
            return print.Length == 6
                   && !int.TryParse(print[0].ToString(), out _);
        }
        #endregion

        #region Data
        public string getCountry(string serial, string lang)
        {
            var serialCode = serial[0].ToString();

            var query = from oldSeries in _db.OldSeries
                        join countries in _db.Countries on oldSeries.countryID equals countries.id
                        join lCountries in _db.LCountries on countries.id equals lCountries.countryID
                        join language in _db.Languages on lCountries.languageID equals language.languageID
                        where oldSeries.code == serialCode && language.code == lang
                        select new
                        {
                            country = lCountries.name
                        };

            var country = query.SingleOrDefault();
            return country?.country;

            /*
                "SELECT LCountries.name AS country FROM OldSeries " +
               "JOIN Countries ON OldSeries.countryID = Countries.id " +
               "JOIN LCountries ON Countries.id = LCountries.countryID " +
               "JOIN Language ON LCountries.languageID = Language.languageID " +
               "WHERE OldSeries.code = @Code AND Language.code = @Lang;";
            */
        }


        public PrinteryData getNewPrintery(string serial, string lang)
        {
            var printeryData = new PrinteryData();

            var serialCode = serial[0].ToString();

            var query = from europeSeries in _db.EuropeSeries
                        join cities in _db.Cities on europeSeries.cityID equals cities.id
                        join lCities in _db.LCities on cities.id equals lCities.cityID
                        join countries in _db.Countries on europeSeries.countryID equals countries.id
                        join lCountries in _db.LCountries on countries.id equals lCountries.countryID
                        join language in _db.Languages on lCities.languageID equals language.languageID
                        where europeSeries.code == serialCode && language.code == lang
                        select new
                        {
                            printery_name = europeSeries.printery,
                            city = lCities.name,
                            country = lCountries.name,
                            europeSeries.circulation
                        };

            var result = query.FirstOrDefault();

            if (result == null) return printeryData;

            printeryData.Name = result.printery_name;
            printeryData.City = result.city;
            printeryData.Country = result.country;
            printeryData.Circulation = Convert.ToBoolean(result.circulation);

            return printeryData;

            /*
                "SELECT EuropeSeries.printery AS printery_name, LCities.name AS city, LCountries.name AS country, EuropeSeries.circulation FROM EuropeSeries " +
                "JOIN Cities ON EuropeSeries.cityID = Cities.id " +
                "JOIN LCities ON Cities.id = LCities.cityID " +
                "JOIN Countries ON EuropeSeries.countryID = Countries.id " +
                "JOIN LCountries ON Countries.id = LCountries.countryID " +
                "JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID " +
                "WHERE EuropeSeries.code = @Code AND Language.code = @Lang;";
            */
        }

        public PrinteryData getOldPrintery(string serial, string lang)
        {
            var printeryData = new PrinteryData();

            var serialCode = serial[0].ToString();

            var query = from printery in _db.Printeries
                        join cities in _db.Cities on printery.cityID equals cities.id
                        join lCities in _db.LCities on cities.id equals lCities.cityID
                        join countries in _db.Countries on printery.countryID equals countries.id
                        join lCountries in _db.LCountries on countries.id equals lCountries.countryID
                        join language in _db.Languages on lCities.languageID equals language.languageID
                        where printery.code == serialCode && language.code == lang
                        select new
                        {
                            printery_name = printery.name,
                            city = lCities.name,
                            country = lCountries.name,
                            printery.circulation
                        };

            var result = query.FirstOrDefault();

            if (result == null) return printeryData;

            printeryData.Name = result.printery_name;
            printeryData.City = result.city;
            printeryData.Country = result.country;
            printeryData.Circulation = Convert.ToBoolean(result.circulation);

            return printeryData;

            /*
                "SELECT Printery.name AS printery_name, LCities.name AS city, LCountries.name AS country, Printery.circulation FROM Printery " +
                "JOIN Cities ON Printery.cityID = Cities.id " +
                "JOIN LCities ON Cities.id = LCities.cityID " +
                "JOIN Countries ON Printery.countryID = Countries.id " +
                "JOIN LCountries ON Countries.id = LCountries.countryID " +
                "JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID " +
                "WHERE Printery.code = @Code AND Language.code = @Lang;";
            */
        }


        public string getMessage(string desc, string lang)
        {
            var query = from lText in _db.LTexts
                        join text in _db.Texts on lText.textID equals text.textID
                        join language in _db.Languages on lText.languageID equals language.languageID
                        where language.code == lang && text.desc == desc
                        select lText.text;

            return query.FirstOrDefault();

            /*
                "SELECT text FROM LTexts " +
                "JOIN Texts ON LTexts.textID = Texts.textID " +
                "JOIN Language ON LTexts.languageID = Language.languageID " +
                "WHERE Language.code = @Lang AND Texts.[desc] = @Desc;";
            */
        }
        public Dictionary<string, string> GetAllLanguages()
        {
            return _db.Languages.ToDictionary(language => language.code, language => language.name);
        }
        #endregion

    }
}
