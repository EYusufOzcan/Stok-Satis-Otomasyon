using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
namespace Stok_ve_Satis_Otomasyonu
{
    public partial class frmSatisKayitListe : Form
    {  DataTable dTable;
       OleDbConnection con = null;
       OleDbDataAdapter adp;
       DataSet ds;
       OleDbCommand cmd = null;
       DataTable dt= new DataTable();
       String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmSatisKayitListe()
        {  InitializeComponent(); }

        private void frmSatisKayitListe_Load(object sender, EventArgs e)
        {  Combo_doldur(); }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.DataSource == null)
            {   MessageBox.Show("Üzgünüz Excel sayfasına aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  }

            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {   Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;
                rowsTotal = DataGridView1.RowCount - 1;
                colsTotal = DataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value; }  }

                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();   }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally
            {   System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null; } }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (DataGridView2.DataSource == null)
            {   MessageBox.Show("Üzgünüz Excel sayfasına aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  }

            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {   Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = DataGridView2.RowCount - 1;
                colsTotal = DataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                { _with1.Cells[1, iC + 1].Value = DataGridView2.Columns[iC].HeaderText; }

                for (I = 0; I <= rowsTotal - 1; I++)
                {   for (j = 0; j <= colsTotal; j++)
                    {  _with1.Cells[I + 2, j + 1].value = DataGridView2.Rows[I].Cells[j].Value;   }  }

                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally
            {   System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;  }  }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (DataGridView3.DataSource == null)
            {
                MessageBox.Show("Üzgünüz Excel sayfasına aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  }

            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = DataGridView3.RowCount - 1;
                colsTotal = DataGridView3.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                { _with1.Cells[1, iC + 1].Value = DataGridView3.Columns[iC].HeaderText; }

                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    { _with1.Cells[I + 2, j + 1].value = DataGridView3.Rows[I].Cells[j].Value; }  }

                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }  }

        private void Button9_Click(object sender, EventArgs e)
        {   DataGridView3.DataSource = null;
            cmbMusteriAd.Text = "";
            GroupBox4.Visible = false; }

        private void Button2_Click(object sender, EventArgs e)
        {   DataGridView1.DataSource = null;
            dtpFaturaTarih1.Text = DateTime.Today.ToString();
            dtpFaturaTarih2.Text = DateTime.Today.ToString();
            GroupBox3.Visible = false; }

        private void Button6_Click(object sender, EventArgs e)
        {   DateTimePicker1.Text = DateTime.Today.ToString();
            DateTimePicker2.Text = DateTime.Today.ToString();
            DataGridView2.DataSource = null;
            GroupBox10.Visible = false; }

        public void Combo_doldur()
        {  try
            {   con = new OleDbConnection(cs);
                con.Open();
                adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand("select distinct MusteriAdSoyad from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID",con);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dTable = ds.Tables[0];
                cmbMusteriAd.Items.Clear();
                foreach (DataRow drow in dTable.Rows)
                { cmbMusteriAd.Items.Add(drow[0].ToString()); } }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {  GroupBox3.Visible = true;
               con = new OleDbConnection(cs);
               con.Open();
               cmd = new OleDbCommand("select (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarih],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı Soyadı],(GenelToplam) as [Genel Toplam],(ToplamOdeme) as [Toplam Ödeme],(Odeme) as [Ödeme] from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID  and FaturaTarih between @Tarih And @Tarih1 order by FaturaTarih desc", con);
               cmd.Parameters.AddWithValue("Tarih", dtpFaturaTarih1.Value.Date);
               cmd.Parameters.AddWithValue("Tarih1", dtpFaturaTarih2.Value.Date);
               OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
               DataSet myDataSet = new DataSet();
               myDA.Fill(myDataSet, "Satis");
               myDA.Fill(myDataSet, "Musterı");
               DataGridView1.DataSource = myDataSet.Tables["Musterı"].DefaultView;
               DataGridView1.DataSource = myDataSet.Tables["Satis"].DefaultView;
               Int64 toplam = 0;
               Int64 toplam1 = 0;
               Int64 toplam2 = 0;

            foreach (DataGridViewRow r in this.DataGridView1.Rows)
            {   Int64 i = Convert.ToInt64(r.Cells[4].Value);
                Int64 j = Convert.ToInt64(r.Cells[5].Value);
                Int64 k = Convert.ToInt64(r.Cells[6].Value);
                toplam = toplam + i;
                toplam1 = toplam1 + j;
                toplam2 = toplam2 + k; }
            TextBox1.Text = toplam.ToString();
            TextBox2.Text = toplam1.ToString();
            TextBox3.Text = toplam2.ToString();
            con.Close(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void cmbMusteriAd_SelectedIndexChanged(object sender, EventArgs e)
        {   try
            { GroupBox4.Visible = true;
              con = new OleDbConnection(cs);
              con.Open();
              cmd = new OleDbCommand("select (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarihi],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı], (GenelToplam) as [Genel Toplam],(ToplamOdeme) as [Toplam Ödeme], (Odeme) as [Ödenen] from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID and MusteriAdSoyad ='" + cmbMusteriAd.Text + "' order by MusteriAdSoyad,FaturaTarih", con);
              OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
              DataSet myDataSet = new DataSet();
              myDA.Fill(myDataSet, "Satis");
              myDA.Fill(myDataSet, "Musterı");
              DataGridView3.DataSource = myDataSet.Tables["Musterı"].DefaultView;
              DataGridView3.DataSource = myDataSet.Tables["Satis"].DefaultView;
              Int64 toplam = 0;
              Int64 toplam1 = 0;
              Int64 toplam2 = 0;

            foreach (DataGridViewRow r in this.DataGridView3.Rows)
            {   Int64 i = Convert.ToInt64(r.Cells[4].Value);
                Int64 j = Convert.ToInt64(r.Cells[5].Value);
                Int64 k = Convert.ToInt64(r.Cells[6].Value);
                toplam = toplam + i;
                toplam1 = toplam1 + j;
                toplam2 = toplam2 + k; }

            TextBox6.Text = toplam.ToString();
            TextBox5.Text = toplam1.ToString();
            TextBox4.Text = toplam2.ToString();
            con.Close();  }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Button5_Click(object sender, EventArgs e)
        {   try
            {   GroupBox10.Visible = true;
                con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarihi],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı Soyadı],(GenelToplam) as [Genel Toplam],(ToplamOdeme) as [Toplam Ödeme],(Odeme) as [Ödenen] from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID and FaturaTarih between @DateTimePicker2 And @DateTimePicker1 and Odeme > 0  order by FaturaTarih desc", con);
                cmd.Parameters.AddWithValue("DateTimePicker2", DateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("DateTimePicker1", DateTimePicker1.Value.Date);
                OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Satis");
                myDA.Fill(myDataSet, "Musterı");
                DataGridView2.DataSource = myDataSet.Tables["Musterı"].DefaultView;
                DataGridView2.DataSource = myDataSet.Tables["Satis"].DefaultView;
                Int64 toplam = 0;
                Int64 toplam1 = 0;
                Int64 toplam2 = 0;

                foreach (DataGridViewRow r in this.DataGridView2.Rows)
                {   Int64 i = Convert.ToInt64(r.Cells[4].Value);
                    Int64 j = Convert.ToInt64(r.Cells[5].Value);
                    Int64 k = Convert.ToInt64(r.Cells[6].Value);
                    toplam = toplam + i;
                    toplam1 = toplam1 + j;
                    toplam2 = toplam2 + k;  }

                TextBox12.Text = toplam.ToString();
                TextBox11.Text = toplam1.ToString();
                TextBox10.Text = toplam2.ToString();
                con.Close(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {   string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {  DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));  }

        private void DataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {   string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {  DataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));  }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));  }

        private void DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {   string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {  DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));  }

        private void TabControl1_Click(object sender, EventArgs e)
        {   DataGridView1.DataSource = null;
            dtpFaturaTarih1.Text = DateTime.Today.ToString();
            dtpFaturaTarih2.Text = DateTime.Today.ToString();
            GroupBox3.Visible = false;
            DataGridView3.DataSource = null;
            cmbMusteriAd.Text = "";
            GroupBox4.Visible = false;
            DateTimePicker1.Text = DateTime.Today.ToString();
            DateTimePicker2.Text = DateTime.Today.ToString();
            DataGridView2.DataSource = null;
            GroupBox10.Visible = false;  }

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        timer1.Enabled = true;
        //        rprSatis rpt = new rprSatis();
        //        cmd = new OleDbCommand();
        //        OleDbDataAdapter myDA = new OleDbDataAdapter();
        //        dtsVeritabanı myDS = new dtsVeritabanı();
        //        con = new OleDbConnection(cs);
        //        cmd.Connection = con;
        //        cmd.CommandText = "select FaturaNo, FaturaTarih, Satis.MusteriID, GenelToplam, ToplamOdeme, Odeme,  MusteriAdSoyad from Satis, Musterı where Satis.MusteriID = Musterı.MusteriID and FaturaTarih between @Tarih And @Tarih1 order by FaturaTarih desc";
        //        cmd.Parameters.AddWithValue("Tarih", dtpFaturaTarih1.Value.Date);
        //        cmd.Parameters.AddWithValue("Tarih1", dtpFaturaTarih2.Value.Date);
        //        cmd.CommandType = CommandType.Text;
        //        myDA.SelectCommand = cmd;
        //        myDA.Fill(myDS, "Satis");
        //        myDA.Fill(myDS, "Musterı");
        //        rpt.SetDataSource(myDS);
        //        frmSatisRapor frm = new frmSatisRapor();
        //        frm.crystalReportViewer1.ReportSource = rpt;
        //        frm.Visible = true;
        //    }

        //    catch (Exception ex)
        //    {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        //private void timer1_Tick(object sender, EventArgs e)
        //{   Cursor = Cursors.Default;
        //    timer1.Enabled = false;  }

        //private void button10_Click(object sender, EventArgs e)
        //{   try
        //    {
        //        if (cmbMusteriAd.Text == "")
        //        {   MessageBox.Show("Lütfen müşteri adını seçiniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            cmbMusteriAd.Focus();
        //            return; }

        //        Cursor = Cursors.WaitCursor;
        //        timer1.Enabled = true;
                //rprSatis rpt = new rprSatis();
                //cmd = new OleDbCommand();
                //OleDbDataAdapter myDA = new OleDbDataAdapter();
                //dtsVeritabanı myDS = new dtsVeritabanı();
                //con = new OleDbConnection(cs);
                //cmd.Connection = con;
                //cmd.CommandText = "select Satis.FaturaNo, Satis.FaturaTarih, Satis.MusteriID, Satis.AraToplam, Satis.KDVYüzde, Satis.KDVTutar, Satis.GenelToplam, Satis.ToplamOdeme,Satis.Odeme, Satis.Uyarilar, Musterı.MusteriID AS Expr1, Musterı.MusteriAdSoyad, Musterı.Adres,  Musterı.İl, Musterı.İlce, Musterı.PostaKodu, Musterı.EvTel, Musterı.CepTel, Musterı.FaksNo, Musterı.Email, Musterı.NotB FROM (Satis INNER JOIN Musterı ON Satis.MusteriID = Musterı.MusteriID) where MusteriAdSoyad='" + cmbMusteriAd.Text + "' order by MusteriAdSoyad,FaturaTarih";
                //cmd.CommandType = CommandType.Text;
                //myDA.SelectCommand = cmd;
                //myDA.Fill(myDS, "Satis");
                //myDA.Fill(myDS, "Musterı");
                //rpt.SetDataSource(myDS);
                //frmSatisRapor frm = new frmSatisRapor();
                //frm.crystalReportViewer1.ReportSource = rpt;
            //    frm.Visible = true;  }

            //catch (Exception ex)
            //{   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }  }

        private void button11_Click(object sender, EventArgs e)
        {   try
            {   Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                //rprSatis rpt = new rprSatis();
                //cmd = new OleDbCommand();
                //OleDbDataAdapter myDA = new OleDbDataAdapter();
                //dtsVeritabanı myDS = new dtsVeritabanı();
                //con = new OleDbConnection(cs);
                //cmd.Connection = con;
                //cmd.CommandText = "select Satis.FaturaNo, Satis.FaturaTarih, Satis.MusteriID, Satis.AraToplam, Satis.KDVYüzde, Satis.KDVTutar, Satis.GenelToplam, Satis.ToplamOdeme,Satis.Odeme, Satis.Uyarilar, Musterı.MusteriID AS Expr1, Musterı.MusteriAdSoyad, Musterı.Adres,  Musterı.İl, Musterı.İlce, Musterı.PostaKodu, Musterı.EvTel, Musterı.CepTel, Musterı.FaksNo, Musterı.Email, Musterı.NotB FROM (Satis INNER JOIN Musterı ON Satis.MusteriID = Musterı.MusteriID) Where FaturaTarih between @DateTimePicker1 And @DateTimePicker2 and Odeme > 0 order by FaturaTarih desc";
                //cmd.Parameters.AddWithValue("DateTimePicker1", DateTimePicker2.Value.Date);
                //cmd.Parameters.AddWithValue("DateTimePicker2", DateTimePicker1.Value.Date);
                //cmd.CommandType = CommandType.Text;
                //myDA.SelectCommand = cmd;
                //myDA.Fill(myDS, "Satis");
                //myDA.Fill(myDS, "Musterı");
                //rpt.SetDataSource(myDS);
                //frmSatisRapor frm = new frmSatisRapor();
                //frm.crystalReportViewer1.ReportSource = rpt;
                /*frm.Visible = true; */ }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }  }  }  }
