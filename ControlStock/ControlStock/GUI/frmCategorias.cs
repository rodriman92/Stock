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
    public partial class frmCategorias : Form
    {
        public static frmCategorias _instancia;
        public frmCategorias()
        {
            InitializeComponent();
        }

        internal static frmCategorias GetInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmCategorias();
            }
            _instancia.BringToFront();
            return _instancia;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm = new frmCategoriaAE();
            frm.Text = "Agregar categoria";
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Categoria cat = frm.GetObjeto();
                    CategoriasBD.Agregar(cat);

                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(dgCategorias);
                    SetearFilas(r, cat);
                    AgregarFila(r);
                    Actualizar();


                }
                catch (Exception)
                {

                    MessageBox.Show("No se pudo agregar el registro. Reintente");
                }
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgCategorias.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Categoria c)
        {
            r.Cells[cmnCategoria.Index].Value = c.DescripcionCategoria;
            r.Cells[cmnCodCat.Index].Value = c.CodigoCategoria;

            r.Tag = c;
        }

        private void bORRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCategorias.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgCategorias.SelectedRows[0];
                Categoria obj = (Categoria)r.Tag;
                frmCategoriaAE frm = new frmCategoriaAE();
                frm.Text = "Borrar registro";
                frm.SetObjeto(obj);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        CategoriasBD.Borrar(obj.IdCategoria);
                        dgCategorias.Rows.Remove(r);

                        MessageBox.Show("Registro eliminado correctamente");
                        Actualizar();

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
            DataGridViewRow r = dgCategorias.SelectedRows[0];
            Categoria obj = (Categoria)r.Tag;
            Categoria objAux = (Categoria)obj.Clone();
            frmCategoriaAE frm = new frmCategoriaAE();
            frm.Text = "Editar categoria";
            frm.SetObjeto(obj);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    obj = frm.GetObjeto();
                    CategoriasBD.Editar(obj);
                    SetearFilas(r, obj);

                    MessageBox.Show("Registro actualizado correctamente");
                    Actualizar();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al actualizar registro");
                }
            }
        }

        private void Actualizar()
        {
            List<Categoria> listaCat = CategoriasBD.GetLista();
            MostrarDatosGrilla(listaCat);
        }

        private void MostrarDatosGrilla(List<Categoria> listaCat)
        {
            dgCategorias.Rows.Clear();

            foreach (Categoria categ in listaCat)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgCategorias);
                SetearFilas(r, categ);
                AgregarFila(r);
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                List<Categoria> listaC = new List<Categoria>();
                listaC = CategoriasBD.GetLista();
                MostrarDatosGrilla(listaC);
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al mostrar el listado");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
