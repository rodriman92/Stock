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
    public partial class frmVentas : Form
    {
        private List<ReciboVenta> listaVta;
        private static frmVentas _instancia;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmClientesAE2 frm = new frmClientesAE2();
            frm.Show();
            //frmVentasAE frm = new frmVentasAE();
            //frm.Text = "Agregar venta";
            //DialogResult dr = frm.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    try
            //    {
            //        Venta v1 = frm.GetObjeto();
            //        VentasBD.Agregar(v1);

            //        DataGridViewRow r = new DataGridViewRow();
            //        r.CreateCells(dgVentas);
            //        SetearFilas(r, v1);
            //        AgregarFila(r);


            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
        }

        private void SetearFilas(DataGridViewRow r, ReciboVenta v1)
        {
            r.Cells[cmnFecha.Index].Value = v1.Fecha.ToShortDateString();
            r.Cells[cmnCliente.Index].Value = v1.cliente;
            r.Cells[cmnProducto.Index].Value = v1.producto;
            r.Cells[cmnCantidad.Index].Value = v1.Cantidad;
            r.Cells[cmnPrecioU.Index].Value = v1.PrecioU;
            r.Cells[cmnImporte.Index].Value = v1.Importe;
            r.Cells[cmnPago.Index].Value = v1.Entrada;
            r.Cells[cmnDebe.Index].Value = v1.Salida;
            
            

            r.Tag = v1;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgVentas.Rows.Add(r);
        }

        internal static frmVentas GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmVentas();
            }
            _instancia.BringToFront();
            return _instancia;
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgVentas.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgVentas.SelectedRows[0];
                ReciboVenta v = (ReciboVenta)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format("¿Desea borrar la venta?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ReciboVtaBD.Borrar(v);


                        dgVentas.Rows.Remove(r);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            List<ReciboVenta> listaVenta = ReciboVtaBD.GetLista();
            MostrarDatosGrilla(listaVenta);
        }

        private void MostrarDatosGrilla(List<ReciboVenta> listaVenta)
        {
            dgVentas.Rows.Clear();

            foreach (ReciboVenta v1 in listaVenta)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgVentas);
                SetearFilas(r, v1);
                AgregarFila(r);
            }
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmRecaudacion frm = new frmRecaudacion();
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmRankingVentas ranking = new frmRankingVentas();
            ranking.Show();
        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgVentas.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgVentas.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgVentas.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Ventas.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

                System.Diagnostics.Process.Start(@"C:\\PDFs\\");



            }
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        internal void ActualizarDatos()
        {
            listaVta = new List<ReciboVenta>();
            try
            {
                listaVta = ReciboVtaBD.GetLista();
                MostrarDatosGrilla(listaVta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void toolBuscarVtaFecha_Click(object sender, EventArgs e)
        {
            frmBuscarVtaFecha frm = new frmBuscarVtaFecha();
            frm.Text = "Buscar ventas";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                DateTime fec1 = frm.GetFechaDesde();
                DateTime fec2 = frm.GetFechaHasta();
                List<ReciboVenta> lista = new List<ReciboVenta>();
                lista = ReciboVtaBD.GetVentasxFecha(fec1, fec2);
                MostrarDatosGrilla(lista);
            }
        }

        private void tspActualizar_Click(object sender, EventArgs e)
        {
            dgVentas.Rows.Clear();
            listaVta = ReciboVtaBD.GetLista();
            MostrarDatosGrilla(listaVta);
        }
    }
}
