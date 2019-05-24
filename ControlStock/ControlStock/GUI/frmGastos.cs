using ControlStock.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.GUI
{
    public partial class frmGastos : Form
    {
        public frmGastos()
        {
            InitializeComponent();
        }

        private void frmGastos_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn=ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string selectComando = "Select Compras.Fecha, SUM(compras.importe)as Gastos from Compras Group by fecha Order by fecha desc";
                    SqlDataAdapter da = new SqlDataAdapter(selectComando, cnn);

                    DataTable dt = new DataTable();

                   

                    //object total = dt.Compute("SUM(Gastos)", null);
                    da.Fill(dt);
                    dgCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                    dgCompras.DataSource = dt;
                    
                    cnn.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
