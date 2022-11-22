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
    public partial class FormReporteCajero : Form
    {
        public FormReporteCajero()
        {
            InitializeComponent();
            var db = new ConexionDB();
            List<string> cajer = db.GetCajerosName();
            foreach (var caj in cajer)
            {
                cmbCajero.Items.Add(caj);
            }
            List<string> depar = db.GetDepartamentosName();
            cmbDepartamento.Items.Add("Todos");
            foreach (var dep in depar)
            {
                cmbDepartamento.Items.Add(dep);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cajero = "";
            string dep = "";
            if (cmbCajero.SelectedIndex == -1)
            {
                MessageBox.Show("Necesitas escoger un Cajero");
                return;
            }
            else if (cmbCajero.SelectedItem.ToString() != "Todos")
                cajero = cmbCajero.SelectedItem.ToString();
            if (cmbDepartamento.SelectedIndex == -1)
            {
                MessageBox.Show("Necesitas escoger un Departamento");
                return;
            }
            else if (cmbDepartamento.SelectedItem.ToString() != "Todos")
                dep = cmbDepartamento.SelectedItem.ToString();

            string fechaI = dtpFechaI.Value.ToString("yyyy-MM-dd");
            string fechaF = dtpFechaF.Value.ToString("yyyy-MM-dd");
            var db = new ConexionDB();
            dgvReporteCajero.DataSource = db.GetReporteCajeros(cajero, dep, fechaI, fechaF);


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

        private void FormReporteCajero_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
