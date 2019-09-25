using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistrationForm
{
    /// <summary>
    /// Interaction logic for MessageBoxShow.xaml
    /// </summary>
    public partial class MessageBoxShow : Window
    {
        public MessageBoxShow(string message)
        {
            InitializeComponent();
            string[] messages = message.Split(' ');
            int count = 0;
            string sumMessage = "";
            for (int i = 0; i < messages.Length; i++)
            {
                count += messages[i].Length;
                sumMessage += messages[i] + " ";
                if (count >= 20)
                {
                    sumMessage += "\n";
                    count = 0;
                }
            }
            TextBoxMessage.Text = sumMessage;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonHidden_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
