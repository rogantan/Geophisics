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
    /// Interaction logic for GeoProfiliesWindow.xaml
    /// </summary>
    public partial class GeoProfiliesWindow : Window
    {
        Database db = Database.getInstance();
        public GeoProfiliesWindow(Площади plozh)
        {
            InitializeComponent();
            PROFILI.ItemsSource = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var profil = PROFILI.SelectedItem as Профили;
            if (profil != null)
            {
                ResearchProfilGraphics researchProfilGraphics = new ResearchProfilGraphics(profil);
                researchProfilGraphics.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var profil = PROFILI.SelectedItem as Профили;
            if (profil != null)
            {
                GeoPiketsWindow geoPiketsWindow = new GeoPiketsWindow(profil);
                geoPiketsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }
    }
}
