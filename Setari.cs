using System;
using System.Windows.Forms;

namespace Scanare_Angajati
{
    public partial class Setari : Form
    {
        public Setari()
        {
            InitializeComponent();
        }

        private void Setari_Load(object sender, EventArgs e)
        {
			this.TopMost = true;
			this.textBox1.Text = SetariInitiale.Default.serverIP;
			this.textBox5.Text = SetariInitiale.Default.databaseName;
			this.textBox2.Text = SetariInitiale.Default.portNo;
			this.textBox3.Text = SetariInitiale.Default.dUsername;
			this.textBox4.Text = SetariInitiale.Default.dPassword;
			Program.myConnectionString = string.Concat(new string[]
				{
					"Data Source=",
					this.textBox1.Text,
					",",
					this.textBox2.Text,
					";Network Library=DBMSSOCN;Initial Catalog=",
					this.textBox5.Text,
					";User ID=",
					this.textBox3.Text,
					";Password=",
					this.textBox4.Text,
					";"
				});
		}

        private void apply_btn_Click(object sender, EventArgs e)
        {
			SetariInitiale.Default.serverIP = this.textBox1.Text;
			SetariInitiale.Default.databaseName = this.textBox5.Text;
			SetariInitiale.Default.portNo = this.textBox2.Text;
			SetariInitiale.Default.dUsername = this.textBox3.Text;
			SetariInitiale.Default.dPassword = this.textBox4.Text;

			SetariInitiale.Default.Save();
			Application.Restart();
		}
    }
}
