namespace uretimrecetesi
{
    partial class yoneticipaneli
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.personelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üretimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelPersonelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinliPersonelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkarılanPersonelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personelToolStripMenuItem,
            this.depoToolStripMenuItem,
            this.üretimToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(847, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // personelToolStripMenuItem
            // 
            this.personelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genelPersonelToolStripMenuItem,
            this.izinliPersonelToolStripMenuItem,
            this.çıkarılanPersonelToolStripMenuItem});
            this.personelToolStripMenuItem.Name = "personelToolStripMenuItem";
            this.personelToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.personelToolStripMenuItem.Text = "Personel";
            // 
            // üretimToolStripMenuItem
            // 
            this.üretimToolStripMenuItem.Name = "üretimToolStripMenuItem";
            this.üretimToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.üretimToolStripMenuItem.Text = "Üretim";
            // 
            // depoToolStripMenuItem
            // 
            this.depoToolStripMenuItem.Name = "depoToolStripMenuItem";
            this.depoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.depoToolStripMenuItem.Text = "Depo";
            // 
            // genelPersonelToolStripMenuItem
            // 
            this.genelPersonelToolStripMenuItem.Name = "genelPersonelToolStripMenuItem";
            this.genelPersonelToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.genelPersonelToolStripMenuItem.Text = "Genel Personel";
            // 
            // izinliPersonelToolStripMenuItem
            // 
            this.izinliPersonelToolStripMenuItem.Name = "izinliPersonelToolStripMenuItem";
            this.izinliPersonelToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.izinliPersonelToolStripMenuItem.Text = "İzinli Personel";
            // 
            // çıkarılanPersonelToolStripMenuItem
            // 
            this.çıkarılanPersonelToolStripMenuItem.Name = "çıkarılanPersonelToolStripMenuItem";
            this.çıkarılanPersonelToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.çıkarılanPersonelToolStripMenuItem.Text = "Çıkarılan Personel";
            // 
            // yoneticipaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(847, 456);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "yoneticipaneli";
            this.Text = "Yönetici Paneli";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.yoneticipaneli_FormClosed);
            this.Load += new System.EventHandler(this.yoneticipaneli_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem personelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genelPersonelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinliPersonelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkarılanPersonelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üretimToolStripMenuItem;
    }
}