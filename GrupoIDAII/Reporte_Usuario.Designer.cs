﻿namespace GrupoIDAII
{
    partial class Reporte_Usuario
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
            this.UsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetUsuarios = new GrupoIDAII.DataSetUsuarios();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.UsuariosTableAdapter = new GrupoIDAII.DataSetUsuariosTableAdapters.UsuariosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuariosBindingSource
            // 
            this.UsuariosBindingSource.DataMember = "Usuarios";
            this.UsuariosBindingSource.DataSource = this.DataSetUsuarios;
            // 
            // DataSetUsuarios
            // 
            this.DataSetUsuarios.DataSetName = "DataSetUsuarios";
            this.DataSetUsuarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.UsuariosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GrupoIDAII.ReporteUsuario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // UsuariosTableAdapter
            // 
            this.UsuariosTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte_Usuario";
            this.Text = "Reporte_Usuario";
            this.Load += new System.EventHandler(this.Reporte_Usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource UsuariosBindingSource;
        private DataSetUsuarios DataSetUsuarios;
        private DataSetUsuariosTableAdapters.UsuariosTableAdapter UsuariosTableAdapter;
    }
}