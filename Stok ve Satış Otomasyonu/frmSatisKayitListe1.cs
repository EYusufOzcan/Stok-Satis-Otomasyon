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
    public partial class frmSatisKayitListe1 : Form
    {
   
    DataTable dTable;
    OleDbConnection con = null;
    OleDbDataAdapter adp;
    DataSet ds;
    OleDbCommand cmd = null;
    DataTable dt= new DataTable();
    OleDbDataReader rdr;
    String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";
        public frmSatisKayitListe1()
        {
            InitializeComponent();
        }

        private void frmSatisKayitListe1_Load(object sender, EventArgs e)
        {
            Combo_doldur();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (DataGridView1.DataSource == null)
            {
                MessageBox.Show("Üzgünüz Excel'e aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                        _with1.Cells[I + 2, j + 1].value = DataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (DataGridView2.DataSource == null)
            {
                MessageBox.Show("Üzgünüz Excel'e aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

                rowsTotal = DataGridView2.RowCount - 1;
                colsTotal = DataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (DataGridView3.DataSource == null)
            {
                MessageBox.Show("Üzgünüz Excel'e aktaracak veri yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                {
                    _with1.Cells[1, iC + 1].Value = DataGridView3.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = DataGridView3.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }  
        }

        private void Button9_Click(object sender, EventArgs e)
        {
        DataGridView3.DataSource = null;
        cmbMusteriAd.Text = "";
        GroupBox4.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        DataGridView1.DataSource = null;
        dtpFaturaTarih1.Text = DateTime.Today.ToString();
        dtpFaturaTarih2.Text = DateTime.Today.ToString();
        GroupBox3.Visible = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        { DateTimePicker1.Text = DateTime.Today.ToString();
          DateTimePicker2.Text = DateTime.Today.ToString();
          DataGridView2.DataSource = null;
          GroupBox10.Visible = false; }

        public void Combo_doldur()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                adp = new OleDbDataAdapter();
                adp.SelectCommand = new OleDbCommand("SELECT distinct MusteriAdSoyad FROM Satis,Musterı where Satis.MusteriID=Musterı.MusteriID ",con);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dTable = ds.Tables[0];
                cmbMusteriAd.Items.Clear();
                foreach (DataRow drow in dTable.Rows)
                { cmbMusteriAd.Items.Add(drow[0].ToString()); } }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            GroupBox3.Visible = true;
            con = new OleDbConnection(cs);
            con.Open();
            cmd = new OleDbCommand("SELECT (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarihi],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı Soyadı], AraToplam as [AraToplam],KDVYüzde as [KDV+GT %], KDVTutar as [KDV+GT Miktar],(GenelToplam) as [Genel Toplam],(TOplamOdeme) as [Toplam Ödeme],(Odeme) as [Ödeme],Uyarilar from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID  and FaturaTarih between @dtpInvoiceDateFrom And @dtpInvoiceDateTo order by FaturaTarih desc", con);
            cmd.Parameters.AddWithValue("dtpInvoiceDateFrom", dtpFaturaTarih1.Value.Date);
            cmd.Parameters.AddWithValue("dtpInvoiceDateTo", dtpFaturaTarih2.Value.Date);
            OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "Satis");
            myDA.Fill(myDataSet, "Musterı");
            DataGridView1.DataSource = myDataSet.Tables["Musterı"].DefaultView;
            DataGridView1.DataSource = myDataSet.Tables["Satis"].DefaultView;
            Int64 sum = 0;
            Int64 sum1 = 0;
            Int64 sum2 = 0;

            foreach (DataGridViewRow r in this.DataGridView1.Rows)
            {
                Int64 i = Convert.ToInt64(r.Cells[7].Value);
                Int64 j = Convert.ToInt64(r.Cells[8].Value);
                Int64 k = Convert.ToInt64(r.Cells[9].Value);
                sum = sum + i;
                sum1 = sum1 + j;
                sum2 = sum2 + k; }
                TextBox1.Text = sum.ToString();
                TextBox2.Text = sum1.ToString();
                TextBox3.Text = sum2.ToString();
                con.Close(); }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
              try
            {
            GroupBox4.Visible = true;
            con = new OleDbConnection(cs);
            con.Open();
            cmd = new OleDbCommand("SELECT (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarihi],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı Soyadı],  AraToplam as [Ara Toplam],KDVYüzde as [KDV+AT %],KDVTutar as [KDV+AT Tutarı],(GenelToplam) as [Genel Toplam],(ToplamOdeme) as [Toplam Ödeme],(Odeme) as [Ödenen],Uyarilar from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID and MusteriAdSoyad='" + cmbMusteriAd.Text + "' order by MusteriAdSoyad,FaturaTarih", con);
            OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
            DataSet myDataSet = new DataSet();
            myDA.Fill(myDataSet, "Satis");
            myDA.Fill(myDataSet, "Musterı");
            DataGridView3.DataSource = myDataSet.Tables["Musterı"].DefaultView;
            DataGridView3.DataSource = myDataSet.Tables["Satis"].DefaultView;
            Int64 sum = 0;
            Int64 sum1 = 0;
            Int64 sum2 = 0;

            foreach (DataGridViewRow r in this.DataGridView3.Rows)
            {
                Int64 i = Convert.ToInt64(r.Cells[7].Value);
                Int64 j = Convert.ToInt64(r.Cells[8].Value);
                Int64 k = Convert.ToInt64(r.Cells[9].Value);
                sum = sum + i;
                sum1 = sum1 + j;
                sum2 = sum2 + k;
            }
            TextBox6.Text = sum.ToString();
            TextBox5.Text = sum1.ToString();
            TextBox4.Text = sum2.ToString();

            con.Close();
            }
        catch (Exception ex)
            {
            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                GroupBox10.Visible = true;
                con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("SELECT  (FaturaNo) as [Fatura No],(FaturaTarih) as [Fatura Tarihi],(Satis.MusteriID) as [Müşteri ID],(MusteriAdSoyad) as [Müşteri Adı Soyadı], AraToplam as [Ara Toplam],KDVYüzde as [KDV+AT %],KDVTutar as [VAT+AT Tutarı],(GenelToplam) as [Genel Toplam],(ToplamOdeme) as [Toplam Ödeme],(Odeme) as [Ödenen],Uyarilar from Satis,Musterı where Satis.MusteriID=Musterı.MusteriID and FaturaTarih between @dtpInvoiceDateFrom And @dtpInvoiceDateTo and  Odeme > 0 order by FaturaTarih desc", con);
                cmd.Parameters.AddWithValue("dtpInvoiceDateFrom", dtpFaturaTarih1.Value.Date);
                cmd.Parameters.AddWithValue("dtpInvoiceDateTo", dtpFaturaTarih2.Value.Date);
                //cmd = new OleDbCommand("SELECT (invoiceNo) as [Invoice No],(InvoiceDate) as [Invoice Date],(Sales.CustomerID) as [Customer ID],(CustomerName) as [Customer Name],SubTotal as [SubTotal],VATPercentage as [Vat+ST %],VATAmount as [VAT+ST Amount],(GrandTotal) as [Grand Total],(TotalPayment) as [Total Payment],(PaymentDue) as [Payment Due],Remarks from Sales,Customer where Sales.CustomerID=Customer.CustomerID and InvoiceDate between #" + DateTimePicker2.Text + "# And #" + DateTimePicker1.Text + "# and PaymentDue > 0 order by InvoiceDate desc", con);
                OleDbDataAdapter myDA = new OleDbDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Satis");
                myDA.Fill(myDataSet, "Musterı");
                DataGridView2.DataSource = myDataSet.Tables["Musterı"].DefaultView;
                DataGridView2.DataSource = myDataSet.Tables["Satis"].DefaultView;
                Int64 sum = 0;
                Int64 sum1 = 0;
                Int64 sum2 = 0;

                foreach (DataGridViewRow r in this.DataGridView2.Rows)
                {
                    Int64 i = Convert.ToInt64(r.Cells[7].Value);
                    Int64 j = Convert.ToInt64(r.Cells[8].Value);
                    Int64 k = Convert.ToInt64(r.Cells[9].Value);
                    sum = sum + i;
                    sum1 = sum1 + j;
                    sum2 = sum2 + k;
                }
                TextBox12.Text = sum.ToString();
                TextBox11.Text = sum1.ToString();
                TextBox10.Text = sum2.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSatisKayitListe1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmFatura frm = new frmFatura();
            frm.label6.Text = label9.Text;
            frm.Show();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmFatura frmSales = new frmFatura();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                frmSales.Show();
                frmSales.txtFaturaNo.Text = dr.Cells[0].Value.ToString();
                frmSales.dtpFaturaTarih.Text = dr.Cells[1].Value.ToString();
                frmSales.txtMusteriID.Text = dr.Cells[2].Value.ToString();
                frmSales.txtMusteriAdi.Text = dr.Cells[3].Value.ToString();
                frmSales.txtAraToplam.Text = dr.Cells[4].Value.ToString();
                frmSales.txtKDVYüzde.Text = dr.Cells[5].Value.ToString();
                frmSales.txtKDVMiktarı.Text = dr.Cells[6].Value.ToString();
                frmSales.txtGenelÖdeme.Text = dr.Cells[7].Value.ToString();
                frmSales.txtToplamÖdenen.Text = dr.Cells[8].Value.ToString();
                frmSales.txtÖdeme.Text = dr.Cells[9].Value.ToString();
                frmSales.txtUyarilar.Text = dr.Cells[10].Value.ToString();
                frmSales.btnGuncelle.Enabled = true;
                frmSales.btnSil.Enabled = true;
                frmSales.btnYazdır.Enabled = true;
                frmSales.btnKaydet.Enabled = false;
                frmSales.label6.Text = label9.Text;
                con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("SELECT UrunBilgileri.UrunID, UrunBilgileri.UrunAd, SatilanUrunler.Fiyat, SatilanUrunler.Adet, SatilanUrunler.ToplamTutar from Satis,SatilanUrunler,UrunBilgileri where Satis.FaturaNo=SatilanUrunler.FaturaNo and UrunBilgileri.UrunID=SatilanUrunler.UrunID and Satis.FaturaNo='" + dr.Cells[0].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read()==true)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    frmSales.ListView1.Items.Add(lst);
                 }
                frmSales.ListView1.Enabled = false;
                frmSales.btnSepet.Enabled = false;
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void DataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView3.SelectedRows[0];
                this.Hide();
                frmFatura frmSales = new frmFatura();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                frmSales.Show();
                frmSales.txtFaturaNo.Text = dr.Cells[0].Value.ToString();
                frmSales.dtpFaturaTarih.Text = dr.Cells[1].Value.ToString();
                frmSales.txtMusteriID.Text = dr.Cells[2].Value.ToString();
                frmSales.txtMusteriAdi.Text = dr.Cells[3].Value.ToString();
                frmSales.txtAraToplam.Text = dr.Cells[4].Value.ToString();
                frmSales.txtKDVYüzde.Text = dr.Cells[5].Value.ToString();
                frmSales.txtKDVMiktarı.Text = dr.Cells[6].Value.ToString();
                frmSales.txtGenelÖdeme.Text = dr.Cells[7].Value.ToString();
                frmSales.txtToplamÖdenen.Text = dr.Cells[8].Value.ToString();
                frmSales.txtÖdeme.Text = dr.Cells[9].Value.ToString();
                frmSales.txtUyarilar.Text = dr.Cells[10].Value.ToString();
                frmSales.btnGuncelle.Enabled = true;
                frmSales.btnSil.Enabled = true;
                frmSales.btnYazdır.Enabled = true;
                frmSales.btnKaydet.Enabled = false;
                frmSales.label6.Text = label9.Text;
                con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("SELECT UrunBilgileri.UrunID, UrunBilgileri.UrunAd, SatilanUrunler.Fiyat, SatilanUrunler.Adet, SatilanUrunler.ToplamTutar from Satis,SatilanUrunler,UrunBilgileri where Satis.FaturaNo=SatilanUrunler.FaturaNo and UrunBilgileri.UrunID=SatilanUrunler.UrunID and Satis.FaturaNo='" + dr.Cells[0].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    frmSales.ListView1.Items.Add(lst);
                   
                }
                frmSales.ListView1.Enabled = false;
                frmSales.btnSepet.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void DataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView2.SelectedRows[0];
                this.Hide();
                frmFatura frmSales = new frmFatura();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                frmSales.Show();
                frmSales.txtFaturaNo.Text = dr.Cells[0].Value.ToString();
                frmSales.dtpFaturaTarih.Text = dr.Cells[1].Value.ToString();
                frmSales.txtMusteriID.Text = dr.Cells[2].Value.ToString();
                frmSales.txtMusteriAdi.Text = dr.Cells[3].Value.ToString();
                frmSales.txtAraToplam.Text = dr.Cells[4].Value.ToString();
                frmSales.txtKDVYüzde.Text = dr.Cells[5].Value.ToString();
                frmSales.txtKDVMiktarı.Text = dr.Cells[6].Value.ToString();
                frmSales.txtGenelÖdeme.Text = dr.Cells[7].Value.ToString();
                frmSales.txtToplamÖdenen.Text = dr.Cells[8].Value.ToString();
                frmSales.txtÖdeme.Text = dr.Cells[9].Value.ToString();
                frmSales.txtUyarilar.Text = dr.Cells[10].Value.ToString();
                frmSales.btnGuncelle.Enabled = true;
                frmSales.btnSil.Enabled = true;
                frmSales.btnYazdır.Enabled = true;
                frmSales.btnKaydet.Enabled = false;
                frmSales.label6.Text = label9.Text;
                con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("SELECT UrunBilgileri.UrunID, UrunBilgileri.UrunAd,SatilanUrunler.Fiyat,SatilanUrunler.Adet,SatilanUrunler.ToplamTutar from Satis,SatilanUrunler,UrunBilgileri where Satis.FaturaNo=UrunBilgileri.FaturaNo and UrunBilgileri.UrunID=SatilanUrunler.UrunID and Satis.FaturaNo='" + dr.Cells[0].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    frmSales.ListView1.Items.Add(lst);

                }
                frmSales.ListView1.Enabled = false;
                frmSales.btnSepet.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = null;
            dtpFaturaTarih1.Text = DateTime.Today.ToString();
            dtpFaturaTarih2.Text = DateTime.Today.ToString();
            GroupBox3.Visible = false;
            DataGridView3.DataSource = null;
            cmbMusteriAd.Text = "";
            GroupBox4.Visible = false;
            DateTimePicker1.Text = DateTime.Today.ToString();
            DateTimePicker2.Text = DateTime.Today.ToString();
            DataGridView2.DataSource = null;
            GroupBox10.Visible = false;

        }

    }

}
