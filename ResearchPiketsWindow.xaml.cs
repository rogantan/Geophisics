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
    /// Interaction logic for ResearchPiketsWindow.xaml
    /// </summary>
    public partial class ResearchPiketsWindow : Window
    {
        Database db = Database.getInstance();
        public List<Измерения> pikets {  get; set; }
        Профили Profil {  get; set; }
        public ResearchPiketsWindow(Профили profil)
        {
            InitializeComponent();
            pikets = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
            PIKETS.ItemsSource = pikets;
            this.Profil = profil;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResearchAddPiketWindow researchAddPiketWindow = new ResearchAddPiketWindow(Profil);
            if (researchAddPiketWindow.ShowDialog() != true) return;
            db.Измеренияs.Add(researchAddPiketWindow.Piket);
            db.SaveChanges();
            pikets = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == Profil.Id).ToList();
            PIKETS.ItemsSource = pikets;
            MessageBox.Show("Пикет добавлен");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ItogGraphicsWindow g = new ItogGraphicsWindow();    
            g.ShowDialog();
        }
    }
}
