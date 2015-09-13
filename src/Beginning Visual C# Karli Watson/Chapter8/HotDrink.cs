using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter8
{
    abstract public class HotDrink
    {
        public int Milk
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Shugar
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void Drink()
        {
            throw new System.NotImplementedException();
        }

        public void AddMilk()
        {
            throw new System.NotImplementedException();
        }

        public void AddShugar()
        {
            throw new System.NotImplementedException();
        }
    }
}