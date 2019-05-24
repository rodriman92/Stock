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
    public partial class frmVentasAE : Form
    {
        Venta venta;
        Producto prod;
        public frmVentasAE()
        {
            InitializeComponent();
        }

        private void frmVentasAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (venta == null)
                {
                    venta = new Venta();
                }
                venta.idProducto = (Producto)cboProducto.SelectedItem;
                
                venta.Cantidad = int.Parse(txtCantidad.Text);
                venta.Fecha = dtpFechaCompra.Value;
                venta.Importe = decimal.Parse(txtImporte.Text);

                this.DialogResult = DialogResult.OK;
            }
        }

        internal Venta GetObjeto()
        {
            return venta;
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboProducto.SelectedIndex.Equals(0))
            {
                valido = false;
                errorProvider1.SetError(cboProducto, "Seleccione un producto");
            }

            
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Los datos no son correctos");
            }
            int cantidad = int.Parse(txtCantidad.Text);
            if (!ProductosBD.RevisarStock(cantidad, prod))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Stock insuficiente");
            }
            return valido;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtCantidad, "El valor no es valido");
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtCantidad, "El valor no es valido");
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                errorProvider1.SetError(txtCantidad, "El valor no es valido");
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProductosBD.CargarComboActivos(ref cboProducto);
            

            if (venta != null)
            {
                cboProducto.SelectedValue = venta.idProducto.IdProducto;
                
                txtCantidad.Text = venta.Cantidad.ToString();
                dtpFechaCompra.Value = venta.Fecha;
                if (string.IsNullOrEmpty(txtImporte.Text.Trim()))
                {
                    txtImporte.Text = "";
                }
                else
                {
                    txtImporte.Text = venta.Importe.ToString();

                }

            }
        }

        private void cboProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            prod = (Producto)cboProducto.SelectedItem;
            txtDetalleProd.Text = "Categoria: " + prod.idCategoria.DescripcionCategoria + Environment.NewLine + "Marca: " + prod.idMarca.DescripcionMarca + Environment.NewLine + "Precio: " + prod.Precio + Environment.NewLine + "Stock: " + prod.Stock;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {

                txtImporte.Text = "";
            }

            else
            {
                int cant = int.Parse(txtCantidad.Text);
                decimal importe;
                Producto p = ProductosBD.GetPrecio(prod.IdProducto);


                importe = cant * p.Precio;

                txtImporte.Text = importe.ToString();

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProductosAE frm = new frmProductosAE();
            frm.Text = "Agregar producto";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Producto p1 = frm.GetObjeto();
                    ProductosBD.Agregar(p1);

                    


                }
                catch (Exception)
                {

                    throw;
                }
            }
            ProductosBD.CargarCombo(ref cboProducto);
        }
    }
}
