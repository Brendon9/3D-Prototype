using Godot;
using System;

namespace Prototype;

public partial class Idle : Node, IMove
{
	public string CheckRelevance(InputPackage input)
	{
		input.actions.Sort(new Move.PrioritySort());
		return input.actions[0];
	}

	public void Update(InputPackage input, double delta) { }

	public void OnEnterState() { }

	public void OnExitState() { }
}
