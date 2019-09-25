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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RegistrationForm
{
    /// <summary>
    /// Interaction logic for MedicalCard.xaml
    /// </summary>
    public partial class MedicalCard : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();
        TextBox[] textBoxes;
        List<DiagnossisCardiovascular> cardiovasculars;
        List<DiagnossisRespiratory> respiratories;
        List<DiagnossisDigestive> digestives;
        List<DiagnossisEndocrine> endocrines;
        StudentDataBase db = new StudentDataBase();
        Thread thread;
        Student student;
        DiagnossisCardiovascular diagnossisCardiovascular = new DiagnossisCardiovascular();
        DiagnossisRespiratory diagnossisRespiratory = new DiagnossisRespiratory();
        DiagnossisDigestive diagnossisDigestive = new DiagnossisDigestive();
        DiagnossisEndocrine diagnossisEndocrine = new DiagnossisEndocrine();
        public MedicalCard(Student student)
        {
            InitializeComponent();
            textBoxes = new TextBox[4]
            {
                TextBoxData1,
                TextBoxData2,
                TextBoxData3,
                TextBoxData4
            };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = DateTime.Now.ToString();
                textBoxes[i].IsEnabled = false;
            }
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            cardiovasculars = new List<DiagnossisCardiovascular>();
            respiratories = new List<DiagnossisRespiratory>();
            digestives = new List<DiagnossisDigestive>();
            endocrines = new List<DiagnossisEndocrine>();
            this.student = student;

            thread = new Thread(() =>
            {
                Action action = actionStartList1;
                Action action2 = actionStartList2;
                Action action3 = actionStartList3;
                Action action4 = actionStartList4;
                List1.Dispatcher.BeginInvoke(action);
                List2.Dispatcher.BeginInvoke(action2);
                List3.Dispatcher.BeginInvoke(action3);
                List4.Dispatcher.BeginInvoke(action4);
            });
            thread.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = DateTime.Now.ToString();
                textBoxes[i].IsEnabled = false;
            }
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                Action action = actionList1;
                List1.Dispatcher.BeginInvoke(action);
            });
            thread.Start();
        }

        private void BtnAdd2_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                Action action = actionList2;
                List2.Dispatcher.BeginInvoke(action);
            });
            thread.Start();
        }

        private void BtnAdd3_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                Action action = actionList3;
                List3.Dispatcher.BeginInvoke(action);
            });
            thread.Start();
        }

        private void BtnAdd4_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                Action action = actionList4;
                List4.Dispatcher.BeginInvoke(action);
            });
            thread.Start();
        }

        void actionStartList1()
        {
            foreach (var cardiovascular in db.DiagnossisCardiovasculars)
            {
                if (student.Id == cardiovascular.StudentId)
                {
                    cardiovasculars.Add
                    (
                        new DiagnossisCardiovascular()
                        {
                            Id = cardiovascular.Id,
                            Quest1 = cardiovascular.Quest1,
                            Quest2 = cardiovascular.Quest2,
                            Quest3 = cardiovascular.Quest3,
                            Quest4 = cardiovascular.Quest4,
                            Date = cardiovascular.Date,
                            Conclusion = cardiovascular.Conclusion,
                            Reception = cardiovascular.Reception,
                            StudentId = cardiovascular.StudentId
                        }
                    );
                }
            }
            List1.ItemsSource = cardiovasculars;
        }

        void actionStartList2()
        {
            foreach (var respiratory in db.DiagnossisRespiratories)
            {
                if (student.Id == respiratory.StudentId)
                {
                    respiratories.Add
                    (
                        new DiagnossisRespiratory()
                        {
                            Id = respiratory.Id,
                            Quest1 = respiratory.Quest1,
                            Quest2 = respiratory.Quest2,
                            Quest3 = respiratory.Quest3,
                            Date = respiratory.Date,
                            Conclusion = respiratory.Conclusion,
                            Reception = respiratory.Reception,
                            StudentId = respiratory.StudentId
                        }
                    );
                }
            }
            List2.ItemsSource = respiratories;
        }

        void actionStartList3()
        {
            foreach (var digestive in db.DiagnossisDigestives)
            {
                if (student.Id == digestive.StudentId)
                {
                    digestives.Add
                    (
                        new DiagnossisDigestive()
                        {
                            Id = digestive.Id,
                            Quest1 = digestive.Quest1,
                            Quest2 = digestive.Quest2,
                            Quest3 = digestive.Quest3,
                            Quest4 = digestive.Quest4,
                            Date = digestive.Date,
                            Conclusion = digestive.Conclusion,
                            Reception = digestive.Reception,
                            StudentId = digestive.StudentId
                        }
                    );
                }
            }
            List3.ItemsSource = digestives;
        }

        void actionStartList4()
        {
            foreach (var endocrine in db.DiagnossisEndocrines)
            {
                if (student.Id == endocrine.StudentId)
                {
                    endocrines.Add
                    (
                        new DiagnossisEndocrine()
                        {
                            Id = endocrine.Id,
                            Quest1 = endocrine.Quest1,
                            Quest2 = endocrine.Quest2,
                            Quest3 = endocrine.Quest3,
                            Quest4 = endocrine.Quest4,
                            Date = endocrine.Date,
                            Conclusion = endocrine.Conclusion,
                            Reception = endocrine.Reception,
                            StudentId = endocrine.StudentId
                        }
                    );
                }
            }
            List4.ItemsSource = endocrines;
        }

        void actionList1()
        {
            diagnossisCardiovascular.Conclusion = TextBoxConclusionCardiovascular.Text;
            diagnossisCardiovascular.Reception = StringFromRichTextBox(TextBoxReceptionCardiovascular);
            diagnossisCardiovascular.Date = DateTime.Parse(TextBoxData1.Text);
            diagnossisCardiovascular.StudentId = student.Id;
            db.DiagnossisCardiovasculars.Add(diagnossisCardiovascular);
            db.SaveChanges();
            cardiovasculars = null;
            cardiovasculars = new List<DiagnossisCardiovascular>(db.DiagnossisCardiovasculars);
            List1.ItemsSource = null;
            List1.ItemsSource = cardiovasculars;
        }

        void actionList2()
        {
            diagnossisRespiratory.Conclusion = TextBoxConclusionRespiratory.Text;
            diagnossisRespiratory.Reception = StringFromRichTextBox(TextBoxReceptionRespiratory);
            diagnossisRespiratory.Date = DateTime.Parse(TextBoxData2.Text);
            diagnossisRespiratory.StudentId = student.Id;
            db.DiagnossisRespiratories.Add(diagnossisRespiratory);
            db.SaveChanges();
            respiratories = null;
            respiratories = new List<DiagnossisRespiratory>(db.DiagnossisRespiratories);
            List2.ItemsSource = null;
            List2.ItemsSource = respiratories;
        }

        void actionList3()
        {
            diagnossisDigestive.Conclusion = TextBoxConclusionDigestive.Text;
            diagnossisDigestive.Reception = StringFromRichTextBox(TextBoxReceptionDigestive);
            diagnossisDigestive.Date = DateTime.Parse(TextBoxData3.Text);
            diagnossisDigestive.StudentId = student.Id;
            db.DiagnossisDigestives.Add(diagnossisDigestive);
            db.SaveChanges();
            digestives = null;
            digestives = new List<DiagnossisDigestive>(db.DiagnossisDigestives);
            List3.ItemsSource = null;
            List3.ItemsSource = digestives;
        }

        void actionList4()
        {
            diagnossisEndocrine.Conclusion = TextBoxConclusionEndocrine.Text;
            diagnossisEndocrine.Reception = StringFromRichTextBox(TextBoxReceptionEndocrine);
            diagnossisEndocrine.Date = DateTime.Parse(TextBoxData4.Text);
            diagnossisEndocrine.StudentId = student.Id;
            db.DiagnossisEndocrines.Add(diagnossisEndocrine);
            db.SaveChanges();
            endocrines = null;
            endocrines = new List<DiagnossisEndocrine>(db.DiagnossisEndocrines);
            List4.ItemsSource = null;
            List4.ItemsSource = endocrines;
        }

        private void QuestionOfCardiovascular1_Click(object sender, RoutedEventArgs e)
        {
            diagnossisCardiovascular.Quest1 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfCardiovascular2_Click(object sender, RoutedEventArgs e)
        {
            diagnossisCardiovascular.Quest2 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfCardiovascular3_Click(object sender, RoutedEventArgs e)
        {
            diagnossisCardiovascular.Quest3 = (sender as RadioButton).Content.ToString();
        }

        private void QuestionOfCardiovascular4_Click(object sender, RoutedEventArgs e)
        {
            diagnossisCardiovascular.Quest4 = (sender as RadioButton).Content.ToString();
        }

        private string StringFromRichTextBox(RichTextBox richTextBox)
        {
            TextRange text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return text.Text;
        }
        private void QuestionOfRespiratory1_Click(object sender, RoutedEventArgs e)
        {
            diagnossisRespiratory.Quest1 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfRespiratory2_Click(object sender, RoutedEventArgs e)
        {
            diagnossisRespiratory.Quest2 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfRespiratory3_Click(object sender, RoutedEventArgs e)
        {
            diagnossisRespiratory.Quest3 = (sender as RadioButton).Content.ToString();
        }

        private void QuestionOfDigestive1_Click(object sender, RoutedEventArgs e)
        {
            diagnossisDigestive.Quest1 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfDigestive2_Click(object sender, RoutedEventArgs e)
        {
            diagnossisDigestive.Quest2 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfDigestive3_Click(object sender, RoutedEventArgs e)
        {
            diagnossisDigestive.Quest3 = (sender as RadioButton).Content.ToString();
        }

        private void QuestionOfDigestive4_Click(object sender, RoutedEventArgs e)
        {
            diagnossisDigestive.Quest4 = (sender as RadioButton).Content.ToString();
        }

        private void QuestionOfEndocrine1_Click(object sender, RoutedEventArgs e)
        {
            diagnossisEndocrine.Quest1 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfEndocrine2_Click(object sender, RoutedEventArgs e)
        {
            diagnossisEndocrine.Quest2 = (sender as RadioButton).Content.ToString();
        }
        private void QuestionOfEndocrine3_Click(object sender, RoutedEventArgs e)
        {
            diagnossisEndocrine.Quest3 = (sender as RadioButton).Content.ToString();
        }

        private void QuestionOfEndocrine4_Click(object sender, RoutedEventArgs e)
        {
            diagnossisEndocrine.Quest4 = (sender as RadioButton).Content.ToString();
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestionOfCardiovascular1_2.IsChecked = false;
            QuestionOfCardiovascular1_3.IsChecked = false;
            QuestionOfCardiovascular1_4.IsChecked = false;

            QuestionOfCardiovascular2_1.IsChecked = false;
            QuestionOfCardiovascular2_2.IsChecked = false;

            QuestionOfCardiovascular3_1.IsChecked = false;
            QuestionOfCardiovascular3_2.IsChecked = false;

            QuestionOfCardiovascular4_1.IsChecked = false;
            QuestionOfCardiovascular4_2.IsChecked = false;
            if (List1.SelectedItem != null)
            {
                string[] Quest = new string[4];
                Quest[0] = cardiovasculars[List1.SelectedIndex].Quest1;
                Quest[1] = cardiovasculars[List1.SelectedIndex].Quest2;
                Quest[2] = cardiovasculars[List1.SelectedIndex].Quest3;
                Quest[3] = cardiovasculars[List1.SelectedIndex].Quest4;
                if ((QuestionOfCardiovascular1_1.Content as string) == Quest[0])
                {
                    QuestionOfCardiovascular1_1.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular1_2.Content as string) == Quest[0])
                {
                    QuestionOfCardiovascular1_2.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular1_3.Content as string) == Quest[0])
                {
                    QuestionOfCardiovascular1_3.IsChecked = true;
                }
                else
                {
                    QuestionOfCardiovascular1_4.IsChecked = true;
                }

                if ((QuestionOfCardiovascular2_1.Content as string) == Quest[1])
                {
                    QuestionOfCardiovascular2_1.IsChecked = true;
                }
                else
                {
                    QuestionOfCardiovascular2_2.IsChecked = true;
                }

                if ((QuestionOfCardiovascular3_1.Content as string) == Quest[2])
                {
                    QuestionOfCardiovascular3_1.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular3_2.Content as string) == Quest[2])
                {
                    QuestionOfCardiovascular3_2.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular3_3.Content as string) == Quest[2])
                {
                    QuestionOfCardiovascular3_3.IsChecked = true;
                }
                else
                {
                    QuestionOfCardiovascular3_4.IsChecked = true;
                }

                if ((QuestionOfCardiovascular4_1.Content as string) == Quest[3])
                {
                    QuestionOfCardiovascular4_1.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular4_2.Content as string) == Quest[3])
                {
                    QuestionOfCardiovascular4_2.IsChecked = true;
                }
                else if ((QuestionOfCardiovascular4_3.Content as string) == Quest[3])
                {
                    QuestionOfCardiovascular4_3.IsChecked = true;
                }
                else 
                {
                    QuestionOfCardiovascular4_4.IsChecked = true;
                }

                TextBoxConclusionCardiovascular.Text = cardiovasculars[List1.SelectedIndex].Conclusion;
                TextBoxReceptionCardiovascular.Document.Blocks.Clear();
                TextBoxReceptionCardiovascular.Document.Blocks.Add(new Paragraph(new Run(cardiovasculars[List1.SelectedIndex].Reception)));
            }
        }

        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestionOfRespiratory1_1.IsChecked = false;
            QuestionOfRespiratory1_2.IsChecked = false;
            QuestionOfRespiratory1_3.IsChecked = false;

            QuestionOfRespiratory2_1.IsChecked = false;
            QuestionOfRespiratory2_2.IsChecked = false;
            QuestionOfRespiratory2_3.IsChecked = false;

            QuestionOfRespiratory3_1.IsChecked = false;
            QuestionOfRespiratory3_2.IsChecked = false;

            if (List2.SelectedItem != null)
            {
                string[] Quest = new string[3];
                Quest[0] = respiratories[List2.SelectedIndex].Quest1;
                Quest[1] = respiratories[List2.SelectedIndex].Quest2;
                Quest[2] = respiratories[List2.SelectedIndex].Quest3;
                if ((QuestionOfRespiratory1_1.Content as string) == Quest[0])
                {
                    QuestionOfRespiratory1_1.IsChecked = true;
                }
                else if ((QuestionOfRespiratory1_2.Content as string) == Quest[0])
                {
                    QuestionOfRespiratory1_2.IsChecked = true;
                }
                else if ((QuestionOfRespiratory1_3.Content as string) == Quest[0])
                {
                    QuestionOfRespiratory1_3.IsChecked = true;
                }

                if ((QuestionOfRespiratory2_1.Content as string) == Quest[1])
                {
                    QuestionOfRespiratory2_1.IsChecked = true;
                }
                else if ((QuestionOfRespiratory2_2.Content as string) == Quest[1])
                {
                    QuestionOfRespiratory2_2.IsChecked = true;
                }
                else if ((QuestionOfRespiratory2_3.Content as string) == Quest[1])
                {
                    QuestionOfRespiratory2_3.IsChecked = true;
                }

                if ((QuestionOfRespiratory3_1.Content as string) == Quest[2])
                {
                    QuestionOfRespiratory3_1.IsChecked = true;
                }
                else if ((QuestionOfRespiratory3_2.Content as string) == Quest[2])
                {
                    QuestionOfRespiratory3_2.IsChecked = true;
                }

                TextBoxConclusionRespiratory.Text = respiratories[List2.SelectedIndex].Conclusion;
                TextBoxReceptionRespiratory.Document.Blocks.Clear();
                TextBoxReceptionRespiratory.Document.Blocks.Add(new Paragraph(new Run(respiratories[List2.SelectedIndex].Reception)));
            }
        }

        private void List3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestionOfDigestive1_1.IsChecked = false;
            QuestionOfDigestive1_2.IsChecked = false;
            QuestionOfDigestive1_3.IsChecked = false;
            QuestionOfDigestive1_4.IsChecked = false;

            QuestionOfDigestive2_1.IsChecked = false;
            QuestionOfDigestive2_2.IsChecked = false;

            QuestionOfDigestive3_1.IsChecked = false;
            QuestionOfDigestive3_2.IsChecked = false;

            QuestionOfDigestive4_1.IsChecked = false;
            QuestionOfDigestive4_2.IsChecked = false;
            if (List3.SelectedItem != null)
            {
                string[] Quest = new string[4];
                Quest[0] = digestives[List3.SelectedIndex].Quest1;
                Quest[1] = digestives[List3.SelectedIndex].Quest2;
                Quest[2] = digestives[List3.SelectedIndex].Quest3;
                Quest[3] = digestives[List3.SelectedIndex].Quest4;
                if ((QuestionOfDigestive1_1.Content as string) == Quest[0])
                {
                    QuestionOfDigestive1_1.IsChecked = true;
                }
                else if ((QuestionOfDigestive1_2.Content as string) == Quest[0])
                {
                    QuestionOfDigestive1_2.IsChecked = true;
                }
                else if ((QuestionOfDigestive1_3.Content as string) == Quest[0])
                {
                    QuestionOfDigestive1_3.IsChecked = true;
                }
                else if ((QuestionOfDigestive1_4.Content as string) == Quest[0])
                {
                    QuestionOfDigestive1_4.IsChecked = true;
                }


                if ((QuestionOfDigestive2_1.Content as string) == Quest[1])
                {
                    QuestionOfDigestive2_1.IsChecked = true;
                }
                else if ((QuestionOfDigestive2_2.Content as string) == Quest[1])
                {
                    QuestionOfDigestive2_2.IsChecked = true;
                }

                if ((QuestionOfDigestive3_1.Content as string) == Quest[2])
                {
                    QuestionOfDigestive3_1.IsChecked = true;
                }
                else if ((QuestionOfDigestive3_2.Content as string) == Quest[2])
                {
                    QuestionOfDigestive3_2.IsChecked = true;
                }

                if ((QuestionOfDigestive4_1.Content as string) == Quest[3])
                {
                    QuestionOfDigestive4_1.IsChecked = true;
                }
                else if ((QuestionOfDigestive4_2.Content as string) == Quest[3])
                {
                    QuestionOfDigestive4_2.IsChecked = true;
                }

                TextBoxConclusionDigestive.Text = respiratories[List3.SelectedIndex].Conclusion;
                TextBoxReceptionDigestive.Document.Blocks.Clear();
                TextBoxReceptionDigestive.Document.Blocks.Add(new Paragraph(new Run(digestives[List3.SelectedIndex].Reception)));
            }
        }

        private void List4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestionOfEndocrine1_1.IsChecked = false;
            QuestionOfEndocrine1_2.IsChecked = false;
            QuestionOfEndocrine1_3.IsChecked = false;
            QuestionOfEndocrine1_4.IsChecked = false;

            QuestionOfEndocrine2_1.IsChecked = false;
            QuestionOfEndocrine2_2.IsChecked = false;
            QuestionOfEndocrine2_3.IsChecked = false;
            QuestionOfEndocrine2_4.IsChecked = false;

            QuestionOfEndocrine3_1.IsChecked = false;
            QuestionOfEndocrine3_2.IsChecked = false;

            QuestionOfEndocrine4_1.IsChecked = false;
            QuestionOfEndocrine4_2.IsChecked = false;
            QuestionOfEndocrine4_3.IsChecked = false;
            if (List4.SelectedItem != null)
            {
                string[] Quest = new string[4];
                Quest[0] = endocrines[List4.SelectedIndex].Quest1;
                Quest[1] = endocrines[List4.SelectedIndex].Quest2;
                Quest[2] = endocrines[List4.SelectedIndex].Quest3;
                Quest[3] = endocrines[List4.SelectedIndex].Quest4;
                if ((QuestionOfEndocrine1_1.Content as string) == Quest[0])
                {
                    QuestionOfEndocrine1_1.IsChecked = true;
                }
                else if ((QuestionOfEndocrine1_2.Content as string) == Quest[0])
                {
                    QuestionOfEndocrine1_2.IsChecked = true;
                }
                else if ((QuestionOfEndocrine1_3.Content as string) == Quest[0])
                {
                    QuestionOfEndocrine1_3.IsChecked = true;
                }
                else if ((QuestionOfEndocrine1_4.Content as string) == Quest[0])
                {
                    QuestionOfEndocrine1_4.IsChecked = true;
                }

                if ((QuestionOfEndocrine2_1.Content as string) == Quest[1])
                {
                    QuestionOfEndocrine2_1.IsChecked = true;
                }
                else if ((QuestionOfEndocrine2_2.Content as string) == Quest[1])
                {
                    QuestionOfEndocrine2_2.IsChecked = true;
                }
                else if ((QuestionOfEndocrine2_3.Content as string) == Quest[1])
                {
                    QuestionOfEndocrine2_3.IsChecked = true;
                }
                else if ((QuestionOfEndocrine2_4.Content as string) == Quest[1])
                {
                    QuestionOfEndocrine2_4.IsChecked = true;
                }


                if ((QuestionOfEndocrine3_1.Content as string) == Quest[2])
                {
                    QuestionOfEndocrine3_1.IsChecked = true;
                }
                else if ((QuestionOfEndocrine3_2.Content as string) == Quest[2])
                {
                    QuestionOfEndocrine3_2.IsChecked = true;
                }

                if ((QuestionOfEndocrine4_1.Content as string) == Quest[3])
                {
                    QuestionOfEndocrine4_1.IsChecked = true;
                }
                else if ((QuestionOfEndocrine4_2.Content as string) == Quest[3])
                {
                    QuestionOfEndocrine4_2.IsChecked = true;
                }
                else if ((QuestionOfEndocrine4_3.Content as string) == Quest[3])
                {
                    QuestionOfEndocrine4_3.IsChecked = true;
                }

                TextBoxConclusionEndocrine.Text = endocrines[List4.SelectedIndex].Conclusion;
                TextBoxReceptionEndocrine.Document.Blocks.Clear();
                TextBoxReceptionEndocrine.Document.Blocks.Add(new Paragraph(new Run(endocrines[List4.SelectedIndex].Reception)));
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            TextBoxConclusionCardiovascular.Text = "";
            TextBoxReceptionCardiovascular.Document.Blocks.Clear();
            TextBoxReceptionCardiovascular.Document.Blocks.Add(new Paragraph(new Run("")));
            QuestionOfCardiovascular1_1.IsChecked = false;
            QuestionOfCardiovascular1_2.IsChecked = false;
            QuestionOfCardiovascular1_3.IsChecked = false;
            QuestionOfCardiovascular1_4.IsChecked = false;

            QuestionOfCardiovascular2_1.IsChecked = false;
            QuestionOfCardiovascular2_2.IsChecked = false;

            QuestionOfCardiovascular3_1.IsChecked = false;
            QuestionOfCardiovascular3_2.IsChecked = false;

            QuestionOfCardiovascular4_1.IsChecked = false;
            QuestionOfCardiovascular4_2.IsChecked = false;

            List1.SelectedItem = null;
        }
        private void BtnNew2_Click(object sender, RoutedEventArgs e)
        {
            TextBoxConclusionRespiratory.Text = "";
            TextBoxReceptionRespiratory.Document.Blocks.Clear();
            TextBoxReceptionRespiratory.Document.Blocks.Add(new Paragraph(new Run("")));
            QuestionOfRespiratory1_1.IsChecked = false;
            QuestionOfRespiratory1_2.IsChecked = false;
            QuestionOfRespiratory1_3.IsChecked = false;

            QuestionOfRespiratory2_1.IsChecked = false;
            QuestionOfRespiratory2_2.IsChecked = false;
            QuestionOfRespiratory2_3.IsChecked = false;

            QuestionOfRespiratory3_1.IsChecked = false;
            QuestionOfRespiratory3_2.IsChecked = false;

            List2.SelectedItem = null;
        }

        private void BtnNew3_Click(object sender, RoutedEventArgs e)
        {
            TextBoxConclusionDigestive.Text = "";
            TextBoxReceptionDigestive.Document.Blocks.Clear();
            TextBoxReceptionDigestive.Document.Blocks.Add(new Paragraph(new Run("")));
            QuestionOfDigestive1_1.IsChecked = false;
            QuestionOfDigestive1_2.IsChecked = false;
            QuestionOfDigestive1_3.IsChecked = false;
            QuestionOfDigestive1_4.IsChecked = false;

            QuestionOfDigestive2_1.IsChecked = false;
            QuestionOfDigestive2_2.IsChecked = false;

            QuestionOfDigestive3_1.IsChecked = false;
            QuestionOfDigestive3_2.IsChecked = false;

            QuestionOfDigestive4_1.IsChecked = false;
            QuestionOfDigestive4_2.IsChecked = false;

            List3.SelectedItem = null;
        }

        private void BtnNew4_Click(object sender, RoutedEventArgs e)
        {
            TextBoxConclusionEndocrine.Text = "";
            TextBoxReceptionEndocrine.Document.Blocks.Clear();
            TextBoxReceptionEndocrine.Document.Blocks.Add(new Paragraph(new Run("")));
            QuestionOfEndocrine1_1.IsChecked = false;
            QuestionOfEndocrine1_2.IsChecked = false;
            QuestionOfEndocrine1_3.IsChecked = false;
            QuestionOfEndocrine1_4.IsChecked = false;

            QuestionOfEndocrine2_1.IsChecked = false;
            QuestionOfEndocrine2_2.IsChecked = false;
            QuestionOfEndocrine2_3.IsChecked = false;
            QuestionOfEndocrine2_4.IsChecked = false;

            QuestionOfEndocrine3_1.IsChecked = false;
            QuestionOfEndocrine3_2.IsChecked = false;

            QuestionOfEndocrine4_1.IsChecked = false;
            QuestionOfEndocrine4_2.IsChecked = false;
            QuestionOfEndocrine4_3.IsChecked = false;
        }
    }
}
