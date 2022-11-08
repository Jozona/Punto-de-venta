
namespace MAD
{
    partial class FormTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pdfDocumentViewer1 = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.SuspendLayout();
            // 
            // pdfDocumentViewer1
            // 
            this.pdfDocumentViewer1.AutoScroll = true;
            this.pdfDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfDocumentViewer1.FormFillEnabled = false;
            this.pdfDocumentViewer1.Location = new System.Drawing.Point(12, 12);
            this.pdfDocumentViewer1.MultiPagesThreshold = 60;
            this.pdfDocumentViewer1.Name = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.OnRenderPageExceptionEvent = null;
            this.pdfDocumentViewer1.PageLayoutMode = Spire.PdfViewer.Forms.PageLayoutMode.SinglePageContinuous;
            this.pdfDocumentViewer1.Size = new System.Drawing.Size(776, 426);
            this.pdfDocumentViewer1.TabIndex = 0;
            this.pdfDocumentViewer1.Text = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Threshold = 60;
            this.pdfDocumentViewer1.ViewerMode = Spire.PdfViewer.Forms.PdfViewerMode.PdfViewerMode.MultiPage;
            this.pdfDocumentViewer1.ZoomFactor = 1F;
            this.pdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // FormTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pdfDocumentViewer1);
            this.Name = "FormTicket";
            this.Text = "FormTicket";
            this.Load += new System.EventHandler(this.FormTicket_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocumentViewer1;
    }
}