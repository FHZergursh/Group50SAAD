using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SAADAdmin.Classes;
using SAADAdmin.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SAADAdmin
{
    public partial class CreateNewMedia : Form
    {
        public CreateNewMedia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((NameTextBox.TextLength == 0) || (TypeTextBox.TextLength == 0) || (DescriptionTextBox.TextLength == 0) || (StockTextBox.TextLength == 0)) 
            {
                MessageBox.Show("Please enter a value for all choices!");
            }
            else //If all 4 boxes filled
            {
                string nameInput = NameTextBox.Text;
                string typeInput = TypeTextBox.Text;
                string descriptionInput = DescriptionTextBox.Text;
                string stockInput = StockTextBox.Text;

                var database = new Database();
                database.connect_db();
                string query = "INSERT INTO media(name, type, description, stock) VALUES ('" + nameInput + "', '" + typeInput + "', '" + descriptionInput + "', '" + stockInput + "')";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = database.mysqlconn;
                try
                {
                    command.ExecuteReader();
                    MessageBox.Show("Command submitted, " + nameInput + " has been added to the database!");
                    MediaManagement page = new MediaManagement();
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

        private void button2_Click(object sender, EventArgs e)
        {
            MediaManagement page = new MediaManagement();
            page.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void StockTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TypeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
