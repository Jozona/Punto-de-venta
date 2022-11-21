using MAD.Conexion;
using MAD.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAD.FormsAdmin
{
    public partial class FormDevolucion : Form
    {

        List<ProductoNotaCredito> CarritoNota = new List<ProductoNotaCredito>();
        string admin = "";
        public FormDevolucion(string username)
        {
            InitializeComponent();
            admin = username;
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

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void txtNumRecibo_TextChanged(object sender, EventArgs e)
        {
            if(txtNumRecibo.Text !="")
            {
                var db = new ConexionDB();
                dgvProdRecibo.DataSource = db.GetProductosRecibo(Convert.ToInt32(txtNumRecibo.Text));
            }
        }

        private void ckbMerma_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMerma.Checked == true)
                numMerma.Enabled = true;
            else
                numMerma.Enabled = false;
        }

        private void dgvProdRecibo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               
                DataGridViewRow row = this.dgvProdRecibo.Rows[e.RowIndex];
                txtNombreProd.Text = row.Cells["Producto"].Value.ToString();
                txtCodProd.Text = row.Cells["CodProductoVenta"].Value.ToString();
                txtPrecioProd.Text = row.Cells["PrecioProducto"].Value.ToString();
                numCantidad.Maximum = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                numCantidad.Minimum = 1;
                numMerma.Maximum = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                numMerma.Minimum = 1;
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            //Checamos si el producto ya esta en el carrito de la nota para solo aumentar la cantidad
            var existe = CarritoNota.Find(p => p.IdProucto == Convert.ToInt32(txtCodProd.Text));
            if (existe != null)
            {
                if((existe.Cantidad + (decimal)numCantidad.Value) > numCantidad.Maximum)
                {
                    MessageBox.Show("No se puede agregar más productos de los que se compraron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                existe.Cantidad += (decimal)numCantidad.Value;
                existe.Total = existe.Cantidad * existe.Precio;

                if(ckbMerma.Checked == true)
                {
                    if ((existe.Merma + (decimal)numMerma.Value) > numMerma.Maximum)
                    {
                        MessageBox.Show("No se puede agregar más productos a merma de los que se compraron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else if ((decimal)numMerma.Value > (decimal)numCantidad.Value)
                    {
                        MessageBox.Show("Cantidad de merma erronea, compruebe sus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    existe.Merma += (decimal)numMerma.Value;
                    ckbMerma.Checked = false;
                    numMerma.Value = 1;
                }

                //Regresamos los textbox vacios
                numCantidad.Value = 1;
                txtNombreProd.Text = "";
                txtCodProd.Text = "";
                txtMotivo.Text = "";

                //Actualizamos el carrito en pantalla
                var bindingList = new BindingList<ProductoNotaCredito>(CarritoNota);
                var source = new BindingSource(bindingList, null);
                dgvProdNota.DataSource = source;
                return;
            }
            decimal merma = 0;
            if (ckbMerma.Checked == true) {
                if ((decimal)numMerma.Value > (decimal)numCantidad.Value)
                {
                    MessageBox.Show("Cantidad de merma erronea, compruebe sus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                merma = (decimal)numMerma.Value;
                ckbMerma.Checked = false;
            }
            //Agregamos el producto al carrito
            if (txtMotivo.Text == "")
            {
                MessageBox.Show("Por favor incluya un motivo de la devolucion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            AgregarProductoNota(Convert.ToInt32(txtCodProd.Text), (decimal)numCantidad.Value, Convert.ToDecimal(txtPrecioProd.Text), merma, txtMotivo.Text);
            numCantidad.Value = 1;
            numMerma.Value = 1;
            txtNombreProd.Text = "";
            txtCodProd.Text = "";
            txtMotivo.Text = "";
            return;
        }


        public void AgregarProductoNota(int codigo, decimal cantidad, decimal precio, decimal merma, string motivo)
        {
            CarritoNota.Add(new ProductoNotaCredito(codigo, cantidad, precio, merma, motivo));
            var bindingList = new BindingList<ProductoNotaCredito>(CarritoNota);
            var source = new BindingSource(bindingList, null);
            dgvProdNota.DataSource = source;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (CarritoNota.Count == 0)
            {
                MessageBox.Show("No hay a devolver");
            }
            else
            {
                var db = new ConexionDB();
                int recibo = db.CrearNotaCredito(CarritoNota, admin, Convert.ToInt32(txtNumRecibo.Text));
                if (recibo != -1)
                {
                    MessageBox.Show("El recibo fue creado correctamente");
                    //Imprimimos 
                    //var form2 = new FormTicket(recibo);
                    //form2.Closed += (s, args) => this.Close();
                    //form2.Show();

                    CarritoNota.Clear();

                    var bindingList = new BindingList<ProductoNotaCredito>(CarritoNota);
                    var source = new BindingSource(bindingList, null);
                    dgvProdRecibo.DataSource = source;
                    dgvProdNota.DataSource = source;
                    txtNumRecibo.Text = "";


                }
                else
                {
                    MessageBox.Show("No fue posible crear el recibo");

                }

            }
        }
    }
}
