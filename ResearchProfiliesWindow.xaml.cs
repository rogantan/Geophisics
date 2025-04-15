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
    /// Interaction logic for ResearchProfiliesWindow.xaml
    /// </summary>
    public partial class ResearchProfiliesWindow : Window
    {
        Database db = Database.getInstance();
        public List<Профили> Squers {  get; set; }
        public ResearchProfiliesWindow(Площади plozh)
        {
            InitializeComponent();
            Squers = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
            PROFILI.ItemsSource = Squers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var profil = PROFILI.SelectedItem as Профили;
            if (profil != null )
            {
                ResearchPiketsWindow researchPiketsWindow = new ResearchPiketsWindow(profil);
                researchPiketsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }
    }
}
