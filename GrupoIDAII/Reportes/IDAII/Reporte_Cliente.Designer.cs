namespace GrupoIDAII.Reportes.IDAII
{
    partial class Reporte_Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetClientes = new GrupoIDAII.Reportes.IDAII.DataSetClientes();
            this.ClientesIDAIIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientesIDAIITableAdapter = new GrupoIDAII.Reportes.IDAII.DataSetClientesTableAdapters.ClientesIDAIITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesIDAIIBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ClientesIDAIIBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GrupoIDAII.Reportes.IDAII.ReportClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetClientes
            // 
            this.DataSetClientes.DataSetName = "DataSetClientes";
            this.DataSetClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ClientesIDAIIBindingSource
            // 
            this.ClientesIDAIIBindingSource.DataMember = "ClientesIDAII";
            this.ClientesIDAIIBindingSource.DataSource = this.DataSetClientes;
            // 
            // ClientesIDAIITableAdapter
            // 
            this.ClientesIDAIITableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte_Cliente";
            this.Load += new System.EventHandler(this.Reporte_Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesIDAIIBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClientesIDAIIBindingSource;
        private DataSetClientes DataSetClientes;
        private DataSetClientesTableAdapters.ClientesIDAIITableAdapter ClientesIDAIITableAdapter;
    }
}