/// <summary>
/// This class contains the data held on a character sheet.
/// </summary>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Program
{
    public enum CharacterRace
    {
        Elf,
        Dwarf,
        Gnome,
        HalfElf,
        Halfling,
        HalfOrc,
        Human}

    ;

    [SerializableAttribute]
    public class Character
    {
        #region Character Stats

        // Character stats. Using capitals because 'int' is a keyword.
        private int STR;
        private int DEX;
        private int CON;
        private int INT;
        private int WIS;
        private int CHA;
        private int[] points = { -4, -2, -1, 0, 1, 2, 3, 5, 7, 10, 13, 17 };
        private int pointcost;
        // The get method calculates values then returns without the need for a function call.
        public int strength
        {
            get
            {
                return this.STR + this.strAlter;
            }
            set
            {
                this.STR = value;
            }
        }

        public int dexterity
        {
            get
            {
                return this.DEX + this.dexAlter;
            }
            set
            {
                this.DEX = value;
            }
        }

        public int constitution
        {
            get
            {
                return this.CON + this.conAlter;
            }
            set
            {
                this.CON = value;
            }
        }

        public int intelligence
        {
            get
            {
                return this.INT + this.intAlter;
            }
            set
            {
                this.INT = value;
            }
        }

        public int wisdom
        {
            get
            {
                return this.WIS + this.wisAlter;
            }
            set
            {
                this.WIS = value;
            }
        }

        public int charisma
        {
            get
            {
                return this.CHA + this.chaAlter;
            }
            set
            {
                this.CHA = value;
            }
        }

        public int pointvalue
        {
            get
            {
                return this.pointcost = points[STR - 7] + points[DEX - 7] + points[CON - 7] + points[INT - 7] + points[WIS - 7] + points[CHA - 7];
            }
            set
            {
                this.pointcost = value;
            }
        }
        // Tempory stat changes
        public int strAlter;
        public int dexAlter;
        public int conAlter;
        public int intAlter;
        public int wisAlter;
        public int chaAlter;
        // Stat modifier accessors.
        public int strMod
        {
            get
            {
                return calcStatMod(this.strength);
            }
        }

        public int dexMod
        {
            get
            {
                return calcStatMod(this.dexterity);
            }
        }

        public int conMod
        {
            get
            {
                return calcStatMod(this.constitution);
            }
        }

        public int intMod
        {
            get
            {
                return calcStatMod(this.intelligence);
            }
        }

        public int wisMod
        {
            get
            {
                return calcStatMod(this.wisdom);
            }
        }

        public int chaMod
        {
            get
            {
                return calcStatMod(this.charisma);
            }
        }

        #endregion

        #region Character Race

        public CharacterRace race;

        public void RaceStatMod()
        {
            switch(race)
            {
                case CharacterRace.Dwarf:
                    conAlter += 2;
                    wisAlter += 2;
                    chaAlter -= 2;
                    break;
                case CharacterRace.Elf:
                    dexAlter += 2;
                    intAlter += 2;
                    conAlter -= 2;
                    break;
                case CharacterRace.Gnome:
                    conAlter += 2;
                    chaAlter += 2;
                    strAlter -= 2;
                    break;
                case CharacterRace.Halfling:
                    dexAlter += 2;
                    chaAlter += 2;
                    strAlter -= 2;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Class Methods

        // Class methods.
        public Character()
        {
            // Stat defaulting.
            int statDefault = 10;
            this.strength = statDefault;
            this.dexterity = statDefault;
            this.constitution = statDefault;
            this.intelligence = statDefault;
            this.wisdom = statDefault;
            this.charisma = statDefault;

            // Ability Alter Defauling.
            int alterDefault = 0;
            this.strAlter = alterDefault;
            this.dexAlter = alterDefault;
            this.conAlter = alterDefault;
            this.intAlter = alterDefault;
            this.wisAlter = alterDefault;
            this.chaAlter = alterDefault;

            // Default to human.
            this.race = CharacterRace.Human;
        }

        private int calcStatMod(int stat)
        {
            return (stat / 2) - 5;
        }
        // These methods should be eventually removed as they are not needed for the character data. They are more
        // presentation and should be in something like the Editor class.
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

        #endregion
    }
}

