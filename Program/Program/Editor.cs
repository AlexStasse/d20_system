﻿using System;

namespace Program
{
    public class Editor
    {
		private static string editormessage = "";
        public static void editor(Character character)
        {
			//in case of message for editor screen, character sheet by default
			Editor.editormessage = character.charsheet();
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
					Editor.editormessage + "\n");

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
					Class (character);
                        break;
                    case "S":
                        character.Skills();
                        break;
                    case "F":
                        character.Feats();
                        break;
                    case "D":
						Description(character);
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
			string files = S.Files ();
			bool save = true;
			while (save == true)
			{
				Console.Clear ();
				//Writes existing files so user knows if the file already exists
				Console.WriteLine ("Existing Files:\n" + files +"\n");
				Console.WriteLine ("Insert Filename");
				filename = Console.ReadLine ();
				//checks if no filename was entered
				if (filename == "")
				{
					//has a whinge about it and doesn't exit the loop
					Console.WriteLine ("Must enter a filename!");
				} 
				else
				{
					//check if the file already exists in case of accidental duplicates
					if (files.Contains (filename))
					{
						bool confirm = true;
						while (confirm == true)
						{
							//oh noes! file exists, what will our brave hero do?
							Console.WriteLine ("Character File Exists! Overwrite? (Y/N)");
							confirm = false;
							switch (Console.ReadLine ().ToUpper ())
							{
							case "Y":
								//ironically, save = false really means save = true.  LEAVE THE SAVE LOOP
								save = false;
								break;
							case "N":
								//let's try a different name then shall we, go back to the save loop
								break;
							default:
								//shit I dunno, I'll just hang out in the confirm loop forever I guess
								confirm = true;
								break;
							}
						}
					}
				}
			}
			//append the filetype and save, hooray!
			filename = filename + ".char";
			S.Save (filename, character);
		}
        //-------------------------------------------------------------------------------------------------------------------------------------------
		//calculates a new value for ability scores since doing it seperately for every single one was retarded
		public static int newval()
		{
			int newval;
			int.TryParse(Console.ReadLine(), out newval);
			newval = newval < 7 ? 7 : newval;
			newval = newval > 18 ? 18 : newval;
			return newval;
		}
		//menu to change ability scores!
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
				/*This is assuming character creation, levelling up and temp stats is handled seperately to this so it's all good
				 * OTOH if you fuck with this after a few levels you may screw yourself*/
                Console.WriteLine("New Value(7 to 18):");
                switch(select)
                {
                    case "S":
						character.strength = newval();
                        break;
                    case "D":
						character.dexterity = newval();
                        break;
                    case "C":
						character.constitution = newval();
                        break;
                    case "I":
						character.intelligence = newval();
                        break;
                    case "W":
						character.wisdom = newval();
                        break;
                    case "R":
						character.charisma = newval();
                        break;
                    case "B":
						//gonna have to update this!
						Editor.editormessage = character.charsheet();
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

				//choose a race, for halfelf, halforc and human we get to choose a stat up
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

		public static void Class(Character character)
		{
			bool classchange = true;
			while (classchange == true)
			{
				Console.Clear ();
				Console.WriteLine ("Choose a Class, currently selected is {0}\n\n" +
					"1) Barbarian\n" +
					"2) Bard\n" +
					"3) Cleric\n" +
					"4) Druid\n" +
					"5) Fighter\n" +
					"6) Monk\n" +
					"7) Paladin\n" +
					"8) Ranger\n" +
					"9) Rogue\n" +
					"10) Sorceror\n" +
					"11) Wizard\n" +
					"B)ack", character.CLASS);

				//choose a race, for halfelf, halforc and human we get to choose a stat up
				switch (Console.ReadLine ().ToUpper ())
				{
				case "1":
					if (character.lc_align == Character.LC_Align.Lawful)
					{
						Console.WriteLine ("Warning! Barbarians must not be Lawful!\n" +
							"Continue and set alignment to Neutral {0}? Y/N (N Default)", character.ge_align);
						switch (Console.ReadLine ().ToUpper ())
						{
						case "Y":
							character.Barbarian (character);
							break;
						default:
							break;
						}
					} 
					else
					{
						character.Barbarian (character);
					}
					break;
				case "2":
					character.Bard (character);
					break;
				case "3":
					character.Cleric (character);
					break;
				case "4":
					character.Druid (character);
					break;
				case "5":
					character.Fighter (character);
					break;
				case "6":
					if (character.lc_align != Character.LC_Align.Lawful)
					{
						Console.WriteLine ("Warning! Monks must be Lawful!\n" +
							"Continue and set alignment to Lawful {0}? Y/N (N Default)", character.ge_align);
						switch (Console.ReadLine ().ToUpper ())
						{
						case "Y":
							character.Monk (character);
							break;
						default:
							break;
						}
					} 
					else
					{
						character.Monk (character);
					}
					break;
				case "7":
					if (character.lc_align != Character.LC_Align.Lawful || character.ge_align != Character.GE_Align.Good)
					{
						Console.WriteLine ("Warning! Paladins must be Lawful Good!\n" +
							"Continue and set alignment to Lawful Good? Y/N (N Default)");
						switch (Console.ReadLine ().ToUpper ())
						{
						case "Y":
							character.Paladin (character);
							break;
						default:
							break;
						}
					} 
					else
					{
						character.Paladin (character);
					}
					break;
				case "8":
					character.Ranger (character);
					break;
				case "9":
					character.Rogue (character);
					break;
				case "10":
					character.Sorceror (character);
					break;
				case "11":
					character.Wizard (character);
					break;
				case "B":
					Editor.editormessage = character.charsheet();
					classchange = false;
					break;
				}
			}
		}

		//this is where we choose a stat up!
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
						//no choice made, stay in the loop
                        statselect = true;
                        break;
                }
            }
        }

		public static int DescriptorChoice(string descriptor_string, string units)
		{
			int result = 0;
			bool repeat = true;
			while (repeat == true)
			{
				repeat = false;
				Console.WriteLine ("Enter a new {0} in {1}", descriptor_string, units);
				try
				{
					result = int.Parse (Console.ReadLine ());
				} 
				catch (FormatException)
				{
					Console.WriteLine ("Must be an integer");
					repeat = true;
				}
			}
			return result;
		}

		public static void Description(Character character)
		{
			bool describing = true;
			while (describing == true)
			{
				Console.Clear ();
				Console.WriteLine(character.description);
				Console.WriteLine ("\nChange:\n" +
				"(N)ame\n" +
				"(A)ge\n" +
				"(H)eight\n" +
				"(W)eight\n" +
				"(E)yes\n" +
				"Hai(r)\n" +
				"(G)ood - Evil Alignment\n" +
				"(L)awful - Chaotic alignment\n" +
				"(B)ack");

				switch(Console.ReadLine().ToUpper())
				{
				case "N":
					Console.WriteLine ("Enter a new name");
					character.name = Console.ReadLine ();
					break;
				case "A":
					character.age = DescriptorChoice ("Age", "Years");
					break;
				case "H":
					character.height = DescriptorChoice ("Height", "cm");
					break;
				case "W":
					character.weight = DescriptorChoice ("Weight", "kg");
					break;
				case "E":
					Console.WriteLine ("Enter a new Eye Description");
					character.eyes = Console.ReadLine ();
					break;
				case "R":
					Console.WriteLine ("Enter a new Hair Description");
					character.hair = Console.ReadLine ();
					break;
				case "G":
					Console.WriteLine ("Select (G)ood, (N)eutral or (E)vil");
					switch (Console.ReadLine ().ToUpper ())
					{
					case "G":
						character.ge_align = Character.GE_Align.Good;
						break;
					case "N":
						character.ge_align = Character.GE_Align.Neutral;
						break;
					case "E":
						character.ge_align = Character.GE_Align.Evil;
						break;
					}
					break;
				case "L":
					Console.WriteLine ("Select (L)awful, (N)eutral or (C)haotic");
					switch (Console.ReadLine ().ToUpper ())
					{
					case "L":
						character.lc_align = Character.LC_Align.Lawful;
						break;
					case "N":
						character.lc_align = Character.LC_Align.Neutral;
						break;
					case "C":
						character.lc_align = Character.LC_Align.Chaotic;
						break;
					}
					break;
				case "B":
					describing = false;
					break;
				}
			}
		}
    }
}

