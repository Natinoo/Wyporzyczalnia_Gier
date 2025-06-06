namespace Wyporzyczalnia_Gier
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWypozyczGry;
        private System.Windows.Forms.Button btnMojeGry;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnWypozyczGry = new System.Windows.Forms.Button();
            this.btnMojeGry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(208, 304);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 30);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Wyloguj";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(334, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 30);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Wyjście";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnWypozyczGry
            // 
            this.btnWypozyczGry.Location = new System.Drawing.Point(65, 105);
            this.btnWypozyczGry.Name = "btnWypozyczGry";
            this.btnWypozyczGry.Size = new System.Drawing.Size(143, 44);
            this.btnWypozyczGry.TabIndex = 2;
            this.btnWypozyczGry.Text = "Wypożycz gry";
            this.btnWypozyczGry.UseVisualStyleBackColor = true;
            this.btnWypozyczGry.Click += new System.EventHandler(this.btnWypozyczGry_Click);
            // 
            // btnMojeGry
            // 
            this.btnMojeGry.Location = new System.Drawing.Point(257, 105);
            this.btnMojeGry.Name = "btnMojeGry";
            this.btnMojeGry.Size = new System.Drawing.Size(143, 44);
            this.btnMojeGry.TabIndex = 3;
            this.btnMojeGry.Text = "Moje gry";
            this.btnMojeGry.Click += new System.EventHandler(this.btnMojeGry_Click);
            // 
            // Main
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(466, 346);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWypozyczGry);
            this.Controls.Add(this.btnMojeGry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel główny";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }
    }
}
