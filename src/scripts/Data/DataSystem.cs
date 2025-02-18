namespace Prototype;

public interface IDataSystem : IDependency<IDataSystem>
{
	Data Data { get; }

	void Create();
	void Delete();
	bool HasFile();
	void Save();
	void Load();
}