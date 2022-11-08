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
        string productoCodigo = "";
        string productoNombre = "";
        decimal subtotal = 0;
        decimal descuento = 0;
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

            

            //Si no hay cantidad escogida
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("Primero es necesario escoger la cantidad del producto");
                return;
            }

            //Buscamos si el codigo de producto ingresado es correcto
            var db = new ConexionDB();

            //Traemos el producto si esta en la bdd
            var producto = db.BuscarProducto(Int32.Parse(tbxCodigoArticulo.Text), (int)nudCantidad.Value);
            if (producto != null)
            {

                //Checamos si el producto ya esta en el carrito para solo aumentar la cantidad
                var existe = Carrito.Find(p => p.Codigo == producto.Codigo);
                if ( existe != null) {
                    existe.Cantidad += (int)nudCantidad.Value;
                    existe.Total = existe.Cantidad * existe.Precio;

                    //Regresamos los textbox vacios
                    nudCantidad.Value = 0;
                    productoCodigo = "";
                    tbxCodigoArticulo.Text = "";
                    tbxNombreProducto.Text = "";

                    //Actualizamos el carrito en pantalla
                    var bindingList = new BindingList<ProductoVenta>(Carrito);
                    var source = new BindingSource(bindingList, null);
                    dtvCarrito.DataSource = source;
                    return;
                }


                //Agregamos el producto al carrito
                AgregarProducto(producto.Codigo,producto.Nombre, producto.Precio, producto.Cantidad);
                nudCantidad.Value = 0;
                productoCodigo = "";
                tbxCodigoArticulo.Text = "";
                tbxNombreProducto.Text = "";
                return;
            }
            else {
                //Si no hay codigo escogido en la 
                if (productoCodigo.Equals(""))
                {
                    MessageBox.Show("Primero es necesario escoger un producto");
                    return;
                }
                //MessageBox.Show("El producto no fue encontrado");
            }

        }

        //Agregar objeto al carrito
        public void AgregarProducto(int codigo, string nombre, decimal precio, int cantidad) {
            Carrito.Add(new ProductoVenta(codigo, nombre, precio, cantidad));
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProductos.Rows[e.RowIndex];
                tbxCodigoArticulo.Text = row.Cells["cod_producto"].Value.ToString();
                tbxNombreProducto.Text = row.Cells["nombre"].Value.ToString();
            }
            

            productoCodigo = tbxCodigoArticulo.Text;
        }

        private void dgvProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProductos.Rows[e.RowIndex];
                string producto = row.Cells["cod_producto"].Value.ToString();
                string nombre = row.Cells["nombre"].Value.ToString();
                productoCodigo = tbxCodigoArticulo.Text;
                tbxCodigoArticulo.Text = producto;
                tbxNombreProducto.Text = nombre;
            }
        }

        private void dtvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            subtotal = 0;
            descuento = 0;
            foreach (var producto in Carrito) {
                subtotal += producto.Total;
                descuento += producto.Descuento;

            }

            lblSubtotal.Text = "$" + subtotal.ToString("#.##");
            lblDescuento.Text = "$" + descuento.ToString("#.##");

            //Calcular el total
            lblTotal.Text = "$" + subtotal.ToString("#.##");

        }

        private void dtvCarrito_DataSourceChanged(object sender, EventArgs e)
        {
            subtotal = 0;
            descuento = 0;
            foreach (var producto in Carrito)
            {
                subtotal += producto.Total;
                descuento += producto.Descuento;

            }

            lblSubtotal.Text = "$" + subtotal.ToString("#.##");
            lblDescuento.Text = "$" + descuento.ToString();

            //Calcular el total
            lblTotal.Text = "$" + subtotal.ToString("#.##");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Checamos si el carrito esta vacio
            if (Carrito.Count == 0)
            {
                MessageBox.Show("No hay nada en el carrito");
            }
            else {
                var db = new ConexionDB();
                int recibo = db.CrearRecibo(Carrito, descuento, subtotal, subtotal);
                if (recibo != -1)
                {
                    MessageBox.Show("El recibo fue creado correctamente");
                    //Imprimimos 
                    var form2 = new FormTicket(recibo);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();




                    Carrito.Clear();
                    var bindingList = new BindingList<ProductoVenta>(Carrito);
                    var source = new BindingSource(bindingList, null);
                    dtvCarrito.DataSource = source;

                    lblSubtotal.Text = "$00.00";
                    lblDescuento.Text = "$00.00";

                    //Calcular el total
                    lblTotal.Text = "$00.00";

                }
                else {
                    MessageBox.Show("No fue posible crear el recibo");

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

/*
public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 500,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };
        Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
        NumericUpDown nud = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
        Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(nud);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? nud.Text : "";
    }
}
*/