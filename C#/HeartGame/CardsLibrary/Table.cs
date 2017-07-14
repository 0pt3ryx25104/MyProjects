using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	class Table
	{
		private Card[] currentTurnCards;
		private Card[,] oldTurnCards;
		private uint round;

		public Table()
		{
			this.currentTurnCards = new Card[4];
			this.oldTurnCards = new Card[13, 4];
			this.round = 0;
		}

		public void OnTable(uint playerNum, Card card)
		{
			currentTurnCards[playerNum] = card;
		}

		public Card GetWhatOnTable(uint playerNum)
		{
			return currentTurnCards[playerNum];
		}

		public void EndARound()
		{
			for (int i = 0; i < 4; i++)
			{
				if(this.currentTurnCards[i]!=null && this.round<13)
					this.oldTurnCards[this.round, i] = this.currentTurnCards[i];
			}
			this.round++;
		}
	}
}
