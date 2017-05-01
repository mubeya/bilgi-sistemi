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


        private void PersonelSayfa_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            textBox6.Hide();



        }

        private void pROFİLİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select sifre,tcNo,ad,soyad,cinsiyet,dogumTarih,dogumYer,medeniHal,babaAd,anneAd,telNo1,telNo2,adres,email from personelTbl where id='" + textBox6.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                textBox1.Text = dr["sifre"].ToString();
                textBox2.Text = dr["tcNo"].ToString();
                textBox3.Text = dr["ad"].ToString();
                textBox9.Text = dr["soyad"].ToString();
                textBox10.Text = dr["cinsiyet"].ToString();
                textBox11.Text = dr["dogumTarih"].ToString();
                textBox12.Text = dr["dogumYer"].ToString();
                textBox13.Text = dr["medeniHal"].ToString();
                textBox14.Text = dr["babaAd"].ToString();
                textBox15.Text = dr["anneAd"].ToString();
                textBox4.Text = dr["email"].ToString();
                textBox5.Text = dr["telNo1"].ToString();
                textBox16.Text = dr["telNo2"].ToString();
                richTextBox1.Text = dr["adres"].ToString();


               
                
            }
        }

        private void dERSLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox4.Hide();
            groupBox1.Hide();
            groupBox3.Hide();


            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select dersId,dersAd from personelTbl where id='" + textBox6.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["dersId"].ToString());
                kayit.SubItems.Add(dr["dersAd"].ToString());

                listView1.Items.Add(kayit);

            }

            baglanti.Close();
        }

        private void öĞRENCİLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox2.Hide();
            groupBox1.Hide();
            groupBox4.Hide();
            

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox7.Text = "";
            textBox17.Text = "";
            textBox8.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
                      


                        if ((!string.IsNullOrEmpty(comboBox1.Text.Trim()) & !string.IsNullOrEmpty(comboBox2.Text.Trim()) & !string.IsNullOrEmpty(comboBox3.Text.Trim()) & !string.IsNullOrEmpty(textBox7.Text.Trim())))
                        {
                            SqlConnection baglan = new SqlConnection();
                            baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                            baglan.Open();
                            SqlCommand komut = new SqlCommand();
                            komut.CommandText = "Select  id from personelTbl where dersId='" + textBox7.Text + "'";
                            komut.Connection = baglan;
                            SqlDataReader reader = komut.ExecuteReader();
                            while (reader.Read())
                            {
                                string a = reader["id"].ToString();
                                if (a == textBox6.Text)
                                {
                                    groupBox4.Show();
                                    groupBox2.Hide();
                                    groupBox1.Hide();
                                    groupBox3.Hide();


                                }

                                else { MessageBox.Show("Bu derse erişim izniniz yoktur!! Başka bir ders ID si giriniz..", "UYARI!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); }
                                a = "";
                            }

                            baglan.Close();

                            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
                            SqlDap = new SqlDataAdapter("Select  ogrenciNo,ogrenciAd,ogrenciSoyad,vize,final,ortalama from ogrenciTbl2 where ogrenciFakulte ='" + comboBox1.SelectedItem + "'and dersId='" + textBox7.Text + "' and ogrenciBolum='" + comboBox2.SelectedItem + "'and ogrenciSinif='" + comboBox3.SelectedItem + "' ", SqlCnn);
                            dt = new DataTable();
                            SqlScb = new SqlCommandBuilder(SqlDap);
                            SqlScb.DataAdapter.Fill(dt);
                            dataGridView1.DataSource = dt;


                            dataGridView1.Columns[0].HeaderText = "NO";
                            dataGridView1.Columns[1].HeaderText = "AD";
                            dataGridView1.Columns[2].HeaderText = "SOYAD";
                            dataGridView1.Columns[3].HeaderText = "VİZE";
                            dataGridView1.Columns[4].HeaderText = "FİNAL";
                            dataGridView1.Columns[5].HeaderText = "ORTALAMA";

                        }

            else { MessageBox.Show("Lütfen işaretli alanları boş geçmeyiniz..", "UYARI!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); }
           

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
          
               // SqlScb.DataAdapter.Update(dt);

                DialogResult k;
                k = MessageBox.Show("Güncelleme başarıyla kaydedildi!!");
            
          /*  catch 
            {
                DialogResult k;
                k = MessageBox.Show("Güncelleme gerçekleştirildi!!");
            
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox4.Hide();
            groupBox2.Hide();
            groupBox1.Hide();


            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox7.Text = "";
            textBox17.Text = "";
            textBox8.Text = "";
           
            

}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "MÜHENDİSLİK F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("BİLGİSAYAR");
                comboBox2.Items.Add("İNŞAAT");
                comboBox2.Items.Add("ENDÜSTRİ");
                comboBox2.Items.Add("ELEKTRİK");
                comboBox2.Items.Add("ELEKTRONİK HABERLEŞME");
                comboBox2.Items.Add("JEOFİZİK");
                comboBox2.Items.Add("JEOLOJİ");
                comboBox2.Items.Add("ÇEVRE");



            }

            if (comboBox1.Text == "İİB F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("SİYASET BİLİMİ");
                comboBox2.Items.Add("İKTİSAT");
                comboBox2.Items.Add("İŞLETME");
                comboBox2.Items.Add("KAMU YÖNETİMİ ");
                comboBox2.Items.Add("ULUSLARARASI İLİŞKİLER");
                comboBox2.Items.Add("ÇEKO");
               


            }

            if (comboBox1.Text == "SAĞLIK MYO")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("HEMŞİRELİK");
                comboBox2.Items.Add("EBELİK");
            }


            if (comboBox1.Text == "EĞİTİM F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("İLÖĞRETİM MATEMATİK ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("OKUL ÖNCESİ ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("SINIIF ÖĞRETMENLİĞİ");
                comboBox2.Items.Add("RAHBERLİK ve DANIŞMANLIK");

            }


            if (comboBox1.Text == "TIP F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("TIP");


           }

            if (comboBox1.Text == "HUKUK F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("HUKUK");

            }

            if (comboBox1.Text == "FEN VE EDEBİYAT F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("MATEMATİK");
                comboBox2.Items.Add("FİZİK");
                comboBox2.Items.Add("KİMYA");
                comboBox2.Items.Add("BİYOLOJİ");
                comboBox2.Items.Add("TÜRK DİLİ VE EDEBİYATI");
                comboBox2.Items.Add("TARİH");
                comboBox2.Items.Add("İNGİLİZ DİLİ VE EDEBİYATI");
                comboBox2.Items.Add("FELSEFE");
                comboBox2.Items.Add("ARKEOLOJİ");

            }

            if (comboBox1.Text == "MİMARLIK F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("MİMARLIK");
                comboBox2.Items.Add("İÇ MİMARLIK");
                comboBox2.Items.Add("PEYZAJ MİMARLIK");
            }


            if (comboBox1.Text == "İLETİŞİM F.")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                comboBox2.Text = "";
                comboBox2.Items.Add("RADYO VE TELEVİZYON");
                comboBox2.Items.Add("GAZETECİLİK");
                comboBox2.Items.Add("REKLAMCILIK");
                comboBox2.Items.Add("GÖRSEL İLETİŞİM TASARIMI");
            }

        }

        private void aNASAYFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnaEkran yeniSayfa = new AnaEkran();
            yeniSayfa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

            if ((!string.IsNullOrEmpty(textBox8.Text.Trim()) & !string.IsNullOrEmpty(textBox17.Text.Trim())))
            {
                SqlConnection baglan = new SqlConnection();
                baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
                baglan.Open();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "Select id from personelTbl where dersId='" + textBox17.Text + "'";
                komut.Connection = baglan;
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    string a = reader["id"].ToString();
                    if (a == textBox6.Text)
                    {
                        groupBox4.Show();
                        groupBox2.Hide();
                        groupBox1.Hide();
                        groupBox3.Hide();
                    
                    }

                    else { MessageBox.Show("Bu derse erişim izniniz yoktur!! Başka bir ders ID si giriniz..", "UYARI!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); }
                    a = "";
                }

                baglan.Close(); 


                SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
                SqlDap = new SqlDataAdapter("Select  ogrenciAd,ogrenciSoyAd,vize,final,ortalama from ogrenciTbl2 where ogrenciNo='" + textBox8.Text + "' and dersId='"+textBox17.Text+"'", SqlCnn);
                dt = new DataTable();
                SqlScb = new SqlCommandBuilder(SqlDap);
                SqlScb.DataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;


                dataGridView1.Columns[0].HeaderText = "AD";
                dataGridView1.Columns[1].HeaderText = "SOYAD";
                dataGridView1.Columns[2].HeaderText = "VİZE";
                dataGridView1.Columns[3].HeaderText = "FİNAL";
                dataGridView1.Columns[4].HeaderText = "ORTALAMA";
               
            }

            else { MessageBox.Show("Lütfen işaretli alanları boş geçmeyiniz..", "UYARI!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); }
           
            

        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void yENİMESAJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar2 frmMesaj2 = new Mesajlar2();
            frmMesaj2.Show();

            frmMesaj2.groupBox1.Show();
            frmMesaj2.groupBox2.Hide();
            frmMesaj2.groupBox3.Hide();
            
           
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select ad,soyad from personelTbl where id='" + textBox6.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                frmMesaj2.textBox3.Text = dr["ad"].ToString() + dr["soyad"].ToString();
               

            }

            frmMesaj2.textBox1.Text = textBox6.Text;

            groupBox4.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            groupBox3.Hide();
        }

        private void gELENMESAJLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar2 frmMesaj2 = new Mesajlar2();
            frmMesaj2.Show();

            frmMesaj2.groupBox2.Show();
            frmMesaj2.groupBox1.Hide();
            frmMesaj2.groupBox3.Hide();


            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select  gonderenId,mesaj from KisiyeMesajTbl where aliciId ='" + textBox6.Text + "'", SqlCnn);
            dt = new DataTable();
            SqlCnn.Open();
            SqlScb = new SqlCommandBuilder(SqlDap);
            frmMesaj2.dataGridView1.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            frmMesaj2.dataGridView1.DataSource = dt;


            frmMesaj2.dataGridView1.Columns[0].HeaderText = "GÖNDEREN KİŞİ";
            frmMesaj2.dataGridView1.Columns[0].Width = 200;
            frmMesaj2.dataGridView1.Columns[1].HeaderText = "MESAJ";
            frmMesaj2.dataGridView1.Columns[1].Width = 775;

            SqlCnn.Close();

            groupBox4.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            groupBox3.Hide();
        }

        private void gİDENMESAJLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar2 frmMesaj2 = new Mesajlar2();
            frmMesaj2.Show();
            frmMesaj2.groupBox3.Show();
            frmMesaj2.groupBox1.Hide();
            frmMesaj2.groupBox2.Hide();


            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select  aliciId,mesaj from KisiyeMesajTbl where gonderenId ='" + textBox6.Text + "'", SqlCnn);
            dt = new DataTable();
            SqlScb = new SqlCommandBuilder(SqlDap);
            frmMesaj2.dataGridView2.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            frmMesaj2.dataGridView2.DataSource = dt;


            frmMesaj2.dataGridView2.Columns[0].HeaderText = "ALICI KİŞİ";
            frmMesaj2.dataGridView2.Columns[0].Width = 165;
            frmMesaj2.dataGridView2.Columns[1].HeaderText = "MESAJ";
            frmMesaj2.dataGridView2.Columns[1].Width = 750;

            groupBox4.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            groupBox3.Hide();

        }

          
     
    }
}