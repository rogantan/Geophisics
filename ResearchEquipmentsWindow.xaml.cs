using Geophisics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ResearchEquipmentsWindow.xaml
    /// </summary>
    public partial class ResearchEquipmentsWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Оборудования> equipments { get => db.Оборудованияs.Local.ToObservableCollection(); }
        public ResearchEquipmentsWindow()
        {
            InitializeComponent();
            EQUIPMENTS.ItemsSource = equipments;    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResearchMainWindow researchMainWindow = new ResearchMainWindow();
            researchMainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
