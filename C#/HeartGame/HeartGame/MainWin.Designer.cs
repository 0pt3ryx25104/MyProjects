using CardsLibrary;

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
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.scoreBox0 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.scoreBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.scoreBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.scoreBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.hbBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cpBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(689, 595);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 29);
			this.button1.TabIndex = 2;
			this.button1.Text = "카드결정";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBox1.Location = new System.Drawing.Point(793, 27);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(391, 29);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "Log";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(695, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 19);
			this.label1.TabIndex = 4;
			this.label1.Text = "DebugBox";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.scoreBox3);
			this.groupBox1.Controls.Add(this.scoreBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.scoreBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.scoreBox0);
			this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(923, 526);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(249, 174);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Score of Current Game";
			// 
			// scoreBox0
			// 
			this.scoreBox0.Enabled = false;
			this.scoreBox0.Location = new System.Drawing.Point(117, 28);
			this.scoreBox0.Name = "scoreBox0";
			this.scoreBox0.Size = new System.Drawing.Size(104, 33);
			this.scoreBox0.TabIndex = 0;
			this.scoreBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Player 0";
			// 
			// scoreBox1
			// 
			this.scoreBox1.Enabled = false;
			this.scoreBox1.Location = new System.Drawing.Point(117, 62);
			this.scoreBox1.Name = "scoreBox1";
			this.scoreBox1.Size = new System.Drawing.Size(104, 33);
			this.scoreBox1.TabIndex = 0;
			this.scoreBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 25);
			this.label3.TabIndex = 1;
			this.label3.Text = "Player 1";
			// 
			// scoreBox2
			// 
			this.scoreBox2.Enabled = false;
			this.scoreBox2.Location = new System.Drawing.Point(117, 96);
			this.scoreBox2.Name = "scoreBox2";
			this.scoreBox2.Size = new System.Drawing.Size(104, 33);
			this.scoreBox2.TabIndex = 0;
			this.scoreBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 99);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 25);
			this.label4.TabIndex = 1;
			this.label4.Text = "Player 2";
			// 
			// scoreBox3
			// 
			this.scoreBox3.Enabled = false;
			this.scoreBox3.Location = new System.Drawing.Point(117, 131);
			this.scoreBox3.Name = "scoreBox3";
			this.scoreBox3.Size = new System.Drawing.Size(104, 33);
			this.scoreBox3.TabIndex = 0;
			this.scoreBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 25);
			this.label5.TabIndex = 1;
			this.label5.Text = "Player 3";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label6.Location = new System.Drawing.Point(951, 490);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(97, 21);
			this.label6.TabIndex = 6;
			this.label6.Text = "Heart Break";
			// 
			// hbBox
			// 
			this.hbBox.Enabled = false;
			this.hbBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.hbBox.Location = new System.Drawing.Point(1074, 487);
			this.hbBox.Name = "hbBox";
			this.hbBox.Size = new System.Drawing.Size(60, 29);
			this.hbBox.TabIndex = 7;
			this.hbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label7.Location = new System.Drawing.Point(951, 454);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 21);
			this.label7.TabIndex = 6;
			this.label7.Text = "Current Player";
			// 
			// cpBox
			// 
			this.cpBox.Enabled = false;
			this.cpBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cpBox.Location = new System.Drawing.Point(1074, 451);
			this.cpBox.Name = "cpBox";
			this.cpBox.Size = new System.Drawing.Size(60, 29);
			this.cpBox.TabIndex = 7;
			this.cpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1184, 750);
			this.Controls.Add(this.cpBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.hbBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWin";
			this.Text = "Heart";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;

		private CardBox[] cardBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox scoreBox3;
		private System.Windows.Forms.TextBox scoreBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox scoreBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox scoreBox0;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox hbBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox cpBox;
	}
}

