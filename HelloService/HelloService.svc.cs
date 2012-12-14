using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "HelloService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez HelloService.svc ou HelloService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class HelloService : IHelloService
    {
        private static readonly List<Person> _persons= new List<Person>();
        
        public Person addPerson(string lastname, string firstname, PersonType type)
        {
            Person unePersonne = new Person
                {
                    Date = DateTime.Now,
                    LastName = lastname,
                    FirstName = firstname,
                    PersonType = type,
                    HasSubscribed = false
                };
            _persons.Add(unePersonne);
            return unePersonne;
        }
        public bool exists(string firstname, string lastname)
        {
            return _persons.Exists(model => model.FirstName.ToLowerInvariant() == firstname && model.LastName.ToLowerInvariant() == lastname);
        }
        /*Must change the boolean property of the Person in your list to true*/
        public bool Subscribe(Person p)
        {
            try
            {
                Person newPerson = _persons.Find(pe => pe.FirstName.ToLowerInvariant() == p.FirstName && pe.LastName.ToLowerInvariant() == p.LastName);
                if (newPerson==null)
                {
                    return false;
                }
                newPerson.HasSubscribed = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        /*Must return the list containing all Person objects*/
        public IEnumerable<Person> GetAllPersons()
        {
            return _persons;
        }
        /*Must return the number of employees’ subscriptions*/
        public int CountManagerSubscriptions()
        {
            return _persons.Count(p=>p.HasSubscribed&& p.PersonType==PersonType.Employee);
        }
        /*Must return the number of managers’ subscriptions*/
        public int CountEmployeeSubscriptions()
        {
            return _persons.Count(p => p.HasSubscribed && p.PersonType == PersonType.Manager);
        }

    }
}
