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
    /// Interaction logic for WindCadVeiculo.xaml
    /// </summary>
    public partial class WindCadVeiculo : Window
    {
        public WindCadVeiculo()
        {
            InitializeComponent();
            SelectFabricantes();
            
        }

        public void SelectFabricantes()
        {
            var x = (from f in dc.Fabricantes
                    orderby f.Descricao
                    select f).ToList();
            comboBox.ItemsSource = x;
            comboBox.DisplayMemberPath = "Descricao";
            comboBox.SelectedValuePath = "id";
        }

        LojaDataContext dc = new LojaDataContext();

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var x = (from f in dc.Veiculos select f).ToList();
            if(!x.Exists(a=> a.id == int.Parse(txtID.Text)))
            {
                Veiculo v = new Veiculo();
                v.id = int.Parse(txtID.Text);
                v.Modelo = txtMod.Text;
                v.IdFabricante = (int)comboBox.SelectedValue;
                v.Ano = int.Parse(txtAno.Text);
                v.ValorCompra = Convert.ToDecimal(txtVC.Text);
                v.ValorVenda = Convert.ToDecimal(txtVV.Text);
                v.PrecoVenda = Convert.ToDecimal(txtPVenda.Text);
                v.DataCompra = data1.SelectedDate;
                v.DataVenda = data2.SelectedDate;
                dc.Veiculos.InsertOnSubmit(v);
                dc.SubmitChanges();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var x = (from f in dc.Veiculos select f).ToList();
            if (x.Exists(a => a.id == int.Parse(txtID.Text)))
            {
                Veiculo v = (from f in dc.Veiculos where f.id == int.Parse(txtID.Text) select f).Single();
                dc.Veiculos.DeleteOnSubmit(v);
                dc.SubmitChanges();
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            //var r = (from f in dc.Veiculos select f).ToList();
            var r = from v in dc.Veiculos select new { v.id, v.Modelo, v.Ano, v.Fabricante.Descricao, v.DataCompra, v.PrecoVenda };
            dataGrid.ItemsSource = r;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var x = (from f in dc.Veiculos select f).ToList();
            if (x.Exists(a => a.id == int.Parse(txtID.Text)))
            {
                Veiculo v = (from f in dc.Veiculos where f.id == int.Parse(txtID.Text) select f).Single();
                v.id = int.Parse(txtID.Text);
                v.Modelo = txtMod.Text;
                v.IdFabricante = Convert.ToInt16(comboBox.SelectedValue);
                v.Ano = int.Parse(txtAno.Text);
                v.ValorCompra = Convert.ToDecimal(txtVC.Text);
                v.ValorVenda = Convert.ToDecimal(txtVV.Text);
                v.PrecoVenda = Convert.ToDecimal(txtPVenda.Text);
                v.DataCompra = data1.SelectedDate;
                v.DataVenda = data2.SelectedDate;
                dc.SubmitChanges();
            }
        }
    }
}
