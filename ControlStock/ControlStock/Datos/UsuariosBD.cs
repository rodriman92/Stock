using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.Datos
{
    class UsuariosBD
    {
        internal static int ValidarUsuario(string user, string clave)
        {
            int resultado = -1;
            using (SqlConnection cnn=ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string comandoSearch = "Select Usuario, Contraseña FROM Usuarios Where Usuario=@user AND Contraseña=@pass";
                    SqlCommand comando = new SqlCommand(comandoSearch, cnn);
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@pass", clave);

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        resultado = 50;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + ex.ToString());
                    
                }
                cnn.Close();
                return resultado;
            }
        }
    }
}
