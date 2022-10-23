using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MAD
{
    public partial class login : Form
    {
        public static int user = 0;
        public login()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "admin")
            //{
            //    user = 0;
            //    var frm = new Form1();
            //    frm.Location = this.Location;
            //    frm.StartPosition = FormStartPosition.Manual;
            //    frm.FormClosing += delegate { this.Show(); };
            //    frm.Show();
            //    this.Hide();
            //}
            //else if (textBox1.Text == "cajero")
            //{

            //    user = 1;
            //    var frm = new Form1();
            //    frm.Location = this.Location;
            //    frm.StartPosition = FormStartPosition.Manual;
            //    frm.FormClosing += delegate { this.Show(); };
            //    frm.Show();
            //    this.Hide();
            //}
            //else {
            //    MessageBox.Show("Usuario incorrecto");
            //}
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-FINOVELR;Initial Catalog=PuntoDeVenta;User ID=;Password=";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
