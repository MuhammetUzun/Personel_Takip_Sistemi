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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();  
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FSDSBO3\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void label4_Click(object sender, EventArgs e)
        {

        }
        /*void kapat()
        {
            //Frmistatistik.Close();
        }*/
         
        private void Frmistatistik_Load(object sender, EventArgs e)
        {//PERSONEL SAYISI;
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select Count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                ToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" select Count(*) from Tbl_Personel where PerDurum =1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                ToplamEvli.Text=dr2[0].ToString();
            }
            baglanti.Close();

            //TOPLAM BEKAR;
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand(" select Count(*) from Tbl_Personel where PerDurum =0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                Toplambekar.Text = dr3[0].ToString();
            }
            baglanti.Close();

           //FARKLI ŞEHİR SAYISI;
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand(" select count(distinct(Persehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                ToplamSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //TOPLAM MAAS;
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select SUM(PerMaas) from Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                ToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAS;
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select AVG(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                OrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Frmistatistik_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
