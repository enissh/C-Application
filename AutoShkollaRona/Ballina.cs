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
    public partial class Ballina : Form
    {
        public Ballina()
        {
            InitializeComponent();
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

        private void ballina5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dritarja = new Raporti();
            dritarja.Show();
        }

        private void ballinadil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te largoheni nga Ballina dhe te kaloni ne Kyqje?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var dritarja = new Kyqja();
                dritarja.Show();
            }
        }

        private void ballinaclose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A jeni te sigurt qe doni te dilni nga aplikacioni?", "Paralajmërim", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void UserEmail_TextChanged(object sender, EventArgs e)
        {
            InitializeComponent();
            UserEmail.Text = Program.UserEmail;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
