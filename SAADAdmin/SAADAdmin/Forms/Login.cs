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
using MySql.Data.MySqlClient;
using SAADAdmin.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SAADAdmin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if ((usernameBox.TextLength == 0) || (passwordBox.TextLength == 0))
            {
                MessageBox.Show("Please enter your username and password.");
            }
            else
            {
                string username = usernameBox.Text;
                string password = passwordBox.Text;

                Database db = new Database();
                db.connect_db();
                string query = "SELECT * FROM admins WHERE username = '" + username + "' AND password = '" + password + "'";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = db.mysqlconn;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt); 


                if (dt.Rows.Count == 0) //Fills a data table, if nothing goes in then it's empty and login fails. There's probably a more direct way to do this, but this works
                {
                    MessageBox.Show("Account not found.");
                }
                else
                {
                    MessageBox.Show("Login successful!");
                    HomePage page = new HomePage();
                    page.Show();
                    this.Hide();
                }


            }


        }

        private void button2_Click(object sender, EventArgs e) //Test SQL connection, mainly for debug purposes
        {
            try 
            {
                string connstring = "server=localhost;uid=root;pwd=root123;database=saad";
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                string sql = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show("ID " + reader["id"] + " Username " + reader["username"] + " Password " + reader["password"]);
                    
                }
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
