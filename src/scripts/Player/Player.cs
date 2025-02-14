using Godot;
using System;

namespace Prototype;

public partial class Player : CharacterBody3D
{
	Model model;
	InputGatherer inputGatherer;

	public override void _Ready()
	{
		model = GetNode<Model>("Model");
		inputGatherer = GetNode<InputGatherer>("Input");
	}

	public override void _PhysicsProcess(double delta)
	{
		InputPackage input = inputGatherer.GatherInput();
		model.Update(input, delta);
	}
}
