using MySql.Data.MySqlClient;
using SAADAdmin.Classes;
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

namespace SAADAdmin.Forms
{
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void FillTable() //Populate the table with data. Run this when an update is needed (auto runs at start)
        {
            var database = new Database();
            database.connect_db();
            string query = "SELECT * FROM users";
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = database.mysqlconn;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            BindingSource binding = new BindingSource();
            binding.DataSource = dt;

            dataTable.DataSource = binding;

            database.closeDB();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage page = new HomePage();
            page.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAccount page = new DeleteAccount();
            page.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewAccount page = new CreateNewAccount();
            page.Show();
            this.Hide();
        }
    }
}
