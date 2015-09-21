using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    class MessageArrivedEventArgs: EventArgs
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }
        public MessageArrivedEventArgs()
        {
            message = "No message sent.";
            // Новых сообщений нет
        }
        public MessageArrivedEventArgs(string newMessage)
        {
            message = newMessage;
        }
    }
}
