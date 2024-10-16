using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessanger
{
    public class Messenger
    {
        public List<Message> Messages = new List<Message>();
        public void SendMessage(User sender, string text)
        {
            Messages.Add(new Message(text, sender));
        }
        public void ShowMessages()
        {
            foreach (var message in Messages)
            {
                Console.WriteLine($"{message.Sender.Username}: {message.Text}");
            }
        }
    }

}
