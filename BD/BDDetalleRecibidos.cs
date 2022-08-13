using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace inventarioIMG.BD
{
    class BDDetalleRecibidos
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

        public void MostrarEnvios(DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarEntradas", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Nombre_producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["FechaEntrada"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }
        public void MostrarEnviosXFolio(DataGridView dgv, string folio)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarEntradasXFolio", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", folio));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Nombre_producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["FechaEntrada"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }
        public void FiltrarXFecha(DataGridView dgv, String fecha)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("MostrarEntradasXFecha", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@fecha", (fecha)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["Nombre_producto"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["FechaEntrada"].ToString();
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
