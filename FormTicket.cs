using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.IO;
using Spire.PdfViewer.Forms;

namespace MAD
{
    public partial class FormTicket : Form
    {
        public FormTicket(int numeroTicket, int tipo)
        {
            InitializeComponent();
            string workingDirectory = Environment.CurrentDirectory;
            string pdfDoc = "";
            if (tipo == 0)
            {
                pdfDoc = workingDirectory + @"\" + numeroTicket + ".pdf";
            }
            else if (tipo == 1)
            {
                pdfDoc = workingDirectory + @"\" + "nota" + numeroTicket + ".pdf";
            }
          
           if (File.Exists(pdfDoc))
               
           {
               
               this.pdfDocumentViewer1.LoadFromFile(pdfDoc);
                
           }


        }

        private void FormTicket_Load(object sender, EventArgs e)
        {
        }

        private void pdfViewer1_Click(object sender, EventArgs e)
        {

        }

        private void FormTicket_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
