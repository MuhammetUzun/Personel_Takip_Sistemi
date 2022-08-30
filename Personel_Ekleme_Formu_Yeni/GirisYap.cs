using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Ekleme_Formu_Yeni
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }
        

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FSDSBO3\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            giris.Parameters.AddWithValue("@p1", textBox1.Text);
            giris.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaSayfa form2 = new FrmAnaSayfa();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı \n Tekrar Deneyin...");
            }
            baglanti.Close();

            
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {

        }

        private void GirisYap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
