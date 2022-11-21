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
    public partial class FormProducto : Form
    {
        string admin = "";
        string nombreProdSelect = "";

        public FormProducto(string adminUser)
        {
            admin = adminUser;
            InitializeComponent();
            var db = new ConexionDB();
            List<string> depar = db.GetDepartamentosName();
            foreach(var dep in depar)
            {
                cmbDepartamento.Items.Add(dep);
            }

            db = new ConexionDB();
            dgvProducto1.DataSource = db.GetProductos();
            dgvProducto2.DataSource = db.GetProductos();
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

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }

        private void dgvProducto1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducto1.Rows[e.RowIndex];
                nombreProdSelect = row.Cells["nombre"].Value.ToString();
                txtIdProd.Text = row.Cells["cod_producto"].Value.ToString();
                var db = new ConexionDB();
                DataTable table = db.GetDatosProductos(Convert.ToInt32(row.Cells["cod_producto"].Value.ToString()));
                txtNombre.Text = table.Rows[0]["nombre"].ToString();
                txtDescripcion.Text = table.Rows[0]["descripcion"].ToString();
                txtCosto.Text = table.Rows[0]["costo"].ToString();
                txtPrecioU.Text = table.Rows[0]["precio_unitario"].ToString();
                txtExistencia.Text = table.Rows[0]["existencia"].ToString();
                txtPuntoR.Text = table.Rows[0]["punto_reorden"].ToString();
                if (table.Rows[0]["estatus"].ToString() == "True")
                    ckbActiva.Checked = true;
                else
                    ckbActiva.Checked = false;

                cmbDepartamento.SelectedIndex = cmbDepartamento.FindString(table.Rows[0]["nombreDep"].ToString());
                txtUnidadM.Text = table.Rows[0]["nombreUnidad"].ToString();
                btn_Agregar.Visible = false;
                btn_Cancelar.Visible = true;
            }

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var db = new ConexionDB();
            int activo = 0;
            if (ckbActiva.Checked == true)
                activo = 1;
            else
                activo = 0;

            string dep;
            if (cmbDepartamento.SelectedIndex != -1 && txtCosto.Text != "" && txtPrecioU.Text != "" && txtExistencia.Text != "" &&txtPuntoR.Text != "" &&txtPrecioU.Text != "")
            {
                dep = cmbDepartamento.SelectedItem.ToString();
                if(db.InsertarProducto(txtNombre.Text, txtDescripcion.Text, Convert.ToDouble(txtCosto.Text), Convert.ToDouble(txtPrecioU.Text), Convert.ToDecimal(txtExistencia.Text), Convert.ToDecimal(txtPuntoR.Text), activo, admin, txtUnidadM.Text, dep) == 1)
                {
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtCosto.Text = "";
                    txtPrecioU.Text = "";
                    txtExistencia.Text = "";
                    txtPuntoR.Text = "";
                    if (ckbActiva.Checked)
                        ckbActiva.Checked = false;
                    cmbDepartamento.SelectedIndex = -1;
                    txtUnidadM.Text = "";
                    dgvProducto1.DataSource = db.GetProductos();
                    dgvProducto2.DataSource = db.GetProductos();
                }
                else
                {
                    MessageBox.Show("Datos erroneos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }           

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (nombreProdSelect.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un producto");
                return;
            }
            var db = new ConexionDB();
            int activo = 0;
            if (ckbActiva.Checked == true)
                activo = 1;
            else
                activo = 0;

            string dep;
            if (cmbDepartamento.SelectedIndex != -1 && txtCosto.Text != "" && txtPrecioU.Text != "" && txtExistencia.Text != "" && txtPuntoR.Text != "" && txtPrecioU.Text != "")
            {
                dep = cmbDepartamento.SelectedItem.ToString();
                int result = db.EditarProducto(Convert.ToInt32(txtIdProd.Text), txtNombre.Text, txtDescripcion.Text, Convert.ToDouble(txtCosto.Text), Convert.ToDouble(txtPrecioU.Text), Convert.ToDecimal(txtExistencia.Text), Convert.ToDecimal(txtPuntoR.Text), activo, txtUnidadM.Text, dep);
                if (result == 1)
                {
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtCosto.Text = "";
                    txtPrecioU.Text = "";
                    txtExistencia.Text = "";
                    txtPuntoR.Text = "";
                    if (ckbActiva.Checked)
                        ckbActiva.Checked = false;
                    cmbDepartamento.SelectedIndex = -1;
                    txtUnidadM.Text = "";
                    dgvProducto1.DataSource = db.GetProductos();
                    dgvProducto2.DataSource = db.GetProductos();
                    btn_Agregar.Visible = true;
                    btn_Cancelar.Visible = false;
                }
                else if(result !=0)
                {
                    MessageBox.Show("Datos erroneos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (nombreProdSelect.Equals(""))
            {
                MessageBox.Show("Necesitas escoger un producto");
                return;
            }
            var db = new ConexionDB();
            if (db.EliminarProducto(Convert.ToInt32(txtIdProd.Text)) == 1)
            {
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtCosto.Text = "";
                txtPrecioU.Text = "";
                txtExistencia.Text = "";
                txtPuntoR.Text = "";
                if (ckbActiva.Checked)
                    ckbActiva.Checked = false;
                cmbDepartamento.SelectedIndex = -1;
                txtUnidadM.Text = "";
                dgvProducto1.DataSource = db.GetProductos();
                dgvProducto2.DataSource = db.GetProductos();
                btn_Agregar.Visible = true;
                btn_Cancelar.Visible = false;
            }

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtPrecioU.Text = "";
            txtExistencia.Text = "";
            txtPuntoR.Text = "";
            if (ckbActiva.Checked)
                ckbActiva.Checked = false;
            cmbDepartamento.SelectedIndex = -1;
            txtUnidadM.Text = "";
            nombreProdSelect = "";
            btn_Agregar.Visible = true;
            btn_Cancelar.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void dgvProducto1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //Descuentos

        private void dgvProducto2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducto1.Rows[e.RowIndex];
                txtIdDesc.Text = row.Cells["cod_producto"].Value.ToString();
                var db = new ConexionDB();
                txtNombre2.Text = row.Cells["nombre"].Value.ToString();
 
               
                btnCancelarDesc.Visible = true;
            }
        }

        private void btnAplicarDesc_Click(object sender, EventArgs e)
        {
            if (txtNombre2.Text == "")
            {
                MessageBox.Show("Necesitas escoger un producto");
                return;
            }
            var db = new ConexionDB();
            int estatus = 0;
            string fechaI = dtpFechaI.Value.ToString("yyyy-MM-dd");
            string fechaF = dtpFechaF.Value.ToString("yyyy-MM-dd");

            if (DateTime.Now.Date >= dtpFechaI.Value && DateTime.Now.Date <= dtpFechaF.Value)
                estatus = 1;

            if(db.AñadirDescuento(fechaI,fechaF,Convert.ToInt32(txtIdDesc.Text), Convert.ToInt32(numDescuento.Value), estatus) == 1)
            {
                dtpFechaF.Value = DateTime.Now.Date;
                dtpFechaI.Value = DateTime.Now.Date;
                numDescuento.Value = 0;
                txtNombre2.Text = "";
            }

        }
    }
}
