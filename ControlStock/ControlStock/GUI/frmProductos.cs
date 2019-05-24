using ControlStock.BL;
using ControlStock.Datos;
using DGVPrinterHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.GUI
{
    
    public partial class frmProductos : Form
    {
        List<Producto> listaP;
        string producto;
        string usuarioLogin;
        private static frmProductos _instancia;
        public frmProductos()
        {
            InitializeComponent();
        }

        internal static frmProductos GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmProductos();
            }
            _instancia.BringToFront();
            return _instancia;
        }



        private void frmProductos_Load(object sender, EventArgs e)
        {
            if (usuarioLogin=="mostrador")
            {
                toolStripMenuItem1.Enabled = false;
                eDITARToolStripMenuItem.Enabled = false;
                bORRARToolStripMenuItem.Enabled = false;
            }
            txtFiltro.Focus();
            
        }

        private void MostrarDatosGrilla(List<Producto> lista)
        {
            dgProductos.Rows.Clear();

            foreach (Producto pro in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgProductos);
                SetearFilas(r, pro);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgProductos.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Producto pro)
        {
            r.Cells[cmnCodigoBarra.Index].Value = pro.CodigoBarra;
            r.Cells[cmnCategoria.Index].Value = pro.idCategoria.DescripcionCategoria;
            r.Cells[cmnMarca.Index].Value = pro.idMarca.DescripcionMarca;
            r.Cells[cmnDescripcion.Index].Value = pro.DescripcionProducto;
            r.Cells[cmnPrecio.Index].Value = "$"+pro.Precio;
            r.Cells[cmnStock.Index].Value = pro.Stock;
            r.Cells[cmnEstado.Index].Value = pro.Estado;
            

            r.Tag = pro;
        }

        internal void SetLogin(string resultadoLogin)
        {
            usuarioLogin = resultadoLogin;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(dgProductos);
                    SetearFilas(r, p1);
                    AgregarFila(r);
                    dgProductos.Rows.Clear();

                }

                catch (Exception)
                {

                    throw;
                }
            }
            Actualizar();
        }

        private void Actualizar()
        {
            try
            {
                List<Producto> lista = ProductosBD.GetLista();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count<=0)
            {
                MessageBox.Show("Seleccione un registro para editar");
            }
            else
            {
                DataGridViewRow r = dgProductos.SelectedRows[0];
                Producto obj = (Producto)r.Tag;
                Producto objAux = (Producto)obj.Clone();
                frmProductosAE frm = new frmProductosAE();
                frm.Text = "Editar reparacion";
                frm.SetObjeto(obj);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    obj = frm.GetObjeto();
                    ProductosBD.Editar(obj);
                    SetearFilas(r, obj);

                    MessageBox.Show("Registro actualizado correctamente");
                    Actualizar();
                }
                catch (Exception)
                {

                }
            }

          }
            
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgProductos.SelectedRows[0];
                Producto p = (Producto)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format("¿Desea borrar el producto?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ProductosBD.Borrar(p.IdProducto);


                        dgProductos.Rows.Remove(r);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarPorCodigoBarra frm = new frmBuscarPorCodigoBarra();
            frm.Text = "Buscar producto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string codigo = frm.GetCodigo();
                List<Producto> lista = new List<Producto>();
                lista = ProductosBD.GetProductosPorCodigo(codigo);
                MostrarDatosGrilla(lista);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listaP = new List<Producto>();
            try
            {
                listaP = ProductosBD.GetLista();
                MostrarDatosGrilla(listaP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((int)this.dgProductos.Rows[e.RowIndex].Cells["cmnStock"].Value <= 8)
            {

                foreach (DataGridViewCell celda in
                this.dgProductos.Rows[e.RowIndex].Cells)
                {
                    celda.Style.BackColor = Color.Red;
                    celda.Style.ForeColor = Color.White;
                }
            }

        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgProductos.ColumnCount);
            
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgProductos.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgProductos.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Productos.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

                System.Diagnostics.Process.Start(@"C:\\PDFs\\");



            }

            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = "Listado de productos";
            //printer.SubTitle = string.Format("Fecha: {0}", DateTime.Now.Date);
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.Footer = "Control de Stock RM";
            //printer.FooterSpacing = 15;
            //printer.PrintDataGridView(dgProductos);
            //printer.PageSettings.Landscape = true;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text == "")
            {
                dgProductos.Rows.Clear();
            }
            else
            {
                txtFiltro.CharacterCasing = CharacterCasing.Upper;

                producto = txtFiltro.Text;
                List<Producto> listaFiltrada = new List<Producto>();
                listaFiltrada = ProductosBD.GetListaFilrada(producto);
                MostrarDatosGrilla(listaFiltrada);
                this.DialogResult = DialogResult.OK;

            }

            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(string.Format("La carga de datos puede demorar tiempo. Desea continuar?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    List<Producto> lista = ProductosBD.GetLista();

                    MostrarDatosGrilla(lista);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
