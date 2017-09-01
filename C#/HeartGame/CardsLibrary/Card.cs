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
		SPADE, HEART, CLUB, DIAMOND
	}
	public enum CardSideEnum
	{
		UP, DOWN
	}
	public enum CardState
	{
		HAND, TABLE
	}

    public class Card
    {
		private CardNumEnum number;
		private CardShapeEnum shape;
		private Image imageFace;
		private Image imageBack;
		private CardSideEnum side;
		private CardState state;

		public Card(CardNumEnum number, CardShapeEnum shape)
		{
			this.number = number;
			this.shape = shape;
			this.side = CardSideEnum.DOWN;
			this.imageFace = ImageCutter.GetFaceImage(this);
			this.imageBack = ImageCutter.GetBackImage();
			this.state = CardState.HAND;
		}

		public CardShapeEnum Shape
		{
			get
			{
				return this.shape;
			}
		}

		public CardNumEnum Number
		{
			get
			{
				return this.number;
			}
		}

		public CardSideEnum Side
		{
			get { return this.side; }
		}

		public CardState State
		{
			get { return this.state; }
		}

		public void OpenCard()
		{
			this.side = CardSideEnum.UP;
		}
		public void CloseCard()
		{
			this.side = CardSideEnum.DOWN;
		}
		public void FromHandToTable()
		{
			if (this.state == CardState.HAND)
				this.state = CardState.TABLE;
		}
    }
}
