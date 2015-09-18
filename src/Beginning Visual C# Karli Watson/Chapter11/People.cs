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
        public List<Person> GetOldest(Person person)
        {
            List<Person> oldestPersonList = new List<Person>();
            for (int i = 0; i < person.Count; i++)
            {
                for (int j = i + 1; j < person.Count; j++)
                {
                    if (person[i] < person[j])
                    {
                        var oldPerson = person[j];
                        var youngPerson = person[i];
                        person[i] = oldPerson;
                        person[j] = youngPerson;
                    }
                }
            }
            Console.WriteLine(person);
            return oldestPersonList;
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
