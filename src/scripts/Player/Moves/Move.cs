using Godot;
using System.Collections.Generic;
using System.Diagnostics;

namespace Prototype;

// public interface IMove
// {
// 	public string CheckRelevance(InputPackage input);
// 	// public void Update(InputPackage input, double delta);
// 	// public void OnEnterState();
// 	public void OnExitState();
// 	public double GetProgress();
// }

public abstract partial class Move : Node //, IMove
{
	public string Animation;
	public CharacterBody3D Player;
	public static Dictionary<string, int> MovesPriority = new Dictionary<string, int>()
		{
				{ "idle", 1 },
				{ "run", 2 },
				{ "sprint", 3 },
				{ "jump_run", 10 }
		};
	private double EnterStateTime;

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

	public abstract string CheckRelevance(InputPackage input);

	private void MarkEnterState()
	{
		EnterStateTime = Time.GetUnixTimeFromSystem();
	}

	public double GetProgress()
	{
		double now = Time.GetUnixTimeFromSystem();
		return now - EnterStateTime;
	}

	public abstract void OnEnterState();

	public abstract void OnExitState();

	public abstract void Update(InputPackage input, double delta);

	protected bool WorksBetween(float start, float finish)
	{
		var progress = GetProgress();
		if (progress >= start && progress <= finish)
		{
			return true;
		}

		return false;
	}

	protected bool WorksLessThan(float time)
	{
		if (GetProgress() < time)
		{
			return true;
		}
		return false;
	}

	protected bool WorksLongerThan(float time)
	{
		if (GetProgress() >= time)
		{
			return true;
		}
		return false;
	}
}
