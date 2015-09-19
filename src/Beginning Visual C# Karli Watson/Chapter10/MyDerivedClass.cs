using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class MyDerivedClass: MyClass
    {
        public override string GetString()
        {
            return base.GetString();
        }
    }
}
