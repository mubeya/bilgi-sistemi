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
    public partial class PersonelGiris : Form
    {
         PersonelSayfa frm5 = new PersonelSayfa();
         Mesajlar2 frmMesaj2 = new Mesajlar2();


         public PersonelGiris()
        {
            InitializeComponent();
            
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text.Trim()) & !string.IsNullOrEmpty(textBox2.Text.Trim())))
            {

                SqlConnection baglan = new SqlConnection();
                baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                baglan.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "Select id,sifre from personelTbl where id='" + textBox1.Text + "'";
                komut.Connection = baglan;
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    string a = reader["Sifre"].ToString();
                    if (a == textBox2.Text)
                    {
                        
                        frm5.Show();
                        frm5.textBox6.Text = textBox1.Text;
                        frmMesaj2.textBox1.Text = textBox1.Text;
                    }
                       
                    else { MessageBox.Show("Kullanıcı ID veya Şifre Hatalı!!"); }
                    a = "";
                }

                baglan.Close();
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

        private void PersonelGiris_Load(object sender, EventArgs e)
        {

           
        }

       
    }
}
