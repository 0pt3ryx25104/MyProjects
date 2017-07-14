using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	class Manager
	{
		private Player[] players;
		private Card[,] cards;
		private Table table;

		private uint game;
		private uint currentPlayer;
		private uint turnSemaphore;
		private bool heartBreak;

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
				for (int j = 0; j < 13; j++)
				{
					CardNumEnum num = (CardNumEnum)((int)CardNumEnum.ACE + j);
					CardShapeEnum shape = (CardShapeEnum)((int)CardShapeEnum.SPADE + i);
					cards[i, j] = new Card(num, shape);
				}
			}

			this.table = new Table();
			this.game = 0;
			this.currentPlayer = 0;
			this.turnSemaphore = 0;
			this.heartBreak = false;
		}

		public void Start()
		{
			Shuffle();

			while (true)
			{
				if (GameEndChecker() == false)
					break;

				this.game++;
				if (this.game % 4 != 0)
					ExchangeCards(this.game % 4);

				WhoHasClub2();
				SucceedSingleGame();
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

		private void SetCurrentPlayer(uint pNum)
		{
			try
			{
				if (pNum >= 4)
					throw new Exception("SetCurrentPlayer() Error");

				this.currentPlayer = pNum;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void RotatePlayerTurn()
		{
			if (this.currentPlayer >= 3)
				SetCurrentPlayer(0);
			else
				SetCurrentPlayer(this.currentPlayer + 1);
		}

		private void ExchangeCards(uint wise)
		{
			this.turnSemaphore = 4;

			switch (wise)
			{
				case 1:// 시계방향
					break;
				case 2:// 반시계 방향
					break;
				case 3:// 앞 사람
					break;
			}
		}

		private void WhoHasClub2()
		{

		}

		private void SucceedSingleGame()
		{
			while (true)
			{
				for (int i = 0; i < 4; i++)
				{
					Card selectedCard = SelectCard();
					this.table.OnTable(this.currentPlayer, selectedCard);
					RotatePlayerTurn();
				}

				ResultARound();
				this.table.EndARound();
			}
		}

		private Card SelectCard()
		{
			// Check Possible Card
			// Heart Break
		}

		private void ResultARound()
		{
			// Find The Strongest
			uint theStrongest = this.currentPlayer;

			CardShapeEnum fShape = this.table.GetWhatOnTable(theStrongest).Shape;
			CardNumEnum fNum = this.table.GetWhatOnTable(theStrongest).Number;
			for (uint i = 0; i < 4; i++)
			{
				if (this.table.GetWhatOnTable(i).Shape == fShape)
				{
					CardNumEnum tempNumber = this.table.GetWhatOnTable(i).Number;
					if (tempNumber == CardNumEnum.ACE || tempNumber > fNum)
					{
						fNum = tempNumber;
						theStrongest = i;
					}
				}
			}

			// Calculate Scores
			// Add scores
			// Who's Next
		}
	}
}
