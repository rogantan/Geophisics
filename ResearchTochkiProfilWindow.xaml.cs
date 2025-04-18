using Geophisics.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ResearchTochkiProfilWindow.xaml
    /// </summary>
    public partial class ResearchTochkiProfilWindow : Window
    {
        Database db = Database.getInstance();
        public List<КоординатыПрофиля> Tochki { get; set; }
        public ResearchTochkiProfilWindow(Профили profil)
        {
            InitializeComponent();
            Tochki = db.КоординатыПрофиляs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
            TOCHKI.ItemsSource = Tochki;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tochka = TOCHKI.SelectedItem as КоординатыПрофиля;
            if (tochka != null )
            {
                ResearchAddTochkaProfil researchAddTochkaProfil = new ResearchAddTochkaProfil(tochka.IdПрофиляNavigation) { Tochka = tochka };
                if (researchAddTochkaProfil.ShowDialog() == true )
                {
                    db.Entry(researchAddTochkaProfil.Tochka).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Точка изменена");
                }
            }
            else
            {
                MessageBox.Show("Выберите точку");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tochka = TOCHKI.SelectedItem as КоординатыПрофиля;
            if (tochka != null)
            {
                db.КоординатыПрофиляs.Remove(tochka);
                db.SaveChanges();
                MessageBox.Show("Точка удалена");
            }
            else
            {
                MessageBox.Show("Выберите точку");
            }
        }
    }
}
