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
    public partial class Mesajlar2 : Form
    {
        public Mesajlar2()
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
                    komut.CommandText= "INSERT into KisiyeMesajTbl (gonderenId,gonderenAd,aliciId,mesaj)  VALUES ('"+ textBox1.Text+ "','" + textBox3.Text +"','" + textBox2.Text+"','" + richTextBox1.Text+"')";
                    // komut.CommandText = "INSERT into KisiyeMesajTbl (gonderenId,gonderenAd,aliciId,mesaj)  VALUES  (@gonderenId,@gonderenAd,@aliciId,@mesaj)";
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
                    komut.CommandText = "INSERT into KisiyeMesajTbl (gonderenId,mesaj)  VALUES ('" + textBox1.Text + "','" + richTextBox1.Text + "')";
                   // komut.CommandText = "INSERT into KisiyeMesajTbl (gonderenId,mesaj)  VALUES  (@gonderenId,@mesaj)";
                    komut.Connection = baglanti;
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
               

                MessageBox.Show("Mesaj başarı ile gönderildi...");
               
            }
            catch (Exception)
            {
               
                MessageBox.Show("Gönderimde bir sıkıntı oluştu daha sonra tekrar deneyiniz...");
            }

       }

        private void Mesajlar2_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox3.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


       
    }
}
