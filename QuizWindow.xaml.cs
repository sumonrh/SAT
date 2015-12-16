using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SATAppRafiqul
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        string CorrectAns;
        Int32 TotalQues = 10, nof_correct=0, nof_wrong=0, nof_unanswered=0;
        float score=0;

        public QuizWindow()
        {
            InitializeComponent();
            getques();
        }

        private void Btn_Exit2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Btn_Home2_Click(object sender, RoutedEventArgs e)
        {
            ActivitySelection Actv_Instnc = new ActivitySelection();
            this.Hide();
            Actv_Instnc.Show();
        }

        private void Btn_Next2_Click(object sender, RoutedEventArgs e)
        {
            radiobuttonchecked(CorrectAns);
            getques();
        }

        private void getques()
        {
            
            if (TotalQues==0)
            {
                score = 100 * nof_correct / (nof_correct+nof_unanswered+nof_wrong);
                System.Windows.MessageBox.Show("Correct: " + Convert.ToString(nof_correct) + " ,wrong: " + Convert.ToString(nof_wrong) + " ,Unanswered: " + Convert.ToString(nof_unanswered)+" : So, you scored : "+Convert.ToString(score)+"% in this session");
                DBProgressConnect DBProgressConnect_inst = new DBProgressConnect();
                //globaldata gb = new globaldata();
                DBProgressConnect_inst.Insert(globaldata.current_user, Convert.ToString(DateTime.Now), Convert.ToString(score));

                ActivitySelection Actv_Instnc = new ActivitySelection();
                this.Hide();
                Actv_Instnc.Show();
            }
            else
            {
                rdbtn1.IsChecked = false;
                rdbtn2.IsChecked = false;
                rdbtn3.IsChecked = false;
                rdbtn4.IsChecked = false;
                DBVocaConnect DBConnect_inst = new DBVocaConnect();
                int data_count = DBConnect_inst.Count();
                DataTable QuesLoadTable = new DataTable();
                QuesLoadTable = DBConnect_inst.Read();

                Random Rand_Gen = new Random();
                int[] x = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    x[j] = Rand_Gen.Next(data_count + 1);
                }
                string ques;
                ques = QuesLoadTable.Rows[x[0]][1].ToString();
                ques = ques.Trim();
                txtblck1.Text = "Question: " + ques;
                CorrectAns = QuesLoadTable.Rows[x[0]][2].ToString();
                CorrectAns = CorrectAns.Trim();
                //label6.Content = "Database Entry: " + (x[0] + 1).ToString() + "\nCorrect Answer: " + CorrectAns;

                string[] AllAns = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    AllAns[i] = QuesLoadTable.Rows[x[i]][2].ToString();
                }

                new Random().Shuffle(AllAns);

                rdbtn1.Content = AllAns[0].Trim();
                rdbtn2.Content = AllAns[1].Trim();
                rdbtn3.Content = AllAns[2].Trim();
                rdbtn4.Content = AllAns[3].Trim();

                TotalQues--;
            }
        }

        private void AnsCheck()
        {

        }

        private void radiobuttonchecked(string correct)
        {
            string student_ans = "";

            if (Convert.ToBoolean(rdbtn1.IsChecked))
            {
                student_ans = Convert.ToString(rdbtn1.Content);
            }   
            else if (Convert.ToBoolean(rdbtn2.IsChecked))
            {
                student_ans = Convert.ToString(rdbtn2.Content);
            }   
            else if (Convert.ToBoolean(rdbtn3.IsChecked))
            {
                student_ans = Convert.ToString(rdbtn3.Content);
            }
            else if (Convert.ToBoolean(rdbtn4.IsChecked))
            {
                student_ans = Convert.ToString(rdbtn4.Content);
            }

            student_ans = student_ans.Trim();
            if (student_ans!="")
                if(student_ans==correct)
                {
                    nof_correct++;
                }
                else
                {
                    nof_wrong++;
                }
            else
            {
                nof_unanswered++;
            }

        }
    }
}
