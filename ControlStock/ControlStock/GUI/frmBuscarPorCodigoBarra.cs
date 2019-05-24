using ControlStock.BL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.GUI
{
    public partial class frmBuscarPorCodigoBarra : Form
    {
        
        string datosFiltro;
        public frmBuscarPorCodigoBarra()
        {
            InitializeComponent();
        }

        private void frmBuscarPorCodigoBarra_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                datosFiltro = txtCodProd.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtCodProd.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCodProd, "Ingrese un codigo valido");
            }
            return valido;
        }

        internal string GetCodigo()
        {
            return datosFiltro;
        }
    }
}
