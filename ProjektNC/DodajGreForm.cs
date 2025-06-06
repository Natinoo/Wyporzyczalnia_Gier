using System;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class DodajGreForm : Form
    {
        private Database db = new Database();

        public string Tytul { get; private set; }
        public string Producent { get; private set; }
        public int RokWydania { get; private set; }
        public string Platforma { get; private set; }
        public bool Dostepnosc { get; private set; } = true; // domyślnie dostępna

        public DodajGreForm()
        {
            InitializeComponent();
            this.btnOK.Text = "Dodaj";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (!IsTitleUnique(txtTytul.Text))
            {
                MessageBox.Show("Gra o podanym tytule już istnieje!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Tytul = txtTytul.Text;
            this.Producent = txtProducent.Text;
            this.RokWydania = int.Parse(txtRokWydania.Text);
            this.Platforma = txtPlatforma.Text;
            this.Dostepnosc = true; // zawsze dostępna

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsTitleUnique(string title)
        {
            string query = $"SELECT COUNT(*) FROM gry WHERE tytul = '{title}'";
            object result = db.ExecuteScalar(query);
            return Convert.ToInt32(result) == 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTytul.Text))
            {
                MessageBox.Show("Tytuł gry jest wymagany!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProducent.Text))
            {
                MessageBox.Show("Producent jest wymagany!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtRokWydania.Text, out int rok) || rok < 1950 || rok > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Podaj poprawny rok wydania!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPlatforma.Text))
            {
                MessageBox.Show("Platforma jest wymagana!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void DodajGreForm_Load(object sender, EventArgs e)
        {
        }
    }
}
