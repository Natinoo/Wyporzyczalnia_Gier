using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class MojeGry : Form
    {
        private int userId;
        private Database db = new Database();

        public MojeGry(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            ConfigureDataGridView();
            LoadRentedGames();
            LoadUserDebt();
        }

        private void ConfigureDataGridView()
        {
            dgvRentedGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentedGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentedGames.MultiSelect = true;
            dgvRentedGames.AllowUserToAddRows = false;
            dgvRentedGames.ReadOnly = true;
            dgvRentedGames.RowHeadersVisible = false;
        }

        private void LoadRentedGames()
        {
            try
            {
                string query = $@"
                SELECT w.id, g.tytul, g.producent, g.platforma, 
                       DATE_FORMAT(w.data_wypozyczenia, '%Y-%m-%d') as data_wypozyczenia,
                       DATE_FORMAT(w.planowana_data_zwrotu, '%Y-%m-%d') as planowana_data_zwrotu
                FROM wypozyczenia w
                JOIN gry g ON w.id_gry = g.id
                WHERE w.id_uzytkownika = {userId} AND w.data_zwrotu IS NULL";

                DataTable result = db.Query(query);

                dgvRentedGames.DataSource = result;
                FormatDataGrid();

                lblMessage.Visible = result.Rows.Count == 0;
                dgvRentedGames.Visible = result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania gier: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGrid()
        {
            dgvRentedGames.Columns["id"].Visible = false;
            dgvRentedGames.Columns["tytul"].HeaderText = "Tytuł";
            dgvRentedGames.Columns["producent"].HeaderText = "Producent";
            dgvRentedGames.Columns["platforma"].HeaderText = "Platforma";
            dgvRentedGames.Columns["data_wypozyczenia"].HeaderText = "Data wypożyczenia";
            dgvRentedGames.Columns["planowana_data_zwrotu"].HeaderText = "Planowany zwrot";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvRentedGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać gry do zwrotu", "Informacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedGames = dgvRentedGames.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => Convert.ToInt32(row.Cells["id"].Value))
                .ToList();

            if (MessageBox.Show($"Czy na pewno chcesz zwrócić {selectedGames.Count} gry?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReturnGames(selectedGames);
            }
        }

        private void ReturnGames(List<int> rentalIds)
        {
            try
            {
                decimal totalPenalty = 0;

                foreach (int rentalId in rentalIds)
                {
                    string dateQuery = $"SELECT DATEDIFF(NOW(), planowana_data_zwrotu) FROM wypozyczenia WHERE id = {rentalId}";
                    object daysLateObj = db.ExecuteScalar(dateQuery);
                    int daysLate = daysLateObj != null ? Convert.ToInt32(daysLateObj) : 0;

                    decimal penalty = daysLate > 0 ? daysLate * 1m : 0m;
                    totalPenalty += penalty;

                    string updateRental = $"UPDATE wypozyczenia SET data_zwrotu = NOW() WHERE id = {rentalId}";
                    string updateGame = $"UPDATE gry g JOIN wypozyczenia w ON g.id = w.id_gry SET g.dostepnosc = TRUE WHERE w.id = {rentalId}";

                    db.Execute(updateRental);
                    db.Execute(updateGame);
                }

                if (totalPenalty > 0)
                {
                    string updateDebt = $"UPDATE uzytkownicy SET zaleglosci = zaleglosci + {totalPenalty} WHERE id = {userId}";
                    db.Execute(updateDebt);
                }

                string message = rentalIds.Count > 1
                    ? $"Zwrócono {rentalIds.Count} gry! Opłata za zwłokę: {totalPenalty:0.00} zł"
                    : $"Gra została zwrócona! Opłata za zwłokę: {totalPenalty:0.00} zł";

                MessageBox.Show(message, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRentedGames();
                LoadUserDebt();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zwrotu gier: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserDebt()
        {
            try
            {
                string query = $"SELECT zaleglosci FROM uzytkownicy WHERE id = {userId}";
                object result = db.ExecuteScalar(query);
                decimal debt = result != null ? Convert.ToDecimal(result) : 0;
                lblDebt.Text = $"Twoje zaległości: {debt:0.00} zł";
            }
            catch (Exception)
            {
                lblDebt.Text = "Błąd przy pobieraniu zaległości";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRentedGames_SelectionChanged(object sender, EventArgs e)
        {
            btnReturn.Enabled = dgvRentedGames.SelectedRows.Count > 0;
        }
    }
}