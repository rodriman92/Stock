using ControlStock.BL;
using ControlStock.Datos;
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
    public partial class frmProductosAE : Form
    {
        Producto prod;
        
        public object Categorias { get; private set; }

        public frmProductosAE()
        {
            InitializeComponent();
        }

        private void frmProductosAE_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            txtCodigo.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
            txtPrecio.CharacterCasing = CharacterCasing.Upper;
            txtStock.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (prod==null)
                {
                    prod = new Producto();
                }
                prod.CodigoBarra = txtCodigo.Text;
                prod.idCategoria = (Categoria)cboCategoria.SelectedItem;
                prod.idMarca = (Marca)cboMarca.SelectedItem;
                prod.DescripcionProducto = txtDescripcion.Text;
                prod.Precio = decimal.Parse(txtPrecio.Text);
                prod.Stock = int.Parse(txtStock.Text);
                if (chkEstado.Checked==true)
                {
                    prod.Estado = EstadoProducto.Activo;
                }
                else
                {
                    prod.Estado = EstadoProducto.Inactivo;
                }
                

                this.DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "El campo no puede estar vacio");

            }
            if (cboCategoria.SelectedIndex.Equals(-1))
            {
                valido = false;
                errorProvider1.SetError(cboCategoria, "La categoria no es valida");
            }
            if (cboMarca.SelectedIndex.Equals(-1))
            {
                valido = false;
                errorProvider1.SetError(cboMarca, "La marca del producto no es valida");
            }

            return valido;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
                
            

        }

        internal Producto GetObjeto()
        {
            return prod;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CategoriasBD.CargarCombo(ref cboCategoria);
            MarcasBD.CargarCombo(ref cboMarca);
            if (prod!=null)
            {
                txtCodigo.Text = prod.CodigoBarra.ToString();
                cboCategoria.SelectedValue = prod.idCategoria.IdCategoria;
                cboMarca.SelectedValue = prod.idMarca.IdMarca;
                cboMarca.SelectedItem = prod.idMarca.IdMarca;
                txtDescripcion.Text = prod.DescripcionProducto.ToString();
                txtPrecio.Text = prod.Precio.ToString();
                txtStock.Text = prod.Stock.ToString();

                if (prod.Estado==EstadoProducto.Activo)
                {
                    chkEstado.Checked=true;
                }
                else 
                {
                    chkEstado.Checked = false;
                }
                
            }
        }

        internal decimal GetPrecio(Producto idProducto)
        {
            return prod.Precio;
        }


        internal void SetObjeto(Producto obj)
        {
            this.prod = obj;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnAddMarc_Click(object sender, EventArgs e)
        {
            frmMarcaAE frm = new frmMarcaAE();
            frm.Text = "Agregar marca";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Marca m = frm.GetObjeto();
                    MarcasBD.Agregar(m);

                    MarcasBD.CargarCombo(ref cboMarca);


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm = new frmCategoriaAE();
            frm.Text = "Agregar categoria";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Categoria c = frm.GetObjeto();
                    CategoriasBD.Agregar(c);

                    CategoriasBD.CargarCombo(ref cboCategoria);


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void txtPrecio_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtPrecio, "El valor no es valido");
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtPrecio, "El valor no es valido");
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtPrecio, "El valor no es valido");
            }
        }

        private void txtStock_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtStock, "El valor no es valido");
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtStock, "El valor no es valido");
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtStock, "El valor no es valido");
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
