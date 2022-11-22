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
    public partial class FormInventario : Form
    {
        public FormInventario()
        {
            InitializeComponent();
            var db = new ConexionDB();
            dgvInventario.DataSource = db.GetProductosInventario();
            List<string> depar = db.GetDepartamentosName();
            foreach (var dep in depar)
            {
                cmbDepartamentoInventario.Items.Add(dep);
            } 
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

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string dep = "";
            int existencia = 0;
            int agotados = 0;
            int merma = 0;
            if (cmbDepartamentoInventario.SelectedIndex != -1)
                dep = cmbDepartamentoInventario.SelectedItem.ToString();
            if (numExistencia.Value != 0)
                existencia = Convert.ToInt32(numExistencia.Value);
            if (ckbAgotados.Checked == true && numExistencia.Value == 0)
                agotados = 1;
            if (ckbMerma.Checked == true)
                merma = 1;

            var db = new ConexionDB();
            dgvInventario.DataSource = db.GetProductosInventarioFiltros(dep,existencia,agotados,merma);
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
