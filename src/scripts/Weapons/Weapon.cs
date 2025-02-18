using Godot;
using System;
using System.Collections.Generic;

namespace Prototype;

public abstract partial class Weapon : CharacterBody3D
{
	public Dictionary<string, string> BasicAttacks = new Dictionary<string, string>();
}
