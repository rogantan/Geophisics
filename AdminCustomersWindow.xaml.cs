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
    /// Interaction logic for AdminCustomersWindow.xaml
    /// </summary>
    public partial class AdminCustomersWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Заказчики> customers { get => db.Заказчикиs.Local.ToObservableCollection(); }
        public AdminCustomersWindow()
        {
            InitializeComponent();
            CUSTOMERS.ItemsSource = customers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
