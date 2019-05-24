using ControlStock.BL;
using ControlStock.Datos;
using MetroFramework.Forms;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            
          
        }



        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmProductos hijo2 = frmProductos.GetInstancia();
            hijo2.TopLevel = false;

            hijo2.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo2);
            this.panelContenedor.Tag = hijo2;
            hijo2.Show();
           
            
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            
            frmCategorias frmComp = frmCategorias.GetInstancia();
            frmComp.TopLevel = false;

            frmComp.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmComp);
            this.panelContenedor.Tag = frmComp;
            frmComp.Show();
            
        }

        private void marcasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmMarcas frmComp = frmMarcas.GetInstancia();
            frmComp.TopLevel = false;

            frmComp.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmComp);
            this.panelContenedor.Tag = frmComp;
            frmComp.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmCompras frmComp = frmCompras.GetInstancia();
            frmComp.TopLevel = false;

            frmComp.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmComp);
            this.panelContenedor.Tag = frmComp;
            frmComp.Show();
        }

        private void proovedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            frmProveedores frmComp = frmProveedores.GetInstancia();
            frmComp.TopLevel = false;

            frmComp.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmComp);
            this.panelContenedor.Tag = frmComp;
            frmComp.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

                frmVentas frmVta = frmVentas.GetInstancia();
                frmVta.TopLevel = false;

                frmVta.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(frmVta);
                this.panelContenedor.Tag = frmVta;
                frmVta.Show();
            
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn=ConexionBD.GetConexion())
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

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe frm = new AcercaDe();
            frm.Show();

        }
    }
}
