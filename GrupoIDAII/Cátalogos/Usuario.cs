using GrupoIDAII.BD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoIDAII.Cátalogos
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }
        private void Usuario_Load(object sender, EventArgs e)
        {
            cargarUsuarios();

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desactivar();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 | txtAlias.Text.Length == 0 | txtCorreo.Text.Length == 0 | txtCorreo.Text.Length == 0 | cbArea.Text.Length == 0)
            {
                MessageBox.Show("Existen campos vacíos");
            }
            else if (ComprobarFormatoEmail(txtCorreo.Text) == false)
            {
                MessageBox.Show("La dirección de correo electrónico no es valida");
            }
            else if (ComprobarFormatoEmail(txtCorreo.Text) == true)
            {
                cargarUsuarios();
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                string alias = txtAlias.Text;
                string pass = txtPass.Text;
                string area = cbArea.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    Usuarios usuario = new Usuarios
                    {
                        nombre = nombre,
                        correo = correo,
                        alias = alias,
                        contrasenia = pass,
                        departamento = area,
                        
                    };
                    Desactivar();
                    contexto.Usuarios.Add(usuario);
                    contexto.SaveChanges();
                    cargarUsuarios();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt16(this.txtID.Text);
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                string alias = txtAlias.Text;
                string pass = txtPass.Text;
                string area = cbArea.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    Usuarios usuario = contexto.Usuarios.FirstOrDefault(x => x.id == id);
                    usuario.nombre = nombre;
                    usuario.correo = correo;
                    usuario.alias = alias;
                    usuario.contrasenia = pass;
                    usuario.departamento = area;
                    contexto.SaveChanges();
                    cargarUsuarios();
                    Limpiar();
                    Desactivar();
                }
                MessageBox.Show("Los datos han sido modificados");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea borrarlo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgUsuarios.SelectedRows.Count == 1)
                {

                    int id = Convert.ToInt16(this.txtID.Text);
                    using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                    {
                        Usuarios usuarios = contexto.Usuarios.FirstOrDefault(x => x.id == id);
                        contexto.Usuarios.Remove(usuarios);
                        contexto.SaveChanges();
                        cargarUsuarios();
                        Desactivar();
                        Limpiar();
                    }
                }
                else
                {
                    if (MessageBox.Show("Seleccione", "Advertencia",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);

                }
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Reporte_Usuario reporte = new Reporte_Usuario();
            reporte.ShowDialog();
        }
        public void Activar()
        {
            txtNombre.Enabled = true;
            txtCorreo.Enabled = true;
            txtAlias.Enabled = true;
            txtPass.Enabled = true;
            cbArea.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            dgUsuarios.Enabled = false;
            btnAgregar.Enabled = false;
        }
        public void Desactivar()
        {
            txtNombre.Enabled = false;
            txtCorreo.Enabled = false;
            txtAlias.Enabled = false;
            txtPass.Enabled = false;
            cbArea.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            dgUsuarios.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public void Activar_()
        {
            txtNombre.Enabled = true;
            txtCorreo.Enabled = true;
            txtAlias.Enabled = true;
            txtPass.Enabled = true;
            cbArea.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            dgUsuarios.Enabled = true;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtAlias.Clear();
            txtPass.Clear();
            cbArea.Items.Clear();
            dgUsuarios.ClearSelection();
        }
        public static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void cargarUsuarios()
        {
            GrupoIDAIIEntities1 grupoContext = new GrupoIDAIIEntities1();
            dgUsuarios.DataSource = grupoContext.Usuarios.ToList();
            dgUsuarios.Columns[0].HeaderText = "No.";
            dgUsuarios.Columns[1].HeaderText = "Nombre del empleado";
            dgUsuarios.Columns[2].HeaderText = "Correo electrónico";
            dgUsuarios.Columns[3].HeaderText = "Alías";
            dgUsuarios.Columns[4].HeaderText = "Contraseña";
            dgUsuarios.Columns[5].HeaderText = "Departamento";


        }
        public void llenarTexbox()
        {
            
            this.txtID.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            this.txtNombre.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            this.txtCorreo.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
            this.txtAlias.Text = dgUsuarios.CurrentRow.Cells[3].Value.ToString();
            this.txtPass.Text = dgUsuarios.CurrentRow.Cells[4].Value.ToString();
            this.cbArea.Text = dgUsuarios.CurrentRow.Cells[5].Value.ToString();
        }
        
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else
            {
                if (txtNombre.Text.Length == 30)
                {
                    MessageBox.Show("Ha alcanzado el número máximo de caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtAlias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else
            {
                if (txtAlias.Text.Length == 10)
                {
                    MessageBox.Show("Ha alcanzado el número máximo de caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAlias.Text.Length == 8)
            {
                MessageBox.Show("Ha alcanzado el número máximo de caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgUsuarios_Click(object sender, EventArgs e)
        {
            llenarTexbox();
            Activar_();
        }
    }
}
