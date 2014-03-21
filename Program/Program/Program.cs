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
				Console.WriteLine ("Welcome to Character Generator\nSelect what you would like to do next\n\n" +
				"1) Abilities\n" +
				"2) Race\n" +
				"3) Class\n" +
				"4) Skills\n" +
				"5) Feats\n" +
				"6) Description");

				//After greeting immediately run a new character generator.  Can add Save/Load functionality later.
				charGen c = new charGen ();
				//This runs a method to select which part of the character generator the user would like to visit
				c.Selection ();
				//Keeps the console open should the program reach this far, otherwise the console would immediately close.
				Console.ReadLine ();
			}
		}
	}

	//This class actually contains all the character generation methods
	class charGen
	{

		//Select which character generation screen to go to
		public void Selection()
		{
			bool select = true;
			while (select == true) 
			{
				select = false;
				switch (Console.ReadLine ()) {
				case "1":
					Abilities ();
					break;
				case "2":
					Race ();
					break;
				case "3":
					Class ();
					break;
				case "4":
					Skills ();
					break;
				case "5":
					Feats ();
					break;
				case "6":
					Description ();
					break;
				default:
					Console.WriteLine ("Try an integer between 1 and 6 (inclusive, smartass).");
					select = true;
					break;
				}
			}
		}

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
