using Godot;
using System;

namespace Prototype;

public partial class Checkpoint : Node
{

	[Export]
	private DiceRoll diceRoll = DiceRoll.D6;
	DiceRollSystem system = new DiceRollSystem();

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("enter"))
		{
			var result = system.Roll(diceRoll);
			GD.Print(result);
		}
	}
}
