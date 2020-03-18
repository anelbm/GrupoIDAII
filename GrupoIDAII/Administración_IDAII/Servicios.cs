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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
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
            if (txtProveedor.Text.Length == 0 | cbMes.Text.Length == 0 | txtSubtotal.Text.Length == 0 | txtFactura.Text.Length == 0 | dpFactura.Text.Length == 0 | dtLimite.Text.Length == 0 | cbEstatus.Text.Length == 0 | txtBanco.Text.Length == 0 | txtCredito.Text.Length == 0)
            {
                MessageBox.Show("Existen campos vacíos");
            }
            else
            {
                cargarServicios();
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
                    ServiciosIDAII serviciosIDAII = new ServiciosIDAII
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
                    contexto.ServiciosIDAII.Add(serviciosIDAII);
                    contexto.SaveChanges();
                    cargarServicios();
                    Limpiar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgServicios.SelectedCells.Count > 0)
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
                    ServiciosIDAII materialesIDAII = contexto.ServiciosIDAII.FirstOrDefault(x => x.id == id);
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
                    cargarServicios();
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
                if (dgServicios.SelectedCells.Count == 1)
                {

                    int id = Convert.ToInt16(this.txtID.Text);
                    using (GrupoIDAIIEntities1 contexto = new GrupoIDAIIEntities1())
                    {
                        ServiciosIDAII servicios = contexto.ServiciosIDAII.FirstOrDefault(x => x.id == id);
                        contexto.ServiciosIDAII.Remove(servicios);
                        contexto.SaveChanges();
                        cargarServicios();
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

        private void dgServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarTexbox();
            Activar_();
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
            dgServicios.Enabled = true;
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
            dgServicios.Enabled = true;
        }
        public void Limpiar()
        {
            txtProveedor.Clear();
            txtSubtotal.Clear();
            txtFactura.Clear();
            txtCredito.Clear();
            txtBanco.Clear();
        }
        public void cargarServicios()
        {
            GrupoIDAIIEntities1 grupoContext = new GrupoIDAIIEntities1();
            dgServicios.DataSource = grupoContext.ServiciosIDAII.ToList();
            dgServicios.Columns[0].HeaderText = "No.";
            dgServicios.Columns[1].HeaderText = "Proveedor";
            dgServicios.Columns[2].HeaderText = "Mes";
            dgServicios.Columns[3].HeaderText = "Subtotal";
            dgServicios.Columns[4].HeaderText = "IVA";
            dgServicios.Columns[5].HeaderText = "Monto";
            dgServicios.Columns[6].HeaderText = "Factura";
            dgServicios.Columns[7].HeaderText = "Fecha de Factura";
            dgServicios.Columns[8].HeaderText = "Días de crédito";
            dgServicios.Columns[9].HeaderText = "Fecha Límite";
            dgServicios.Columns[10].HeaderText = "Banco";
            dgServicios.Columns[11].HeaderText = "Estatus";
        }
        public void llenarTexbox()
        {
            this.txtID.Text = dgServicios.CurrentRow.Cells[0].Value.ToString();
            this.txtProveedor.Text = dgServicios.CurrentRow.Cells[1].Value.ToString();
            this.cbMes.Text = dgServicios.CurrentRow.Cells[2].Value.ToString();
            this.txtSubtotal.Text = dgServicios.CurrentRow.Cells[3].Value.ToString();
            this.txtIVA.Text = dgServicios.CurrentRow.Cells[4].Value.ToString();
            this.txtMonto.Text = dgServicios.CurrentRow.Cells[5].Value.ToString();
            this.txtFactura.Text = dgServicios.CurrentRow.Cells[6].Value.ToString();
            this.dpFactura.Text = dgServicios.CurrentRow.Cells[7].Value.ToString();
            this.txtCredito.Text = dgServicios.CurrentRow.Cells[8].Value.ToString();
            this.dtLimite.Text = dgServicios.CurrentRow.Cells[9].Value.ToString();
            this.txtBanco.Text = dgServicios.CurrentRow.Cells[10].Value.ToString();
            this.cbEstatus.Text = dgServicios.CurrentRow.Cells[11].Value.ToString();
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
            dgServicios.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            cargarServicios();
        }
    }
}
