using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPracticeApp
{
    public partial class UserLogin : Form
    {
        string connectionString = @"Data Source=dev_23; Initial Catalog=PracticeDb; Integrated Security=True;";
        string Email = "";
        string Password = "";
        public UserLogin()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Email = EmailInput.Text.Trim(); 
            Password = PassInput.Text.Trim();
            string query = "select * from Users where Email = '" + Email + "' and password = '" + Password + "';";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable user = new DataTable();
            sqlData.Fill(user);
            if(user.Rows.Count == 1)
            {
                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Something is Wrong!", "Login Failed!");
            }
        }

        private void SignupBtn_Click(object sender, EventArgs e)
        {
            UserSingUP singUp = new UserSingUP(); 
            this.Hide();
            singUp.Show();
        }
    }
}
