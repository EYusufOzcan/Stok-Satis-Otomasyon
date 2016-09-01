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
//using CrystalDecisions.Shared;
//using CrystalDecisions.CrystalReports.Engine;
namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmFatura : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader rdr;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmFatura()
        {  InitializeComponent(); }

        private void FaturaNo_Ata()
        { txtFaturaNo.Text = "FTR-" + Sayı_olustur(8); }

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
            { result.Append(chars[b % (chars.Length)]);  }
            return result.ToString();  }

        private void btnKaydet_Click(object sender, EventArgs e)
        {   try
            {   if (txtMusteriID.Text == "")
                {   MessageBox.Show("Lütfen müşteri ID seçiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMusteriID.Focus();
                    return; }

                if (txtKDVYüzde.Text == "")
                {   MessageBox.Show("Lütfen KDV yüzdesini giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKDVYüzde.Focus();
                    return; }

                if (txtToplamÖdenen.Text == "")
                {   MessageBox.Show("Lütfen toplam ödemeyi giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtToplamÖdenen.Focus();
                    return; }

                if (ListView1.Items.Count == 0)
                {   MessageBox.Show("Üzgünüz ürün ekleme işlemi gerçekleşmedi.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;  }
                FaturaNo_Ata();
                con = new OleDbConnection(cs);
                con.Open();
                string ct = "select FaturaNo from Satis where FaturaNo=@bul";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new OleDbParameter("@bul", System.Data.OleDb.OleDbType.VarChar, 20, "FaturaNo"));
                cmd.Parameters["@bul"].Value = txtFaturaNo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {  MessageBox.Show("Bu fatura numarası zaten var.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if ((rdr != null))
                    { rdr.Close();  }
                    return;  }

                con = new OleDbConnection(cs);
                con.Open();
                string cb = "insert Into Satis(FaturaNo, FaturaTarih, MusteriID, AraToplam, KDVYüzde, KDVTutar, GenelToplam, ToplamOdeme, Odeme, Uyarilar) values ('" + txtFaturaNo.Text + "','" + dtpFaturaTarih.Text + "','" + txtMusteriID.Text + "'," + txtAraToplam.Text + "," + txtKDVYüzde.Text + "," + txtKDVMiktarı.Text + "," + txtGenelÖdeme.Text + "," + txtToplamÖdenen.Text + "," + txtÖdeme.Text + ",'" + txtUyarilar.Text + "')";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                { con.Close(); }
                con.Close();

                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {   con = new OleDbConnection(cs);
                    string cd = "insert Into SatilanUrunler (FaturaNo,UrunID,Adet,Fiyat,ToplamTutar) values (@FaturaNo,@UrunID,@Adet,@Fiyat,@ToplamTutar)";
                    cmd = new OleDbCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("FaturaNo", txtFaturaNo.Text);
                    cmd.Parameters.AddWithValue("UrunID", ListView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("Adet", ListView1.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("Fiyat", ListView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("ToplamTutar", ListView1.Items[i].SubItems[5].Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close(); }

                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {   con = new OleDbConnection(cs);
                    con.Open();
                    string cb1 = "update Stok set Adet = Adet - " + ListView1.Items[i].SubItems[4].Text + " where UrunID= " + ListView1.Items[i].SubItems[1].Text + "";
                    cmd = new OleDbCommand(cb1);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close(); }

                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {   con = new OleDbConnection(cs);
                    con.Open();
                    string cb2 = "update Stok set ToplamFiyat = ToplamFiyat - '" + ListView1.Items[i].SubItems[5].Text + "' where UrunID= " + ListView1.Items[i].SubItems[1].Text + "";
                    cmd = new OleDbCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close(); }
                btnKaydet.Enabled = false;
                btnYazdır.Enabled = true;
                VeriAl();
                MessageBox.Show("Başarılı şekilde kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);  }
          
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void frmFatura_Load(object sender, EventArgs e)
        { VeriAl(); }

        private void Button1_Click(object sender, EventArgs e)
        {   this.Hide();
            frmMusteriListe1 frm = new frmMusteriListe1();
            frm.label1.Text = label6.Text;
            frm.Visible=true; }

        private void txtSatisAdet_TextChanged(object sender, EventArgs e)
        {   int x1 = 0;
            int x2 = 0;
            int.TryParse(txtFiyat.Text, out x1);
            int.TryParse(txtSatisAdet.Text, out x2);
            int I = (x1 * x2);
            txtToplamTutar.Text = I.ToString(); }

        public double Ara_toplam()
        {   int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;
            
            try
            {   j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {  k = k + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);  }    }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return k; }

   
        private void btnKaldır_Click(object sender, EventArgs e)
        {   try
            {
                if (ListView1.Items.Count == 0)
                {   MessageBox.Show("Kaldırılacak madde yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {   int itmCnt = 0;
                    int i = 0;
                    int t = 0;
                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;
                    for (i = 1; i <= itmCnt + 1; i++)
                    { t = t + 1;  }
                    txtAraToplam.Text = Ara_toplam().ToString();
                    if (txtKDVYüzde.Text != "")
                    {   txtKDVMiktarı.Text = Convert.ToInt32((Convert.ToInt32(txtAraToplam.Text) * Convert.ToDouble(txtKDVYüzde.Text) / 100)).ToString();
                        txtGenelÖdeme.Text = (Convert.ToInt32(txtAraToplam.Text) + Convert.ToInt32(txtKDVMiktarı.Text)).ToString(); }
                    int x1 = 0;
                    int x2 = 0;
                    int.TryParse(txtGenelÖdeme.Text, out x1);
                    int.TryParse(txtToplamÖdenen.Text, out x2);
                    int I = (x2 - x1);
                    txtÖdeme.Text = I.ToString();
                }

                btnKaldır.Enabled = false;
                if (ListView1.Items.Count == 0)
                {
                    txtAraToplam.Text = "";
                }
            }
            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtTaxPer_TextChanged(object sender, EventArgs e)
        {   try
            {
                if (string.IsNullOrEmpty(txtKDVYüzde.Text))
                {   txtKDVMiktarı.Text = "";
                    txtGenelÖdeme.Text = "";
                    return; }
                txtKDVMiktarı.Text = Convert.ToInt32((Convert.ToInt32(txtAraToplam.Text) * Convert.ToDouble(txtKDVYüzde.Text) / 100)).ToString() ;
                txtGenelÖdeme.Text = (Convert.ToInt32(txtAraToplam.Text) + Convert.ToInt32(txtKDVMiktarı.Text)).ToString();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        { btnKaldır.Enabled = true; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                String str = "select StokID,UrunBilgileri.UrunID,UrunAd,Ozellikler,Fiyat,sum(Adet) from Stok,UrunBilgileri where Stok.UrunID=UrunBilgileri.UrunID and UrunAd like '" + txtUrun.Text + "%' group by StokID,UrunAd,Fiyat,Ozellikler,UrunBilgileri.UrunID having sum(Adet > 0) order by UrunAd";
                cmd = new OleDbCommand(str, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {  dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]); }
                con.Close(); }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }  }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {   string str = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(str, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            { dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(str, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)); }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   try
            {   DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtUrunID.Text = dr.Cells[1].Value.ToString();
                txtUrunAdi.Text = dr.Cells[2].Value.ToString();
                txtFiyat.Text = dr.Cells[4].Value.ToString();
                txtMevcutAdet.Text = dr.Cells[5].Value.ToString();
                txtSatisAdet.Focus(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        public void VeriAl()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                String sql = "select StokID,UrunBilgileri.UrunID,UrunAd,Ozellikler,Fiyat,sum(Adet) from Stok,UrunBilgileri where Stok.UrunID=UrunBilgileri.UrunID group by StokID,UrunAd,Fiyat,Ozellikler,UrunBilgileri.UrunID having sum(Adet > 0) order by UrunAd";
                cmd = new OleDbCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                { dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]); }
                con.Close();  }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Sıfırla()
        {
            txtFaturaNo.Text = ""; dtpFaturaTarih.Text = DateTime.Today.ToString();
            txtMusteriID.Text = ""; txtMusteriAdi.Text = ""; txtUrunAdi.Text = "";
            txtUrunID.Text = ""; txtFiyat.Text = ""; txtMevcutAdet.Text = "";
            txtSatisAdet.Text = ""; txtToplamTutar.Text = ""; ListView1.Items.Clear();
            txtAraToplam.Text = ""; txtKDVYüzde.Text = ""; txtKDVMiktarı.Text = "";
            txtGenelÖdeme.Text = ""; txtToplamÖdenen.Text = ""; txtÖdeme.Text = "";
            txtUrun.Text = ""; txtUyarilar.Text = ""; btnKaydet.Enabled = true; 
            btnSil.Enabled = false; btnGuncelle.Enabled = false; btnKaldır.Enabled = false;
            btnYazdır.Enabled = false; ListView1.Enabled = true; btnSepet.Enabled = true; }

        private void btnYeni_Click(object sender, EventArgs e)
        {  Sıfırla();  }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {  Kayıt_sil(); } }

        private void Kayıt_sil()
        {    try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cq1 = "delete from SatilanUrunler where FaturaNo='" + txtFaturaNo.Text + "'";
                cmd = new OleDbCommand(cq1);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                con.Close();
                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from Satis where FaturaNo='" + txtFaturaNo.Text + "'";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if (Etki > 0)
                {  MessageBox.Show("Başarılı bir şekilde silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                else
                {   MessageBox.Show("Kayıt bulunamadı.", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla(); }
                if (con.State == ConnectionState.Open)
                { con.Close(); } }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void frmFatura_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmAnasayfa frm = new frmAnasayfa();
            if (label6.Text == "Yönetici") frm.devredısı();
            if (label6.Text == "Çalışan") frm.devredısı1();
            frm.Kullanici.Text = label6.Text;
            frm.Show();  }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {   int x1 = 0;
            int x2 = 0;
            int.TryParse(txtGenelÖdeme.Text, out x1);
            int.TryParse(txtToplamÖdenen.Text, out x2);
            int I = (x2 - x1);
            txtÖdeme.Text = I.ToString(); }

        private void txtTotalOdeme_Validating(object sender, CancelEventArgs e)
        {
            int x1 = 0;
            int x2 = 0;
            int.TryParse(txtGenelÖdeme.Text, out x1);
            int.TryParse(txtToplamÖdenen.Text, out x2);
            if (x2 < x1)
            {
                MessageBox.Show("Toplam ödeme, genel toplamdan küçük olamaz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToplamÖdenen.Text = "";
                txtÖdeme.Text = "";
                txtToplamÖdenen.Focus();
                return; } }

        private void txtSatısAdet_Validating(object sender, CancelEventArgs e)
        {   int x1 = 0;
            int x2 = 0;
            int.TryParse(txtMevcutAdet.Text, out x1);
            int.TryParse(txtSatisAdet.Text, out x2);
            if (x2 > x1)
            {   MessageBox.Show("Ürün satış adeti, stokta bulunan mevcut adetten büyük olamaz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSatisAdet.Text = "";
                txtToplamTutar.Text = "";
                txtSatisAdet.Focus();
                return; } }

        //private void btnYazdır_Click(object sender, EventArgs e)
        //{   try
        //    {   Cursor = Cursors.WaitCursor;
        //        timer1.Enabled = true;
        //        rprFatura rpt = new rprFatura();
        //        cmd = new OleDbCommand();
        //        OleDbDataAdapter myDA = new OleDbDataAdapter();
        //        DataSet myDS = new DataSet();
        //        con = new OleDbConnection(cs);
        //        cmd.Connection = con;
        //        cmd.CommandText = "select UrunBilgileri.UrunID, UrunBilgileri.UrunAd, UrunBilgileri.Ozellikler, UrunBilgileri.Fiyat, Satis.FaturaNo, Satis.FaturaTarih, Satis.MusteriID, Satis.AraToplam , Satis.KDVYüzde, Satis.KDVTutar, Satis.GenelToplam, Satis.ToplamOdeme, Satis.Odeme, Satis.Uyarilar, SatilanUrunler.ID,SatilanUrunler.FaturaNo AS Expr1, SatilanUrunler.UrunID AS Expr2,  SatilanUrunler.Adet, SatilanUrunler.Fiyat AS Expr3, SatilanUrunler.ToplamTutar,Musterı.MusteriID AS Expr4, Musterı.MusteriAdSoyad, Musterı.Adres, Musterı.İl, Musterı.İlce, Musterı.PostaKodu,Musterı.EvTel, Musterı.CepTel, Musterı.FaksNo, Musterı.Email, Musterı.NotB from (((Musterı inner join Satis on Musterı.MusteriID = Satis.MusteriID) inner join SatilanUrunler on Satis.FaturaNo = SatilanUrunler.FaturaNo) inner join UrunBilgileri on SatilanUrunler.UrunID = UrunBilgileri.UrunID) where Satis.FaturaNo='" + txtFaturaNo.Text + "'";
        //        cmd.CommandType = CommandType.Text;
        //        myDA.SelectCommand = cmd;
        //        myDA.Fill(myDS, "UrunBilgileri");
        //        myDA.Fill(myDS, "Satis");
        //        myDA.Fill(myDS, "SatilanUrunler");
        //        myDA.Fill(myDS, "Musterı");
        //        rpt.SetDataSource(myDS);
        //        frmFaturaRapor frm = new frmFaturaRapor();
        //        frm.crystalReportViewer1.ReportSource = rpt;
        //        frm.Visible=true;  }

        //    catch (Exception ex)
        //    {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void timer1_Tick(object sender, EventArgs e)
        {   Cursor = Cursors.Default;
            timer1.Enabled = false; }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {  con = new OleDbConnection(cs);
               con.Open();
               String cb = "update Satis set GenelToplam= " + txtGenelÖdeme.Text + ",ToplamOdeme= " + txtToplamÖdenen.Text + ",Odeme= " + txtÖdeme.Text + ",Uyarilar='" + txtUyarilar.Text + "' where FaturaNo= '" + txtFaturaNo.Text + "'";
               cmd = new OleDbCommand(cb);
               cmd.Connection = con;
               cmd.ExecuteReader();
               con.Close();

            for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {   con = new OleDbConnection(cs);
                string cd = "update SatilanUrunler set Adet=" + ListView1.Items[i].SubItems[4].Text + ",Fiyat= " + ListView1.Items[i].SubItems[3].Text + ",ToplamTutar= " + ListView1.Items[i].SubItems[5].Text + " where FaturaNo='" + txtFaturaNo.Text + "' and UrunID= " + ListView1.Items[i].SubItems[1].Text + "";
                cmd = new OleDbCommand(cd);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); }

            for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {  con = new OleDbConnection(cs);
                con.Open();
                string cb1 = "update Stok set Adet = Adet - " + ListView1.Items[i].SubItems[4].Text + " where UrunID= " + ListView1.Items[i].SubItems[1].Text + "";
                cmd = new OleDbCommand(cb1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();  }

            for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb2 = "update Stok set ToplamFiyat = ToplamFiyat - '" + ListView1.Items[i].SubItems[5].Text + "' where UrunID= " + ListView1.Items[i].SubItems[1].Text + "";
                cmd = new OleDbCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close(); }
            VeriAl();
            btnGuncelle.Enabled = false;
            MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Button4_Click(object sender, EventArgs e)
        {   this.Hide();
            frmSatisKayitListe1 frm = new frmSatisKayitListe1();
            frm.DataGridView1.DataSource = null;
            frm.dtpFaturaTarih1.Text = DateTime.Today.ToString();
            frm.dtpFaturaTarih2.Text = DateTime.Today.ToString();
            frm.GroupBox3.Visible = false;
            frm.DataGridView3.DataSource = null;
            frm.cmbMusteriAd.Text = "";
            frm.GroupBox4.Visible = false;
            frm.DateTimePicker1.Text = DateTime.Today.ToString();
            frm.DateTimePicker2.Text = DateTime.Today.ToString();
            frm.DataGridView2.DataSource = null;
            frm.GroupBox10.Visible = false;
            frm.Combo_doldur();
            frm.label9.Text = label6.Text;
            frm.Show(); }

        private void btnSepet_Click(object sender, EventArgs e)
        {   try
            {   if (txtMusteriID.Text == "")
                {   MessageBox.Show("Lütfen müşteri ID seçiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMusteriID.Focus();
                    return; }

                if (txtUrunAdi.Text=="")
                {   MessageBox.Show("Lütfen ürün adını seçiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  }

                if (txtSatisAdet.Text=="")
                {   MessageBox.Show("Lütfen satış yapılacak adeti giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSatisAdet.Focus();
                    return;  }

                int SatısAdet = Convert.ToInt32(txtSatisAdet.Text);
                if (SatısAdet == 0)
                {   MessageBox.Show("Satış adeti sıfır olamaz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSatisAdet.Focus();
                    return; }
              
                if (ListView1.Items.Count==0)
                {   ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(txtUrunID.Text);
                    lst.SubItems.Add(txtUrunAdi.Text);
                    lst.SubItems.Add(txtFiyat.Text);
                    lst.SubItems.Add(txtSatisAdet.Text);
                    lst.SubItems.Add(txtToplamTutar.Text);
                    ListView1.Items.Add(lst);
                    txtAraToplam.Text = Ara_toplam().ToString();
                    if (txtKDVYüzde.Text != "")
                    {   txtKDVMiktarı.Text = Convert.ToInt32((Convert.ToInt32(txtAraToplam.Text) * Convert.ToDouble(txtKDVYüzde.Text) / 100)).ToString();
                        txtGenelÖdeme.Text = (Convert.ToInt32(txtAraToplam.Text) + Convert.ToInt32(txtKDVMiktarı.Text)).ToString(); }
                    int x1 = 0;
                    int x2 = 0;
                    int.TryParse(txtGenelÖdeme.Text, out x1);
                    int.TryParse(txtToplamÖdenen.Text, out x2);
                    int I = (x2 - x1);
                    txtÖdeme.Text = I.ToString();
                    txtUrunAdi.Text = "";
                    txtUrunID.Text = "";
                    txtFiyat.Text = "";
                    txtMevcutAdet.Text = "";
                    txtSatisAdet.Text = "";
                    txtToplamTutar.Text = "";
                    txtUrun.Text = "";
                    return;  }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    if (ListView1.Items[j].SubItems[1].Text == txtUrunID.Text)
                    {
                        ListView1.Items[j].SubItems[1].Text = txtUrunID.Text;
                        ListView1.Items[j].SubItems[2].Text = txtUrunAdi.Text;
                        ListView1.Items[j].SubItems[3].Text = txtFiyat.Text;
                        ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(txtSatisAdet.Text)).ToString();
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txtToplamTutar.Text)).ToString();
                        txtAraToplam.Text = Ara_toplam().ToString();
                        if (txtKDVYüzde.Text != "")
                        {   txtKDVMiktarı.Text = Convert.ToInt32((Convert.ToInt32(txtAraToplam.Text) * Convert.ToDouble(txtKDVYüzde.Text) / 100)).ToString();
                            txtGenelÖdeme.Text = (Convert.ToInt32(txtAraToplam.Text) + Convert.ToInt32(txtKDVMiktarı.Text)).ToString(); }
                        int x1 = 0;
                        int x2 = 0;
                        int.TryParse(txtGenelÖdeme.Text, out x1);
                        int.TryParse(txtToplamÖdenen.Text, out x2);
                        int I = (x2 - x1);
                        txtÖdeme.Text = I.ToString();
                        txtUrunAdi.Text = "";
                        txtUrunID.Text = "";
                        txtFiyat.Text = "";
                        txtMevcutAdet.Text = "";
                        txtSatisAdet.Text = "";
                        txtToplamTutar.Text = "";
                        return;  }  }
                   
                    ListViewItem lst1 = new ListViewItem();
                    lst1.SubItems.Add(txtUrunID.Text);
                    lst1.SubItems.Add(txtUrunAdi.Text);
                    lst1.SubItems.Add(txtFiyat.Text);
                    lst1.SubItems.Add(txtSatisAdet.Text);
                    lst1.SubItems.Add(txtToplamTutar.Text);
                    ListView1.Items.Add(lst1);
                    txtAraToplam.Text = Ara_toplam().ToString();
                    if (txtKDVYüzde.Text != "")
                    {   txtKDVMiktarı.Text = Convert.ToInt32((Convert.ToInt32(txtAraToplam.Text) * Convert.ToDouble(txtKDVYüzde.Text) / 100)).ToString();
                        txtGenelÖdeme.Text = (Convert.ToInt32(txtAraToplam.Text) + Convert.ToInt32(txtKDVMiktarı.Text)).ToString(); }
                    int x3 = 0;
                    int x4 = 0;
                    int.TryParse(txtGenelÖdeme.Text, out x3);
                    int.TryParse(txtToplamÖdenen.Text, out x4);
                    int I1 = (x4 - x3);
                    txtÖdeme.Text = I1.ToString();
                    txtUrunAdi.Text = "";
                    txtUrunID.Text = "";
                    txtFiyat.Text = "";
                    txtMevcutAdet.Text = "";
                    txtSatisAdet.Text = "";
                    txtToplamTutar.Text = "";
                    return; }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } } } }