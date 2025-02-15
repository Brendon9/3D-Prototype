using Godot;

namespace Prototype;

public partial class Midair : Move
{
	[Export] RayCast3D Downcast;
	[Export] BoneAttachment3D RootAttachment;

	private const float LandingHeight = 1.163f;
	public override void _Ready()
	{
		Animation = "midair";
		MoveName = "midair";
	}

	public override string CheckRelevance(InputPackage input)
	{
		Vector3 floorPoint = Downcast.GetCollisionPoint();
		if (RootAttachment.GlobalPosition.DistanceTo(floorPoint) < LandingHeight)
		{
			Vector3 xzVelocity = Player.Velocity;
			xzVelocity.Y = 0;
			if (xzVelocity.LengthSquared() >= 10)
			{
				return "landing_sprint";
			}
			return "landing_run";
		}
		else
		{
			return "okay";
		}
	}

	public override void OnEnterState()
	{
	}

	public override void OnExitState()
	{
	}

	public override void Update(InputPackage input, double delta)
	{
		Player.Velocity -= Player.GetGravity() * (float)delta;
		Player.MoveAndSlide();
	}
}
