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
    public partial class PersonelSayfa : Form
    {
       
        public PersonelSayfa()
        {
            InitializeComponent();
            
           
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();



        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox3.Hide();
            groupBox4.Hide();


           
            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select DISTINCT ogrenciNo,ogrenciAd,ogrenciSoyAd,vize,final,ortalama from Table_1 where ogrenciFakulte ='" + comboBox1.Text + "'and ogrenciBolum='" + comboBox2.Text + "'and ogrenciSinif='" + comboBox3.Text + "' and dersID='" +textBox5.Text+"'", SqlCnn);
            dt = new DataTable();
            SqlScb = new SqlCommandBuilder(SqlDap);
            SqlScb.DataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
           

        }


          private void button7_Click(object sender, EventArgs e)
        {
            SqlScb.DataAdapter.Update(dt);
            
            DialogResult k;
            k = MessageBox.Show("Güncelleme başarıyla kaydedildi!!");
        }



          /*  SqlConnection baglan = new SqlConnection();
            baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand komut = new SqlCommand("Select  ogrenciNo,ogrenciAd,ogrenciSoyAd from ogrenciTbl where ogrenciFakulte ='" + comboBox1.Text + "'and ogrenciBolum='" + comboBox2.Text + "'and ogrenciSinif='" + comboBox3.Text + "'",baglan);
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["ogrenciNo"].ToString());
                kayit.SubItems.Add(dr["ogrenciAd"].ToString());
                kayit.SubItems.Add(dr["ogrenciSoyAd"].ToString());

                listView1.Items.Add(kayit);
            }

            baglan.Close();*/
        
         




        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox2.Hide();
            groupBox4.Hide();
            textBox7.Hide();

           
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox4.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            

            SqlConnection baglan = new SqlConnection();
            baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand komut = new SqlCommand("Select  ogrenciAd,ogrenciSoyAd from ogrenciTbl where ogrenciNo='" + textBox6.Text + "'" ,baglan);
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            listView2.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["ogrenciAd"].ToString());
                kayit.SubItems.Add(dr["ogrenciSoyAd"].ToString());

               
                listView2.Items.Add(kayit);
            }

            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            groupBox3.Show();
            groupBox2.Hide();
            groupBox4.Hide();

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
            AnaEkran yeniSayfa = new AnaEkran();
            yeniSayfa.BringToFront();

        }


       

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBox1.Text == "MÜHENDİSLİK")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Items.Add("BİLGİSAYAR");
                comboBox2.Items.Add("İNŞAAT");
                comboBox2.Items.Add("ENDÜSTRİ");
                comboBox2.Items.Add("ELEKTRİK");
                comboBox2.Items.Add("ELEKTRONİK");
                comboBox2.Items.Add("JEOFİZİK");
                comboBox2.Items.Add("JEOLOJİ");
                comboBox2.Items.Add("ÇEVRE");



            }

            if (comboBox1.Text == "İİBF")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Items.Add("SİYASET BİLİMİ");
                comboBox2.Items.Add("İKTİSAT");
                comboBox2.Items.Add("İŞLETME");
                comboBox2.Items.Add("KAMU YÖNETİMİ ");
                comboBox2.Items.Add("ULUSLARARASI İLİŞKİLER");
                comboBox2.Items.Add("ÇEKO");
                comboBox2.Items.Add("İLETİŞİM");
                comboBox2.Items.Add("RADYO ve TELEVİZYON");


            }

            if (comboBox1.Text == "SAĞLIK MYO")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("HEMŞİRELİK");
                comboBox2.Items.Add("EBELİK");
            }


            if (comboBox1.Text == "EĞİTİM")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("İLÖĞRETİM MATEMATİK ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("OKUL ÖNCESİ ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("SINIIF ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("RAHBERLİK ve DANIŞMANLIK");

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select dersID,dersAdi,ad,soyad,email,telefon,adres from Kullanici where id='" + textBox7.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["dersID"].ToString());
                kayit.SubItems.Add(dr["dersAdi"].ToString());

                listView1.Items.Add(kayit);

                textBox1.Text = dr["ad"].ToString();
                textBox2.Text = dr["soyad"].ToString();
                textBox3.Text = dr["email"].ToString();
                textBox4.Text = dr["telefon"].ToString();
                richTextBox1.Text = dr["adres"].ToString();


            }

            baglanti.Close();

        }

       
    }

}
