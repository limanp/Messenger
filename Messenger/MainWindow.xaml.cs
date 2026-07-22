using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public Chat CurrentChat = new Chat("asdfasd");

        public MainWindow()
        {
            InitializeComponent();
            MessageData[] messagesOfITCommunity =
            {
                new MessageData("News", "SomeText", MessageSender.Contact),
                new MessageData("Bob", "SomeText", MessageSender.Contact),
                new MessageData("James", "SomeText", MessageSender.Contact),
                new MessageData("ProgrammingNews", "SomeText", MessageSender.Contact)
            };

            MessageData[] messagesOfTechNews =
            {
                new MessageData("TechNews", "New iphone implement AI in own OS", MessageSender.Contact)
            };

            ObservableCollection<Chat> Chats = new ObservableCollection<Chat>
            {
                new Chat ("TechNews", messagesOfTechNews),
                new Chat ("ITCommunity", messagesOfITCommunity)
            };

            // Connected collection with xaml elemenents 
            ChatMassageHistory.ItemsSource = CurrentChat.Messages;

            ChatList.ItemsSource = Chats; 
        }


        private void Send_Message(object sender, RoutedEventArgs e)
        {
            var text = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                MessageData message = new MessageData("Pavlo", text, MessageSender.Me);
                CurrentChat.Messages.Add(message);

                MessageTextBox.Clear();
            }

        }
    }

    public class Chat : INotifyPropertyChanged
    {
        public Chat(string name)
        {
            Name = name;         
        }
        public Chat(string name, MessageData[] messages)
        {
            Name = name;
            foreach (MessageData message in messages)
            {
                Messages.Add(message);
            }
        }
        public Chat(MessageData[] messages)
        {
            foreach (MessageData message in messages)
            {
                Messages.Add(message);
            }
        }
        public ObservableCollection<MessageData> Messages { get; set; } = new ObservableCollection<MessageData>();
        public string Name { get; set; }
        public string LastMessage()
        {
            return Messages[^1].Text; 
        }

        //private object _currentChat;
        //public object CurrentChat
        //{
        //    get => _currentChat;
        //    set { _currentChat = value; OnPropertyChanged(); }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        // protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 

    }

    public enum MessageSender // Визначає, хто є відправником повідомлення
    {
        Me,
        Contact
    }
    public class MessageData // Клас для зберігання даних про повідомлення 
    {

        public MessageData(string contactName, string text, MessageSender sender)
        {
            ContactName = contactName;
            Text = text;
            Sender = sender;
        }
        public string ContactName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string AvatarPath { get; set; } = string.Empty;
        public MessageSender Sender { get; set; }
        public bool IsFromMe => Sender == MessageSender.Me;

    }
}