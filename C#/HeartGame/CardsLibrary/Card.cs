using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace CardsLibrary
{
	public enum CardNumEnum
	{
		ACE, TWO, THIRD, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN,
		JACK, QUEEN, KING
	}

	public enum CardShapeEnum
	{
		SPADE, HEART, DIAMOND, CLUB
	}

	public enum CardSideEnum
	{
		UP, DOWN
	}

    public class Card
    {
		private CardNumEnum number;
		private CardShapeEnum shape;
		private Image imageFace;
		private Image imageBack;
		private CardSideEnum side;

		public Card(CardNumEnum number, CardShapeEnum shape)
		{
			this.number = number;
			this.shape = shape;
			this.side = CardSideEnum.DOWN;
			// Need to update (imageFace, imageBack)
			this.imageFace = null;
			this.imageBack = null;
		}
    }
}
