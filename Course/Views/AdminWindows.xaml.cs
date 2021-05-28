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

namespace Course.Views
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void ButtonShowAllClick(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {

                var sortedUsers = db.Users.OrderBy(u => u.Login);

                foreach (User user in sortedUsers)
                {
                    allUsers.Text += $"Login: {user.Login} | password: {user.Password} | email: {user.Email}\n";
                }
            }

            allUsers.Visibility = Visibility.Visible;
        }

        private void ButtonDeleteUser(object sender, RoutedEventArgs e)
        {
            allUsers.Visibility = Visibility.Hidden;

            delete.Visibility = Visibility.Visible;

            login.Visibility = Visibility.Visible;
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var userToRemove = db.Users.Where(us => us.Login == login.Text).FirstOrDefault();
                db.Users.Remove(userToRemove);
                db.SaveChanges();
            }

            allUsers.Text = "";
        }
    }
}
