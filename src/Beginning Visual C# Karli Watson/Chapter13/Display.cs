using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    public class Display
    {
        public void DisplayMessage(object message, EventArgs e)
        {
            Console.WriteLine("Argument: {0}", e);
            Console.WriteLine("Message arrived: {0}", message.ToString());
        }
    }
}
