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
    public partial class frmProveedores : Form
    {
        private static frmProveedores _instancia;
        string datosCliente;
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(dgProveedor);
                    SetearFilas(r, prov);
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
            dgProveedor.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Proveedor prov)
        {
            r.Cells[cmnProv.Index].Value = prov.DescripcionProveedor;
            r.Cells[cmnCUIT.Index].Value = prov.CUIT;
            r.Cells[cmnTel.Index].Value = prov.Telefono;
            r.Cells[cmnDireccion.Index].Value = prov.Direccion;
            r.Cells[cmnEmail.Index].Value = prov.Email;
            r.Cells[cmnLocalidad.Index].Value = prov.Localidad;

            r.Tag = prov;
        }

        internal static frmProveedores GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmProveedores();
            }
            _instancia.BringToFront();
            return _instancia;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgProveedor.SelectedRows[0];
            Proveedor obj = (Proveedor)r.Tag;
            Proveedor objAux = (Proveedor)obj.Clone();
            frmProveedoresAE frm = new frmProveedoresAE();
            frm.Text = "Editar proveedor";
            frm.SetObjeto(obj);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    obj = frm.GetObjeto();
                    ProveedoresBD.Editar(obj);
                    SetearFilas(r, obj);

                    MessageBox.Show("Registro actualizado correctamente");
                    Actualizar();
                }
                catch (Exception)
                {

                }
            }
        }

        private void Actualizar()
        {
            throw new NotImplementedException();
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgProveedor.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgProveedor.SelectedRows[0];
                Proveedor p = (Proveedor)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format("¿Desea borrar el proveedor?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ProveedoresBD.Borrar(p.IdProveedor);


                        dgProveedor.Rows.Remove(r);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            txtCliente.CharacterCasing = CharacterCasing.Upper;
            txtCliente.Focus();
            try
            {

                List<Proveedor> lista = ProveedoresBD.GetLista();

                MostrarDatosGrilla(lista);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MostrarDatosGrilla(List<Proveedor> lista)
        {
            dgProveedor.Rows.Clear();

            foreach (Proveedor pro in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgProveedor);
                SetearFilas(r, pro);
                AgregarFila(r);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iMPRIMIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgProveedor.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dgProveedor.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in dgProveedor.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Proveedores.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                pdfDoc.AddHeader("Listado de proveedores", "Proveedores");
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();

                System.Diagnostics.Process.Start(@"C:\\PDFs\\");



            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            datosCliente = txtCliente.Text;
            List<Proveedor> listaFiltrada = new List<Proveedor>();
            listaFiltrada = ProveedoresBD.GetListaFilrada(datosCliente);
            MostrarDatosGrilla(listaFiltrada);
            this.DialogResult = DialogResult.OK;
        }
    }
}
