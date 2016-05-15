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

namespace AtividadeLinqVeiculo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CadVeiculosClick(object sender, RoutedEventArgs e)
        {
            WindCadVeiculo w = new WindCadVeiculo();
            w.Show();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {

        }

        private void CadFabricantesClick(object sender, RoutedEventArgs e)
        {
            WindCadFabricante w = new WindCadFabricante();
            w.Show();
        }

        private void ConsVeiculosClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
