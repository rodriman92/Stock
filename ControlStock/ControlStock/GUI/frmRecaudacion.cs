using ControlStock.Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock.GUI
{
    public partial class frmRecaudacion : Form
    {
        public frmRecaudacion()
        {
            InitializeComponent();
        }

        private void frmRecaudacion_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string selectComando = "Select ReciboVenta.Fecha, SUM(ReciboVenta.Importe)as Recaudacion from ReciboVenta Group by fecha Order by fecha desc";
                    SqlDataAdapter da = new SqlDataAdapter(selectComando, cnn);

                    DataTable dt = new DataTable();



                    //object total = dt.Compute("SUM(Gastos)", null);
                    da.Fill(dt);
                    dgRecaudacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgRecaudacion.DataSource = dt;

                    double sumatoria = 0.00;

                    foreach (DataGridViewRow row in dgRecaudacion.Rows)
                    {
                        sumatoria += Convert.ToInt32(row.Cells["Recaudacion"].Value);
                    }

                    txtRecaudacion.Text = Math.Round(sumatoria, 2).ToString();

                    cnn.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgRecaudacion.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgRecaudacion.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgRecaudacion.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Recaudacion.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                pdfDoc.AddHeader("Listado de productos","Listado de productos");
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

                System.Diagnostics.Process.Start(@"C:\\PDFs\\");



            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgRecaudacion.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgRecaudacion.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgRecaudacion.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Recaudacion.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                pdfDoc.AddHeader("Listado de productos", "Recaudacion");
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

