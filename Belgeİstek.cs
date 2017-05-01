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
    public partial class Belgeİstek : Form
    {
        public Belgeİstek()
        {
            InitializeComponent();
        }

        private void Belgeİstek_Load(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
            textBox3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = textBox1.Text;

            try
            {
                SqlConnection baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "INSERT into belgeTbl(Id,belge,verilecekYer,istekNedeni)  VALUES ('" + textBox3.Text + "','" +comboBox2.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "')";
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

        private void button3_Click(object sender, EventArgs e)
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
