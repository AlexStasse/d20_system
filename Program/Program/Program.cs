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
				//This greets the user when they run the program
				Console.Clear();
				//After greeting immediately run a new character generator.  Can add Save/Load functionality later.
				Menu m = new Menu ();
				//This runs a method to select which part of the character generator the user would like to visit
				m.Generation ();
				//Keeps the console open should the program reach this far, otherwise the console would immediately close.
				Console.ReadLine ();
			}
		}
	}

	//This class contains menu methods
	class Menu
	{

		//Select which character generation screen to go to
		public void Generation()
		{
			Console.Clear();
			Console.WriteLine ("Welcome to Character Generator\nSelect what you would like to do next\n\n" +
				"1) Abilities\n" +
				"2) Race\n" +
				"3) Class\n" +
				"4) Skills\n" +
				"5) Feats\n" +
				"6) Description");
			charGen c = new charGen ();
			bool select = true;
			while (select == true) 
			{
				select = false;
				switch (Console.ReadLine ()) {
				case "1":
					c.Abilities ();
					break;
				case "2":
					c.Race ();
					break;
				case "3":
					c.Class ();
					break;
				case "4":
					c.Skills ();
					break;
				case "5":
					c.Feats ();
					break;
				case "6":
					c.Description ();
					break;
				default:
					Console.WriteLine ("Try an integer between 1 and 6 (inclusive, smartass).");
					select = true;
					break;
				}
			}
		}
	}

	//This class contains the character generators
	class charGen
	{

		/*Bunch of methods used for each part of the character generator, all currently do nothing.  
		 *Some of these may end up large so we can consider offloading them somewhere else maybe?*/
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
