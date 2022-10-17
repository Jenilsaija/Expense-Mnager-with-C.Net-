using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
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


namespace Expence_Manager
{
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (Exname.Text.Trim() == "" || exAmount.Text.Trim() == "" || comboBox1.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || exDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill Up All Details");
            }
            else
            {
                this.Hide();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Expense Manager C# .NET Project\Expence Manager\Expence Manager\Database1.mdf"";Integrated Security=True");
                con.Open();
                String Query = "Insert into expenses(username,ExpenseName,ExpenseAmount,ExpenseCatagory,ExpenseDate,ExpenseDesc) Values(@username,@ExpenseName,@ExpenseAmount,@ExpenseCatagory,@ExpenseDate,@ExpenseDesc)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@username", Login.userName.ToString());
                cmd.Parameters.AddWithValue("@ExpenseName", Exname.Text);
                cmd.Parameters.AddWithValue("@ExpenseAmount", exAmount.Text);
                cmd.Parameters.AddWithValue("@ExpenseCatagory", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ExpenseDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@ExpenseDesc", exDesc.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add Expence Successfully");
                con.Close();
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
