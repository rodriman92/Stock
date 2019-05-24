using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlStock.BL;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Data;
using ControlStock.Datos;

namespace ControlStock.Datos
{
    public class ProductosBD
    {
        internal static List<Producto> GetLista()
        {
            
            List<Producto> listaProd = new List<Producto>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos ORDER BY DescripcionProducto asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto obj = new Producto();
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);
                        obj.Estado = (EstadoProducto)reader.GetInt32(7);


                        listaProd.Add(obj);
                    }
                }
            }
            return listaProd;
        }

        internal static object GetObjeto(string producto)
        {
            Producto obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE IdProducto=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", producto);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Producto();
                            obj.IdProducto = reader.GetInt32(0);
                            obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                            obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                            obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                            obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                            obj.Precio = reader.GetDecimal(5);
                            obj.Stock = reader.GetInt32(6);
                            obj.Estado = (EstadoProducto)reader.GetInt32(7);



                        }
                    }
                }
                return obj.DescripcionProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static Producto GetDetalleProducto(string text)
        {
            Producto obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE DescripcionProducto=@desc or (CodigoBarra=@desc)";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@desc", text);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Producto();
                            obj.IdProducto = reader.GetInt32(0);
                            obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                            obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                            obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                            obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                            obj.Precio = reader.GetDecimal(5);
                            obj.Stock = reader.GetInt32(6);
                           
                           



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

        internal static string ObtenerIdAPartirDesc(string v)
        {
            Producto obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE DescripcionProducto=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", v);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Producto();
                            obj.IdProducto = reader.GetInt32(0);
                            obj.CodigoBarra = reader.GetString(1);
                            obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                            obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                            obj.DescripcionProducto = reader.GetString(4);
                            obj.Precio = reader.GetDecimal(5);
                            obj.Stock = reader.GetInt32(6);
                            obj.Estado = (EstadoProducto)reader.GetInt32(7);


                        }
                    }
                }
                return v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal static bool RevisarStock(int cantidad, string prod)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())

                try
                {
                    cnn.Open();
                    string selectCommand = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE Stock>=@cantidad and DescripcionProducto like '%' + @prod + '%'";
                    SqlCommand comando = new SqlCommand(selectCommand, cnn);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@prod",prod);
                    SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                    {
                        Producto obj = new Producto();
                        reader.Read();
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);



                        reader.Close();
                        cnn.Close();
                        return true;
                    }
                    else
                    {
                        cnn.Close();
                        reader.Close();
                        return false;

                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
        }

        internal static void CargarCombo(ref MetroComboBox cboProducto)
        {
            throw new NotImplementedException();
        }

        internal static List<Producto> GetListaFilrada(string producto)
        {
            List<Producto> listaProdFilt = new List<Producto>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos Where CodigoBarra like @prod+'%' or DescripcionProducto like '%'+@desc+'%' ORDER BY DescripcionProducto asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                comando.Parameters.AddWithValue("@prod", producto);
                comando.Parameters.AddWithValue("@desc", producto);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto obj = new Producto();
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);
                        obj.Estado = (EstadoProducto)reader.GetInt32(7);




                        listaProdFilt.Add(obj);
                    }
                }
            }
            return listaProdFilt;
        }

        internal static void Agregar(Producto p1)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();

                    string insertCommand = "INSERT INTO PRODUCTOS(CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado) VALUES (@cod, @cat,@mar, @desc, @pre, @stock, @est)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn);
                    comando.Parameters.AddWithValue("@cod", p1.CodigoBarra);
                    comando.Parameters.AddWithValue("@cat", p1.idCategoria.IdCategoria);
                    comando.Parameters.AddWithValue("@mar", p1.idMarca.IdMarca);
                    comando.Parameters.AddWithValue("@desc", p1.DescripcionProducto);
                    comando.Parameters.AddWithValue("@pre", p1.Precio);
                    comando.Parameters.AddWithValue("@stock", p1.Stock);
                    comando.Parameters.AddWithValue("@est", p1.Estado);
                    

                    comando.ExecuteNonQuery();

                    insertCommand = "SELECT @@IDENTITY";
                    comando = new SqlCommand(insertCommand, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    p1.IdProducto = id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal static void CargarComboActivos(ref MetroComboBox cboProducto)
        {
            List<Producto> lista = ProductosBD.GetListaActivos();
            Producto prod = new Producto() { DescripcionProducto = "<Seleccione un producto>" };
            lista.Insert(0, prod);
            cboProducto.DataSource = lista;
            cboProducto.DisplayMember = "DescripcionProducto";
            cboProducto.ValueMember = "IdProducto";
        }

        private static List<Producto> GetListaActivos()
        {
            List<Producto> listaProd = new List<Producto>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Productos WHERE Estado=1 ORDER BY DescripcionProducto asc  ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto obj = new Producto();
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);
                        obj.Estado = (EstadoProducto)reader.GetInt32(7);


                        listaProd.Add(obj);
                    }
                }
            }
            return listaProd;
        }

        internal static bool RevisarStock(int cantidad, Producto prod)
        {
            using(SqlConnection cnn=ConexionBD.GetConexion())
            
                try
                {
                    cnn.Open();
                    string selectCommand = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE Stock>=@cantidad and idProducto=@id";
                    SqlCommand comando = new SqlCommand(selectCommand, cnn);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("id", prod.IdProducto);
                    SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                    {
                        Producto obj = new Producto();
                        reader.Read();
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);



                        reader.Close();
                        cnn.Close();
                        return true;
                    }
                    else
                    {
                        cnn.Close();
                        reader.Close();
                        return false;

                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            
        
    

        internal static void CargarCombo(ref ComboBox cboProducto)
        {
            List<Producto> lista = ProductosBD.GetLista();
            Producto prod = new Producto() { DescripcionProducto = "<Seleccione un producto>" };
            lista.Insert(0, prod);
            cboProducto.DataSource = lista;
            cboProducto.DisplayMember = "DescripcionProducto";
            cboProducto.ValueMember = "IdProducto";
        }

        internal static Producto GetString(int v)
        {
            Producto obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE IdProducto=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", v);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Producto();
                            obj.IdProducto = reader.GetInt32(0);
                            obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                            obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                            obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                            obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                            obj.Precio = reader.GetDecimal(5);
                            obj.Stock = reader.GetInt32(6);




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

        internal static void Editar(Producto obj)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string updateCommand = "UPDATE Productos SET CodigoBarra=@cod, idCategoria=@cat, idMarca=@mar, DescripcionProducto=@desc, Precio=@pre, Stock=@stock, Estado=@est WHERE IdProducto=@id";
                    SqlCommand comando = new SqlCommand(updateCommand, cnn);
                    comando.Parameters.AddWithValue("@cod", obj.CodigoBarra);
                    comando.Parameters.AddWithValue("@cat", obj.idCategoria.IdCategoria);
                    comando.Parameters.AddWithValue("@mar", obj.idMarca.IdMarca);
                    comando.Parameters.AddWithValue("@desc", obj.DescripcionProducto);
                    comando.Parameters.AddWithValue("@pre", obj.Precio);
                    comando.Parameters.AddWithValue("@stock", obj.Stock);
                    comando.Parameters.AddWithValue("@est", obj.Estado);
                    comando.Parameters.AddWithValue("@id", obj.IdProducto);

                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    MessageBox.Show("Error al editar registro", "Error");
                }
            }
        }

        internal static List<Producto> GetProductosPorCodigo(string codigo)
        {
            using (SqlConnection cnn=ConexionBD.GetConexion())
            {
                List<Producto> listaFiltrada = new List<Producto>();
                cnn.Open();

                string filterCommand="SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE CodigoBarra like '%'+@codigo+'%'";
                SqlCommand comando = new SqlCommand(filterCommand, cnn);
                comando.Parameters.AddWithValue("@codigo", codigo);

                try
                {
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto obj = new Producto();
                        
                        obj.IdProducto = reader.GetInt32(0);
                        obj.CodigoBarra = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                        obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                        obj.DescripcionProducto = reader[4] == DBNull.Value ? string.Empty : reader.GetString(4);
                        obj.Precio = reader.GetDecimal(5);
                        obj.Stock = reader.GetInt32(6);
                        obj.Estado = (EstadoProducto)reader.GetInt32(7);

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

        internal static Producto GetPrecio(int idProducto)
        {
            Producto obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProducto, CodigoBarra, idCategoria, idMarca, DescripcionProducto, Precio, Stock, Estado FROM Productos WHERE IdProducto=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", idProducto);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Producto();
                            obj.IdProducto = reader.GetInt32(0);
                            obj.CodigoBarra = reader.GetString(1);
                            obj.idCategoria = CategoriasBD.GetObjeto(reader.GetInt32(2));
                            obj.idMarca = MarcasBD.GetObjeto(reader.GetInt32(3));
                            obj.DescripcionProducto = reader.GetString(4);
                            obj.Precio = reader.GetDecimal(5);
                            obj.Stock = reader.GetInt32(6);
                            obj.Estado = (EstadoProducto)reader.GetInt32(7);
                            

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

        internal static void Borrar(int idProducto)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string deleteCommand = "DELETE FROM PRODUCTOS WHERE IdProducto=@id";
                    SqlCommand comando = new SqlCommand(deleteCommand, cnn);
                    comando.Parameters.AddWithValue("@id", idProducto);
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
    }
}
