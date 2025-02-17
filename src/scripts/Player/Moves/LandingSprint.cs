using Godot;

namespace Prototype;

public partial class LandingSprint : Move
{
	private const float TransitionTiming = 0.2f;
	public override void _Ready()
	{
		Animation = "landing_sprint";
		MoveName = "landing_sprint";
	}

	public override string CheckRelevance(InputPackage input)
	{
		if (GetProgress() >= 0.2)
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
