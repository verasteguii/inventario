using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using inventarioIMG.Properties;


namespace inventarioIMG.BD
{
    class BDEnviarProd
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

        public void LlenarClinicas(ComboBox cb)
        {
            try
            {
                Conectar();
                cb.Items.Clear();
                cmb = new SqlCommand("select strNombre from [Operacion_179].[dbo].[tbConfiguracionClinicas] where strClasifEnc<>000 and strClasifEnc<>179 and strClasifEnc<>50  and intActiva=1", cn);
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr[0].ToString());
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        public void MostrarPrecio(ComboBox prod, TextBox precio)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("VerPrecio", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(prod.SelectedItem)));
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    //cbclinica.Items.Add(dr[0].ToString());
                    precio.Text = dr[0].ToString();
                   
                }
                dr.Close();
                Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void AgregarEnvio(ComboBox clinica, ComboBox producto, string precio, string doctor, string cantidad)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("agregarenvio", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@precio", Convert.ToDouble(precio)));
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString(clinica.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@doctor", Convert.ToString(doctor)));
                cmb.Parameters.Add(new SqlParameter("@cantidad", Convert.ToInt32(cantidad)));

                cmb.ExecuteNonQuery();
                MessageBox.Show("Cambios Guardados");
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void AgregarEnvios(DataGridView dgv, string folio)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("agregarenvio", cn);
                cmb.CommandTimeout = 5;
                cmb.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    cmb.Parameters.Clear();
                    cmb.Parameters.AddWithValue("@Clinica", Convert.ToString(row.Cells["Clinica"].Value));
                    cmb.Parameters.AddWithValue("@producto", Convert.ToString(row.Cells["Producto"].Value));
                    cmb.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells["cantidad"].Value));
                    cmb.Parameters.AddWithValue("@area", Convert.ToString(row.Cells["area"].Value));
                    cmb.Parameters.AddWithValue("@folio", Convert.ToInt32(folio));
                    cmb.ExecuteNonQuery();
                }
                MessageBox.Show("Envio realizado\nFolio:"+folio);
                Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar" + ex);
            }
        }

        public void ValidarEnvios(DataGridView dgv, DataGridView dgv2, DataGridView dgv3, Label prod, Label stock, Button guardar)
        {
            guardar.Enabled = false;
            prod.Visible = false;
            stock.Visible = false;
            dgv2.Visible = false;
            dgv3.Visible = false;
            string producto;
            int cantidad, temp,cant_errores=0, cant_errores2=0;
            string[] validacion = new string[dgv.RowCount];
            string[] validacion2 = new string[dgv.RowCount];
            string[] temp3 = new string[dgv.RowCount];
            
            Conectar();
            
            for(int i=0;i<dgv.RowCount;i++)
            {
                producto = dgv.Rows[i].Cells[1].Value.ToString();
                cantidad = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                cmb = new SqlCommand("select nombre_producto, stock from productos where nombre_producto='" + producto + "' and Bajalogica=1", cn);
                cmb.ExecuteNonQuery();
                dr = cmb.ExecuteReader();
                if (dr.Read())
                {
                    //MessageBox.Show("El valor del producto es:" + dr[0].ToString());
                    //MessageBox.Show("El valor de stock es:" + dr[1].ToString());
                    temp = int.Parse(dr[1].ToString());
                    //Validar3 para ver si existen productos duplicados
                   
                    if (temp<cantidad)
                    {
                        validacion2[cant_errores2] = producto;
                        cant_errores2++;
                       
                    }
                   
                }
                else
                {
                    //si no lee el producto ingresado es porque no existe, entonces
                    //se guardan los Productos que no existen en la bd (se escribieron mal en el doc excel)
                    //para desplegarlos y mostrar cuales productos estan mal ingresados 
                    validacion[cant_errores] = producto;
                    cant_errores++;
                    

                }
                dr.Close();
                
            }
            Desconectar();
             
            

            

            if (cant_errores > 0)
            {
                dgv2.Rows.Clear();
                dgv2.Visible = true;
                prod.Visible = true;
                for (int i=0;i<cant_errores;i++)
                {
                    dgv2.Rows.Add();
                    dgv2.Rows[i].Cells[0].Value = validacion[i];
                }
            }
            if(cant_errores2 > 0)
            {
                dgv3.Rows.Clear();
                dgv3.Visible = true;
                stock.Visible = true;
                for (int i=0;i<cant_errores2;i++)
                {
                    dgv3.Rows.Add();
                    dgv3.Rows[i].Cells[0].Value = validacion2[i];
                }
            }

            if(cant_errores==0 && cant_errores2==0)
            {
                MessageBox.Show("Los productos ingresados son correctos\ny las cantidades son suficientes para realizar envio");
                guardar.Enabled = true;
            }

        }

        public void GetFolio(TextBox folio)
        {
            try
            {
                Conectar();
                folio.Clear();
                cmb = new SqlCommand("asignarfolio", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    folio.Text = dr[0].ToString();
                }
                dr.Close();
                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void MostrarEnvios(DataGridView dgv)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("mostrarenvios", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void cargarstock(ComboBox producto, Label stock)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("cargarstock", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    stock.Text = dr[0].ToString();
                }
                dr.Close();

                Desconectar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            } 
        }

        public void MostrarClinicas(ComboBox clinicas)
        {
            try
            {
                Conectar();
                cmb = new SqlCommand("MostrarClinicas", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                dr = cmb.ExecuteReader();
                while (dr.Read())
                {
                    clinicas.Items.Add(dr[0].ToString());
                }
                dr.Close();

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarEnviosFiltroClinica(DataGridView dgv, ComboBox clinicas)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("FiltroClinica", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString(clinicas.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarEnviosFiltroClinicaXProducto(DataGridView dgv, ComboBox clinicas, ComboBox producto)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("filtrarXClinicaXProd", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString(clinicas.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void MostrarProductoFiltroXClinica(ComboBox clinica, ComboBox producto)
        {
            try
            {
                producto.Items.Clear();
                Conectar();
                cmb = new SqlCommand("ProductoXCLinica", cn);
                cmb.CommandTimeout = 10;
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString(clinica.SelectedItem)));
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
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void FiltrarXProducto(DataGridView dgv, ComboBox producto)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("filtrarXProd", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
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
                cmb = new SqlCommand("filtrarXFecha", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@fecha", (fecha)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void FiltrarXClinicaXFecha(DataGridView dgv,ComboBox clinica ,String fecha)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("filtrarXClinicaXFecha", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@fecha", (fecha)));
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString (clinica.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }

        public void FiltrarXClinicaXFechaXProd(DataGridView dgv, ComboBox clinica, String fecha, ComboBox producto)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("filtrarXClinicaXFechaXProducto", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@fecha", (fecha)));
                cmb.Parameters.Add(new SqlParameter("@clinica", Convert.ToString(clinica.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }
        public void BuscarXFolio(DataGridView dgv,string folio)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("BuscarXFolio", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", (folio)));           
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
                }

                Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
          }

        public void BuscarXFolioXProd(DataGridView dgv, ComboBox folio, ComboBox producto)
        {
            try
            {
                Conectar();
                dgv.Rows.Clear();
                cmb = new SqlCommand("BuscarXFolioXProd", cn);
                cmb.CommandType = CommandType.StoredProcedure;
                cmb.Parameters.Add(new SqlParameter("@folio", Convert.ToInt32(folio.SelectedItem)));
                cmb.Parameters.Add(new SqlParameter("@producto", Convert.ToString(producto.SelectedItem)));
                da = new SqlDataAdapter(cmb);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = item["folio"].ToString();
                    dgv.Rows[index].Cells[1].Value = item["intclinica"].ToString();
                    dgv.Rows[index].Cells[2].Value = item["producto"].ToString();
                    dgv.Rows[index].Cells[3].Value = item["Precio"].ToString();
                    dgv.Rows[index].Cells[4].Value = item["cantidad"].ToString();
                    dgv.Rows[index].Cells[5].Value = item["doctor"].ToString();
                    dgv.Rows[index].Cells[6].Value = item["total"].ToString();
                    dgv.Rows[index].Cells[7].Value = item["Fecha_Envio"].ToString();
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
    
