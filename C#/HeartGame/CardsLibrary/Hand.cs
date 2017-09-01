using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	public class Hand
	{
		private List<Card> cardList;

		public List<Card> CardList
		{
			get { return this.cardList; }
		}

		public Hand()
		{
			this.cardList = new List<Card>();
		}

		// 손에 카드를 추가
		public void AddAtHand(Card newCard)
		{
			try
			{
				if (this.cardList.Count >= 13)
					throw new Exception("AddAtHand() Error. Exceeding hand limit");
				this.cardList.Add(newCard);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			this.cardList.Sort(delegate(Card A, Card B)
			{
				if (A.Shape > B.Shape) 
				{
					return 1; 
				}
				else if (A.Shape < B.Shape) 
				{ 
					return -1; 
				}
				else 
				{
					if (A.Number == CardNumEnum.ACE)
						return 1;
					else if (B.Number == CardNumEnum.ACE)
						return -1;
					else if (A.Number > B.Number)
						return 1; 
					else 
						return -1; 
				}
			});
		}

		// 손에서 카드를 제거(카드를 냄)
		public Card RemoveFromHand(CardShapeEnum shape, CardNumEnum num)
		{
			try
			{
				foreach (Card card in this.cardList)
				{
					if (card.Shape == shape && card.Number == num)
					{
						Card temp = card;
						this.cardList.Remove(card);
						return temp;
					}
				}
				throw new Exception("RemoveFromHand() error");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}

		public bool CheckClub2()
		{
			return this.cardList.Exists(x => x.Shape == CardShapeEnum.CLUB && x.Number == CardNumEnum.TWO);
		}

		// 같은 모양의 카드가 있는지 체크
		public bool CheckIfShape(CardShapeEnum shape)
		{
			return this.cardList.Exists(x => x.Shape == shape);
		}
	}
}
