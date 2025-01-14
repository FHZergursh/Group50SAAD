using MySql.Data.MySqlClient;
using SAADAdmin.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAADAdmin.Forms
{
    public partial class MediaManagement : Form
    {
        public MediaManagement()
        {
            InitializeComponent();
        }

        private void MediaManagement_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FillTable()
        {
            var database = new Database();
            database.connect_db();
            string query = "SELECT * FROM media";
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

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewMedia page = new CreateNewMedia();
            page.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage page = new HomePage();
            page.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMedia page = new DeleteMedia();
            page.Show();
            this.Hide();
        }
    }
}
