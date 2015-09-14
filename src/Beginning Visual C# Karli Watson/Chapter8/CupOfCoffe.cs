using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter8
{
    public class CupOfCoffe : HotDrink, ICup
    {
        public int BeanType
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Color
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Volume
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Refill()
        {
            throw new NotImplementedException();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}