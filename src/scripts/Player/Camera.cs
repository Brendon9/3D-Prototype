using Godot;
using System;

namespace Prototype;

public partial class Camera : Node3D
{
	[Export] Player Player;
	Camera3D PlayerCamera;
	private bool mouseIsCaptured = true;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerCamera = GetNode<Camera3D>("PlayerCamera");

		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = Player.GlobalPosition;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("mouse_mode_switch"))
		{
			SwitchMouse();
		}
	}

	private void SwitchMouse()
	{
		if (mouseIsCaptured)
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
		else
		{
			Input.MouseMode = Input.MouseModeEnum.Captured;
		}
		mouseIsCaptured = !mouseIsCaptured;
	}
}
