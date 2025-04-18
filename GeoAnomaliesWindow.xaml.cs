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
    /// Interaction logic for GeoAnomaliesWindow.xaml
    /// </summary>
    public partial class GeoAnomaliesWindow : Window
    {
        public string Login {  get; set; }
        Database db = Database.getInstance();
        public GeoAnomaliesWindow(string login)
        {
            InitializeComponent();
            this.Login = login;
            ANOMALIES.ItemsSource = db.Аномалииs.Where(x => x.IdГеофизикаNavigation.Логин == login).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GeoAddAnomaliaWindow geoAddAnomaliaWindow = new GeoAddAnomaliaWindow(Login);
            geoAddAnomaliaWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
