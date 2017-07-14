using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	class Player
	{
		private String name;
		private int score;
		private Hand playerHand;

		public Player(String name)
		{
			this.name = name;
			this.score = 0;
			this.playerHand = new Hand();
		}
	}
}
