using System;

namespace console
{
	class Selector
	{
		//member variables
		private int select;
		enum Generator
		{
			Abilities, Race, Class, Skills, Feats, Description
		}
		public void Selection()
		{
			string[] generator = {"Abilities", "Race", "Class", "Skills", "Feats", "Description"};
			select = Convert.ToInt16 (Console.ReadLine ());
			Console.WriteLine ("Selected {0}", generator[select]);
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
