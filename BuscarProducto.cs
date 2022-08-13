using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpreadsheetLight;


namespace inventarioIMG
{
    public partial class BuscarProducto : Form
    {

        BD.BDProducto producto = new BD.BDProducto();
        BD.BDLogin BDlogn = new BD.BDLogin();
        public BuscarProducto()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(LabelUsuario);
            producto.MostrarProductos(dataGridView1);
            producto.Categorias(cmbCategoria);
            producto.VerProductos(cmbProductos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbProductos.Text = "";
            cmbCategoria.Text = "";
            producto.MostrarProductos(dataGridView1);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbProductos_TextChanged(object sender, EventArgs e)
        {
            producto.VerProducto(cmbProductos, dataGridView1);
        }

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            cmbProductos.Text = "";
            producto.MostrarProductoXCategoria(cmbCategoria, dataGridView1);
            producto.VerProductosXCategoria(cmbProductos, cmbCategoria);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SLDocument s1 = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.Bold = true;
            style.Font.FontColor = System.Drawing.Color.FromArgb(30, 79, 135);



            int columna = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                s1.SetCellValue(1, columna, column.HeaderText.ToString());
                s1.SetCellStyle(1, columna, style);
                columna++;
            }

            int fila = 2;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                s1.SetCellValue(fila, 1, row.Cells[0].Value.ToString());
                s1.SetCellValue(fila, 2, row.Cells[1].Value.ToString());
                s1.SetCellValue(fila, 3, row.Cells[2].Value.ToString());
                s1.SetCellValue(fila, 4, row.Cells[3].Value.ToString());
                fila++;
            }

            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "Guardar archivo";
            SaveFileDialog1.CheckPathExists = true;
            SaveFileDialog1.DefaultExt = "xlsx";
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    s1.SaveAs(SaveFileDialog1.FileName);
                    MessageBox.Show("Archivo exportado con exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProductos_KeyPress(object sender, KeyPressEventArgs e)
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
