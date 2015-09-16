using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class MyClass
    {
        private string myString = "\"Base class field\"";
        public string ContainedString
        {
            set { myString = value; }
        }
        public virtual string GetString()
        {
            return myString;
        }
    }
}
