﻿using System;
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
    public partial class frmMarkaListe : Form
    {
        OleDbDataReader rdr = null;
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmMarkaListe()
        { InitializeComponent();  }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {   string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {  dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20)); }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));   }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmMarka frm = new frmMarka();
            frm.Show();
            frm.txtMarkaAdi.Text = dr.Cells[0].Value.ToString();
            frm.textBox1.Text = dr.Cells[0].Value.ToString();
            frm.btnSil.Enabled = true;
            frm.btnGuncelle.Enabled = true;
            frm.txtMarkaAdi.Focus();
            frm.btnKaydet.Enabled = false; }

        private void frmMarkaListe_Load(object sender, EventArgs e)
        {  VeriAl(); }

        public void VeriAl()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                String sql = "select * from Marka order by MarkaAd";
                cmd = new OleDbCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                { dataGridView1.Rows.Add(rdr[0]); }
                con.Close(); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void frmMarkaListe_FormClosing(object sender, FormClosingEventArgs e)
        {   this.Hide();
            frmMarka frm = new frmMarka();
            frm.Show(); } } }
