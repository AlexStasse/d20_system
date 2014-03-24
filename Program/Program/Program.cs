using System;
using System.IO;

namespace Program
{
	class MainClass
	{
		//C# programs always start from the Main method
		public static void Main(string[] args)
		{
			string returnmessage = "";
			while(true) 
			{
				Character character = new Character();
				bool select = true;
				while(select == true) 
				{
					Console.Clear ();
					Console.WriteLine("Welcome to the character manager\n" +
						"(L)oad or (C)reate new character\n" +
						returnmessage);
					select = false;
					switch(Console.ReadLine().ToUpper())
					{
					case "L": //Selected Load
						InOut L = new InOut ();
						string files = L.Files ();
						if (files == "")
						{
							returnmessage = "No Files Exist!";
						} 
						else
						{
							Console.Clear ();
							Console.WriteLine ("Select Character to load:");
							Console.WriteLine (files);
							string filename = Console.ReadLine () + ".char";
							bool loading = true;
							if (filename == ".char")
							{
								loading = false;
								returnmessage = "No File Selected";
							}
							while (loading == true)
							{
								try
								{
									character = L.Load (filename);
									loading = false;
									Editor.editor(character);
								} 
								catch (System.IO.FileNotFoundException)
								{
									Console.WriteLine ("File not found! (B)ack to main menu or try again");
									string response = Console.ReadLine ();
									switch (response)
									{
									case "b":
									case "B":
										loading = false;
										select = true;
										break;
									default:
										filename = response;
										break;
									}
								}
							}
						}
						break;
					case "C": //Selected Create
						//newChar creates all the empty variables needed for a new character
						Console.WriteLine (character.strength);
						Editor.editor (character);
						returnmessage = character.charsheet ();
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
