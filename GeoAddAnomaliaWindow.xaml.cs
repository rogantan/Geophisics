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
    /// Interaction logic for GeoAddAnomaliaWindow.xaml
    /// </summary>
    public partial class GeoAddAnomaliaWindow : Window
    {
        public Аномалии Anomalia { get; set; } = new Аномалии();
        Database db = Database.getInstance();
        public string Login { get; set; }
        public GeoAddAnomaliaWindow(string login)
        {
            InitializeComponent();
            DataContext = this;
            this.Login = login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (naz.Text != null && opis.Text != null)
            {
                Геофизики? geo = db.Геофизикиs.Where(x => x.Логин == Login).FirstOrDefault() as Геофизики;
                if (geo != null)
                {
                    Anomalia.IdГеофизикаNavigation = geo;
                }
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Что-то не введено");
            }
        }
    }
}
