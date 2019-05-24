using ControlStock.BL;
using ControlStock.Datos;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.GUI
{
    public partial class frmCompraAE : Form
    {
        Compra compra;
        Producto producto;
        Proveedor prv;
        string idProd;
        
        
        
        public frmCompraAE()
        {
            InitializeComponent();
        }
        internal int ObtenerId()
        {
            return int.Parse(lbNroIDProd.Text);
        }

        private void frmCompraAE_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = ConexionBD.GetConexion();
            ConexionBD c = new ConexionBD();
            c.autoCompletarProducto(txtProducto);

            //Producto producto = new Producto();
            //producto= ProductosBD.GetDetalleProducto(txtProducto.Text);

            //txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //addItems(coleccion);
            //txtProducto.AutoCompleteCustomSource = coleccion;
            //txtProducto.Text = producto.CodigoBarra + " - " + producto.DescripcionProducto;
        }


        //private void addItems(AutoCompleteStringCollection coleccion)
        //{
        //    using (SqlConnection cnn = ConexionBD.GetConexion())
        //    {
        //        cnn.Open();
        //        DataTable tbl = new DataTable();

        //        SqlDataAdapter da = new SqlDataAdapter("Select CodigoBarra, DescripcionProducto from Productos", cnn);

        //        da.Fill(tbl);
        //        foreach (DataRow X in tbl.Rows)
        //        {
        //            coleccion.Add(X[0].ToString());
        //        }
        //        cnn.Close();
        //    }
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (compra==null)
                {
                    compra = new Compra();
                }
                compra.Producto = lbNroIDProd.Text;
                compra.idProveedor = (Proveedor)cboProveedor.SelectedItem;
                compra.Cantidad = int.Parse(txtCantidad.Text);
                compra.Fecha = dtpFechaCompra.Value;
                compra.Importe = decimal.Parse(txtImporte.Text) * int.Parse(txtCantidad.Text);
                
                this.DialogResult = DialogResult.OK;
            }
        }

        internal Compra GetObjeto()
        {
           
            return compra;
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProducto, "Debe seleccionar un producto");
            }

            if (cboProveedor.SelectedIndex.Equals(0))
            {
                valido = false;
                errorProvider1.SetError(cboProveedor, "Seleccione un proveedor");
            }
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Los datos no son correctos");
            }
            if (string.IsNullOrEmpty(txtImporte.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtImporte, "El campo no puede estar vacio");
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

        internal void SetObjeto(Compra obj)
        {
            this.compra = obj;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            ProveedoresBD.CargarCombo(ref cboProveedor);

            if (compra!=null)
            {
                txtProducto.Text = compra.Producto;
                cboProveedor.SelectedValue = compra.idProveedor.IdProveedor;
                txtCantidad.Text = compra.Cantidad.ToString();
                dtpFechaCompra.Value = compra.Fecha;
                if (string.IsNullOrEmpty(txtImporte.Text.Trim()))
                {
                    txtImporte.Text = "";
                }
                else
                {
                    txtTotal.Text = compra.Importe.ToString();

                }
                
            }
        }

        private void cboProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            
        }

       

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            //{

            //    txtImporte.Text = "";
            //    txtTotal.Text = "";
            //}
            //else
            //{
            //    int cant = int.Parse(txtCantidad.Text);
            //    if (!string.IsNullOrEmpty(txtImporte.Text.Trim()))
            //    {
            //        decimal importe = decimal.Parse(txtImporte.Text);
            //        decimal total;


            //        total = cant * importe;
            //        txtTotal.Text = importe.ToString();

            //    }
            //    else
            //    {
            //        errorProvider1.SetError(txtImporte, "Los datos no son correctos");
            //    }
                

                

                

            //}

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImporte.Text.Trim()))
            {
                int cant = int.Parse(txtCantidad.Text);
                decimal importe = decimal.Parse(txtImporte.Text);
                decimal total;


                total = cant * importe;
                txtTotal.Text = "$" + total.ToString();

            }
            else
            {
                errorProvider1.SetError(txtImporte, "Los datos no son correctos");
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator

                )

                
                e.Handled = false;

            else
                
                e.Handled = true;
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE();
            frm.Text = "Agregar proveedor";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Proveedor prov = frm.GetObjeto();
                    ProveedoresBD.Agregar(prov);




                }
                catch (Exception)
                {

                    throw;
                }
            }
            ProveedoresBD.CargarCombo(ref cboProveedor);
        }

        private void cboProveedor_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            prv = (Proveedor)cboProveedor.SelectedItem;
            txtDetalleProv.Text = "Razon Social: " + prv.DescripcionProveedor + Environment.NewLine + "CUIT: " + prv.CUIT + Environment.NewLine + "Direccion: " + prv.Direccion + Environment.NewLine + "Tel: " + prv.Telefono + Environment.NewLine + "Email: " + prv.Email;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            
            
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                MessageBox.Show("Debe escribir el nombre de un producto");
            }
            else
            {

                producto = new Producto();
                producto = ProductosBD.GetDetalleProducto(txtProducto.Text);
                if (producto!=null)
                {
                    txtProducto.Text = producto.CodigoBarra + " - " + producto.DescripcionProducto;
                    txtCantidad.Focus();
                    lbNroIDProd.Text = producto.IdProducto.ToString();
                    


                }
                else
                {
                    MessageBox.Show("El producto no existe. Reintente");
                    txtProducto.Clear();
                    txtProducto.Focus();
                }

                
                



            }
        }
    }
}
