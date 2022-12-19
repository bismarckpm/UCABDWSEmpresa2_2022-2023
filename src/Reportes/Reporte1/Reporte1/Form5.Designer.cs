namespace Reporte1
{
    partial class Form5
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
            this.gestionBDDataSet7 = new Reporte1.GestionBDDataSet7();
            this.reportesReque5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportesReque5TableAdapter = new Reporte1.GestionBDDataSet7TableAdapters.ReportesReque5TableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesReque5BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportesReque5BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reporte1.Reporte4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-3, 97);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1501, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // gestionBDDataSet7
            // 
            this.gestionBDDataSet7.DataSetName = "GestionBDDataSet7";
            this.gestionBDDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportesReque5BindingSource
            // 
            this.reportesReque5BindingSource.DataMember = "ReportesReque5";
            this.reportesReque5BindingSource.DataSource = this.gestionBDDataSet7;
            // 
            // reportesReque5TableAdapter
            // 
            this.reportesReque5TableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Haettenschweiler", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(139, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(839, 44);
            this.label3.TabIndex = 8;
            this.label3.Text = "LISTA DE TICKETS RECHAZADOS EN ALGUN MODELO DE APROBACION";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 567);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesReque5BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GestionBDDataSet7 gestionBDDataSet7;
        private System.Windows.Forms.BindingSource reportesReque5BindingSource;
        private GestionBDDataSet7TableAdapters.ReportesReque5TableAdapter reportesReque5TableAdapter;
        private System.Windows.Forms.Label label3;
    }
}