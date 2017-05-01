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

namespace okulOtomasyon
{
    public partial class Forum : Form
    {
        object soru;
        object Id;

        public Forum()
        {
            InitializeComponent();
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();


        private void Forum_Load(object sender, EventArgs e)
        {
            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select soruId, gonderenId,gonderenAd,soru FROM forumSoru", SqlCnn);
            dt = new DataTable();
            SqlCnn.Open();
            SqlScb = new SqlCommandBuilder(SqlDap);
            dataGridView1.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "SORU ID";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "GÖNDEREN KİŞİ ID";
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].HeaderText = "GÖNDEREN KİŞİ";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "MESAJ SORU";
            dataGridView1.Columns[3].Width = 930;
            

            SqlCnn.Close();

            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ForumCevap forum2 = new ForumCevap();
            soru = dataGridView1.CurrentRow.Cells["soruId"].Value.ToString();
            Id = dataGridView1.CurrentRow.Cells["gonderenId"].Value.ToString();
            forum2.label1.Text = soru.ToString();
            forum2.label2.Text = Id.ToString();
            forum2.textBox3.Text = soru.ToString();
            forum2.Show();


       }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ForumSoru yeni = new ForumSoru();
            yeni.Show();
        }
    }
}
