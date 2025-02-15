using Godot;
using System.Collections.Generic;

namespace Prototype;

public partial class Model : Node
{
	[Export] public Player player;
	[Export] public Skeleton3D skeleton;
	public AnimationPlayer animator;
	private IMove currentMove;
	Dictionary<string, IMove> moves = new Dictionary<string, IMove>();

	public override void _Ready()
	{
		skeleton = GetNode<Skeleton3D>("GeneralSkeleton");
		animator = GetNode<AnimationPlayer>("AnimationPlayer");
		moves.Add("idle", GetNode<Idle>("Idle"));
		moves.Add("run", GetNode<Run>("Run"));
		moves.Add("jump", GetNode<Jump>("Jump"));
		currentMove = moves["idle"];
		foreach (IMove move in moves.Values)
		{
			move.Player = player;
		}

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
