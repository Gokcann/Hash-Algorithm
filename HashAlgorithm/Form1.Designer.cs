namespace HashAlgorithm
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.kayit = new System.Windows.Forms.Button();
            this.giris = new System.Windows.Forms.Button();
            this.kullanici = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // kayit
            // 
            this.kayit.Location = new System.Drawing.Point(230, 152);
            this.kayit.Name = "kayit";
            this.kayit.Size = new System.Drawing.Size(103, 45);
            this.kayit.TabIndex = 0;
            this.kayit.Text = "Kayit Ol";
            this.kayit.UseVisualStyleBackColor = true;
            this.kayit.Click += new System.EventHandler(this.kayit_Click);
            // 
            // giris
            // 
            this.giris.Location = new System.Drawing.Point(230, 218);
            this.giris.Name = "giris";
            this.giris.Size = new System.Drawing.Size(103, 45);
            this.giris.TabIndex = 1;
            this.giris.Text = "Giris Yap";
            this.giris.UseVisualStyleBackColor = true;
            this.giris.Click += new System.EventHandler(this.giris_Click);
            // 
            // kullanici
            // 
            this.kullanici.Location = new System.Drawing.Point(196, 61);
            this.kullanici.Name = "kullanici";
            this.kullanici.Size = new System.Drawing.Size(160, 20);
            this.kullanici.TabIndex = 2;
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(196, 110);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(160, 20);
            this.sifre.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanici Adi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sifre";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(372, 113);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Sifreyi Goster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanici);
            this.Controls.Add(this.giris);
            this.Controls.Add(this.kayit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kayit;
        private System.Windows.Forms.Button giris;
        private System.Windows.Forms.TextBox kullanici;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

