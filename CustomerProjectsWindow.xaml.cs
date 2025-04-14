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
    /// Interaction logic for CustomerProjectsWindow.xaml
    /// </summary>
    public partial class CustomerProjectsWindow : Window
    {
        Database db = Database.getInstance();
        //public List<Проекты> Projects { get => db.Проектыs.Local.ToList(); }
        public CustomerProjectsWindow(string Login)
        {
            InitializeComponent();
            List<Проекты> Projects = db.Проектыs.Where(x => x.IdЗаказчикаNavigation.Логин == Login).ToList();
            PROJECTS.ItemsSource = Projects;
        }
    }
}
