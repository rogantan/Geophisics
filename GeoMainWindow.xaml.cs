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
    /// Interaction logic for GeoMainWindow.xaml
    /// </summary>
    public partial class GeoMainWindow : Window
    {
        public string Login {  get; set; }
        public GeoMainWindow(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeoProjectsWindow geoProjectsWindow = new GeoProjectsWindow(Login);
            geoProjectsWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GeoAnomaliesWindow geoAnomaliesWindow = new GeoAnomaliesWindow(Login);   
            geoAnomaliesWindow.Show();
            this.Close();
        }
    }
}
