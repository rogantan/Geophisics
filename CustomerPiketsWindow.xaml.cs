﻿using Geophisics.Models;
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
    /// Interaction logic for CustomerPiketsWindow.xaml
    /// </summary>
    public partial class CustomerPiketsWindow : Window
    {
        Database db = Database.getInstance();
        public Профили Profil {  get; set; }
        public CustomerPiketsWindow(Профили profil)
        {
            InitializeComponent();
            this.Profil = profil;
            PIKETS.ItemsSource = db.Измеренияs.Where(x => x.IdПрофиляNavigation.Id == profil.Id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ItogGraphicsWindow g = new ItogGraphicsWindow(Profil);
            g.ShowDialog();
        }
    }
}
