﻿using System;

namespace Program
{
    public class Editor
    {
        public static void editor(Character character)
        {
			//in case of message for editor screen, character sheet by default
			string editormessage = character.charsheet();
            bool select = true;
            while(select == true)
            {
				//Editor menu starts here
                Console.Clear();
                Console.WriteLine("Character Editor\nSelect what you would like to change\n\n" +
               		"(A)bilities\n" +
               		"(R)ace\n" +
    	           	"(C)lass\n" +
       	        	"(S)kills\n" +
       	        	"(F)eats\n" +
       	        	"(D)escription\n" +
					"Sa(v)e\n" +
					"(B)ack to main menu\n\n" +
					editormessage + "\n");

                /*This is a series of menus which should call methods in the charEdit class to read/write variables and do calculations
                 * while all the menu functionality should be kept here*/
                switch(Console.ReadLine().ToUpper())
                {
                    case "A":
                        Abilities(character);
                        break;
                    case "R":
                        Race(character);
                        break;
                    case "C":
                        character.Class();
                        break;
                    case "S":
                        character.Skills();
                        break;
                    case "F":
                        character.Feats();
                        break;
                    case "D":
                        character.Description();
                        break;
                    case "B":
					/*ends the select menu loop, effectively sending you back to the main menu
					 * the returnmessage(charsheet) is defined in Program, ensuring you always see it no matter how you return*/
                        select = false;
                        break;
					case "V": 
					savemenu (character);
						break;
                    default:
                        break;
                }
            }
        }
		public static void savemenu(Character character)
		{
			InOut S = new InOut ();
			string filename = "";
			bool save = true;
			while (save == true)
			{
				Console.Clear ();
				Console.WriteLine ("Existing Files:\n" + S.Files() +"\n");
				Console.WriteLine ("Insert Filename");
				filename = Console.ReadLine ();
				if (filename == "")
				{
					Console.WriteLine ("Must enter a filename!");
				} 
				else
				{
					string files = S.Files ();
					//check if the file already exists in case of accidental duplicates
					if (files.Contains (filename))
					{
						bool confirm = true;
						while (confirm == true)
						{
							Console.WriteLine ("Character File Exists! Overwrite? (Y/N)");
							confirm = false;
							switch (Console.ReadLine ().ToUpper ())
							{
							case "Y":
								save = false;
								break;
							case "N":
								break;
							default:
								confirm = true;
								break;
							}
						}
					}
				}
			}
			filename = filename + ".char";
			S.Save (filename, character);
		}
        //-------------------------------------------------------------------------------------------------------------------------------------------
        public static void Abilities(Character character)
        {
            bool abchange = true;
            while(abchange == true)
            {
                Console.Clear();
                Console.WriteLine(
                    "Abilities currently cost {12} points.\n" +
                    "10: Low Fantasy\n" +
                    "15: Standard Fantasy\n" +
                    "20: High Fantasy\n" +
                    "25: Epic Fantasy\n\n" +
                    "  Ability\t Score\t Modifier\n" +
                    "(S)trength:\t   {0} \t    {6}\n" +
                    "(D)exterity:\t   {1} \t    {7}\n" +
                    "(C)onstitution:\t   {2} \t    {8}\n" +
                    "(I)ntelligence:\t   {3} \t    {9}\n" +
                    "(W)isdom:\t   {4} \t    {10}\n" +
                    "Cha(r)isma:\t   {5} \t    {11}\n",
                    character.strength, character.dexterity, character.constitution, character.intelligence, character.wisdom, 
                    character.charisma, character.strMod, character.dexMod, character.conMod, character.intMod, character.wisMod,
                    character.chaMod, character.pointvalue);

				Console.WriteLine("Change which Ability? Or go (B)ack.");
                string select = Console.ReadLine().ToUpper();
                Console.WriteLine("New Value(7 to 18):");
                switch(select)
                {
                    case "S":
                        int newval = 0;
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.strength = newval;
                        break;
                    case "D":
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.dexterity = newval;
                        break;
                    case "C":
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.constitution = newval;
                        break;
                    case "I":
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.intelligence = newval;
                        break;
                    case "W":
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.wisdom = newval;
                        break;
                    case "R":
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.charisma = newval;
                        break;
                    case "B":
                        abchange = false;
                        break;
                }
            }
        }

        public static void Race(Character character)
        {
            bool racechange = true;
            while(racechange == true)
            {
                Console.Clear();
                Console.WriteLine("Choose a Race, currently selected is {0}\n\n" +
                "1) Dwarf\t +2 Con, +2 Wis, -2 Cha\n" +
                "2) Elf\t\t +2 Dex, +2 Int, -2 Con\n" +
                "3) Gnome\t +2 Con, +2 Cha, -2 Str\n" +
                "4) Half Elf\t +2 to one ability score of your choice\n" +
                "5) Halfling\t +2 Dex, +2 Cha, -2 Str\n" +
                "6) Half Orc\t +2 to one ability score of your choice\n" +
                "7) Human\t +2 to one ability score of your choice\n" +
                "B)ack", character.race);

                switch(Console.ReadLine().ToUpper())
                {
                    case "1":
                        character.race = CharacterRace.Dwarf;
                        character.RaceStatMod();
                        break;
                    case "2":
                        character.race = CharacterRace.Elf;
                        character.RaceStatMod();
                        break;
                    case "3":
                        character.race = CharacterRace.Gnome;
                        character.RaceStatMod();
                        break;
                    case "4":
                        character.race = CharacterRace.HalfElf;
                        StatChoice(character);
                        break;
                    case "5":
                        character.race = CharacterRace.Halfling;
                        character.RaceStatMod();
                        break;
                    case "6":
                        character.race = CharacterRace.HalfOrc;
                        StatChoice(character);
                        break;
                    case "7":
                        character.race = CharacterRace.Human;
                        StatChoice(character);
                        break;
                    case "B":
                        racechange = false;
                        break;
                }
            }
        }

        public static void StatChoice(Character character)
        {
			character.RacialReset ();
            Console.WriteLine("Choose an Ability Score to increase by 2 points:\n" +
				"(S)trength, (D)exterity, (C)onstitution, (I)ntelligence, (W)isdom, Cha(r)isma");
            string select = Console.ReadLine().ToUpper();
            bool statselect = true;
            while(statselect == true)
            {
                statselect = false;
                switch(select)
                {
                    case "S":
                        character.strRacial = 2;
                        break;
                    case "D":
                        character.dexRacial = 2;
                        break;
                    case "C":
                        character.conRacial = 2;
                        break;
                    case "I":
                        character.intRacial = 2;
                        break;
                    case "W":
                        character.wisRacial = 2;
                        break;
                    case "R":
                        character.chaRacial = 2;
                        break;
                    default:
                        statselect = true;
                        break;
                }
            }
        }
    }
}

