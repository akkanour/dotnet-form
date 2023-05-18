using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System.Data;

namespace Form_Database
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server = localhost;Database = dotnet; Uid = root; Pwd = ;");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajouter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualiser();
        }
        public void ajouter()
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO 'etudiant'(`id`,`nom`,`prenom`,`cin");
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Bien Ajouté");
                    actualiser();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        public void actualiser()
        {
            MySqlCommand cmd = new MySqlCommand("select * from etudiant", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter();
            adp.SelectCommand = cmd;
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supprimer();
        }
        public void supprimer()
        {
            int l = dataGridView1.CurrentCell.RowIndex;
            int ID = (int)dataGridView1.Rows[1].Cells[0].Value;
            MySqlCommand cmd = new MySqlCommand("DELETE FROM etudiant WHERE `etudiant`.`id` = " + ID + "", conn);
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("L'étudiant N° " + ID.ToString() + " a été bien supprimé");
                    actualiser();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        public void modifier()
        {
            int ID2;
            int indice = -1;
            if (indice == -1)
            {
                indice = dataGridView1.CurrentCell.RowIndex;
                ID2 = (int)dataGridView1.Rows[indice].Cells[0].Value;
                textBox1.Text = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Text = "Validez";
            }
            else
            {

            }
        }
    }
}