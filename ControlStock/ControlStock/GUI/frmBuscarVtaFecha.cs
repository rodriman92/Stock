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
    public partial class frmBuscarVtaFecha : Form
    {
        DateTime fechaDesde, fechaHasta;
        public frmBuscarVtaFecha()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            this.DialogResult = DialogResult.OK;
            
        }

        internal DateTime GetFechaDesde()
        {
            return fechaDesde;
        }

        private void frmBuscarVtaFecha_Load(object sender, EventArgs e)
        {
            //dtpDesde.Format = DateTimePickerFormat.Custom;
            //dtpDesde.CustomFormat = "yyyyMMdd";

            //dtpHasta.Format = DateTimePickerFormat.Custom;
            //dtpHasta.CustomFormat = "yyyyMMdd";

        }

        internal DateTime GetFechaHasta()
        {
            return fechaHasta;
        }
    }
}
