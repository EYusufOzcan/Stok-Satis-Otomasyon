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
    public partial class frmAnasayfa : Form
    {   OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmAnasayfa()
        { InitializeComponent(); }

        public void devredısı()
        {   btnKullaniciYönet.Enabled = false;
            btnKullanicilar.Enabled = false;  }

        public void devredısı1()
        {   btnKullaniciYönet.Enabled = false;
            btnKullanicilar.Enabled = false;
            faturaToolStripMenuItem.Enabled = false;
            btnFatura.Enabled = false; }

        private void musterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {   frmMusteriListe frm = new frmMusteriListe();  frm.Show(); }

        private void urunlerToolStripMenuItem_Click(object sender, EventArgs e)
        {   frmUrunAramaListe frm = new frmUrunAramaListe();  frm.Show(); }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {   this.Hide();
            frmSistemGiris frm = new frmSistemGiris();
            frm.Show();
            frm.txtKullaniciAd.Text = "";
            frm.txtSifre.Text = "";
            frm.ProgressBar1.Visible = false;
            frm.txtKullaniciAd.Focus(); }

        private void frmAnaMenü_Load(object sender, EventArgs e)
        {   ToolStripStatusLabel4.Text = System.DateTime.Now.ToString(); }

        private void timer1_Tick(object sender, EventArgs e)
        {  ToolStripStatusLabel4.Text = System.DateTime.Now.ToString(); }

        private void stokToolStripMenuItem_Click(object sender, EventArgs e)
        {   frmStokKayitListe frm = new frmStokKayitListe();
            frm.Show(); }

        private void faturaToolStripMenuItem_Click(object sender, EventArgs e)
        {   this.Hide();
            frmFatura frm = new frmFatura();
            frm.label6.Text = Kullanici.Text;
            frm.Show(); }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {   frmMusteriler frm = new frmMusteriler();
            frm.Show(); }

        private void btnKategori_Click(object sender, EventArgs e)
        {   frmKategori frm = new frmKategori();
            frm.Show(); }

        private void btnFirma_Click(object sender, EventArgs e)
        {   frmMarka frm = new frmMarka(); frm.Show(); }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {   frmUrun frm = new frmUrun(); frm.Show(); }

        private void btnUrunOzellikleri_Click(object sender, EventArgs e)
        {   frmUrunBilgisi frm = new frmUrunBilgisi(); frm.Show(); }

        private void Button3_Click(object sender, EventArgs e)
        {   frmSistemKullaniciListesi frm = new frmSistemKullaniciListesi(); frm.Show(); }

        private void btnKullaniciYönet_Click(object sender, EventArgs e)
        {   frmKullaniciKayit frm = new frmKullaniciKayit();
            frm.Show(); }

        private void btnStok_Click(object sender, EventArgs e)
        {   this.Hide();
            frmStok frm = new frmStok();
            frm.label8.Text = Kullanici.Text;
            frm.Show(); }

        private void btnSatis_Click(object sender, EventArgs e)
        {   this.Hide(); frmFatura frm = new frmFatura();
            frm.label6.Text = Kullanici.Text; frm.Show(); }

        private void btnFatura_Click(object sender, EventArgs e)
        {   this.Hide();  frmFatura frm = new frmFatura();
            frm.label6.Text = Kullanici.Text;  frm.Show(); }

        private void btnStokAra_Click(object sender, EventArgs e)
        {   frmStokListe frm = new frmStokListe(); frm.Show(); }

        //private void btnMusteriRaporu_Click(object sender, EventArgs e)
        //{   try
        //    {   Cursor = Cursors.WaitCursor;
        //        timer1.Enabled = true;
        //        //rprMusteri rpt = new rprMusteri();
        //        cmd = new OleDbCommand();
        //        OleDbDataAdapter myDA = new OleDbDataAdapter();
        //        dtsVeritabanı myDS = new dtsVeritabanı();
        //        con = new OleDbConnection(cs);
        //        cmd.Connection = con;
        //        cmd.CommandText = "select * from Musterı order by MusteriAdSoyad";
        //        cmd.CommandType = CommandType.Text;
        //        myDA.SelectCommand = cmd;
        //        myDA.Fill(myDS, "Musterı");
                //rpt.SetDataSource(myDS);
                //frmMusteriRapor frm = new frmMusteriRapor();
                //frm.crystalReportViewer1.ReportSource = rpt;
                //frm.crystalReportViewer1.RefreshReport();
                //frm.Visible = true;  }

            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {   frmSatisKayitListe frm = new frmSatisKayitListe();
            frm.ShowDialog(); }

        private void notepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {   System.Diagnostics.Process.Start("Notepad.exe"); }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {   System.Diagnostics.Process.Start("Calc.exe");  }

        private void wordpadToolStripMenuItem1_Click(object sender, EventArgs e)
        {   System.Diagnostics.Process.Start("Wordpad.exe"); }

        private void görevYöneticisiToolStripMenuItem_Click(object sender, EventArgs e)
        {   System.Diagnostics.Process.Start("TaskMgr.exe"); }

        private void mSWordToolStripMenuItem1_Click(object sender, EventArgs e)
        {  System.Diagnostics.Process.Start("Winword.exe"); }

    }
}
