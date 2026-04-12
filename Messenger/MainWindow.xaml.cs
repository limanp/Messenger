using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();

            List<MessageData> items = new List<MessageData>();
            items.Add(new MessageData() { ContactName = "Pavlo", Text = "Hello!" });
            items.Add(new MessageData() { ContactName = "James", Text = "Hello, How are you?", Sender = MessageSender.Contact});
            items.Add(new MessageData() { ContactName = "Pavlo", Text = "Nice, and you?" });
          
            icMessageList.ItemsSource = items;
        }
        internal void InitializeMesseging()
        {
            
        }

    }
   
    internal enum MessageSender
    {
        Me, 
        Contact
    }
    internal class MessageData
    {

        public string ContactName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string AvatarPath { get; set; } = string.Empty;
        public MessageSender Sender { get; set; }
        public bool IsFromMe => Sender == MessageSender.Me; 
        
    }

}