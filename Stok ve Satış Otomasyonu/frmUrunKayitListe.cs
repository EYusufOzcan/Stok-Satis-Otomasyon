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
    public partial class frmUrunKayitListe : Form
    {
        OleDbDataReader rdr = null;
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmUrunKayitListe()
        { InitializeComponent(); }

        public void VeriAl()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("SELECT * from UrunBilgileri order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                { dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3]); }
                con.Close(); }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void frmUrunKayitListe_Load(object sender, EventArgs e)
        { VeriAl(); }

        private void txtUrunAd_TextChanged(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                cmd = new OleDbCommand("select * from UrunBilgileri where UrunAd like '" + txtUrunAd.Text + "%' order by UrunAd", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                { dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]); }
                con.Close(); }

            catch (Exception ex)
            {   MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            { dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)); }
       
        private void frmUrunKayitListe_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmStok frm = new frmStok();
            frm.label8.Text = label1.Text;
            frm.Show(); }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   try
            {   DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmStok frm = new frmStok();
                frm.Show();
                frm.txtUrunID.Text = dr.Cells[0].Value.ToString();
                frm.txtUrunAd.Text = dr.Cells[1].Value.ToString();
                frm.txtOzellikler.Text = dr.Cells[2].Value.ToString();
                frm.txtFiyat.Text = dr.Cells[3].Value.ToString();
                frm.label8.Text = label1.Text;
                frm.txtAdet.Focus(); }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } } } }
