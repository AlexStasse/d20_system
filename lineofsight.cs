using System;

public class Program
{
	public static void Main(string[] args)
	{
		char[,] field = new char[Console.WindowHeight, Console.WindowWidth];
		for(int i = 0; i < field.GetLength(0); i++)
		{
			for(int j = 0; j < field.GetLength(1); j++)
			{
				field[i, j] = ' ';
			}
		}
		Random rand = new Random();
		int y0 = rand.Next(field.GetLength(0));
		int x0 = rand.Next(field.GetLength(1));
		int y1;
		int x1;
		// Ensure that the points are different.
		do
		{
			y1 = rand.Next(field.GetLength(0));
			x1 = rand.Next(field.GetLength(1));
		}
		while(y0 == y1 && x0 == x1);
		if(Math.Abs(x1 - x0) > Math.Abs(y1 - y0))
		{
			if(x1 < x0)
			{
				int temp = x0;
				x0 = x1;
				x1 = temp;
			}
			for(int x = x0; x <= x1; x++)
			{
				int y = ((int) Math.Round((double) (y1 - y0) / (double) (x1 - x0) * (x - x0))) + y0;
				Console.WriteLine("y: {0}", y);
				field[y, x] = '#';
			}
		}
		else
		{
			if(y1 < y0)
			{
				int temp = y0;
				y0 = y1;
				y1 = temp;
			}
			for(int y = y0; y <= y1; y++)
			{
				int x = ((int) Math.Round((double) (x1 - x0) / (double) (y1 - y0) * (y - y0))) + x0;
				Console.WriteLine("x: {0}", x);
				field[y, x] = '#';
			}
		}
		for(int i = 0; i < field.GetLength(0); i++)
		{
			for(int j = 0; j < field.GetLength(1); j++)
			{
				Console.Write(field[i, j]);
			}
			Console.WriteLine();
		}
		Console.WriteLine("{0},{1} : {2},{3}", x0, y0, x1, y1);
	}
}