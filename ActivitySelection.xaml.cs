using System;
using System.Collections.Generic;
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
    /// Interaction logic for ActivitySelection.xaml
    /// </summary>
    public partial class ActivitySelection : Window
    {
        public ActivitySelection()
        {
            InitializeComponent();
        }

        private void Btn_QuizVoc_Copy_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main_Inst = new MainWindow();
            this.Hide();
            Main_Inst.Show();
        }

        private void Btn_LearnVoc_Click(object sender, RoutedEventArgs e)
        {
            LearningWindow lrnwndw_inst =new LearningWindow();
            this.Hide();
            lrnwndw_inst.Show();
        }

        private void Btn_QuizVoc_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow QuizWindow_Inst = new QuizWindow();
            this.Hide();
            QuizWindow_Inst.Show();
        }

        private void Btn_ProgReport_Click(object sender, RoutedEventArgs e)
        {
            scoresheet scoresheet_inst = new scoresheet();
            this.Hide();
            scoresheet_inst.Show();

        }
    }
}
