using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Diagnostics;

namespace CardsLibrary
{
	public class Manager
	{
		private Player[] players;
		public Player[] Players
		{
			get{return this.players;}
		}

		private Card[,] cards;
		private Table table;
		public Table GetTable
		{
			get { return this.table; }
		}

		private Card[,] selectedExCards;

		private uint game;
		private int currentPlayer;		// Bit
		public int CurrentPlyaer
		{
			get { return this.currentPlayer; }
			
		}
		private int firstPlayer;
		private uint turnSemaphore;
		private bool heartBreak;
		public bool HeartBreak
		{
			get { return this.heartBreak; }
		}
		private bool club2;
		private System.Threading.Thread[] exThreads;
		private bool exChecker;
		public bool ExChecker
		{
			get { return this.exChecker; }
		}

		public delegate Card[] GetCardsDele(int pNum, int cNum);
		public event GetCardsDele GetSelectedCard;

		public delegate void PrintDebugLog(String msg);
		public event PrintDebugLog PrintDebug;

		public delegate void ReDrawCard();
		public event ReDrawCard ExNReDraw;
		public event ReDrawCard ReDraw;

		public Manager()
		{
			this.players = new Player[4];
			players[0] = new Player("A");
			players[1] = new Player("B");
			players[2] = new Player("C");
			players[3] = new Player("D");

			this.cards = new Card[4,13];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 13; j++)	// 카드 생성
				{
					CardNumEnum num = (CardNumEnum)((int)CardNumEnum.ACE + j);
					CardShapeEnum shape = (CardShapeEnum)((int)CardShapeEnum.SPADE + i);
					cards[i, j] = new Card(num, shape);
				}
			}

			this.table = new Table();
			this.selectedExCards = new Card[4, 3];
			this.exThreads = new Thread[4];
			this.exChecker = false;
		}

		public void Start()
		{
			while (true)
			{
				if (GameEndChecker() == true)
					break;

				this.game = 0;
				this.heartBreak = false;
				this.club2 = false;
				this.turnSemaphore = 0;
				this.currentPlayer = 0;

				//Shuffle();	Should be corrected
				this.exChecker = false;
				this.game++;
				if (this.game % 4 != 0)
					ExchangeCards(this.game % 4);
				this.exChecker = true;

				ExNReDraw();

				WhoHasClub2();
				//Debug.WriteLine(this.currentPlayer.ToString());
				//PrintDebug(this.currentPlayer.ToString());
				for (int i = 0; i < 13; i++)
				{
					SucceedSingleGame();
				}
			}
		}

		private void Shuffle()
		{
			Random rnd = new Random();

			for (uint i = 0; i < 2000; i++)	// Shuffle cards
			{
				int t1 = rnd.Next(4), t3 = rnd.Next(4);
				int t2 = rnd.Next(13), t4 = rnd.Next(13);
				Card tempCard = this.cards[t1, t2];
				this.cards[t1, t2] = this.cards[t3, t4];
				this.cards[t3, t4] = tempCard;
			}

			for (uint i = 0; i < 4; i++)
			{
				for (uint j = 0; j < 13; j++)
				{
					this.players[i].PlayerHand.AddAtHand(this.cards[i, j]);
				}
			}
		}

		private bool GameEndChecker()
		{
			if (this.players[0].Score > 100 || this.players[1].Score > 100 || this.players[2].Score > 100 || this.players[3].Score > 100)
				return true;
			else 
				return false;
		}

		// 플레이어 턴을 설정
		private void SetCurrentPlayer(uint pNum)
		{
			try
			{
				if (pNum >= 4)
					throw new Exception("SetCurrentPlayer() Error");

				this.currentPlayer = (int)pNum;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		// 플레이어 턴을 넘김
		private void RotatePlayerTurn()
		{
			if (this.currentPlayer >= 3)
				SetCurrentPlayer(0);
			else
				SetCurrentPlayer((uint)this.currentPlayer + 1);
		}
		// 카드 교환
		private void ExchangeCards(uint wise)
		{
			//this.turnSemaphore = 4;
			//currentPlayer = 0;
			//currentPlayer |= 0xf;
			for (int i = 0; i < 4; i++)
			{
				//currentPlayer = (uint)(0x1<<(byte)i);
				currentPlayer = i;
				exThreads[i] = new Thread(new ParameterizedThreadStart(SelectingExCards));
				exThreads[i].Start(i);
				exThreads[i].Join();
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Card temp = selectedExCards[i,j];
					players[i].PlayerHand.RemoveFromHand(temp.Shape, temp.Number);
				}
			}
			switch (wise)
			{
				case 1:// 시계방향
					for (int i = 0; i < 3; i++)
						players[1].PlayerHand.AddAtHand(selectedExCards[0, i]);
					for (int i = 0; i < 3; i++)
						players[2].PlayerHand.AddAtHand(selectedExCards[1, i]);
					for (int i = 0; i < 3; i++)
						players[3].PlayerHand.AddAtHand(selectedExCards[2, i]);
					for (int i = 0; i < 3; i++)
						players[0].PlayerHand.AddAtHand(selectedExCards[3, i]);
					break;
				case 2:// 반시계 방향
					for (int i = 0; i < 3; i++)
						players[3].PlayerHand.AddAtHand(selectedExCards[0, i]);
					for (int i = 0; i < 3; i++)
						players[0].PlayerHand.AddAtHand(selectedExCards[1, i]);
					for (int i = 0; i < 3; i++)
						players[1].PlayerHand.AddAtHand(selectedExCards[2, i]);
					for (int i = 0; i < 3; i++)
						players[2].PlayerHand.AddAtHand(selectedExCards[3, i]);
					break;
				case 3:// 앞 사람
					for (int i = 0; i < 3; i++)
						players[2].PlayerHand.AddAtHand(selectedExCards[0, i]);
					for (int i = 0; i < 3; i++)
						players[3].PlayerHand.AddAtHand(selectedExCards[1, i]);
					for (int i = 0; i < 3; i++)
						players[0].PlayerHand.AddAtHand(selectedExCards[2, i]);
					for (int i = 0; i < 3; i++)
						players[1].PlayerHand.AddAtHand(selectedExCards[3, i]);
					break;
			}
		}

		void SelectingExCards(object pNum)
		{
			Card[] GottenCards = GetSelectedCard((int)pNum, 3);
			for (int i = 0; i < 3; i++)
			{
				this.selectedExCards[(int)pNum, i] = GottenCards[i];
			}
			currentPlayer = -1;
			/*
			String str = "";
			for (int i = 0; i < 3; i++)
			{
				str += (GottenCards[i].Number.ToString() + " " + GottenCards[i].Shape.ToString() + ", ");
			}
			PrintDebug(str);
			 */
			//this.SelectingExCards[pNum,0]
		}




		private void WhoHasClub2()
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.players[i].PlayerHand.CheckClub2())
				{
					this.currentPlayer = i;
					break;
				}
			}
		}

		private void SucceedSingleGame()
		{
			this.firstPlayer = this.currentPlayer;
			for (int i = 0; i < 4; i++)
			{
				PrintDebug("Current Turn : Player " + this.currentPlayer.ToString());
				Card selectedCard = SelectCard();
				this.table.OnTable(this.currentPlayer, selectedCard);
				ReDraw();
				RotatePlayerTurn();
			}

			ResultARound();			// 한 라운드 정산
			this.table.EndARound();	// 테이블 상의 카드를 정리
			Thread.Sleep(1500);
			ReDraw();
		}

		private Card SelectCard()
		{
			Card[] selectedCard = null;
			while (true)
			{
				selectedCard = GetSelectedCard(this.currentPlayer, 1);
				if (CardRuleChecker(selectedCard[0]) == true)
					break;
				PrintDebug("Wrong Card...");
			}

			selectedCard[0].OpenCard();
			selectedCard[0].FromHandToTable();
			players[this.currentPlayer].PlayerHand.RemoveFromHand(selectedCard[0].Shape, selectedCard[0].Number);
			return selectedCard[0];
		}

		private bool CardRuleChecker(Card card)
		{
			// 클럽2를 내지 않은 가장 맨 처음일 때
			if (club2 == false)
			{
				if (card.Shape == CardShapeEnum.CLUB && card.Number == CardNumEnum.TWO)
				{
					club2 = true;
					return true;
				}
				else
				{
					return false;
				}
			}
			// 첫 턴이다
			else if (currentPlayer==firstPlayer)
			{
				// 낸 카드가 하트인가?
				if (card.Shape==CardShapeEnum.HEART)
				{
					// 하트가 깨져있다.
					if (heartBreak == true)
					{
						return true;
					}
					// 하트가 안 깨졌다.
					else
					{
						Hand tHand = players[currentPlayer].PlayerHand;
						if (tHand.CheckIfShape(CardShapeEnum.CLUB) || tHand.CheckIfShape(CardShapeEnum.DIAMOND) || tHand.CheckIfShape(CardShapeEnum.SPADE))
						{
							return false;
						}
						else
						{
							heartBreak = true;
							return true;
						}
					}
				}
				// 다른 모양인가?
				else
				{
					return true;
				}
			}
			// 첫 턴이 아니다
			else
			{
				// 맨 처음에 낸 카드와 문양이 같다.
				if (table.GetWhatOnTable(firstPlayer).Shape == card.Shape)
				{
					return true;
				}
				// 다르다
				else
				{
					CardShapeEnum tShape = table.GetWhatOnTable(firstPlayer).Shape;
					// 맨 처음에 낸 카드와 문양이 같은 게 없다
					if (players[currentPlayer].PlayerHand.CheckIfShape(tShape) == false)
					{
						// 낸 카드가 하트다
						if (card.Shape == CardShapeEnum.HEART)
						{
							heartBreak = true;
							return true;
						}
						// 낸 카드가 하트가 아니다
						else
						{
							return true;
						}
					}
					// 문양이 같은 게 있다.
					else
					{
						return false;
					}
				}
			}
		}

		private void ResultARound()
		{
			// Find The Strongest
			int theStrongest = this.firstPlayer;

			CardShapeEnum fShape = this.table.GetWhatOnTable(theStrongest).Shape;
			CardNumEnum fNum = this.table.GetWhatOnTable(theStrongest).Number;
			for (int i = 0; i < 4; i++)
			{
				if (this.table.GetWhatOnTable(i).Shape == fShape)
				{
					CardNumEnum tempNumber = this.table.GetWhatOnTable(i).Number;
					if (tempNumber == CardNumEnum.ACE || tempNumber > fNum)
					{
						fNum = tempNumber;
						theStrongest = i;
						if (fNum == CardNumEnum.ACE)
							break;
					}
				}
			}

			// Calculate Scores
			int scoreOfThisRound = this.table.SumOfScoreCard();

			// Add scores
			if (scoreOfThisRound == 26)	// Shoot the moon
			{
				for (int i = 0; i < 4; i++)
				{
					if (i == theStrongest)
						continue;
					this.players[i].AddScore(26);
				}
			}
			else
			{
				this.players[theStrongest].AddScore(scoreOfThisRound);
			}

			// Who's Next
			this.currentPlayer = theStrongest;
		}

		public void DebugFunc()
		{
			this.Shuffle();
			foreach(Card card in this.players[0].PlayerHand.CardList)
			{
				card.OpenCard();
			}
			foreach (Card card in this.players[1].PlayerHand.CardList)
			{
				card.OpenCard();
			}
			foreach (Card card in this.players[2].PlayerHand.CardList)
			{
				card.OpenCard();
			}
			foreach (Card card in this.players[3].PlayerHand.CardList)
			{
				card.OpenCard();
			}
		}

		public void AbortExThreads()
		{
			for(int i=0; i<4; i++){
				if (this.exThreads[i].ThreadState == System.Threading.ThreadState.Running)
				{
					exThreads[i].Abort();
				}
			}
		}
	}
}
