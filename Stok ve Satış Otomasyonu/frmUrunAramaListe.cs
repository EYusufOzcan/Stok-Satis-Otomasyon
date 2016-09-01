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
    public partial class frmUrunAramaListe : Form
    {
        OleDbDataReader rdr = null;
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmUrunAramaListe()
        { InitializeComponent(); }

        public void VeriAl()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select (UrunAd) as [Ürün Adı], Kategori, Marka from Urun order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {  dataGridView1.Rows.Add(rdr[0],rdr[1],rdr[2]); }
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void frmUrunAramaListe_Load(object sender, EventArgs e)
        { VeriAl(); }

        private void txtUrunAd_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select (UrunAd) as [Ürün Adı], Kategori, Marka from Urun where UrunAd like '" + txtUrunAd.Text + "%' order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {  dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]); }
                con.Close(); }
          
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtKategori_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select (UrunAd) as [Ürün Adı], Kategori, Marka from Urun where Kategori like '" + txtKategori.Text + "%' order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {  dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]); }
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void txtMarka_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select (UrunAd) as [Ürün Adı], Kategori, Marka from Urun where Kategori like '" + txtMarka.Text + "%' order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {  dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]); }
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void Button3_Click(object sender, EventArgs e)
        {
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
                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;
                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }

            finally
            {   System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null; } }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {  dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)); } } }
