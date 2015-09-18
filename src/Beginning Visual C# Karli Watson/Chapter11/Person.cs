using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    public class Person: DictionaryBase, ICloneable
    {
        private string name;
        private int age;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public Person()
        {
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Add (string idName, Person myPerson)
        {
            Dictionary.Add(idName, myPerson);
        }
        public Person this[string name]
        {
            get
            {
                return (Person)Dictionary[name];
            }
            set
            {
                Dictionary[name] = value;
            }

        }
        public Person this[int idPerson]
        {
            get
            {
                return (Person)Dictionary[idPerson];
            }
            set
            {
                Dictionary[idPerson] = value;
            }

        }
        public static bool operator >=(Person person1, Person person2)
        {
            return (person1.age >= person2.age);
        }
        public static bool operator <(Person person1, Person person2)
        {
            return !(person1 >= person2);
        }
        public static bool operator <=(Person person1, Person person2)
        {
            return (person1.age <= person2.age);
        }
        public static bool operator >(Person person1, Person person2)
        {
            return !(person1.age <= person2.age);
        }
        public object Clone()
        {
            Person person = new Person();
            return person;
        }
    }
}
