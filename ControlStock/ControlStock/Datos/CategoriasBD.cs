using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlStock.BL;
using System.Data.SqlClient;
using System.Data;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace ControlStock.Datos
{
    public class CategoriasBD
    {
        internal static Categoria GetObjeto(int c)
        {
            Categoria obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdCategoria, DescripcionCategoria, CodigoCategoria FROM Categorias WHERE IdCategoria=@id ORDER BY DescripcionCategoria desc";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", c);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Categoria();
                            obj.IdCategoria = reader.GetInt32(0);
                            obj.DescripcionCategoria = reader.GetString(1);
                            obj.CodigoCategoria = reader.GetString(2);
                            


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

        internal static void Agregar(Categoria cat)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();

                    string insertCommand = "INSERT INTO CATEGORIAS(DescripcionCategoria,CodigoCategoria) VALUES (@desc, @cod)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn);
                    comando.Parameters.AddWithValue("@desc", cat.DescripcionCategoria);
                    comando.Parameters.AddWithValue("@cod", cat.CodigoCategoria);



                    comando.ExecuteNonQuery();

                    insertCommand = "SELECT @@IDENTITY";
                    comando = new SqlCommand(insertCommand, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    cat.IdCategoria = id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal static void CargarCombo(ref ComboBox cboCategoria)
        {
            List<Categoria> lista = CategoriasBD.GetLista();
            Categoria categoria2 = new Categoria() { DescripcionCategoria = "<Seleccione la categoria>" };
            lista.Insert(0, categoria2);
            cboCategoria.DataSource = lista;
            cboCategoria.DisplayMember = "DescripcionCategoria";
            cboCategoria.ValueMember = "IdCategoria";
        }

        internal static void Editar(Categoria obj)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string updateCommand = "UPDATE CATEGORIAS SET DescripcionCategoria=@desc, CodigoCategoria=@cod WHERE IdCategoria=@id";
                    SqlCommand comando = new SqlCommand(updateCommand, cnn);
                    comando.Parameters.AddWithValue("@desc", obj.DescripcionCategoria);
                    comando.Parameters.AddWithValue("@cod", obj.CodigoCategoria);

                    comando.Parameters.AddWithValue("@id", obj.IdCategoria);

                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    MessageBox.Show("Error al editar registro", "Error");
                }
            }
        }

        internal static void Borrar(int idCategoria)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string deleteCommand = "DELETE FROM CATEGORIAS WHERE IdCategoria=@id";
                    SqlCommand comando = new SqlCommand(deleteCommand, cnn);
                    comando.Parameters.AddWithValue("@id", idCategoria);
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

        public static List<Categoria> GetLista()
        {
            List<Categoria> listaCat = new List<Categoria>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Categorias ORDER BY DescripcionCategoria asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria obj = new Categoria();
                        obj.IdCategoria = reader.GetInt32(0);
                        obj.DescripcionCategoria = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                        obj.CodigoCategoria = reader[2] == DBNull.Value ? string.Empty : reader.GetString(2);

                        


                        listaCat.Add(obj);
                    }
                }
            }
            return listaCat;
        }
    }
}
