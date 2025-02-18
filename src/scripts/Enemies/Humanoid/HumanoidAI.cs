using Godot;
using System;

namespace Prototype;

public partial class HumanoidAI : Node
{
	[Export] string mode = "spamming hits";
	const float hitsPeriod = 2f;
	const float hitTreshold = 0f;

	public override void _Ready()
	{
	}

	public InputPackage GatherInput()
	{
		InputPackage inputPackage = new InputPackage();

		inputPackage.actions.Add("idle");

		return inputPackage;
	}
}
