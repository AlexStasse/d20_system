/// <summary>
/// This class contains the data held on a character sheet.
/// </summary>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Program
{
	public class Character
	{
		#region Character Stats
		// Charater stats.
		// The get method calculates values then returns without the need for a function call.
		public int strength
		{
			get
			{
				return this.strength - this.strAlter;
			}
			set
			{
				this.strength = value;
			}
		}
		public int dexterity
		{
			get
			{
				return this.dexterity - this.dexAlter;
			}
			set
			{
				this.dexterity = value;
			}
		}
		public int constitution
		{
			get
			{
				return this.constitution - this.conAlter;
			}
			set
			{
				this.constitution = value;
			}
		}
		public int intelligence
		{
			get
			{
				return this.intelligence - this.intAlter;
			}
			set
			{
				this.intelligence = value;
			}
		}
		public int wisdom
		{
			get
			{
				return this.wisdom - this.wisAlter;
			}
			set
			{
				this.wisdom = value;
			}
		}
		public int charisma
		{
			get
			{
				return this.charisma - this.chaAlter;
			}
			set
			{
				this.charisma = value;
			}
		}

		// Tempory stat changes
		public int strAlter;
		public int dexAlter;
		public int conAlter;
		public int intAlter;
		public int wisAlter;
		public int chaAlter;

		// Stat modifier accessors.
		public int strMod
		{
			get
			{
				return calcStatMod(this.strength);
			}
		}
		public int dexMod
		{
			get
			{
				return calcStatMod(this.dexterity);
			}
		}
		public int conMod
		{
			get 
			{
				return calcStatMod(this.constitution);
			}
		}
		public int intMod
		{
			get
			{
				return calcStatMod(this.intelligence);
			}
		}
		public int wisMod
		{
			get
			{
				return calcStatMod(this.wisdom);
			}
		}
		public int chaMod
		{
			get
			{
				return calcStatMod(this.charisma);
			}
		}
		#endregion

		#region Charater Race
		public enum CharacterRace 
		{
			human, elf, dwarf, halfling, halfElf, halfOrc, gnome
		};

		public CharacterRace race;
		#endregion

		#region Class Methods
		// Class methods.
		public Character()
		{
			// Stat defaulting
			int statDefault = 10;
			this.strength = statDefault;
			this.dexterity = statDefault;
			this.constitution = statDefault;
			this.intelligence = statDefault;
			this.wisdom = statDefault;
			this.charisma = statDefault;

			// Ability Alter Defauling
			int alterDefault = 0;
			this.strength = alterDefault;
			this.dexterity = alterDefault;
			this.constitution = alterDefault;
			this.intelligence = alterDefault;
			this.wisdom = alterDefault;
			this.charisma = alterDefault;
		}

		private int calcStatMod(int stat)
		{
			return (stat / 2) - 5;
		}

		public void Race()
		{
			Console.Clear();
			Console.WriteLine("Race");
			Console.ReadLine();
		}

		public void Class()
		{
			Console.Clear();
			Console.WriteLine("Class");
			Console.ReadLine();
		}

		public void Skills()
		{
			Console.Clear();
			Console.WriteLine("Skills");
			Console.ReadLine();
		}

		public void Feats()
		{
			Console.Clear();
			Console.WriteLine("Feats");
			Console.ReadLine();
		}

		public void Description()
		{
			Console.Clear();
			Console.WriteLine("Description");
			Console.ReadLine();
		}
		#endregion

		// pointcost = points[STR-7] + points[DEX-7] +points[CON-7] +points[INT-7] +points[WIS-7] +points[CHA-7];
	}
}

