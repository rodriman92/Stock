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
     public class MarcasBD
    {
        

        internal static Marca GetObjeto(int v)
        {
            Marca obj = null;
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {
                    cnn.Open();
                    string strComando = "SELECT IdMarca, DescripcionMarca FROM Marcas WHERE IdMarca=@id";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@id", v);
                    using (SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            obj = new Marca();
                            obj.IdMarca = reader.GetInt32(0);
                            obj.DescripcionMarca = reader.GetString(1);
                            



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

        internal static void Agregar(Marca m)
        {
            try
            {
                using (SqlConnection cnn = ConexionBD.GetConexion())
                {

                    cnn.Open();

                    string insertCommand = "INSERT INTO MARCAS(DescripcionMarca) VALUES (@desc)";
                    SqlCommand comando = new SqlCommand(insertCommand, cnn);
                    comando.Parameters.AddWithValue("@desc", m.DescripcionMarca);
                    


                    comando.ExecuteNonQuery();

                    insertCommand = "SELECT @@IDENTITY";
                    comando = new SqlCommand(insertCommand, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    m.IdMarca = id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal static void CargarCombo(ref ComboBox cboMarca)
        {
            List<Marca> lista = MarcasBD.GetLista();
            Marca marca2 = new Marca() { DescripcionMarca = "<Seleccione la marca>" };
            lista.Insert(0, marca2);
            cboMarca.DataSource = lista;
            cboMarca.DisplayMember = "DescripcionMarca";
            cboMarca.ValueMember = "IdMarca";
        }

        internal static void Editar(Marca obj)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string updateCommand = "UPDATE MARCAS SET DescripcionMarca=@desc WHERE IdMarca=@id";
                    SqlCommand comando = new SqlCommand(updateCommand, cnn);
                    comando.Parameters.AddWithValue("@desc", obj.DescripcionMarca);
                    
                    comando.Parameters.AddWithValue("@id", obj.IdMarca);

                    comando.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    MessageBox.Show("Error al editar registro", "Error");
                }
            }
        }

        public static List<Marca> GetLista()
        {
            List<Marca> listaMarc = new List<Marca>();

            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                cnn.Open();
                string strComando = "SELECT * FROM Marcas ORDER BY DescripcionMarca asc ";
                SqlCommand comando = new SqlCommand(strComando, cnn);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marca obj = new Marca();
                        obj.IdMarca = reader.GetInt32(0);
                        obj.DescripcionMarca = reader[1] == DBNull.Value ? string.Empty : reader.GetString(1);
                       




                        listaMarc.Add(obj);
                    }
                }
            }
            return listaMarc;
        }

        internal static void Borrar(int idMarca)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string deleteCommand = "DELETE FROM MARCAS WHERE IdMarca=@id";
                    SqlCommand comando = new SqlCommand(deleteCommand, cnn);
                    comando.Parameters.AddWithValue("@id", idMarca);
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
