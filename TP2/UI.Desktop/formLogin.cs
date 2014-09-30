using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        Business.Logic.UsuarioLogic usu;
        public formLogin()
        {
            InitializeComponent();
            usu = new Business.Logic.UsuarioLogic();
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            validarLogin();
        }      
        
        /// <summary>
        /// Muestra si el usuario/contraseña es correcto o nó.
        /// </summary>
        private void validarLogin()
        {
            try
            {
                if (txtUsuario.Text.Length > 0 && txtPass.Text.Length > 0)
                {
                    if (usu.identificarUsuario(txtUsuario.Text, txtPass.Text))
                    {
                        MessageBox.Show("Usted ha ingresado al sistema correctamente."
                        , "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetFields();
                    }
                }
                else
                {
                    MessageBox.Show("Tiene que ingresar el nombre y la contraseña para poder ingresar", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetFields();
            }

        }
        /// <summary>
        /// Borra los campos usuario y contraseña y pone el foco en usuario
        /// </summary>
        private void resetFields()
        {
            txtUsuario.Clear();
            txtPass.Clear();            
            txtUsuario.Focus();
        }

    }
}
