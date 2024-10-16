using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessanger
{
    public class Message
    {
        public string Text { get; set; }
        public User Sender { get; set; }
        public Message(string text, User sender)
        {
            Text = text;
            Sender = sender;
        }
    }

}
