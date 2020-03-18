using GrupoIDAII.BD;
using GrupoIDAII.Reportes.IDAII;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GrupoIDAII
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEmpresa.Text.Length == 0 | txtContacto.Text.Length == 0 | txtTelefono.Text.Length == 0 | txtCorreo.Text.Length == 0)
            {
                MessageBox.Show("Existen campos vacíos");
            }
            else if (ComprobarFormatoEmail(txtCorreo.Text) == false)
            {
                MessageBox.Show("La dirección de correo electrónico no es valida");
            }
            else if (ComprobarFormatoEmail(txtCorreo.Text) == true)
            {
                cargarClientes();
                string empresa = txtEmpresa.Text;
                string contacto = txtContacto.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    ClientesIDAII clientesIDAII = new ClientesIDAII
                    {
                        nomEmpresa = empresa,
                        nomContacto = contacto,
                        telefono = telefono,
                        correo = correo,

                    };
                    Desactivar();
                    contexto.ClientesIDAII.Add(clientesIDAII);
                    contexto.SaveChanges();
                    cargarClientes();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt16(this.txtID.Text);
                string empresa = txtEmpresa.Text;
                string contacto = txtContacto.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    ClientesIDAII clientesIDAII = contexto.ClientesIDAII.FirstOrDefault(x => x.id == id);
                    clientesIDAII.nomEmpresa = empresa;
                    clientesIDAII.nomContacto = contacto;
                    clientesIDAII.telefono = telefono;
                    clientesIDAII.correo = correo;
                    contexto.SaveChanges();
                    cargarClientes();
                    Limpiar();
                    Desactivar();
                }
                MessageBox.Show("Los datos han sido modificados");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desactivar();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea borrarlo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgClientes.SelectedCells.Count == 1)
                {

                    int id = Convert.ToInt16(this.txtID.Text);
                    using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                    {
                        ClientesIDAII clientes = contexto.ClientesIDAII.FirstOrDefault(x => x.id == id);
                        contexto.ClientesIDAII.Remove(clientes);
                        contexto.SaveChanges();
                        cargarClientes();
                        Desactivar();
                        Limpiar();
                    }
                }
                else
                {
                    if (MessageBox.Show("Seleccione", "Advertencia",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) ;

                }
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Reporte_Cliente rp = new Reporte_Cliente();
            rp.ShowDialog();
        }

        private void dgClientes_Click(object sender, EventArgs e)
        {
            llenarTexbox();
            Activar_();
        }
        public void Activar()
        {
            txtEmpresa.Enabled = true;
            txtContacto.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            dgClientes.Enabled = false;
            btnAgregar.Enabled = false;
        }
        public void Desactivar()
        {
            txtEmpresa.Enabled = false;
            txtContacto.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            dgClientes.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public void Activar_()
        {
            txtEmpresa.Enabled = true;
            txtContacto.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            dgClientes.Enabled = true;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        public void Limpiar()
        {
            txtEmpresa.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dgClientes.ClearSelection();
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

       public void cargarClientes()
        {
            GrupoIDAIIEntities1 grupoContext = new GrupoIDAIIEntities1();
            dgClientes.DataSource = grupoContext.ClientesIDAII.ToList();
            dgClientes.Columns[0].HeaderText = "No.";
            dgClientes.Columns[1].HeaderText = "Nombre de la empresa";
            dgClientes.Columns[2].HeaderText = "Nombre del contacto";
            dgClientes.Columns[3].HeaderText = "Télefono";
            dgClientes.Columns[4].HeaderText = "Correo";
            dgClientes.Columns[5].Visible = false;
            dgClientes.Columns[6].Visible = false; 
        }

        public void llenarTexbox()
        {
            this.txtID.Text = dgClientes.CurrentRow.Cells[0].Value.ToString();
            this.txtEmpresa.Text = dgClientes.CurrentRow.Cells[1].Value.ToString();
            this.txtContacto.Text = dgClientes.CurrentRow.Cells[2].Value.ToString();
            this.txtTelefono.Text = dgClientes.CurrentRow.Cells[3].Value.ToString();
            this.txtCorreo.Text = dgClientes.CurrentRow.Cells[4].Value.ToString();
        }

    }
}
