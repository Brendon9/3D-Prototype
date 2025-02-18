using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using Prototype;

public class EntitySystemTests : TestClass
{
  MockDataSystem mockDataSystem = new MockDataSystem();
  EntitySystem sut = new EntitySystem();

  public EntitySystemTests(Node testScene) : base(testScene) { }

  [Setup]
  public void Setup()
  {
    IDataSystem.Register(mockDataSystem);
    mockDataSystem.Create();
  }

  [Cleanup]
  public void Cleanup()
  {
    IRandomNumberGenerator.Reset();
    IDataSystem.Reset();
  }

  [Test]
  public void Create_Succeeds()
  {
    IRandomNumberGenerator.Register(new MockFixedRNG(1));

    var entity = sut.Create();

    entity.id.ShouldBeEquivalentTo(1);
    mockDataSystem.Data.entities.Contains(entity).ShouldBeTrue();
  }

  [Test]
  public void Create_ZeroId_RollsAgain()
  {
    IRandomNumberGenerator.Register(new MockSequenceRNG(0, 1));

    var entity = sut.Create();

    entity.id.ShouldBeEquivalentTo(1);
  }

  [Test]
  public void Create_DuplicateId_RollsAgain()
  {
    IRandomNumberGenerator.Register(new MockSequenceRNG(1, 2));
    mockDataSystem.Data.entities.Add(new Entity(1));

    var entity = sut.Create();

    entity.id.ShouldBeEquivalentTo(2);
  }

  [Test]
  public void Destroy_Succeeds()
  {
    var entity = new Entity(1);
    mockDataSystem.Data.entities.Add(entity);

    sut.Destroy(entity);

    mockDataSystem.Data.entities.Contains(entity).ShouldBeFalse();
  }
}