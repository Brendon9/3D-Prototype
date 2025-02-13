using Godot;

namespace Prototype;

public class DiceRollSystem
{
		public int Roll(DiceRoll diceRoll)
		{
			
				int result = diceRoll.bonus;
				for (int i = 0; i < diceRoll.count; i++)
						result += GD.RandRange(1, diceRoll.sides + 1);
				return result;
		}
}
