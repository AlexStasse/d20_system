using System;
using System.IO;

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
                    "(L)oad or (C)reate new character");

				Character character = new Character();
				bool select = true;
				while(select == true) 
				{
					select = false;
					switch(Console.ReadLine().ToUpper())
					{
					case "L": //Selected Load
						InOut L = new InOut ();
						Console.Clear ();
						Console.WriteLine ("Select Character to load:");
						string files = L.Files ();
						Console.WriteLine (files);
						string filename = Console.ReadLine () + ".char";
						character = L.Load(filename);
                    case "C": //Selected Create
						//newChar creates all the empty variables needed for a new character
                        Console.WriteLine(character.strength);
                        Editor.editor(character);
						break;
					default: //nothing selected, go to start of loop
						select = true;
						break;
					}
				}
			}
		}
	}
}
