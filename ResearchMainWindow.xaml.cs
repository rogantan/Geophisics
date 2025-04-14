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
    /// Interaction logic for ResearchMainWindow.xaml
    /// </summary>
    public partial class ResearchMainWindow : Window
    {
        public ResearchMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResearchProjectsWindow researchProjectsWindow = new ResearchProjectsWindow();
            this.Close();
            researchProjectsWindow.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResearchEquipmentsWindow researchEquipmentsWindow = new ResearchEquipmentsWindow();
            this.Close();
            researchEquipmentsWindow.Show();
        }
    }
}
