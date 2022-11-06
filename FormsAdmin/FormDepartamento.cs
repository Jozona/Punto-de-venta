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
    public partial class FormDepartamento : Form
    {

        string admin = "";
        string cveDepSeleccionado = "";

        public FormDepartamento(string adminUser)
        {
            admin = adminUser;
            InitializeComponent();
            var db = new ConexionDB();
            dgvDepartamentos.DataSource = db.GetDepartamentos();
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

        private void FormDepartamento_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void dgvDepartamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDepartamentos.Rows[e.RowIndex];
                cveDepSeleccionado = row.Cells["clave_departamento"].Value.ToString();
                tbxDepartamento.Text = row.Cells["nombre"].Value.ToString();
                if (row.Cells["devolucion"].Value.ToString() == "True")
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;
                if (row.Cells["activo"].Value.ToString() == "True")
                    ckbActivo.Checked = true;
                else
                    ckbActivo.Checked = false;
                btn_Agregar.Visible = false;
                btn_Cancelar.Visible = true;
            }

        }



        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            Random aleatorio = new Random();

            int devolucion = 0;
            int estatus = 0;
            if (checkBox1.Checked == true)
                devolucion = 1;
            if (ckbActivo.Checked == true)
                estatus = 1;

            int claveRandom;

            claveRandom = aleatorio.Next(10000, 99999);

            var db = new ConexionDB();


            if (db.InsertarDepartamento(tbxDepartamento.Text, claveRandom.ToString(), devolucion, estatus, admin) == 1)
            {
                tbxDepartamento.Text = "";
                if (checkBox1.Checked == true)
                    checkBox1.Checked = false;
                if (ckbActivo.Checked == true)
                    ckbActivo.Checked = false;

                dgvDepartamentos.DataSource = db.GetDepartamentos();
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (cveDepSeleccionado.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un departamento");
                return;
            }
            int devolucion = 0;
            int estatus = 0;
            if (checkBox1.Checked == true)
                devolucion = 1;
            if (ckbActivo.Checked == true)
                estatus = 1;
            var db = new ConexionDB();
            if (db.EditarDepartamento(tbxDepartamento.Text, devolucion, estatus,cveDepSeleccionado) == 1)
            {
                tbxDepartamento.Text = "";
                if (checkBox1.Checked == true)
                    checkBox1.Checked = false;
                if (ckbActivo.Checked == true)
                    ckbActivo.Checked = false;
                cveDepSeleccionado = "";
                btn_Agregar.Visible = true;
                btn_Cancelar.Visible = false;
                dgvDepartamentos.DataSource = db.GetDepartamentos();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            tbxDepartamento.Text = "";
            if (checkBox1.Checked == true)
                checkBox1.Checked = false;
            if (ckbActivo.Checked == true)
                ckbActivo.Checked = false;
            cveDepSeleccionado = "";
            btn_Agregar.Visible = true;
            btn_Cancelar.Visible = false;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (cveDepSeleccionado.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un departamento");
                return;
            }
           var db = new ConexionDB();
            if (db.EliminarDepartamento(cveDepSeleccionado) == 1)
            {
                tbxDepartamento.Text = "";
                if (checkBox1.Checked == true)
                    checkBox1.Checked = false;
                if (ckbActivo.Checked == true)
                    ckbActivo.Checked = false;
                cveDepSeleccionado = "";
                btn_Agregar.Visible = true;
                btn_Cancelar.Visible = false;
                dgvDepartamentos.DataSource = db.GetDepartamentos();
            }

        }





        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
