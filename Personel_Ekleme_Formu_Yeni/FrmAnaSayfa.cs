using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Ekleme_Formu_Yeni
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FSDSBO3\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        void temizle()
        {//VOİD İLE TEMİZLE BUTONUNUN İŞLEVİ VERİLDİ
            txtpeersonelad.Text = null;
            txtpersonelsoyad.Text = "";
            txtmeslek.Text = "";
            txtpersonelid.Text = "";
            cmbsehir.Text = "";
            mskmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtpeersonelad.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {   // PERSONEL EKLEME BUTONU
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_personel (Perad,PerSoyad,permaas,persehir,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtpeersonelad.Text);
            komut.Parameters.AddWithValue("@p2", txtpersonelsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskmaas.Text);
            komut.Parameters.AddWithValue("@p4", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            MessageBox.Show("Personel başarıyla eklenmiştir...");

            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {   // LİSTELE BUTONU SQL TABLOMUZU DATAGRİDWİEW ÜZERİNDE GÖRÜNTÜLEME SAĞLADI
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

            temizle();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        // Hücrelere çift tıklandığında satırdaki değerleri text boxlara yansıtır.
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtpersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtpeersonelad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtpersonelsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "True")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {  //DELETE SQL KOMUTU İLE PERSONEL SİLME İŞLEMİ
            string silinecek_ad = txtpeersonelad.Text;

            baglanti.Open();
            SqlCommand sqlSil = new SqlCommand("delete from Tbl_personel where Perid=@a", baglanti);
            sqlSil.Parameters.AddWithValue("@a", txtpersonelid.Text);
            sqlSil.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show(silinecek_ad + " başarıyla silinmiştir.");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME BUTONU
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set Perad=@b1,PerSoyad=@b2,PerSehir=@b3,PerMaas=@b4,PerDurum=@b5,PerMeslek=@b6 WHERE Perid=@b7", baglanti);
            komutguncelle.Parameters.AddWithValue("@b1", txtpeersonelad.Text);
            komutguncelle.Parameters.AddWithValue("@b2", txtpersonelsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@b3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@b4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@b5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@b6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@b7", txtpersonelid.Text);
            komutguncelle.ExecuteNonQuery();
            MessageBox.Show(txtpersonelid.Text + "  " + " idli numaralı personel güncellendi ");
            baglanti.Close();
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            GrafikRaporu gr = new GrafikRaporu();
            gr.Show();
        }

        private void FrmAnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
