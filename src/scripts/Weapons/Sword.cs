using Godot;
using System;

namespace Prototype;

public partial class Sword : Weapon
{
	public override void _Ready()
	{
		BasicAttacks.Add("light_attack_pressed", "slash_1");
	}
}
