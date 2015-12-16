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
    /// Interaction logic for LearningWindow.xaml
    /// </summary>
    public partial class LearningWindow : Window
    {
        string CorrectAns, Ques;
        int data_count = 0, j=1;
        int[] x;
        DataTable QuesLoadTable = new DataTable();
        Random Rand_Gen = new Random();

        public LearningWindow()
        {
            InitializeComponent();
            DBVocaConnect DBVCnnct_inst = new DBVocaConnect();
            QuesLoadTable = DBVCnnct_inst.Read();
            data_count = DBVCnnct_inst.Count();
            x = new int[data_count+1];
            for (int i = 1; i <= data_count; i++ )
            {
                x[i] = Rand_Gen.Next(1, data_count + 1);
            }
                
            getques();
        }

        private void Btn_Exit2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            ActivitySelection Actv_Instnc = new ActivitySelection();
            this.Hide();
            Actv_Instnc.Show();
        }

        private void getques()
        {
            j++;
            Ques = QuesLoadTable.Rows[x[j]][1].ToString();
            txtbx_vc.Text = "Question : " + Ques.Trim();
            CorrectAns = QuesLoadTable.Rows[x[j]][2].ToString();
        }

        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            getques();
        }

        private void Btn_Answer_Click(object sender, RoutedEventArgs e)
        {
            txtbx_vc.Text = "Answer : "+CorrectAns.Trim();
        }

        private void Btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            j--;
            Ques = QuesLoadTable.Rows[x[j]][1].ToString();
            txtbx_vc.Text = "Question : " + Ques.Trim();
            CorrectAns = QuesLoadTable.Rows[x[j]][2].ToString();
        }
    }
}
