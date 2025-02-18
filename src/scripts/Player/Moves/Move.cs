using Godot;
using System.Collections.Generic;

namespace Prototype;

public abstract partial class Move : Node
{
	public string Animation;
	public string MoveName;
	public Player Player;
	public static Dictionary<string, int> MovesPriority = new Dictionary<string, int>()
		{
				{ "idle", 1 },
				{ "run", 2 },
				{ "sprint", 3 },
				{ "jump_run", 10 },
				{ "jump_sprint", 10 },
				{ "midair", 10 },
				{ "landing_run", 10 },
				{ "landing_sprint", 10 },
				{ "slash_1", 15 },
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

	public double GetProgress()
	{
		double now = Time.GetUnixTimeFromSystem();
		return now - EnterStateTime;
	}

	public abstract void OnEnterState();

	public abstract void OnExitState();

	public abstract void Update(InputPackage input, double delta);

	public void MarkEnterState()
	{
		EnterStateTime = Time.GetUnixTimeFromSystem();
	}

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
