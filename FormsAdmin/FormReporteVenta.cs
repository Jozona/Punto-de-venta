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
    public partial class FormReporteVenta : Form
    {

        bool fechaInicio, fechaFinal = false;

        public FormReporteVenta()
        {
            InitializeComponent();

            var db = new ConexionDB();
            dgvReporteVentas.DataSource = db.GetReporteVentas();
            dgvReporteVentas.AllowUserToOrderColumns = true;
            dgvReporteVentas.AllowUserToResizeColumns = true;
            dgvReporteVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaInicio = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fechaFinal = true;
        }

        private void btnBuscarReporteVenta_Click(object sender, EventArgs e)
        {
            (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# And fecha_venta <= #{1:yyyy/MM/dd}# AND nombre LIKE '%{2}%'", dateTimePicker1.Value, dateTimePicker2.Value, cbxDepartamento.Text);
            int i = 0;
        }
    }
}
