namespace SOR4_Blender
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.activePanel = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelVerNum = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.imgSF = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgTwitch = new System.Windows.Forms.PictureBox();
            this.imgYoutube = new System.Windows.Forms.PictureBox();
            this.imgBMCSupport = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdateNotif = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYoutube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBMCSupport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // activePanel
            // 
            this.activePanel.Location = new System.Drawing.Point(0, 33);
            this.activePanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.activePanel.Name = "activePanel";
            this.activePanel.Size = new System.Drawing.Size(536, 381);
            this.activePanel.TabIndex = 1;
            this.activePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activePanel_MouseDown);
            this.activePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.activePanel_MouseMove);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DimGray;
            this.panelTop.Controls.Add(this.labelVerNum);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(536, 36);
            this.panelTop.TabIndex = 45;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // labelVerNum
            // 
            this.labelVerNum.AutoSize = true;
            this.labelVerNum.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerNum.ForeColor = System.Drawing.Color.White;
            this.labelVerNum.Location = new System.Drawing.Point(138, 13);
            this.labelVerNum.Name = "labelVerNum";
            this.labelVerNum.Size = new System.Drawing.Size(27, 13);
            this.labelVerNum.TabIndex = 44;
            this.labelVerNum.Text = "v1.2";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(464, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(36, 36);
            this.btnMinimize.TabIndex = 42;
            this.btnMinimize.Text = "̶̶";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(500, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(12, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(125, 21);
            this.labelTitle.TabIndex = 41;
            this.labelTitle.Text = "SOR4 BLENDER";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // imgSF
            // 
            this.imgSF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgSF.Location = new System.Drawing.Point(420, 38);
            this.imgSF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgSF.Name = "imgSF";
            this.imgSF.Size = new System.Drawing.Size(95, 20);
            this.imgSF.TabIndex = 75;
            this.imgSF.TabStop = false;
            this.imgSF.Click += new System.EventHandler(this.imgSF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(467, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "Updates on";
            // 
            // imgTwitch
            // 
            this.imgTwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgTwitch.Location = new System.Drawing.Point(403, 41);
            this.imgTwitch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgTwitch.Name = "imgTwitch";
            this.imgTwitch.Size = new System.Drawing.Size(15, 16);
            this.imgTwitch.TabIndex = 77;
            this.imgTwitch.TabStop = false;
            // 
            // imgYoutube
            // 
            this.imgYoutube.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgYoutube.Location = new System.Drawing.Point(378, 41);
            this.imgYoutube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgYoutube.Name = "imgYoutube";
            this.imgYoutube.Size = new System.Drawing.Size(23, 16);
            this.imgYoutube.TabIndex = 76;
            this.imgYoutube.TabStop = false;
            // 
            // imgBMCSupport
            // 
            this.imgBMCSupport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgBMCSupport.InitialImage = null;
            this.imgBMCSupport.Location = new System.Drawing.Point(25, 15);
            this.imgBMCSupport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgBMCSupport.Name = "imgBMCSupport";
            this.imgBMCSupport.Size = new System.Drawing.Size(152, 43);
            this.imgBMCSupport.TabIndex = 74;
            this.imgBMCSupport.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdateNotif);
            this.panel1.Controls.Add(this.imgBMCSupport);
            this.panel1.Controls.Add(this.imgSF);
            this.panel1.Controls.Add(this.imgYoutube);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imgTwitch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 78);
            this.panel1.TabIndex = 79;
            // 
            // btnUpdateNotif
            // 
            this.btnUpdateNotif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUpdateNotif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateNotif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateNotif.Location = new System.Drawing.Point(196, 15);
            this.btnUpdateNotif.Name = "btnUpdateNotif";
            this.btnUpdateNotif.Size = new System.Drawing.Size(160, 43);
            this.btnUpdateNotif.TabIndex = 82;
            this.btnUpdateNotif.Text = "vx.x is now available!\r\nGET IT NOW!";
            this.btnUpdateNotif.UseVisualStyleBackColor = false;
            this.btnUpdateNotif.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.activePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainWindow";
            this.Text = "SOR4 Blender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYoutube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBMCSupport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel activePanel;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.PictureBox imgSF;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox imgTwitch;
        public System.Windows.Forms.PictureBox imgYoutube;
        public System.Windows.Forms.PictureBox imgBMCSupport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelVerNum;
        public System.Windows.Forms.Button btnUpdateNotif;
    }
}

