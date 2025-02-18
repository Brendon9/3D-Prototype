using Chickensoft.GoDotTest;
using Godot;
using Shouldly;

namespace Prototype.Tests;

public class CoreSetTests : TestClass
{
  public CoreSetTests(Node testScene) : base(testScene) { }

  [Test]
  public void Add_And_Remove_Success()
  {
    CoreSet<int> sut = [42];

    sut.ShouldContain(42);

    sut.Remove(42);
    sut.ShouldBeEmpty();
  }

  [Test]
  public void Add_Duplicate_IsIgnored()
  {
    CoreSet<int> sut =
    [
        1,
        1, // duplicate
        2,
        3,
    ];
    sut.Count.ShouldBeEquivalentTo(3);
  }

  const string json = "{\"values\":[1]}";
  // [Test]
  // public void JsonUtility_Serialization_Success()
  // {
  //   CoreSet<int> sut = new CoreSet<int>();
  //   sut.Add(1);
  //   var result = Json.Stringify(sut);
  //   result.ShouldBeEquivalentTo(json);
  // }

  // [Test]
  // public void JsonUtility_Deserialization_Success()
  // {
  //   CoreSet<int> sut = new CoreSet<int>();
  //   JsonUtility.FromJsonOverwrite(json, sut);
  //   sut.Count.ShouldBeEquivalentTo(1);
  //   sut.ShouldContain(1);
  // }
}