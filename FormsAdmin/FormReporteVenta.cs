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

        bool fechaInicio, fechaFinal;

        public FormReporteVenta()
        {
            InitializeComponent();

            var db = new ConexionDB();
            dgvReporteVentas.DataSource = db.GetReporteVentas();
            dgvReporteVentas.AllowUserToOrderColumns = true;
            dgvReporteVentas.AllowUserToResizeColumns = true;
            dgvReporteVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReporteVentas.Columns["caja"].Visible = false;

            List<string> depar = db.GetDepartamentosName();
            foreach (var dep in depar)
            {
                cbxDepartamento.Items.Add(dep);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaInicio = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fechaFinal = true;
        }

        private void FormReporteVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarReporteVenta_Click(object sender, EventArgs e)
        {

            if (!fechaInicio && !fechaFinal && tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("No hay nada seleccionado");
            }

            else if (fechaInicio && !fechaFinal && tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals("")) { 
                MessageBox.Show("Solo hay fecha de inicio");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}#", dateTimePicker1.Value);
            }

            else if (!fechaInicio && fechaFinal && tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Solo hay fecha de final");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta <= #{0:yyyy/MM/dd}#", dateTimePicker2.Value);
            }

            else if (!fechaInicio && !fechaFinal && !tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Solo hay caja");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(caja, System.String) LIKE '{0}'", tbxCaja.Text);
            }

            else if (!fechaInicio && !fechaFinal && tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Solo hay departamento");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre LIKE '{0}'", cbxDepartamento.Text);
            }

            else if (fechaInicio && fechaFinal && tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Hay fecha de inicio y de final");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# And fecha_venta <= #{1:yyyy/MM/dd}#", dateTimePicker1.Value, dateTimePicker2.Value);
            }

            //Fecha de inicio y caja
            else if (fechaInicio && !fechaFinal && !tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Fecha de inicio y caja");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# AND CONVERT(caja, System.String) LIKE '{1}'", dateTimePicker1.Value,  Int32.Parse(tbxCaja.Text));
            }

            //Fecha de inicio y departamento
            else if (fechaInicio && !fechaFinal && tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# AND nombre LIKE '{1}' ", dateTimePicker1.Value, cbxDepartamento.Text);
            }

            //Fecha de final y caja
            else if (!fechaInicio && fechaFinal && !tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta <= #{0:yyyy/MM/dd}# AND CONVERT(caja, System.String) LIKE '{1}'",  dateTimePicker2.Value, Int32.Parse(tbxCaja.Text));
            }

            //Fecha de final y departamento
            else if (!fechaInicio && fechaFinal && tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta <= #{0:yyyy/MM/dd}# AND nombre LIKE '{1}'", dateTimePicker2.Value, cbxDepartamento.Text);
            }

            //Departamento Y caja
            else if (!fechaFinal && !fechaFinal && !tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre LIKE '{0}' AND CONVERT(caja, System.String) LIKE '{1}'", cbxDepartamento.Text, Int32.Parse(tbxCaja.Text));
            }

            //Fecha de inicio, final y departamento
            else if (fechaInicio && fechaFinal && tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Hay fecha de inicio, de final y una departamento");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# And fecha_venta <= #{1:yyyy/MM/dd}# AND nombre LIKE '{2}'", dateTimePicker1.Value, dateTimePicker2.Value, cbxDepartamento.Text);
            }

            else if (fechaInicio && fechaFinal && !tbxCaja.Text.Equals("") && cbxDepartamento.Text.Equals(""))
            {
                MessageBox.Show("Hay fecha de inicio, de final y una caja");
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# And fecha_venta <= #{1:yyyy/MM/dd}# AND CONVERT(caja, System.String) LIKE '{2}'", dateTimePicker1.Value, dateTimePicker2.Value, Int32.Parse(tbxCaja.Text));
            }


            else if (fechaInicio && fechaFinal && !tbxCaja.Text.Equals("") && !cbxDepartamento.Text.Equals(""))
            {
                (dgvReporteVentas.DataSource as DataTable).DefaultView.RowFilter = string.Format("fecha_venta >= #{0:yyyy/MM/dd}# And fecha_venta <= #{1:yyyy/MM/dd}# AND nombre LIKE '{2}' AND CONVERT(caja, System.String) LIKE '{3}'", dateTimePicker1.Value, dateTimePicker2.Value, cbxDepartamento.Text, Int32.Parse(tbxCaja.Text));
            }

            
            
            tbxCaja.Text = "";
            cbxDepartamento.SelectedIndex = -1;
            fechaFinal = false;
            fechaInicio = false;
        }
    }
}
