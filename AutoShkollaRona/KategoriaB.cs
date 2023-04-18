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
    public partial class KategoriaB : Form
    {
        string pagesa;
        public KategoriaB()
        {
            InitializeComponent();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Ballina();
            dritarja.Show();
        }

        private void B2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaA();
            dritarja.Show();
        }

        private void B4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaC();
            dritarja.Show();
        }

        private void B5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Raporti();
            dritarja.Show();
        }

        private void Bdil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te largoheni nga Kategoria B dhe te kaloni ne Kyqje?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var dritarja = new Kyqja();
                dritarja.Show();
            }
        }

        private void Bclose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True");
        private void Bapliko_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaB_apliko'" + int.Parse(Bidtextbox.Text) + "','" + Bemritextbox.Text + "','" + Bemailtextbox.Text + "','" + Bqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Urime per aplikimin per makin", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
        }

        private void Bpagesa1_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Me keste";
        }

        private void Bpagesa2_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Totale";
        }

        private void Bndrysho_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaB_ndrysho'" + int.Parse(Bidtextbox.Text) + "','" + Bemritextbox.Text + "','" + Bemailtextbox.Text + "','" + Bqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ndryshimi u be me sukses!", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
        }

        private void Bfshij_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("A jeni te sigurt qe doni te fshini kete person?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult) ;
            {
                SqlCommand com = new SqlCommand("exec dbo.KategoriaB_fshij'" + int.Parse(Bidtextbox.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("U fshij me sukses");
                Refresh();
            }
        }

        private void KategoriaB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet5.KategoriaB' table. You can move, or remove it, as needed.
            this.kategoriaBTableAdapter.Fill(this.dataSet5.KategoriaB);

        }
    }
}
