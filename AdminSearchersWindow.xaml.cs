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
    /// Interaction logic for AdminSearchersWindow.xaml
    /// </summary>
    public partial class AdminSearchersWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Исследователи> searchers { get => db.Исследователиs.Local.ToObservableCollection(); }
        public AdminSearchersWindow()
        {
            InitializeComponent();
            SEARCHERS.ItemsSource = searchers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminAddSearcherWindow searcher = new AdminAddSearcherWindow();
            if (searcher.ShowDialog() != true) return;
            db.Исследователиs.Add(searcher.Sear);
            db.SaveChanges();
            SEARCHERS.Items.Refresh();
            MessageBox.Show("Исследователь добавлен!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var resercher = SEARCHERS.SelectedItem as Исследователи;
            if (resercher != null)
            {
                AdminAddSearcherWindow adminAddSearcherWindow = new AdminAddSearcherWindow() { Sear = resercher };
                if (adminAddSearcherWindow.ShowDialog() == true)
                {
                    db.Entry(adminAddSearcherWindow.Sear).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Исследователь изменен");
                }
            }
            else
            {
                MessageBox.Show("Выберите исследователя");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var resercher = SEARCHERS.SelectedItem as Исследователи;
            if (resercher != null)
            {
                List<Измерения> pikets = db.Измеренияs.Where(x => x.IdИсследователяNavigation.Id == resercher.Id).ToList();
                foreach (var piket in pikets)
                {
                    db.Remove(piket);
                    db.SaveChanges();
                }
                db.Исследователиs.Remove(resercher);
                db.SaveChanges();
                MessageBox.Show("Исследователь удален");
            }
            else
            {
                MessageBox.Show("Выберите исследователя");
            }
        }
    }
}
