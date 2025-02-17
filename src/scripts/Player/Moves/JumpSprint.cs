using Godot;

namespace Prototype;

public partial class JumpSprint : Move
{
	private const float VerticalSpeedAdded = 2.5f;
	private const float TransitionTiming = 0.4f;
	private const float JumpTiming = 0.0657f;
	private bool jumped = false;

	public override void _Ready()
	{
		Animation = "jump_sprint";
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
				Player.Velocity += Player.Velocity with { Y = VerticalSpeedAdded };
				jumped = true;
			}
		}
		Player.MoveAndSlide();
	}

	public override void OnEnterState() { }

	public override void OnExitState() { }
}
