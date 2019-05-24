using ControlStock.BL;
using ControlStock.Datos;
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
    public partial class frmMarcas : Form
    {
        private static frmMarcas _instancia;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(dgMarca);
                    SetearFilas(r, m);
                    AgregarFila(r);


                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        internal static frmMarcas GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmMarcas();
            }
            _instancia.BringToFront();
            return _instancia;

        }
        private void MostrarDatosGrilla(List<Marca> lista)
        {
            dgMarca.Rows.Clear();

            foreach (Marca mar in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgMarca);
                SetearFilas(r, mar);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgMarca.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Marca m)
        {

            r.Cells[cmnMarca.Index].Value = m.DescripcionMarca;

            r.Tag = m;
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMarca.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgMarca.SelectedRows[0];
                Marca obj = (Marca)r.Tag;
                frmMarcaAE frm = new frmMarcaAE();
                frm.Text = "Borrar registro";
                frm.SetObjeto(obj);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        MarcasBD.Borrar(obj.IdMarca);
                        dgMarca.Rows.Remove(r);

                        MessageBox.Show("Registro eliminado correctamente");

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error al intentar borrar un registro", "Error");
                    }
                }
            }
        }

        private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgMarca.SelectedRows[0];
            Marca obj = (Marca)r.Tag;
            Marca objAux = (Marca)obj.Clone();
            frmMarcaAE frm = new frmMarcaAE();
            frm.Text = "Editar marca";
            frm.SetObjeto(obj);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    obj = frm.GetObjeto();
                    MarcasBD.Editar(obj);
                    SetearFilas(r, obj);

                    MessageBox.Show("Registro actualizado correctamente");
                    Actualizar();
                }
                catch (Exception )
                {
                    MessageBox.Show("Error al actualizar registro");
                }
            }
        }

        private void Actualizar()
        {
            List<Marca> listaM = MarcasBD.GetLista();
            MostrarDatosGrilla(listaM);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            try
            {

                List<Marca> lista = MarcasBD.GetLista();

                MostrarDatosGrilla(lista);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
