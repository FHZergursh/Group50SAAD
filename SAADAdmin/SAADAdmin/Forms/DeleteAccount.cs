using MySql.Data.MySqlClient;
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

namespace SAADAdmin
{
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
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
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Please enter a value for all choices!");
            }
            else //If all 4 boxes filled
            {
                string idInput = textBox1.Text;


                var database = new Database();
                database.connect_db();
                string query = " DELETE FROM users WHERE id = " + idInput + "";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = database.mysqlconn;
                try
                {
                    command.ExecuteReader();
                    MessageBox.Show("Account deleted!");
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

