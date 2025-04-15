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
    /// Interaction logic for ResearchAddTochkaPlozh.xaml
    /// </summary>
    public partial class ResearchAddTochkaPlozh : Window
    {
        public КоординатыПлощади Tochka { get; set; } = new КоординатыПлощади();
        Площади Square { get; set; }
        public ResearchAddTochkaPlozh(Площади square)
        {
            InitializeComponent();
            DataContext = this;
            this.Square = square;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (x.Text != null && y.Text != null)
            {
                Tochka.IdПлощадиNavigation = Square;
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
