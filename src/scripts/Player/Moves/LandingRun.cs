using Godot;

namespace Prototype;

public partial class LandingRun : Move
{
	private const float VerticalSpeedAdded = 2.5f;
	private const float TransitionTiming = 0.44f;
	private const float JumpTiming = 0.1f;
	private bool jumped = false;

	public override void _Ready()
	{
		Animation = "landing_run";
		MoveName = "landing_run";
	}

	public override string CheckRelevance(InputPackage input)
	{
		if (WorksLongerThan(TransitionTiming))
		{
			jumped = false;
			return "midair";
		}
		else
		{
			return "okay";
		}
	}

	public override void Update(InputPackage _input, double delta)
	{
		if (WorksLongerThan(JumpTiming))
		{
			if (!jumped)
			{
				Vector3 velocity = Player.Velocity;
				velocity.Y = VerticalSpeedAdded;
				Player.Velocity += velocity;
				jumped = true;
			}
		}
		Player.MoveAndSlide();
	}

	public override void OnEnterState() { }

	public override void OnExitState() { }
}
