using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	public class Table
	{
		private Card[] currentTurnCards;
		public Card[] CurrentRurnCards
		{
			get { return currentTurnCards; }
		}
		private Card[,] oldTurnCards;
		public Card[,] OldTurnCards
		{
			get { return this.oldTurnCards; }
		}
		private uint round;
		public uint Round
		{
			get { return this.round; }
		}

		public Table()
		{
			this.currentTurnCards = new Card[4];
			for (int i = 0; i < 4; i++)
				this.currentTurnCards[i] = null;
			this.oldTurnCards = new Card[13, 4];
			for (int i = 0; i < 13; i++)
			{
				for (int j = 0; j < 4; j++)
					this.oldTurnCards[i,j] = null;
			}
			this.round = 0;
		}

		public void OnTable(int playerNum, Card card)
		{
			currentTurnCards[playerNum] = card;
		}

		public Card GetWhatOnTable(int playerNum)
		{
			return currentTurnCards[playerNum];
		}

		public void EndARound()
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.currentTurnCards[i] != null && this.round < 13)
				{
					this.oldTurnCards[this.round, i] = this.currentTurnCards[i];
					this.currentTurnCards[i] = null;
				}
			}
			this.round++;
		}

		public int SumOfScoreCard()
		{
			int score = 0;
			for (int i = 0; i < 4; i++)
			{
				if (this.currentTurnCards[i] != null)
				{
					if (this.currentTurnCards[i].Shape == CardShapeEnum.HEART)
						score++;
					else if (this.currentTurnCards[i].Shape == CardShapeEnum.SPADE && this.currentTurnCards[i].Number == CardNumEnum.QUEEN)
						score += 13;
				}
			}
			return score;
		}
	}
}
