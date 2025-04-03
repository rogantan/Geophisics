using Geophisics.Models;
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

namespace Geophisics
{
    /// <summary>
    /// Interaction logic for AdminAddCustomerWindow.xaml
    /// </summary>
    public partial class AdminAddCustomerWindow : Window
    {
        public Заказчики Customer {  get; set; } = new Заказчики();
        public AdminAddCustomerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Customer.Фио) || string.IsNullOrEmpty(Customer.Логин) || string.IsNullOrEmpty(Customer.Пароль))
            {
                MessageBox.Show("Данные введены некорректно!");
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
