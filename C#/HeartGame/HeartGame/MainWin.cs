using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CardsLibrary;
using System.Threading;
using System.Diagnostics;

namespace HeartGame
{
	public partial class MainWin : Form
	{
		private Manager manager;
		private Queue<Card>[] selectedCardQueue;
		private bool buttonOk;
		private uint retOk;	// Bit
		private System.Threading.Thread gameThread;

		public delegate void SyncControlAcc();

		public MainWin()
		{
			InitializeComponent();
			this.manager = null;
			this.selectedCardQueue = new Queue<Card>[4];
			for (int i = 0; i < 4; i++)
				this.selectedCardQueue[i] = new Queue<Card>();
			this.buttonOk = false;
			this.retOk = 0;
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GameStartInitializing();
			gameThread.Start();
		}
		private void GameThreadStartFunc()
		{
			if (manager != null)
				manager.Start();
		}

		# region External Class Event Handlers
		private Card[] SelectCard(int pNum, int cNum)
		{
			if ((cNum >= 3) && manager.CurrentPlyaer != -1)	// Exchange
			{
				while (this.buttonOk == false) ;
				this.buttonOk = false;

				Card[] result = new Card[3];
				for (int i = 0; i < 3; i++)
				{
					result[i] = this.selectedCardQueue[pNum].Dequeue();
				}
				return result;
			}
			else if ((cNum == 1) && manager.CurrentPlyaer != -1)
			{
				while (this.buttonOk == false) ;
				this.buttonOk = false;

				Card[] result = new Card[1];
				for (int i = 0; i < this.selectedCardQueue[pNum].Count-1; i++)
					this.selectedCardQueue[pNum].Dequeue();
				result[0] = this.selectedCardQueue[pNum].Dequeue();
				return result;
			}
			else
			{
				throw new Exception("Thread error: SelectCard()");
			}
		}
		private void PrintDebug(String msg)
		{
			this.textBox1.Text = msg;
		}
		# endregion

		private void CardOrderedDrawing()
		{
			if (this.InvokeRequired == true)
			{
				SyncControlAcc sync = new SyncControlAcc(CardOrderedDrawing);
				this.Invoke(sync);
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					int k = 0;
					for (int j = 0; j < 13; j++)
					{
						int tIndex = i * 13 + j;
						// 테이블에 이미 낸 카드
						if (cardBox[tIndex].CardInfo.State == CardState.TABLE)
						{
							bool table1Checker = false;
							// 테이블1 그리기
							for (int l = 0; l < 4; l++)
							{
								Card temp = this.manager.GetTable.GetWhatOnTable(l);
								if(temp==null)
									continue;
								if (temp.Shape == cardBox[tIndex].CardInfo.Shape && temp.Number == cardBox[tIndex].CardInfo.Number)
								{
									Point newLocation = new Point(0, 0);
									switch (l)
									{
										case 0:
											newLocation = new Point(350, 350);
											break;
										case 1:
											newLocation = new Point(300, 300);
											break;
										case 2:
											newLocation = new Point(350, 250);
											break;
										case 3:
											newLocation = new Point(400, 300);
											break;
									}
									cardBox[tIndex].Location = newLocation;
									table1Checker = true;
									break;
								}
							}
							if (table1Checker == true)
								continue;
							// 테이블2 그리기
							for (int l = 0; l < this.manager.GetTable.Round; l++)
							{
								bool table2Checker = false;
								for (int m = 0; m < 4; m++)
								{
									Card temp = this.manager.GetTable.OldTurnCards[l, m];
									if (temp == null)
										break;
									if (temp.Shape == cardBox[tIndex].CardInfo.Shape && temp.Number == cardBox[tIndex].CardInfo.Number)
									{
										cardBox[tIndex].Location = new Point(930 + 40 * m, 50 + 20 * l);
										table2Checker = true;
										break;
									}
								}
								if (table2Checker == true)
									break;
							}
							continue;
						}

						switch (i)
						{
							case 0:
								cardBox[tIndex].Location = new Point(150, 600);
								cardBox[tIndex].Location += new Size(40 * k, 0);
								break;
							case 1:
								cardBox[tIndex].Location = new Point(50, 100);
								cardBox[tIndex].Location += new Size(0, 40 * k);
								break;
							case 2:
								cardBox[tIndex].Location = new Point(150, 40);
								cardBox[tIndex].Location += new Size(40 * k, 0);
								break;
							case 3:
								cardBox[tIndex].Location = new Point(800, 100);
								cardBox[tIndex].Location += new Size(0, 40 * k);
								break;
						}
						k++;
					}
				}
				this.scoreBox0.Text = this.manager.Players[0].Score.ToString();
				this.scoreBox1.Text = this.manager.Players[1].Score.ToString();
				this.scoreBox2.Text = this.manager.Players[2].Score.ToString();
				this.scoreBox3.Text = this.manager.Players[3].Score.ToString();
				this.hbBox.Text = this.manager.HeartBreak.ToString();
				this.cpBox.Text = this.manager.CurrentPlyaer.ToString();
			}
		}
		
		private void GameStartInitializing()
		{
			manager = new Manager();
			manager.DebugFunc();

			this.cardBox = new CardBox[52];
			for (int i = 0; i < 52; i++)
			{
				cardBox[i] = new CardBox(manager.Players[i / 13].PlayerHand.CardList[i % 13]);
				if (i / 13 == 0 || i / 13 == 2)
					cardBox[i].Location = cardBox[i].Location + new Size(40 * (i % 13) + 50, 600 - 280 * (i / 13));
				else
					cardBox[i].Location = cardBox[i].Location + new Size(-500 + (i / 13) * 400, 40 * (i % 13) + 100);

				cardBox[i].Name = "cardBox" + i.ToString();
				if (cardBox[i].CardInfo.Side == CardSideEnum.DOWN)
					cardBox[i].Image = ImageCutter.GetBackImage();
				else
					cardBox[i].Image = ImageCutter.GetFaceImage(cardBox[i].CardInfo);
				if (i < 10)
					cardBox[i].Name = "cardBox_0" + i;
				else
					cardBox[i].Name = "cardBox_" + i;
				cardBox[i].MouseClick += new System.Windows.Forms.MouseEventHandler(cardBox_MouseClick);
			}

			for (int i = 0; i < 52; i++)
			{
				this.Controls.Add(this.cardBox[51 - i]);
				//cardBox[i].BringToFront();
			}
			manager.GetSelectedCard += new CardsLibrary.Manager.GetCardsDele(SelectCard);
			manager.PrintDebug += new CardsLibrary.Manager.PrintDebugLog(PrintDebug);
			manager.ExNReDraw += new CardsLibrary.Manager.ReDrawCard(CardBoxChangeAfterEx);
			manager.ReDraw += new CardsLibrary.Manager.ReDrawCard(CardOrderedDrawing);

			gameThread = new Thread(new ThreadStart(GameThreadStartFunc));
		}

		private void CardBoxChangeAfterEx()
		{
			for (int i = 0; i < 52; i++)
			{
				cardBox[i].ChangeCardInfo(manager.Players[i / 13].PlayerHand.CardList[i % 13]);
				if (cardBox[i].CardInfo.Side == CardSideEnum.DOWN)
					cardBox[i].Image = ImageCutter.GetBackImage();
				else
					cardBox[i].Image = ImageCutter.GetFaceImage(cardBox[i].CardInfo);
				//Debug.WriteLine(cardBox[i].CardInfo.Number.ToString() + " " + cardBox[i].CardInfo.Shape.ToString());
			}
			CardOrderedDrawing();
		}

		# region Card Click Event Handler
		private void cardBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (manager != null && manager.CurrentPlyaer != -1)
			{
				CardBox tempCB = ((CardBox)sender);
				int len = tempCB.Name.Length;
				String indexStr = tempCB.Name.Substring(len - 2, 2);
				int index = Convert.ToInt32(indexStr);

				if (manager.CurrentPlyaer != index / 13)
					return;

				if (cardBox[index].CardInfo.State == CardState.HAND)
				{
					// For Debugging
					CardNumEnum temp1 = tempCB.CardInfo.Number;
					CardShapeEnum temp2 = tempCB.CardInfo.Shape;
					textBox1.Text = temp1.ToString() + " " + temp2.ToString();
					// End

					Queue<Card> tempQ = selectedCardQueue[index / 13];
					if (tempQ.Contains(cardBox[index].CardInfo) == false)
						tempQ.Enqueue(cardBox[index].CardInfo);
					if (tempQ.Count > 3)
						tempQ.Dequeue();
				}
			}
		}
		#endregion



		private void pictureBox1_Click(object sender, MouseEventArgs e)
		{

		}

		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			/*
			if (selectedCardQueue[0].Count >= 3 && selectedCardQueue[1].Count >= 3 && selectedCardQueue[2].Count >= 3 && selectedCardQueue[3].Count >= 3)
			{
				this.buttonOk = true;
			}
			 */
			if (this.manager.ExChecker == true)
			{
				if (selectedCardQueue[0].Count >= 1 || selectedCardQueue[1].Count >= 1 || selectedCardQueue[2].Count >= 1 || selectedCardQueue[3].Count >= 1)
				{
					this.buttonOk = true;
					return;
				}
			}
			else if (selectedCardQueue[0].Count >= 3 || selectedCardQueue[1].Count >= 3 || selectedCardQueue[2].Count >= 3 || selectedCardQueue[3].Count >= 3)
			{
				this.buttonOk = true;
				return;
			}
			else
			{
				return;
			}

			/*
			while (retOk != 0xf && retOk != 0xf0) ;
			this.retOk = 0;
			this.buttonOk = false;
			 */
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(this.manager!=null)
				this.manager.AbortExThreads();
			if(this.gameThread!=null && this.gameThread.ThreadState == System.Threading.ThreadState.Running)
				this.gameThread.Abort();
			Application.Exit();
		}

		private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.manager != null)
				this.manager.AbortExThreads();
			if (this.gameThread != null && this.gameThread.ThreadState == System.Threading.ThreadState.Running)
				this.gameThread.Abort();
			Application.Exit();
		}
	}
}
