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

        // Додавання повідомлення
        public void SendMessage(User sender, string text)
        {
            Message message = new Message(text, sender);
            _messages.Add(message);
        }

        // Видалення повідомлення за індексом
        public void DeleteMessage(int index)
        {
            if (index >= 0 && index < _messages.Count)
            {
                _messages.RemoveAt(index);
                Console.WriteLine("Повідомлення успішно видалено.");
            }
            else
            {
                Console.WriteLine("Невірний індекс.");
            }
        }

        // Оновлення повідомлення за індексом
        public void UpdateMessage(int index, string newText)
        {
            if (index >= 0 && index < _messages.Count)
            {
                _messages[index].Text = newText;
                Console.WriteLine("Повідомлення оновлено.");
            }
            else
            {
                Console.WriteLine("Невірний індекс.");
            }
        }

        // Виведення всіх повідомлень
        public void ShowMessages()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║ Повідомлення у чаті:                              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");

            for (int i = 0; i < _messages.Count; i++)
            {
                var message = _messages[i];
                Console.WriteLine($"[{i}] {message}");
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

            // Додавання повідомлень
            messenger.SendMessage(user1, "Привіт, Марк!");
            messenger.SendMessage(user2, "Привіт, Еммі!");

            // Виведення повідомлень
            messenger.ShowMessages();

            // Оновлення та видалення повідомлень
            messenger.UpdateMessage(0, "Привіт ще раз, Марк!");
            messenger.DeleteMessage(1);

            // Виведення оновлених повідомлень
            messenger.ShowMessages();

            Console.ReadLine(); // Щоб програма не закривалась одразу
        }
    }
}
