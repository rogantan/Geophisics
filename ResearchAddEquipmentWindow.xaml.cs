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
    /// Interaction logic for ResearchAddEquipmentWindow.xaml
    /// </summary>
    public partial class ResearchAddEquipmentWindow : Window
    {
        public Оборудования Equipment { get; set; } = new Оборудования();
        public ResearchAddEquipmentWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Equipment.Название) && Equipment.ДатаКалибровки != null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Что-то введено неверно");
            }
        }
    }
}
