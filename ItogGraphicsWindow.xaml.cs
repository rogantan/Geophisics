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
using Geophisics.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Geophisics
{
    /// <summary>
    /// Interaction logic for ItogGraphicsWindow.xaml
    /// </summary>
    public partial class ItogGraphicsWindow : Window
    {
        public PlotModel MyModel { get; private set; }
        Database db = Database.getInstance();
        public ItogGraphicsWindow(Профили profil)
        {
            InitializeComponent();
            DataContext = this;
            this.MyModel = new PlotModel() { Title = "Измерения по профилю" };
            List<Измерения> tochki = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
            var lineSeries = new LineSeries
            {
                Title = "Значения",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Black
            };
            foreach (var tochka in tochki)
            {
                // Преобразуем DateOnly в DateTime
                DateTime dateTime = tochka.Дата.ToDateTime(TimeOnly.MinValue);
                // Добавляем точку на график
                lineSeries.Points.Add(new DataPoint(
                    DateTimeAxis.ToDouble(dateTime), // Преобразуем дату в double
                    Convert.ToDouble(tochka.Значение) // Преобразуем значение в double
                ));
            }

            // Добавляем серию на график
            MyModel.Series.Add(lineSeries);

            // Настройка осей
            MyModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Дата",
                StringFormat = "yyyy-MM-dd", // Формат отображения даты
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            MyModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Значение",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });
        }
    }
}
