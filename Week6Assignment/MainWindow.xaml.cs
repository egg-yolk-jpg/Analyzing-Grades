using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Week6Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void analyzeGradesButton_Click(object sender, RoutedEventArgs e)
        {
            // Week 6 Assignment
            // Yakimah
            // Monday, September 26th, 2022

            // For the first half of this assignment, I will be creating a program that creates a text document of scores
            // and then places those scores in a list box. Those scores will then be shown as their equivalent grades in 
            // another textbox. In addition, I will show the total number of score entries the average of all the scores.
            // You can also save the file as a text file to any folder in your computer!

            try
            {

                const int FAILING_GRADE = 59;
                const int BARELY_ACCEPTABLE = 69;
                const int PASS = 79;
                const int GOOD = 89;
                const int AWESOME = 100;

                StreamWriter writeGrade;
                writeGrade = File.CreateText(@"C:\Users\yakim\source\repos\Week6Assignment\Week6Assignment\bin\Debug\grades.txt");
                writeGrade.WriteLine(59);
                writeGrade.WriteLine(60);
                writeGrade.WriteLine(65);
                writeGrade.WriteLine(75);
                writeGrade.WriteLine(56);
                writeGrade.WriteLine(90);
                writeGrade.WriteLine(66);
                writeGrade.WriteLine(62);
                writeGrade.WriteLine(98);
                writeGrade.WriteLine(72);
                writeGrade.WriteLine(95);
                writeGrade.WriteLine(71);
                writeGrade.WriteLine(63);
                writeGrade.WriteLine(77);
                writeGrade.WriteLine(65);
                writeGrade.WriteLine(77);
                writeGrade.WriteLine(65);
                writeGrade.WriteLine(50);
                writeGrade.WriteLine(85);
                writeGrade.WriteLine(62);


                writeGrade.Close();

                StreamReader readGrade;
                readGrade = File.OpenText(@"C:\Users\yakim\source\repos\Week6Assignment\Week6Assignment\bin\Debug\grades.txt");

                scoresListBox.Items.Clear();
                gradesListBox.Items.Clear();
                combinedListBox.Items.Clear();
                combinedListBox.Items.Add("Scores" + "        " + "Grades");
                combinedListBox.Items.Add(" ");

                while (!readGrade.EndOfStream)
                {
                    int score = int.Parse(readGrade.ReadLine());
                    const int LARGEST_NUMBER = 100;
                    const int SMALLEST_NUMBER = 0;
                    int totalNumber;
                    scoresListBox.Items.Add(score);
                    

                    string A = "A";
                    string B = "B";
                    string C = "C";
                    string D = "D";
                    string F = "F";

                    if (score <= FAILING_GRADE)
                    {
                        gradesListBox.Items.Add(F);
                        combinedListBox.Items.Add(score + "               " + F);
                    }
                    else if (score <= BARELY_ACCEPTABLE)
                    {
                        gradesListBox.Items.Add(D);
                        combinedListBox.Items.Add(score + "               " + D);
                    }
                    else if (score <= PASS)
                    {
                        gradesListBox.Items.Add(C);
                        combinedListBox.Items.Add(score + "               " + C);
                    }
                    else if (score <= GOOD)
                    {
                        gradesListBox.Items.Add(B);
                        combinedListBox.Items.Add(score + "               " + B);
                    }
                    else if (score <= AWESOME)
                    {
                        gradesListBox.Items.Add(A);
                        combinedListBox.Items.Add(score + "               " + A);
                    }

                    /// It gets a bit messy in this area. When I first went through the instructions
                    /// I misunderstood the number of listboxes I was supposed to use. But by the 
                    /// time I got to the [Save Dialog] section of the instructions, I had already
                    /// learned so much and decided not to take anything out.

                    if(score <= LARGEST_NUMBER)
                    {
                        if(score >= SMALLEST_NUMBER)
                        {
                           
                            

                            string[] numberList = File.ReadAllLines(@"C:\Users\yakim\source\repos\Week6Assignment\Week6Assignment\bin\Debug\grades.txt");
                            double sum = 0;
                           

                            double average;
                            

                            foreach(string number in numberList)
                            {
                                for (totalNumber = 0; totalNumber <= scoresListBox.Items.Count; totalNumber++)
                                {

                                    totalLabel.Content = totalNumber.ToString();
                                   
                                }
                                sum += int.Parse(number);

                                object listBoxNumber = new object();
                                listBoxNumber = totalLabel.Content;
                                string listBoxString = listBoxNumber as string;
                                int listBoxInteger = int.Parse(listBoxString);
                                average = sum / listBoxInteger;
                                averagesLabel.Content = average;
                            }

                            if (readGrade.EndOfStream == true)
                            {
                                combinedListBox.Items.Add(" ");
                                int combinedListBoxItems = combinedListBox.Items.Count - 3;
                                combinedListBox.Items.Add("The total number of scores is " + combinedListBoxItems + ".");

                                double combinedListBoxSum = 0;
                                combinedListBoxSum += score;

                                int combinedListBoxItemsUpdate = combinedListBox.Items.Count - 4;
                                double combinedListBoxAverage = sum / combinedListBoxItemsUpdate;
                                combinedListBox.Items.Add("The average of the scores is " + combinedListBoxAverage + ".");
                                
                            }
                        }
                    }
                   


                }

                readGrade.Close();
            }

            catch
            {
                MessageBox.Show("Something went wrong. Please check the code!");
            }


        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var gradesList = new StringBuilder();
            foreach (var line in combinedListBox.Items)
            {
                gradesList.AppendLine(line.ToString());
            }

            string ready2save = gradesList.ToString();

            SaveFileDialog saveGrades = new SaveFileDialog();
            saveGrades.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveGrades.DefaultExt = "txt";
            if (saveGrades.ShowDialog() == true)
            {
                File.WriteAllText(saveGrades.FileName, ready2save);

            }
        }
    }
}


