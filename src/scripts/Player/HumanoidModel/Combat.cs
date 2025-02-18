using Godot;
using System.Collections.Generic;

namespace Prototype;

public partial class Combat : Node
{
	[Export] Model Model;
	public static Dictionary<string, int> InputPriority = new Dictionary<string, int>();

	public override void _Ready()
	{
		InputPriority.Add("light_attack_pressed", 1);
		InputPriority.Add("heavy_attack_pressed", 2);
	}

	public InputPackage TranslateCombatActions(InputPackage newInput)
	{
		if (newInput.combatActions.Count != 0)
		{
			newInput.combatActions.Sort(new PrioritySort());
			string bestInputAction = newInput.combatActions[0];
			string translatedIntoMoveName = Model.ActiveWeapon.BasicAttacks[bestInputAction];
			newInput.actions.Add(translatedIntoMoveName);
		}
		return newInput;
	}

	public class PrioritySort : IComparer<string>
	{

		public int Compare(string x, string y)
		{
			if (InputPriority[x] == InputPriority[y])
			{
				return 0;
			}
			if (InputPriority[x] < InputPriority[y])
			{
				return 1;
			}

			return -1;
		}
	}
}
