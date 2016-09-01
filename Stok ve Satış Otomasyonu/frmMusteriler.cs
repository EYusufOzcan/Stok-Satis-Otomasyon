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
    public partial class frmMusteriler : Form
    {
        OleDbDataReader rdr = null;
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmMusteriler()
        { InitializeComponent(); }

        private void Sıfırla()
        {   txtAdres.Text = ""; txtİlce.Text = "";  txtEmail.Text = ""; 
            txtFaksNo.Text = ""; txtMusteriAd.Text = ""; txtCepTel.Text = ""; 
            txtNot.Text = ""; txtEvTel.Text = ""; txtMusteriID.Text = "";
            txtPostaKodu.Text = ""; cmbİl.Text = ""; btnKaydet.Enabled = true;
            btnSil.Enabled = false; btnGuncelle.Enabled = false; txtMusteriAd.Focus(); }

        private void MusteriNo_ata()
        { txtMusteriID.Text = "M-" + Sayı_olustur(6); }

        public static string Sayı_olustur(int maxSize)
        {   char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length)]); }
            return result.ToString(); }

        private void txtPostaKodu_Validating(object sender, CancelEventArgs e)
        {   if (txtPostaKodu.TextLength > 5)
            {   MessageBox.Show("Sadece 5 basamaklı sayı giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostaKodu.Focus(); } }

        private void txtPostaKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else
            { e.Handled = true; } }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (txtCepTel.TextLength > 11)
            {   MessageBox.Show("Sadece 11 basamaklı sayı giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCepTel.Focus(); }  }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {   e.Handled = false; }
            else
            {   e.Handled = true;  } }

        private void btnYeni_Click(object sender, EventArgs e)
        {  Sıfırla();  }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtMusteriAd.Text == "")
            {   MessageBox.Show("Lütfen müşterinin adını ve soyadını giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMusteriAd.Focus();
                return; }
           
            if (txtAdres.Text == "")
            {   MessageBox.Show("Lütfen adres giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdres.Focus();
                return; }

            if (txtİlce.Text == "")
            {   MessageBox.Show("Lütfen ilçe bilgisini giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtİlce.Focus();
                return; }

            if (cmbİl.Text == "")
            {   MessageBox.Show("Lütfen ili seçiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbİl.Focus();
                return; }

            if (txtPostaKodu.Text == "")
            {   MessageBox.Show("Lütfen posta kodunu giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPostaKodu.Focus();
                return; }

            if (txtCepTel.Text == "")
            {   MessageBox.Show("Lütfen cep numarasını giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCepTel.Focus();
                return; }

            try
            {   MusteriNo_ata();
                con = new OleDbConnection(cs);
                con.Open();
                string ct = "select MusteriID from Musterı where MusteriID=@bul";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new OleDbParameter("@bul", System.Data.OleDb.OleDbType.VarChar, 20, "MusteriID"));
                cmd.Parameters["@bul"].Value = txtMusteriID.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {  MessageBox.Show("Bu müşteri ID'si zaten var.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if ((rdr != null))
                    {  rdr.Close();  } }

                else
                {   con = new OleDbConnection(cs);
                    con.Open();
                    string cb = " insert into Musterı(MusteriID, MusteriAdSoyad, Adres, İl, İlce, PostaKodu, EvTel, CepTel, FaksNo, Email, NotB ) VALUES (@d1, @d2, @d3, @d4, @d5, @d6, @d7, @d8, @d9, @d10, @d11)";
                    cmd = new OleDbCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new OleDbParameter("@d1", System.Data.OleDb.OleDbType.VarChar, 20, "MusteriID"));
                    cmd.Parameters.Add(new OleDbParameter("@d2", System.Data.OleDb.OleDbType.VarChar, 50, "MusteriAdSoyad"));
                    cmd.Parameters.Add(new OleDbParameter("@d3", System.Data.OleDb.OleDbType.VarChar, 250, "Adres"));
                    cmd.Parameters.Add(new OleDbParameter("@d4", System.Data.OleDb.OleDbType.VarChar, 50, "İl"));
                    cmd.Parameters.Add(new OleDbParameter("@d5", System.Data.OleDb.OleDbType.VarChar, 50, "İlce"));
                    cmd.Parameters.Add(new OleDbParameter("@d6", System.Data.OleDb.OleDbType.VarChar, 10, "PostaKodu"));
                    cmd.Parameters.Add(new OleDbParameter("@d7", System.Data.OleDb.OleDbType.VarChar, 15, "EvTel"));
                    cmd.Parameters.Add(new OleDbParameter("@d8", System.Data.OleDb.OleDbType.VarChar,15, "CepTel" ));
                    cmd.Parameters.Add(new OleDbParameter("@d9", System.Data.OleDb.OleDbType.VarChar, 15, "FaksNo"));
                    cmd.Parameters.Add(new OleDbParameter("@d10", System.Data.OleDb.OleDbType.VarChar, 150, "Email"));
                    cmd.Parameters.Add(new OleDbParameter("@d11", System.Data.OleDb.OleDbType.VarChar, 250, "NotB"));
                    cmd.Parameters["@d1"].Value = txtMusteriID.Text;
                    cmd.Parameters["@d2"].Value = txtMusteriAd.Text;    
                    cmd.Parameters["@d3"].Value = txtAdres.Text;
                    cmd.Parameters["@d4"].Value = cmbİl.Text;
                    cmd.Parameters["@d5"].Value = txtİlce.Text;                
                    cmd.Parameters["@d6"].Value = txtPostaKodu.Text;
                    cmd.Parameters["@d7"].Value = txtEvTel.Text;
                    cmd.Parameters["@d8"].Value = txtCepTel.Text;
                    cmd.Parameters["@d9"].Value = txtFaksNo.Text;
                    cmd.Parameters["@d10"].Value = txtEmail.Text;
                    cmd.Parameters["@d11"].Value = txtNot.Text;
                    cmd.ExecuteReader();
                    MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Müşteri Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnKaydet.Enabled = false;
                    if (con.State == ConnectionState.Open)
                    {  con.Close(); }
                    con.Close(); }
                txtMusteriAd.Text = ""; txtAdres.Text = ""; txtİlce.Text = "";
                cmbİl.Text = ""; txtEvTel.Text = ""; txtPostaKodu.Text = "";
                txtEmail.Text = ""; txtCepTel.Text="";  txtFaksNo.Text="";
                txtNot.Text = "";  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Kayıt_sil()
        {   try
            { int Etki = 0;
              con = new OleDbConnection(cs);
              con.Open();
              string cq = "delete from Musterı where MusteriID=@sil1;";
              cmd = new OleDbCommand(cq);
              cmd.Connection = con;
              cmd.Parameters.Add(new OleDbParameter("@sil1", System.Data.OleDb.OleDbType.VarChar, 20, "MusteriID"));
              cmd.Parameters["@sil1"].Value = txtMusteriID.Text;
                Etki = cmd.ExecuteNonQuery();

                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }

                else
                {   MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                    con.Close();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }  }

        private void btnSil_Click(object sender, EventArgs e)
        {   try
            {   if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Müşteri Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {  Kayıt_sil();  }  }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void txtFaksNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else
            { e.Handled = true; } }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else
            {   e.Handled = true; }  }

        private void Button2_Click(object sender, EventArgs e)
        {   this.Hide();
            frmMusteriListe2 frm = new frmMusteriListe2();
            frm.Show();
            frm.VeriAl(); }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "update Musterı set MusteriAdSoyad = '" + txtMusteriAd.Text + "', Adres= '" + txtAdres.Text + "', İlce= '" + txtİlce.Text + "',İl= '" + cmbİl.Text + "',PostaKodu= '" + txtPostaKodu.Text + "',EvTel= '" + txtEvTel.Text + "',Email= '" + txtEmail.Text + "',CepTel= '" + txtCepTel.Text + "',FaksNo= '" + txtFaksNo.Text + "', NotB= '" + txtNot.Text + "' where MusteriID= '" + txtMusteriID.Text + "'";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Müşteri Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuncelle.Enabled = false;
                if (con.State == ConnectionState.Open)
                { con.Close(); }
                con.Close(); }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } } } }
