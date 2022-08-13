using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace inventarioIMG
{
    public partial class BajaProductos : Form
    {
        BD.BDProducto producto = new BD.BDProducto();
        BD.BDLogin BDlogn = new BD.BDLogin();

        public BajaProductos()
        {
            InitializeComponent();
        }

        private void BajaProductos_Load(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(LabelUsuario);
            producto.VerProductos(cmbProducto);
            producto.MostrarProductos(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producto.BajaProductos(cmbProducto);
            producto.VerProductos(cmbProducto);
            producto.MostrarProductos(dataGridView1);
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
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

