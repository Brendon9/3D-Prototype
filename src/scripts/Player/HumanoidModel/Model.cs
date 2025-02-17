using Godot;
using System.Collections.Generic;

namespace Prototype;

public partial class Model : Node3D
{
	[Export] public Player player;
	[Export] public Skeleton3D skeleton;
	public AnimationPlayer animator;
	private Move currentMove;
	Dictionary<string, Move> moves = new Dictionary<string, Move>();

	public override void _Ready()
	{
		skeleton = GetNode<Skeleton3D>("GeneralSkeleton");
		animator = GetNode<AnimationPlayer>("SkeletonAnimator");

		moves.Add("idle", GetNode<Idle>("States/Idle"));
		moves.Add("run", GetNode<Run>("States/Run"));
		moves.Add("sprint", GetNode<Sprint>("States/Sprint"));
		moves.Add("jump_run", GetNode<JumpRun>("States/JumpRun"));
		moves.Add("midair", GetNode<Midair>("States/Midair"));
		moves.Add("landing_run", GetNode<LandingRun>("States/LandingRun"));
		moves.Add("jump_sprint", GetNode<JumpSprint>("States/JumpSprint"));
		moves.Add("landing_sprint", GetNode<LandingSprint>("States/LandingSprint"));

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
