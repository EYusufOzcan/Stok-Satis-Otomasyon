using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmKullaniciKayit : Form
    {
        OleDbDataReader rdr = null;
        DataTable dtable = new DataTable();
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        DataTable dt = new DataTable();
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmKullaniciKayit()
        { InitializeComponent();  }

        private void frmKullaniciKayit_Load(object sender, EventArgs e)
        { Oto_tam(); }

        private void Sıfırla()
        {   txtKullaniciAd.Text = ""; txtSifre.Text = ""; txtTel.Text = "";
            txtAdSoyad.Text = ""; txtEmail.Text = ""; btnKaydet.Enabled = true;
            btnSil.Enabled = false; btnGuncelle.Enabled = false; txtKullaniciAd.Focus(); }

        private void btnYeni_Click(object sender, EventArgs e)
        {  Sıfırla();  }

        private void btnKaydet_Click(object sender, EventArgs e)
        {   if (txtKullaniciAd.Text == "")
            {   MessageBox.Show("Lütfen kullanıcı adını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAd.Focus();
                return; }

            if (txtSifre.Text == "")
            {   MessageBox.Show("Lütfen şifreyi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Focus();
                return; }

            if (txtAdSoyad.Text == "")
            {   MessageBox.Show("Lütfen ad soyad kısmını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdSoyad.Focus();
                return; }

            if (comboRol.Text == "")
            {  MessageBox.Show("Lütfen rolü seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboRol.Focus();
                return; }
            try
            {   con = new OleDbConnection(cs);
                con.Open();
                string ct = "select KullaniciAd from Kayıt where KullaniciAd = @bul";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new OleDbParameter("@bul", System.Data.OleDb.OleDbType.VarChar, 30, "KullaniciAd"));
                cmd.Parameters["@bul"].Value = txtKullaniciAd.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Bu kullanıcı adı zaten var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAd.Text = "";
                    txtKullaniciAd.Focus();


                    if ((rdr != null))
                    {  rdr.Close(); }
                    return; }

                con = new OleDbConnection(cs);
                con.Open();

                string cb = "insert into Kayıt (Rol, KullaniciAd, KullaniciSifre, Tel, Email, AdSoyad, KayitTarih) values ('" + comboRol.Text + "','" + txtKullaniciAd.Text + "','" + txtSifre.Text + "','" + txtTel.Text + "','" + txtEmail.Text + "','" + txtAdSoyad.Text + "','" + System.DateTime.Now + "')";

                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new OleDbConnection(cs);
                con.Open();

                string cb1 = "insert into Kullanicilar (Rol, KullaniciAd, KullaniciSifre) values ('" + comboRol.Text + "','" + txtKullaniciAd.Text + "','" + txtSifre.Text + "')";
                cmd = new OleDbCommand(cb1);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Kullanıcı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                btnKaydet.Enabled = false; }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void btnKullanılabilir_Click(object sender, EventArgs e)
        {   try
            {   if (txtKullaniciAd.Text == "")
                {   MessageBox.Show("Lütfen kullanıcı adını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAd.Focus();
                    return; }

                con = new OleDbConnection(cs);
                con.Open();
                string ct = "select KullaniciAd from Kayıt where KullaniciAd='" + txtKullaniciAd.Text + "'";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {   MessageBox.Show("Bu kullanıcı adı kullanılabilir değil.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; }

                if (!rdr.Read())
                {   MessageBox.Show("Bu kullanıcı adı kullanılabilir.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKullaniciAd.Focus(); }

                if ((rdr != null))
                {  rdr.Close(); } }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Bu mail adresi geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;  } } }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {  e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space); }

        private void txtKullaniciAd_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]");
            if (txtKullaniciAd.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtKullaniciAd.Text))
                {
                    MessageBox.Show("Sadece harfler, rakamlar ve alt çizgiye izin verilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAd.SelectAll();
                    e.Cancel = true; } }  }

        private void btnKayıtlar_Click(object sender, EventArgs e)
        {   frmSistemKullanıcıBilgileri frm = new frmSistemKullanıcıBilgileri();
            frm.Show();  }

        private void txtKullaniciAd_TextChanged(object sender, EventArgs e)
        {   
            btnSil.Enabled = true;
            btnGuncelle.Enabled = true;
            try
            {
                txtKullaniciAd.Text = txtKullaniciAd.Text.TrimEnd();
                con = new OleDbConnection(cs);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select KullaniciAd, KullaniciSifre, AdSoyad, Tel, Email from Kayıt where KullaniciAd = '" + txtKullaniciAd.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {   txtSifre.Text = (rdr.GetString(1).Trim());
                    txtAdSoyad.Text = (rdr.GetString(2).Trim());
                    txtTel.Text = (rdr.GetString(3).Trim());
                    txtEmail.Text = (rdr.GetString(4).Trim());  }

                if ((rdr != null))
                { rdr.Close(); }

                if (con.State == ConnectionState.Open)
                {   con.Close();  }  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Oto_tam()
        {
            try{
            con = new OleDbConnection(cs);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select KullaniciAd from Kayıt", con);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds, "Kayıt");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            { col.Add(ds.Tables[0].Rows[i]["KullaniciAd"].ToString());  }

            txtKullaniciAd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtKullaniciAd.AutoCompleteCustomSource = col;
            txtKullaniciAd.AutoCompleteMode = AutoCompleteMode.Suggest;

            con.Close();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection(cs);
                con.Open();

                string cb = "update Kayıt set KullaniciSifre='" + txtSifre.Text + "',Tel='" + txtTel.Text + "',Email='" + txtEmail.Text + "', AdSoyad='" + txtAdSoyad.Text + "' where KullaniciAd='" + txtKullaniciAd.Text + "'";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kullanıcı Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                btnGuncelle.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {  Kayıt_sil();  }  }

        private void Kayıt_sil()
        {   try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cz1 = "select KullaniciAd from Kayıt where Rol ='Yönetim' ";
                cmd = new OleDbCommand(cz1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    MessageBox.Show("Silinemiyor." + "\n" + "Yönetim hesabı silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Oto_tam();
                    Sıfırla();

                    if ((rdr != null))
                    {  rdr.Close(); }
                    return;
                }

                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from Kayıt where KullaniciAd='" + txtKullaniciAd.Text + "'";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();

                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Oto_tam(); }

                else
                {   MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();
                    Oto_tam();  }

                if (con.State == ConnectionState.Open)
                {  con.Close(); }

                con = new OleDbConnection(cs);
                con.Open();
                string ct = "delete from Kullanicilar where KullaniciAd='" + txtKullaniciAd.Text + "'";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                { con.Close(); }
                Sıfırla(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtTel_Validating(object sender, CancelEventArgs e)
        {
            if (txtTel.TextLength > 11)
            {
                MessageBox.Show("Sadece 11 karakter uzunluğunda bir sayı giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTel.Focus(); } }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            { e.Handled = false;  }

            else
            {  e.Handled = true;  } } } }