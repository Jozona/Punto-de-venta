
namespace MAD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.btnExpander = new FontAwesome.Sharp.IconButton();
            this.btnCerrarChildForm = new FontAwesome.Sharp.IconButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelSeccion = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.iconButton2);
            this.panelMenu.Controls.Add(this.iconButton1);
            this.panelMenu.Controls.Add(this.panelInfo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 754);
            this.panelMenu.TabIndex = 0;
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Cube;
            this.iconButton2.IconColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 140);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.iconButton2.Size = new System.Drawing.Size(220, 60);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "Salir";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Cube;
            this.iconButton1.IconColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 80);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(220, 60);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Venta";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelInfo.Controls.Add(this.label3);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(220, 80);
            this.panelInfo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(62, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(89, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "10:24";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(53, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitulo.Controls.Add(this.btnMaximize);
            this.panelTitulo.Controls.Add(this.iconButton6);
            this.panelTitulo.Controls.Add(this.btnExpander);
            this.panelTitulo.Controls.Add(this.btnCerrarChildForm);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(220, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1039, 80);
            this.panelTitulo.TabIndex = 1;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 18;
            this.btnMaximize.Location = new System.Drawing.Point(965, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(41, 24);
            this.btnMaximize.TabIndex = 6;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconButton6.IconColor = System.Drawing.Color.White;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 14;
            this.iconButton6.Location = new System.Drawing.Point(997, 2);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Size = new System.Drawing.Size(41, 24);
            this.iconButton6.TabIndex = 5;
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click_1);
            // 
            // btnExpander
            // 
            this.btnExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpander.FlatAppearance.BorderSize = 0;
            this.btnExpander.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpander.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnExpander.IconColor = System.Drawing.Color.White;
            this.btnExpander.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExpander.IconSize = 21;
            this.btnExpander.Location = new System.Drawing.Point(929, 0);
            this.btnExpander.Name = "btnExpander";
            this.btnExpander.Size = new System.Drawing.Size(41, 21);
            this.btnExpander.TabIndex = 4;
            this.btnExpander.UseVisualStyleBackColor = true;
            // 
            // btnCerrarChildForm
            // 
            this.btnCerrarChildForm.FlatAppearance.BorderSize = 0;
            this.btnCerrarChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarChildForm.IconChar = FontAwesome.Sharp.IconChar.HouseChimney;
            this.btnCerrarChildForm.IconColor = System.Drawing.Color.White;
            this.btnCerrarChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarChildForm.IconSize = 36;
            this.btnCerrarChildForm.Location = new System.Drawing.Point(6, 6);
            this.btnCerrarChildForm.Name = "btnCerrarChildForm";
            this.btnCerrarChildForm.Size = new System.Drawing.Size(33, 29);
            this.btnCerrarChildForm.TabIndex = 1;
            this.btnCerrarChildForm.UseVisualStyleBackColor = true;
            this.btnCerrarChildForm.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(492, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(62, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio";
            // 
            // panelSeccion
            // 
            this.panelSeccion.AutoSize = true;
            this.panelSeccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeccion.Location = new System.Drawing.Point(220, 80);
            this.panelSeccion.Name = "panelSeccion";
            this.panelSeccion.Size = new System.Drawing.Size(1039, 674);
            this.panelSeccion.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 754);
            this.Controls.Add(this.panelSeccion);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelInfo;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSeccion;
        private FontAwesome.Sharp.IconButton btnCerrarChildForm;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton btnExpander;
    }
}

