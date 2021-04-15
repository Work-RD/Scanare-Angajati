using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Scanare_Angajati
{
    public partial class Form1 : Form
    {
        private SqlConnection myConnection = new SqlConnection(Program.myConnectionString);

        public string nr_cartela = "";
        public string nr_marca = "";
        public string nume = "";
        public string prenume = "";
        public string data = "";

        Timer timer = new Timer
        {
            Interval = 3000
        };

        public Form1()
        {
            InitializeComponent();

            timer.Tick += new System.EventHandler(OnTimerEvent);

            this.label2.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool error = false;
            try
            {
                this.myConnection.Open();
                this.myConnection.Close();
            }
            catch (Exception)
            {
                error = true;
            }

            if (textBox1.Text.StartsWith("61"))
            {
                nr_marca = textBox1.Text;
            }
            else
            {
                nr_cartela = textBox1.Text;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (error == false)
                {
                    scanare_cartela();
                }
                else
                {
                    MessageBox.Show("Check you internet connection!");
                }
                textBox1.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
           
        }

        public void scanare_cartela()
        {
            if (textBox1.Text.StartsWith("61"))
            {
                nume = "";
                prenume = "";
                myConnection.Open();
                SqlDataReader sqlDataReader = new SqlCommand("SELECT nume, prenume FROM personal WHERE nr_marca='" + nr_marca + "'", myConnection).ExecuteReader();
                bool flag = sqlDataReader.Read();
                if (flag)
                {
                    nume = sqlDataReader.GetValue(0).ToString();
                    prenume = sqlDataReader.GetValue(1).ToString();

                    this.label1.Font = new Font("Microsoft Sans Serif", 48, FontStyle.Bold);
                    this.label1.Text = "Scanare " + nume + " " + prenume + "?";
                    this.button1.Visible = true;
                    this.button2.Visible = true;
                    this.textBox1.Visible = false;
                    this.button3.Visible = false;
                    this.pictureBox1.Visible = false;
                }
                else
                {
                    timer.Enabled = true;
                    this.BackColor = System.Drawing.Color.Red;
                    this.label1.Visible = false;
                    this.label2.Visible = true;
                    this.textBox1.Visible = false;
                    this.button3.Visible = false;
                    this.pictureBox1.Visible = false;
                    this.label2.Text = "Număr de marcă greșit!" + "\r\n" + "Vă rugăm luați legătura cu HR.";
                }
                myConnection.Close();
            }
            else
            {
                data = "";
                myConnection.Open();
                SqlDataReader sqlDataReader = new SqlCommand("SELECT nume FROM personal WHERE nr_cartela='" + nr_cartela + "'", myConnection).ExecuteReader();
                bool flag = sqlDataReader.Read();
                if (flag)
                {
                    timer.Enabled = true;
                    this.BackColor = System.Drawing.Color.Green;
                    this.label1.Visible = false;
                    this.label2.Visible = true;
                    this.textBox1.Visible = false;
                    this.button3.Visible = false;
                    this.pictureBox1.Visible = false;
                    this.label2.Text = "Scanare reușită!";
                }
                else
                {
                    timer.Enabled = true;
                    this.BackColor = System.Drawing.Color.Red;
                    this.label1.Visible = false;
                    this.label2.Visible = true;
                    this.textBox1.Visible = false;
                    this.button3.Visible = false;
                    this.pictureBox1.Visible = false;
                    this.label2.Text = "Cartelă nealocată!" + "\r\n" + "Vă rugăm luați legătura cu HR.";
                }
                myConnection.Close();

                data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (flag)
                {
                    this.myConnection.Open();
                    string query = "INSERT INTO scanare (nr_cartela, data_scanare) VALUES ('" + nr_cartela + "', '" + data + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                    this.myConnection.Close();
                }
            }
        }

        private void OnTimerEvent(object source, EventArgs e)
        {
            timer.Enabled = false;
            this.BackColor = System.Drawing.Color.White;
            this.label1.Visible = true;
            this.label2.Visible = false;
            this.textBox1.Visible = true;
            this.button3.Visible = true;
            this.pictureBox1.Visible = true;
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nr_cartela = "";
            data = "";
            myConnection.Open();
            SqlDataReader sqlDataReader = new SqlCommand("SELECT nr_cartela FROM personal WHERE nr_marca='" + nr_marca + "'", myConnection).ExecuteReader();
            bool flag = sqlDataReader.Read();
            if (flag)
            {
                nr_cartela = sqlDataReader.GetValue(0).ToString();

                timer.Enabled = true;
                this.label1.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Bold);
                this.label1.Text = "Te rugăm să te scanezi aici !";
                this.BackColor = System.Drawing.Color.Green;
                this.label1.Visible = false;
                this.label2.Visible = true;
                this.textBox1.Visible = false;
                this.button3.Visible = false;
                this.pictureBox1.Visible = false;
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.label2.Text = "Scanare reușită!";
            }
            myConnection.Close();

            data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            this.myConnection.Open();
            string query = "INSERT INTO scanare (nr_cartela, data_scanare) VALUES ('" + nr_cartela + "', '" + data + "')";
            SqlCommand myCommand = new SqlCommand(query, this.myConnection);
            myCommand.ExecuteNonQuery();
            this.myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Bold);
            this.label1.Text = "Te rugăm să te scanezi aici !";
            this.textBox1.Visible = true;
            this.button3.Visible = true;
            this.pictureBox1.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.ActiveControl = textBox1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = (int)new Parola().ShowDialog();
        }
    }
}
