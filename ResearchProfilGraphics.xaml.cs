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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Geophisics.Models;

namespace Geophisics
{
    /// <summary>
    /// Interaction logic for ResearchProfilGraphics.xaml
    /// </summary>
    public partial class ResearchProfilGraphics : Window
    {
        public PlotModel MyModel { get; private set; }
        Database db = Database.getInstance();
        public ResearchProfilGraphics(Профили profil)
        {
            InitializeComponent();
            DataContext = this;
            this.MyModel = new PlotModel { Title = "Площадь" };
            List<КоординатыПрофиля> tochki = db.КоординатыПрофиляs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
            var lineSeries = new LineSeries
            {
                Title = "Значения",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Black
            };
            foreach (var tochka in tochki)
            {
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(tochka.X), Convert.ToDouble(tochka.Y)));
            }
            MyModel.Series.Add(lineSeries);
        }
    }
}
