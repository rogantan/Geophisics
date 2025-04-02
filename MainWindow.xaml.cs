using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Geophisics;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AdminProjectsWindow adminProjectsWindow = new AdminProjectsWindow();
        adminProjectsWindow.Show();
        this.Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        AdminCustomersWindow adminCustomersWindow = new AdminCustomersWindow();
        adminCustomersWindow.Show();
        this.Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        AdminSearchersWindow adminSearchersWindow = new AdminSearchersWindow(); 
        adminSearchersWindow.Show();
        this.Close();
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        AdminGeosWindow adminGeosWindow = new AdminGeosWindow();
        adminGeosWindow.Show();
        this.Close();
    }
}