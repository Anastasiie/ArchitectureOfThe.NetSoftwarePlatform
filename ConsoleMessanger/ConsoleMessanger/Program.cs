using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMessenger
{
    // Клас для збереження інформації про користувача
    public class User
    {
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }

    // Клас для повідомлень
    public class Message
    {
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime Timestamp { get; set; }

        public Message(string text, User sender)
        {
            Text = text;
            Sender = sender;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Timestamp.ToShortTimeString()} {Sender.Username}: {Text}";
        }
    }

    // Клас для управління повідомленнями
    public class Messenger
    {
        private List<Message> _messages = new List<Message>();

        public void SendMessage(User sender, string text)
        {
            Message message = new Message(text, sender);
            _messages.Add(message);
        }
        public void ShowMessages()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║ Повідомлення у чаті:                              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");

            foreach (var message in _messages)
            {
                Console.Write($"║ ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"{message.Sender.Username.PadRight(12)}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" | {message.Timestamp.ToShortTimeString()} |");
                Console.ResetColor();


                 Console.WriteLine($"║ {message.Text}                                     ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення користувачів
            User user1 = new User("Emmy");
            User user2 = new User("Mark");

            // Створення об'єкта месенджера
            Messenger messenger = new Messenger();

            // Відправлення повідомлень
            messenger.SendMessage(user1, "Привіт, Марк!");
            messenger.SendMessage(user2, "Привіт, Еммі!");

            // Виведення повідомлень
            messenger.ShowMessages();

            Console.ReadLine(); // Щоб програма не закривалась одразу
        }
    }
}
