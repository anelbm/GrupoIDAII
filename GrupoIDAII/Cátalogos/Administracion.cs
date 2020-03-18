using GrupoIDAII.Administración_IDAII;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoIDAII
{
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            CuentasPorCobrar frm = new CuentasPorCobrar();
            frm.ShowDialog();
        }

        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            Contreseñas frm = new Contreseñas();
            frm.ShowDialog();
        }

        private void btnCobrarE_Click(object sender, EventArgs e)
        {

        }

        private void btnClientesE_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            frm.ShowDialog();
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            Materiales frm = new Materiales();
            frm.ShowDialog();
        }

        private void btnViaticos_Click(object sender, EventArgs e)
        {
            Viaticos frm = new Viaticos();
            frm.ShowDialog();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            Servicios frm = new Servicios();
            frm.ShowDialog();
        }
    }
}
