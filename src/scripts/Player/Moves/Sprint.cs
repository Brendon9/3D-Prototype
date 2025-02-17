using Godot;
using System;

namespace Prototype;

public partial class Sprint : Move
{
  public const float Speed = 5.0f;
  private float Gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity");

  public override void _Ready()
  {
    Animation = "sprint";
  }

  public override string CheckRelevance(InputPackage input)
  {
    input.actions.Sort(new PrioritySort());
    if (input.actions[0] == "sprint")
    {
      return "okay";
    }
    return input.actions[0];
  }


  public override void Update(InputPackage input, double delta)
  {
    Player.Velocity = VelocityByInput(input, delta);
    Player.LookAt(Player.GlobalPosition - Player.Velocity);
    Player.MoveAndSlide();
  }

  public override void OnEnterState() { }

  public override void OnExitState() { }

  private Vector3 VelocityByInput(InputPackage input, double delta)
  {
    Vector3 newVelocity = Player.Velocity;

    Vector3 direction = (Player.cameraMount.Basis * new Vector3(-input.inputDirection.X, 0, -input.inputDirection.Y)).Normalized();
    newVelocity.X = direction.X * Speed;
    newVelocity.Z = direction.Z * Speed;

    if (!Player.IsOnFloor())
    {
      newVelocity.Y -= Gravity * (float)delta;
    }

    return newVelocity;
  }
}
