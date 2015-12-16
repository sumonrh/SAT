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
using System.Data.SQLite;

namespace SATAppRafiqul
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

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Signup_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx_user.Text == "" || passwordBox1.Password == "")
            {
                System.Windows.MessageBox.Show("Please enter username and password");
            }
            else
            {
                DBLoginConnect LoginDB = new DBLoginConnect();
                int exist = LoginDB.U_Exists(txtbx_user.Text);
                if (exist > 0)
                {
                    System.Windows.MessageBox.Show("User already exists!!");
                }
                else if (exist == 0)
                {
                    LoginDB.Insert(txtbx_user.Text, passwordBox1.Password);
                    System.Windows.MessageBox.Show("User Successfully Subscribed");
                }
                else if (exist == -1)
                {
                    System.Windows.MessageBox.Show("Connection Failed");
                }
            }
            
        }

        private void Btn_Unsubscribe(object sender, RoutedEventArgs e)
        {
            if (txtbx_user.Text == "" || passwordBox1.Password == "")
            {
                System.Windows.MessageBox.Show("Please enter username and password");
            }
            else
            {
                DBLoginConnect LoginDB = new DBLoginConnect();
                int upexists = LoginDB.UandP_Exists(txtbx_user.Text, passwordBox1.Password);
                if (upexists == 1)
                {
                    LoginDB.Delete(txtbx_user.Text, passwordBox1.Password);
                    System.Windows.MessageBox.Show("User Successfully Unsubscribed");
                }
                else if (upexists == 0)
                {
                    System.Windows.MessageBox.Show("User does not exist!!");
                }
                else if (upexists > 1)
                {
                    System.Windows.MessageBox.Show("Multiple user exist!!");
                }
                else if (upexists == -1)
                {
                    System.Windows.MessageBox.Show("Connection Failed");
                }
            }
            
        }

        private void Btn_Signin_Click(object sender, RoutedEventArgs e)
        {

            if (txtbx_user.Text=="" || passwordBox1.Password=="")
            {
                System.Windows.MessageBox.Show("Please enter username and password");
            }
            else
            {
                DBLoginConnect LoginDB = new DBLoginConnect();
                int upexists = LoginDB.UandP_Exists(txtbx_user.Text, passwordBox1.Password);
                if (upexists == 1)
                {
                    //globaldata gb = new globaldata();
                    //gb.current_user = txtbx_user.Text;
                    globaldata.current_user=txtbx_user.Text;
                    this.Hide();
                    ActivitySelection actvxml = new ActivitySelection();
                    actvxml.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("User does not exist!!");
                }
            }
            
        }
    }
}
