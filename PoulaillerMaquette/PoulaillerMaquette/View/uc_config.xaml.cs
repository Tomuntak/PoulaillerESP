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

using PoulaillerMaquette.DAO;

namespace PoulaillerMaquette.View
{
    /// <summary>
    /// Logique d'interaction pour uc_config.xaml
    /// </summary>
    public partial class uc_config : UserControl
    {
        DAOPoules daopoule;

        public uc_config()
        {
            InitializeComponent();
            daopoule = new DAOPoules();

        }

        private void BTN_AddPoule_Click(object sender, RoutedEventArgs e)
        {
            //daopoule.CreatePoule();
        }

        private void BTN_ConfPoule_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_DelPoule_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_AltPoule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
