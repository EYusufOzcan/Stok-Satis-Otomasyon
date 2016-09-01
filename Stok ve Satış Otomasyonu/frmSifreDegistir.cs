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
    public partial class frmSifreDegistir : Form
    {
       
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmSifreDegistir()
        { InitializeComponent();  }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                int Etki = 0;
                if ((txtKullaniciAdi.Text.Trim().Length == 0))
                {   MessageBox.Show("Lütfen kullanıcı adını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAdi.Focus();
                    return; }

                if ((txtEskiSifre.Text.Trim().Length == 0))
                {    MessageBox.Show("Lütfen eski şifreyi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEskiSifre.Focus();
                    return; }

                if ((txtYeniSifre.Text.Trim().Length == 0))
                {   MessageBox.Show("Lütfen yeni şifreyi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Focus();
                    return; }

                if ((txtSifreTekrar.Text.Trim().Length == 0))
                {   MessageBox.Show("Lütfen şifrenin tekrarını giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSifreTekrar.Focus();
                    return; }

                if ((txtYeniSifre.TextLength < 5))
                {   MessageBox.Show("Yeni şifre en az 5 karakter boyutunda olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Text = "";
                    txtSifreTekrar.Text = "";
                    txtYeniSifre.Focus();
                    return; }

                else if ((txtYeniSifre.Text != txtSifreTekrar.Text))
                {   MessageBox.Show("Şifre ve şifre tekrarı aynı değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Text = "";
                    txtEskiSifre.Text = "";
                    txtSifreTekrar.Text = "";
                    txtEskiSifre.Focus();
                    return; }

                else if ((txtEskiSifre.Text == txtYeniSifre.Text))
                {   MessageBox.Show("Eski şifre ile yeni şifre aynı.\nYeni bir şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Text = "";
                    txtSifreTekrar.Text = "";
                    txtYeniSifre.Focus();
                    return;  }
              
                con = new OleDbConnection(cs);
                con.Open();
                string co = "Update Kullanicilar set KullaniciSifre = '" + txtYeniSifre.Text + "'where KullaniciAd='" + txtKullaniciAdi.Text + "' and KullaniciSifre = '" + txtEskiSifre.Text + "'";

                cmd = new OleDbCommand(co);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if ((Etki > 0))
                {   MessageBox.Show("Başarılı bir şekilde değiştirildi.", "Şifre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    txtKullaniciAdi.Text = "";
                    txtYeniSifre.Text = "";
                    txtEskiSifre.Text = "";
                    txtSifreTekrar.Text = "";
                    frmSistemGiris Kayıt = new frmSistemGiris();
                    Kayıt.Show();
                    Kayıt.txtKullaniciAd.Text = "";
                    Kayıt.txtSifre.Text = "";
                    Kayıt.ProgressBar1.Visible = false;
                    Kayıt.txtKullaniciAd.Focus(); }

                else
                {   MessageBox.Show("Geçersiz kullanıcı adı veya şifresi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAdi.Text = "";
                    txtYeniSifre.Text = "";
                    txtEskiSifre.Text = "";
                    txtSifreTekrar.Text = "";
                    txtKullaniciAdi.Focus();  }

                if ((con.State == ConnectionState.Open))
                { con.Close();  }
                con.Close(); }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void frmSifreDegistir_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmSistemGiris frm = new frmSistemGiris();
            frm.txtKullaniciAd.Text = "";
            frm.txtSifre.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.txtKullaniciAd.Focus();
            frm.Show(); } } }
