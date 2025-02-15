using Godot;

public partial class Downcast : RayCast3D
{
	BoneAttachment3D RootAttachment;
	CsgSphere3D CsgSphere3D;

	public override void _Ready()
	{
		RootAttachment = GetNode<BoneAttachment3D>("../Root");
		CsgSphere3D = GetNode<CsgSphere3D>("CSGSphere3D2");
	}

	public override void _Process(double delta)
	{
		GlobalPosition = RootAttachment.GlobalPosition;
		CsgSphere3D.GlobalPosition = GetCollisionPoint();
	}
}
