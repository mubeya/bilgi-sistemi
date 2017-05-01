using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulOtomasyon
{
   
    public partial class AnaEkran : Form
   {
        public AnaEkran()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelGiris yeniSayfa = new PersonelGiris();
            yeniSayfa.Show();

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Forum yeniSayfa = new Forum();
            yeniSayfa.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciGiris yeniSayfa = new OgrenciGiris();
            yeniSayfa.Show();
        }
    }
}
