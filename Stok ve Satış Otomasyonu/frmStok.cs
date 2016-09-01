using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;
namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmStok : Form
    {
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        OleDbDataReader rdr;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmStok()
        { InitializeComponent(); }

        private void frmStok_Load(object sender, EventArgs e)
        {  VeriAl(); }

        public static string Sayı_olustur(int maxSize)
        {   char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {  result.Append(chars[b % (chars.Length)]); }
            return result.ToString(); }

        private void StokNo_ata()
        { txtStokID.Text = "S-" + Sayı_olustur(6); }

        public void VeriAl()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select StokID as [Stok ID], (UrunAd) as [Ürün Adı],(Ozellikler) as [Özellikler] ,sum(Adet) as [Adet], Fiyat, sum(ToplamFiyat) as [Toplam Fiyat] from UrunBilgileri,Stok where UrunBilgileri.UrunID=Stok.UrunID group by StokID, UrunAd,Ozellikler,Fiyat having sum(Adet > 0)  order by UrunAd", con);
                OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Stok");
                myDA.Fill(myDataSet, "UrunBilgileri");
                dataGridView1.DataSource = myDataSet.Tables["Stok"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["UrunBilgileri"].DefaultView;
                con.Close(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void button2_Click(object sender, EventArgs e)
        {   this.Hide();
            frmUrunKayitListe frm = new frmUrunKayitListe();
            frm.label1.Text = label8.Text;
            frm.Show(); }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUrunAd.Text == "")
            {   MessageBox.Show("Lütfen ürün adını seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUrunAd.Focus();
                return; }

            if (txtAdet.Text == "")
            {   MessageBox.Show("Lütfen adeti giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdet.Focus();
                return; }

            try
            {  con = new OleDbConnection(cs);
               con.Open();
               String ct = "select UrunID from Stok where UrunID=" + txtUrunID.Text +"";
               cmd = new OleDbCommand(ct);
               cmd.Connection = con;
               rdr = cmd.ExecuteReader();

            if (rdr.Read()==true) 
                {  MessageBox.Show("Bu kayıt zaten var." + "\n" + "Lütfen stoktaki ürünü güncelleyiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if ((rdr != null))
                {  rdr.Close(); } 
                return;  }
                StokNo_ata();
                con = new OleDbConnection(cs);
                con.Open();
                string cb = "insert into Stok(StokID, UrunID, Adet, ToplamFiyat,StokTarih) values ('" + txtStokID.Text + "','" + txtUrunID.Text + "','" + txtAdet.Text + "','" + txtToplamFiyat.Text + "','" + dtpStokTarih.Value + "')";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Enabled = false;
                VeriAl();
                frmStokListe frm = new frmStokListe();
                frm.VeriAl(); }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {   int x1 = 0;
            int x2 = 0;
            int.TryParse(txtFiyat.Text, out x1);
            int.TryParse(txtAdet.Text, out x2);
            int I = (x1 * x2);
            txtToplamFiyat.Text = I.ToString(); }

        private void Sıfırla()
        {   txtFiyat.Text = ""; txtOzellikler.Text = ""; txtUrunAd.Text = "";
            txtAdet.Text = ""; txtToplamFiyat.Text = ""; txtStokID.Text = "";
            dtpStokTarih.Text = DateTime.Today.ToString(); txtUrun.Text = "";
            btnSil.Enabled = false; btnGuncelle.Enabled = false; btnKaydet.Enabled = true; }

        private void btnYeni_Click(object sender, EventArgs e)
        {  Sıfırla(); }

        private void btnSil_Click(object sender, EventArgs e)
        {   if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { Kayıt_sil(); } }

        private void Kayıt_sil()
        {   try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from Stok where StokID='" + txtStokID.Text + "'";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                else
                {  MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                if (con.State == ConnectionState.Open)
                { con.Close(); } }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void frmStok_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmAnasayfa frm = new frmAnasayfa();
            frm.Kullanici.Text = label8.Text;
            frm.Show(); }

        private void btnKayıtlar_Click(object sender, EventArgs e)
        {   this.Hide();
            frmStokKayitListe1 frm = new frmStokKayitListe1();
            frm.label1.Text = label8.Text;
            frm.Show();
            frm.VeriAl(); }

        private void txtUrunAd_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select StokID as [Stok ID], (UrunAd) as [Ürün Adı], (Ozellikler) as [Özellikler] ,sum(Adet) as [Adet], Fiyat, sum(ToplamFiyat) as [Toplam Fiyat] from UrunBilgileri,Stok where UrunBilgileri.UrunID=Stok.UrunID and UrunAd like '" + txtUrun.Text + "%' group by StokID, UrunAd,Ozellikler,Fiyat having sum(Adet > 0)  order by UrunAd", con);
                OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Stok");
                myDA.Fill(myDataSet, "UrunBilgileri");
                dataGridView1.DataSource = myDataSet.Tables["Stok"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["UrunBilgileri"].DefaultView;
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "Update Stok set UrunID='" + txtUrunID.Text + "',Adet='" + txtAdet.Text + "',ToplamFiyat='" + txtToplamFiyat.Text + "',StokTarih= '" + dtpStokTarih.Value + "' where StokID='" + txtStokID.Text + "'";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuncelle.Enabled = false;
                VeriAl();
                frmStokListe frm = new frmStokListe();
                frm.VeriAl(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void button1_Click(object sender, EventArgs e)
        {   this.Hide();
            frmStokKayitListe1 frm = new frmStokKayitListe1();
            frm.label1.Text = label8.Text;
            frm.Show();
            frm.VeriAl(); } } }
