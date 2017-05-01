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
    public partial class Mesajlar : Form
    {
        int gonderenId;
        string gonderenAd;
        string soru;
            
        public Mesajlar()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (radioButton1.Checked == true)
                {

                    SqlConnection baglanti = new SqlConnection();
                    baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "INSERT into KisiyeMesajTbl (gonderenId,gonderenAd,aliciId,mesaj)  VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + richTextBox1.Text + "')";
                   // komut.CommandText = " INSERT into KisiyeMesjTbl (gonderenId,gonderenAd,aliciId,mesaj)  VALUES (@gonderenId,@gonderenAd,@aliciId,@mesaj) ";
                    komut.Connection = baglanti;
                    komut.ExecuteNonQuery();
                    baglanti.Close();


                }

                if (radioButton2.Checked == true)
                {

                    SqlConnection baglanti = new SqlConnection();
                    baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "INSERT into forumSoru (gonderenId,gonderenAd,soru)  VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "')";
                   // komut.CommandText = "INSERT into forumSoru (gonderenId,gonderenAd,soru)  VALUES ( @gonderenId, @gonderenAd,@soru)";
                    komut.Connection = baglanti;
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                   

                  /* komut.Parameters.AddWithValue("@gonderenId", Convert.ToString(gonderenId));
                   komut.Parameters.AddWithValue("@gonderenAd", Convert.ToString(gonderenAd));
                   komut.Parameters.AddWithValue("@soru", Convert.ToString(soru));*/
                  
                }


                MessageBox.Show("Mesaj başarı ile gönderildi...");
            }

            catch (Exception)
            {

                MessageBox.Show("Gönderimde bir sıkıntı oluştu daha sonra tekrar deneyiniz...");
            }   

        }
        
        private void Mesajlar_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
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

       

        private void button4_Click(object sender, EventArgs e)
        {
            AnaEkran yeni = new AnaEkran();
            yeni.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




       
    }
}
