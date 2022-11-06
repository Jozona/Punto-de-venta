using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MAD.Conexion;

namespace MAD.FormsAdmin
{
    public partial class FormCajero : Form
    {
        string admin = "";
        string cajeroSeleccionado = "";
        string userCajeroSelccionado = "";
        public FormCajero(string adminUser)
        {
            admin = adminUser;
            InitializeComponent();
            var db = new ConexionDB();
            dgvCajeros.DataSource = db.GetCajeros();
            LoadTheme();
            
        }


        //Envia los datos a los textBox cuando le da click a una celda
       


        private void LoadTheme() {
            foreach (Control btns in this.Controls) {
                if (btns.GetType() == typeof(Button)) {
                    Button btn = (Button)btns;
                    btn.BackColor = Theme.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Theme.SecondaryColor;
                }
            
            }
        }

        private void FormCajero_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        //Boton para editar al cajero

        private void button1_Click_1(object sender, EventArgs e)
        {
            var db = new ConexionDB();
            if (tbxAM.Text == "" || tbxAP.Text == "" || tbxNombre.Text == "" || tbxNomina.Text == "" || tbxCurp.Text == "" || tbxEmail.Text == "" || tbxPassword.Text == "" || tbxUsuario.Text == "")
                return;
            db.InsertarUsuarioCajero(tbxUsuario.Text, tbxPassword.Text);
            string fechaNacimiento = dtpNacimiento.Value.ToString("yyyy-MM-dd");
            db.InsertarDatosCajero(tbxNombre.Text, tbxAM.Text, tbxAP.Text, tbxCurp.Text, fechaNacimiento, tbxNomina.Text, tbxEmail.Text, tbxUsuario.Text, admin);
            tbxAM.Text = "";
            tbxAP.Text = "";
            tbxNombre.Text = "";
            tbxNomina.Text = "";
            tbxCurp.Text = "";
            tbxEmail.Text = "";
            tbxPassword.Text = "";
            tbxUsuario.Text = "";
            dtpNacimiento.Value = DateTime.Now;
            dgvCajeros.DataSource = db.GetCajeros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbxAM.Text = "";
            tbxAP.Text = "";
            tbxNombre.Text = "";
            tbxNomina.Text = "";
            tbxCurp.Text = "";
            tbxEmail.Text = "";
            tbxPassword.Text = "";
            tbxUsuario.Text = "";
            dtpNacimiento.Value = DateTime.Now;
            btnCancelar.Visible = false;
            button1.Visible = true;
        }

        private void dgvCajeros_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCajeros.Rows[e.RowIndex];
                tbxNombre.Text = row.Cells["nombre"].Value.ToString();
                tbxAM.Text = row.Cells["apellido_materno"].Value.ToString();
                tbxAP.Text = row.Cells["apellido_paterno"].Value.ToString();
                tbxCurp.Text = row.Cells["curp"].Value.ToString();
                dtpNacimiento.Text = row.Cells["fecha_nacimiento"].Value.ToString();
                tbxNomina.Text = row.Cells["num_nomina"].Value.ToString();
                tbxEmail.Text = row.Cells["email"].Value.ToString();
                tbxUsuario.Text = row.Cells["usuario"].Value.ToString();
                tbxPassword.Text = row.Cells["contra"].Value.ToString();
                cajeroSeleccionado = row.Cells["id_cajero"].Value.ToString();
                userCajeroSelccionado = row.Cells["usuario"].Value.ToString();
                btnCancelar.Visible = true;
                button1.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cajeroSeleccionado.Equals("") || userCajeroSelccionado.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un cajero");
                return;
            }
            var db = new ConexionDB();
            string fechaNacimiento = dtpNacimiento.Value.ToString("yyyy-MM-dd");
            db.EditarCajero(tbxNombre.Text, tbxAM.Text, tbxAP.Text, tbxCurp.Text, fechaNacimiento, tbxNomina.Text, tbxEmail.Text, userCajeroSelccionado, admin, tbxPassword.Text, cajeroSeleccionado);
            tbxAM.Text = "";
            tbxAP.Text = "";
            tbxNombre.Text = "";
            tbxNomina.Text = "";
            tbxCurp.Text = "";
            tbxEmail.Text = "";
            tbxPassword.Text = "";
            tbxUsuario.Text = "";
            dtpNacimiento.Value = DateTime.Now;
            btnCancelar.Visible = false;
            button1.Visible = true;
            dgvCajeros.DataSource = db.GetCajeros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cajeroSeleccionado.Equals("") || userCajeroSelccionado.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un cajero");
                return;
            }
            var db = new ConexionDB();
            db.EliminarCajero(cajeroSeleccionado);
            tbxAM.Text = "";
            tbxAP.Text = "";
            tbxNombre.Text = "";
            tbxNomina.Text = "";
            tbxCurp.Text = "";
            tbxEmail.Text = "";
            tbxPassword.Text = "";
            tbxUsuario.Text = "";
            dtpNacimiento.Value = DateTime.Now;
            btnCancelar.Visible = false;
            button1.Visible = true;
            dgvCajeros.DataSource = db.GetCajeros();
        }
    }
}
