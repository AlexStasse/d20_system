using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program
{
    //Contains Loading and Saving functionality
    class InOut
    {
		public string path = Directory.GetCurrentDirectory () + "\\characters\\";


		public void createdir()
		{
			Directory.CreateDirectory(path);
			var di = new DirectoryInfo(path);
			di.Attributes &= ~FileAttributes.ReadOnly;
		}

		public Character Load(string filename)
        {
			createdir ();
			Character character = new Character();
			Stream stream = File.Open(path + filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			character = (Character)bFormatter.Deserialize(stream);
			stream.Close();
			return character;
        }
		public void Save(string filename, Character character)
		{
			createdir ();
			Console.WriteLine (path);
			Stream stream = File.Open(path + filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, character);
			stream.Close();
		}
		//Returns a list of files in the current directory (by default the program directory)
		public string Files()
		{
			createdir ();
			string[] files = Directory.GetFiles (path, "*.char");
			string files2 = "";
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

