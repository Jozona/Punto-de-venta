
namespace MAD.FormsAdmin
{
    partial class FormReporteCajero
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
            this.label24 = new System.Windows.Forms.Label();
            this.dtpFechaF = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpFechaI = new System.Windows.Forms.DateTimePicker();
            this.cmbCajero = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvReporteCajero = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCajero)).BeginInit();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(356, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 30);
            this.label24.TabIndex = 59;
            this.label24.Text = "Fecha final";
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaF.Location = new System.Drawing.Point(318, 66);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaF.TabIndex = 58;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(122, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 30);
            this.label23.TabIndex = 57;
            this.label23.Text = "Fecha inicial";
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaI.Location = new System.Drawing.Point(86, 66);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaI.TabIndex = 56;
            // 
            // cmbCajero
            // 
            this.cmbCajero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCajero.FormattingEnabled = true;
            this.cmbCajero.Location = new System.Drawing.Point(554, 66);
            this.cmbCajero.Name = "cmbCajero";
            this.cmbCajero.Size = new System.Drawing.Size(220, 29);
            this.cmbCajero.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(626, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 30);
            this.label1.TabIndex = 60;
            this.label1.Text = "Cajero";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(812, 66);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(220, 29);
            this.cmbDepartamento.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(843, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 62;
            this.label2.Text = "Departamento";
            // 
            // dgvReporteCajero
            // 
            this.dgvReporteCajero.AllowUserToAddRows = false;
            this.dgvReporteCajero.AllowUserToDeleteRows = false;
            this.dgvReporteCajero.AllowUserToResizeColumns = false;
            this.dgvReporteCajero.AllowUserToResizeRows = false;
            this.dgvReporteCajero.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporteCajero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteCajero.Location = new System.Drawing.Point(86, 250);
            this.dgvReporteCajero.Name = "dgvReporteCajero";
            this.dgvReporteCajero.ReadOnly = true;
            this.dgvReporteCajero.RowHeadersVisible = false;
            this.dgvReporteCajero.RowTemplate.Height = 25;
            this.dgvReporteCajero.Size = new System.Drawing.Size(946, 332);
            this.dgvReporteCajero.TabIndex = 65;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.Location = new System.Drawing.Point(483, 153);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(144, 52);
            this.btnFiltrar.TabIndex = 64;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FormReporteCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 635);
            this.Controls.Add(this.dgvReporteCajero);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCajero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.dtpFechaI);
            this.Name = "FormReporteCajero";
            this.Text = "FormReporteCajero";
            this.Load += new System.EventHandler(this.FormReporteCajero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCajero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private System.Windows.Forms.ComboBox cmbCajero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvReporteCajero;
        private System.Windows.Forms.Button btnFiltrar;
    }
}