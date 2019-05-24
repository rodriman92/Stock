using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlStock.BL;

namespace ControlStock.Datos
{
    class ReciboVtaBD
    {
        internal static void Guardar(ReciboVenta recibo)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();
                    SqlTransaction tran = cnn.BeginTransaction();
                    
                    string insertComando = "INSERT INTO RECIBOVENTA(Fecha, Cliente, Producto, Cantidad, PrecioU, Importe, Entrada, Salida) values (@fec, @cliente, @producto, @cant, @preciou, @importe, @ent, @sal)";
                    SqlCommand comando = new SqlCommand(insertComando, cnn, tran);
                    comando.Parameters.AddWithValue("@fec", recibo.Fecha);
                    comando.Parameters.AddWithValue("@cliente", recibo.cliente);
                    comando.Parameters.AddWithValue("@producto", recibo.producto);
                    comando.Parameters.AddWithValue("@cant", recibo.Cantidad);
                    comando.Parameters.AddWithValue("@preciou", recibo.PrecioU);
                    comando.Parameters.AddWithValue("@importe", recibo.Importe);
                    comando.Parameters.AddWithValue("@ent", recibo.Entrada);
                    comando.Parameters.AddWithValue("@sal", recibo.Salida);

                    try
                    {
                        comando.ExecuteNonQuery();

                        insertComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(insertComando, cnn, tran);
                        int id = (int)(decimal)comando.ExecuteScalar();
                        recibo.IdRecibo = id;

                        string updateStatement =
                        "UPDATE Productos SET Stock=Stock-@cant " +
                        "WHERE CodigoBarra + ' - ' + DescripcionProducto=@id";
                        SqlCommand updateCommand = new SqlCommand(updateStatement, cnn, tran);
                        updateCommand.Parameters.AddWithValue("@cant", recibo.Cantidad);
                        updateCommand.Parameters.AddWithValue("@id", recibo.producto);
                        updateCommand.ExecuteNonQuery();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {

                        tran.Rollback();
                        ex.Message.ToString();
                    }
                    finally
                    {
                        cnn.Close();
                        tran.Dispose();
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        internal static List<ReciboVenta> GetLista()
        {
            List<ReciboVenta> listaVenta = new List<ReciboVenta>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM ReciboVenta ORDER BY IdRecibo desc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReciboVenta obj = new ReciboVenta();
                        obj.IdRecibo = reader.GetInt32(0);
                        obj.Fecha = reader.GetDateTime(1);
                        obj.cliente = reader.GetString(2);
                        obj.producto = reader.GetString(3);
                        obj.Cantidad = reader.GetInt32(4);
                        obj.PrecioU = reader.GetDecimal(5);
                        obj.Importe = reader.GetDecimal(6);
                        obj.Entrada = reader.GetDecimal(7);
                        obj.Salida = reader.GetDecimal(8);

                        listaVenta.Add(obj);
                    }
                }
            }
            return listaVenta;
        
    }

        internal static void Borrar(ReciboVenta v)
        {
            SqlTransaction tran = null;
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                tran = ConexionBD.CNN.BeginTransaction();
                string deleteString = "DELETE FROM RECIBOVENTA WHERE IdRecibo=@id";
                SqlCommand deleteCommand = new SqlCommand(deleteString, cnn, tran);
                deleteCommand.Parameters.AddWithValue("@id", v.IdRecibo);

                string updateString = "UPDATE Productos SET Stock=Stock+@cant " +
                        "WHERE CodigoBarra + ' - ' + DescripcionProducto=@id";
                SqlCommand updateCommand = new SqlCommand(updateString, cnn, tran);
                updateCommand.Parameters.AddWithValue("@cant", v.Cantidad);
                updateCommand.Parameters.AddWithValue("@id", v.producto);
                updateCommand.ExecuteNonQuery();
                tran.Commit();

                try
                {
                    deleteCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error", ex.Message);

                }
                finally
                {
                    cnn.Close();
                    tran.Dispose();
                }


            }
        }

        internal static List<ReciboVenta> GetVentasxFecha(DateTime desde, DateTime hasta)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                List<ReciboVenta> listaFiltrada = new List<ReciboVenta>();
                cnn.Open();

                string filterCommand = @"SELECT *
                        FROM ReciboVenta
                        WHERE CAST(CONVERT(CHAR(8), Fecha, 112) AS INT) BETWEEN CAST(CONVERT(CHAR(8), @desde, 112) AS INT) 
                                    AND CAST(CONVERT(CHAR(8), @hasta, 112) AS INT)";


                SqlCommand comando = new SqlCommand(filterCommand, cnn);
                comando.Parameters.AddWithValue("@desde", desde);
                comando.Parameters.AddWithValue("@hasta", hasta);

                try
                {
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ReciboVenta obj = new ReciboVenta();
                        obj.IdRecibo = reader.GetInt32(0);
                        obj.Fecha = reader.GetDateTime(1);
                        obj.cliente = reader.GetString(2);
                        obj.producto = reader.GetString(3);
                        obj.Cantidad = reader.GetInt32(4);
                        obj.PrecioU = reader.GetDecimal(5);
                        obj.Importe = reader.GetDecimal(6);
                        obj.Entrada = reader.GetDecimal(7);
                        obj.Salida = reader.GetDecimal(8);

                        listaFiltrada.Add(obj);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al intentar una busqueda", ex.Message);
                }
                finally
                {
                    cnn.Close();
                }
                return listaFiltrada;
            }
        }
    }
}
