using Godot;

namespace Prototype;

public partial class InputGatherer : Node
{
	public InputPackage GatherInput()
	{
		InputPackage newInput = new InputPackage();

		newInput.inputDirection = Input.GetVector("left", "right", "forward", "backward");
		if (newInput.inputDirection != Vector2.Zero)
		{
			newInput.actions.Add("run");
			if (Input.IsActionPressed("sprint"))
			{
				newInput.actions.Add("sprint");
			}
		}

		if (Input.IsActionJustPressed("jump"))
		{
			if (newInput.actions.Contains("sprint"))
			{
				newInput.actions.Add("jump_sprint");
			}
			else
			{
				newInput.actions.Add("jump_run");
			}
		}

		if (Input.IsActionJustPressed("light_attack"))
		{
			newInput.combatActions.Add("light_attack_pressed");
		}

		if (newInput.actions.Count == 0)
		{
			newInput.actions.Add("idle");
		}

		return newInput;
	}
}
