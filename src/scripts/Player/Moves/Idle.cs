namespace Prototype;

public partial class Idle : Move
{
	public override void _Ready()
	{
		Animation = "idle";
	}

	public override string CheckRelevance(InputPackage input)
	{
		input.actions.Sort(new PrioritySort());
		return input.actions[0];
	}

	public override void OnEnterState()
	{
	}

	public override void OnExitState()
	{
	}

	public override void Update(InputPackage input, double delta)
	{
	}
}
