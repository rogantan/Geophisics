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
    /// Interaction logic for AdminAddGeoWindow.xaml
    /// </summary>
    public partial class AdminAddGeoWindow : Window
    {
        public Геофизики Geo { get; set; } = new Геофизики();
        public AdminAddGeoWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Geo.Фио) || string.IsNullOrEmpty(Geo.Логин) || string.IsNullOrEmpty(Geo.Пароль))
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
