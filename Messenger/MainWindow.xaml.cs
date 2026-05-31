using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Chat chat = new Chat();
        public MainWindow()
        {
            InitializeComponent();
            messageList.ItemsSource = chat.Messages; 
        }
     

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            var text = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                MessageData message = new MessageData() { ContactName = "Pavlo", Text = text };
                chat.Messages.Add(message); 
             
                MessageTextBox.Clear();
            }
            
        }
    }

    public class Chat : INotifyPropertyChanged
    {
        public ObservableCollection<MessageData> Messages { get; set; } = new ObservableCollection<MessageData>();

        private object _currentChat;
        public object CurrentChat
        {
            get => _currentChat;
            set { _currentChat = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler? PropertyChanged; 

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 

    }

    public enum MessageSender // Визначає, хто є відправником повідомлення
    {
        Me, 
        Contact
    }
    public class MessageData // Клас для зберігання даних про повідомлення 
    {

        public string ContactName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string AvatarPath { get; set; } = string.Empty;
        public MessageSender Sender { get; set; }
        public bool IsFromMe => Sender == MessageSender.Me; 
        
    }
}