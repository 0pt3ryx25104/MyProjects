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
		private uint score;
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

		public uint Score
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

		public void AddScore(uint val)
		{
			this.score += val;
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
