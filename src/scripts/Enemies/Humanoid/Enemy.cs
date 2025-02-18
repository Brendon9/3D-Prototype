using Godot;

namespace Prototype;

public partial class Enemy : CharacterBody3D
{
	Model model;
	PlayerVisuals visuals;
	HumanoidAI humanoidAI;

	public override void _Ready()
	{
		model = GetNode<Model>("Model");
		visuals = GetNode<PlayerVisuals>("Visuals");
		humanoidAI = GetNode<HumanoidAI>("HumanoidAI");

		visuals.AcceptModel(model);
	}

	public override void _PhysicsProcess(double delta)
	{
		InputPackage input = humanoidAI.GatherInput();
		model.Update(input, delta);

		input.QueueFree();
	}
}
