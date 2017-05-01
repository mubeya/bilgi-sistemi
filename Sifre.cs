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
    public partial class Sifre : Form
    {
        public Sifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(textBox1.Text.Trim()) & !string.IsNullOrEmpty(textBox2.Text.Trim()) & !string.IsNullOrEmpty(textBox2.Text.Trim())))
                {
                    SqlConnection baglanti = new SqlConnection();
                    baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ogrenciTbl1 SET sifre='" + textBox3.Text + "' where ogrenciNo='" + textBox4.Text + "'", baglanti);
                    cmd.ExecuteNonQuery();
                    cmd.Connection = baglanti;

                    MessageBox.Show("Şifre başarıyla güncellendi!!");


                    baglanti.Close();
                }

                else { MessageBox.Show("İşaretli alanları boş bırakmayınız...", "UYARI!!"); }
            }

            catch { MessageBox.Show("Şifre !"); }
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox4.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciSayfa yeni = new OgrenciSayfa();
            yeni.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            AnaEkran yeniSayfa = new AnaEkran();
            yeniSayfa.Show();
        }

       

       
    }
}
