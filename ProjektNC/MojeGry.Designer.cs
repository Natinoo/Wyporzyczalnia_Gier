using System.Drawing;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    partial class MojeGry
    {
        private System.ComponentModel.IContainer components = null;

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
            this.dgvRentedGames = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblDebt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentedGames)).BeginInit();
            this.SuspendLayout();

            // dgvRentedGames
            this.dgvRentedGames.AllowUserToAddRows = false;
            this.dgvRentedGames.AllowUserToDeleteRows = false;
            this.dgvRentedGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentedGames.BackgroundColor = System.Drawing.Color.White;
            this.dgvRentedGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRentedGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentedGames.Location = new System.Drawing.Point(20, 36);
            this.dgvRentedGames.MultiSelect = false;
            this.dgvRentedGames.Name = "dgvRentedGames";
            this.dgvRentedGames.ReadOnly = true;
            this.dgvRentedGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentedGames.Size = new System.Drawing.Size(640, 350);
            this.dgvRentedGames.TabIndex = 0;
            this.dgvRentedGames.SelectionChanged += new System.EventHandler(this.dgvRentedGames_SelectionChanged);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(454, 410);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Powrót";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // btnReturn
            this.btnReturn.Enabled = false;
            this.btnReturn.Location = new System.Drawing.Point(560, 410);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Zwróć grę";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // lblMessage
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblMessage.Location = new System.Drawing.Point(20, 200);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(640, 50);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Nie masz obecnie wypożyczonych żadnych gier";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;

            // lblDebt
            this.lblDebt.AutoSize = true;
            this.lblDebt.Location = new System.Drawing.Point(17, 419);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Size = new System.Drawing.Size(90, 13);
            this.lblDebt.TabIndex = 4;
            this.lblDebt.Text = "Twoje zaległości:";

            // MojeGry
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 450);
            this.Controls.Add(this.lblDebt);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvRentedGames);
            this.Name = "MojeGry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moje wypożyczone gry";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentedGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvRentedGames;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblDebt;
    }
}