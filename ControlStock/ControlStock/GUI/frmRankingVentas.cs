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
    public partial class frmRankingVentas : Form
    {
        public frmRankingVentas()
        {
            InitializeComponent();
        }

        private void frmRankingVentas_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = ConexionBD.GetConexion())
            {
                try
                {
                    cnn.Open();
                    string selectComando = "select top 10 SUM(reciboventa.cantidad)as Cantidad, Reciboventa.Producto FROM ReciboVenta Group by Producto order by Cantidad desc";
                    SqlDataAdapter da = new SqlDataAdapter(selectComando, cnn);

                    DataTable dt = new DataTable();



                    //object total = dt.Compute("SUM(Gastos)", null);
                    da.Fill(dt);
                    dgRanking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgRanking.DataSource = dt;

                    cnn.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgRanking.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgRanking.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgRanking.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Ranking.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                pdfDoc.AddHeader("Listado de productos", "Ranking de ventas");
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
