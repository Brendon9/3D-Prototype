using System.Linq;
using Godot;

namespace Prototype;

public partial class InputGatherer : Node
{
	public InputPackage GatherInput()
	{
		InputPackage newInput = new InputPackage();

		newInput.inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (newInput.inputDirection != Vector2.Zero)
		{
			newInput.actions.Add("run");
		}

		if (Input.IsActionJustPressed("jump"))
		{
			if (newInput.actions.Contains("sprint"))
			{
				newInput.actions.Add("sprint_jump");
			}
			else
			{
				newInput.actions.Add("run_jump");
			}
		}

		if (newInput.actions.Count == 0)
		{
			newInput.actions.Add("idle");
		}

		return newInput;
	}
}
