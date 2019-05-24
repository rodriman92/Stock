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
    public partial class frmMarcaAE : Form
    {
        Marca marca;
        public frmMarcaAE()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            txtMarca.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (marca==null)
                {
                    marca = new Marca();
                }
                marca.DescripcionMarca = txtMarca.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        internal Marca GetObjeto()
        {
            return marca;
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtMarca, "Los datos ingresados no son validos");
            }
            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marca!=null)
            {
                txtMarca.Text = marca.DescripcionMarca;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        internal void SetObjeto(Marca obj)
        {
            this.marca = obj;
        }
    }
}
