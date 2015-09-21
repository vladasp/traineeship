using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    public delegate void MessageHandler(Connection source, EventArgs e);
    public class Connection
    {
        public event MessageHandler MessageArrived;
        private Timer pollTimer;
        public Connection()
        {
            pollTimer = new Timer(1000);
            pollTimer.Elapsed += CheckForMessage;
        }
        public void Connect()
        {
            pollTimer.Start();
        }
        public void Disconnect()
        {
            pollTimer.Stop();
        }
        private static Random random = new Random();
        private void CheckForMessage(object source, EventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            Console.WriteLine("Argument: {0}", e);
            if ((random.Next(9) == 0) && (MessageArrived != null))
            {
                MessageArrived(this, new MessageArrivedEventArgs("Hello Mum!"));
            }
        }
    }
}
