using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using CardsLibrary;

namespace HeartGame
{
	class CardBox : PictureBox
	{
		private Card card;

		public Card CardInfo
		{
			get { return this.card; }
		}

		public void ChangeCardInfo(Card card)
		{
			this.card = card;
		}

		public CardBox(Card card) : base()
		{
			this.card = card;
			base.Image = ImageCutter.GetBackImage();
			base.Location = new System.Drawing.Point(100, 0);
			//base.Name = "cardBox0";
			//base.Size = new System.Drawing.Size(86, 126);
			base.Size = new System.Drawing.Size(57, 84);
			base.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			base.TabIndex = 1;
			base.TabStop = false;
			//base.Click += new System.EventHandler(this.pictureBox1_Click);
		}

	}
}
