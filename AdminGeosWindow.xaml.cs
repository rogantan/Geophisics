using Geophisics.Models;
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
    }
}
