using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program
{
    //Contains Loading and Saving functionality
    class InOut
    {
		//the I/O directory for saving characters is ProgramDir\characters
		public string path = Directory.GetCurrentDirectory () + "\\characters\\";

		//creates the characters directory
		public void createdir()
		{
			Directory.CreateDirectory(path);
			var di = new DirectoryInfo(path);
			di.Attributes &= ~FileAttributes.ReadOnly;
		}

		//Loads characters from a binary file
		public Character Load(string filename)
        {
			//make sure the directory exists
			createdir ();
			//create a new Character ckass to load the data into
			Character character = new Character();
			//stream the data into the character
			Stream stream = File.Open(path + filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			character = (Character)bFormatter.Deserialize(stream);
			stream.Close();
			return character;
        }
		public void Save(string filename, Character character)
		{
			//make sure the directory exists
			createdir ();
			//stream the character into the save file
			Stream stream = File.Open(path + filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, character);
			stream.Close();
		}
		//Returns a list of files in the current directory (by default the program directory)
		public string Files()
		{
			//make sure the directory exists
			createdir ();
			//get an array of all files with extension .char
			string[] files = Directory.GetFiles (path, "*.char");
			string files2 = "";
			//create a vertical list of file names
			foreach (string j in files)
			{
				string k = j.Replace (path, "");
				k = k.Replace (".char", "");
				files2 += "\n" + k;
			}
			return files2;
		}
    }
}

