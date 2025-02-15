using Godot;
using System;

namespace Prototype;

public partial class Run : Node, IMove
{
	private CharacterBody3D player;
	public CharacterBody3D Player { get { return player; } set { player = value; } }

	public const float Speed = 4.5f;

	public string CheckRelevance(InputPackage input)
	{
		input.actions.Sort(new Move.PrioritySort());
		if (input.actions[0] == "run")
		{
			return "okay";
		}
		return input.actions[0];
	}

	public void OnEnterState() { }

	public void OnExitState() { }

	public void Update(InputPackage input, double delta)
	{
		player.Velocity = VelocityByInput(input, delta);
		player.MoveAndSlide();
	}

	private Vector3 VelocityByInput(InputPackage input, double delta)
	{
		Vector3 newVelocity = player.Velocity;

		Vector3 direction = (player.Transform.Basis * new Vector3(input.inputDirection.X, 0, input.inputDirection.Y)).Normalized();
		newVelocity.X = direction.X * Speed;
		newVelocity.Z = direction.Z * Speed;

		if (!player.IsOnFloor())
		{
			newVelocity += player.GetGravity() * (float)delta;
		}

		return newVelocity;
	}
}
