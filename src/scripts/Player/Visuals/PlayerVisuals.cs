using Godot;

namespace Prototype;

public partial class PlayerVisuals : Node3D
{
	Model Model;
	MeshInstance3D betaJoints;
	MeshInstance3D betaSurface;
	Node3D SwordVisuals;

	public void AcceptModel(Model _model)
	{
		Model = _model;
		betaJoints.Skeleton = _model.skeleton.GetPath();
		betaSurface.Skeleton = _model.skeleton.GetPath();
	}

	public override void _Ready()
	{
		betaJoints = GetNode<MeshInstance3D>("BetaJoints");
		betaSurface = GetNode<MeshInstance3D>("BetaSurface");
		SwordVisuals = GetNode<Node3D>("SwordVisuals");
	}

	public override void _Process(double delta)
	{
		AdjustWeaponVisuals();
	}

	private void AdjustWeaponVisuals()
	{
		SwordVisuals.GlobalTransform = Model.ActiveWeapon.GlobalTransform;
	}
}
