using GrupoIDAII.Cátalogos;
using Soporte.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoIDAII
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CargarUsuario();
        }

        private void CargarUsuario()
        {
            lblNombre.Text = InicioSesionUsuario.Nombre;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuario frm = new Usuario();
            AbrirFormInPanel(frm);
        }

        private void btnAdmon_Click(object sender, EventArgs e)
        {
            Administracion frm = new Administracion();
            AbrirFormInPanel(frm);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cerrar la sesión?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            this.Close();
        }
    }
}
