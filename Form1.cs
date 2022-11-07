using MAD.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MAD
{


    public partial class Form1 : Form
    {


        int type = 0;
        //Datos
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        int cajaGbl = -1;
        public Form1(string rol, string username, int caja)
        {
            InitializeComponent();
            random = new Random();
            btnCerrarChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            LoadOptions(rol, caja);
            lblUser.Text = username;
            lblFecha.Text = DateTime.Now.ToString("MMM dd yyyy,hh:mm");
            timer1.Start();
            cajaGbl = caja;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private Color SelectThemeColor()
        {
            int index = random.Next(Theme.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(Theme.ColorList.Count);
            }
            tempIndex = index;
            string color = Theme.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitulo.BackColor = color;
                    panelInfo.BackColor = Theme.ChangeColorBrightness(color, -0.3);
                    Theme.PrimaryColor = color;
                    Theme.SecondaryColor = Theme.ChangeColorBrightness(color, -0.3);
                    btnCerrarChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               
            }
        }

        private void OpenChildForm(Form childForm, object btnSender) {
            if (activeForm != null){
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelSeccion.Controls.Add(childForm);
            this.panelSeccion.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitulo.Text = childForm.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormVentas(), sender);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReportes(), sender);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset() {
            DisableButton();
            lblTitulo.Text = "Inicio";
            panelTitulo.BackColor = Color.FromArgb(0, 150, 136);
            panelInfo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCerrarChildForm.Visible = false;
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        //Funcion que muestra las opciones disponibles dependiendo del rol del usuario
        private void LoadOptions(string rol, int caja) {
            if (rol.Equals("admin"))
            {
                iconButton1.Visible = false;
                iconButton2.Visible = false;
                lblCaja.Visible = false;

            }
            else if (rol.Equals("caja"))
            {
                iconButton3.Visible = false;
                iconButton4.Visible = false;
                iconButton5.Visible = false;
                iconButton7.Visible = false;
                iconButton8.Visible = false;
                iconButton9.Visible = false;
                iconButton10.Visible = false;
                iconButton11.Visible = false;
                iconButton12.Visible = false;
                iconButton13.Visible = false;
                lblCaja.Text = "Caja: " + caja.ToString();
            }
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormCajas(lblUser.Text), sender);
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormCajero(lblUser.Text), sender);
        }

        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormConsultaRecibos(), sender);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormDepartamento(lblUser.Text), sender);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormDevolucion(), sender);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormInventario(), sender);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormProducto(lblUser.Text), sender);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormReporteCajero(), sender);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormsAdmin.FormReporteVenta(), sender);
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            //Regresar al login
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        //Funcion para mostrar la hora y fecha
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("MMM dd yyyy,hh:mm");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cajaGbl != -1) {
                var db = new ConexionDB();
                db.LiberarCaja(cajaGbl);
            }
        }
    }
}
