using System;
using System.Collections.Generic;
using System.IO;
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

namespace RegistrationForm
{
    public partial class LogIn : Window
    {
        StudentDataBase db = new StudentDataBase();
        Student student;
        byte[] img;
        string path = null;

        private bool isClicked = false;
        public LogIn(Student student)
        {
            InitializeComponent();
            TextBoxFN.IsEnabled = false;
            TextBoxLN.IsEnabled = false;
            TextBoxPhone.IsEnabled = false;
            TextBoxEmail.IsEnabled = false;
            TextBoxAddress.IsEnabled = false;

            ButtonBrowse.Visibility = Visibility.Hidden;
            labelBrowse1.Visibility = Visibility.Hidden;
            labelBrowse2.Visibility = Visibility.Hidden;

            TextBoxFN.Text = student.FirstName;
            TextBoxLN.Text = student.LastName;
            TextBoxPhone.Text = student.Phone;
            TextBoxEmail.Text = student.Email;
            TextBoxAddress.Text = student.Address;

            ImageBrowse.Source = ToImage(student.Photo);
            this.student = student;
            HeaderText.Text = student.FirstName + " " + student.LastName;
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

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(isClicked)
            {
                TextBoxFN.IsEnabled = false;
                TextBoxLN.IsEnabled = false;
                TextBoxPhone.IsEnabled = false;
                TextBoxEmail.IsEnabled = false;
                TextBoxAddress.IsEnabled = false;

                ButtonBrowse.Visibility = Visibility.Hidden;
                labelBrowse1.Visibility = Visibility.Hidden;
                labelBrowse2.Visibility = Visibility.Hidden;

                student.FirstName = TextBoxFN.Text;
                student.LastName = TextBoxLN.Text;
                student.Phone = TextBoxPhone.Text;
                student.Email = TextBoxEmail.Text;
                student.Address = TextBoxAddress.Text;
                HeaderText.Text = student.FirstName + " " + student.LastName;
                if (path != null)
                {
                    img = null;
                    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    img = binaryReader.ReadBytes((int)fileStream.Length);
                    student.Photo = img;
                }
                foreach(Student s in db.Students)
                {
                    if (student.Id == s.Id)
                    {
                        s.FirstName = student.FirstName;
                        s.LastName = student.LastName;
                        s.Phone = student.Phone;
                        s.Email = student.Email;
                        s.Address = student.Address;
                        if (path != null)
                        {
                            s.Photo = student.Photo;
                        }
                    }
                }
                db.SaveChanges();
            }
            else
            {
                TextBoxFN.IsEnabled = true;
                TextBoxLN.IsEnabled = true;
                TextBoxPhone.IsEnabled = true;
                TextBoxEmail.IsEnabled = true;
                TextBoxAddress.IsEnabled = true;

                ButtonBrowse.Visibility = Visibility.Visible;
                labelBrowse1.Visibility = Visibility.Visible;
                labelBrowse2.Visibility = Visibility.Visible;
            }
            isClicked = !isClicked;
        }


        private BitmapImage ToImage(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            return image;
            //using (MemoryStream ms = new MemoryStream(array))
            //{
            //    BitmapImage image = new BitmapImage();
            //    image.BeginInit();
            //    image.StreamSource = ms;
            //    image.EndInit();
            //    return image;
            //}
        }

        private void ButtonMedicalCard_Click(object sender, RoutedEventArgs e)
        {
            MedicalCard medicalCard = new MedicalCard(student);
            medicalCard.Show();
        }

        private void TextBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text == "") return;
            if (!ValidatorExprensions.IsValidEmail(TextBoxEmail.Text))
            {
                TextBoxEmail.Text += "(Error!)";
                TextBoxEmail.BorderBrush = Brushes.Red;
                TextBoxEmail.Foreground = Brushes.Red;
            }
        }

        private void TextBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text == "") return;
            TextBoxEmail.BorderBrush = Brushes.Black;
            TextBoxEmail.Foreground = Brushes.Black;
            if (!ValidatorExprensions.IsValidEmail(TextBoxEmail.Text)) TextBoxEmail.Text = "";
            if (TextBoxEmail.Text.Contains("(Error!)"))
            {
                TextBoxEmail.Text = TextBoxEmail.Text.Replace("(Error!)", "");
            }
        }
    }
}
