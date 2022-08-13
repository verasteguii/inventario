using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace inventarioIMG
{
    public partial class BuscarDevoluciones : Form
    {
        BD.BDDevoluciones devoluciones = new BD.BDDevoluciones();
        BD.BDLogin BDlogn = new BD.BDLogin();
        public BuscarDevoluciones()
        {
            InitializeComponent();
        }

        private void BuscarDevoluciones_Load(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(LabelUsuario);
            devoluciones.MostrarDevoluciones(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // devoluciones.MostrarDevolucionesXFolio(dataGridView1, textfolio.Text);
        }

        private void textproducto_TextChanged(object sender, EventArgs e)
        {
            //devoluciones.MostrarDevolucionesXProducto(dataGridView1, textproducto.Text);
        }

        private void textfolio_Leave(object sender, EventArgs e)
        {
            //textproducto.Text = ""; 
            devoluciones.MostrarDevolucionesXFolio(dataGridView1, textfolio.Text);
        }



        private void textfolio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
