using Godot;

namespace Prototype;

public partial class LandingRun : Move
{
	private const float TransitionTiming = 0.2f;
	public override void _Ready()
	{
		Animation = "landing_run";
		MoveName = "landing_run";
	}

	public override string CheckRelevance(InputPackage input)
	{
		if (WorksLongerThan(TransitionTiming))
		{
			input.actions.Sort(new PrioritySort());
			return input.actions[0];
		}
		else
		{
			return "okay";
		}
	}

	public override void Update(InputPackage _input, double delta)
	{
		Player.Velocity += Player.GetGravity() * (float)delta;
		Player.MoveAndSlide();
	}

	public override void OnEnterState() { }

	public override void OnExitState() { }
}
