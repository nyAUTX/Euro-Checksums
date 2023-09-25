﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EuroService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool CheckOldSerial(string serial);
        [OperationContract]
        bool CheckNewSerial(string serial);
        [OperationContract]
        bool CheckOldSerialFormat(string serial);
        [OperationContract]
        bool CheckNewSerialFormat(string serial);
        [OperationContract]
        bool CheckPrinteryFormat(string print);
        [OperationContract]
        string getCountry(string serial, string lang);
        [OperationContract]
        Printery getNewPrintery(string serial, string lang);
        [OperationContract]
        Printery getOldPrintery(string serial, string lang);
        [OperationContract]
        string getMessage(string serial, string lang);
        [OperationContract]
        Dictionary<string, string> GetAllLanguages();
    }

    [DataContract]
    public class Printery
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public bool Circulation { get; set; }
    }
}