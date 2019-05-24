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
    public partial class frmPrincipal : Form
    {
        

        public frmPrincipal()
        {
            InitializeComponent();
            
        }
        string resultadoLogin;

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    


                    SqlCommand cmd = new SqlCommand("backupdb", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;




                    cnn.Open();


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("El backup fue realizado exitosamente");
                   

                    cnn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    cnn.Close();
                }
            }
        }

        internal void SetLogin(string parametro)
        {
            this.resultadoLogin = parametro;
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AcercaDe frm = new AcercaDe();
            frm.Show();
        }

        private void productosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmProductos hijo2 = frmProductos.GetInstancia();
            hijo2.SetLogin(resultadoLogin);
            hijo2.TopLevel = false;
            
            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void ventasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmVentas hijo2 = frmVentas.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void comprasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmCompras hijo2 = frmCompras.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void marcasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmMarcas hijo2 = frmMarcas.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void categoriasToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmCategorias hijo2 = frmCategorias.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            


            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmProveedores hijo2 = frmProveedores.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
        }

        private void backupToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {


                    SqlCommand cmd = new SqlCommand("backupdb", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    toolStripProgressBar1.Minimum = 0;

                    toolStripProgressBar1.Maximum = 100;

                    toolStripProgressBar1.Step = 1;
                    for (int i = 0; i <= 99; i++)
                    {

                        toolStripProgressBar1.PerformStep();


                    }


                    cnn.Open();


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("El backup fue realizado exitosamente");

                    cnn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrio un problema al realizar el backup. Asegurese de que la carpeta BackupControlStock este creada en la raiz de C");
                    cnn.Close();
                }
            }
        }

        private void infoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            AcercaDe frm = new AcercaDe();
            frm.Show();
        }

        private void txtFecHora_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lbLogin.Text = "Bienvenido, " + resultadoLogin +"!";

            if (resultadoLogin=="mostrador")
            {
                comprasToolStripMenuItem1.Enabled = false;
                proveedoresToolStripMenuItem.Enabled = false;
            }
            
        }

        private void bloquearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
