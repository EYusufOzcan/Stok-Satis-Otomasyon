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
    public partial class frmSistemKullaniciListesi : Form
    {
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";
        public frmSistemKullaniciListesi()
        { InitializeComponent(); }

        private OleDbConnection Connection
        {
            get
            {   OleDbConnection ConnectionToFetch = new OleDbConnection(cs);
                ConnectionToFetch.Open();
                return ConnectionToFetch; } }
        public DataView VeriAl()
        {
            dynamic SelectQry = "select (Rol) as [Rol] ,(KullaniciAd) as [Kullanıcı Adı],(KullaniciSifre) as [Sifre] from Kullanicilar ";
            DataSet SampleSource = new DataSet();
            DataView TableView = null;
            try
            {
                OleDbCommand SampleCommand = new OleDbCommand();
                dynamic SampleDataAdapter = new OleDbDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(SampleSource);
                TableView = SampleSource.Tables[0].DefaultView; }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return TableView; }

        private void frmSistemKullaniciListesi_Load(object sender, EventArgs e)
        { dataGridView1.DataSource = VeriAl();  }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2)); } } }
