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
    public partial class Add : Form
    {
        string useridd;
        
        
        private void Add_Load(object sender, EventArgs e)
        {
        }
        public Add()
        {
            InitializeComponent();
            textBox3.Text = Open.name;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            useridd = Open.name;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From SavedData where UserID='" + useridd + "' and Username='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("This data is already stored!");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into SavedData values (@UserID, @Username, @Password)", con);
                con.Open();
                cmd.Parameters.AddWithValue("UserID", useridd);
                cmd.Parameters.AddWithValue("Username", textBox1.Text);
                cmd.Parameters.AddWithValue("Password", textBox2.Text);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Data Added");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load_1(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
