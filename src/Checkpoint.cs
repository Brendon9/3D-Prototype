using Godot;
using System;

namespace Prototype;

public partial class Checkpoint : Node
{

	DiceRoll diceRoll = DiceRoll.D6;
	DiceRollSystem system = new DiceRollSystem();

	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("enter"))
		{
			var result = system.Roll(diceRoll);
			GD.Print(result);
		}
	}
}
