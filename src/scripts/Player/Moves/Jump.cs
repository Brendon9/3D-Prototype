using Godot;
using System;
using System.Linq;

namespace Prototype;

public partial class Jump : Node, IMove
{

	[Export] CharacterBody3D Player;

	public const float JumpVelocity = 4.5f;

	public string CheckRelevance(InputPackage input)
	{
		if (Player.IsOnFloor())
		{
			input.actions.Sort(new Move.PrioritySort());
			return input.actions[0];
		}
		return "okay";
	}

	public void Update(InputPackage input, double delta)
	{
		Player.Velocity += Player.GetGravity() * (float)delta;
		Player.MoveAndSlide();
	}

	public void OnEnterState()
	{
		Vector3 velocity = Player.Velocity;
		velocity.Y = JumpVelocity;
		Player.Velocity = velocity;
	}

	public void OnExitState()
	{
	}
}
