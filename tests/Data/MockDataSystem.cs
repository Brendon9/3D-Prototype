using Prototype;

public class MockDataSystem : IDataSystem
{
  public Data Data { get; private set; }

  public void Create()
  {
    Data = new Data();
  }

  public void Delete()
  {
    Data = null;
  }

  public bool HasFile()
  {
    return false;
  }

  public void Load()
  {

  }

  public void Save()
  {

  }
}