using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using Dominio;

namespace GrupoIDAII
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Red;
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Red;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mensajeError(string msg)
        {
            lblMensaje.Text = "  " + msg;
            lblMensaje.Visible = true;

        }

        private void cerrarSesion(Object sender, FormClosedEventArgs e)
        {
            txtPass.Text = "Contraseña";
            txtPass.UseSystemPasswordChar = false;
            txtUsuario.Text = "Usuario";
            txtUsuario.UseSystemPasswordChar = false;
            lblMensaje.Visible = false;
            this.Show();
            txtUsuario.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtUsuario.Text != "Usuario")
                {
                    if (txtPass.Text != "Contraseña")
                    {
                        Usuario user = new Usuario();
                        var validacioLogin = user.LoginUsuario(txtUsuario.Text, txtPass.Text);
                        if (validacioLogin == true)
                        {
                            Menu formPrincipal = new Menu();
                            formPrincipal.Show();
                            formPrincipal.FormClosed += cerrarSesion;
                            this.Hide();
                        }
                        else
                        {
                            mensajeError("Datos incorrectos");
                            txtPass.Text = "Contraseña";
                            txtPass.UseSystemPasswordChar = false;
                            txtUsuario.Text = "Usuario";
                            txtUsuario.UseSystemPasswordChar = false;
                        }
                    }
                    else
                        mensajeError("Ingrese su contraseña");

                }
                else
                    mensajeError("Ingrese su nombre de usuario");
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (txtPass.Text != "Contraseña")
                {
                    Usuario user = new Usuario();
                    var validacioLogin = user.LoginUsuario(txtUsuario.Text, txtPass.Text);
                    if (validacioLogin == true)
                    {
                        Menu formPrincipal = new Menu();
                        formPrincipal.Show();
                        formPrincipal.FormClosed += cerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        mensajeError("Datos incorrectos");
                        txtPass.Text = "Contraseña";
                        txtPass.UseSystemPasswordChar = false;
                        txtUsuario.Text = "Usuario";
                        txtUsuario.UseSystemPasswordChar = false;
                    }
                }
                else
                    mensajeError("Ingrese su contraseña");

            }
            else
                mensajeError("Ingrese su nombre de usuario");
        }
    }
}
