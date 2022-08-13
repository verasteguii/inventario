using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace inventarioIMG.BD
{
    
    internal class BDProducto
    {
        private SqlConnection cn;
        private SqlCommand cmb;
        private SqlDataAdapter da;
        private DataTable dt;
        private SqlDataReader dr;

        private void Conectar()
        {
            try
            {
                cn = new SqlConnection("server=imagendb-xl.c0htsxrna0bd.us-west-2.rds.amazonaws.com ;database=inventario;uid=imagendentaldba ;pwd=2s2:W$GyqSF(*7,-;");
                cn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de Conexion", ex.ToString());
            }
        }

        private void Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexion" + ex.ToString());
            }
        }

       public void AgregarProducto(string nombre, string categoria,string precio, string cantidad)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("AltaProductos", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@nombre_producto", nombre));
                cmb.Parameters.Add(new SqlParameter("@categoria", categoria));
                cmb.Parameters.Add(new SqlParameter("@precio", Convert.ToDouble(precio)));
                cmb.Parameters.Add(new SqlParameter("@stock", Convert.ToInt32(cantidad)));
                cmb.ExecuteNonQuery();
                MessageBox.Show("Se inserto un nuevo producto");
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarProductos(DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarProductos", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["Nombre_Producto"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Categoria"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Stock"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void VerProductos(ComboBox producto)
        {
            try
            {
                Conectar();
                producto.Items.Clear();
                cmb = new SqlCommand("MostrarProductos", cn);
                cmb.CommandType = CommandType.StoredProcedure;

                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    producto.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void VerProductosXCategoria(ComboBox producto,ComboBox categoria)
        {
            try
            {
                Conectar();
                producto.Items.Clear();
                cmb = new SqlCommand("VerProductosXCategoria", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@categoria", Convert.ToString(categoria.SelectedItem)));

                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    producto.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void BajaProductos(ComboBox producto)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("BajaProductos", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                cmb.ExecuteNonQuery();
                Desconectar();
                MessageBox.Show("Se elimino el producto");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void ModificarProductos(string producto, string categoria, string precio, string cantidad, ComboBox prod)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("ModificarProductos", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", producto));
                cmb.Parameters.Add(new SqlParameter("@categoria", categoria));
                cmb.Parameters.Add(new SqlParameter("@precio", Convert.ToDouble(precio)));
                cmb.Parameters.Add(new SqlParameter("@stock", Convert.ToInt32(cantidad)));
                cmb.Parameters.Add(new SqlParameter("@prod", Convert.ToString(prod.SelectedItem)));
                cmb.ExecuteNonQuery();
                Desconectar();
                MessageBox.Show("Se modifico el producto");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void llenarXActualizar(TextBox producto, TextBox categoria, TextBox precio, TextBox cantidad, ComboBox prod)
        {
            try
            {
                Conectar();
                //cbclinica.Items.Clear();
                cmb = new SqlCommand("ProdXModificar", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@Producto", Convert.ToString(prod.SelectedItem)));
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    //cbclinica.Items.Add(dr[0].ToString());
                    producto.Text = dr[0].ToString();
                    categoria.Text = dr[1].ToString();
                    precio.Text = dr[2].ToString();
                    cantidad.Text = dr[3].ToString();
                }
                dr.Close();
                Desconectar();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Categorias(ComboBox categoria)
        {
            try
            {
                Conectar();
                categoria.Items.Clear();
                cmb = new SqlCommand("Categorias", cn);
                cmb.CommandType = CommandType.StoredProcedure;

                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    categoria.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void MostrarProductoXCategoria(ComboBox categoria, DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarProductoXCategoria", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@categoria", Convert.ToString(categoria.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["Nombre_Producto"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Categoria"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Stock"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void VerProducto(ComboBox producto, DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("verProducto", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["Nombre_Producto"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Categoria"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Stock"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

    }
}
