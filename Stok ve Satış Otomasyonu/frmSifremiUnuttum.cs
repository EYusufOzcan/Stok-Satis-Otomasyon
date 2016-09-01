using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmSifremiUnuttum : Form
    {
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmSifremiUnuttum()
        {  InitializeComponent(); }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {    MessageBox.Show("Lütfen mail adresinizi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return; }

            try
            {   Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                DataSet ds = new DataSet();
                OleDbConnection con = new OleDbConnection(cs);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("select KullaniciSifre, Adsoyad from Kayıt Where Email = '" + txtEmail.Text + "'", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MailMessage Msg = new MailMessage(); 
                    Msg.From = new MailAddress("stok.satis.otomasyan@gmail.com");
                    Msg.To.Add(txtEmail.Text);
                    Msg.Subject = "Şifre Hatırlatma";
                    Msg.Body = "Sayın " + ds.Tables[0].Rows[0]["Adsoyad"] + "<br / >" + "Şifreniz: " + Convert.ToString(ds.Tables[0].Rows[0]["KullaniciSifre"]) + "";
                    Msg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("stok.satis.otomasyan@gmail.com", "deli90*-");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    MessageBox.Show(("Şifreniz başarılı gönderildi. " + ("\r\n" + "Lütfen mailinizi kontrol ediniz.")), "Teşekkürler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmSistemGiris Kayıt = new frmSistemGiris();
                    Kayıt.Show();
                    Kayıt.txtKullaniciAd.Text = "";
                    Kayıt.txtSifre.Text = "";
                    Kayıt.ProgressBar1.Visible = false;
                    Kayıt.txtKullaniciAd.Focus(); } }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void RecoveryPassword_Load(object sender, EventArgs e)
        {  txtEmail.Focus(); }

        private void frmSifreUnuttum_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmSistemGiris frm = new frmSistemGiris();
            frm.txtKullaniciAd.Text = "";
            frm.txtSifre.Text = "";
            frm.txtKullaniciAd.Focus();
            frm.Show(); }

        private void timer1_Tick(object sender, EventArgs e)
        {  Cursor = Cursors.Default;
           timer1.Enabled = false; } } }
