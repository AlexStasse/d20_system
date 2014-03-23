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
						//Immediately run a new character editor.
						Menu.Editor ();
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
		public static void Editor()
		{
			charEdit c = new charEdit ();
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
					
				/*This is a series of menus which should call methods in the charEdit class to read/write variables and do calculations
				 * while all the menu functionality should be kept here*/
				switch (Console.ReadLine().ToUpper()) 
				{
				case "A":
					c.Abilities ();
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

		/*Bunch of methods used for each part of the character editing, all currently do nothing.  
		 *The Console.Writeline commands only exist to show the method was called and shouldn't be in the final program
		 *and in fact none of these methods should read or write to/from the console at all when finished.*/
		public void Abilities()
		{
			Console.Clear ();
			Console.WriteLine ("Abilities");
			Console.ReadLine ();
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
