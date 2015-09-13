using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter8
{
    public interface ICup
    {
        int Color { get; set; }
        int Volume { get; set; }

        void Refill();
        void Wash();
    }
}