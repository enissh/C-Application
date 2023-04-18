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
  
    public partial class KategoriaA : Form
    {
        string pagesa;
        public KategoriaA()
        {
            InitializeComponent();
        }

        private void A1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Ballina();
            dritarja.Show();
        }

        private void A2_Click(object sender, EventArgs e)
        {

        }

        private void A3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaB();
            dritarja.Show();
        }

        private void A4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaC();
            dritarja.Show();
        }

        private void A5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Raporti();
            dritarja.Show();
        }

        private void Adil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te largoheni nga Kategoria A dhe te kaloni ne Kyqje?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var dritarja = new Kyqja();
                dritarja.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
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

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True");
        private void kyqjaregjistrohubutton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaA_apliko'"+int.Parse(Aidtextbox.Text)+"','"+Aemritextbox.Text+"','" + Aemailtextbox.Text + "','" + Aqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Urime per aplikimin e motocikletes");
            Refresh();
        }
        void Refresh()
        {
            SqlCommand com = new SqlCommand("exec dbo.KategoriaA_View" , con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KategoriaAtabel.DataSource = dt;
        }
       

            private void Apagesa1_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Me keste";
        }

        private void Apagesa2_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Totale";
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Refresh();
        }

        private void KategoriaA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet4.KategoriaA' table. You can move, or remove it, as needed.
            this.kategoriaATableAdapter.Fill(this.dataSet4.KategoriaA);

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaA_ndrysho'" + int.Parse(Aidtextbox.Text) + "','" + Aemritextbox.Text + "','" + Aemailtextbox.Text + "','" + Aqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ndryshimi u be me sukses!");
            Refresh();
        }

        private void Afshij_Click(object sender, EventArgs e)
        {
        
            con.Open();
            if (MessageBox.Show("A jeni te sigurt qe doni te fshini kete person?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult);
            {
                SqlCommand com = new SqlCommand("exec dbo.KategoriaA_fshij'" + int.Parse(Aidtextbox.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("U fshij me sukses");
                Refresh();
            }
        }

        private void Arefresh_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("exec dbo.KategoriaA_View", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KategoriaAtabel.DataSource = dt;
        }
    }
}
