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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        string connectionString = "Data Source=localhost;Initial Catalog=[db];Integrated Security=True;";

        public bool CheckOldSerial(string serial)
        {
            if (serial.Length != 12)
            {
                // Serial length should be 12 characters
                return false;
            }

            char firstLetter = serial[0];
            int firstLetterValue = char.ToUpper(firstLetter) - 'A' + 1;

            int lastNumber = (int)char.GetNumericValue(serial[11]);

            if (firstLetterValue < 1 || firstLetterValue > 26)
            {
                // Invalid first letter
                return false;
            }

            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                char letter = serial[i];
                if (!char.IsDigit(letter))
                {
                    // Invalid character found
                    return false;
                }

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
            if (serial.Length != 12)
            {
                // Serial length should be 12 characters
                return false;
            }

            int firstLetterValue = char.ToUpper(serial[0]) - 'A' + 1;
            int secondLetterValue = char.ToUpper(serial[1]) - 'A' + 1;
            int lastNumber = (int)char.GetNumericValue(serial[11]);

            if (firstLetterValue < 1 || firstLetterValue > 26 || secondLetterValue < 1 || secondLetterValue > 26)
            {
                // Invalid first letter
                return false;
            }

            int sum = 0;
            for (int i = 2; i <= 10; i++)
            {
                char letter = serial[i];
                if (!char.IsDigit(letter))
                {
                    // Invalid character found
                    return false;
                }

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

        public string getCountry(string serial, string lang)
        {
            string query = "SELECT LCountries.name AS country FROM OldSeries JOIN Countries ON OldSeries.countryID = Countries.id JOIN LCountries ON Countries.id = LCountries.countryID JOIN Language ON LCountries.languageID = Language.languageID WHERE OldSeries.code = @Code AND Language.code = @Lang;";

            string message = "Error";

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

                        object result = command.ExecuteReader();

                        if (result != null)
                        {
                            message = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return message;
        }

        public string getNewPrintery(string serial, string lang)
        {
            string query = "SELECT EuropeSeries.printery AS printery_name, LCities.name AS city, LCountries.name AS country FROM EuropeSeries JOIN Cities ON EuropeSeries.cityID = Cities.id JOIN LCities ON Cities.id = LCities.cityID JOIN Countries ON EuropeSeries.countryID = Countries.id JOIN LCountries ON Countries.id = LCountries.countryID JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID WHERE EuropeSeries.code = @Code AND Language.code = @Lang;";

            string xmlMessage = string.Empty;

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
                            string printeryName = reader["printery_name"].ToString();
                            string city = reader["city"].ToString();
                            string country = reader["country"].ToString();

                            using (StringWriter stringWriter = new StringWriter())
                            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                            {
                                xmlWriter.WriteStartDocument();
                                xmlWriter.WriteStartElement("Printery");

                                xmlWriter.WriteStartElement("PrinteryName");
                                xmlWriter.WriteString(printeryName);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteStartElement("City");
                                xmlWriter.WriteString(city);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteStartElement("Country");
                                xmlWriter.WriteString(country);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteEndDocument();
                                xmlWriter.Flush();

                                xmlMessage = stringWriter.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return xmlMessage;
        }

        public string getOldPrintery(string serial, string lang)
        {
            string query = "SELECT Printery.name AS printery_name, LCities.name AS city, LCountries.name AS country FROM Printery JOIN Cities ON Printery.cityID = Cities.id JOIN LCities ON Cities.id = LCities.cityID JOIN Countries ON Printery.countryID = Countries.id JOIN LCountries ON Countries.id = LCountries.countryID JOIN Language ON LCities.languageID = Language.languageID AND LCountries.languageID = Language.languageID WHERE Printery.code = @Code AND Language.code = @Lang;";

            string xmlMessage = string.Empty;

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
                            string printeryName = reader["printery_name"].ToString();
                            string city = reader["city"].ToString();
                            string country = reader["country"].ToString();

                            using (StringWriter stringWriter = new StringWriter())
                            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                            {
                                xmlWriter.WriteStartDocument();
                                xmlWriter.WriteStartElement("Printery");

                                xmlWriter.WriteStartElement("PrinteryName");
                                xmlWriter.WriteString(printeryName);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteStartElement("City");
                                xmlWriter.WriteString(city);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteStartElement("Country");
                                xmlWriter.WriteString(country);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteEndDocument();
                                xmlWriter.Flush();

                                xmlMessage = stringWriter.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return xmlMessage;
        }

        public string getMessage(string desc, string lang)
        {
            string query = "SELECT text FROM LTexts " +
                           "JOIN Texts ON LTexts.textID = Texts.textID " +
                           "JOIN Language ON LTexts.languageID = Language.languageID " +
                           "WHERE Language.code = @Lang AND Texts.desc = @Desc;";

            string text = string.Empty;

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
                            text = reader["text"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return text;
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
