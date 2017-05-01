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
   
    public partial class OgrenciSayfa : Form
    {
       
        Sifre frm2 = new Sifre();
        
        public OgrenciSayfa()
        {
            InitializeComponent();
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();

        private void OgrenciSayfa_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            textBox6.Hide();
            label1.Hide();
            textBox14.Hide();
            textBox15.Hide();
            textBox16.Hide();
            textBox17.Hide();
            textBox18.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            base.Dispose(true);

         //   groupBox1.Hide();
         //   groupBox2.Hide();


        }

        private void öĞRENCİBİLGİLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select sifre,tcNo,ogrenciAd,ogrenciSoyad,cinsiyet,babaAd,anneAd,dogumYeri,email,telNo1,telNo2,adres,dogumTarih from ogrenciTbl1 where ogrenciNo='" + textBox16.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                textBox1.Text=dr["sifre"].ToString();
                textBox2.Text = dr["tcNo"].ToString();
                textBox3.Text = dr["ogrenciAd"].ToString();
                textBox4.Text = dr["ogrenciSoyad"].ToString();
                textBox5.Text = dr["cinsiyet"].ToString();
                textBox7.Text = dr["babaAd"].ToString();
                textBox8.Text = dr["anneAd"].ToString();
                textBox9.Text = dr["dogumYeri"].ToString();
                textBox10.Text = dr["email"].ToString();
                textBox11.Text = dr["telNo1"].ToString();
                textBox12.Text = dr["telNo2"].ToString();
                textBox13.Text = dr["dogumTarih"].ToString();
                richTextBox1.Text = dr["adres"].ToString();

               
            }

            baglanti.Close();
            
        }
       


        private void dERSLİSTESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            groupBox1.Hide();
            groupBox2.Show();
            groupBox3.Hide();
            groupBox4.Hide();

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select dersID,dersAdi,dersAKTS from ogrenciTbl2 where ogrenciNo='" + label1.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["dersID"].ToString());
                kayit.SubItems.Add(dr["dersAdi"].ToString());
                kayit.SubItems.Add(dr["dersAKTS"].ToString());
               
                listView1.Items.Add(kayit);

               
               
            }

            baglanti.Close();
            
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

       

        private void mESAJLARIMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dANIŞMANBİLGİLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //frm1.Show();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Show();
            groupBox4.Hide();


             SqlConnection baglanti = new SqlConnection();
             baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
             SqlCommand cmd = new SqlCommand("Select danısmanNo,dansmanAdi,email from danısmanTbl where ogrenciNo='" + textBox18.Text+ "'", baglanti);
             SqlDataReader dr;
             baglanti.Open();
             dr = cmd.ExecuteReader();
             listView2.Items.Clear();
             while (dr.Read())
             {
                 ListViewItem kayit = new ListViewItem(dr["danısmanNo"].ToString());
                 kayit.SubItems.Add(dr["dansmanAdi"].ToString());
                 kayit.SubItems.Add(dr["email"].ToString());


                 listView2.Items.Add(kayit);

            
             }
            
         }

        private void hARÇBİLGİLERİToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Show();
      
            
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select harcDurum,harcMiktar from  harcTbl where ogrenciNo='" + textBox17.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            listView3.Items.Clear();
            while (dr.Read())
            {
                ListViewItem kayit = new ListViewItem(dr["harcDurum"].ToString());
                kayit.SubItems.Add(dr["harcMiktar"].ToString());
               

                listView3.Items.Add(kayit);

            }

            
        }

         

        private void aNASAYFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnaEkran yeniSayfa = new AnaEkran();
            yeniSayfa.Show();
        }

        private void şİFREDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2.Show();
            frm2.textBox4.Text = label1.Text;
           

        }

        private void yENİMESAJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar frmMesajlar = new Mesajlar();
            frmMesajlar.Show();
            frmMesajlar.textBox1.Text = label1.Text;
            frmMesajlar.groupBox1.Show();
            frmMesajlar.groupBox2.Hide();
            frmMesajlar.groupBox3.Hide();

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select ogrenciAd,ogrenciSoyad from ogrenciTbl1 where ogrenciNo='" + textBox18.Text + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                frmMesajlar.textBox3.Text = dr["ogrenciAd"].ToString() + dr["ogrenciSoyad"].ToString();


            }
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void gELENKUTUSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar frmMesajlar = new Mesajlar();
            frmMesajlar.Show();
          
            frmMesajlar.groupBox2.Show();
            frmMesajlar.groupBox1.Hide();
            frmMesajlar.groupBox3.Hide();
            

            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select  gonderenId,gonderenAd,mesaj from KisiyeMesajTbl  where aliciId ='" + textBox14.Text + "'", SqlCnn);
            dt = new DataTable();
            SqlCnn.Open();
            SqlScb = new SqlCommandBuilder(SqlDap);
            frmMesajlar.dataGridView1.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            frmMesajlar.dataGridView1.DataSource = dt;


            frmMesajlar.dataGridView1.Columns[0].HeaderText = "GÖNDEREN KİŞİ ID";
            frmMesajlar.dataGridView1.Columns[0].Width = 130;
            frmMesajlar.dataGridView1.Columns[1].HeaderText = "GÖNDEREN KİŞİ";
            frmMesajlar.dataGridView1.Columns[1].Width = 128;
            frmMesajlar.dataGridView1.Columns[2].HeaderText = "MESAJ";
            frmMesajlar.dataGridView1.Columns[2].Width = 725;

            SqlCnn.Close();

            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            
        }

        private void gİDENKUTUSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mesajlar frmMesajlar = new Mesajlar();
            frmMesajlar.Show();
            frmMesajlar.groupBox3.Show();
            frmMesajlar.groupBox1.Hide();
            frmMesajlar.groupBox2.Hide();
          

            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select  aliciId,mesaj from KisiyeMesajTbl where gonderenId ='" + textBox15.Text + "'", SqlCnn);
            dt = new DataTable();
            SqlScb = new SqlCommandBuilder(SqlDap);
            frmMesajlar.dataGridView2.Columns.Clear();
            SqlScb.DataAdapter.Fill(dt);
            frmMesajlar.dataGridView2.DataSource = dt;

            
            frmMesajlar.dataGridView2.Columns[0].HeaderText = "ALICI KİŞİ";
            frmMesajlar.dataGridView2.Columns[0].Width = 175; 
            frmMesajlar.dataGridView2.Columns[1].HeaderText = "MESAJ";
            frmMesajlar.dataGridView2.Columns[1].Width = 763;

            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
           
        }

        private void şİFREDEĞİŞTİRToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Sifre yeniSayfa = new Sifre();
            yeniSayfa.Show();

            yeniSayfa.textBox4.Text = label1.Text;
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void yARIYILNOTDURUMUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotDurumu frmNot = new NotDurumu();
            frmNot.Show();

            frmNot.textBox1.Text = label1.Text;
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void bÖLÜMBİLGİLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BolumBilgileri yeni = new BolumBilgileri();
            yeni.Show();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void bELGEİSTEKLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Belgeİstek yeni = new Belgeİstek();

            yeni.textBox3.Text = textBox14.Text;
            yeni.Show();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void gENELNOTDURUMUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotDurumu frmNot = new NotDurumu();
            frmNot.Show();

            frmNot.textBox1.Text = label1.Text;
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();

        }

        private void aNASAYFAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AnaEkran yeniSayfa = new AnaEkran();
            yeniSayfa.Show();
        }

       

    }
}
