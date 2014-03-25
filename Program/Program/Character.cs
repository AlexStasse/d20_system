/// <summary>
/// This class contains the data held on a character sheet.
/// </summary>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

	//serializable so we can save to a file
	[Serializable()]
	//there is a serializable class we need to inherit to send data in and out
	public class Character : ISerializable
    {
		//returns data from InOut
		public Character(SerializationInfo info, StreamingContext ctxt)
		{
			this.STR = (int)info.GetValue("Strength", typeof(int));
			this.DEX = (int)info.GetValue("Dexterity", typeof(int));
			this.CON = (int)info.GetValue("Constitution", typeof(int));
			this.INT = (int)info.GetValue("Intelligence", typeof(int));
			this.WIS = (int)info.GetValue("Wisdom", typeof(int));
			this.CHA = (int)info.GetValue("Charisma", typeof(int));

			this.strRacial = (int)info.GetValue("Racial Strength", typeof(int));
			this.dexRacial = (int)info.GetValue("Racial Dexterity", typeof(int));
			this.conRacial = (int)info.GetValue("Racial Constitution", typeof(int));
			this.intRacial = (int)info.GetValue("Racial Intelligence", typeof(int));
			this.wisRacial = (int)info.GetValue("Racial Wisdom", typeof(int));
			this.chaRacial = (int)info.GetValue("Racial Charisma", typeof(int));

			this.race = (CharacterRace)info.GetValue ("Race", typeof(CharacterRace));

			this.NAME = (string)info.GetValue("Name", typeof(string));
			this.AGE = (int)info.GetValue("Age", typeof(int));
			this.HEIGHT = (int)info.GetValue("Height", typeof(int));
			this.WEIGHT = (int)info.GetValue("Weight", typeof(int));
			this.EYES = (string)info.GetValue("Eyes", typeof(string));
			this.HAIR = (string)info.GetValue("Hair", typeof(string));
			this.ge_align = (GE_Align)info.GetValue ("GE_Align", typeof(GE_Align));
			this.lc_align = (LC_Align)info.GetValue ("LC_Align", typeof(LC_Align));

			//show a character sheet after loading because why not?
			string sheet = charsheet ();
			Console.WriteLine (sheet);
			Console.ReadLine ();
		}

		//sends data to InOut
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue ("Strength", this.STR);
			info.AddValue ("Dexterity", this.DEX);
			info.AddValue ("Constitution", this.CON);
			info.AddValue ("Intelligence", this.INT);
			info.AddValue ("Wisdom", this.WIS);
			info.AddValue ("Charisma", this.CHA);

			info.AddValue ("Racial Strength", this.strRacial);
			info.AddValue ("Racial Dexterity", this.dexRacial);
			info.AddValue ("Racial Constitution", this.conRacial);
			info.AddValue ("Racial Intelligence", this.intRacial);
			info.AddValue ("Racial Wisdom", this.wisRacial);
			info.AddValue ("Racial Charisma", this.chaRacial);

			info.AddValue ("Race", this.race);

			info.AddValue ("Name", this.NAME);
			info.AddValue ("Age", this.AGE);
			info.AddValue ("Height", this.HEIGHT);
			info.AddValue ("Weight", this.WEIGHT);
			info.AddValue ("Eyes", this.EYES);
			info.AddValue ("Hair", this.HAIR);
			info.AddValue ("GE_Align", this.ge_align);
			info.AddValue ("LC_Align", this.lc_align);
		}

		//creates a character sheet.  By keeping this here it is easier to edit later.
		public string charsheet()
		{
			string description = string.Format("Name: {0}" +
				"Age: {1}, Height: {2}, Weight: {3}\n" +
				"Eyes: {4}, Hair: {5}",
				this.name, this.age, this.height, this.weight, 
				this.eyes, this.hair);

			string attributes = string.Format ("STR: {0} DEX: {1} CON: {2}\n" +
                "INT: {3} WIS: {4} INT: {5}",
                 this.strength, this.dexterity, this.constitution, 
                 this.intelligence, this.wisdom, this.charisma);
				
			string align;
			string lc = "";
			string ge = "";
			switch (lc_align)
			{
			case LC_Align.Chaotic:
				lc = "Chaotic";
				break;
			case LC_Align.Lawful:
				lc = "Lawful";
				break;
			case LC_Align.Neutral:
				lc = "Neutral";
				break;
			}
			switch (ge_align)
			{
			case GE_Align.Evil:
				ge = "Evil";
				break;
			case GE_Align.Good:
				ge = "Good";
				break;
			case GE_Align.Neutral:
				ge = "Neutral";
				break;
			}

			if (lc == "Neutral" && ge == "Neutral")
			{
				align = "Alignment: True Neutral";
			} else
			{
				align = "Alignment: " + lc + " " + ge;
			}

			string sheet = description + "\t" + align + "\n" + attributes;

			return sheet;
		}

        #region Character Stats

        // Character stats. Using capitals because 'int' is a keyword.
        private int STR;
        private int DEX;
        private int CON;
        private int INT;
        private int WIS;
        private int CHA;
		//we can just return the point cost from an array rather than figuring out what the formula whould be.
        private int[] points = { -4, -2, -1, 0, 1, 2, 3, 5, 7, 10, 13, 17 };
		//this returns a 'never used' warning on compile even though it is totally used.
		private int pointcost;
        // The get method calculates values then returns without the need for a function call.
        public int strength
        {
            get
            {
				return this.STR + this.strAlter + this.strRacial;
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
				return this.DEX + this.dexAlter + this.dexRacial;
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
				return this.CON + this.conAlter + this.conRacial;
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
				return this.INT + this.intAlter + this.intRacial;
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
				return this.WIS + this.wisAlter + this.wisRacial;
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
				return this.CHA + this.chaAlter + this.chaRacial;
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
				//remember that variable that was 'never used'? yeah.
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

		// Racial stat changes
		public int strRacial;
		public int dexRacial;
		public int conRacial;
		public int intRacial;
		public int wisRacial;
		public int chaRacial;

		//reset the racial stat boosts here
		public void RacialReset()
		{
			strRacial = 0;
			dexRacial = 0;
			conRacial = 0;
			intRacial = 0;
			wisRacial = 0;
			chaRacial = 0;
		}

        public void RaceStatMod()
        {
            switch(race)
            {
			case CharacterRace.Dwarf:
					RacialReset ();
					conRacial = 2;
                    wisRacial = 2;
					chaRacial = -2;
                    break;
                case CharacterRace.Elf:
					RacialReset ();
					dexRacial = 2;
					conRacial = -2;
					intRacial = 2;
                    break;
                case CharacterRace.Gnome:
					RacialReset ();
					strRacial = -2;
					conRacial = 2;
					chaRacial = 2;
                    break;
                case CharacterRace.Halfling:
					RacialReset ();
					strRacial = -2;
					dexRacial = 2;
					chaRacial = 2;
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

			// Racial Ability Alter Defauling.
			this.strRacial = alterDefault;
			this.dexRacial = alterDefault;
			this.conRacial = alterDefault;
			this.intRacial = alterDefault;
			this.wisRacial = alterDefault;
			this.chaRacial = alterDefault;

            // Default to human.
            this.race = CharacterRace.Human;

			// Default Description
			this.name = "New Character";
			this.age = 40;
			this.height = 170;
			this.weight = 70;
			this.eyes = "brown";
			this.hair = "SPIKY BLONDE";
			this.ge_align = GE_Align.Neutral;
			this.lc_align = LC_Align.Neutral;
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
		#endregion

		#region character description

		public GE_Align ge_align;
		public LC_Align lc_align;
		private string NAME;
		private int AGE;
		private int HEIGHT;
		private int WEIGHT;
		private string EYES;
		private string HAIR;


		public string name
		{
			get
			{
				return this.NAME;
			}
			set
			{
				this.NAME = value;
			}
		}

		public int age
		{
			get
			{
				return this.AGE;
			}
			set
			{
				this.AGE = value;
			}
		}

		public int height
		{
			get
			{
				return this.HEIGHT;
			}
			set
			{
				this.HEIGHT = value;
			}
		}

		public int weight
		{
			get
			{
				return this.WEIGHT;
			}
			set
			{
				this.WEIGHT = value;
			}
		}

		public string eyes
		{
			get
			{
				return this.EYES;
			}
			set
			{
				this.EYES = value;
			}
		}

		public string hair
		{
			get
			{
				return this.HAIR;
			}
			set
			{
				this.HAIR = value;
			}
		}

		public enum GE_Align
		{
			Good,
			Neutral,
			Evil
		};

		public enum LC_Align
		{
			Lawful,
			Neutral,
			Chaotic
		};

        public void Description()
        {
            Console.Clear();
            Console.WriteLine("Description");
            Console.ReadLine();
        }

        #endregion
    }
}

