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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PoulaillerMaquette.View;

namespace PoulaillerMaquette
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_home_Click(object sender, RoutedEventArgs e)
        {
            window_container.Children.Clear();
            uc_home my_home = new uc_home();
            window_container.Children.Add(my_home);
        }

        private void BTN_gest_Click(object sender, RoutedEventArgs e)
        {
            window_container.Children.Clear();
            uc_config my_config = new uc_config();
            window_container.Children.Add(my_config);
        }

        private void BTN_cfg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_info_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
