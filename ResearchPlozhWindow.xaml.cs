using Geophisics.Models;
using System.Windows;

namespace Geophisics
{
    /// <summary>
    /// Interaction logic for ResearchPlozhWindow.xaml
    /// </summary>
    public partial class ResearchPlozhWindow : Window
    {
        Database db = Database.getInstance();
        Проекты Project { get; set; }
        List<Площади> Plozhes;
        public ResearchPlozhWindow(Проекты project)
        {
            InitializeComponent();
            this.Project = project;
            Plozhes = db.Площадиs.Where(x => x.IdПроектаNavigation.Id == project.Id).ToList();
            PLOZHES.ItemsSource = Plozhes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Площади площади = new Площади();
            площади.IdПроектаNavigation = Project;
            db.Площадиs.Add(площади);
            db.SaveChanges();
            Plozhes = db.Площадиs.Where(x => x.IdПроектаNavigation.Id == Project.Id).ToList();
            PLOZHES.ItemsSource = Plozhes;
            MessageBox.Show("Площадь добавлена");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var square = PLOZHES.SelectedItem as Площади;
            ResearchAddTochkaPlozh researchAddTochkaPlozh = new ResearchAddTochkaPlozh(square);
            if (square != null)
            {
                if (researchAddTochkaPlozh.ShowDialog() != true) return;
                db.КоординатыПлощадиs.Add(researchAddTochkaPlozh.Tochka);
                db.SaveChanges();
                MessageBox.Show("Координата площади добавлена!");
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var plozh = PLOZHES.SelectedItem as Площади;
            if (plozh != null)
            {
                ResearchProfiliesWindow researchPiketsWindow = new ResearchProfiliesWindow(plozh);
                researchPiketsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var square = PLOZHES.SelectedItem as Площади;
            if (square != null)
            {
                ResearchTochkiPlozhWindow researchTochkiPlozhWindow = new ResearchTochkiPlozhWindow(square);
                researchTochkiPlozhWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var square = PLOZHES.SelectedItem as Площади;
            if ( square != null)
            {
                List<КоординатыПлощади> tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == square.Id).ToList();
                foreach (var tochka in tochki)
                {
                    db.КоординатыПлощадиs.Remove(tochka);
                    db.SaveChanges();
                }
                db.Площадиs.Remove(square);
                db.SaveChanges();
                Plozhes = db.Площадиs.Where(x => x.IdПроектаNavigation.Id == Project.Id).ToList();
                PLOZHES.ItemsSource = Plozhes;
                MessageBox.Show("Площадь удалена!");
            }
            else
            {
                MessageBox.Show("Выберите площадь");
            }
        }
    }
}
