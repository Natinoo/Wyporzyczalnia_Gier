using System;
using System.Windows.Forms;

namespace Wyporzyczalnia_Gier
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    var result = loginForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Application.Run(new Main(loginForm.UserId, loginForm.IsAdmin));
                    }
                    else
                    {
                        break; 
                    }
                }
            }
        }
    }
}
