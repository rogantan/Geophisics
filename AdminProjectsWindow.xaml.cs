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
    /// Interaction logic for AdminProjectsWindow.xaml
    /// </summary>
    public partial class AdminProjectsWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Проекты> Clients { get => db.Проектыs.Local.ToObservableCollection(); }
        public AdminProjectsWindow()
        {
            InitializeComponent();
            PROJECTS.ItemsSource = Clients;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminAddProjectWindow adminAddProjectWindow = new AdminAddProjectWindow();
            if (adminAddProjectWindow.ShowDialog() != true) return;
            db.Проектыs.Add(adminAddProjectWindow.Project);
            db.SaveChanges();
            PROJECTS.Items.Refresh();
            MessageBox.Show("Проект добавлен!");
        }
    }
}
