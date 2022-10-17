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

namespace Expence_Manager
{
    public partial class ViewExpence : Form
    {
        public ViewExpence()
        {
            InitializeComponent();
            ViewExpenseData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewExpenseData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Expense Manager C# .NET Project\Expence Manager\Expence Manager\Database1.mdf"";Integrated Security=True");
            con.Open();
            String Query = "select ExpenseName,ExpenseAmount,ExpenseCatagory,ExpenseDate,ExpenseDesc from expenses where username=@username";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@username", Login.userName.ToString());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
