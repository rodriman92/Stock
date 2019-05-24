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
    public partial class frmProveedoresAE : Form
    {
        Proveedor prov;
        public frmProveedoresAE()
        {
            InitializeComponent();
        }

        private void frmProveedoresAE_Load(object sender, EventArgs e)
        {
            txtProveedor.CharacterCasing = CharacterCasing.Upper;
            txtDireccion.CharacterCasing = CharacterCasing.Upper;
            txtEmail.CharacterCasing = CharacterCasing.Upper;
            txtLocalidad.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (prov==null)
                {
                    prov = new Proveedor();
                }
                prov.DescripcionProveedor = txtProveedor.Text;
                prov.CUIT = txtCUIT.Text;
                prov.Telefono = txtTel.Text;
                prov.Direccion = txtDireccion.Text;
                prov.Email = txtEmail.Text;
                prov.Localidad = txtLocalidad.Text;

                this.DialogResult = DialogResult.OK;
            }
        }

        internal Proveedor GetObjeto()
        {
            return prov;
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtProveedor.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El campo no es correcto");

            }
            return valido;
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (prov!=null)
            {
                txtProveedor.Text = prov.DescripcionProveedor;
                txtCUIT.Text = prov.CUIT;
                txtTel.Text = prov.Telefono;
                txtDireccion.Text = prov.Direccion;
                txtEmail.Text = prov.Email;
                txtLocalidad.Text = prov.Localidad;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        internal void SetObjeto(Proveedor obj)
        {
            this.prov = obj;
        }
    }
}
