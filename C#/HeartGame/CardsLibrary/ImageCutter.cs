using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Drawing;

namespace CardsLibrary
{
	public class ImageCutter
	{
		private static System.Resources.ResourceManager resourceManager =
			new System.Resources.ResourceManager("CardsLibrary.Resources", System.Reflection.Assembly.GetExecutingAssembly());

		public static Bitmap GetFaceImage(Card card)
		{
			Bitmap cardImages = (Bitmap)resourceManager.GetObject("card_front");

			int topx = 0;
			int topy = 0;

			if (card.Shape == CardShapeEnum.CLUB) topy = 1;
			if (card.Shape == CardShapeEnum.HEART) topy = 99;
			if (card.Shape == CardShapeEnum.SPADE) topy = 197;
			if (card.Shape == CardShapeEnum.DIAMOND) topy = 295;

			topx = 73 * Convert.ToInt32(card.Number) + 1;

			Rectangle rect = new Rectangle(topx, topy, 72, 97);
			Bitmap cropped = cardImages.Clone(rect, cardImages.PixelFormat);

			return cropped;
		}

		public static Bitmap GetBackImage()
		{
			Bitmap cardBack = (Bitmap)resourceManager.GetObject("card_back");

			return cardBack;
		}
	}
}
