using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    public class MyCopyableClass: object
    {
        private string myTestField = "Base field";
        public string myPropertyField
        {
            get
            {
                return myTestField;
            }
            set
            {
                myTestField = value;
            }
        }
        public MyCopyableClass CloneClass()
        {
            return (MyCopyableClass)MemberwiseClone();
        }
    }
}
