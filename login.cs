using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MAD.Conexion;

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
            //Checamos en la base de datos si el usuario existe
            var db = new ConexionDB();
            string login = db.Login(txtUsername.Text, txtPassword.Text);

            if (login.Equals("admin"))
            {
                this.Hide();
                var form2 = new Form1(login, txtUsername.Text, -1);
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
            else if (login.Equals("caja")) {
                this.Hide();
                var form2 = new Forms.FormEscogerCaja(login, txtUsername.Text);
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
