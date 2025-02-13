
using Chickensoft.GoDotTest;
using Godot;

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
    // Assert.AreEqual(18, sut.Roll(diceRoll));
    sut.Roll(diceRoll).Equals(18);
  }
}