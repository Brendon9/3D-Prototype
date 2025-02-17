using Godot;
using System;

public partial class MovesData : Node
{
	AnimationPlayer BackendAnimationDatabase;

	bool AnimationEnded;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BackendAnimationDatabase = GetNode<AnimationPlayer>("BackendAnimationsDatabase");
	}


	public void GetValue(string animation, int track, float time)
	{

	}
}