using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace inventarioIMG.BD
{
    class BDDevoluciones
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
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexion" + ex.ToString());
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


        public void VerFolios(ComboBox Folio)
        {
            try
            {
                Conectar();
                Folio.Items.Clear();
                cmb = new SqlCommand("VerFolios", cn);
                cmb.CommandType = CommandType.StoredProcedure;

                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    Folio.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void VerProductosXFolio(ComboBox productos, ComboBox folio)
        {
            try
            {
                Conectar();
                productos.Items.Clear();
                cmb = new SqlCommand("VerProductosXFolio", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", Convert.ToInt32(folio.SelectedItem)));


                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    productos.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Devolucion(ComboBox folio, ComboBox producto)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("devolucion", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", Convert.ToInt32(folio.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                cmb.ExecuteNonQuery();
                MessageBox.Show("Producto Devuelto");
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarDevoluciones(DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarDevoluciones", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["fecha_devolucion"].ToString();
                }

                Desconectar();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        public void MostrarDevolucionesXFolio(DataGridView dgv, string folio)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarDevolucionesXFolio", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", folio));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["fecha_devolucion"].ToString();
                }

                Desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

        public void MostrarDevolucionesXProducto(DataGridView dgv, string producto)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarDevolucionesXProd", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", producto));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["fecha_devolucion"].ToString();
                }

                Desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

    }
}
    