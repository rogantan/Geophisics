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
    /// Interaction logic for AdminCustomersWindow.xaml
    /// </summary>
    public partial class AdminCustomersWindow : Window
    {
        Database db = Database.getInstance();
        public ObservableCollection<Заказчики> customers { get => db.Заказчикиs.Local.ToObservableCollection(); }
        public AdminCustomersWindow()
        {
            InitializeComponent();
            CUSTOMERS.ItemsSource = customers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminAddCustomerWindow adminAddCustomerWindow = new AdminAddCustomerWindow();
            if (adminAddCustomerWindow.ShowDialog() != true) return;
            db.Заказчикиs.Add(adminAddCustomerWindow.Customer);
            db.SaveChanges();
            CUSTOMERS.Items.Refresh();
            MessageBox.Show("Заказчик добавлен!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var customer = CUSTOMERS.SelectedItem as Заказчики;
            if (customer != null )
            {
                AdminAddCustomerWindow adminAddCustomerWindow = new AdminAddCustomerWindow() { Customer = customer };
                if (adminAddCustomerWindow.ShowDialog() == true)
                {
                    db.Entry(adminAddCustomerWindow.Customer).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Заказчик изменен");
                }
            }
            else
            {
                MessageBox.Show("Выберите заказчика");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var customer = CUSTOMERS.SelectedItem as Заказчики;
            if (customer != null)
            {
                List<Проекты> projects = db.Проектыs.Where(x => x.IdЗаказчикаNavigation.Id == customer.Id).ToList();
                foreach (var project in projects)
                {
                    var plozhes = db.Площадиs.Where(x => x.IdПроектаNavigation.Id == project.Id).ToList();

                    foreach (var plozh in plozhes)
                    {
                        var plozh_tochki = db.КоординатыПлощадиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
                        db.КоординатыПлощадиs.RemoveRange(plozh_tochki);
                        var profili = db.Профилиs.Where(x => x.IdПлощадиNavigation.Id == plozh.Id).ToList();
                        foreach (var profil in profili)
                        {
                            var profil_tochki = db.КоординатыПрофиляs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
                            db.КоординатыПрофиляs.RemoveRange(profil_tochki);
                            var pikets = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
                            db.Измеренияs.RemoveRange(pikets);
                        }
                        db.Профилиs.RemoveRange(profili);
                    }
                    db.Площадиs.RemoveRange(plozhes);
                }
                db.Проектыs.RemoveRange(projects);
                db.Заказчикиs.Remove(customer);
                db.SaveChanges();
                MessageBox.Show("Заказчик удален");
            }
            else
            {
                MessageBox.Show("Выберите заказчика");
            }
        }
    }
}
