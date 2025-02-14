using Godot;
using System;
using System.Collections.Generic;

namespace Prototype;

public interface IMove
{
	public string CheckRelevance(InputPackage input);
	public void Update(InputPackage input, double delta);
	public void OnEnterState();
	public void OnExitState();
}

public partial struct Move
{
	public static Dictionary<string, int> MovesPriority = new Dictionary<string, int>()
		{
				{ "idle", 1 },
				{ "run", 2 },
				{ "jump", 10 }
		};

	public class PrioritySort : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if (MovesPriority[x] == MovesPriority[y])
			{
				return 0;
			}
			if (MovesPriority[x] < MovesPriority[y])
			{
				return 1;
			}

			return -1;
		}
	}
}
