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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");

        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("SELECT ILCEAD FROM TBLİLCE ", bgl);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlçe.Items.Add(dr[0]);
            }
            bgl.Close();

            bgl.Open();
            SqlCommand kmt = new SqlCommand("select sum(APARTİ),sum(BPARTİ),sum(CPARTİ),sum(DPARTİ),sum(EPARTİ) FROM TBLİLCE", bgl);
            SqlDataReader dr2 = kmt.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["PARTİLER"].Points.AddXY("A Partisi", dr2[0]);
                chart1.Series["PARTİLER"].Points.AddXY("B Partisi", dr2[1]);
                chart1.Series["PARTİLER"].Points.AddXY("C Partisi", dr2[2]);
                chart1.Series["PARTİLER"].Points.AddXY("D Partisi", dr2[3]);
                chart1.Series["PARTİLER"].Points.AddXY("E Partisi", dr2[4]);
            }
            bgl.Close();

        }

        private void Cmbİlçe_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand kmt = new SqlCommand("select * from TBLİLCE where ILCEAD=@P1", bgl);
            kmt.Parameters.AddWithValue("@P1", Cmbİlçe.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                progressBarA.Value = int.Parse(dr[2].ToString());
                progressBarB.Value = int.Parse(dr[3].ToString());
                progressBarC.Value = int.Parse(dr[4].ToString());
                progressBarD.Value = int.Parse(dr[5].ToString());
                progressBarE.Value = int.Parse(dr[6].ToString());

                LblA.Text = dr[2].ToString();
                LblB.Text = dr[3].ToString();
                LblC.Text = dr[4].ToString();
                LblD.Text = dr[5].ToString();
                LblE.Text = dr[6].ToString();
            }
            bgl.Close();
        }
    }
}
