using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	class Hand
	{
		private List<Card> cardList;

		public Hand()
		{
			this.cardList = new List<Card>();
		}

		public void AddAtHand(Card newCard)
		{
			this.cardList.Add(newCard);
		}

		public Card RemoveFromHand(int index)
		{
			try
			{
				if (this.cardList.Count<=index)
					throw new Exception("Index Range at Hand Class is wrong.");

				Card selectedCard = this.cardList[index];
				this.cardList.RemoveAt(index);
				return selectedCard;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}
	}
}
