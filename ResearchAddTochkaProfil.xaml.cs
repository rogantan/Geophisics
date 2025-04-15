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
    /// Interaction logic for ResearchAddTochkaProfil.xaml
    /// </summary>
    public partial class ResearchAddTochkaProfil : Window
    {
        public КоординатыПрофиля Tochka { get; set; } = new КоординатыПрофиля();
        Профили Profil {  get; set; }
        public ResearchAddTochkaProfil(Профили profil)
        {
            InitializeComponent();
            DataContext = this;
            this.Profil = profil;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (x.Text != null && y.Text != null)
            {
                Tochka.IdПрофиляNavigation = Profil;
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
