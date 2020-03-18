using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoIDAII
{
    public partial class CuentasPorCobrar : Form
    {
        public CuentasPorCobrar()
        {
            InitializeComponent();
        }

        private void CuentasPorCobrar_Load(object sender, EventArgs e)
        {

        }

        private void txtSIVA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double cantidadSIVA, cantidadCIVA;

                cantidadSIVA = double.Parse(this.txtSIVA.Text);
                cantidadCIVA = cantidadSIVA * 1.16;
                this.txtCIVA.Text = cantidadCIVA.ToString();
            }
            catch (Exception)
            {

                this.txtCIVA.Text = "";
            }
            
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Activar()
        {
            
            txtContacto.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            dgCobrar.Enabled = false;
            btnAgregar.Enabled = false;
        }
        public void Desactivar()
        {
            
            txtContacto.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            dgCobrar.Enabled = true;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public void Activar_()
        {
            
            txtContacto.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            dgCobrar.Enabled = true;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        public void Limpiar()
        {
          
            txtContacto.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dgCobrar.ClearSelection();
        }

        private void cbEmpresa_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("data source=LAPTOP-QOMJAHVK;initial catalog=GrupoIDAII; user id=sa;password=123456789; MultipleActiveResultSets=true");
            SqlCommand cm = new SqlCommand("select nomEmpresa from dbo.ClientesIDAII", cn);
            cn.Open();
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read() == true)
            {
                cbEmpresa.Items.Add(dr["nomEmpresa"]);
            }
        }

        private void cbEmpresa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection("data source=LAPTOP-QOMJAHVK;initial catalog=GrupoIDAII; user id=sa;password=123456789; MultipleActiveResultSets=true");
                SqlCommand cm = new SqlCommand("select * from dbo.ClientesIDAII", cn);
                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if(dr.Read())
                {
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
