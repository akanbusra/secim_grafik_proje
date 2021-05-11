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

namespace veritabanı_seçim_istatistik_proje
{
    public partial class vtg : Form
    {
        public vtg()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafik fr = new FrmGrafik();
            fr.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLİLCE (ILCEAD,APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtA.Text);
            komut.Parameters.AddWithValue("@p3", TxtB.Text);
            komut.Parameters.AddWithValue("@p4", TxtC.Text);
            komut.Parameters.AddWithValue("@p5", TxtD.Text);
            komut.Parameters.AddWithValue("@p6", TxtE.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("OY GİRİŞİ GERÇEKLEŞTİ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtAd.Text = " ";
            TxtA.Text = " ";
            TxtB.Text = " ";
            TxtC.Text = " ";
            TxtD.Text = " ";
            TxtE.Text = " ";
        }

        private void vtg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBSECIMPROJEDataSet.TBLİLCE' table. You can move, or remove it, as needed.
            this.tBLİLCETableAdapter.Fill(this.dBSECIMPROJEDataSet.TBLİLCE);

        }
    }
}
