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
    public class ComprasBD
    {
        internal static void Agregar(Compra c1, int idObj)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();
                    SqlTransaction tran = cnn.BeginTransaction();
                    string insertCommand = "INSERT INTO Compras(Producto, idProveedor, Cantidad, Fecha, Importe) VALUES (@prod, @prov,@can, @fec, @imp)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn, tran);
                    comando.Parameters.AddWithValue("@prod", idObj);
                    comando.Parameters.AddWithValue("@prov", c1.idProveedor.IdProveedor);
                    comando.Parameters.AddWithValue("@can", c1.Cantidad);
                    comando.Parameters.AddWithValue("@fec", c1.Fecha);
                    comando.Parameters.AddWithValue("@imp", c1.Importe);
                    
                    try
                    {
                       comando.ExecuteNonQuery();

                       insertCommand = "SELECT @@IDENTITY";
                       comando = new SqlCommand(insertCommand, cnn,tran);
                       int id = (int)(decimal)comando.ExecuteScalar();
                       c1.IdCompra = id;

                        string updateStatement =
                        "UPDATE Productos SET Stock=Stock+@cant " +
                        "WHERE CodigoBarra + ' - ' + DescripcionProducto=@id";
                        SqlCommand updateCommand = new SqlCommand(updateStatement, cnn, tran);
                        updateCommand.Parameters.AddWithValue("@cant", c1.Cantidad);
                        updateCommand.Parameters.AddWithValue("@id", c1.Producto);
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

        internal static List<Compra> GetLista()
        {
            List<Compra> listaCompra = new List<Compra>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Compras ORDER BY Fecha desc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Compra obj = new Compra();
                        obj.IdCompra = reader.GetInt32(0);
                        obj.Producto = reader.GetInt32(1).ToString();
                        obj.idProveedor = ProveedoresBD.GetObjeto(reader.GetInt32(2));
                        obj.Cantidad = reader.GetInt32(3);
                        obj.Fecha = reader.GetDateTime(4);
                        obj.Importe = reader.GetDecimal(5);
                        
                        



                        listaCompra.Add(obj);
                    }
                }
            }
            return listaCompra ;
        }


        internal static void Editar(Compra obj)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string updateCommand = "UPDATE Compras SET idProducto=@prod, idProveedor=@prov, Cantidad=@can, Fecha=@fec, Importe=@imp WHERE IdCompra=@id";
                    SqlCommand comando = new SqlCommand(updateCommand, cnn);
                    comando.Parameters.AddWithValue("@prod", obj.Producto);
                    comando.Parameters.AddWithValue("@prov", obj.idProveedor.IdProveedor);
                    comando.Parameters.AddWithValue("@can", obj.Cantidad);
                    comando.Parameters.AddWithValue("@fec", obj.Fecha);
                    comando.Parameters.AddWithValue("@imp", obj.Importe);
                    
                    comando.Parameters.AddWithValue("@id", obj.IdCompra);

                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    MessageBox.Show("Error al editar registro", "Error");
                }
            }
        }

        internal static void Borrar(Compra c)
        {
            SqlTransaction tran = null;
            using (SqlConnection cnn=ConexionBD.GetConexion())
            {
                cnn.Open();
                tran = ConexionBD.CNN.BeginTransaction();
                string deleteString = "DELETE FROM Compras WHERE IdCompra=@ID";
                SqlCommand deleteCommand = new SqlCommand(deleteString, cnn, tran);
                deleteCommand.Parameters.AddWithValue("@ID", c.IdCompra);

                string updateString= "UPDATE Productos SET Stock=Stock-@cant " +
                        "WHERE CodigoBarra + ' - ' + DescripcionProducto=@id";
                SqlCommand updateCommand = new SqlCommand(updateString, cnn, tran);
                updateCommand.Parameters.AddWithValue("@cant", c.Cantidad);
                updateCommand.Parameters.AddWithValue("@id", c.Producto);
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
    }
}
