using Godot;
using System.Collections.Generic;

namespace Prototype;

public partial class Model : Node
{
	[Export] public Player player;
	[Export] public Skeleton3D skeleton;
	public AnimationPlayer animator;
	private Move currentMove;
	Dictionary<string, Move> moves = new Dictionary<string, Move>();

	public override void _Ready()
	{
		skeleton = GetNode<Skeleton3D>("GeneralSkeleton");
		animator = GetNode<AnimationPlayer>("AnimationPlayer");

		moves.Add("idle", GetNode<Idle>("Idle"));
		moves.Add("run", GetNode<Run>("Run"));
		moves.Add("jump_run", GetNode<JumpRun>("JumpRun"));
		currentMove = moves["idle"];

		foreach (Move move in moves.Values)
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
		animator.Play(currentMove.Animation);
	}
}
