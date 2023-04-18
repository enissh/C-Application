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
    public partial class KategoriaC : Form
    {
        string pagesa;
        public KategoriaC()
        {
            InitializeComponent();
        }

        private void ballina1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Ballina();
            dritarja.Show();
        }

        private void ballina2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaA();
            dritarja.Show();
        }

        private void ballina3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaB();
            dritarja.Show();
        }

        private void ballina5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Raporti();
            dritarja.Show();
        }

        private void ballinadil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te largoheni nga Kategoria C dhe te kaloni ne Kyqje?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var dritarja = new Kyqja();
                dritarja.Show();
            }
        }

        private void Cclose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True");
        private void Capliko_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaC_apliko'" + int.Parse(Cidtextbox.Text) + "','" + Cemritextbox.Text + "','" + Cemailtextbox.Text + "','" + Cqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Urime per aplikimin per makin", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
        }

        private void Cpagesa1_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Me keste";
        }

        private void Cpagesa2_CheckedChanged(object sender, EventArgs e)
        {
            pagesa = "Totale";
        }

        private void Cndrysho_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.KategoriaC_ndrysho'" + int.Parse(Cidtextbox.Text) + "','" + Cemritextbox.Text + "','" + Cemailtextbox.Text + "','" + Cqytetitextbox.Text + "','" + pagesa + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ndryshimi u be me sukses!", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
        }

        private void Cfshij_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("A jeni te sigurt qe doni te fshini kete person?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult) ;
            {
                SqlCommand com = new SqlCommand("exec dbo.KategoriaC_fshij'" + int.Parse(Cidtextbox.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("U fshij me sukses");
                Refresh();
            }
        }

        private void KategoriaC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet6.KategoriaC' table. You can move, or remove it, as needed.
            this.kategoriaCTableAdapter.Fill(this.dataSet6.KategoriaC);

        }
    }
}
