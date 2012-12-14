using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IHelloService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Person addPerson(string lastname, string firstname, PersonType type);

        [OperationContract]
        bool exists(string firstname, string lastname);

        [OperationContract]
        bool Subscribe(Person p);

        [OperationContract]
        IEnumerable<Person> GetAllPersons();

        [OperationContract]
        int CountManagerSubscriptions();

        [OperationContract]
        int CountEmployeeSubscriptions();
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public bool HasSubscribed { get; set; }

        [DataMember]
        public PersonType PersonType { get; set; }
    }

    public enum PersonType{ Employee,Manager} ;
}
