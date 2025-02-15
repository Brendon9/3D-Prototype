using Godot;

namespace Prototype;

public partial class Player : CharacterBody3D
{
	Model model;
	InputGatherer inputGatherer;
	PlayerVisuals visuals;
	public Camera cameraMount;

	public override void _Ready()
	{
		model = GetNode<Model>("Model");
		inputGatherer = GetNode<InputGatherer>("Input");
		visuals = GetNode<PlayerVisuals>("PlayerVisuals");
		cameraMount = GetNode<Camera>("CameraMount");

		visuals.AcceptSkeleton(model.skeleton);
		model.animator.Play("run");
	}

	public override void _PhysicsProcess(double delta)
	{
		InputPackage input = inputGatherer.GatherInput();
		model.Update(input, delta);

		input.QueueFree();
	}
}
