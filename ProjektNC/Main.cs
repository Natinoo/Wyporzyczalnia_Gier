using System;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    public partial class Main : Form
    {
        private int userId;
        private bool isAdmin;

        public Main()
        {
            InitializeComponent();
        }

        public Main(int userId, bool isAdmin)
        {
            InitializeComponent();
            this.userId = userId;
            this.isAdmin = isAdmin;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // logika wylogowania zajmuje się Program.cs
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnWypozyczGry_Click(object sender, EventArgs e)
        {
            using (WypozyczeniaForm wypForm = new WypozyczeniaForm(userId, isAdmin))
            {
                wypForm.ShowDialog();
            }
        }

        private void btnMojeGry_Click(object sender, EventArgs e)
        {
            using (MojeGry mojeGryForm = new MojeGry(userId))
            {
                mojeGryForm.ShowDialog();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }
    }
}
