using Godot;

namespace Prototype;

public partial class Slash1 : Move
{
  // const float ComboTiming = 0.97f;
  private const float TransitionTiming = 1.1333f;
  public override void _Ready()
  {
    Animation = "slash_1";
    MoveName = "slash_1";
  }

  public override string CheckRelevance(InputPackage input)
  {
    // check_combos(input)
    // if WorksLongerThan(COMBO_TIMING) and has_queued_move:
    // 	has_queued_move = false
    // 	return queued_move
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

  public override void OnEnterState()
  {
    Player.Velocity = Vector3.Zero;
  }

  public override void OnExitState() { }

  public override void Update(InputPackage input, double delta) { }
}