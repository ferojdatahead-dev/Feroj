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
    public partial class UserSingUP : Form
    {
        string connectionString = @"Data Source=dev_23; Initial Catalog=PracticeDb; Integrated Security=True;";
        public UserSingUP()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(emailInput.Text == "" || passInput.Text == "" || cPassInput.Text == "")
            {
                MessageBox.Show("Some required Data is missing!", "Error!");
            }else if (passInput.Text != cPassInput.Text)
            {
                MessageBox.Show("Password and Confirm Password must be same!", "Invalid Input!");
            }
            else
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("AddUser", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", nameInput.Text);
                    cmd.Parameters.AddWithValue("@Mobile", mobileInput.Text);
                    cmd.Parameters.AddWithValue("@Address", addressInput.Text);
                    cmd.Parameters.AddWithValue("@Email", emailInput.Text);
                    cmd.Parameters.AddWithValue("@Password", passInput.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Congratulations {nameInput.Text}!!\n" +
                        $"Registration is successful.\n", "Success");
                }
                UserLogin logIn = new UserLogin();
                this.Hide();
                logIn.Show();
            }
        }
        private void clear()
        {
            nameInput.Text = mobileInput.Text = addressInput.Text = emailInput.Text = passInput.Text = cPassInput.Text = "";
        }
    }
}
