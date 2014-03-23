using System;

namespace console
{
	class MainClass
	{
		//C# programs always start from the Main method
		public static void Main (string[] args)
		{
			while (true) 
			{
				//Clear the console if we come back to the program start and give user options.
				Console.Clear();
				Console.WriteLine ("Welcome to the character manager\n" +
					"(L)oad, (S)ave or (C)reate new character");

				bool select = true;
				while (select == true) 
				{
					select = false;
					switch (Console.ReadLine().ToUpper())
					{
					case "L":
						InOut L = new InOut ();
						L.Load ();
						break;
					case "S":
						InOut S = new InOut ();
						S.Save ();
						break;
					case "C":
						int[] c; 
						c = charEdit.newChar ();
						Menu.Editor (c);
						break;
					default:
						select = true;
						break;
					}
				}
			}
		}
	}

	//Contains Loading and Saving functionality
	class InOut
	{
			public void Load()
			{
				Console.Clear ();
				Console.WriteLine ("Load");
				Console.ReadLine ();
			}

			public void Save()
			{
				Console.Clear ();
				Console.WriteLine ("Save");
				Console.ReadLine ();
			}
	}

	//This class contains menu methods and shouldn't deal with any variables!
	class Menu
	{

		//Select which character edit screen to go to
		public static void Editor(int[] character)
		{
			bool select = true;
			while (select == true) 
			{
				Console.Clear();
				Console.WriteLine ("Character Editor\nSelect what you would like to change\n\n" +
					"(A)bilities\n" +
					"(R)ace\n" +
					"(C)lass\n" +
					"(S)kills\n" +
					"(F)eats\n" +
					"(D)escription\n" +
					"(B)ack to main menu");
				charEdit c = new charEdit();
				/*This is a series of menus which should call methods in the charEdit class to read/write variables and do calculations
				 * while all the menu functionality should be kept here*/
				switch (Console.ReadLine().ToUpper()) 
				{
				case "A":
					int[] charnew;
					int[] mods;
					Console.Clear ();
					c.Abilities (character, out charnew, out mods);
					int STR = charnew [0];
					int DEX = charnew [1];
					int CON = charnew [2];
					int INT = charnew [3];
					int WIS = charnew [4];
					int CHA = charnew [5];
					int STRmod = mods [0];
					int DEXmod = mods [1];
					int CONmod = mods [2];
					int INTmod = mods [3];
					int WISmod = mods [4];
					int CHAmod = mods [5];
					Console.WriteLine ("Abilities:\n\n" +
						"Strength:\t {0} \t {6}\n" +
						"Dexterity:\t {1} \t {7}\n" +
						"Constitution:\t {2} \t {8}\n" +
						"Intelligence:\t {3} \t {9}\n" +
						"Wisdom:\t\t {4} \t {10}\n" +
						"Charisma:\t {5} \t {11}\n",
						STR, DEX, CON, INT, WIS, CHA, STRmod, DEXmod, CONmod, INTmod, WISmod, CHAmod);
					Console.ReadLine ();
					break;
				case "R":
					c.Race ();
					break;
				case "C":
					c.Class ();
					break;
				case "S":
					c.Skills ();
					break;
				case "F":
					c.Feats ();
					break;
				case "D":
					c.Description ();
					break;
				case "B":
					select = false;
					break;
				default:
					break;
				}
			}
		}
	}

	//This class contains the character editors
	class charEdit
	{
		//sets up empty variables for a new character
		public static int[] newChar()
		{
			int STR = 7;
			int DEX = 8;
			int CON = 9;
			int INT = 10;
			int WIS = 11;
			int CHA = 12;
			int[] abilities = {STR, DEX, CON, INT, WIS, CHA};
			return abilities;
		}

		/*Bunch of methods used for each part of the character editing, all currently do nothing.  
		 *The Console.Writeline commands only exist to show the method was called and shouldn't be in the final program
		 *and in fact none of these methods should read or write to/from the console at all when finished.*/
		public void Abilities(int[] character, out int[] character2, out int[] mods)
		{
			int STR = character [0];
			int DEX = character [1];
			int CON = character [2];
			int INT = character [3];
			int WIS = character [4];
			int CHA = character [5];

			int STRmod = STR/2 - 5;
			int DEXmod = DEX/2 - 5;
			int CONmod = CON/2 - 5;
			int INTmod = INT/2 - 5;
			int WISmod = WIS/2 - 5;
			int CHAmod = CHA/2 - 5;

			//some shit goes here

			character2 = new int[] {STR, DEX, CON, INT, WIS, CHA};
			mods = new int[] {STRmod, DEXmod, CONmod, INTmod, WISmod, CHAmod};
		}
		public void Race()
		{
			Console.Clear ();
			Console.WriteLine ("Race");
			Console.ReadLine ();
		}
		public void Class()
		{
			Console.Clear ();
			Console.WriteLine ("Class");
			Console.ReadLine ();
		}
		public void Skills()
		{
			Console.Clear ();
			Console.WriteLine ("Skills");
			Console.ReadLine ();
		}
		public void Feats()
		{
			Console.Clear ();
			Console.WriteLine ("Feats");
			Console.ReadLine ();
		}
		public void Description()
		{
			Console.Clear ();
			Console.WriteLine ("Description");
			Console.ReadLine ();
		}
	}
}
