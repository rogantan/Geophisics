using Geophisics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AdminGeosWindow.xaml
    /// </summary>
    public partial class AdminGeosWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Геофизики> geos { get => db.Геофизикиs.Local.ToObservableCollection(); }
        public AdminGeosWindow()
        {
            InitializeComponent();
            GEOS.ItemsSource = geos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminAddGeoWindow adminAddGeoWindow = new AdminAddGeoWindow();
            if (adminAddGeoWindow.ShowDialog() != true) return;
            db.Геофизикиs.Add(adminAddGeoWindow.Geo);
            db.SaveChanges();
            GEOS.Items.Refresh();
            MessageBox.Show("Геофизик добавлен!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var geo = GEOS.SelectedItem as Геофизики;
            if (geo != null)
            {
                AdminAddGeoWindow adminAddGeoWindow = new AdminAddGeoWindow() { Geo = geo };
                if (adminAddGeoWindow.ShowDialog() == true)
                {
                    db.Entry(adminAddGeoWindow.Geo).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Геофизик изменен");
                }
            }
            else
            {
                MessageBox.Show("Выберите геофизика");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var geo = GEOS.SelectedItem as Геофизики;
            if (geo != null)
            {
                List<Аномалии> anomalies = db.Аномалииs.Where(x => x.IdГеофизикаNavigation.Id == geo.Id).ToList();
                foreach (var anomali in anomalies)
                {
                    db.Remove(anomali);
                    db.SaveChanges();
                }
                db.Геофизикиs.Remove(geo);
                db.SaveChanges();
                MessageBox.Show("Геофизик удален");
            }
            else
            {
                MessageBox.Show("Выберите геофизика");
            }
        }
    }
}
