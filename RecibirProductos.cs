using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace inventarioIMG
{
    public partial class RecibirProductos : Form
    {
        BD.BDProducto producto = new BD.BDProducto();
        BD.BDRecibirProductos recibirproducto = new BD.BDRecibirProductos();
        BD.BDLogin BDlogn = new BD.BDLogin();
        public RecibirProductos()
        {
            InitializeComponent();
        }

        private void RecibirProductos_Load(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(LabelUsuario);
            producto.MostrarProductos(dataGridView1);
            producto.Categorias(cmbcategoria);
            producto.VerProductos(cmbproducto);
        }

        private void cmbcategoria_TextChanged(object sender, EventArgs e)
        {
            cmbproducto.Text = "";
            producto.MostrarProductoXCategoria(cmbcategoria, dataGridView1);
            producto.VerProductosXCategoria(cmbproducto, cmbcategoria);
        }

        private void cmbproducto_TextChanged(object sender, EventArgs e)
        {
            producto.VerProducto(cmbproducto, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbcategoria.Text!="" && cmbproducto.Text!="" && textcantidad.Text!="")
            {
                recibirproducto.AgregarStock(cmbproducto, textcantidad.Text);
                producto.VerProducto(cmbproducto, dataGridView1);
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos para poder agregar productos a stock");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbcategoria.Text = "";
            cmbproducto.Text = "";
            textcantidad.Text = "";
            producto.MostrarProductos(dataGridView1);
        }

        private void textcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char retroceso = (char)8;
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == retroceso)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
