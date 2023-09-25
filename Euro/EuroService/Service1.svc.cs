﻿using System;
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

        string connectionString = "Data Source=localhost;Initial Catalog=Euro;Integrated Security=True;";
        
        public bool CheckOldSerial(string serial)
        {
            if (!CheckOldSerialFormat(serial))
            {
                return false;
            }

            char firstLetter = serial[0];
            int firstLetterValue = char.ToUpper(firstLetter) - 'A' + 1;

            int lastNumber = (int)char.GetNumericValue(serial[11]);

            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                char letter = serial[i];

                sum += (int)char.GetNumericValue(letter);
            }

            sum += firstLetterValue;
            
            int checksum = 8 - sum % 9;

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

            int firstLetterValue = char.ToUpper(serial[0]) - 'A' + 1;
            int secondLetterValue = char.ToUpper(serial[1]) - 'A' + 1;
            int lastNumber = (int)char.GetNumericValue(serial[11]);

            int sum = 0;
            for (int i = 2; i <= 10; i++)
            {
                char letter = serial[i];

                sum += (int)char.GetNumericValue(letter);
            }

            sum += firstLetterValue + secondLetterValue;

            int checksum = 7 - sum % 9;

            if (checksum == 0 && lastNumber == 9 || checksum == -1 && lastNumber == 8)
            {
                return true;
            }
            
            return checksum == lastNumber;
        }
        
        // Check Formats
        public bool CheckOldSerialFormat(string serial)
        {
            if (serial.Length != 12
                || int.TryParse(serial[0].ToString(), out _)
                || !long.TryParse(serial.Substring(1), out _))
            {
                return false;
            }
            return true;
        }
        
        public bool CheckNewSerialFormat(string serial)
        {
            if (serial.Length != 12
                || int.TryParse(serial[0].ToString(), out _)
                || int.TryParse(serial[1].ToString(), out _)
                || !long.TryParse(serial.Substring(2), out _))
            {
                return false;
            }
            return true;
        }
        
        public bool CheckPrinteryFormat(string print)
        {
            if (print.Length != 6
               || int.TryParse(print[0].ToString(), out _))
            {
                return false;
            }
            return true;
        }

        // Get data
        public string getCountry(string serial, string lang)
        {
            string query = 
                "SELECT LCountries.name AS country FROM OldSeries " +
                "JOIN Countries ON OldSeries.countryID = Countries.id " +
                "JOIN LCountries ON Countries.id = LCountries.countryID " +
                "JOIN Language ON LCountries.languageID = Language.languageID " +
                "WHERE OldSeries.code = @Code AND Language.code = @Lang;";

            // Create a new SqlConnection and SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Code", serial[0]);
                        command.Parameters.AddWithValue("@Lang", lang);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader["country"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return null;
        }
        
        public Printery getNewPrintery(string serial, string lang)
        {
            Printery printery = new Printery();
            
            string query = 
                "SELECT EuropeSeries.printery AS printery_name, LCities.name AS city, LCountries.name AS country, EuropeSeries.circulation FROM EuropeSeries " +
                "JOIN Cities ON EuropeSeries.cityID = Cities.id " +
                "JOIN LCities ON Cities.id = LCities.cityID " +
                "JOIN Countries ON EuropeSeries.countryID = Countries.id " +
                "JOIN LCountries ON Countries.id = LCountries.countryID " +
                "JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID " +
                "WHERE EuropeSeries.code = @Code AND Language.code = @Lang;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Code", serial[0]);
                        command.Parameters.AddWithValue("@Lang", lang);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        
                        if (reader.Read())
                        {
                            printery.Name = reader["printery_name"].ToString();
                            printery.City = reader["city"].ToString();
                            printery.Country = reader["country"].ToString();
                            printery.Circulation = Convert.ToBoolean(int.Parse(reader["circulation"].ToString()));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return printery;
        }

        public Printery getOldPrintery(string serial, string lang)
        {
            Printery printery = new Printery();
            
            string query = 
                "SELECT Printery.name AS printery_name, LCities.name AS city, LCountries.name AS country, Printery.circulation FROM Printery " +
                "JOIN Cities ON Printery.cityID = Cities.id " +
                "JOIN LCities ON Cities.id = LCities.cityID " +
                "JOIN Countries ON Printery.countryID = Countries.id " +
                "JOIN LCountries ON Countries.id = LCountries.countryID " +
                "JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID " +
                "WHERE Printery.code = @Code AND Language.code = @Lang;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Code", serial[0]);
                        command.Parameters.AddWithValue("@Lang", lang);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            printery.Name = reader["printery_name"].ToString();
                            printery.City = reader["city"].ToString();
                            printery.Country = reader["country"].ToString();
                            printery.Circulation = Convert.ToBoolean(int.Parse(reader["circulation"].ToString()));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return printery;
        }

        public string getMessage(string desc, string lang)
        {
            string query = 
                "SELECT text FROM LTexts " +
                "JOIN Texts ON LTexts.textID = Texts.textID " +
                "JOIN Language ON LTexts.languageID = Language.languageID " +
                "WHERE Language.code = @Lang AND Texts.[desc] = @Desc;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Lang", lang);
                        command.Parameters.AddWithValue("@Desc", desc);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return reader["text"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return null;
        }

        public Dictionary<string, string> GetAllLanguages()
        {
            string query = "SELECT code, name FROM Language;";

            Dictionary<string, string> languages = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string code = reader["code"].ToString();
                            string name = reader["name"].ToString();
                            languages.Add(code, name);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return languages;
        }

    }
}