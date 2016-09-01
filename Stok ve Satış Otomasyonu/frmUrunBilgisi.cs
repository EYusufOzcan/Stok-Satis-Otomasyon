using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmUrunBilgisi : Form
    {
        OleDbDataReader rdr = null;
        DataTable dtable = new DataTable();
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        DataTable dt = new DataTable();
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmUrunBilgisi()
        {  InitializeComponent(); }

        public void Combo_doldur()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string ct = "select RTRIM(UrunAd) from Urun order by UrunAd";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {  cmbUrunAdi.Items.Add(rdr[0]);  }
                con.Close();  }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }  }

        private void frmUrunBilgisi_Load(object sender, EventArgs e)
        {  Combo_doldur();  }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUrunAdi.Text == "")
            {   MessageBox.Show("Lütfen ürün seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUrunAdi.Focus();
                return;  }

            if (txtFiyat.Text == "")
            {   MessageBox.Show("Lütfen fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFiyat.Focus();
                return;  }

            try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "insert into UrunBilgileri(UrunAd,Ozellikler,Fiyat,Resim) values ('" + cmbUrunAdi.Text + "','" + txtOzellik.Text + "'," + txtFiyat.Text + ",@d1)";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                OleDbParameter p = new OleDbParameter("@d1", OleDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Enabled = false; }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }  }

        private void Sıfırla()
        {   txtFiyat.Text = ""; txtOzellik.Text = ""; cmbUrunAdi.Text = "";
            btnSil.Enabled = false; btnGuncelle.Enabled = false; btnKaydet.Enabled = true;
            pictureBox1.Image = null; pictureBox1.Image = Properties.Resources._12;
            cmbUrunAdi.Focus(); }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Kayıt_sil();  }  }

        private void Kayıt_sil()
        {   try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from UrunBilgileri where UrunID=" + txtUrunID.Text + "";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();  }
                else
                {   MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                if (con.State == ConnectionState.Open)
                {  con.Close(); } }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnYeni_Click(object sender, EventArgs e)
        {  Sıfırla(); }

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {  e.Handled = false; }

            else
            {  e.Handled = true; } }

        private void btnVeriler_Click(object sender, EventArgs e)
        {   this.Hide();
            frmUrunKayitListe1 frm = new frmUrunKayitListe1();
            frm.Show();
            frm.GetData(); }

        private void btnResimYukleme_Click(object sender, EventArgs e)
        {   try
            {   var _with1 = openFileDialog1;
                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {  pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); } }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "update UrunBilgileri set UrunAd='" + cmbUrunAdi.Text + "',Ozellikler='" + txtOzellik.Text + "',Fiyat=" + txtFiyat.Text + ",Resim=@d1 where UrunID=" + txtUrunID.Text + "";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                OleDbParameter p = new OleDbParameter("@d1", OleDbType.VarBinary);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuncelle.Enabled = false; }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } } } }
