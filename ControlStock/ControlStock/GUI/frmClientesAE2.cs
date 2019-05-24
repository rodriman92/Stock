using ControlStock.BL;
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
    public partial class frmClientesAE2 : Form
    {
        private DataTable dt;
        

        public frmClientesAE2()
        {
            InitializeComponent();
        }

        private void frmClientesAE2_Load(object sender, EventArgs e)
        {
            txtCliente.Focus();

            dt = new DataTable();
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Precio Unitario");
            dt.Columns.Add("Importe");

            DGV.DataSource = dt;

            //facModelo = ControlStock.Properties.Resources.FactModel;

            SqlConnection cnn = ConexionBD.GetConexion();
            ConexionBD c = new ConexionBD();
            c.autoCompletar(txtProducto, txtPrecUn);
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPrecUn_TextChanged(object sender, EventArgs e)
        {
            if (!(txtCantidad.Text.Equals("") || txtPrecUn.Text.Equals("")))
                txtImporte.Text = (Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(txtPrecUn.Text)).ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                MessageBox.Show("Debe escribir el nombre de un producto");
            }
            else
            {

                Producto producto = new Producto();
                producto = ProductosBD.GetDetalleProducto(txtProducto.Text);
                if (producto!=null)
                {
                    txtPrecUn.Text = producto.Precio.ToString();
                    txtExistencia.Text = producto.Stock.ToString();
                    txtProducto.Text = producto.CodigoBarra + " - " + producto.DescripcionProducto;
                    txtCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("El producto no existe. Reintente");
                    txtProducto.Clear();
                    txtProducto.Focus();
                    
                }
                

                
            }

            
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Clear();
            txtPrecUn.Clear();
            txtCantidad.Clear();
            txtImporte.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
                {
                    errorProvider1.SetError(txtProducto, "El campo no puede estar vacio");
                    errorProvider1.SetError(txtCantidad, "El campo no puede estar vacio");
                }
                else
                {
                    errorProvider1.Clear();
                }


                if (camposCompletos() && DGV.Rows.Count < 10)
                {
                    añadirRegistro();
                    vaciarCampos();
                    txtProducto.Focus();
                }

                else
                {
                    MessageBox.Show("Se supero el limite de items. Realice otra factura");
                }
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProducto, "El campo no puede estar vacio");

            }
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "El campo no puede estar vacio");
            }
            return valido;

        }

        ReciboVenta recibo;
        private void AgregarABD()
        {
            foreach (DataGridViewRow r in DGV.Rows)
            {
                recibo.Fecha = dtpFecha.Value;
                recibo.cliente = txtCliente.Text;
                recibo.producto = r.Cells["Producto"].Value.ToString();
                recibo.Cantidad = int.Parse(r.Cells["Cantidad"].Value.ToString());
                recibo.PrecioU = decimal.Parse(r.Cells["Precio Unitario"].Value.ToString());
                recibo.Importe = decimal.Parse(r.Cells["Importe"].Value.ToString());
                recibo.Entrada = decimal.Parse(txtEntrada.Text);
                recibo.Salida = decimal.Parse(txtSalida.Text);

                ReciboVtaBD.Guardar(recibo);

            }
          
            this.DialogResult = DialogResult.OK;

            
        }

        private void vaciarCampos()
        {
            txtCantidad.Text = String.Empty;
            txtProducto.Clear();
            txtExistencia.Text = String.Empty;
            txtPrecUn.Text = String.Empty;
            txtImporte.Text = String.Empty;
            txtProducto.Focus();
        }

        private void añadirRegistro()
        {

            dt.Rows.Add(txtCantidad.Text, txtProducto.Text, txtPrecUn.Text, txtImporte.Text);
            DGV.DataSource = dt;
        }

        private Boolean camposCompletos()
        {
            if (txtCantidad.Text.Equals("") ||
txtPrecUn.Text.Equals("") || txtImporte.Text.Equals(""))
                return false;

            else
                return true;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (!(txtCantidad.Text.Equals("") || txtPrecUn.Text.Equals("")))
                txtImporte.Text = (Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(txtPrecUn.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recibo = new ReciboVenta();
            
            recibo.Entrada = decimal.Parse(txtEntrada.Text);
            recibo.Salida = decimal.Parse(txtSalida.Text);

            decimal sumatoria = 0;

            if (DGV.Rows.Count==0)
            {
                errorProvider1.SetError(button2, "Debe agregar un registro antes de cerrar el ticket");

            }
            else
            {
                errorProvider1.Clear();
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    sumatoria += Convert.ToDecimal(row.Cells["Importe"].Value);

                }
                txtImportePagar.Text = sumatoria.ToString("0.00");
                DeshabilitarIngreso();
                txtEntrada.SelectAll();

            }



        }

        private void DeshabilitarIngreso()
        {
            dtpFecha.Enabled = false;
            txtCliente.Enabled = false;
            txtProducto.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpiar.Enabled = false;
            txtCantidad.Enabled = false;
            btnAddLista.Enabled = false;
            txtEntrada.SelectAll();
        }

        private void txtEntrada_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEntrada.Text.Trim()))
            {

                txtEntrada.Text = " ";
            }
            else
            {
                recibo = new ReciboVenta();
                recibo.Entrada = decimal.Parse(txtEntrada.Text);
                recibo.Salida = decimal.Parse(txtSalida.Text);
                decimal sumatoria = 0;

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    sumatoria += Convert.ToDecimal(row.Cells["Importe"].Value);
                }



                if (sumatoria == recibo.Entrada)
                {
                    recibo.Salida = 0;
                    txtSalida.Text = recibo.Salida.ToString("0.00");
                    

                }
                else if (sumatoria > recibo.Entrada)
                {
                    recibo.Salida = (sumatoria - recibo.Entrada);
                    txtSalida.Text = recibo.Salida.ToString("0.00");
                    
                    
                }
                else if (recibo.Entrada > sumatoria)
                {
                    txtSuVuelto.Text = (recibo.Entrada - sumatoria).ToString() ;
                    txtSalida.Text = "0.00";
                }
                else if (recibo.Entrada < sumatoria)
                {
                    txtSuVuelto.Text = "0.00";
                    txtSalida.Text = (sumatoria - recibo.Entrada).ToString();
                }
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarABD();
            //foreach (DataGridViewRow r in DGV.Rows)
            //{
            //    recibo.dia = int.Parse(txtDia.Text);
            //    recibo.mes = int.Parse(txtMes.Text);
            //    recibo.año = int.Parse(txtAño.Text);
            //    recibo.cliente = txtCliente.Text;
            //    recibo.producto = txtProducto.Text;
            //    recibo.Cantidad = int.Parse(txtCantidad.Text);
            //    recibo.PrecioU = decimal.Parse(txtPrecUn.Text);

            //    recibo.Importe = recibo.PrecioU * recibo.Cantidad;
            //    recibo.Entrada = decimal.Parse(txtEntrada.Text);
            //    recibo.Salida = decimal.Parse(txtSalida.Text);
            //    //foreach (DataGridViewRow row in DGV.Rows)
            //    //{
            //    //    sumatoria += Convert.ToDecimal(row.Cells["Importe"].Value);
            //    //}
            //    ReciboVtaBD.Guardar(recibo);
            //}
            MessageBox.Show("Venta registrada!");
            this.Close();
            frmVentas frmVta = frmVentas.GetInstancia();
            frmVta.ActualizarDatos();
        }


        private void LimpiarControles()
        {
            
            dtpFecha.Enabled = true;
            txtCliente.Enabled = true;
            txtProducto.Enabled = true;
            btnBuscar.Enabled = true;
            btnLimpiar.Enabled = true;
            txtCantidad.Enabled = true;
            btnAddLista.Enabled = true;

            dtpFecha.Value = DateTime.Now;
            txtCliente.Clear();
            txtProducto.Clear();
            txtExistencia.Clear();
            txtCantidad.Clear();
            txtPrecUn.Clear();
            txtImporte.Clear();
            txtImportePagar.Clear();
            txtEntrada.Clear();
            txtSalida.Clear();
            txtCliente.Focus();
        }

    }
}
