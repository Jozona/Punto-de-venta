using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAD.Forms
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
