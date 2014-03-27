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

	public enum CharacterClass
	{
		Barbarian,
		Bard,
		Cleric,
		Druid,
		Fighter,
		Monk,
		Paladin,
		Ranger,
		Rogue,
		Sorcerer,
		Wizard}

	;

	#region InOut
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
			this.CLASS = (CharacterClass)info.GetValue ("Class", typeof(CharacterClass));

			this.HD = (int)info.GetValue ("Hit Dice", typeof(int));
			this.WEALTH = (float)info.GetValue("Wealth", typeof(float));
			this.SKILLPOINTS = (int)info.GetValue ("Skillpoints", typeof(int));
			this.BAB = (int)info.GetValue("BAB", typeof(int));
			this.FORTITUDE = (int)info.GetValue ("fortitude", typeof(int));
			this.REFLEX = (int)info.GetValue ("reflex", typeof(int));
			this.WILL = (int)info.GetValue ("will", typeof(int));

			this.NAME = (string)info.GetValue("Name", typeof(string));
			this.AGE = (int)info.GetValue("Age", typeof(int));
			this.HEIGHT = (int)info.GetValue("Height", typeof(int));
			this.WEIGHT = (int)info.GetValue("Weight", typeof(int));
			this.EYES = (string)info.GetValue("Eyes", typeof(string));
			this.HAIR = (string)info.GetValue("Hair", typeof(string));
			this.ge_align = (GE_Align)info.GetValue ("GE_Align", typeof(GE_Align));
			this.lc_align = (LC_Align)info.GetValue ("LC_Align", typeof(LC_Align));
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
			info.AddValue ("Class", this.CLASS);

			info.AddValue("Hit Dice", this.HD);
			info.AddValue("Wealth", this.WEALTH);
			info.AddValue("Skillpoints", this.SKILLPOINTS);
			info.AddValue("BAB", this.BAB);
			info.AddValue("fortitude", this.FORTITUDE);
			info.AddValue("reflex", this.REFLEX);
			info.AddValue("will", this.WILL);

			info.AddValue ("Name", this.NAME);
			info.AddValue ("Age", this.AGE);
			info.AddValue ("Height", this.HEIGHT);
			info.AddValue ("Weight", this.WEIGHT);
			info.AddValue ("Eyes", this.EYES);
			info.AddValue ("Hair", this.HAIR);
			info.AddValue ("GE_Align", this.ge_align);
			info.AddValue ("LC_Align", this.lc_align);
		}

	#endregion

		#region Charactersheet
		//creates a character sheet.  By keeping this here it is easier to edit later.

		public string DESCRIPTION;
		public string description {
			get
			{
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
					align = string.Format ("Alignment: {0} {1}", lc, ge);
				}

				string description = string.Format ("Name: {0} " + align +
					"\nAge: {1} years, Height: {2}cm, Weight: {3}kg\n" +
				                    "Eyes: {4}, Hair: {5}",
					                    this.name, this.age, this.height, this.weight, 
					                    this.eyes, this.hair);

				return description;
			}
		}

		public string charsheet()
		{
			string description = this.description;

			string attributes = string.Format ("STR: {0} DEX: {1} CON: {2}\n" +
                "INT: {3} WIS: {4} INT: {5}",
                 this.strength, this.dexterity, this.constitution, 
                 this.intelligence, this.wisdom, this.charisma);
				

			string sheet = description + "\n" + attributes;

			return sheet;
		}
		#endregion

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

		#region Character Class

		// Define CLASS in capitals since class is a keyword
		public CharacterClass CLASS;

		// Initialize class variables
		private int HD;
		private float WEALTH;
		private int SKILLPOINTS;
		private int BAB;
		private int FORTITUDE;
		private int REFLEX;
		private int WILL;

		public int hitdice
		{
			get
			{
				return this.HD;
			}
		}
		public float wealth
		{
			get
			{
				return this.WEALTH;
			}
			set
			{
				this.WEALTH = value;
			}
		}
		public int skillpoints
		{
			get
			{
				return this.SKILLPOINTS;
			}
		}
		public int bab
		{
			get
			{
				return this.BAB;
			}
		}
		public int fortitude
		{
			get
			{
				return this.FORTITUDE;
			}
		}
		public int reflex
		{
			get
			{
				return this.REFLEX;
			}
		}
		public int will
		{
			get
			{
				return this.WILL;
			}
		}

		public void Barbarian(Character character)
		{
			character.CLASS = CharacterClass.Barbarian;
			if (character.lc_align == LC_Align.Lawful)
			{
				character.lc_align = LC_Align.Neutral;
			}
			HD = 12;
			wealth = 105F;
			SKILLPOINTS = 4 + character.intMod;
			BAB = 1;
			FORTITUDE = 2;
			REFLEX = 0;
			WILL = 0;
		}

		public void Bard(Character character)
		{
			character.CLASS = CharacterClass.Bard;
			HD = 8;
			wealth = 105F;
			SKILLPOINTS = 6 + character.intMod;
			BAB = 0;
			FORTITUDE = 0;
			REFLEX = 2;
			WILL = 2;
		}

		public void Cleric(Character character)
		{
			character.CLASS = CharacterClass.Cleric;
			HD = 8;
			wealth = 140F;
			SKILLPOINTS = 2 + character.intMod;
			BAB = 0;
			FORTITUDE = 2;
			REFLEX = 0;
			WILL = 2;
		}

		public void Druid(Character character)
		{
			character.CLASS = CharacterClass.Druid;
			HD = 8;
			wealth = 70F;
			SKILLPOINTS = 4 + character.intMod;
			BAB = 0;
			FORTITUDE = 2;
			REFLEX = 0;
			WILL = 2;
		}

		public void Fighter(Character character)
		{
			character.CLASS = CharacterClass.Fighter;
			HD = 10;
			wealth = 175F;
			SKILLPOINTS = 2 + character.intMod;
			BAB = 1;
			FORTITUDE = 2;
			REFLEX = 0;
			WILL = 0;
		}

		public void Monk(Character character)
		{
			character.CLASS = CharacterClass.Monk;
			if (character.lc_align != LC_Align.Lawful)
			{
				character.lc_align = LC_Align.Lawful;
			}
			HD = 8;
			wealth = 35F;
			SKILLPOINTS = 4 + character.intMod;
			BAB = 0;
			FORTITUDE = 2;
			REFLEX = 2;
			WILL = 2;
		}

		public void Paladin(Character character)
		{
			character.CLASS = CharacterClass.Paladin;
			if (character.lc_align != LC_Align.Lawful || character.ge_align != GE_Align.Good)
			{
				character.lc_align = LC_Align.Lawful;
				character.ge_align = GE_Align.Good;
			}
			HD = 10;
			wealth = 175F;
			SKILLPOINTS = 2 + character.intMod;
			BAB = 1;
			FORTITUDE = 2;
			REFLEX = 0;
			WILL = 2;
		}

		public void Ranger(Character character)
		{
			character.CLASS = CharacterClass.Ranger;
			HD = 10;
			wealth = 175F;
			SKILLPOINTS = 6 + character.intMod;
			BAB = 1;
			FORTITUDE = 2;
			REFLEX = 2;
			WILL = 0;
		}

		public void Rogue(Character character)
		{
			character.CLASS = CharacterClass.Rogue;
			HD = 8;
			wealth = 140F;
			SKILLPOINTS = 8 + character.intMod;
			BAB = 0;
			FORTITUDE = 0;
			REFLEX = 2;
			WILL = 0;
		}

		public void Sorceror(Character character)
		{
			character.CLASS = CharacterClass.Sorcerer;
			HD = 6;
			wealth = 70F;
			SKILLPOINTS = 2 + character.intMod;
			BAB = 0;
			FORTITUDE = 0;
			REFLEX = 0;
			WILL = 2;
		}

		public void Wizard(Character character)
		{
			character.CLASS = CharacterClass.Wizard;
			HD = 6;
			wealth = 70F;
			SKILLPOINTS = 2 + character.intMod;
			BAB = 0;
			FORTITUDE = 0;
			REFLEX = 0;
			WILL = 2;
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

			// Default to Rogue
			this.CLASS = CharacterClass.Rogue;

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

