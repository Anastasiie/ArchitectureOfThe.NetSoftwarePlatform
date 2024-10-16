using ConsoleMessanger;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("Alice");
        User user2 = new User("Bob");
        Messenger messenger = new Messenger();

        messenger.SendMessage(user1, "Hi, Bob!");
        messenger.SendMessage(user2, "Hello, Alice!");

        messenger.ShowMessages();
    }
}
