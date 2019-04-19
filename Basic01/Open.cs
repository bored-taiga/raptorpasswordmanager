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

    public partial class Open : Form
    {
        public static string name;
        
        public Open()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Users where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                name = textBox1.Text;
                var Main = new Main();
                Main.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\László\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Users where Username='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("User already registered, please login!");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into Users values (@Username, @Password)", con);
                con.Open();
                cmd.Parameters.AddWithValue("Username", textBox1.Text);
                cmd.Parameters.AddWithValue("Password", textBox2.Text);
                cmd.ExecuteNonQuery();
                textBox2.Text = "";
                MessageBox.Show("Registration Succesful! Please login!");
            }


        }
    }

}
