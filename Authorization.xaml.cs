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
using Geophisics.Models;

namespace Geophisics
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database db = Database.getInstance();
            string login = Login.Text;
            string password = Password.Text;
            var admins = db.Администраторыs.Local.Where(x => x.Логин == login && x.Пароль == password).Any();
            var customers = db.Заказчикиs.Local.Where(x => x.Логин == login && x.Пароль == password).Any();
            var issledovs = db.Исследователиs.Local.Where(x => x.Логин == login && x.Пароль == password).Any();
            var explorers = db.Геофизикиs.Local.Where(x => x.Логин == login && x.Пароль == password).Any();
            if (admins)
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else if (customers)
            {

            }
            else if (issledovs)
            {

            }
            else if (explorers)
            {

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль"!);
            }
        }
    }
}
