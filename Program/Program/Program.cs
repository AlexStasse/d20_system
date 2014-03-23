using System;

namespace Program
{

    public enum CharacterRace 
    {
        human, elf, dwarf, halfling, halfElf, halfOrc, gnome
    };

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
                    "(L)oad, (S)ave or (C)reate new character");

				bool select = true;
				while(select == true) 
				{
					select = false;
					switch(Console.ReadLine().ToUpper())
					{
					case "L": //Selected Load
						InOut L = new InOut();
						L.Load();
						break;
					case "S": //Selected Save
						InOut S = new InOut();
						S.Save();
						break;
                    case "C": //Selected Create
						//newChar creates all the empty variables needed for a new character
                            Character character = new Character();
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
