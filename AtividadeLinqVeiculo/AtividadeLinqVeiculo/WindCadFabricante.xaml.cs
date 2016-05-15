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

namespace AtividadeLinqVeiculo
{
    /// <summary>
    /// Interaction logic for WindCadFabricante.xaml
    /// </summary>
    public partial class WindCadFabricante : Window
    {
        public WindCadFabricante()
        {
            InitializeComponent();
        }
        LojaDataContext d = new LojaDataContext();
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = (from f in d.Fabricantes select f).ToList();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var x =(from z in d.Fabricantes select z).ToList();
            if (!x.Exists(a=> a.id == int.Parse(txtId.Text))) { 
            Fabricante f = new Fabricante();
            f.id = int.Parse(txtId.Text);
            f.Descricao = txtDesc.Text;
            d.Fabricantes.InsertOnSubmit(f);
            d.SubmitChanges();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var x = (from z in d.Fabricantes select z).ToList();
            if (x.Exists(a => a.id == int.Parse(txtId.Text))) { 
                Fabricante c = (from f in d.Fabricantes where f.id == int.Parse(txtId.Text) select f).Single();
            d.Fabricantes.DeleteOnSubmit(c);
            d.SubmitChanges();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var x = (from z in d.Fabricantes select z).ToList();
            if (x.Exists(a => a.id == int.Parse(txtId.Text)))
            {
                Fabricante c = (from f in d.Fabricantes where f.id == int.Parse(txtId.Text) select f).Single();
                c.Descricao = txtDesc.Text;
                d.SubmitChanges();
            }
        }
    }
}
