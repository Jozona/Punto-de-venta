
namespace MAD.FormsAdmin
{
    partial class FormConsultaRecibos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRecibos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFYC = new System.Windows.Forms.Button();
            this.cbxCaja = new System.Windows.Forms.ComboBox();
            this.cbxRecibo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRecibo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvNotas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNotaFecha = new System.Windows.Forms.Button();
            this.dtpNota = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxReciboNota = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReciboNota = new System.Windows.Forms.Button();
            this.btnFYCnota = new System.Windows.Forms.Button();
            this.cbxCajaNota = new System.Windows.Forms.ComboBox();
            this.cbxNota = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNotaFechaCaja = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNota = new System.Windows.Forms.Button();
            this.dgvProductosDevueltos = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxImprimirNota = new System.Windows.Forms.TextBox();
            this.tbxImprimirRecibo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDevueltos)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1114, 622);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dgvRecibos);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dgvProductos);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1106, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recibos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(438, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Productos comprados";
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecibos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRecibos.Location = new System.Drawing.Point(3, 213);
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.RowTemplate.Height = 25;
            this.dgvRecibos.Size = new System.Drawing.Size(1100, 150);
            this.dgvRecibos.TabIndex = 2;
            this.dgvRecibos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecibos_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFYC);
            this.panel1.Controls.Add(this.cbxCaja);
            this.panel1.Controls.Add(this.cbxRecibo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpRecibo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 210);
            this.panel1.TabIndex = 1;
            // 
            // btnFYC
            // 
            this.btnFYC.BackColor = System.Drawing.Color.Maroon;
            this.btnFYC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFYC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFYC.Location = new System.Drawing.Point(793, 117);
            this.btnFYC.Name = "btnFYC";
            this.btnFYC.Size = new System.Drawing.Size(98, 37);
            this.btnFYC.TabIndex = 11;
            this.btnFYC.Text = "Buscar";
            this.btnFYC.UseVisualStyleBackColor = false;
            this.btnFYC.Click += new System.EventHandler(this.btnFYC_Click);
            // 
            // cbxCaja
            // 
            this.cbxCaja.FormattingEnabled = true;
            this.cbxCaja.Location = new System.Drawing.Point(897, 65);
            this.cbxCaja.Name = "cbxCaja";
            this.cbxCaja.Size = new System.Drawing.Size(121, 23);
            this.cbxCaja.TabIndex = 10;
            this.cbxCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxCaja_KeyPress);
            // 
            // cbxRecibo
            // 
            this.cbxRecibo.FormattingEnabled = true;
            this.cbxRecibo.Location = new System.Drawing.Point(257, 65);
            this.cbxRecibo.Name = "cbxRecibo";
            this.cbxRecibo.Size = new System.Drawing.Size(121, 23);
            this.cbxRecibo.TabIndex = 9;
            this.cbxRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxRecibo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(483, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Recibo/s";
            // 
            // dtpRecibo
            // 
            this.dtpRecibo.CustomFormat = "dd/MM/YYYY";
            this.dtpRecibo.Location = new System.Drawing.Point(625, 65);
            this.dtpRecibo.Name = "dtpRecibo";
            this.dtpRecibo.Size = new System.Drawing.Size(168, 23);
            this.dtpRecibo.TabIndex = 6;
            this.dtpRecibo.Value = new System.DateTime(2022, 11, 21, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(751, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Busqueda con fecha y caja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(188, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Busqueda con numero de recibo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(507, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "O";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(269, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductos.Location = new System.Drawing.Point(3, 410);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowTemplate.Height = 25;
            this.dgvProductos.Size = new System.Drawing.Size(1100, 181);
            this.dgvProductos.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1106, 594);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notas de credito";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(-4, -32);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1114, 640);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dgvNotas);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.dgvProductosDevueltos);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1106, 612);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Recibos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(475, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Productos devueltos";
            // 
            // dgvNotas
            // 
            this.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNotas.Location = new System.Drawing.Point(3, 213);
            this.dgvNotas.Name = "dgvNotas";
            this.dgvNotas.RowTemplate.Height = 25;
            this.dgvNotas.Size = new System.Drawing.Size(1100, 150);
            this.dgvNotas.TabIndex = 2;
            this.dgvNotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotas_CellClick);
            this.dgvNotas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotas_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNotaFecha);
            this.panel2.Controls.Add(this.dtpNota);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cbxReciboNota);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnReciboNota);
            this.panel2.Controls.Add(this.btnFYCnota);
            this.panel2.Controls.Add(this.cbxCajaNota);
            this.panel2.Controls.Add(this.cbxNota);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dtpNotaFechaCaja);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnNota);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 210);
            this.panel2.TabIndex = 1;
            // 
            // btnNotaFecha
            // 
            this.btnNotaFecha.BackColor = System.Drawing.Color.Maroon;
            this.btnNotaFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotaFecha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNotaFecha.Location = new System.Drawing.Point(382, 117);
            this.btnNotaFecha.Name = "btnNotaFecha";
            this.btnNotaFecha.Size = new System.Drawing.Size(98, 37);
            this.btnNotaFecha.TabIndex = 20;
            this.btnNotaFecha.Text = "Buscar";
            this.btnNotaFecha.UseVisualStyleBackColor = false;
            this.btnNotaFecha.Click += new System.EventHandler(this.btnNotaFecha_Click);
            // 
            // dtpNota
            // 
            this.dtpNota.CustomFormat = "dd/MM/YYYY";
            this.dtpNota.Location = new System.Drawing.Point(338, 65);
            this.dtpNota.Name = "dtpNota";
            this.dtpNota.Size = new System.Drawing.Size(168, 23);
            this.dtpNota.TabIndex = 18;
            this.dtpNota.Value = new System.DateTime(2022, 11, 21, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(343, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 21);
            this.label14.TabIndex = 17;
            this.label14.Text = "Busqueda por fecha";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(534, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "O";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(831, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "O";
            // 
            // cbxReciboNota
            // 
            this.cbxReciboNota.FormattingEnabled = true;
            this.cbxReciboNota.Location = new System.Drawing.Point(917, 65);
            this.cbxReciboNota.Name = "cbxReciboNota";
            this.cbxReciboNota.Size = new System.Drawing.Size(121, 23);
            this.cbxReciboNota.TabIndex = 14;
            this.cbxReciboNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxReciboNota_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(906, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 21);
            this.label11.TabIndex = 13;
            this.label11.Text = "Buscar por recibo";
            // 
            // btnReciboNota
            // 
            this.btnReciboNota.BackColor = System.Drawing.Color.Maroon;
            this.btnReciboNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReciboNota.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReciboNota.Location = new System.Drawing.Point(929, 117);
            this.btnReciboNota.Name = "btnReciboNota";
            this.btnReciboNota.Size = new System.Drawing.Size(98, 37);
            this.btnReciboNota.TabIndex = 12;
            this.btnReciboNota.Text = "Buscar";
            this.btnReciboNota.UseVisualStyleBackColor = false;
            this.btnReciboNota.Click += new System.EventHandler(this.btnReciboNota_Click);
            // 
            // btnFYCnota
            // 
            this.btnFYCnota.BackColor = System.Drawing.Color.Maroon;
            this.btnFYCnota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFYCnota.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFYCnota.Location = new System.Drawing.Point(660, 117);
            this.btnFYCnota.Name = "btnFYCnota";
            this.btnFYCnota.Size = new System.Drawing.Size(98, 37);
            this.btnFYCnota.TabIndex = 11;
            this.btnFYCnota.Text = "Buscar";
            this.btnFYCnota.UseVisualStyleBackColor = false;
            this.btnFYCnota.Click += new System.EventHandler(this.btnFYCnota_Click);
            // 
            // cbxCajaNota
            // 
            this.cbxCajaNota.FormattingEnabled = true;
            this.cbxCajaNota.Location = new System.Drawing.Point(647, 88);
            this.cbxCajaNota.Name = "cbxCajaNota";
            this.cbxCajaNota.Size = new System.Drawing.Size(121, 23);
            this.cbxCajaNota.TabIndex = 10;
            this.cbxCajaNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxCajaNota_KeyPress);
            // 
            // cbxNota
            // 
            this.cbxNota.FormattingEnabled = true;
            this.cbxNota.Location = new System.Drawing.Point(105, 65);
            this.cbxNota.Name = "cbxNota";
            this.cbxNota.Size = new System.Drawing.Size(121, 23);
            this.cbxNota.TabIndex = 9;
            this.cbxNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxNota_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(487, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "Nota/s de credito";
            // 
            // dtpNotaFechaCaja
            // 
            this.dtpNotaFechaCaja.CustomFormat = "dd/MM/YYYY";
            this.dtpNotaFechaCaja.Location = new System.Drawing.Point(616, 59);
            this.dtpNotaFechaCaja.Name = "dtpNotaFechaCaja";
            this.dtpNotaFechaCaja.Size = new System.Drawing.Size(168, 23);
            this.dtpNotaFechaCaja.TabIndex = 6;
            this.dtpNotaFechaCaja.Value = new System.DateTime(2022, 11, 21, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(564, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(301, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "Busqueda con fecha y caja(de recibos)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(36, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "Busqueda con numero de nota";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(283, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "O";
            // 
            // btnNota
            // 
            this.btnNota.BackColor = System.Drawing.Color.Maroon;
            this.btnNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNota.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNota.Location = new System.Drawing.Point(117, 117);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(98, 37);
            this.btnNota.TabIndex = 0;
            this.btnNota.Text = "Buscar";
            this.btnNota.UseVisualStyleBackColor = false;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // dgvProductosDevueltos
            // 
            this.dgvProductosDevueltos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosDevueltos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductosDevueltos.Location = new System.Drawing.Point(3, 428);
            this.dgvProductosDevueltos.Name = "dgvProductosDevueltos";
            this.dgvProductosDevueltos.RowTemplate.Height = 25;
            this.dgvProductosDevueltos.Size = new System.Drawing.Size(1100, 181);
            this.dgvProductosDevueltos.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1106, 612);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Notas de credito";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.tbxImprimirNota);
            this.tabPage5.Controls.Add(this.tbxImprimirRecibo);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.button2);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1106, 594);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Imprimir recibo / nota";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(384, 373);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 15);
            this.label19.TabIndex = 20;
            this.label19.Text = "Numero recibo:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(384, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 15);
            this.label18.TabIndex = 19;
            this.label18.Text = "Numero recibo:";
            // 
            // tbxImprimirNota
            // 
            this.tbxImprimirNota.Location = new System.Drawing.Point(499, 370);
            this.tbxImprimirNota.Name = "tbxImprimirNota";
            this.tbxImprimirNota.Size = new System.Drawing.Size(100, 23);
            this.tbxImprimirNota.TabIndex = 18;
            this.tbxImprimirNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // tbxImprimirRecibo
            // 
            this.tbxImprimirRecibo.Location = new System.Drawing.Point(499, 106);
            this.tbxImprimirRecibo.Name = "tbxImprimirRecibo";
            this.tbxImprimirRecibo.Size = new System.Drawing.Size(100, 23);
            this.tbxImprimirRecibo.TabIndex = 17;
            this.tbxImprimirRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(538, 249);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 25);
            this.label17.TabIndex = 16;
            this.label17.Text = "O";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(487, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 21);
            this.label16.TabIndex = 14;
            this.label16.Text = "Imprimir nota";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(499, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 37);
            this.button3.TabIndex = 13;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(487, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 21);
            this.label15.TabIndex = 11;
            this.label15.Text = "Imprimir recibo";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(499, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormConsultaRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 621);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormConsultaRecibos";
            this.Text = "Consulta Recibos";
            this.Load += new System.EventHandler(this.FormConsultaRecibos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosDevueltos)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRecibos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRecibo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnFYC;
        private System.Windows.Forms.ComboBox cbxCaja;
        private System.Windows.Forms.ComboBox cbxRecibo;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvNotas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFYCnota;
        private System.Windows.Forms.ComboBox cbxCajaNota;
        private System.Windows.Forms.ComboBox cbxNota;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNotaFechaCaja;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNota;
        private System.Windows.Forms.DataGridView dgvProductosDevueltos;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnNotaFecha;
        private System.Windows.Forms.DateTimePicker dtpNota;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxReciboNota;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReciboNota;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxImprimirNota;
        private System.Windows.Forms.TextBox tbxImprimirRecibo;
        private System.Windows.Forms.Label label17;
    }
}