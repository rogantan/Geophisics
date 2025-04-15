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
        Площади Plozh { get; set; }
        public ResearchProfiliesWindow(Площади plozh)
        {
            InitializeComponent();
            Squers = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
            PROFILI.ItemsSource = Squers;
            this.Plozh = plozh;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResearchAddProfilWindow researchAddProfilWindow = new ResearchAddProfilWindow(Plozh);
            if (researchAddProfilWindow.ShowDialog() != true) return;
            db.Профилиs.Add(researchAddProfilWindow.Profil);
            db.SaveChanges();
            Squers = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == Plozh.Id).ToList();
            PROFILI.ItemsSource = Squers;
            MessageBox.Show("Профиль добавлен!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Profil = PROFILI.SelectedItem as Профили;
            if ( Profil != null )
            {
                ResearchTochkiProfilWindow researchTochkiProfilWindow = new ResearchTochkiProfilWindow(Profil);
                researchTochkiProfilWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var profil = PROFILI.SelectedItem as Профили;
            if ( profil != null )
            {
                ResearchAddTochkaProfil researchAddTochkaProfil = new ResearchAddTochkaProfil(profil);
                if (researchAddTochkaProfil.ShowDialog() != true) return;
                db.КоординатыПрофиляs.Add(researchAddTochkaProfil.Tochka);
                db.SaveChanges();
                MessageBox.Show("Координата профиля добавлена");
            }
            else
            {
                MessageBox.Show("Выберите профиль");
            }
        }
    }
}
