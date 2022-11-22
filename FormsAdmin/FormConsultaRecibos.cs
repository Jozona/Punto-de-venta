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
    public partial class FormConsultaRecibos : Form
    {
        public FormConsultaRecibos()
        {
            InitializeComponent();
            dgvRecibos.AllowUserToOrderColumns = true;
            dgvRecibos.AllowUserToResizeColumns = true;
            dgvRecibos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecibos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvNotas.AllowUserToOrderColumns = true;
            dgvNotas.AllowUserToResizeColumns = true;
            dgvNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxRecibo.Text.Equals("")) { 
                MessageBox.Show("Asegurate de ingresar un recibo");
                return;
            }

            var db = new ConexionDB();
            dgvRecibos.DataSource = db.GetRecibo(Int32.Parse(cbxRecibo.Text));
            dgvProductos.DataSource = db.GetProductosDeRecibo(Int32.Parse(cbxRecibo.Text));
            dgvRecibos.Columns[1].DefaultCellStyle.Format = "N2";
            dgvRecibos.Columns[2].DefaultCellStyle.Format = "N2";
            dgvRecibos.Columns[3].DefaultCellStyle.Format = "N2";
            dgvProductos.Columns[1].DefaultCellStyle.Format = "N2";
            dgvProductos.Columns[2].DefaultCellStyle.Format = "N2";
            dgvProductos.Columns[3].DefaultCellStyle.Format = "N2";
        }

        private void FormConsultaRecibos_Load(object sender, EventArgs e)
        {

        }

        private void cbxRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFYC_Click(object sender, EventArgs e)
        {
            if (cbxCaja.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar una caja");
                return;
            }
            var db = new ConexionDB();
            string fecha = dtpRecibo.Value.ToString("yyyy-MM-dd");
            
            dgvRecibos.DataSource = db.GetRecibosFechaCaja(fecha, Int32.Parse(cbxCaja.Text));
            dgvRecibos.Columns[1].DefaultCellStyle.Format = "N2";
            dgvRecibos.Columns[2].DefaultCellStyle.Format = "N2";
            dgvRecibos.Columns[3].DefaultCellStyle.Format = "N2";
        }

        private void dgvRecibos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvRecibos.Rows[e.RowIndex];
                //tbxNombre.Text = row.Cells["nombre"].Value.ToString();
                MessageBox.Show("Recibo seleccionado");
                string numRecibo = row.Cells[0].Value.ToString();
                var db = new ConexionDB();
                dgvProductos.DataSource = db.GetProductosDeRecibo(Int32.Parse(numRecibo));
                dgvProductos.Columns[1].DefaultCellStyle.Format = "N2";
                dgvProductos.Columns[2].DefaultCellStyle.Format = "N2";
                dgvProductos.Columns[3].DefaultCellStyle.Format = "N2";
            }
        }

        private void cbxCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //Cuando se pide nota con fecha y caja de recibo
        private void btnFYCnota_Click(object sender, EventArgs e)
        {
            if (cbxCajaNota.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar una caja");
                return;
            }

            var db = new ConexionDB();
            string fecha = dtpNotaFechaCaja.Value.ToString("yyyy-MM-dd");
            dgvNotas.DataSource = db.GetNotaFechaCaja(fecha, Int32.Parse(cbxCajaNota.Text));

        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            if (cbxNota.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar una nota");
                return;
            }

            var db = new ConexionDB();
            dgvNotas.DataSource = db.GetNota(Int32.Parse(cbxNota.Text));
            dgvNotas.Columns[2].DefaultCellStyle.Format = "N2";
            dgvProductosDevueltos.DataSource = db.GetProductosNota(Int32.Parse(cbxNota.Text));
        }

        private void btnNotaFecha_Click(object sender, EventArgs e)
        {
            var db = new ConexionDB();
            string fecha = dtpNota.Value.ToString("yyyy-MM-dd");
            dgvNotas.DataSource = db.GetNotaFecha(fecha);
        }

        private void btnReciboNota_Click(object sender, EventArgs e)
        {
            if (cbxReciboNota.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar un recibo");
                return;
            }

            var db = new ConexionDB();
            dgvNotas.DataSource = db.GetNotaRecibo(Int32.Parse(cbxReciboNota.Text));
            dgvNotas.Columns[2].DefaultCellStyle.Format = "N2";


        }

        private void dgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNotas.Rows[e.RowIndex];
                //tbxNombre.Text = row.Cells["nombre"].Value.ToString();
                MessageBox.Show("Nota seleccionada");
                string numNota = row.Cells[0].Value.ToString();
                var db = new ConexionDB();
                dgvProductosDevueltos.DataSource = db.GetProductosNota(Int32.Parse(numNota));
                dgvProductosDevueltos.Columns[1].DefaultCellStyle.Format = "N2";
                dgvProductosDevueltos.Columns[2].DefaultCellStyle.Format = "N2";
                dgvProductosDevueltos.Columns[3].DefaultCellStyle.Format = "N2";
            }
        }

        private void dgvNotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNotas.Rows[e.RowIndex];
                //tbxNombre.Text = row.Cells["nombre"].Value.ToString();
                MessageBox.Show("Hola");
                string numNota = row.Cells[0].Value.ToString();
                var db = new ConexionDB();
                dgvProductosDevueltos.DataSource = db.GetProductosNota(Int32.Parse(numNota));
                dgvProductosDevueltos.Columns[1].DefaultCellStyle.Format = "N2";
                dgvProductosDevueltos.Columns[2].DefaultCellStyle.Format = "N2";
                dgvProductosDevueltos.Columns[3].DefaultCellStyle.Format = "N2";
            }
        }

        private void cbxNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbxCajaNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbxReciboNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbxImprimirRecibo.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar un recibo");
                return;
            }
            var db = new ConexionDB();
            int existe = db.ReciboExiste(Int32.Parse(tbxImprimirRecibo.Text));
            if (existe == 1)
            {
                var form2 = new FormTicket(Int32.Parse(tbxImprimirRecibo.Text), 0);
                //form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else {
                MessageBox.Show("No fue encontrado");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbxImprimirNota.Text.Equals(""))
            {
                MessageBox.Show("Asegurate de ingresar una nota");
                return;
            }
            var db = new ConexionDB();
            int existe = db.NotaExiste(Int32.Parse(tbxImprimirNota.Text));
            if (existe == 1)
            {
                var form2 = new FormTicket(Int32.Parse(tbxImprimirNota.Text), 1);
                //form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("No fue encontrado");
            }
        }
    }
}
