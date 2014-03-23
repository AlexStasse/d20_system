using System;

namespace Program
{
    public class Editor
    {
        public static void editor(Character character)
        {
            bool select = true;
            while(select == true) 
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
                Character c = new Character();

                /*This is a series of menus which should call methods in the charEdit class to read/write variables and do calculations
                 * while all the menu functionality should be kept here*/
                switch(Console.ReadLine().ToUpper()) 
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
            Character newCharater = new Character();
            int pointcost = 0;
            bool abchange = true;
            while(abchange == true) 
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
                    newCharater.strength, newCharater.dexterity, newCharater.constitution, newCharater.intelligence, newCharater.wisdom, 
                    newCharater.charisma, newCharater.strMod, newCharater.dexMod, newCharater.conMod, newCharater.intMod, newCharater.wisdom,
                    newCharater.chaMod, pointcost);

                Console.WriteLine("Change which Ability? Or go(B)ack.");
                switch(Console.ReadLine().ToUpper()) 
                {
                    case "S":
                        int newval = 0;
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.strength = newval;
                        break;
                    case "D":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.dexterity = newval;
                        break;
                    case "C":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.constitution = newval;
                        break;
                    case "I":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.intelligence = newval;
                        break;
                    case "W":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.wisdom = newval;
                        break;
                    case "R":
                        Console.WriteLine("New Value(7 to 18):");
                        int.TryParse(Console.ReadLine(), out newval);
                        if(newval >= 7 && newval <= 18)
                            character.charisma = newval;
                        break;

                }
            }
    }
    }
}

