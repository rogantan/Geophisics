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
    /// Interaction logic for GeoProjectsWindow.xaml
    /// </summary>
    public partial class GeoProjectsWindow : Window
    {
        Database db = Database.getInstance();
        public string Login {  get; set; }
        public GeoProjectsWindow(string login)
        {
            InitializeComponent();
            PROJECTS.ItemsSource = db.Проектыs.Local.ToList();
            this.Login = login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var project = PROJECTS.SelectedItem as Проекты;
            if (project != null )
            {
                GeoPlozhesWindow geoProfiliesWindow = new GeoPlozhesWindow(project);
                geoProfiliesWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите проект");
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GeoMainWindow geoMainWindow = new GeoMainWindow(Login);
            geoMainWindow.Show();
            this.Close();
        }
    }
}
