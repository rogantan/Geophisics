using Geophisics.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AdminProjectsWindow.xaml
    /// </summary>
    public partial class AdminProjectsWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Проекты> Projects { get => db.Проектыs.Local.ToObservableCollection(); }
        public AdminProjectsWindow()
        {
            InitializeComponent();
            PROJECTS.ItemsSource = Projects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminAddProjectWindow adminAddProjectWindow = new AdminAddProjectWindow();
            if (adminAddProjectWindow.ShowDialog() != true) return;
            db.Проектыs.Add(adminAddProjectWindow.Project);
            db.SaveChanges();
            PROJECTS.Items.Refresh();
            MessageBox.Show("Проект добавлен!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var project = PROJECTS.SelectedItem as Проекты;
            if (project != null )
            {
                AdminAddProjectWindow adminAddProjectWindow = new AdminAddProjectWindow() { Project = project };    
                if (adminAddProjectWindow.ShowDialog() == true)
                {
                    db.Entry(adminAddProjectWindow.Project).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Проект изменен");
                }
            }
            else
            {
                MessageBox.Show("Выберите проект");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var project = PROJECTS.SelectedItem as Проекты;
            if (project != null)
            {
                List<Площади> plozhes = db.Площадиs.Where(x => x.IdПроектаNavigation.Id  == project.Id).ToList();
                List<Профили> profilies;
                foreach (var plozh in plozhes)
                {
                    var plozh_tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
                    db.RemoveRange(plozh_tochki);

                    profilies = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();

                    foreach (var profil in profilies)
                    {
                        var profil_tochki = db.КоординатыПрофиляs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
                        db.КоординатыПрофиляs.RemoveRange(profil_tochki);
                        var pikets = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
                        db.Измеренияs.RemoveRange(pikets);
                    }
                    db.RemoveRange(profilies);

                }
                db.RemoveRange(plozhes);
                db.Remove(project);
                db.SaveChanges();
                MessageBox.Show("Проект удален");
            }
            else
            {
                MessageBox.Show("Выберите проект");
            }
        }
    }
}
