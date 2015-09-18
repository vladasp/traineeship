using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    public class Person: DictionaryBase
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
        public static bool operator >=(Person persone1, Person persone2)
        {
            return (persone1.age >= persone2.age);
        }
        public static bool operator <(Person persone1, Person persone2)
        {
            return !(persone1 >= persone2);
        }
        public static bool operator <=(Person persone1, Person persone2)
        {
            return (persone1.age <= persone2.age);
        }
        public static bool operator >(Person persone1, Person persone2)
        {
            return !(persone1 <= persone2);
        }



    }
}
