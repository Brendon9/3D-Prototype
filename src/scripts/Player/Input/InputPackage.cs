using Godot;
using System;
using System.Collections.Generic;

namespace Prototype;

public partial class InputPackage : Node
{
  public List<string> actions = new List<string>();
  public List<string> combatActions = new List<string>();
  public Vector2 inputDirection = Vector2.Zero;
}