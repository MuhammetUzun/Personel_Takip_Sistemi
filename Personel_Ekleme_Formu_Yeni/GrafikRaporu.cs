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

namespace Personel_Ekleme_Formu_Yeni
{
    public partial class GrafikRaporu : Form
    {
        public GrafikRaporu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FSDSBO3\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void GrafikRaporu_Load(object sender, EventArgs e)
        {
            //ŞEHİRLERDE YAŞAYAN İNSANLARIN RAPOR GRAFİĞİ
            baglanti.Open();
            SqlCommand grafik1 = new SqlCommand(" select Persehir,COUNT(*) from Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader gr1 = grafik1.ExecuteReader();
            while (gr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(gr1[0], gr1[1]);
            }
            baglanti.Close();


            //MESLEKLERE GÖRE ORTALAMA MAAŞ RAPOR GRAFİĞİ
            baglanti.Open();
            SqlCommand grafik2 = new SqlCommand("select PerMeslek,avg(PerMaas) from Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader gr2 = grafik2.ExecuteReader();
            while (gr2.Read())
            {
                chart2.Series["Meslek - Maas"].Points.AddXY(gr2[0], gr2[1]);
            }
            baglanti.Close();




        }

        private void GrafikRaporu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
