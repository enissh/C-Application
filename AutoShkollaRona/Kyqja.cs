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
    public partial class Kyqja : Form
    {
        public Kyqja()
        {
            InitializeComponent();
        }

        private void kyqjaregjistrohubutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Regjistrohu();
            dritarja.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void kyqjakyqubutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JR7UJM0\SQLEXPRESS;Initial Catalog=AutoShkollaRona;Integrated Security=True");
            string query = "Select * from Regjistrohu Where email = '" + kyqjaemailbox.Text.Trim() + "' and password = '" + kyqjapasswordbox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            Program.UserEmail = kyqjaemailbox.Text;
            if (kyqjaemailbox.Text.Length == 0 && kyqjapasswordbox.Text.Length == 0)
            {
                MessageBox.Show("Fushat jane te zbrazura, ju lutem plotesoni ato!", "Paralajmerim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(dtb.Rows.Count == 1)
            {
                this.Hide();
                Ballina dritarja = new Ballina();
                dritarja.Show();
            }
            else
            {
                MessageBox.Show("Email ose Password jane gabim, ju lutem provoni perseri!", "Paralajmerim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
