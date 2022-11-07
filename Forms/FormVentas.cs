using MAD.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAD.Forms
{
    public partial class FormVentas : Form
    {

        List<ProductoVenta> Carrito = new List<ProductoVenta>();
        public FormVentas()
        {
            InitializeComponent();
            dtvCarrito.AllowUserToOrderColumns = true;
            dtvCarrito.AllowUserToResizeColumns = true;
            dtvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtvCarrito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            var db = new ConexionDB();
            dgvProductos.DataSource = db.GetProductosCaja();
            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

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

        private void FormInicio_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProducto("hola", 12.3m, 3);
        }

        //Agregar objeto al carrito
        public void AgregarProducto(string nombre, decimal precio, int cantidad) {
            Carrito.Add(new ProductoVenta(nombre, precio, cantidad));
            var bindingList = new BindingList<ProductoVenta>(Carrito);
            var source = new BindingSource(bindingList, null);
            dtvCarrito.DataSource = source;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbxCodigoArticulo_TextChanged(object sender, EventArgs e)
        {
            (dgvProductos.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(cod_producto, System.String) LIKE '%{0}%'", tbxCodigoArticulo.Text);
        }

        private void tbxNombreProducto_TextChanged(object sender, EventArgs e)
        {
            (dgvProductos.DataSource as DataTable).DefaultView.RowFilter = string.Format("nombre LIKE '%{0}%'", tbxNombreProducto.Text);
        }
    }
}
