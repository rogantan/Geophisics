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
    /// Interaction logic for AdminAddProjectWindow.xaml
    /// </summary>
    public partial class AdminAddProjectWindow : Window
    {
        public Проекты Project { get; set; } = new Проекты();
        Database db = Database.getInstance();
        public ObservableCollection<Администраторы> admins { get => db.Администраторыs.Local.ToObservableCollection(); }
        public ObservableCollection<Заказчики> custiomers { get => db.Заказчикиs.Local.ToObservableCollection(); }
        public AdminAddProjectWindow()
        {
            InitializeComponent();
            ad_combo.ItemsSource = admins;
            cus_combo.ItemsSource = custiomers;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name == null || desc == null || begin_date == null || end_date == null || ad_combo.SelectedItem == null || cus_combo.SelectedItem == null)
            {
                MessageBox.Show("Неверные данные");
            }
            else
            {
                DialogResult = true;
            }
                
        }
    }
} 
