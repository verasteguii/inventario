using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace inventarioIMG.BD
{
    class BDRecibirProductos
    {
        private SqlConnection cn;
        private SqlCommand cmb;
        //private SqlDataAdapter da;
        //private DataTable dt;
        //private SqlDataReader dr;



        private void Conectar()
        {
            try
            {
                cn = new SqlConnection("server=imagendb-xl.c0htsxrna0bd.us-west-2.rds.amazonaws.com ;database=inventario;uid=imagendentaldba ;pwd=2s2:W$GyqSF(*7,-;");
                cn.Open();
            }
            catch (Exception ex)
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

        public void AgregarStock(ComboBox producto, string cantidad)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("AgregarStock", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("producto", Convert.ToString(producto.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@cantidad", Convert.ToInt32(cantidad)));
                cmb.ExecuteNonQuery();
                MessageBox.Show("Se Agregaron los productos a stock");
                Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
