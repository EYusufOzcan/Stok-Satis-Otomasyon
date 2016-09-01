namespace Stok_ve_Satis_Otomasyonu
{
    partial class frmMusteriler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMusteriler));
            this.Button2 = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.txtEvTel = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtFaksNo = new System.Windows.Forms.TextBox();
            this.txtNot = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.cmbİl = new System.Windows.Forms.ComboBox();
            this.txtİlce = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtMusteriAd = new System.Windows.Forms.TextBox();
            this.txtMusteriID = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPostaKodu = new System.Windows.Forms.TextBox();
            this.txtCepTel = new System.Windows.Forms.TextBox();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(295, 80);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(29, 21);
            this.Button2.TabIndex = 14;
            this.Button2.Text = "<";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSil.Location = new System.Drawing.Point(16, 124);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(87, 29);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "&Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnSil);
            this.GroupBox2.Controls.Add(this.btnGuncelle);
            this.GroupBox2.Controls.Add(this.btnKaydet);
            this.GroupBox2.Controls.Add(this.btnYeni);
            this.GroupBox2.Location = new System.Drawing.Point(482, 66);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(119, 169);
            this.GroupBox2.TabIndex = 11;
            this.GroupBox2.TabStop = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuncelle.Location = new System.Drawing.Point(16, 89);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(87, 29);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "&Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.Location = new System.Drawing.Point(16, 54);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(87, 29);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "&Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYeni.Location = new System.Drawing.Point(16, 19);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(87, 29);
            this.btnYeni.TabIndex = 0;
            this.btnYeni.Text = "&Yeni Kayıt";
            this.btnYeni.UseVisualStyleBackColor = true;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // txtEvTel
            // 
            this.txtEvTel.Location = new System.Drawing.Point(160, 327);
            this.txtEvTel.Name = "txtEvTel";
            this.txtEvTel.Size = new System.Drawing.Size(119, 20);
            this.txtEvTel.TabIndex = 7;
            this.txtEvTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefon_KeyPress);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.LightGray;
            this.Label11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(31, 29);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(133, 22);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "Müşteri Bilgileri";
            // 
            // txtFaksNo
            // 
            this.txtFaksNo.Location = new System.Drawing.Point(161, 440);
            this.txtFaksNo.Name = "txtFaksNo";
            this.txtFaksNo.Size = new System.Drawing.Size(119, 20);
            this.txtFaksNo.TabIndex = 10;
            this.txtFaksNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFaksNo_KeyPress);
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(161, 492);
            this.txtNot.Multiline = true;
            this.txtNot.Name = "txtNot";
            this.txtNot.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNot.Size = new System.Drawing.Size(251, 67);
            this.txtNot.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(161, 365);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(226, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.Location = new System.Drawing.Point(37, 493);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(29, 17);
            this.Label23.TabIndex = 12;
            this.Label23.Text = "Not";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.Location = new System.Drawing.Point(37, 440);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(56, 17);
            this.Label22.TabIndex = 11;
            this.Label22.Text = "Faks No.";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.Location = new System.Drawing.Point(37, 406);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(87, 17);
            this.Label21.TabIndex = 10;
            this.Label21.Text = "*Cep Telefonu";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.Location = new System.Drawing.Point(37, 365);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(38, 17);
            this.Label20.TabIndex = 9;
            this.Label20.Text = "Email";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(37, 327);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(74, 17);
            this.Label19.TabIndex = 8;
            this.Label19.Text = "Ev Telefonu";
            // 
            // cmbİl
            // 
            this.cmbİl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbİl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbİl.FormattingEnabled = true;
            this.cmbİl.Items.AddRange(new object[] {
            "İstanbul",
            "Ankara",
            "İzmir",
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkari",
            "Hatay",
            "Iğdır",
            "Isparta",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kilis",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Şanlıurfa",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"});
            this.cmbİl.Location = new System.Drawing.Point(160, 205);
            this.cmbİl.Name = "cmbİl";
            this.cmbİl.Size = new System.Drawing.Size(172, 21);
            this.cmbİl.TabIndex = 4;
            // 
            // txtİlce
            // 
            this.txtİlce.Location = new System.Drawing.Point(160, 238);
            this.txtİlce.Name = "txtİlce";
            this.txtİlce.Size = new System.Drawing.Size(144, 20);
            this.txtİlce.TabIndex = 5;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(160, 152);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(273, 36);
            this.txtAdres.TabIndex = 3;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(37, 285);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(76, 17);
            this.Label9.TabIndex = 7;
            this.Label9.Text = "*Posta Kodu";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(37, 241);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(32, 17);
            this.Label8.TabIndex = 6;
            this.Label8.Text = "*İlçe";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(37, 206);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(21, 17);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "*İl";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(37, 155);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 17);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "*Adres";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(37, 116);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(77, 17);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "*Müşteri Adı";
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Location = new System.Drawing.Point(160, 115);
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.Size = new System.Drawing.Size(273, 20);
            this.txtMusteriAd.TabIndex = 1;
            // 
            // txtMusteriID
            // 
            this.txtMusteriID.Location = new System.Drawing.Point(161, 81);
            this.txtMusteriID.Name = "txtMusteriID";
            this.txtMusteriID.ReadOnly = true;
            this.txtMusteriID.Size = new System.Drawing.Size(118, 20);
            this.txtMusteriID.TabIndex = 20;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(37, 81);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(68, 17);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Müşteri ID";
            // 
            // txtPostaKodu
            // 
            this.txtPostaKodu.Location = new System.Drawing.Point(160, 285);
            this.txtPostaKodu.Name = "txtPostaKodu";
            this.txtPostaKodu.Size = new System.Drawing.Size(100, 20);
            this.txtPostaKodu.TabIndex = 6;
            this.txtPostaKodu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostaKodu_KeyPress);
            this.txtPostaKodu.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostaKodu_Validating);
            // 
            // txtCepTel
            // 
            this.txtCepTel.Location = new System.Drawing.Point(161, 406);
            this.txtCepTel.Name = "txtCepTel";
            this.txtCepTel.Size = new System.Drawing.Size(119, 20);
            this.txtCepTel.TabIndex = 9;
            this.txtCepTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtCepTel.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // frmMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(639, 598);
            this.Controls.Add(this.txtCepTel);
            this.Controls.Add(this.txtPostaKodu);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtEvTel);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtFaksNo);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.cmbİl);
            this.Controls.Add(this.txtİlce);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtMusteriAd);
            this.Controls.Add(this.txtMusteriID);
            this.Controls.Add(this.Label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMusteriler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Kayıt";
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnSil;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnGuncelle;
        internal System.Windows.Forms.Button btnKaydet;
        internal System.Windows.Forms.Button btnYeni;
        internal System.Windows.Forms.TextBox txtEvTel;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtFaksNo;
        internal System.Windows.Forms.TextBox txtNot;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox cmbİl;
        internal System.Windows.Forms.TextBox txtİlce;
        internal System.Windows.Forms.TextBox txtAdres;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtMusteriAd;
        internal System.Windows.Forms.TextBox txtMusteriID;
        internal System.Windows.Forms.Label Label4;
        public System.Windows.Forms.TextBox txtPostaKodu;
        public System.Windows.Forms.TextBox txtCepTel;
    }
}