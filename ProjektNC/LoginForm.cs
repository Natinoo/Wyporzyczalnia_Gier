using System;
using System.Drawing;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class LoginForm : Form
    {
        private readonly Database db = new Database();

        public int UserId { get; private set; }
        public bool IsAdmin { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            ApplyStyles();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Logowanie do systemu";
        }

        private void ApplyStyles()
        {
            this.ClientSize = new Size(400, 250);
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblLogin.Location = new Point(50, 40);
            txtLogin.Location = new Point(150, 37);
            txtLogin.Size = new Size(200, 25);

            lblPassword.Location = new Point(50, 80);
            txtPassword.Location = new Point(150, 77);
            txtPassword.Size = new Size(200, 25);

            btnLogin.Location = new Point(150, 130);
            btnLogin.Size = new Size(100, 35);

            btnRegister.Location = new Point(50, 180);
            btnRegister.Size = new Size(120, 35);

            btnExit.Location = new Point(230, 180);
            btnExit.Size = new Size(120, 35);

            txtPassword.PasswordChar = '•';

            btnLogin.BackColor = Color.FromArgb(0, 123, 255);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
            btnRegister.ForeColor = Color.FromArgb(0, 123, 255);

            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(108, 117, 125);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Proszę wprowadzić login i hasło", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int userId;
                bool isAdmin;

                if (db.LoginUser(login, password, out userId, out isAdmin))
                {
                    this.UserId = userId;
                    this.IsAdmin = isAdmin;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Błędny login lub hasło", "Błąd logowania",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            regForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
    }
}
