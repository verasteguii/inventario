using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace inventarioIMG
{
    public partial class ModificarProductos : Form
    {
        BD.BDProducto producto = new BD.BDProducto();
        BD.BDLogin BDlogn = new BD.BDLogin();

        public ModificarProductos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModificarProductos_Load(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(LabelUsuario);
            producto.VerProductos(cmbprod);
            producto.MostrarProductos(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbprod.Text!="" && textproducto.Text!="" && textcategoria.Text!="" && textprecio.Text!="" && textstock.Text!="")
            { 
                producto.ModificarProductos(textproducto.Text, textcategoria.Text, textprecio.Text, textstock.Text, cmbprod);
                producto.MostrarProductos(dataGridView1);
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }

        private void cmbprod_TextChanged(object sender, EventArgs e)
        {
            producto.llenarXActualizar(textproducto, textcategoria, textprecio, textstock, cmbprod);
        }

        private void textprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46;
            char retroceso = (char)8;
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == signo_decimal)
            {
                if (textprecio.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void cmbprod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
