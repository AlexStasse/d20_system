/// <summary>
/// Tile.
/// This class is going to be used to hold all of the data
/// for a single square in the game, as well as managing
/// the characters to be shown.
/// </summary>

using System;

namespace Program
{
	public class Tile
	{
		Character character;
		Item item;

		public Tile()
		{
			this.item = new Item();
		}

		public void setCharacter(Character c)
		{
			this.character = c;
		}

		public void removeCharacter()
		{
			this.character = null;
		}

		public char print()
		{
			if(character != null)
			{
				return '@';
			}
			else
			{
				return this.item.print();
			}
		}
	}
}

