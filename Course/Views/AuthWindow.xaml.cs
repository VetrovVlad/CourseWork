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
using System.Windows.Shapes;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private async void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = this.login.Text.Trim();
            string psw = this.password.Password;

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

            if (check)
            {
                await Task.Run(() =>
                {
                    User authUser = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        authUser = db.Users
                            .Where(b => b.Login == login && b.Password == psw)
                            .FirstOrDefault();
                    }

                    if (authUser != null)
                    {
                        MessageBox.Show("You'r welcome!");
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct login/password!");
                    }
                });
            }
        }

        private void ButtonRegisterClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
