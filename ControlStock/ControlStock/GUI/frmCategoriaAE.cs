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
    public partial class frmCategoriaAE : Form
    {
        Categoria cate;
        public frmCategoriaAE()
        {
            InitializeComponent();
        }

        private void frmCategoriaAE_Load(object sender, EventArgs e)
        {
            txtCategoria.CharacterCasing = CharacterCasing.Upper;
            txtCodigo.CharacterCasing = CharacterCasing.Upper;
        }


   private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (cate==null)
                {
                    cate = new Categoria();
                }
                cate.DescripcionCategoria = txtCategoria.Text;
                cate.CodigoCategoria = txtCodigo.Text;

                this.DialogResult = DialogResult.OK;
            }
        }

        internal Categoria GetObjeto()
        {
            return cate;
        }

        private bool validarDatos()
        {
            bool valido = true;

            if (string.IsNullOrEmpty(txtCategoria.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "El campo no es valido");
            }

            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (cate!=null)
            {
                txtCategoria.Text = cate.DescripcionCategoria;
                txtCodigo.Text = cate.CodigoCategoria;
            }
        }

        internal void SetObjeto(Categoria obj)
        {
            this.cate = obj;
        }
    }
}
