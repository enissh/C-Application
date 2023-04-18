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

namespace AutoShkollaRona
{
    public partial class Regjistrohu : Form
    {
        string gjinia;
        string eksperienca;
        string email;
        public Regjistrohu()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Kyqja();
            dritarja.Show();
        }

        private void kyqjaregjistrohubutton_Click(object sender, EventArgs e)
        {
            string email = regjemail.Text;
            if (regjidbox.Text.Length == 0 && regjemritextbox.Text.Length == 0 && regjmbiemritextbox.Text.Length == 0 && regjemailtextbox.Text.Length == 0 && regjpasswordtextbox.Text.Length == 0 )
            {
                MessageBox.Show("Fushat jan te zbrasura", "Paralajmërim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!regjemailtextbox.Text.Contains("@"))
            {
                MessageBox.Show("Ju lutem vendosni @ e emailin tuaj", "Paralajmërim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!regjemailtextbox.Text.Contains("."))
            {
                MessageBox.Show("Ju lutem vendosni . ne emailin tuaj", "Paralajmërim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (regjpasswordtextbox.Text.Length < 5)
            {
                MessageBox.Show("Passwordi duhet te permabje se paku 5 karaktere, provo perseri", "Paralajmërim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IsEmailRegistered(email))
            {
                MessageBox.Show("Ky email është i regjistruar tashmë. Ju lutemi provoni përsëri me një email tjetër.", "Regjistrimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegisterUser(email);
                MessageBox.Show("Urime, Regjistrimi u be me sukses!", "Regjistrimi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool IsEmailRegistered(string email)
        {
            string connectionString = @"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM [dbo].[Regjistrohu] WHERE email = @Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count > 0);
            }
        }
        private void RegisterUser(string email)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS; Initial catalog=AutoShkollaRona;  Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Regjistrohu]
([id]
           ,[emri]
           ,[mbiemri]
           ,[email]
           ,[password]
           ,[mosha]
           ,[gjinia]
           ,[eksperienca]
           ,[qyteti])
     VALUES
('" + regjidbox.Text + "','" + regjemritextbox.Text + "','" + regjmbiemritextbox.Text + "','" + regjemailtextbox.Text + "','" + regjpasswordtextbox.Text + "','" + regjmoshatextbox.Text + "','" + gjinia + "','" + eksperienca + "','" + regjqytetitextbox.Text +  "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void regjgjiniam_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "M";
        }

        private void regjgjiniaf_CheckedChanged(object sender, EventArgs e)
        {
            gjinia = "F";
        }

        private void regjeksperienca0_CheckedChanged(object sender, EventArgs e)
        {
            eksperienca = "0 vite";
        }

        private void regjeksperienca1_CheckedChanged(object sender, EventArgs e)
        {
            eksperienca = "1 vit";
        }

        private void regjeksperienca2_CheckedChanged(object sender, EventArgs e)
        {
            eksperienca = "2 vite";
        }
    }
}
