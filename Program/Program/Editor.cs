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
                        Abilities(c, character);
                        break;
                    case "R":
                        c.Race();
                        break;
                    case "C":
                        c.Class();
                        break;
                    case "S":
                        c.Skills();
                        break;
                    case "F":
                        c.Feats();
                        break;
                    case "D":
                        c.Description();
                        break;
                    case "B":
                        select = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void Race()
        {
            Console.Clear();
            Console.WriteLine("Race");
            Console.ReadLine();
        }

        public void Class()
        {
            Console.Clear();
            Console.WriteLine("Class");
            Console.ReadLine();
        }

        public void Skills()
        {
            Console.Clear();
            Console.WriteLine("Skills");
            Console.ReadLine();
        }

        public void Feats()
        {
            Console.Clear();
            Console.WriteLine("Feats");
            Console.ReadLine();
        }

        public void Description()
        {
            Console.Clear();
            Console.WriteLine("Description");
            Console.ReadLine();
        }
    }
}

