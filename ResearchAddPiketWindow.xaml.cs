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
    /// Interaction logic for ResearchAddPiketWindow.xaml
    /// </summary>
    public partial class ResearchAddPiketWindow : Window
    {
        public Измерения Piket { get; set; } = new Измерения();
        Database db = Database.getInstance();
        Профили Profile { get; set; }
        public ResearchAddPiketWindow(Профили profil)
        {
            InitializeComponent();
            DataContext = this;
            Eq.ItemsSource = db.Оборудованияs.Local.ToList();
            Re.ItemsSource = db.Исследователиs.Local.ToList();
            this.Profile = profil;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (date.SelectedDate != null && Eq.SelectedItem != null && Re.SelectedItem != null && !string.IsNullOrEmpty(x.Text) && !string.IsNullOrEmpty(y.Text) && !string.IsNullOrEmpty(value.Text))
            {
                Piket.Дата = DateOnly.FromDateTime(date.SelectedDate.Value);
                Piket.IdПрофиляNavigation = Profile;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Что-то введено неверно");
            }
        }
    }
}
