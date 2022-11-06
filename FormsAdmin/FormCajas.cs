using MAD.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAD.FormsAdmin
{
    public partial class FormCajas : Form
    {
        string admin = "";
        string num_cajaSelect = "";
        public FormCajas(string adminUser)
        {
            admin = adminUser;
            InitializeComponent();
            var db = new ConexionDB();
            txtNumCaja.Text = db.GetNumCaja().ToString();
            dgvCajas.DataSource = db.GetCajas();
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Theme.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Theme.SecondaryColor;
                }

            }
        }

        private void FormCajas_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int activo = 0;
            if (ckbActiva.Checked == true)
                activo = 1;

            var db = new ConexionDB();
            if (db.InsertarCaja(admin,activo) == 1)
            {
                if (ckbActiva.Checked == true)
                    ckbActiva.Checked = false;
                dgvCajas.DataSource = db.GetCajas();
                txtNumCaja.Text = db.GetNumCaja().ToString();
            }
        }

        private void dgvCajas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCajas.Rows[e.RowIndex];
                num_cajaSelect = row.Cells["num_caja"].Value.ToString();
                txtNumCaja.Text = row.Cells["num_caja"].Value.ToString();
                txtCajero.Text = row.Cells["cajero"].Value.ToString();
                if (row.Cells["estatus"].Value.ToString() == "True")
                    ckbActiva.Checked = true;
                else
                    ckbActiva.Checked = false;
                btnAgregar.Visible = false;
                btnCancelar.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNumCaja.Text = "";
            if (ckbActiva.Checked == true)
                ckbActiva.Checked = false;
            if (ckbActiva.Checked == true)
                ckbActiva.Checked = false;
            btnAgregar.Visible = true;
            btnCancelar.Visible = false;
            var db = new ConexionDB();
            txtNumCaja.Text = db.GetNumCaja().ToString();
            num_cajaSelect = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (num_cajaSelect.Equals(""))
            {
                MessageBox.Show("Necesitas escoger una caja");
                return;
            }
            if (txtCajero.Text == "")
            {
                int activo = 0;
                if (ckbActiva.Checked == true)
                    activo = 1;
                var db = new ConexionDB();
                if (db.EditarCaja(Convert.ToInt32(txtNumCaja.Text),activo) == 1)
                {
                    txtNumCaja.Text = "";
                    if (ckbActiva.Checked == true)
                        ckbActiva.Checked = false;
                    if (ckbActiva.Checked == true)
                        ckbActiva.Checked = false;
                    btnAgregar.Visible = true;
                    btnCancelar.Visible = false;    
                    txtNumCaja.Text = db.GetNumCaja().ToString();
                    dgvCajas.DataSource = db.GetCajas();
                    num_cajaSelect = "";
                }
                return;
            }
            MessageBox.Show("No se puede modificar esta caja ya que un cajero la esta utilizando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (num_cajaSelect.Equals(""))
            {
                MessageBox.Show("Necesitas escoger una caja");
                return;
            }
            if (txtCajero.Text == "")
            {
                int activo = 0;
                if (ckbActiva.Checked == true)
                    activo = 1;
                var db = new ConexionDB();
                if (db.EliminarCaja(Convert.ToInt32(txtNumCaja.Text)) == 1)
                {
                    txtNumCaja.Text = "";
                    if (ckbActiva.Checked == true)
                        ckbActiva.Checked = false;
                    if (ckbActiva.Checked == true)
                        ckbActiva.Checked = false;
                    btnAgregar.Visible = true;
                    btnCancelar.Visible = false;
                    txtNumCaja.Text = db.GetNumCaja().ToString();
                    dgvCajas.DataSource = db.GetCajas();
                    num_cajaSelect = "";
                }
                return;
            }
            MessageBox.Show("No se puede eliminar esta caja ya que un cajero la esta utilizando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
