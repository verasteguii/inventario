using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace inventarioIMG.BD
{
    class BDLogin
    {
        private SqlConnection cn;
        private SqlCommand cmb;
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

        public int InicioSesion(string usuario, string password)
        {
            
            try
            {
                Conectar();
                cmb = new SqlCommand("InicioSesion", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@usuario", usuario));
                cmb.Parameters.Add(new SqlParameter("@password", password));
                dr = cmb.ExecuteReader();
                
                if (dr.Read())
                {
                    usuario = dr[0].ToString();
                    password = dr[1].ToString();
                    return 1;
                    
                }
                else
                {
                    return 0;
                }
                dr.Close();
                Desconectar();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            
        }

        public void Sesion(string usuario)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("IniciosDeSesion", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@usuario", usuario));
                cmb.ExecuteNonQuery();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarUsuario(Label usuario)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("MostrarUsuarios", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                dr = cmb.ExecuteReader();

                if (dr.Read())
                {
                    usuario.Text = dr[0].ToString();
                }
                
                dr.Close();
                Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

    }
}
