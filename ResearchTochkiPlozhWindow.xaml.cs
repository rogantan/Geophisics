using Geophisics.Models;
using Microsoft.EntityFrameworkCore;
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
        Площади Square { get; set; }
        public ResearchTochkiPlozhWindow(Площади square)
        {
            InitializeComponent();
            this.Square = square;
            tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == square.Id).ToList();
            TOCHKI.ItemsSource = tochki;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tochka = TOCHKI.SelectedItem as КоординатыПлощади;
            if (tochka != null )
            {
                ResearchAddTochkaPlozh researchAddTochkaPlozh = new ResearchAddTochkaPlozh(tochka.IdПлощадиNavigation) { Tochka = tochka };
                if (researchAddTochkaPlozh.ShowDialog() == true )
                {
                    db.Entry(researchAddTochkaPlozh.Tochka).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Точка изменена");
                }
            }
            else
            {
                MessageBox.Show("Выберите точку");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tochka = TOCHKI.SelectedItem as КоординатыПлощади;
            if (tochka != null)
            {
                db.КоординатыПлощадиs.Remove(tochka);   
                db.SaveChanges();
                tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == Square.Id).ToList();
                TOCHKI.ItemsSource = tochki;
                MessageBox.Show("Точка удалена");
            }
            else
            {
                MessageBox.Show("Выберите точку");
            }
        }
    }
}
