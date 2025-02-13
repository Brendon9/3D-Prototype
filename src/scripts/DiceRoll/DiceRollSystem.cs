using Godot;

namespace Prototype;

public interface IDiceRollSystem : IDependency<IDiceRollSystem>
{
	int Roll(DiceRoll diceRoll);
}

public class DiceRollSystem : IDiceRollSystem
{
	public int Roll(DiceRoll diceRoll)
	{

		int result = diceRoll.bonus;
		for (int i = 0; i < diceRoll.count; i++)
			result += IRandomNumberGenerator.Resolve().Range(1, diceRoll.sides);
		return result;
	}
}

public partial struct DiceRoll
{
	public int Roll()
	{
		return IDiceRollSystem.Resolve().Roll(this);
	}
}
