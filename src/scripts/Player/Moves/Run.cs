using Godot;

namespace Prototype;

public partial class Run : Move
{
	public const float Speed = 3.0f;
	private float Gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity");

	public override void _Ready()
	{
		Animation = "run";
	}

	public override string CheckRelevance(InputPackage input)
	{
		if (!Player.IsOnFloor())
		{
			return "midair";
		}

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
		Player.LookAt(Player.GlobalPosition - Player.Velocity);
		Player.MoveAndSlide();
	}

	private Vector3 VelocityByInput(InputPackage input, double delta)
	{
		Vector3 newVelocity = Player.Velocity;

		Vector3 direction = (Player.cameraMount.Basis * new Vector3(-input.inputDirection.X, 0, -input.inputDirection.Y)).Normalized();
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
