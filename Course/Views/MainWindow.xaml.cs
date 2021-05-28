using Course.Models;
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

namespace Course
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private async void ButtonRegClick(object sender, RoutedEventArgs e)
        {
            string login = this.login.Text.Trim();
            string psw = this.password.Password;
            string psw2 = this.password2.Password;
            string email = this.email.Text.Trim().ToLower();

            bool check = true;

            if (login.Length < 5)
            {
                this.login.ToolTip = "Input more then 5 symbols!";
                this.login.Background = Brushes.IndianRed;
                
                check = false;
            }
            else
            {
                this.login.ToolTip = "";
                this.login.Background = Brushes.Transparent;

                check = true;
            }

            if (psw.Length < 5)
            {
                this.password.ToolTip = "Input more then 5 symbols!";
                this.password.Background = Brushes.IndianRed;

                check = false;
            }
            else
            {
                this.password.ToolTip = "";
                this.password.Background = Brushes.Transparent;

                check = true;
            }
            if (psw != psw2)
            {
                this.password2.ToolTip = "Input password like first!";
                this.password2.Background = Brushes.IndianRed;

                check = false;
            }
            else
            {
                this.password2.ToolTip = "";
                this.password2.Background = Brushes.Transparent;

                check = true;
            }

            if (email.Length<5 || !email.Contains("@") || !email.Contains("."))
            {
                this.email.ToolTip = "Input email!";
                this.email.Background = Brushes.IndianRed;

                check = false;
            } 
            else
            {
                this.email.ToolTip = "";
                this.email.Background = Brushes.Transparent;

                check = true;
            }

      

            await Task.Run(() =>
            {
                User user = db.Users.Where(usr => usr.Login == login).FirstOrDefault();
                if (user != null)
                {
                    MessageBox.Show("You have already registed!");
                }
                else if (check && user == null)
                {
                    user = new User(login, psw, email);

                    db.Users.Add(user);
                    db.SaveChanges();

                    MessageBox.Show("Your registration is finished!");
                }
               
                 
            });
            
        }

        private void ButtonSignClick(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Hide();
        }
    }
}
