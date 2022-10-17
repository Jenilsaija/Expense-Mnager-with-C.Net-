using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expence_Manager
{
    public partial class Reports : Form
    {

        public Reports()
        {
            InitializeComponent();
            int max = featchdata("Select Max(ExpenseAmount) As val from expenses");
            label2.Text = max.ToString();
            int min = featchdata("Select Min(ExpenseAmount) As val from expenses");
            label3.Text = min.ToString();
            int total = featchdata("Select Sum(ExpenseAmount) As val from expenses");
            label8.Text= total.ToString();
            int Avg = featchdata("Select Avg(ExpenseAmount) As val from expenses");
            label5.Text = Avg.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public int featchdata(String query)
        {
            int res=0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Expense Manager C# .NET Project\Expence Manager\Expence Manager\Database1.mdf"";Integrated Security=True");
            con.Open();
            String Query = query + " Where username=@username";
            SqlCommand cmd = new SqlCommand(Query, con);
            String uname = Login.userName.ToString();
            cmd.Parameters.AddWithValue("@username", uname);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader(); 
            if (dr.Read())
            {
                res = Convert.ToInt32(dr["val"].ToString());
            }
            con.Close();
            return res;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
