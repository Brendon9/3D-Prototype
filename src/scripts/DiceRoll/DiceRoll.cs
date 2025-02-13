using Godot;
using System;

namespace Prototype;

public partial struct DiceRoll
{
	[Export] public int count;
	[Export] public int sides;
	[Export] public int bonus;

	public static readonly DiceRoll D6 = new DiceRoll(6);
	public static readonly DiceRoll D20 = new DiceRoll(20);

	public DiceRoll(int sides)
	{
		this.count = 1;
		this.sides = sides;
		this.bonus = 0;
	}

	public DiceRoll(int count, int sides)
	{
		this.count = count;
		this.sides = sides;
		this.bonus = 0;
	}

	public DiceRoll(int count, int sides, int bonus)
	{
		this.count = count;
		this.sides = sides;
		this.bonus = bonus;
	}
}