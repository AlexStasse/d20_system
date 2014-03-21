using System;

namespace console
{
	class MainClass
	{
		//C# programs always start from the Main method
		public static void Main (string[] args)
		{
			//This greets the user when they run the program
			Console.WriteLine ("Welcome to Character Generator\nSelect what you would like to do next\n\n" +
				"1)Abilities\n" +
				"2)Race\n" +
				"3)Class\n" +
				"4)Skills\n" +
				"5)Feats\n" +
				"6)Description");

			//After greeting immediately run a new character generator.  Can add Save/Load functionality later.
			charGen c = new charGen ();
			//This runs a method to select which part of the character generator the user would like to visit
			c.Selection ();
			//Keeps the console open should the program reach this far, otherwise the console would immediately close.
			Console.ReadLine ();
		}
	}

	//This class actually contains all the character generation methods
	class charGen
	{
		//member variables
		private int select;
		public string gen;

		//Select which character generation screen to go to
		public void Selection()
		{
			//This is probably not the way we want to do this if we want to make it modular, but hey I'm learning
			string[] generator = {"Abilities", "Race", "Class", "Skills", "Feats", "Description"};

			//Using numbers instead of character highlights to select a menu makes this loop much simpler, but it's less pretty.
			while (select < 1 || select > 6) 
			{
				try
				{
					select = Convert.ToInt16 (Console.ReadLine ());
				}
				catch (FormatException)
				{
					select = 0;
				}
				/*The next step after here in all instances will immediately clear the console, 
				* so we can display this and it will only be seen if the user fucked up somehow*/
				Console.WriteLine ("bad selection");
			}

			select--;
			gen = generator[select];
			Console.WriteLine ("Selected {0}", gen);

			//ugh.  Someone can do this way better I'm sure but I'm lazy.
			if (gen == "Abilities")
				Abilities ();
			else if (gen == "Race")
				Race ();
			else if (gen == "Class")
				Class ();
			else if (gen == "Skills")
				Skills ();
			else if (gen == "Feats")
				Feats ();
			else if (gen == "Description")
				Description ();
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
