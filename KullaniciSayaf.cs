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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();

        private void pROFİLİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();


            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("Select dersID,dersAdi,ad,soyad,email,telefon,adres from Kullanici where id='" + textBox5.Text + "'", baglanti);
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
        }

        private void öĞRENCİLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            


            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select DISTINCT ogrenciNo,ogrenciAd,ogrenciSoyAd,vize,final,ortalama from Table_1 where ogrenciFakulte ='" + comboBox1.Text + "'and ogrenciBolum='" + comboBox2.Text + "'and ogrenciSinif='" + comboBox3.Text + "' and dersID='" + textBox5.Text + "'", SqlCnn);
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

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide(); 
            groupBox3.Hide();
            groupBox4.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();

            
            SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
            SqlDap = new SqlDataAdapter("Select DISTINCT ogrenciNo,ogrenciAd,ogrenciSoyAd,vize,final,ortalama from Table_1 where ogrenciFakulte ='" + comboBox1.Text + "'and ogrenciBolum='" + comboBox2.Text + "'and ogrenciSinif='" + comboBox3.Text + "' and dersID='" +textBox5.Text+"'", SqlCnn);
            dt = new DataTable();
            SqlScb = new SqlCommandBuilder(SqlDap);
            SqlScb.DataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox4.Show();
            groupBox1.Hide();
            groupBox2.Show(); 
            groupBox3.Hide();


            SqlConnection baglan = new SqlConnection();
            baglan.ConnectionString = "Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True";
            SqlCommand komut = new SqlCommand("Select  ogrenciAd,ogrenciSoyAd from ogrenciTbl where ogrenciNo='" + textBox6.Text + "'", baglan);
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
        
    }
}