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
    /// Interaction logic for ResearchAddProfilWindow.xaml
    /// </summary>
    public partial class ResearchAddProfilWindow : Window
    {
        public Профили Profil {  get; set; } = new Профили();
        Площади Plozh {  get; set; }
        public ResearchAddProfilWindow(Площади plozh)
        {
            InitializeComponent();
            DataContext = this;
            this.Plozh = plozh;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (napr.Text != null && dlin.Text != null)
            {
                Profil.IdПлощадиNavigation = Plozh;
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то не введено");
            }
        }
    }
}
