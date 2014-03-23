using System;

namespace Program
{
    public class Editor
    {
        public static void editor(Character character)
        {
            bool select = true;
            while (select == true)
            {
                Console.Clear();
                Console.WriteLine("Character Editor\nSelect what you would like to change\n\n" +
                "(A)bilities\n" +
                "(R)ace\n" +
                "(C)lass\n" +
                "(S)kills\n" +
                "(F)eats\n" +
                "(D)escription\n" +
                "(B)ack to main menu");

                /*This is a series of menus which should call methods in the charEdit class to read/write variables and do calculations
                 * while all the menu functionality should be kept here*/
                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        Abilities(character);
                        break;
                    case "R":
                        character.Race();
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
                        select = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Abilities(Character character)
        {
            int pointcost = 0;
            bool abchange = true;
            while (abchange == true)
            {
                Console.Clear();
                Console.WriteLine(
                    "Abilities currently cost {12} points.\n\n" +
                    "(S)trength:\t {0} \t {6}\n" +
                    "(D)exterity:\t {1} \t {7}\n" +
                    "(C)onstitution:\t {2} \t {8}\n" +
                    "(I)ntelligence:\t {3} \t {9}\n" +
                    "(W)isdom:\t {4} \t {10}\n" +
                    "Cha(r)isma:\t {5} \t {11}\n",
                    character.strength, character.dexterity, character.constitution, character.intelligence, character.wisdom, 
                    character.charisma, character.strMod, character.dexMod, character.conMod, character.intMod, character.wisMod,
                    character.chaMod, pointcost);

                Console.WriteLine("Change which Ability? Or go(B)ack.");
                switch (Console.ReadLine().ToUpper())
                {
                    case "S":
                        int newval = 0;
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.strength = newval;
                        break;
                    case "D":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.dexterity = newval;
                        break;
                    case "C":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.constitution = newval;
                        break;
                    case "I":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.intelligence = newval;
                        break;
                    case "W":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        newval = newval < 7 ? 7 : newval;
                        newval = newval > 18 ? 18 : newval;
                        character.wisdom = newval;
                        break;
                    case "R":
                        Console.WriteLine("New Value(7 to 18):");
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
    }
}

