/*
 * A* Pathfinding.
 * This program implements a basic version of the A* pathfinding algorithm.
 * Author: Owen Harvey
 * Date: 2014-04-15
 */


using System;
using System.Collections.Generic;

namespace Program
{
	// Ensures that these properties exist on the entity class.
	interface IPhysicalProperties
	{
		bool passable
		{
			get;
			set;
		}
	}

	// Class that can be replaced later.
	public class Entity : IPhysicalProperties
	{
		private bool _passable;
		public bool passable
		{
			get
			{
				return _passable;
			}
			set
			{
				_passable = value;
			}
		}
		
		public Entity()
		{
			this.passable = true;
		} 
	}
	
	// Internal class, should only be using for pathfinding.
	internal class Node
	{
		private Entity entity;
		internal bool passable
		{
			get
			{
				return this.entity.passable;
			}
			set
			{
				this.entity.passable = value;
			}
		}
		internal bool visible;
		internal Node parent;
		internal char c;
		// Values used in A* path calculations.
		internal int g;
		internal int h;
		// Used to hold the node location.
		// Useful when comparing to the nodes in openList.
		internal int x;
		internal int y;
		// Path cost thus far.
		internal int f
		{
			get
			{
				return g + h;
			}
		}
		
		// Defaults a bunch of values.
		// Not the best but shad-up.
		internal Node()
		{
			this.entity = new Entity();
			this.visible = false;
			this.parent = null;
			this.c = '@';
			this.g = 0;
			this.h = 0;
			this.x = 0;
			this.y = 0;
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			// Set up lists and the field.
			Node startNode;
			Node endNode;
			int SCALE = 10;
			int fieldDensity = 20;
			List<Node> openList = new List<Node>();
			List<Node> closedList = new List<Node>();
			Node[,] field = new Node[Console.WindowHeight, Console.WindowWidth];
			// Set the field obstacle density from system args.
			if(args.Length >= 1)
			{
				try
				{
					fieldDensity = Int32.Parse(args[0]);
				}
				catch
				{
				}
			}
			// Populate the field.
			for(int i = 0; i < field.GetLength(0); i++)
			{
				for(int j = 0; j < field.GetLength(1); j++)
				{
					field[i, j] = new Node();
					field[i, j].y = i;
					field[i, j].x = j;
				}
			}
			// Set up start node
			Random rand = new Random();
			startNode = field[rand.Next(field.GetLength(0)), rand.Next(field.GetLength(1))];
			startNode.visible = true;
			startNode.c = '8';
			startNode.g = 0;
			openList.Add(startNode);
			// Set up end node
			endNode = field[rand.Next(field.GetLength(0)), rand.Next(field.GetLength(1))];
			endNode.c = '#';
			// Add impassable Nodes
			for(int i = 0; i < field.GetLength(0); i++)
			{
				for(int j = 0; j < field.GetLength(1); j++)
				{
					if(field[i, j] != startNode && field[i, j] != endNode)
					{
						// fieldDensity holds the percentage of tiles that are filled with impassable nodes.
						if(rand.Next(0, 100) < fieldDensity)
						{
							field[i, j].passable = false;
							field[i, j].visible = true;
							field[i, j].c = '.';
						}
					}
				}
			}
			// Add heuristic data.
			for(int i = 0; i < field.GetLength(0); i++)
			{
				for(int j = 0; j < field.GetLength(1); j++)
				{
					// Manhattan Distance heuristic.
					// Dead simple but probably not good for larger, messy maps.
					field[i, j].h = (Math.Abs(field[i, j].x - endNode.x) + Math.Abs(field[i, j].y - endNode.y)) * SCALE;
				}
			}
			// Main algorithm loop.
			int cntr = 1;
			while(openList.Count > 0 && closedList.LastIndexOf(endNode) == -1)
			{
				Node tempNode = openList[0];
				// Find the node with the lowest f value.
				for(int i = 0; i < openList.Count; i++)
				{
					if(openList[i].f < tempNode.f)
					{
						tempNode = openList[i];
					}
				}
				// Check the surrounding nodes for the best path.
				for(int i = 0; i < 8; i++)
				{
					int x = -1;
					int y = -1;
					bool valid = false;
					// Each case does bound checking for the direction.
					switch(i)
					{
						// Cardinal directions.
						// Up
						case 0:
							if(tempNode.y - 1 >= 0)
							{
								x = tempNode.x;
								y = tempNode.y - 1;
								valid = true;
							}
							break;
						// Down
						case 1:
							if(tempNode.y + 1 <= field.GetLength(0) - 1)
							{
								x = tempNode.x;
								y = tempNode.y + 1;
								valid = true;
							}
							break;
						// Left
						case 2:
							if(tempNode.x - 1 >= 0)
							{
								x = tempNode.x - 1;
								y = tempNode.y;
								valid = true;
							}
							break;
						// Right
						case 3:
							if(tempNode.x + 1 <= field.GetLength(1) - 1)
							{
								x = tempNode.x + 1;
								y = tempNode.y;
								valid = true;
							}
							break;
						// Ordinal directions.
						// Up-Left
						case 4:
							if(tempNode.x - 1 >= 0 && tempNode.y - 1 >= 0)
							{
								x = tempNode.x - 1;
								y = tempNode.y - 1;
								valid = true;
							}
							break;
						// Up-Right
						case 5:
							if(tempNode.x + 1 <= field.GetLength(1) - 1 && tempNode.y - 1 >= 0)
							{
								x = tempNode.x + 1;
								y = tempNode.y - 1;
								valid = true;
							}
							break;
						// Down Left
						case 6:
							if(tempNode.x - 1 >= 0 && tempNode.y + 1 <= field.GetLength(0) - 1)
							{
								x = tempNode.x - 1;
								y = tempNode.y + 1;
								valid = true;
							}
							break;
						// Down Right
						case 7:
							if(tempNode.x + 1 <= field.GetLength(1) - 1 && tempNode.y + 1 <= field.GetLength(0) - 1)
							{
								x = tempNode.x + 1;
								y = tempNode.y + 1;
								valid = true;
							}
							break;
						// Throws errors but whatever. It lets us know that something went wrong somewhere.
						default:
							x = -1;
							y = -1;
							break;
					}
					// Set the movement cost for cardinal or ordinal. 
					// Ordinal is proportional to approx sqrt(2) so that diagonal movement is
					// isn't 'faster', but using ints for speed of execution.
					int moveCost;
					if(i < 4)
					{
						moveCost = (int) (1 * SCALE);
					}
					else
					{
						moveCost = (int) (1.4 * SCALE);
					}
					// Check that the node is in the field and is not in the closedList (already checked).
					if(valid == true && closedList.LastIndexOf(field[y, x]) == -1 && field[y, x].passable == true)
					{
						// If not in the openList, add to the openList.
						if(openList.LastIndexOf(field[y, x]) == -1)
						{
							field[y, x].parent = tempNode;
							field[y, x].g = tempNode.g + moveCost;
							openList.Add(field[y, x]);
						}
						else
						{
							// If this is a less expensive path, update the node.
							if(tempNode.g + 1 < field[y, x].g)
							{
								field[y, x].parent = tempNode;
								field[y, x].g = tempNode.g + moveCost;
								//openList.Add(field[y, x]);
							}
						}
					}					
				}
				openList.Remove(tempNode);
				closedList.Add(tempNode);
				//Console.WriteLine("Loop number {0}", cntr++);
				//Console.WriteLine("{0} elements in the openList", openList.Count);
			}
			// Trace the path back to the starting node.
			Node temp = endNode;
			while(temp != null)
			{
				temp.visible = true;
				temp = temp.parent;
			}
			// Print the field out to console.
			string printString = ""; 
			for(int i = 0; i < field.GetLength(0); i++)
			{
				for(int j = 0; j < field.GetLength(1); j++)
				{
					if(field[i, j].visible == true)
					{
						printString += field[i, j].c;
					}
					else
					{
						printString += " ";
					}
				}
				if(i != field.GetLength(0) - 1)
				{
					printString += "\n";
				}
			}
			// Block for input so the entire field is displayed.
			Console.Write(printString);
			Console.CursorVisible = false;
			Console.ReadKey();
			Console.CursorVisible = true;
		}
	}
}
