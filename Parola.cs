using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scanare_Angajati
{
    public partial class Parola : Form
    {
        public Parola()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ("Webasto123"))
            {
                int num = (int)new Setari().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please try again.");
                this.textBox1.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (textBox1.Text == ("Webasto123"))
                {
                    int num = (int)new Setari().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please try again.");
                    this.textBox1.Text = "";
                }
            }
        }
    }
}
