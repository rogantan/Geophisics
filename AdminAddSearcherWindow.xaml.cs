using Geophisics.Models;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for AdminAddSearcherWindow.xaml
    /// </summary>
    public partial class AdminAddSearcherWindow : Window
    {
        public Исследователи Sear { get; set; } = new Исследователи();
        public AdminAddSearcherWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Sear.Фио) || string.IsNullOrEmpty(Sear.Логин) || string.IsNullOrEmpty(Sear.Пароль))
            {
                MessageBox.Show("Данные введены некорректно");
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
