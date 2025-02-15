using Godot;

namespace Prototype;

public partial class Idle : Node, IMove
{
	private CharacterBody3D player;
	public CharacterBody3D Player { get { return player; } set { player = value; } }

	public string CheckRelevance(InputPackage input)
	{
		input.actions.Sort(new Move.PrioritySort());
		return input.actions[0];
	}

	public void Update(InputPackage input, double delta) { }

	public void OnEnterState() { }

	public void OnExitState() { }
}
