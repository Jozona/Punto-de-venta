using MAD.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAD.Forms
{
    public partial class FormEscogerCaja : Form
    {
        string usernameProxy = "";
        string rolProxy = "";
        string num_cajaSelect = "";

        public FormEscogerCaja(string rol, string username)
        {
            InitializeComponent();
            usernameProxy = username;
            rolProxy = rol;
            var db = new ConexionDB();
            dgvCajasEscoger.DataSource = db.GetCajasDisponibles();
            dgvCajasEscoger.AllowUserToOrderColumns = true;
            dgvCajasEscoger.AllowUserToResizeColumns = true;
            dgvCajasEscoger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCajasEscoger.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void FormEscogerCaja_Load(object sender, EventArgs e)
        {

        }

        private void dgvCajasEscoger_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCajasEscoger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCajasEscoger.Rows[e.RowIndex];
                num_cajaSelect = row.Cells["num_caja"].Value.ToString();
                txtCaja.Text = row.Cells["num_caja"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCaja.Text.Equals("")){
                MessageBox.Show("Necesitas escoger una caja.");
                return;
            }

            
            var db = new ConexionDB();
            byte cajero = db.GetIdCajero(usernameProxy);
            db.AsignarCaja(Int32.Parse(txtCaja.Text), cajero);
            this.Hide();
            var form2 = new Form1(rolProxy, usernameProxy, Int32.Parse(txtCaja.Text));
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
