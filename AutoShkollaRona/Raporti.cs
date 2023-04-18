using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoShkollaRona
{
    public partial class Raporti : Form
    {
        public Raporti()
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

        private void ballina4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new KategoriaC();
            dritarja.Show();
        }

        private void ballinadil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te largoheni nga Raporti dhe te kaloni ne Kyqje?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var dritarja = new Kyqja();
                dritarja.Show();
            }
        }

        private void raporticlose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ballina5_Click(object sender, EventArgs e)
        {

        }

        private void Raporti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Regjistrohu' table. You can move, or remove it, as needed.
            this.regjistrohuTableAdapter.Fill(this.dataSet1.Regjistrohu);

        }
    }
}
