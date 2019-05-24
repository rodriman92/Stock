using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Controls;
using ControlStock.BL;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ControlStock.Datos
{
    public class ProveedoresBD
    {
        internal static void CargarCombo(ref ComboBox cboProveedor)
        {
            List<Proveedor> lista = ProveedoresBD.GetLista();
            Proveedor prov = new Proveedor() { DescripcionProveedor = "<Seleccione el proveedor>" };
            lista.Insert(0, prov);
            cboProveedor.DataSource = lista;
            cboProveedor.DisplayMember = "DescripcionProveedor";
            cboProveedor.ValueMember = "IdProveedor";
        }

        public static List<Proveedor> GetLista()
        {
            List<Proveedor> listaProv = new List<Proveedor>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Proveedores ORDER BY Proveedor asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedor obj = new Proveedor();
                        obj.IdProveedor = reader.GetInt32(0);
                        obj.DescripcionProveedor = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.CUIT = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2);
                        obj.Telefono = reader[3] == DBNull.Value ? string.Empty : reader.GetString(3);
                        obj.Direccion = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Email = reader[5] == DBNull.Value ? string.Empty : reader.GetString(5);
                        obj.Localidad = reader[6] == DBNull.Value ? string.Empty : reader.GetString(6);




                        listaProv.Add(obj);
                    }
                }
            }
            return listaProv;
        }

        internal static void Agregar(Proveedor prov)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();
                    
                    string insertCommand = "INSERT INTO Proveedores(Proveedor, CUIT, Telefono, Direccion, Email, Localidad) VALUES (@prov, @cuit,@tel, @dir, @email, @loc)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn);
                    comando.Parameters.AddWithValue("@prov", prov.DescripcionProveedor);
                    comando.Parameters.AddWithValue("@cuit", prov.CUIT);
                    comando.Parameters.AddWithValue("@tel", prov.Telefono);
                    comando.Parameters.AddWithValue("@dir", prov.Direccion);
                    comando.Parameters.AddWithValue("@email", prov.Email);
                    comando.Parameters.AddWithValue("@loc", prov.Localidad);

                    try
                    {
                        comando.ExecuteNonQuery();

                        insertCommand = "SELECT @@IDENTITY";
                        comando = new SqlCommand(insertCommand, cnn);
                        int id = (int)(decimal)comando.ExecuteScalar();
                        prov.IdProveedor = id;

                        

                    }
                    catch (Exception ex)
                    {

                        
                        throw ex;
                    }
                    finally
                    {
                        cnn.Close();
                        
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal static void Borrar(int idProveedor)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string deleteCommand = "DELETE FROM PROVEEDORES WHERE IdProveedor=@id";
                    SqlCommand comando = new SqlCommand(deleteCommand, cnn);
                    comando.Parameters.AddWithValue("@id", idProveedor);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrio un error al intentar borrar el registro", ex.Message);
                }
                finally
                {
                    cnn.Close();
                }
            }
        }

        internal static void Editar(Proveedor obj)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string updateCommand = "UPDATE Proveedores SET Proveedor=@prov, CUIT=@cuit, Telefono=@tel, Direccion=@dir, Email=@email, Localidad=@loc WHERE IdProveedor=@id";
                    SqlCommand comando = new SqlCommand(updateCommand, cnn);
                    comando.Parameters.AddWithValue("@prov", obj.DescripcionProveedor);
                    comando.Parameters.AddWithValue("@cuit", obj.CUIT);
                    comando.Parameters.AddWithValue("@tel", obj.Telefono);
                    comando.Parameters.AddWithValue("@dir", obj.Direccion);
                    comando.Parameters.AddWithValue("@email", obj.Email);
                    comando.Parameters.AddWithValue("@loc", obj.Localidad);
                    comando.Parameters.AddWithValue("@id", obj.IdProveedor);

                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    MessageBox.Show("Error al editar registro", "Error");
                }
            }
        }

        internal static Proveedor GetObjeto(int v)
        {
            Proveedor obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProveedor, Proveedor, CUIT, Telefono, Direccion, Email, Localidad FROM Proveedores WHERE IdProveedor=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", v);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Proveedor();
                            obj.IdProveedor = reader.GetInt32(0);
                            obj.DescripcionProveedor = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                            obj.CUIT = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2);
                            obj.Telefono = reader[3] == DBNull.Value ? string.Empty : reader.GetString(3);
                            obj.Direccion = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                            obj.Email = reader[5] == DBNull.Value ? string.Empty : reader.GetString(5);
                            obj.Localidad = reader[6] == DBNull.Value ? string.Empty : reader.GetString(6);




                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static List<Proveedor> GetListaFilrada(string datosCliente)
        {
            List<Proveedor> listaProv = new List<Proveedor>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT IdProveedor, Proveedor, CUIT, Telefono, Direccion, Email, Localidad FROM Proveedores WHERE Proveedor like '%'+@prov+'%' ORDER BY Proveedor asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                comando.Parameters.AddWithValue("@prov", datosCliente);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedor obj = new Proveedor();
                        obj.IdProveedor = reader.GetInt32(0);
                        obj.DescripcionProveedor = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.CUIT = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2);
                        obj.Telefono = reader[3] == DBNull.Value ? string.Empty : reader.GetString(3);
                        obj.Direccion = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Email = reader[5] == DBNull.Value ? string.Empty : reader.GetString(5);
                        obj.Localidad = reader[6] == DBNull.Value ? string.Empty : reader.GetString(6);




                        listaProv.Add(obj);
                    }
                }
            }
            return listaProv;
        }
    }
  
}
