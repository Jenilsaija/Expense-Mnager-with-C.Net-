using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Collections;
using Microsoft.VisualBasic;
using System.Windows.Forms.VisualStyles;

namespace Expence_Manager
{
    public partial class Login : Form
    {
        public static string userName;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbusername.Text.Trim() == "" || tbpass.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Up All Details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Expense Manager C# .NET Project\Expence Manager\Expence Manager\Database1.mdf"";Integrated Security=True");
                con.Open();
                string query = "select * from users";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                int Count = 0;
                while (dr.Read())
                {
                    if (dr["username"].ToString() == tbusername.Text.Trim() && dr["Password"].ToString() == tbpass.Text.ToString())
                    {
                        userName = dr["username"].ToString();
                        DashBoard dash = new DashBoard();
                        this.Hide();
                        dash.Show();
                        Count++;
                    }
                }
                if (Count == 0)
                {
                    MessageBox.Show("Username and Password Invalid");
                    userName = "";
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbusername.Text.Trim() == "" || tbpass.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Up All Details");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Expense Manager C# .NET Project\Expence Manager\Expence Manager\Database1.mdf"";Integrated Security=True");
                con.Open();
                String Query = "Insert into users(username,Password) values(@username,@Password)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@username", tbusername.Text);
                cmd.Parameters.AddWithValue("@Password", tbpass.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Added Successfully. Now you Login ");
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
