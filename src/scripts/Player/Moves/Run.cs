using Godot;

namespace Prototype;

public partial class Run : Move
{
	public const float Speed = 2.5f;

	public override void _Ready()
	{
		Animation = "run";
	}

	public override string CheckRelevance(InputPackage input)
	{
		input.actions.Sort(new PrioritySort());
		if (input.actions[0] == "run")
		{
			return "okay";
		}
		return input.actions[0];
	}

	public override void Update(InputPackage input, double delta)
	{
		Player.Velocity = VelocityByInput(input, delta);
		Player.MoveAndSlide();
	}

	private Vector3 VelocityByInput(InputPackage input, double delta)
	{
		Vector3 newVelocity = Player.Velocity;

		Vector3 direction = (Player.Transform.Basis * new Vector3(input.inputDirection.X, 0, input.inputDirection.Y)).Normalized();
		newVelocity.X = direction.X * Speed;
		newVelocity.Z = direction.Z * Speed;

		if (!Player.IsOnFloor())
		{
			newVelocity += Player.GetGravity() * (float)delta;
		}

		return newVelocity;
	}

	public override void OnEnterState()
	{
	}

	public override void OnExitState()
	{
	}
}
