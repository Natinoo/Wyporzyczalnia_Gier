namespace Wyporzyczalnia_Gier
{
    partial class DodajGreForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTytul = new System.Windows.Forms.Label();
            this.txtTytul = new System.Windows.Forms.TextBox();
            this.lblProducent = new System.Windows.Forms.Label();
            this.txtProducent = new System.Windows.Forms.TextBox();
            this.lblRokWydania = new System.Windows.Forms.Label();
            this.txtRokWydania = new System.Windows.Forms.TextBox();
            this.lblPlatforma = new System.Windows.Forms.Label();
            this.txtPlatforma = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTytul
            // 
            this.lblTytul.AutoSize = true;
            this.lblTytul.Location = new System.Drawing.Point(20, 20);
            this.lblTytul.Name = "lblTytul";
            this.lblTytul.Size = new System.Drawing.Size(35, 13);
            this.lblTytul.TabIndex = 0;
            this.lblTytul.Text = "Tytuł:";
            // 
            // txtTytul
            // 
            this.txtTytul.Location = new System.Drawing.Point(120, 17);
            this.txtTytul.Name = "txtTytul";
            this.txtTytul.Size = new System.Drawing.Size(200, 20);
            this.txtTytul.TabIndex = 1;
            // 
            // lblProducent
            // 
            this.lblProducent.AutoSize = true;
            this.lblProducent.Location = new System.Drawing.Point(20, 50);
            this.lblProducent.Name = "lblProducent";
            this.lblProducent.Size = new System.Drawing.Size(59, 13);
            this.lblProducent.TabIndex = 2;
            this.lblProducent.Text = "Producent:";
            // 
            // txtProducent
            // 
            this.txtProducent.Location = new System.Drawing.Point(120, 47);
            this.txtProducent.Name = "txtProducent";
            this.txtProducent.Size = new System.Drawing.Size(200, 20);
            this.txtProducent.TabIndex = 3;
            // 
            // lblRokWydania
            // 
            this.lblRokWydania.AutoSize = true;
            this.lblRokWydania.Location = new System.Drawing.Point(20, 80);
            this.lblRokWydania.Name = "lblRokWydania";
            this.lblRokWydania.Size = new System.Drawing.Size(72, 13);
            this.lblRokWydania.TabIndex = 4;
            this.lblRokWydania.Text = "Rok wydania:";
            // 
            // txtRokWydania
            // 
            this.txtRokWydania.Location = new System.Drawing.Point(120, 77);
            this.txtRokWydania.Name = "txtRokWydania";
            this.txtRokWydania.Size = new System.Drawing.Size(200, 20);
            this.txtRokWydania.TabIndex = 5;
            // 
            // lblPlatforma
            // 
            this.lblPlatforma.AutoSize = true;
            this.lblPlatforma.Location = new System.Drawing.Point(20, 110);
            this.lblPlatforma.Name = "lblPlatforma";
            this.lblPlatforma.Size = new System.Drawing.Size(54, 13);
            this.lblPlatforma.TabIndex = 6;
            this.lblPlatforma.Text = "Platforma:";
            // 
            // txtPlatforma
            // 
            this.txtPlatforma.Location = new System.Drawing.Point(120, 107);
            this.txtPlatforma.Name = "txtPlatforma";
            this.txtPlatforma.Size = new System.Drawing.Size(200, 20);
            this.txtPlatforma.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Dodaj";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(220, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DodajGreForm
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(350, 210);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPlatforma);
            this.Controls.Add(this.lblPlatforma);
            this.Controls.Add(this.txtRokWydania);
            this.Controls.Add(this.lblRokWydania);
            this.Controls.Add(this.txtProducent);
            this.Controls.Add(this.lblProducent);
            this.Controls.Add(this.txtTytul);
            this.Controls.Add(this.lblTytul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DodajGreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodaj nową grę";
            this.Load += new System.EventHandler(this.DodajGreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTytul;
        private System.Windows.Forms.TextBox txtTytul;
        private System.Windows.Forms.Label lblProducent;
        private System.Windows.Forms.TextBox txtProducent;
        private System.Windows.Forms.Label lblRokWydania;
        private System.Windows.Forms.TextBox txtRokWydania;
        private System.Windows.Forms.Label lblPlatforma;
        private System.Windows.Forms.TextBox txtPlatforma;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
