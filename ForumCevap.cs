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
    public partial class ForumCevap : Form
    {
        public ForumCevap()
        {
            InitializeComponent();
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();

        private void Forum2_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            textBox3.Hide();

            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select  gonderenId,cevap FROM forumCevap ", SqlCnn);
            dt = new DataTable();
            SqlCnn.Open();
            SqlScb = new SqlCommandBuilder(SqlDap);
            dataGridView1.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[0].HeaderText = "GÖNDEREN KİŞİ ID";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].HeaderText = "CEVAP";
            dataGridView1.Columns[1].Width =1115;
           


            SqlCnn.Close();

        }

        
           

        private void button1_Click_1(object sender, EventArgs e)
        {
             try
            {

                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "INSERT into forumCevap(soruId,gonderenId,cevap) VALUES ('" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "')";
                komut.Connection = baglanti;
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Mesaj başarı ile gönderildi...");
            }
                  


          catch (Exception)
            {
               
                MessageBox.Show("Gönderimde bir sıkıntı oluştu daha sonra tekrar deneyiniz...");
            }
        
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
       

        
    }
}
