namespace EsApiTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eSStartSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miStart = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetPic = new System.Windows.Forms.ToolStripMenuItem();
            this.miSendKey = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetRemoteMouse = new System.Windows.Forms.ToolStripMenuItem();
            this.miEndSession = new System.Windows.Forms.ToolStripMenuItem();
            this.testWithCallbakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miStartCallback = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eSStartSessionToolStripMenuItem,
            this.testWithCallbakToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eSStartSessionToolStripMenuItem
            // 
            this.eSStartSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStart,
            this.miGetPic,
            this.miSendKey,
            this.miSetRemoteMouse,
            this.miEndSession});
            this.eSStartSessionToolStripMenuItem.Name = "eSStartSessionToolStripMenuItem";
            this.eSStartSessionToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.eSStartSessionToolStripMenuItem.Text = "test";
            // 
            // miStart
            // 
            this.miStart.Name = "miStart";
            this.miStart.Size = new System.Drawing.Size(198, 22);
            this.miStart.Text = "ES_StartSession";
            this.miStart.Click += new System.EventHandler(this.miStart_Click);
            // 
            // miGetPic
            // 
            this.miGetPic.Enabled = false;
            this.miGetPic.Name = "miGetPic";
            this.miGetPic.Size = new System.Drawing.Size(198, 22);
            this.miGetPic.Text = "GetPicture";
            this.miGetPic.Click += new System.EventHandler(this.miGetPic_Click);
            // 
            // miSendKey
            // 
            this.miSendKey.Enabled = false;
            this.miSendKey.Name = "miSendKey";
            this.miSendKey.Size = new System.Drawing.Size(198, 22);
            this.miSendKey.Text = "ES_SendKey";
            this.miSendKey.Click += new System.EventHandler(this.miSendKey_Click);
            // 
            // miSetRemoteMouse
            // 
            this.miSetRemoteMouse.Enabled = false;
            this.miSetRemoteMouse.Name = "miSetRemoteMouse";
            this.miSetRemoteMouse.Size = new System.Drawing.Size(198, 22);
            this.miSetRemoteMouse.Text = "ES_SetRemoteMouse";
            this.miSetRemoteMouse.Click += new System.EventHandler(this.miSetRemoteMouse_Click);
            // 
            // miEndSession
            // 
            this.miEndSession.Enabled = false;
            this.miEndSession.Name = "miEndSession";
            this.miEndSession.Size = new System.Drawing.Size(198, 22);
            this.miEndSession.Text = "ES_EndSession";
            this.miEndSession.Click += new System.EventHandler(this.miEndSession_Click);
            // 
            // testWithCallbakToolStripMenuItem
            // 
            this.testWithCallbakToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartCallback});
            this.testWithCallbakToolStripMenuItem.Name = "testWithCallbakToolStripMenuItem";
            this.testWithCallbakToolStripMenuItem.Size = new System.Drawing.Size(113, 21);
            this.testWithCallbakToolStripMenuItem.Text = "TestWithCallbak";
            // 
            // miStartCallback
            // 
            this.miStartCallback.Name = "miStartCallback";
            this.miStartCallback.Size = new System.Drawing.Size(180, 22);
            this.miStartCallback.Text = "Start";
            this.miStartCallback.Click += new System.EventHandler(this.miStartCallback_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eSStartSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miStart;
        private System.Windows.Forms.ToolStripMenuItem miGetPic;
        private System.Windows.Forms.ToolStripMenuItem miSendKey;
        private System.Windows.Forms.ToolStripMenuItem miSetRemoteMouse;
        private System.Windows.Forms.ToolStripMenuItem miEndSession;
        private System.Windows.Forms.ToolStripMenuItem testWithCallbakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miStartCallback;
    }
}

