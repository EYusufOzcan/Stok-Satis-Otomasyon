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
    public partial class frmMarka : Form
    {
        OleDbDataReader rdr = null;
        DataTable dtable = new DataTable();
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        DataTable dt = new DataTable();
        String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Veritabanı.accdb;";

        public frmMarka()
        {  InitializeComponent(); }

        private void frmMarka_Load(object sender, EventArgs e)
        { Oto_tam(); }

        private void Sıfırla()
        {  txtMarkaAdi.Text = "";
           btnKaydet.Enabled = true;
           btnSil.Enabled = false;
           btnGuncelle.Enabled = false;
           txtMarkaAdi.Focus(); }

        private void btnYeni_Click(object sender, EventArgs e)
        { Sıfırla(); }

        private void btnKaydet_Click(object sender, EventArgs e)
        {   if (txtMarkaAdi.Text == "")
            {   MessageBox.Show("Lütfen marka adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMarkaAdi.Focus();
                return; }
            try
            {   con = new OleDbConnection(cs);
                con.Open();
                string ct = "select MarkaAd from Marka where MarkaAd='" + txtMarkaAdi.Text + "'";
                cmd = new OleDbCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {   MessageBox.Show("Bu marka adı zaten var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarkaAdi.Text = "";
                    txtMarkaAdi.Focus();
                    if ((rdr != null))
                    {  rdr.Close();  }
                    return;  }
                con = new OleDbConnection(cs);
                con.Open();
                string cb = "insert into Marka (MarkaAd) values ('" + txtMarkaAdi.Text + "')";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde kaydedildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                btnKaydet.Enabled = false; }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }  }

        private void Oto_tam()
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("select distinct MarkaAd from Marka", con);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds, "Marka");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                { col.Add(ds.Tables[0].Rows[i]["MarkaAd"].ToString()); }
                txtMarkaAdi.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMarkaAdi.AutoCompleteCustomSource = col;
                txtMarkaAdi.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();  }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  } }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı gerçekten silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {  Kayıt_sil(); } }

        private void Kayıt_sil()
        {   try
            {   int Etki = 0;
                con = new OleDbConnection(cs);
                con.Open();
                string cq = "delete from Marka where MarkaAd='" + txtMarkaAdi.Text + "'";
                cmd = new OleDbCommand(cq);
                cmd.Connection = con;
                Etki = cmd.ExecuteNonQuery();
                if (Etki > 0)
                {   MessageBox.Show("Başarılı bir şekilde silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();
                    Oto_tam();  }

                else
                {   MessageBox.Show("Kayıt bulunamadı!", "Üzgünüz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sıfırla();
                    Oto_tam();   }

                if (con.State == ConnectionState.Open)
                { con.Close();  } }

            catch (Exception ex)
            {  MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void btnVeriler_Click(object sender, EventArgs e)
        {   this.Hide();
            frmMarkaListe frm = new frmMarkaListe();
            frm.Show();
            frm.VeriAl(); }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {   try
            {   con = new OleDbConnection(cs);
                con.Open();
                string cb = "update Marka set MarkaAd='" + txtMarkaAdi.Text + "' where MarkaAd='" + textBox1.Text + "'";
                cmd = new OleDbCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Başarılı bir şekilde güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Oto_tam();
                btnGuncelle.Enabled = false; }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);  }  }  }  }
