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
    /// Interaction logic for ResearchEquipmentsWindow.xaml
    /// </summary>
    public partial class ResearchEquipmentsWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Оборудования> equipments { get => db.Оборудованияs.Local.ToObservableCollection(); }
        public ResearchEquipmentsWindow()
        {
            InitializeComponent();
            EQUIPMENTS.ItemsSource = equipments;    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResearchMainWindow researchMainWindow = new ResearchMainWindow();
            researchMainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResearchAddEquipmentWindow researchAddEquipmentWindow = new ResearchAddEquipmentWindow();
            if (researchAddEquipmentWindow.ShowDialog() != true)
            {
                return;
            }
            db.Оборудованияs.Add(researchAddEquipmentWindow.Equipment);
            db.SaveChanges();   
            EQUIPMENTS.Items.Refresh();
            MessageBox.Show("Оборудование добавлено");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var equipment = EQUIPMENTS.SelectedItem as Оборудования;
            if (equipment != null)
            {
                ResearchAddEquipmentWindow researchAddEquipmentWindow = new ResearchAddEquipmentWindow() { Equipment = equipment };
                if (researchAddEquipmentWindow.ShowDialog() == true)
                {
                    db.Entry(researchAddEquipmentWindow.Equipment).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Оборудование изменено");
                }
            }
            else
            {
                MessageBox.Show("Выберите оборудование");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var equipment = EQUIPMENTS.SelectedItem as Оборудования;
            if (equipment != null)
            {
                List<Измерения> pikets = db.Измеренияs.Where(x => x.IdОборудованияNavigation.Id == equipment.Id).ToList();
                db.RemoveRange(pikets); 
                db.Оборудованияs.Remove(equipment);
                db.SaveChanges();
                MessageBox.Show("Оборудование удалено");
            }
            else
            {
                MessageBox.Show("Выберите оборудование");
            }
        }
    }
}
