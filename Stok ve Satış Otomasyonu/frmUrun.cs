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
    public partial class frmUrun : Form
    {
        OleDbDataReader rdr = null;
        DataTable dtable = new DataTable();
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        DataTable dt = new DataTable();
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmUrun()
        { InitializeComponent(); }

        private void frmUrun_Load(object sender, EventArgs e)
        {  Combo_doldur(); Oto_tam(); }

        public void Combo_doldur()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string ct = "select RTRIM(KategoriAd) from Kategori order by KategoriAd";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {  cmbKategori.Items.Add(rdr[0]);  }
                con.Close();
                con = new OleDbConnection(cs);
                con.Open();
                string ct1 = "select RTRIM(MarkaAd) from Marka order by MarkaAd";
                cmd = new OleDbCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                { cmbMarka.Items.Add(rdr[0]); }
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Sıfırla()
        {   txtÜrünAd.Text = ""; cmbMarka.Text = ""; cmbKategori.Text = "";
            btnSil.Enabled = false; btnGuncelle.Enabled = false;
            btnKaydet.Enabled = true; txtÜrünAd.Focus(); }

        private void btnYeni_Click(object sender, EventArgs e)
        {   Sıfırla(); }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtÜrünAd.Text == "")
            {
                MessageBox.Show("Lütfen ürün adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtÜrünAd.Focus();
                return;
            }
            if (cmbKategori.Text == "")
            {   MessageBox.Show("Lütfen kategori seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbKategori.Focus();
                return; }

            if (cmbMarka.Text == "")
            {   MessageBox.Show("Lütfen marka seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMarka.Focus();
                return; }

            try
            {   con = new OleDbConnection(cs);
                con.Open();
                string ct = "select UrunAd from Urun where UrunAd='" + txtÜrünAd.Text + "'";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Bu ürün adı zaten var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtÜrünAd.Text = "";
                    txtÜrünAd.Focus();

                    if ((rdr != null))
                    { rdr.Close(); }
                    return; }

                con = new OleDbConnection(cs);
                con.Open();
                string cb = "insert into Urun(UrunAd,Kategori,Marka) values ('" + txtÜrünAd.Text + "','" + cmbKategori.Text+ "','" + cmbMarka.Text+ "')";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                txtÜrünAd.Text = "";
                txtÜrünAd.Focus(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnSil_Click(object sender, EventArgs e)
        {  if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { Kayıt_sil(); } }

        private void Kayıt_sil()
        {   try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from Urun where UrunAd='" + txtÜrünAd.Text + "'";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();
                    Oto_tam(); }
                else
                {   MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();
                    Oto_tam(); }

                if (con.State == ConnectionState.Open)
                {  con.Close(); } }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Oto_tam()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("select distinct UrunAd from Urun", con);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds, "Urun");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {  col.Add(ds.Tables[0].Rows[i]["UrunAd"].ToString()); }

                txtÜrünAd.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtÜrünAd.AutoCompleteCustomSource = col;
                txtÜrünAd.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "update Urun set UrunAd='" + txtÜrünAd.Text + "', Kategori='" + cmbKategori.Text + "', Marka='" + cmbMarka.Text + "' where UrunAd='" + textBox1.Text + "'";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                btnGuncelle.Enabled = false;  }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnVeriler_Click(object sender, EventArgs e)
        {   this.Hide();
            frmUrunAramaListe1 frm = new frmUrunAramaListe1();
            frm.Show();
            frm.VeriAl(); } } }
