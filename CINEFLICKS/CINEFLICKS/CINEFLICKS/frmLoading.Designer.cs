
namespace CINEFLICKS
{
    partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.tmrLoading = new System.Windows.Forms.Timer(this.components);
            this.proBarLoading = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.SuspendLayout();
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel2.Location = new System.Drawing.Point(81, 50);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(90, 17);
            this.bunifuLabel2.TabIndex = 6;
            this.bunifuLabel2.Text = "PROCESSING...";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // tmrLoading
            // 
            this.tmrLoading.Enabled = true;
            this.tmrLoading.Interval = 50;
            this.tmrLoading.Tick += new System.EventHandler(this.tmrLoading_Tick);
            // 
            // proBarLoading
            // 
            this.proBarLoading.AllowAnimations = false;
            this.proBarLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.proBarLoading.Animation = 0;
            this.proBarLoading.AnimationSpeed = 220;
            this.proBarLoading.AnimationStep = 10;
            this.proBarLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.proBarLoading.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("proBarLoading.BackgroundImage")));
            this.proBarLoading.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.proBarLoading.BorderRadius = 5;
            this.proBarLoading.BorderThickness = 1;
            this.proBarLoading.Location = new System.Drawing.Point(24, 22);
            this.proBarLoading.Maximum = 100;
            this.proBarLoading.MaximumValue = 100;
            this.proBarLoading.Minimum = 0;
            this.proBarLoading.MinimumValue = 0;
            this.proBarLoading.Name = "proBarLoading";
            this.proBarLoading.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.proBarLoading.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.proBarLoading.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.proBarLoading.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.proBarLoading.Size = new System.Drawing.Size(201, 11);
            this.proBarLoading.TabIndex = 8;
            this.proBarLoading.Value = 0;
            this.proBarLoading.ValueByTransition = 0;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(248, 89);
            this.Controls.Add(this.proBarLoading);
            this.Controls.Add(this.bunifuLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CINEFLICKS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuProgressBar proBarLoading;
        private System.Windows.Forms.Timer tmrLoading;
    }
}