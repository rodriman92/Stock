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
    public partial class frmLogin : Form
    {
        Usuario user;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (user==null)
                {
                    user = new Usuario();
                }
                

                if (UsuariosBD.ValidarUsuario(cboUsuario.Text, txtClave.Text)>0)
                {
                    
                    this.Hide();
                    string parametro = cboUsuario.Text;
                    frmPrincipal frm2 = new frmPrincipal();
                    frm2.SetLogin(parametro);


                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta. Reintente");
                    cboUsuario.SelectedIndex=0;
                    txtClave.Clear();
                    cboUsuario.Focus();
                }
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboUsuario.SelectedIndex.Equals(0))
            {
                valido = false;
                errorProvider1.SetError(cboUsuario, "Seleccione");
            }
            if (string.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtClave, "El campo no puede estar vacio");

            }

            return valido;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cboUsuario.Focus();
            //cboUsuario.DroppedDown = true;
            cboUsuario.SelectedIndex=0;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboUsuario_DropDown(object sender, EventArgs e)
        {

        }
    }
}
