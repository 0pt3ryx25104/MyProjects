using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLibrary
{
	public class Player
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

		public String Name
		{
			get{
				return this.name;
			}
		}

		public int Score
		{
			get
			{
				return this.score;
			}
			set
			{
				this.score = value;
			}
		}

		public void AddScore(int val)
		{
			this.score += val;
			if (this.score < 0)
				this.score = 0;
		}

		public Hand PlayerHand
		{
			get
			{
				return this.playerHand;
			}
		}
	}
}
