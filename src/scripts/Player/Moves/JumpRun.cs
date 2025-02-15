using Godot;

namespace Prototype;

public partial class JumpRun : Move
{
  private const float VerticalSpeedAdded = 2.5f;
  private const float TransitionTiming = 0.44f;
  private const float JumpTiming = 0.1f;
  private bool jumped = false;

  public override void _Ready()
  {
    Animation = "jump_run";
  }

  public override string CheckRelevance(InputPackage input)
  {
    if (Player.IsOnFloor())
    {
      input.actions.Sort(new PrioritySort());
      return input.actions[0];
    }
    return "okay";
  }

  public override void Update(InputPackage input, double delta)
  {
    Player.Velocity += Player.GetGravity() * (float)delta;
    Player.MoveAndSlide();
  }

  public override void OnEnterState()
  {
    Vector3 velocity = Player.Velocity;
    // velocity.Y = JumpVelocity;
    Player.Velocity = velocity;
  }

  public override void OnExitState()
  {
  }
}
