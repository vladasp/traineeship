using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    public class People: DictionaryBase, ICloneable, IEnumerable
    {
        Person person = new Person();
        public People()
        {

        }
        private People(Person persons)
        {
             person = persons;
        }

        public List<Person> GetOldest()
        {
            List<Person> oldestPersonList = new List<Person>();
            foreach (DictionaryEntry item in Dictionary)    
            {
                if (oldestPersonList.Count == 0)
                {
                    oldestPersonList.Add((Person)item.Value);
                }
                else if ((Person)item.Value >= oldestPersonList[0])
                {
                    if ((Person)item.Value >= oldestPersonList[0] && (Person)item.Value <= oldestPersonList[0])
                    {
                        oldestPersonList.Add((Person)item.Value);
                    }
                    else
                    {
                        oldestPersonList.Clear();
                        oldestPersonList.Add((Person)item.Value);
                    }
                }
            }
            Console.WriteLine("Oldes persons are:");
            foreach (Person p in oldestPersonList)
            {
                Console.WriteLine("Name {0} Age {1}", p.Name, p.Age);
            }
            return oldestPersonList;
        }

        public void Add(string idName, Person myPerson)
        {
            Dictionary.Add(idName, myPerson);
        }

        public object Clone()
        {
            People people = new People(person.Clone() as Person);
            return people;
        }
        public IEnumerable Ages
        {
            get
            {
                foreach (object person in Dictionary.Values)
                    yield return (person as Person).Age;
            }
        }
    }
}
