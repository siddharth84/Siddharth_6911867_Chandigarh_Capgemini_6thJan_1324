using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace WinformAppDemo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(
"Server=SIDDHARTH\\SQLEXPRESS;" +
"Database=Sidddb;" +
"Integrated Security=True;" +
"TrustServerCertificate=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employeetb", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SPEmp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PEmpId", Convert.ToInt32(txtEmpId.Text));
            cmd.Parameters.AddWithValue("@PEmpName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@PEmpDesig", txtEmpDesig.Text);
            cmd.Parameters.AddWithValue("@PEmpDOJ", Convert.ToDateTime(txtEmpDOJ.Text));
            cmd.Parameters.AddWithValue("@PEmpSal", Convert.ToInt32(txtEmpSal.Text));
            cmd.Parameters.AddWithValue("@PEmpDept", Convert.ToInt32(txtEmpDept.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
            MessageBox.Show("Record Inserted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SPEmp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PEmpId", Convert.ToInt32(txtEmpId.Text));
            cmd.Parameters.AddWithValue("@PEmpName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@PEmpDesig", txtEmpDesig.Text);
            cmd.Parameters.AddWithValue("@PEmpDOJ", Convert.ToDateTime(txtEmpDOJ.Text));
            cmd.Parameters.AddWithValue("@PEmpSal", Convert.ToInt32(txtEmpSal.Text));
            cmd.Parameters.AddWithValue("@PEmpDept", Convert.ToInt32(txtEmpDept.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
            MessageBox.Show("Record Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SPEmp_Del", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PEmpId", Convert.ToInt32(txtEmpId.Text));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
            MessageBox.Show("Record Deleted");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SPGetData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PEmpId", Convert.ToInt32(txtEmpId.Text));

            cmd.Parameters.Add("@PEmpName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PEmpDesig", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PEmpDOJ", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PEmpSal", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PEmpDept", SqlDbType.Int).Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            txtEmpName.Text = cmd.Parameters["@PEmpName"].Value.ToString();
            txtEmpDesig.Text = cmd.Parameters["@PEmpDesig"].Value.ToString();
            txtEmpDOJ.Text = cmd.Parameters["@PEmpDOJ"].Value.ToString();
            txtEmpSal.Text = cmd.Parameters["@PEmpSal"].Value.ToString();
            txtEmpDept.Text = cmd.Parameters["@PEmpDept"].Value.ToString();
        }
    }
}