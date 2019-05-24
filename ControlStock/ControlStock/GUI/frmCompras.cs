using ControlStock.BL;
using ControlStock.Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class frmCompras : Form
    {
        private static frmCompras _instancia;

        
        frmCompraAE frm;

        int p = 0;
        public frmCompras()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCompraAE frm = new frmCompraAE();
            frm.Text = "Agregar compra";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    
                    Compra c1 = frm.GetObjeto();

                    int IdObj = frm.ObtenerId();

                    ComprasBD.Agregar(c1, IdObj);

                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(dgCompras);
                    SetearFilas(r, c1);
                    AgregarFila(r);


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
            private void AgregarFila(DataGridViewRow r)
        {
            dgCompras.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Compra c1)
        {
            r.Cells[cmnProducto.Index].Value = ProductosBD.GetObjeto(c1.Producto);
            r.Cells[cmnProv.Index].Value = c1.idProveedor.DescripcionProveedor;
            r.Cells[cmnCantidad.Index].Value = c1.Cantidad;
            r.Cells[cmnFecha.Index].Value = c1.Fecha.ToShortDateString();
            r.Cells[cmnImporte.Index].Value = "$"+c1.Importe;


            r.Tag = c1;
        }

        internal static frmCompras GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmCompras();
            }
            _instancia.BringToFront();
            return _instancia;
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCompras.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgCompras.SelectedRows[0];
                Compra c = (Compra)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format("¿Desea borrar la compra?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ComprasBD.Borrar(c);


                        dgCompras.Rows.Remove(r);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            try
            {


                List<Compra> lista = ComprasBD.GetLista();

                MostrarDatosGrilla(lista);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MostrarDatosGrilla(List<Compra> lista)
        {
            dgCompras.Rows.Clear();

            foreach (Compra com in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgCompras);
                SetearFilas(r, com);
                AgregarFila(r);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmGastos frm = new frmGastos();
            frm.Show();
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgCompras.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgCompras.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgCompras.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Compras.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                pdfDoc.AddHeader("Listado de compras", "Compras");
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

                System.Diagnostics.Process.Start(@"C:\\PDFs\\");



            }
        }
    }
    
}
