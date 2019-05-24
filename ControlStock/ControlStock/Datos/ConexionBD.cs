using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.Datos
{
    public class ConexionBD
    {
        public static SqlConnection CNN;
        public static SqlConnection GetConexion()

        {
            //IPHostEntry host;
            //string localIP = "";
            //host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (IPAddress ip in host.AddressList)
            //{
            //    if (ip.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        localIP = ip.ToString();
            //    }
            //}

            try
            {

                string CadenaConexion = "Data Source=192.168.1.209,1433\\SQLEXPRESS; Database = ControlStock; user Id = sa; Password = admin1234";
                CNN = new SqlConnection(CadenaConexion);
                return CNN;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        internal void autoCompletarProducto(TextBox txtProducto)
        {
            
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string cmd = "SELECT CODIGOBARRA, DESCRIPCIONPRODUCTO FROM Productos";
                    SqlCommand comando = new SqlCommand(cmd, cnn);
                   
                    SqlDataReader dr = comando.ExecuteReader();

                    while (dr.Read())
                    {

                        txtProducto.AutoCompleteCustomSource.Add(dr["CodigoBarra"].ToString());
                        txtProducto.AutoCompleteCustomSource.Add(dr["DescripcionProducto"].ToString());
                        //txtProducto.AutoCompleteCustomSource.Add(dr["CodigoBarra"] + "-" + (dr["DescripcionProducto"].ToString()));
                        //txtProducto.AutoCompleteCustomSource.Add(dr["DescripcionProducto"] + "-" + (dr["CodigoBarra"].ToString()));


                    }

                    dr.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo autocompletar el campo" + ex.ToString());
                }
            }
        }

        public void autoCompletar(TextBox textProducto, TextBox textPrecioUn)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string cmd = "SELECT DescripcionProducto FROM Productos";
                    SqlCommand comando = new SqlCommand(cmd, cnn);
                    SqlDataReader dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        textProducto.AutoCompleteCustomSource.Add(dr["DescripcionProducto"].ToString());
                        
                        
                    }
                    
                    dr.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo autocompletar el campo" + ex.ToString());
                }
            }

        }
    }
}
