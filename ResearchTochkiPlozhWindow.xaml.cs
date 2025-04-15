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
    /// Interaction logic for ResearchTochkiPlozhWindow.xaml
    /// </summary>
    public partial class ResearchTochkiPlozhWindow : Window
    {
        Database db = Database.getInstance();
        public List<КоординатыПлощади> tochki {  get; set; }
        public ResearchTochkiPlozhWindow(Площади square)
        {
            InitializeComponent();
            tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == square.Id).ToList();
            TOCHKI.ItemsSource = tochki;
        }
    }
}
