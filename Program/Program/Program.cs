using System;

namespace console
{
	class Selector
	{
		//member variables
		private int select;
		public string gen;

		//Select which character generation screen to go to
		public void Selection()
		{
			string[] generator = {"Abilities", "Race", "Class", "Skills", "Feats", "Description"};

			bool idiot = true;
			while (idiot) {
				try {
					select = Convert.ToInt16 (Console.ReadLine ());
					idiot = false;
				} catch (FormatException) {
					Console.WriteLine ("Try a number from 1 to 6");
				}
			}

			select--;
			gen = generator[select];
			Console.WriteLine ("Selected {0}", gen);

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

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to Character Generator " +
				"\nSelect what you would like to do next:" +
				"\n\n1)Abilities\n2)Race\n3)Class\n4)Skills\n5)Feats\n6)Description");
			Selector s = new Selector ();
			s.Selection ();
			Console.ReadLine ();
		}
	}
}
