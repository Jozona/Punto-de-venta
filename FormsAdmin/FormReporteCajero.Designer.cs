
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
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.FechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesVendidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label24 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaVenta,
            this.NombreCajero,
            this.Departamento,
            this.UnidadesVendidas,
            this.SumaVenta,
            this.SumaUtilidad});
            this.dataGridView3.Location = new System.Drawing.Point(129, 171);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(644, 499);
            this.dataGridView3.TabIndex = 55;
            // 
            // FechaVenta
            // 
            this.FechaVenta.HeaderText = "FechaVenta";
            this.FechaVenta.Name = "FechaVenta";
            this.FechaVenta.ReadOnly = true;
            // 
            // NombreCajero
            // 
            this.NombreCajero.HeaderText = "NombreCajero";
            this.NombreCajero.Name = "NombreCajero";
            this.NombreCajero.ReadOnly = true;
            // 
            // Departamento
            // 
            this.Departamento.HeaderText = "Departamento";
            this.Departamento.Name = "Departamento";
            this.Departamento.ReadOnly = true;
            // 
            // UnidadesVendidas
            // 
            this.UnidadesVendidas.HeaderText = "UnidadesVendidas";
            this.UnidadesVendidas.Name = "UnidadesVendidas";
            this.UnidadesVendidas.ReadOnly = true;
            // 
            // SumaVenta
            // 
            this.SumaVenta.HeaderText = "SumaVenta";
            this.SumaVenta.Name = "SumaVenta";
            this.SumaVenta.ReadOnly = true;
            // 
            // SumaUtilidad
            // 
            this.SumaUtilidad.HeaderText = "SumaUtilidad";
            this.SumaUtilidad.Name = "SumaUtilidad";
            this.SumaUtilidad.ReadOnly = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(282, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 30);
            this.label24.TabIndex = 59;
            this.label24.Text = "Fecha final";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Location = new System.Drawing.Point(244, 66);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 58;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(48, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 30);
            this.label23.TabIndex = 57;
            this.label23.Text = "Fecha inicial";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 56;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(480, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 29);
            this.comboBox1.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(552, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 30);
            this.label1.TabIndex = 60;
            this.label1.Text = "Cajero";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(738, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(220, 29);
            this.comboBox2.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(769, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 62;
            this.label2.Text = "Departamento";
            // 
            // FormReporteCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 682);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView3);
            this.Name = "FormReporteCajero";
            this.Text = "FormReporteCajero";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesVendidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumaUtilidad;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}