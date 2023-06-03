using System;
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
        string getCountry(string serial, string lang);
        [OperationContract]
        string getNewPrintery(string serial, string lang);
        [OperationContract]
        string getOldPrintery(string serial, string lang);
        [OperationContract]
        string getMessage(string serial, string lang);
        [OperationContract]
        Dictionary<string, string> GetAllLanguages();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
