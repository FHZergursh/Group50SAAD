using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SAADAdmin.Classes;
using SAADAdmin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SAADAdmin
{
    public partial class CreateNewAccount : Form
    {
        public CreateNewAccount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountManagement page = new AccountManagement();
            page.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((UsernameTextbox.TextLength == 0) || (PasswordTextbox.TextLength == 0))
            {
                MessageBox.Show("Please enter a value for all choices!");
            }
            else //If all 4 boxes filled
            {
                string usernameInput = UsernameTextbox.Text;
                string passwordInput = PasswordTextbox.Text;

                var database = new Database();
                database.connect_db();
                string query = "INSERT INTO users(username, password) VALUES('" + usernameInput + "', '" + passwordInput + "')";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = database.mysqlconn;
                try
                {
                    command.ExecuteReader();
                    MessageBox.Show("Command submitted, " + usernameInput + " has been added to the database!");
                    AccountManagement page = new AccountManagement();
                    page.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!");
                }

                database.closeDB();



            }

        }
    }
}
