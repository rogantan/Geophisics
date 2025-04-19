using Geophisics.Models;
using Microsoft.EntityFrameworkCore;
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
            GeoMainWindow geoMainWindow = new GeoMainWindow(Login);
            geoMainWindow.Show();   
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GeoAddAnomaliaWindow geoAddAnomaliaWindow = new GeoAddAnomaliaWindow(Login);
            if (geoAddAnomaliaWindow.ShowDialog() != true) return;
            db.Аномалииs.Add(geoAddAnomaliaWindow.Anomalia);
            db.SaveChanges();
            MessageBox.Show("Аномалия добавлена");
            ANOMALIES.ItemsSource = db.Аномалииs.Where(x => x.IdГеофизикаNavigation.Логин == Login).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var anomalia = ANOMALIES.SelectedItem as Аномалии;
            if (anomalia != null)
            {
                GeoAddAnomaliaWindow geoAddAnomaliaWindow = new GeoAddAnomaliaWindow(Login) { Anomalia = anomalia };
                if (geoAddAnomaliaWindow.ShowDialog() == true)
                {
                    db.Entry(geoAddAnomaliaWindow.Anomalia).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Аномалия изменена");
                }
            }
            else
            {
                MessageBox.Show("Выберите аномалию");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var anomalia = ANOMALIES.SelectedItem as Аномалии;
            if (anomalia != null)
            {
                db.Аномалииs.Remove(anomalia);  
                db.SaveChanges();
                MessageBox.Show("Аномалия удалена");
                ANOMALIES.ItemsSource = db.Аномалииs.Where(x => x.IdГеофизикаNavigation.Логин == Login).ToList();
            }
            else
            {
                MessageBox.Show("Выберите аномалию");
            }
        }
    }
}
