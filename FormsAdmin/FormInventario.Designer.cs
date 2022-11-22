
namespace MAD.FormsAdmin
{
    partial class FormInventario
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
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.cmbDepartamentoInventario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numExistencia = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.ckbAgotados = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbMerma = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeColumns = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(66, 171);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.RowTemplate.Height = 25;
            this.dgvInventario.Size = new System.Drawing.Size(875, 499);
            this.dgvInventario.TabIndex = 54;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // cmbDepartamentoInventario
            // 
            this.cmbDepartamentoInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDepartamentoInventario.FormattingEnabled = true;
            this.cmbDepartamentoInventario.Location = new System.Drawing.Point(26, 69);
            this.cmbDepartamentoInventario.Name = "cmbDepartamentoInventario";
            this.cmbDepartamentoInventario.Size = new System.Drawing.Size(220, 29);
            this.cmbDepartamentoInventario.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(57, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 60;
            this.label2.Text = "Departamento";
            // 
            // numExistencia
            // 
            this.numExistencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numExistencia.Location = new System.Drawing.Point(316, 69);
            this.numExistencia.Name = "numExistencia";
            this.numExistencia.Size = new System.Drawing.Size(142, 29);
            this.numExistencia.TabIndex = 63;
            this.numExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(302, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 30);
            this.label15.TabIndex = 62;
            this.label15.Text = "Existencia mínima";
            // 
            // ckbAgotados
            // 
            this.ckbAgotados.AutoSize = true;
            this.ckbAgotados.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckbAgotados.Location = new System.Drawing.Point(607, 64);
            this.ckbAgotados.Name = "ckbAgotados";
            this.ckbAgotados.Size = new System.Drawing.Size(48, 34);
            this.ckbAgotados.TabIndex = 65;
            this.ckbAgotados.Text = "Sí";
            this.ckbAgotados.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(540, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 30);
            this.label4.TabIndex = 64;
            this.label4.Text = "Productos agotados";
            // 
            // ckbMerma
            // 
            this.ckbMerma.AutoSize = true;
            this.ckbMerma.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckbMerma.Location = new System.Drawing.Point(820, 64);
            this.ckbMerma.Name = "ckbMerma";
            this.ckbMerma.Size = new System.Drawing.Size(48, 34);
            this.ckbMerma.TabIndex = 67;
            this.ckbMerma.Text = "Sí";
            this.ckbMerma.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(803, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 66;
            this.label1.Text = "Merma";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.Location = new System.Drawing.Point(948, 36);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(130, 66);
            this.btnFiltrar.TabIndex = 68;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 682);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.ckbMerma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbAgotados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numExistencia);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbDepartamentoInventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvInventario);
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            this.Load += new System.EventHandler(this.FormInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExistencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.ComboBox cmbDepartamentoInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numExistencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ckbAgotados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbMerma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrar;
    }
}