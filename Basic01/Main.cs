using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Basic01
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand sda = new SqlCommand("Select * From SavedData where UserID='" + Open.name + "'", con);
            SqlDataReader reader = sda.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Username"].ToString());
                listBox2.Items.Add(reader["Password"].ToString());
            }
            con.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var Add = new Add();
            Add.ShowDialog();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand sda = new SqlCommand("Select * From SavedData where UserID='" + Open.name + "'", con);
            SqlDataReader reader = sda.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Username"].ToString());
                listBox2.Items.Add(reader["Password"].ToString());
            }
            con.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand sda = new SqlCommand("Select * From SavedData where UserID='" + Open.name + "'", con);
            SqlDataReader reader = sda.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["Username"].ToString());
                listBox2.Items.Add(reader["Password"].ToString());
            }
            con.Close();
        }
    }
}
