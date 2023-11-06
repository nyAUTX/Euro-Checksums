using EuroServiceCF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EuroService;
using Language = EuroService.Language;

namespace EuroServiceCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly EuroContext _db = new EuroContext();

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

        public Dictionary<string, string> GetAllLanguages()
        {
            return _db.Languages.ToDictionary(language => language.Code, language => language.Name);
        }

        public string getCountry(string serial, string lang)
        {
            var serialCode = serial[0].ToString();

            var query = from oldSeries in _db.OldSeries
                join countries in _db.Countries on oldSeries.CountryId equals countries.Id
                join lCountries in _db.LCountries on countries.Id equals lCountries.CountryId
                join language in _db.Languages on lCountries.LanguageId equals language.LanguageId
                where oldSeries.Code == serialCode && language.Code == lang
                select new
                {
                    country = lCountries.Name
                };

            var country = query.SingleOrDefault();
            return country?.country;
        }

        public string getMessage(string desc, string lang)
        {
            var query = from lText in _db.LTexts
                join text in _db.Texts on lText.TextId equals text.TextId
                join language in _db.Languages on lText.LanguageId equals language.LanguageId
                where language.Code == lang && text.Desc == desc
                select lText.Text;

            return query.FirstOrDefault();
        }

        public PrinteryData getNewPrintery(string serial, string lang)
        {
            var printeryData = new PrinteryData();

            var serialCode = serial[0].ToString();

            var query = from europeSeries in _db.EuropeSeries
                join cities in _db.Cities on europeSeries.CityId equals cities.Id
                join lCities in _db.LCities on cities.Id equals lCities.CityId
                join countries in _db.Countries on europeSeries.CountryId equals countries.Id
                join lCountries in _db.LCountries on countries.Id equals lCountries.CountryId
                join languageCities in _db.Languages on lCities.LanguageId equals languageCities.LanguageId
                join languageCountries in _db.Languages on lCountries.LanguageId equals languageCountries.LanguageId
                where europeSeries.Code == serialCode && languageCities.Code == lang && languageCountries.Code == lang
                select new
                {
                    printery_name = europeSeries.Printery,
                    city = lCities.Name,
                    country = lCountries.Name,
                    europeSeries.Circulation
                };

            var result = query.FirstOrDefault();

            if (result == null) return printeryData;

            printeryData.Name = result.printery_name;
            printeryData.City = result.city;
            printeryData.Country = result.country;
            printeryData.Circulation = Convert.ToBoolean(result.Circulation);

            return printeryData;
        }

        public PrinteryData getOldPrintery(string serial, string lang)
        {
            var printeryData = new PrinteryData();

            var serialCode = serial[0].ToString();

            var query = from printery in _db.Printeries
                join cities in _db.Cities on printery.CityId equals cities.Id
                join lCities in _db.LCities on cities.Id equals lCities.CityId
                join countries in _db.Countries on printery.CountryId equals countries.Id
                join lCountries in _db.LCountries on countries.Id equals lCountries.CountryId
                join languageCities in _db.Languages on lCities.LanguageId equals languageCities.LanguageId
                join languageCountries in _db.Languages on lCountries.LanguageId equals languageCountries.LanguageId
                        where printery.Code == serialCode && languageCities.Code == lang && languageCountries.Code == lang
                        select new
                {
                    printery_name = printery.Name,
                    city = lCities.Name,
                    country = lCountries.Name,
                    printery.Circulation
                };

            var result = query.FirstOrDefault();

            if (result == null) return printeryData;

            printeryData.Name = result.printery_name;
            printeryData.City = result.city;
            printeryData.Country = result.country;
            printeryData.Circulation = Convert.ToBoolean(result.Circulation);

            return printeryData;
        }

        #endregion
        
    }
}