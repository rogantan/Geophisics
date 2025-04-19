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
    /// Interaction logic for CustomerProfiliesWindow.xaml
    /// </summary>
    public partial class CustomerProfiliesWindow : Window
    {
        Database db = Database.getInstance();
        public CustomerProfiliesWindow(Площади plozh)
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
                CustomerPiketsWindow customerPiketsWindow = new CustomerPiketsWindow(profil);
                customerPiketsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }
    }
}
