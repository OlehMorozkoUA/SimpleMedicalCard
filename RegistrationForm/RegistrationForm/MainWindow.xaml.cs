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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistrationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentDataBase db = new StudentDataBase();
        Student student;
        bool isExist = false;
        public MainWindow()
        {
            InitializeComponent();
            TextBoxFN.Text = "Oleh";
            TextBoxLN.Text = "Morozko";
            TextBoxP1.Password = "40432432";
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ButtonHidden_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxFN.Text != string.Empty && TextBoxLN.Text != string.Empty && TextBoxP1.Password != string.Empty)
                {
                    foreach (Student s in db.Students)
                    {
                        if (TextBoxFN.Text == s.FirstName && TextBoxLN.Text == s.LastName && TextBoxP1.Password == s.Password)
                        {
                            student = s;
                            isExist = true;
                            break;
                        }
                    }
                    if (isExist)
                    {
                        MessageBoxShow messageBoxShow = new MessageBoxShow("Hello, " + student.FirstName + " " + student.LastName);
                        messageBoxShow.ShowDialog();
                        LogIn logIn = new LogIn(student);
                        logIn.ShowDialog();

                        isExist = false;
                        student = null;
                        TextBoxFN.Text = string.Empty;
                        TextBoxLN.Text = string.Empty;
                        TextBoxP1.Password = string.Empty;
                    }
                    else
                    {
                        MessageBoxShow messageBoxShow = new MessageBoxShow("This account is not exist!!!");
                        messageBoxShow.ShowDialog();
                    }
                }
                else
                {
                    MessageBoxShow messageBoxShow = new MessageBoxShow("Write down all blank!!!");
                    messageBoxShow.ShowDialog();
                }
            }
            catch(Exception)
            {
                MessageBoxShow messageBoxShow = new MessageBoxShow("Authorization error!!!");
                messageBoxShow.ShowDialog();
            }
        }

        private void ButtonRegistrate_Click(object sender, RoutedEventArgs e)
        {
            Registrate registrate = new Registrate();
            registrate.ShowDialog();
        }
    }
}
