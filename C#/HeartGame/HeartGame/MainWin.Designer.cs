namespace HeartGame
{
	partial class MainWin
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thisGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.restartToolStripMenuItem1,
            this.statisticsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.startToolStripMenuItem.Text = "Start";
			// 
			// restartToolStripMenuItem
			// 
			this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
			this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.restartToolStripMenuItem.Text = "Save";
			// 
			// restartToolStripMenuItem1
			// 
			this.restartToolStripMenuItem1.Name = "restartToolStripMenuItem1";
			this.restartToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.restartToolStripMenuItem1.Text = "Restart";
			// 
			// statisticsToolStripMenuItem
			// 
			this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
			this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.statisticsToolStripMenuItem.Text = "Statistics";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.contactToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// howToPlayToolStripMenuItem
			// 
			this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
			this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.howToPlayToolStripMenuItem.Text = "How to Play";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateLogToolStripMenuItem,
            this.thisGameToolStripMenuItem});
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.infoToolStripMenuItem.Text = "Info";
			// 
			// contactToolStripMenuItem
			// 
			this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
			this.contactToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.contactToolStripMenuItem.Text = "Contact";
			// 
			// updateLogToolStripMenuItem
			// 
			this.updateLogToolStripMenuItem.Name = "updateLogToolStripMenuItem";
			this.updateLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.updateLogToolStripMenuItem.Text = "Update Log";
			// 
			// thisGameToolStripMenuItem
			// 
			this.thisGameToolStripMenuItem.Name = "thisGameToolStripMenuItem";
			this.thisGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.thisGameToolStripMenuItem.Text = "This Game";
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 750);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWin";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thisGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
	}
}

