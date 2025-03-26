using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-158TMOS\SQLEXPRESS;Initial Catalog=MySDTDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = ("Select * From login Where username = @username And password = @password");

            SqlDataAdapter sda = new SqlDataAdapter(query, conn);

            sda.SelectCommand.Parameters.AddWithValue("@username", textBox1.Text);
            sda.SelectCommand.Parameters.AddWithValue("@password", textBox2.Text);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                crud cd = new crud();
                cd.Show();

            }
            else
            {
                MessageBox.Show("Invalid username & password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            


        }
    }
}
