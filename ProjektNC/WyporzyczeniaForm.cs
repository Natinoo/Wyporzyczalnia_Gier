using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class WypozyczeniaForm : Form
    {
        private int userId;
        private bool isAdmin;
        private Database db = new Database();
        private DataView gameDataView;
        private Label lblDebt; // Dodana deklaracja etykiety

        public WypozyczeniaForm(int userId, bool isAdmin)
        {
            this.userId = userId;
            this.isAdmin = isAdmin;
            InitializeComponent();
            InitializeDebtLabel(); // Dodana inicjalizacja etykiety
            SetupAdminControls();
            LoadAvailableGames();
            ConfigureSearchBox();
            LoadUserDebt(); // Dodane ładowanie danych o zaległościach
        }

        private void InitializeDebtLabel()
        {
            lblDebt = new Label();
            lblDebt.Location = new Point(20, 20);
            lblDebt.Size = new Size(300, 20);
            lblDebt.Text = "Twoje zaległości: ...";
            this.Controls.Add(lblDebt);
        }

        private void ConfigureSearchBox()
        {
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = "Szukaj po tytule...";

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Szukaj po tytule...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = SystemColors.WindowText;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Szukaj po tytule...";
                    txtSearch.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void SetupAdminControls()
        {
            if (isAdmin)
            {
                Button btnAddGame = new Button();
                btnAddGame.Text = "Dodaj grę";
                btnAddGame.Location = new Point(260, 430);
                btnAddGame.Size = new Size(100, 30);
                btnAddGame.BackColor = Color.FromArgb(0, 123, 255);
                btnAddGame.ForeColor = Color.White;
                btnAddGame.FlatStyle = FlatStyle.Flat;
                btnAddGame.Click += BtnAddGame_Click;
                this.Controls.Add(btnAddGame);

                Button btnDeleteGame = new Button();
                btnDeleteGame.Text = "Usuń grę";
                btnDeleteGame.Location = new Point(380, 430);
                btnDeleteGame.Size = new Size(100, 30);
                btnDeleteGame.BackColor = Color.FromArgb(220, 53, 69);
                btnDeleteGame.ForeColor = Color.White;
                btnDeleteGame.FlatStyle = FlatStyle.Flat;
                btnDeleteGame.Click += BtnDeleteGame_Click;
                this.Controls.Add(btnDeleteGame);
            }
        }

        private void LoadAvailableGames()
        {
            try
            {
                string query = "SELECT id, tytul, producent, rok_wydania, platforma, dostepnosc FROM gry WHERE dostepnosc > 0";
                DataTable result = db.Query(query);
                gameDataView = new DataView(result);
                dgvGames.DataSource = gameDataView;
                FormatDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd podczas ładowania gier", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGrid()
        {
            dgvGames.Columns["id"].Visible = false;
            dgvGames.Columns["tytul"].HeaderText = "Tytuł";
            dgvGames.Columns["producent"].HeaderText = "Producent";
            dgvGames.Columns["platforma"].HeaderText = "Platforma";
            dgvGames.Columns["rok_wydania"].HeaderText = "Rok wydania";
            dgvGames.Columns["dostepnosc"].HeaderText = "Dostępność";

            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGames.Columns["rok_wydania"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGames.Columns["dostepnosc"].DefaultCellStyle.NullValue = "☑";
            dgvGames.Columns["dostepnosc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Szukaj po tytule..." || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                gameDataView.RowFilter = "";
                return;
            }

            try
            {
                string filterText = txtSearch.Text.Replace("'", "''");
                gameDataView.RowFilter = $"tytul LIKE '%{filterText}%'";
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd wyszukiwania", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvGames.SelectedRows.Count == 0) return;

            try
            {
                foreach (DataGridViewRow row in dgvGames.SelectedRows)
                {
                    int gameId = Convert.ToInt32(row.Cells["id"].Value);

                    string rentQuery = $@"
                    INSERT INTO wypozyczenia (id_gry, id_uzytkownika, data_wypozyczenia, planowana_data_zwrotu)
                    VALUES ({gameId}, {userId}, NOW(), DATE_ADD(NOW(), INTERVAL 28 DAY))";

                    string updateQuery = $"UPDATE gry SET dostepnosc = FALSE WHERE id = {gameId}";

                    db.Execute(rentQuery);
                    db.Execute(updateQuery);
                }

                MessageBox.Show("Gry zostały wypożyczone!", "Sukces",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAvailableGames();
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd podczas wypożyczania", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            using (DodajGreForm dodajGreForm = new DodajGreForm())
            {
                if (dodajGreForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string query = $@"
                        INSERT INTO gry (tytul, producent, rok_wydania, platforma, dostepnosc)
                        VALUES ('{dodajGreForm.Tytul}', '{dodajGreForm.Producent}', 
                                {dodajGreForm.RokWydania}, '{dodajGreForm.Platforma}', 
                                {(dodajGreForm.Dostepnosc ? 1 : 0)})";

                        db.Execute(query);
                        LoadAvailableGames();
                        MessageBox.Show("Gra została dodana pomyślnie!", "Sukces",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd podczas dodawania gry", "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDeleteGame_Click(object sender, EventArgs e)
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać grę do usunięcia", "Informacja",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = Convert.ToInt32(dgvGames.SelectedRows[0].Cells["id"].Value);
            string gameTitle = dgvGames.SelectedRows[0].Cells["tytul"].Value.ToString();

            if (MessageBox.Show($"Czy na pewno chcesz usunąć grę: {gameTitle}?", "Potwierdzenie",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string checkQuery = $"SELECT COUNT(*) FROM wypozyczenia WHERE id_gry = {gameId} AND data_zwrotu IS NULL";
                    object result = db.ExecuteScalar(checkQuery);
                    int activeRentals = Convert.ToInt32(result);

                    if (activeRentals > 0)
                    {
                        MessageBox.Show("Nie można usunąć gry, która jest aktualnie wypożyczona!", "Błąd",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string deleteQuery = $"DELETE FROM gry WHERE id = {gameId}";
                    db.Execute(deleteQuery);

                    MessageBox.Show("Gra została usunięta pomyślnie!", "Sukces",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAvailableGames();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd podczas usuwania gry", "Błąd",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadUserDebt()
        {
            try
            {
                string query = $"SELECT zaleglosci FROM uzytkownicy WHERE id = {userId}";
                object result = db.ExecuteScalar(query);

                if (result == null || result == DBNull.Value)
                {
                    lblDebt.Text = "Brak danych o zaległościach";
                    return;
                }

                decimal debt = Convert.ToDecimal(result);
                lblDebt.Text = $"Twoje zaległości: {debt:0.00} zł";
            }
            catch (Exception)
            {
                lblDebt.Text = "Nie udało się pobrać zaległości";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WypozyczeniaForm_Load(object sender, EventArgs e)
        {
        }
    }
}