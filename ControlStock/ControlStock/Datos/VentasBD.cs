using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlStock.BL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControlStock.Datos
{
    public class VentasBD
    {
        internal static void Agregar(Venta v1)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();
                    SqlTransaction tran = cnn.BeginTransaction();
                    string insertCommand = "INSERT INTO Ventas(idProducto, Cantidad, Fecha, Importe) VALUES (@prod,@can, @fec, @imp)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn, tran);
                    comando.Parameters.AddWithValue("@prod", v1.idProducto.IdProducto);
                    
                    comando.Parameters.AddWithValue("@can", v1.Cantidad);
                    comando.Parameters.AddWithValue("@fec", v1.Fecha);
                    comando.Parameters.AddWithValue("@imp", v1.Importe);

                    try
                    {
                        comando.ExecuteNonQuery();

                        insertCommand = "SELECT @@IDENTITY";
                        comando = new SqlCommand(insertCommand, cnn, tran);
                        int id = (int)(decimal)comando.ExecuteScalar();
                        v1.IdVenta = id;

                        string updateStatement =
                        "UPDATE Productos SET Stock=Stock-@cant " +
                        "WHERE IdProducto=@id";
                        SqlCommand updateCommand = new SqlCommand(updateStatement, cnn, tran);
                        updateCommand.Parameters.AddWithValue("@cant", v1.Cantidad);
                        updateCommand.Parameters.AddWithValue("@id", v1.idProducto.IdProducto);
                        updateCommand.ExecuteNonQuery();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {

                        tran.Rollback();
                        throw ex;
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

        internal static void Borrar(Venta v)
        {
            SqlTransaction tran = null;
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                tran = ConexionBD.CNN.BeginTransaction();
                string deleteString = "DELETE FROM Ventas WHERE IdVenta=@ID";
                SqlCommand deleteCommand = new SqlCommand(deleteString, cnn, tran);
                deleteCommand.Parameters.AddWithValue("@ID", v.IdVenta);

                string updateString = "UPDATE Productos SET Stock=Stock+@cant " +
                        "WHERE IdProducto=@id";
                SqlCommand updateCommand = new SqlCommand(updateString, cnn, tran);
                updateCommand.Parameters.AddWithValue("@cant", v.Cantidad);
                updateCommand.Parameters.AddWithValue("@id", v.idProducto.IdProducto);
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

        internal static List<Venta> GetLista()
        {
            List<Venta> listaVenta = new List<Venta>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Ventas ORDER BY Fecha desc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Venta obj = new Venta();
                        obj.IdVenta = reader.GetInt32(0);
                        obj.idProducto = ProductosBD.GetString(reader.GetInt32(1));
                        
                        obj.Cantidad = reader.GetInt32(2);
                        obj.Fecha = reader.GetDateTime(3);
                        obj.Importe = reader.GetDecimal(4);





                        listaVenta.Add(obj);
                    }
                }
            }
            return listaVenta;
        }
    }
}
