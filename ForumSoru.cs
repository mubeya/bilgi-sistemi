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
    public partial class ForumSoru : Form
    {
        public ForumSoru()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                    SqlConnection baglanti = new SqlConnection();
                    baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "INSERT into forumSoru (gonderenId,gonderenAd,soru)  VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + richTextBox1.Text + "')";
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
    }
}
