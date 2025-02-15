using Godot;

namespace Prototype;

public partial class PlayerVisuals : Node3D
{
	[Export] MeshInstance3D betaJoints;
	[Export] MeshInstance3D betaSurface;

	public override void _Ready()
	{
		betaJoints = GetNode<MeshInstance3D>("BetaJoints");
		betaSurface = GetNode<MeshInstance3D>("BetaSurface");
	}

	public void AcceptSkeleton(Skeleton3D skeleton)
	{
		betaJoints.Skeleton = skeleton.GetPath();
		betaSurface.Skeleton = skeleton.GetPath();
	}
}
