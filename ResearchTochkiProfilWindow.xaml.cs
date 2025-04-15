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
    }
}
