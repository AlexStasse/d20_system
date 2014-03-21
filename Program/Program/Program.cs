using System;

namespace console
{
	class Selector
	{
		//member variables
		private int select;
		public string gen;

		public void Selection()
		{
			string[] generator = {"Abilities", "Race", "Class", "Skills", "Feats", "Description"};
			select = Convert.ToInt16 (Console.ReadLine ());
			select--;
			gen = generator[select];
			Console.WriteLine ("Selected {0}", gen);

			if (gen == "Abilities")
				Abilities ();
		}

		public void Abilities()
		{
			Console.Clear ();
			Console.WriteLine ("Abilities");
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
