using Godot;
using System;
using System.Collections.Generic;

namespace Prototype;

public partial class Model : Node
{
	private IMove currentMove;
	Dictionary<string, IMove> moves = new Dictionary<string, IMove>();

	public override void _Ready()
	{
		moves.Add("idle", GetNode<Idle>("Idle"));
		moves.Add("run", GetNode<Run>("Run"));
		moves.Add("jump", GetNode<Jump>("Jump"));
		currentMove = moves["idle"] as IMove;
	}

	public void Update(InputPackage input, double delta)
	{
		var relevance = currentMove.CheckRelevance(input);
		if (relevance != "okay")
		{
			switchTo(relevance);
		}
		currentMove.Update(input, delta);
	}

	private void switchTo(string state)
	{
		currentMove.OnExitState();
		currentMove = moves[state];
		currentMove.OnEnterState();
	}
}
