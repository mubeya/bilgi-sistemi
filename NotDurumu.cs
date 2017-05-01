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
    public partial class NotDurumu : Form
    {
        public NotDurumu()
        {
            InitializeComponent();
        }

        SqlConnection SqlCnn = new SqlConnection();
        SqlDataAdapter SqlDap = new SqlDataAdapter();
        SqlCommandBuilder SqlScb = new SqlCommandBuilder();
        DataTable dt = new DataTable();


        private void NotDurumu_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Show();
            textBox1.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            groupBox1.Show();
            groupBox2.Hide();

            if (comboBox1.Text == "GÜZ YARIYILI")
            {
                SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
                SqlDap = new SqlDataAdapter("Select  dersAdi,vize,final,ortalama  FROM ogrenciTbl2 WHERE ogrenciNo='" + textBox1.Text + "'", SqlCnn);
                dt = new DataTable();
                SqlCnn.Open();
                SqlScb = new SqlCommandBuilder(SqlDap);
                dataGridView1.Columns.Clear();
                SqlScb.DataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;


                dataGridView1.Columns[0].HeaderText = "DERS ";
                dataGridView1.Columns[0].Width = 215;
                dataGridView1.Columns[1].HeaderText = "VİZE";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "FİNAL";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "ORTALAMA";
                dataGridView1.Columns[3].Width = 150;


                SqlCnn.Close(); 

             }


            if (comboBox1.Text == "BAHAR YARIYILI")
            {
                SqlCnn = new SqlConnection("Data Source=PC-HP\\SQLEXPRESS;Initial Catalog=okulOtomasyon;Integrated Security=True");
                SqlDap = new SqlDataAdapter("Select  dersAdi,vize,final,ortalama  FROM ogrenciTbl2 WHERE ogrenciNo='" + textBox1.Text + "'", SqlCnn);
                dt = new DataTable();
                SqlCnn.Open();
                SqlScb = new SqlCommandBuilder(SqlDap);
                dataGridView1.Columns.Clear();
                SqlScb.DataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;


                dataGridView1.Columns[0].HeaderText = "DERS ";
                dataGridView1.Columns[0].Width = 230;
                dataGridView1.Columns[1].HeaderText = "VİZE";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "FİNAL";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].HeaderText = "ORTALAMA";
                dataGridView1.Columns[3].Width = 150;


                SqlCnn.Close();

            }

         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       }

}
