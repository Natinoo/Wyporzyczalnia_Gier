using System;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class RegistrationForm : Form
    {
        private Database db = new Database();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string passwordConfirm = txtPasswordConfirm.Text;

            if (login == "" || email == "" || password == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != passwordConfirm)
            {
                MessageBox.Show("Hasła nie są zgodne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = $"INSERT INTO uzytkownicy (login, email, haslo) VALUES ('{login}', '{email}', SHA2('{password}', 256))";
                int rows = db.Execute(sql);
                if (rows > 0)
                {
                    MessageBox.Show("Rejestracja zakończona sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie udało się zarejestrować.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
