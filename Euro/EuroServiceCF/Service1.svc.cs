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

namespace EuroServiceCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly EuroContext db = new EuroContext();

        public bool CheckNewSerial(string serial)
        {
            throw new NotImplementedException();
        }

        public bool CheckNewSerialFormat(string serial)
        {
            throw new NotImplementedException();
        }

        public bool CheckOldSerial(string serial)
        {
            throw new NotImplementedException();
        }

        public bool CheckOldSerialFormat(string serial)
        {
            throw new NotImplementedException();
        }

        public bool CheckPrinteryFormat(string print)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetAllLanguages()
        {
            throw new NotImplementedException();
        }

        public string getCountry(string serial, string lang)
        {
            throw new NotImplementedException();
        }

        public string getMessage(string serial, string lang)
        {
            throw new NotImplementedException();
        }

        public PrinteryData getNewPrintery(string serial, string lang)
        {
            throw new NotImplementedException();
        }

        public PrinteryData getOldPrintery(string serial, string lang)
        {
            throw new NotImplementedException();
        }
    }
}
