using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Msg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseManager databaseManager;
        List<Message> list;
        public MainWindow()
        {

            InitializeComponent();
            databaseManager = new DatabaseManager();
            list = new List<Message>();
            Task feachData = new Task(() => GetData());
            feachData.Start();
        }
        public void GetData()
        {
            while (true)
            {
                //Message m = list.Last();
                //databaseManager.GetMessages(m.Id);
                UpdateChat();
                Thread.Sleep(1000);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                string text = textbox.Text.ToString();
                Message m = new Message
                {
                    Msg = text
                };
                list.Add(m);
            }
        }
        public void UpdateChat() => Dispatcher.BeginInvoke(new Action(() => list.ForEach((m) => listView.Items.Add(m.Msg))));

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("Closing");
        }
    }
}
