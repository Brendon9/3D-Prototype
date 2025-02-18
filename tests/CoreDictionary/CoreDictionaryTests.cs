using Chickensoft.GoDotTest;
using Godot;
using Shouldly;

public class CoreDictionaryTests : TestClass
{
  const int key = 1;
  const int value = 3;
  public CoreDictionaryTests(Node testScene) : base(testScene) { }

  [Test]
  public void Add_And_Remove_Success()
  {
    CoreDictionary<int, int> sut = new CoreDictionary<int, int>
    {
        { key, value }
    };
    sut.Count.ShouldBeEquivalentTo(1);
    sut[key].ShouldBeEquivalentTo(value);

    sut.Remove(key);
    sut.ShouldBeEmpty();
  }

  // const string json = "{\"keys\":[1],\"values\":[3]}";
  // [Test]
  // public void JsonUtility_Serialization_Success()
  // {
  //   CoreDictionary<int, int> sut = new CoreDictionary<int, int>();
  //   sut.Add(key, value);
  //   var result = JsonUtility.ToJson(sut);
  //   result.ShouldBeEquivalentTo(json);
  // }

  // [Test]
  // public void JsonUtility_Deserialization_Success()
  // {
  //   CoreDictionary<int, int> sut = new CoreDictionary<int, int>();
  //   JsonUtility.FromJsonOverwrite(json, sut);
  //   sut.Count.ShouldBeEquivalentTo(1);
  //   sut[key].ShouldBeEquivalentTo(value);
  // }
}