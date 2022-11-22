
namespace MAD.FormsAdmin
{
    partial class FormDevolucion
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
            this.txtNumRecibo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.txtNombreProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbMerma = new System.Windows.Forms.CheckBox();
            this.numMerma = new System.Windows.Forms.NumericUpDown();
            this.dgvProdRecibo = new System.Windows.Forms.DataGridView();
            this.dgvProdNota = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.txtPrecioProd = new System.Windows.Forms.TextBox();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMerma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdRecibo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdNota)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumRecibo
            // 
            this.txtNumRecibo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNumRecibo.Location = new System.Drawing.Point(699, 106);
            this.txtNumRecibo.Name = "txtNumRecibo";
            this.txtNumRecibo.ShortcutsEnabled = false;
            this.txtNumRecibo.Size = new System.Drawing.Size(284, 29);
            this.txtNumRecibo.TabIndex = 46;
            this.txtNumRecibo.TextChanged += new System.EventHandler(this.txtNumRecibo_TextChanged);
            this.txtNumRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumRecibo_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(757, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(181, 30);
            this.label22.TabIndex = 45;
            this.label22.Text = "Número de recibo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMotivo.Location = new System.Drawing.Point(481, 314);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(383, 168);
            this.txtMotivo.TabIndex = 48;
            this.txtMotivo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(633, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "Motivo";
            // 
            // btnDevolver
            // 
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDevolver.Location = new System.Drawing.Point(598, 559);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(144, 52);
            this.btnDevolver.TabIndex = 49;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTerminar.Location = new System.Drawing.Point(904, 559);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(144, 52);
            this.btnTerminar.TabIndex = 50;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // txtNombreProd
            // 
            this.txtNombreProd.Enabled = false;
            this.txtNombreProd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreProd.Location = new System.Drawing.Point(528, 228);
            this.txtNombreProd.Name = "txtNombreProd";
            this.txtNombreProd.Size = new System.Drawing.Size(284, 29);
            this.txtNombreProd.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(575, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 30);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nombre del producto";
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numCantidad.Location = new System.Drawing.Point(980, 228);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(142, 29);
            this.numCantidad.TabIndex = 54;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(1001, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 30);
            this.label11.TabIndex = 53;
            this.label11.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(968, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 30);
            this.label3.TabIndex = 55;
            this.label3.Text = "Cantidad merma";
            // 
            // ckbMerma
            // 
            this.ckbMerma.AutoSize = true;
            this.ckbMerma.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckbMerma.Location = new System.Drawing.Point(1001, 359);
            this.ckbMerma.Name = "ckbMerma";
            this.ckbMerma.Size = new System.Drawing.Size(98, 34);
            this.ckbMerma.TabIndex = 57;
            this.ckbMerma.Text = "Merma";
            this.ckbMerma.UseVisualStyleBackColor = true;
            this.ckbMerma.CheckedChanged += new System.EventHandler(this.ckbMerma_CheckedChanged);
            // 
            // numMerma
            // 
            this.numMerma.Enabled = false;
            this.numMerma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMerma.Location = new System.Drawing.Point(980, 453);
            this.numMerma.Name = "numMerma";
            this.numMerma.Size = new System.Drawing.Size(142, 29);
            this.numMerma.TabIndex = 56;
            this.numMerma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvProdRecibo
            // 
            this.dgvProdRecibo.AllowUserToAddRows = false;
            this.dgvProdRecibo.AllowUserToDeleteRows = false;
            this.dgvProdRecibo.AllowUserToResizeColumns = false;
            this.dgvProdRecibo.AllowUserToResizeRows = false;
            this.dgvProdRecibo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdRecibo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdRecibo.Location = new System.Drawing.Point(45, 107);
            this.dgvProdRecibo.Name = "dgvProdRecibo";
            this.dgvProdRecibo.ReadOnly = true;
            this.dgvProdRecibo.RowHeadersVisible = false;
            this.dgvProdRecibo.RowTemplate.Height = 25;
            this.dgvProdRecibo.Size = new System.Drawing.Size(393, 150);
            this.dgvProdRecibo.TabIndex = 58;
            this.dgvProdRecibo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdRecibo_CellClick);
            // 
            // dgvProdNota
            // 
            this.dgvProdNota.AllowUserToAddRows = false;
            this.dgvProdNota.AllowUserToDeleteRows = false;
            this.dgvProdNota.AllowUserToResizeColumns = false;
            this.dgvProdNota.AllowUserToResizeRows = false;
            this.dgvProdNota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdNota.Location = new System.Drawing.Point(45, 332);
            this.dgvProdNota.Name = "dgvProdNota";
            this.dgvProdNota.ReadOnly = true;
            this.dgvProdNota.RowHeadersVisible = false;
            this.dgvProdNota.RowTemplate.Height = 25;
            this.dgvProdNota.Size = new System.Drawing.Size(393, 150);
            this.dgvProdNota.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(136, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 30);
            this.label4.TabIndex = 60;
            this.label4.Text = "Productos del recibo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(158, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 30);
            this.label5.TabIndex = 61;
            this.label5.Text = "Productos Nota";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Enabled = false;
            this.txtCodProd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodProd.Location = new System.Drawing.Point(12, 12);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(38, 29);
            this.txtCodProd.TabIndex = 62;
            this.txtCodProd.Visible = false;
            this.txtCodProd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPrecioProd
            // 
            this.txtPrecioProd.Enabled = false;
            this.txtPrecioProd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrecioProd.Location = new System.Drawing.Point(56, 12);
            this.txtPrecioProd.Name = "txtPrecioProd";
            this.txtPrecioProd.Size = new System.Drawing.Size(117, 29);
            this.txtPrecioProd.TabIndex = 63;
            this.txtPrecioProd.Visible = false;
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(179, 12);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(100, 23);
            this.tbxNombre.TabIndex = 64;
            this.tbxNombre.Visible = false;
            // 
            // FormDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 635);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.txtPrecioProd);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvProdNota);
            this.Controls.Add(this.dgvProdRecibo);
            this.Controls.Add(this.ckbMerma);
            this.Controls.Add(this.numMerma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNombreProd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumRecibo);
            this.Controls.Add(this.label22);
            this.Name = "FormDevolucion";
            this.Text = "FormDevolucion";
            this.Load += new System.EventHandler(this.FormDevolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMerma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdRecibo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdNota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumRecibo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RichTextBox txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.TextBox txtNombreProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbMerma;
        private System.Windows.Forms.NumericUpDown numMerma;
        private System.Windows.Forms.DataGridView dgvProdRecibo;
        private System.Windows.Forms.DataGridView dgvProdNota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.TextBox txtPrecioProd;
        private System.Windows.Forms.TextBox tbxNombre;
    }
}