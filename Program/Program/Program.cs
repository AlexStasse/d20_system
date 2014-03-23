using System;

namespace Program
{
	class MainClass
	{
		//C# programs always start from the Main method
		public static void Main(string[] args)
		{
			while(true) 
			{
				//Clear the console if we come back to the program start and give user options.
				Console.Clear();
				Console.WriteLine("Welcome to the character manager\n" +
					"(L)oad,(S)ave or(C)reate new character");

				bool select = true;
				while(select == true) 
				{
					select = false;
					switch(Console.ReadLine().ToUpper())
					{
					case "L": //Selected Load
						InOut L = new InOut();
						L.Load();
						break;
					case "S": //Selected Save
						InOut S = new InOut();
						S.Save();
						break;
					case "C": //Selected Create
						//newChar creates all the empty variables needed for a new character
                        Character c = new Character();
                        Program.Editor.editor(c);
						break;
					default: //nothing selected, go to start of loop
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
                Console.Clear();
				Console.WriteLine("Load");
				Console.ReadLine();
			}

			public void Save()
			{
				Console.Clear();
				Console.WriteLine("Save");
				Console.ReadLine();
			}
	}

	//This class contains menu methods and shouldn't deal with any variables!
	class Menu
	{
        public static Character Abilities()
		{
			int pointcost = 0;
			bool abchange = true;
			while(abchange == true) 
			{
				Console.Clear();
                Character newCharater = new Character();
				Console.WriteLine(
                    "Abilities currently cost {12} points.\n\n" +
				    "(S)trength:\t {0} \t {6}\n" +
				    "(D)exterity:\t {1} \t {7}\n" +
				    "(C)onstitution:\t {2} \t {8}\n" +
				    "(I)ntelligence:\t {3} \t {9}\n" +
				    "(W)isdom:\t {4} \t {10}\n" +
				    "Cha(r)isma:\t {5} \t {11}\n",
                    newCharater.strength, newCharater.dexterity, newCharater.constitution, newCharater.intelligence, newCharater.wisdom, 
                    newCharater.charisma, newCharater.strMod, newCharater.dexMod, newCharater.conMod, newCharater.intMod, newCharater.wisdom,
                    newCharater.chaMod, pointcost);

				Console.WriteLine("Change which Ability? Or go(B)ack.");
				switch(Console.ReadLine().ToUpper()) 
				{
				case "S":
					int newval = 0;
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [0] = newval;
					break;
				case "D":
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [1] = newval;
					break;
				case "C":
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [2] = newval;
					break;
				case "I":
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [3] = newval;
					break;
				case "W":
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [4] = newval;
					break;
				case "R":
					Console.WriteLine("New Value(7 to 18):");
					int.TryParse(Console.ReadLine(), out newval);
					if(newval >= 7 && newval <= 18)
						character [5] = newval;
					break;

				}
			}
		}
	}
	//This class contains the character editors
	class charEdit
	{
		//sets up empty variables for a new character
		

		/*Bunch of methods used for each part of the character editing, all currently do nothing.  
		 *The Console.Writeline commands only exist to show the method was called and shouldn't be in the final program
		 *and in fact none of these methods should read or write to/from the console at all when finished.*/
		public void Abilities(int[] character, out int[] character2, out int[] mods, out int pointcost)
		{
			int[] points = { -4, -2, -1, 0, 1, 2, 3, 5, 7, 10, 13, 17 };

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

			pointcost = points[STR-7] + points[DEX-7] +points[CON-7] +points[INT-7] +points[WIS-7] +points[CHA-7];

			//some shit goes here

			character2 = new int[] {STR, DEX, CON, INT, WIS, CHA};
			mods = new int[] {STRmod, DEXmod, CONmod, INTmod, WISmod, CHAmod};
		}
		
	}
}
