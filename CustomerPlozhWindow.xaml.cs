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
    /// Interaction logic for CustomerPlozhWindow.xaml
    /// </summary>
    public partial class CustomerPlozhWindow : Window
    {
        Database db = Database.getInstance();
        public CustomerPlozhWindow(Проекты project)
        {
            InitializeComponent();
            PLOZHES.ItemsSource = db.Площадиs.Where(x => x.IdПроектаNavigation.Id == project.Id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var plozh = PLOZHES.SelectedItem as Площади;
            if (plozh != null)
            {
                ResearchPlozhGraphicsWindow researchPlozhGraphicsWindow = new ResearchPlozhGraphicsWindow(plozh);
                researchPlozhGraphicsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var plozh = PLOZHES.SelectedItem as Площади;
            if (plozh != null)
            {
                CustomerProfiliesWindow customerProfiliesWindow = new CustomerProfiliesWindow(plozh);
                customerProfiliesWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }
    }
}
