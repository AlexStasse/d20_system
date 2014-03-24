using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program
{
    //Contains Loading and Saving functionality
    class InOut
    {
		public Character Load(string filename)
        {
			Character character = new Character();
			Stream stream = File.Open(filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			character = (Character)bFormatter.Deserialize(stream);
			stream.Close();
			return character;
        }

		public void Save(string filename, Character character)
		{
			Stream stream = File.Open(filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, character);
			stream.Close();
		}
    }
}

