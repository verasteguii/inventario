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
    public partial class AltaProductos : Form
    {
        BD.BDProducto producto = new BD.BDProducto();
        BD.BDLogin BDlogn = new BD.BDLogin();
        public AltaProductos()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            textnombre.Text = "";
            textprecio.Text = "";
            textcategoria.Text = "";
            textcantidad.Text = "";
            textModProd.Text = "";
            textModPrecio.Text = "";
            textModCategoria.Text = "";
            textModStock.Text = "";
            cmbModProd.Text = "";
            cmbeliminarprod.Text = "";
        }
        private void AltaProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AltaProductos_Load_1(object sender, EventArgs e)
        {
            BDlogn.MostrarUsuario(labelUsuario);
            producto.MostrarProductos(dataGridView1);
            producto.VerProductos(cmbModProd);
            producto.VerProductos(cmbeliminarprod);
            producto.Categorias(cmbBuscarProd);
            producto.VerProductos(cmbBuscarProducto);

        }



        private void textcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char retroceso = (char)8;
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if(e.KeyChar == retroceso)
            {
              e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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





        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            producto.MostrarProductos(dataGridView1);
            groupMod.Visible = false;
            groupEliminar.Visible = false;
            groupBuscar.Visible = false;
            saveToolStripButton.Enabled = true;
            groupAlta.Visible = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(groupAlta.Visible==true)
            { 
                if (textnombre.Text != "" && textprecio.Text != "" && textcantidad.Text != "" && textcategoria.Text != "")
                {
                    producto.AgregarProducto(textnombre.Text, textcategoria.Text, textprecio.Text, textcantidad.Text);
                    producto.MostrarProductos(dataGridView1);
                    textnombre.Text = "";
                    textcategoria.Text = "";
                    textcantidad.Text = "";
                    textprecio.Text = "";
                }
                else
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
            }
            else if(groupMod.Visible==true)
            {
                if (cmbModProd.Text != "" && textModProd.Text != "" && textModCategoria.Text != "" && textModPrecio.Text != "" && textModStock.Text != "")
                {
                    producto.ModificarProductos(textModProd.Text, textModCategoria.Text, textModPrecio.Text, textModStock.Text, cmbModProd);
                    producto.MostrarProductos(dataGridView1);
                }
                else
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
            }
            else if(groupEliminar.Visible==true)
            {
                if(cmbeliminarprod.Text!="")
                { 
                    producto.BajaProductos(cmbeliminarprod);
                    producto.VerProductos(cmbeliminarprod);
                    producto.MostrarProductos(dataGridView1);
                }
                else
                {
                    MessageBox.Show("No se ha ingresado el producto a eliminar");
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una acción por realizar");
            }
            Limpiar();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            producto.MostrarProductos(dataGridView1);
            groupAlta.Visible = false;
            groupEliminar.Visible = false;
            groupBuscar.Visible = false;
            saveToolStripButton.Enabled = true;
            groupMod.Visible = true;

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            producto.llenarXActualizar(textModProd, textModCategoria, textModPrecio, textModStock, cmbModProd);
        }

        private void textModPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            producto.MostrarProductos(dataGridView1);
            groupAlta.Visible = false;
            groupMod.Visible = false;
            groupBuscar.Visible = false;
            saveToolStripButton.Enabled = true;
            groupEliminar.Visible = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupAlta_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBuscarProd_TextChanged(object sender, EventArgs e)
        {
            cmbBuscarProducto.Text = "";
            producto.MostrarProductoXCategoria(cmbBuscarProd, dataGridView1);
            producto.VerProductosXCategoria(cmbBuscarProducto, cmbBuscarProd);
        }

        private void cmbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            producto.VerProducto(cmbBuscarProducto, dataGridView1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupAlta.Visible = false;
            groupMod.Visible = false;
            groupEliminar.Visible = false;
            saveToolStripButton.Enabled = false;
            groupBuscar.Visible = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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


    }
}
