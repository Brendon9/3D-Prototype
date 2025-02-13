using Godot;

public interface IRandomNumberGenerator : IDependency<IRandomNumberGenerator>
{
  public int Range(int minInclusive, int maxExclusive);
}

public struct RandomNumberGenerator : IRandomNumberGenerator
{
  public int Range(int minInclusive, int maxExclusive)
  {
    return GD.RandRange(minInclusive, maxExclusive);
  }
}