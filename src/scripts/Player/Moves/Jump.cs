using Godot;

namespace Prototype;

public partial class Jump : Node, IMove
{
	private CharacterBody3D player;
	public CharacterBody3D Player { get { return player; } set { player = value; } }

	public const float JumpVelocity = 4.5f;

	public string CheckRelevance(InputPackage input)
	{
		if (player.IsOnFloor())
		{
			input.actions.Sort(new Move.PrioritySort());
			return input.actions[0];
		}
		return "okay";
	}

	public void Update(InputPackage input, double delta)
	{
		player.Velocity += player.GetGravity() * (float)delta;
		player.MoveAndSlide();
	}

	public void OnEnterState()
	{
		Vector3 velocity = player.Velocity;
		velocity.Y = JumpVelocity;
		player.Velocity = velocity;
	}

	public void OnExitState()
	{
	}
}
