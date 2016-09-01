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
    public partial class frmSistemGiris : Form
    {   String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmSistemGiris()
        {  InitializeComponent(); }

        private void btnGiris_Click(object sender, EventArgs e)
        {   if (cmbRol.Text == "")
            {   MessageBox.Show("Lütfen kullanıcı rolünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRol.Focus();
                return; }

            if (txtKullaniciAd.Text == "")
            {   MessageBox.Show("Lütfen kullanıcı adını giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKullaniciAd.Focus();
                return; }

            if (txtSifre.Text == "")
            {   MessageBox.Show("Lütfen şifreyi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Focus();
                return; }

            try
            {   OleDbConnection myConnection = default(OleDbConnection);
                myConnection = new OleDbConnection(cs);
                OleDbCommand myCommand = default(OleDbCommand);
                myCommand = new OleDbCommand("select Rol, KullaniciAd,KullaniciSifre from Kullanicilar where Rol = @kullaniciRol AND KullaniciAd = @kullaniciAd and KullaniciSifre = @kullaniciSifre", myConnection);
                OleDbParameter kRol = new OleDbParameter("@kullaniciRol", OleDbType.VarChar);
                OleDbParameter kAd = new OleDbParameter("@kullaniciAd", OleDbType.VarChar);
                OleDbParameter kSifre = new OleDbParameter("@kullaniciSifre", OleDbType.VarChar);
                kRol.Value = cmbRol.Text;
                kAd.Value = txtKullaniciAd.Text;
                kSifre.Value = txtSifre.Text;
                myCommand.Parameters.Add(kRol);
                myCommand.Parameters.Add(kAd);
                myCommand.Parameters.Add(kSifre);
                myCommand.Connection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {   this.Hide();
                    frmAnasayfa frm = new frmAnasayfa();
                    frm.Show();
                    frm.Kullanici.Text = cmbRol.Text;
                    if (cmbRol.SelectedItem == "Yönetici") frm.devredısı();
                    if (cmbRol.SelectedItem == "Çalışan") frm.devredısı1();  }

                else
                {   MessageBox.Show("Giriş Başarısız.\nRol ve Kullanıcı adı ve şifresini kontrol ediniz!", "Giriş Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKullaniciAd.Clear();
                    txtSifre.Clear();
                    cmbRol.Enabled = true;
                    cmbRol.Focus();  }

                if (myConnection.State == ConnectionState.Open)
                {  myConnection.Dispose(); } }
           
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }  }

        private void btnCıkıs_Click(object sender, EventArgs e)
        { Close(); }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   this.Hide();
            frmSifreDegistir frm = new frmSifreDegistir();
            frm.Show();
            frm.txtKullaniciAdi.Text = "";
            frm.txtYeniSifre.Text = "";
            frm.txtEskiSifre.Text = "";
            frm.txtSifreTekrar.Text = ""; }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   this.Hide();
            frmSifremiUnuttum frm = new frmSifremiUnuttum();
            frm.txtEmail.Focus();
            frm.Show();  } } }
