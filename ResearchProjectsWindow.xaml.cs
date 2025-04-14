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
    /// Interaction logic for ResearchProjectsWindow.xaml
    /// </summary>
    public partial class ResearchProjectsWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Проекты> Projects { get => db.Проектыs.Local.ToObservableCollection(); }
        public ResearchProjectsWindow()
        {
            InitializeComponent();
            PROJECTS.ItemsSource = Projects;
        }

        private void PROJECTS_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("jefhenj");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Project = PROJECTS.SelectedItem as Проекты;
            if (Project != null)
            {
                ResearchPlozhWindow win = new ResearchPlozhWindow(Project);
                win.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResearchMainWindow researchMainWindow = new ResearchMainWindow();
            researchMainWindow.Show();
            this.Close();
        }
    }
}
