
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;

namespace Prototype.Tests;

public class DiceRollSystemTests : TestClass
{
  public DiceRollSystemTests(Node testScene) : base(testScene) { }

  [Setup]
  public void Setup()
  {
    IRandomNumberGenerator.Register(new MockFixedRNG(7));
  }

  [Cleanup]
  public void Cleanup()
  {
    IRandomNumberGenerator.Reset();
  }

  [Test]
  public void Roll_Passes()
  {
    var sut = new DiceRollSystem();
    var diceRoll = new DiceRoll(2, 10, 4);
    sut.Roll(diceRoll).ShouldBeEquivalentTo(18);
  }
}