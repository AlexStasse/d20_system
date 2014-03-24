using System;
using System.IO;

namespace Program
{
	class MainClass
	{
		//C# programs always start from the Main method
		public static void Main(string[] args)
		{
			//This is a string we can use any time we return to the main menu
			string returnmessage = "";
			while(true) 
			{
				Character character = new Character();
				bool select = true;
				while(select == true) 
				{
					//The main menu starts here, most of the rest of this is dealing with errors from loading
					Console.Clear ();
					Console.WriteLine("Welcome to the character manager\n" +
						"(L)oad or (C)reate new character\n" +
						returnmessage);
					select = false;
					switch(Console.ReadLine().ToUpper())
					{
					case "L": //Selected Load, may god have mercy on your soul
						InOut L = new InOut ();
						//This grabs a list of files in the directory
						string files = L.Files ();
						//Check if the directory is empty, if so you don't get to try to load nothing
						if (files == "")
						{
							returnmessage = "No Files Exist!";
						} 
						else
						{
							//Good on you! the directory isn't empty
							Console.Clear ();
							Console.WriteLine ("Select Character to load:");
							//Writes the list of files so you know your options
							Console.WriteLine (files);
							string filename = Console.ReadLine () + ".char";
							bool loading = true;
							//Ok smartass, tried to load nothing did you? I don't think so!
							if (filename == ".char")
							{
								loading = false;
								returnmessage = "No File Selected";
							}
							while (loading == true)
							{
								try
								{
									//If everything went well you end up here with your character loaded
									character = L.Load (filename);
									loading = false;
									Editor.editor(character);
								} 
								catch (System.IO.FileNotFoundException)
								{
									//If the file doesn't exist you can either try again or go back to main menu.  Will have to make sure nobody saves a file called "b"
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
