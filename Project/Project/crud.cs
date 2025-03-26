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
    
    public partial class crud : Form
    {
        public crud()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public int studentId;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-158TMOS\SQLEXPRESS;Initial Catalog=MySDTDB;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                String query = ("Insert INTO std_Info Values(@studentName, @fatherName, @sapID, @mobile, @city)");

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentName", textBox1.Text);
                cmd.Parameters.AddWithValue("@fatherName", textBox2.Text);
                cmd.Parameters.AddWithValue("@sapID", textBox3.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox4.Text);
                cmd.Parameters.AddWithValue("@city", comboBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student record successfully Entered!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetstudentRecord();
                clearFields();
            }
           
        }

        private bool isValid()
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("All Fields must be filled!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void crud_Load(object sender, EventArgs e)
        {
            GetstudentRecord();
        }

        private void GetstudentRecord()
        {
            String query = ("Select * From std_Info");

            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields(){
            studentId = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (studentId > 0)
            {
                String query = ("UPDATE std_Info SET studentName = @studentName, fatherName= @fatherName, sapID = @sapID, mobile = @mobile, city = @city WHERE studentID = @ID");

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentName", textBox1.Text);
                cmd.Parameters.AddWithValue("@fatherName", textBox2.Text);
                cmd.Parameters.AddWithValue("@sapID", textBox3.Text);
                cmd.Parameters.AddWithValue("@mobile", textBox4.Text);
                cmd.Parameters.AddWithValue("@city", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ID", this.studentId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student record successfully Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetstudentRecord();
                clearFields();
            }
            else 
            {
                MessageBox.Show("Select a student record to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (studentId > 0)
            {
                String query = ("DELETE FROM std_Info WHERE studentID = @ID");

                SqlCommand cmd = new SqlCommand(query, conn);
               
                cmd.Parameters.AddWithValue("@ID", this.studentId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student record successfully Deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetstudentRecord();
                clearFields();
            }

            else
            {
                MessageBox.Show("Select a student record to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
