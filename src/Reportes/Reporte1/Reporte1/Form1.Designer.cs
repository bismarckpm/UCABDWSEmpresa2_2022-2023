namespace Reporte1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportesRequeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gestionBDDataSet1 = new Reporte1.GestionBDDataSet1();
            this.reportesRequeTableAdapter = new Reporte1.GestionBDDataSet1TableAdapters.ReportesRequeTableAdapter();
            this.gestionBDDataSet = new Reporte1.GestionBDDataSet();
            this.gestionBDDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uCABServicesDesk8DataSet = new Reporte1.UCABServicesDesk8DataSet();
            this.uCABServicesDesk8DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportesReque2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportesReque2TableAdapter = new Reporte1.UCABServicesDesk8DataSetTableAdapters.ReportesReque2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesRequeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCABServicesDesk8DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCABServicesDesk8DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesReque2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportesRequeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reporte1.Reporte1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 140);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1665, 519);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Haettenschweiler", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(330, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(840, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "LISTA DE TICKETS ASIGNADOS A UN DEPARTAMENTO EN ESPECIFICO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // reportesRequeBindingSource
            // 
            this.reportesRequeBindingSource.DataMember = "ReportesReque";
            this.reportesRequeBindingSource.DataSource = this.gestionBDDataSet1;
            // 
            // gestionBDDataSet1
            // 
            this.gestionBDDataSet1.DataSetName = "GestionBDDataSet1";
            this.gestionBDDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportesRequeTableAdapter
            // 
            this.reportesRequeTableAdapter.ClearBeforeFill = true;
            // 
            // gestionBDDataSet
            // 
            this.gestionBDDataSet.DataSetName = "GestionBDDataSet";
            this.gestionBDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gestionBDDataSetBindingSource
            // 
            this.gestionBDDataSetBindingSource.DataSource = this.gestionBDDataSet;
            this.gestionBDDataSetBindingSource.Position = 0;
            // 
            // uCABServicesDesk8DataSet
            // 
            this.uCABServicesDesk8DataSet.DataSetName = "UCABServicesDesk8DataSet";
            this.uCABServicesDesk8DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uCABServicesDesk8DataSetBindingSource
            // 
            this.uCABServicesDesk8DataSetBindingSource.DataSource = this.uCABServicesDesk8DataSet;
            this.uCABServicesDesk8DataSetBindingSource.Position = 0;
            // 
            // reportesReque2BindingSource
            // 
            this.reportesReque2BindingSource.DataMember = "ReportesReque2";
            this.reportesReque2BindingSource.DataSource = this.uCABServicesDesk8DataSetBindingSource;
            // 
            // reportesReque2TableAdapter
            // 
            this.reportesReque2TableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 660);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesRequeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionBDDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCABServicesDesk8DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uCABServicesDesk8DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesReque2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reportesRequeBindingSource;
        private GestionBDDataSet1 gestionBDDataSet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private GestionBDDataSet1TableAdapters.ReportesRequeTableAdapter reportesRequeTableAdapter;
        private GestionBDDataSet gestionBDDataSet;
        private System.Windows.Forms.BindingSource gestionBDDataSetBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource reportesReque2BindingSource;
        private System.Windows.Forms.BindingSource uCABServicesDesk8DataSetBindingSource;
        private UCABServicesDesk8DataSet uCABServicesDesk8DataSet;
        private UCABServicesDesk8DataSetTableAdapters.ReportesReque2TableAdapter reportesReque2TableAdapter;
    }
}

