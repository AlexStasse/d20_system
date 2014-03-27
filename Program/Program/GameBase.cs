using System;

namespace Program
{
	public class GameBase
	{
		Tile[,] screen;
		public GameBase()
		{
			this.screen = new Tile[Console.WindowHeight, Console.WindowWidth];
			for(int i = 0; i < screen.GetLength(0); i++)
			{
				for(int j = 0; j < screen.GetLength(1); j++)
				{
					screen[i, j] = new Tile();
				}
			}
		}

		public void print()
		{
			char[] cTemp;
			string[] sTemp;
			int cCount = 0;
			int sCount = 0;
			sTemp = new string[screen.GetLength(0)];
			for(int i = 0; i < screen.GetLength(0); i++)
			{
				cTemp = new char[screen.Length];
				for(int j = 0; j < screen.GetLength(1); j++)
				{
					cTemp[cCount] = screen[i, j].print();
					cCount++;
				}
				cCount = 0;
				sTemp[sCount] = String.Join("", cTemp) + "\n";
				sCount++;
			}
			string s = String.Join("", sTemp);
			Console.Write(s);
		}
	}
}

