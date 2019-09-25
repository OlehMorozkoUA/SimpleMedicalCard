using MaterialDesignThemes.Wpf;
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
using Microsoft.Win32;
using System.IO;

namespace RegistrationForm
{
    /// <summary>
    /// Interaction logic for Registrate.xaml
    /// </summary>
    public partial class Registrate : Window
    {
        StudentDataBase db = new StudentDataBase();
        Student student;
        byte[] img;
        string path = null;

        public Registrate()
        {
            InitializeComponent();
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

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBrowse.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                path = openFileDialog.FileName;
            }
        }

        private void ButtonRegistrate_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxFN != null && TextBoxLN != null && TextBoxP1.Password != null && TextBoxP2.Password != null)
            {
                if(TextBoxP1.Password == TextBoxP2.Password)
                {
                    img = null;
                    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    img = binaryReader.ReadBytes((int)fileStream.Length);
                    student = new Student()
                    {
                        FirstName = TextBoxFN.Text,
                        LastName = TextBoxLN.Text,
                        Password = TextBoxP1.Password,
                        Photo = img
                    };
                    db.Students.Add(student);
                    db.SaveChanges();

                    TextBoxFN.Text = "";
                    TextBoxLN.Text = "";
                    TextBoxP1.Password = "";
                    TextBoxP2.Password = "";

                    ImageBrowse.Source = null;
                }
                else
                {
                    MessageBoxShow messageBoxShow = new MessageBoxShow("Password must be equal to Password*!!!");
                    messageBoxShow.ShowDialog();
                }
            }
            else
            {
                MessageBoxShow messageBoxShow = new MessageBoxShow("Enter all fields!!!");
                messageBoxShow.ShowDialog();
            }
        }
    }
}
