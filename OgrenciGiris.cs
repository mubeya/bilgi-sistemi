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
    public partial class OgrenciGiris : Form
    {
        OgrenciSayfa frmOgrenci = new OgrenciSayfa();
        Sifre frm2 = new Sifre();
        public OgrenciGiris()
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
                komut.CommandText = "Select ogrenciNo,sifre from ogrenciTbl1 where ogrenciNo='" + textBox1.Text + "'";
                komut.Connection = baglan;
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    string a = reader["Sifre"].ToString();
                    if (a == textBox2.Text)
                    {
                        //OgrenciGiris.ActiveForm.Hide();
                        OgrenciSayfa frmOgrenci = new OgrenciSayfa();
                        Belgeİstek frmBelge = new Belgeİstek();
                    
                        frmOgrenci.textBox16.Text = textBox1.Text;
                        frmOgrenci.label1.Text = textBox1.Text;
                        frm2.textBox4.Text = textBox1.Text;
                        frmOgrenci.textBox14.Text = textBox1.Text;
                        frmOgrenci.textBox15.Text = textBox1.Text;
                        frmOgrenci.textBox17.Text = textBox1.Text;
                        frmOgrenci.textBox18.Text = textBox1.Text;
                        frmBelge.textBox3.Text = textBox1.Text;
                        frmOgrenci.ShowDialog();

                        OgrenciGiris formGiris = new OgrenciGiris();
                        formGiris.Visible = true;
                    }

                    else { MessageBox.Show("Öğrenci NO veya Şifre Hatalı!!"); }
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
    }
}
