namespace Stok_ve_Satis_Otomasyonu
{
    partial class frmAnasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnasayfa));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.musterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araclarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hesapMakinesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordpadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.görevYöneticisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSWordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Kullanici = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMusteriRaporu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKullaniciYönet = new System.Windows.Forms.Button();
            this.btnFatura = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnUrunOzellikleri = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnFirma = new System.Windows.Forms.Button();
            this.btnStokAra = new System.Windows.Forms.Button();
            this.btnKullanicilar = new System.Windows.Forms.Button();
            this.btnMusteriEkle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musterilerToolStripMenuItem,
            this.urunlerToolStripMenuItem,
            this.stokToolStripMenuItem,
            this.faturaToolStripMenuItem,
            this.raporToolStripMenuItem,
            this.araclarToolStripMenuItem1,
            this.cikisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 78);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // musterilerToolStripMenuItem
            // 
            this.musterilerToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musterilerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.musterilerToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.Usergroup;
            this.musterilerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.musterilerToolStripMenuItem.Name = "musterilerToolStripMenuItem";
            this.musterilerToolStripMenuItem.Size = new System.Drawing.Size(83, 74);
            this.musterilerToolStripMenuItem.Text = "Müşteriler";
            this.musterilerToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.musterilerToolStripMenuItem.Click += new System.EventHandler(this.musterilerToolStripMenuItem_Click);
            // 
            // urunlerToolStripMenuItem
            // 
            this.urunlerToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunlerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.urunlerToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.Box;
            this.urunlerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.urunlerToolStripMenuItem.Name = "urunlerToolStripMenuItem";
            this.urunlerToolStripMenuItem.Size = new System.Drawing.Size(67, 74);
            this.urunlerToolStripMenuItem.Text = "Ürünler";
            this.urunlerToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.urunlerToolStripMenuItem.Click += new System.EventHandler(this.urunlerToolStripMenuItem_Click);
            // 
            // stokToolStripMenuItem
            // 
            this.stokToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.stokToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.stokToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.stock_icon_v_3;
            this.stokToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stokToolStripMenuItem.Name = "stokToolStripMenuItem";
            this.stokToolStripMenuItem.Size = new System.Drawing.Size(97, 74);
            this.stokToolStripMenuItem.Text = "Mevcut Stok";
            this.stokToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stokToolStripMenuItem.Click += new System.EventHandler(this.stokToolStripMenuItem_Click);
            // 
            // faturaToolStripMenuItem
            // 
            this.faturaToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.faturaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.faturaToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.CCRQInvoice;
            this.faturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.faturaToolStripMenuItem.Name = "faturaToolStripMenuItem";
            this.faturaToolStripMenuItem.Size = new System.Drawing.Size(62, 74);
            this.faturaToolStripMenuItem.Text = "Fatura";
            this.faturaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.faturaToolStripMenuItem.Click += new System.EventHandler(this.faturaToolStripMenuItem_Click);
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.raporToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.raporToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources._1425499519_button_34;
            this.raporToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(93, 74);
            this.raporToolStripMenuItem.Text = "Satış Rapor";
            this.raporToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.raporToolStripMenuItem.Click += new System.EventHandler(this.raporToolStripMenuItem_Click);
            // 
            // araclarToolStripMenuItem1
            // 
            this.araclarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem1,
            this.hesapMakinesiToolStripMenuItem,
            this.wordpadToolStripMenuItem1,
            this.görevYöneticisiToolStripMenuItem,
            this.mSWordToolStripMenuItem1});
            this.araclarToolStripMenuItem1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.araclarToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.araclarToolStripMenuItem1.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.Utilities_icon__5_;
            this.araclarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.araclarToolStripMenuItem1.Name = "araclarToolStripMenuItem1";
            this.araclarToolStripMenuItem1.Size = new System.Drawing.Size(65, 74);
            this.araclarToolStripMenuItem1.Text = "Araçlar";
            this.araclarToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // notepadToolStripMenuItem1
            // 
            this.notepadToolStripMenuItem1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.notepadToolStripMenuItem1.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.Notepad1;
            this.notepadToolStripMenuItem1.Name = "notepadToolStripMenuItem1";
            this.notepadToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.notepadToolStripMenuItem1.Text = "Notepad";
            this.notepadToolStripMenuItem1.Click += new System.EventHandler(this.notepadToolStripMenuItem1_Click);
            // 
            // hesapMakinesiToolStripMenuItem
            // 
            this.hesapMakinesiToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hesapMakinesiToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.calc;
            this.hesapMakinesiToolStripMenuItem.Name = "hesapMakinesiToolStripMenuItem";
            this.hesapMakinesiToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.hesapMakinesiToolStripMenuItem.Text = "Hesap Makinesi";
            this.hesapMakinesiToolStripMenuItem.Click += new System.EventHandler(this.hesapMakinesiToolStripMenuItem_Click);
            // 
            // wordpadToolStripMenuItem1
            // 
            this.wordpadToolStripMenuItem1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.wordpadToolStripMenuItem1.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.Wordpad_icon__Windows_7_;
            this.wordpadToolStripMenuItem1.Name = "wordpadToolStripMenuItem1";
            this.wordpadToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.wordpadToolStripMenuItem1.Text = "Wordpad";
            this.wordpadToolStripMenuItem1.Click += new System.EventHandler(this.wordpadToolStripMenuItem1_Click);
            // 
            // görevYöneticisiToolStripMenuItem
            // 
            this.görevYöneticisiToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.görevYöneticisiToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.task_manager1;
            this.görevYöneticisiToolStripMenuItem.Name = "görevYöneticisiToolStripMenuItem";
            this.görevYöneticisiToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.görevYöneticisiToolStripMenuItem.Text = "Görev Yöneticisi";
            this.görevYöneticisiToolStripMenuItem.Click += new System.EventHandler(this.görevYöneticisiToolStripMenuItem_Click);
            // 
            // mSWordToolStripMenuItem1
            // 
            this.mSWordToolStripMenuItem1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mSWordToolStripMenuItem1.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.MS_Word_2_icon1;
            this.mSWordToolStripMenuItem1.Name = "mSWordToolStripMenuItem1";
            this.mSWordToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.mSWordToolStripMenuItem1.Text = "MS Word";
            this.mSWordToolStripMenuItem1.Click += new System.EventHandler(this.mSWordToolStripMenuItem1_Click);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cikisToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cikisToolStripMenuItem.Image = global::Stok_ve_Satis_Otomasyonu.Properties.Resources.logout;
            this.cikisToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(62, 74);
            this.cikisToolStripMenuItem.Text = "Çıkış";
            this.cikisToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.cikisToolStripMenuItem_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.Kullanici,
            this.ToolStripStatusLabel3,
            this.ToolStripStatusLabel4});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 472);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(935, 26);
            this.StatusStrip1.TabIndex = 3;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(33, 21);
            this.ToolStripStatusLabel1.Text = "Rol :";
            // 
            // Kullanici
            // 
            this.Kullanici.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kullanici.ForeColor = System.Drawing.Color.Red;
            this.Kullanici.Image = ((System.Drawing.Image)(resources.GetObject("Kullanici.Image")));
            this.Kullanici.Name = "Kullanici";
            this.Kullanici.Size = new System.Drawing.Size(182, 21);
            this.Kullanici.Text = "ToolStripStatusLabel2";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(560, 21);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // ToolStripStatusLabel4
            // 
            this.ToolStripStatusLabel4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel4.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripStatusLabel4.Image")));
            this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            this.ToolStripStatusLabel4.Size = new System.Drawing.Size(145, 21);
            this.ToolStripStatusLabel4.Text = "ToolStripStatusLabel4";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GroupBox1.BackgroundImage")));
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.btnMusteriRaporu);
            this.GroupBox1.Controls.Add(this.groupBox2);
            this.GroupBox1.Controls.Add(this.btnKullaniciYönet);
            this.GroupBox1.Controls.Add(this.btnFatura);
            this.GroupBox1.Controls.Add(this.btnSatis);
            this.GroupBox1.Controls.Add(this.btnUrunEkle);
            this.GroupBox1.Controls.Add(this.btnStok);
            this.GroupBox1.Controls.Add(this.btnUrunOzellikleri);
            this.GroupBox1.Controls.Add(this.btnKategori);
            this.GroupBox1.Controls.Add(this.btnFirma);
            this.GroupBox1.Controls.Add(this.btnStokAra);
            this.GroupBox1.Controls.Add(this.btnKullanicilar);
            this.GroupBox1.Controls.Add(this.btnMusteriEkle);
            this.GroupBox1.Location = new System.Drawing.Point(-10, 61);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(341, 425);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            // 
            // btnMusteriRaporu
            // 
            this.btnMusteriRaporu.BackColor = System.Drawing.Color.AliceBlue;
            this.btnMusteriRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriRaporu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriRaporu.Location = new System.Drawing.Point(33, 335);
            this.btnMusteriRaporu.Name = "btnMusteriRaporu";
            this.btnMusteriRaporu.Size = new System.Drawing.Size(130, 50);
            this.btnMusteriRaporu.TabIndex = 7;
            this.btnMusteriRaporu.Text = "Müşteri Raporu";
            this.btnMusteriRaporu.UseVisualStyleBackColor = false;
            //this.btnMusteriRaporu.Click += new System.EventHandler(this.btnMusteriRaporu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(359, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 680);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // btnKullaniciYönet
            // 
            this.btnKullaniciYönet.BackColor = System.Drawing.Color.AliceBlue;
            this.btnKullaniciYönet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciYönet.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciYönet.Location = new System.Drawing.Point(184, 335);
            this.btnKullaniciYönet.Name = "btnKullaniciYönet";
            this.btnKullaniciYönet.Size = new System.Drawing.Size(130, 50);
            this.btnKullaniciYönet.TabIndex = 13;
            this.btnKullaniciYönet.Text = "Kullanıcıları Yönet";
            this.btnKullaniciYönet.UseVisualStyleBackColor = false;
            this.btnKullaniciYönet.Click += new System.EventHandler(this.btnKullaniciYönet_Click);
            // 
            // btnFatura
            // 
            this.btnFatura.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFatura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFatura.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFatura.Location = new System.Drawing.Point(184, 223);
            this.btnFatura.Name = "btnFatura";
            this.btnFatura.Size = new System.Drawing.Size(130, 50);
            this.btnFatura.TabIndex = 11;
            this.btnFatura.Text = "Fatura";
            this.btnFatura.UseVisualStyleBackColor = false;
            this.btnFatura.Click += new System.EventHandler(this.btnFatura_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSatis.ImageKey = "1295374829_desktop.png";
            this.btnSatis.Location = new System.Drawing.Point(184, 167);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(130, 50);
            this.btnSatis.TabIndex = 10;
            this.btnSatis.Text = "Satış";
            this.btnSatis.UseVisualStyleBackColor = false;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.AliceBlue;
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunEkle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUrunEkle.ImageKey = "loading36.gif";
            this.btnUrunEkle.Location = new System.Drawing.Point(33, 167);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(130, 50);
            this.btnUrunEkle.TabIndex = 3;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnStok
            // 
            this.btnStok.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStok.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStok.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStok.ImageIndex = 16;
            this.btnStok.Location = new System.Drawing.Point(184, 111);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(130, 50);
            this.btnStok.TabIndex = 9;
            this.btnStok.Text = "Stok";
            this.btnStok.UseVisualStyleBackColor = false;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnUrunOzellikleri
            // 
            this.btnUrunOzellikleri.BackColor = System.Drawing.Color.AliceBlue;
            this.btnUrunOzellikleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunOzellikleri.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunOzellikleri.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUrunOzellikleri.ImageIndex = 23;
            this.btnUrunOzellikleri.Location = new System.Drawing.Point(33, 223);
            this.btnUrunOzellikleri.Name = "btnUrunOzellikleri";
            this.btnUrunOzellikleri.Size = new System.Drawing.Size(130, 50);
            this.btnUrunOzellikleri.TabIndex = 4;
            this.btnUrunOzellikleri.Text = "Ürün Özellikleri";
            this.btnUrunOzellikleri.UseVisualStyleBackColor = false;
            this.btnUrunOzellikleri.Click += new System.EventHandler(this.btnUrunOzellikleri_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.BackColor = System.Drawing.Color.AliceBlue;
            this.btnKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategori.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategori.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnKategori.ImageIndex = 24;
            this.btnKategori.Location = new System.Drawing.Point(33, 55);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(130, 50);
            this.btnKategori.TabIndex = 1;
            this.btnKategori.Text = "Kategori";
            this.btnKategori.UseVisualStyleBackColor = false;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnFirma
            // 
            this.btnFirma.BackColor = System.Drawing.Color.AliceBlue;
            this.btnFirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirma.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFirma.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFirma.ImageIndex = 15;
            this.btnFirma.Location = new System.Drawing.Point(33, 111);
            this.btnFirma.Name = "btnFirma";
            this.btnFirma.Size = new System.Drawing.Size(130, 50);
            this.btnFirma.TabIndex = 2;
            this.btnFirma.Text = "Firma/Şirket";
            this.btnFirma.UseVisualStyleBackColor = false;
            this.btnFirma.Click += new System.EventHandler(this.btnFirma_Click);
            // 
            // btnStokAra
            // 
            this.btnStokAra.BackColor = System.Drawing.Color.AliceBlue;
            this.btnStokAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStokAra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokAra.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStokAra.ImageIndex = 20;
            this.btnStokAra.Location = new System.Drawing.Point(184, 55);
            this.btnStokAra.Name = "btnStokAra";
            this.btnStokAra.Size = new System.Drawing.Size(130, 50);
            this.btnStokAra.TabIndex = 8;
            this.btnStokAra.Text = "Stok Ara";
            this.btnStokAra.UseVisualStyleBackColor = false;
            this.btnStokAra.Click += new System.EventHandler(this.btnStokAra_Click);
            // 
            // btnKullanicilar
            // 
            this.btnKullanicilar.BackColor = System.Drawing.Color.AliceBlue;
            this.btnKullanicilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanicilar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullanicilar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnKullanicilar.ImageIndex = 5;
            this.btnKullanicilar.Location = new System.Drawing.Point(184, 279);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new System.Drawing.Size(130, 50);
            this.btnKullanicilar.TabIndex = 12;
            this.btnKullanicilar.Text = "Kullanıcılar";
            this.btnKullanicilar.UseVisualStyleBackColor = false;
            this.btnKullanicilar.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnMusteriEkle
            // 
            this.btnMusteriEkle.BackColor = System.Drawing.Color.AliceBlue;
            this.btnMusteriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriEkle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriEkle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMusteriEkle.ImageIndex = 0;
            this.btnMusteriEkle.Location = new System.Drawing.Point(33, 279);
            this.btnMusteriEkle.Name = "btnMusteriEkle";
            this.btnMusteriEkle.Size = new System.Drawing.Size(130, 50);
            this.btnMusteriEkle.TabIndex = 5;
            this.btnMusteriEkle.Text = "Müşteri Ekle";
            this.btnMusteriEkle.UseVisualStyleBackColor = false;
            this.btnMusteriEkle.Click += new System.EventHandler(this.btnMusteriEkle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(935, 498);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // frmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(935, 498);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmAnasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.frmAnaMenü_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem musterilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel Kullanici;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnKullaniciYönet;
        internal System.Windows.Forms.Button btnFatura;
        internal System.Windows.Forms.Button btnSatis;
        internal System.Windows.Forms.Button btnUrunEkle;
        internal System.Windows.Forms.Button btnStok;
        internal System.Windows.Forms.Button btnUrunOzellikleri;
        internal System.Windows.Forms.Button btnKategori;
        internal System.Windows.Forms.Button btnFirma;
        internal System.Windows.Forms.Button btnStokAra;
        internal System.Windows.Forms.Button btnKullanicilar;
        internal System.Windows.Forms.Button btnMusteriEkle;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnMusteriRaporu;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem araclarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hesapMakinesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordpadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem görevYöneticisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSWordToolStripMenuItem1;
    }
}