using GrupoIDAII.BD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoIDAII.Administración_IDAII
{
    public partial class Materiales : Form
    {
        public Materiales()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Activar(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtProveedor.Text.Length == 0 | cbMes.Text.Length == 0 | txtSubtotal.Text.Length == 0 | txtFactura.Text.Length == 0 | dpFactura.Text.Length == 0 | dtLimite.Text.Length == 0 | cbEstatus.Text.Length == 0 | txtBanco.Text.Length == 0 | txtCredito.Text.Length == 0)
            {
                MessageBox.Show("Existen campos vacíos");
            }
            else
            {
                cargarMateriales();
                string proveedor = txtProveedor.Text;
                string mes = cbMes.Text;
                double subtotal = double.Parse(txtSubtotal.Text);
                double iva =  double.Parse(txtIVA.Text);
                double monto = double.Parse(txtMonto.Text);
                string factura = txtFactura.Text;
                DateTime fecha = DateTime.Parse(dpFactura.Text);
                int dias = int.Parse(txtCredito.Text);
                DateTime limite = DateTime.Parse(dtLimite.Text);
                string banco = txtBanco.Text;
                string estatus = cbEstatus.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    MaterialesIDAII materialesIDAII = new MaterialesIDAII
                    {
                        proveedor = proveedor,
                        mes = mes,
                        subtotal = subtotal,
                        iva = iva,
                        monto = monto,
                        factura = factura,
                        fecha_fac = fecha,
                        dias_credito = dias,
                        fecha_lim = limite,
                        banco = banco,
                        estatus = estatus,
                    };
                    Desactivar();
                    contexto.MaterialesIDAII.Add(materialesIDAII);
                    contexto.SaveChanges();
                    cargarMateriales();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgMateriales.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt16(this.txtID.Text);
                string proveedor = txtProveedor.Text;
                string mes = cbMes.Text;
                double subtotal = double.Parse(txtSubtotal.Text);
                double iva = double.Parse(txtIVA.Text);
                double monto = double.Parse(txtMonto.Text);
                string factura = txtFactura.Text;
                DateTime fecha = DateTime.Parse(dpFactura.Text);
                int dias = int.Parse(txtCredito.Text);
                DateTime limite = DateTime.Parse(dtLimite.Text);
                string banco = txtBanco.Text;
                string estatus = cbEstatus.Text;

                using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                {
                    MaterialesIDAII materialesIDAII = contexto.MaterialesIDAII.FirstOrDefault(x => x.id == id);
                    materialesIDAII.proveedor = proveedor;
                    materialesIDAII.mes = mes;
                    materialesIDAII.subtotal = subtotal;
                    materialesIDAII.iva = iva;
                    materialesIDAII.monto = monto;
                    materialesIDAII.factura = factura;
                    materialesIDAII.fecha_fac = fecha;
                    materialesIDAII.dias_credito = dias;
                    materialesIDAII.fecha_lim = limite;
                    materialesIDAII.banco = banco;
                    materialesIDAII.estatus = estatus;
                    contexto.SaveChanges();
                    cargarMateriales();
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
                if (dgMateriales.SelectedCells.Count == 1)
                {

                    int id = Convert.ToInt16(this.txtID.Text);
                    using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                    {
                        MaterialesIDAII materialesIDAII = contexto.MaterialesIDAII.FirstOrDefault(x => x.id == id);
                        contexto.MaterialesIDAII.Remove(materialesIDAII);
                        contexto.SaveChanges();
                        cargarMateriales();
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

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double cantidadSIVA, cantidadCIVA, monto;

                cantidadSIVA = double.Parse(this.txtSubtotal.Text);
                cantidadCIVA = cantidadSIVA * 0.16;
                monto = cantidadSIVA + cantidadCIVA;
                this.txtIVA.Text = cantidadCIVA.ToString();
                this.txtMonto.Text = monto.ToString();
            }
            catch (Exception)
            {

                this.txtIVA.Text = "";
                this.txtMonto.Text = "";
            }
        }
        public void Activar()
        {
            txtProveedor.Enabled = true;
            cbMes.Enabled = true;
            txtSubtotal.Enabled = true;
            txtFactura.Enabled = true;
            dpFactura.Enabled = true;
            txtCredito.Enabled = true;
            dtLimite.Enabled = true;
            txtBanco.Enabled = true;
            cbEstatus.Enabled = true;
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            dgMateriales.Enabled = true;
        }
        public void Desactivar()
        {
            txtProveedor.Enabled = false;
            cbMes.Enabled = false;
            txtSubtotal.Enabled = false;
            txtFactura.Enabled = false;
            dpFactura.Enabled = false;
            txtCredito.Enabled = false;
            dtLimite.Enabled = false;
            txtBanco.Enabled = false;
            cbEstatus.Enabled = false;
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled = false;
            dgMateriales.Enabled = true;
        }
        public void Limpiar()
        {
            txtProveedor.Clear();
            txtSubtotal.Clear();
            txtFactura.Clear();
            txtCredito.Clear();
            txtBanco.Clear();
        }
        public void cargarMateriales()
        {
            GrupoIDAIIEntities1 grupoContext = new GrupoIDAIIEntities1();
            dgMateriales.DataSource = grupoContext.MaterialesIDAII.ToList();
            dgMateriales.Columns[0].HeaderText = "No.";
            dgMateriales.Columns[1].HeaderText = "Proveedor";
            dgMateriales.Columns[2].HeaderText = "Mes";
            dgMateriales.Columns[3].HeaderText = "Subtotal";
            dgMateriales.Columns[4].HeaderText = "IVA";
            dgMateriales.Columns[5].HeaderText = "Monto";
            dgMateriales.Columns[6].HeaderText = "Factura";
            dgMateriales.Columns[7].HeaderText = "Fecha de Factura";
            dgMateriales.Columns[8].HeaderText = "Días de crédito";
            dgMateriales.Columns[9].HeaderText = "Fecha Límite";
            dgMateriales.Columns[10].HeaderText = "Banco";
            dgMateriales.Columns[11].HeaderText = "Estatus";
        }

        private void Materiales_Load(object sender, EventArgs e)
        {
            cargarMateriales();
        }
        public void llenarTexbox()
        {
            this.txtID.Text = dgMateriales.CurrentRow.Cells[0].Value.ToString();
            this.txtProveedor.Text = dgMateriales.CurrentRow.Cells[1].Value.ToString();
            this.cbMes.Text = dgMateriales.CurrentRow.Cells[2].Value.ToString();
            this.txtSubtotal.Text = dgMateriales.CurrentRow.Cells[3].Value.ToString();
            this.txtIVA.Text = dgMateriales.CurrentRow.Cells[4].Value.ToString();
            this.txtMonto.Text = dgMateriales.CurrentRow.Cells[5].Value.ToString();
            this.txtFactura.Text = dgMateriales.CurrentRow.Cells[6].Value.ToString();
            this.dpFactura.Text = dgMateriales.CurrentRow.Cells[7].Value.ToString();
            this.txtCredito.Text = dgMateriales.CurrentRow.Cells[8].Value.ToString();
            this.dtLimite.Text = dgMateriales.CurrentRow.Cells[9].Value.ToString();
            this.txtBanco.Text = dgMateriales.CurrentRow.Cells[10].Value.ToString();
            this.cbEstatus.Text = dgMateriales.CurrentRow.Cells[11].Value.ToString();
        }

        private void dgMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarTexbox();
            Activar_();
        }
        public void Activar_()
        {
            txtProveedor.Enabled = true;
            cbMes.Enabled = true;
            txtSubtotal.Enabled = true;
            txtFactura.Enabled = true;
            dpFactura.Enabled = true;
            txtCredito.Enabled = true;
            dtLimite.Enabled = true;
            txtBanco.Enabled = true;
            cbEstatus.Enabled = true;
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            dgMateriales.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
