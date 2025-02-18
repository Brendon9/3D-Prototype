using System.Collections;
using System.Collections.Generic;
using Godot;

namespace Prototype;

public interface IDataSerializer : IDependency<IDataSerializer>
{
	string Serialize(Data data);
	Data Deserialize(string json);
}

public class DataSerializer : IDataSerializer
{
	public Data Deserialize(string json)
	{
		throw new System.NotImplementedException();
	}

	public string Serialize(Data data)
	{
		throw new System.NotImplementedException();
	}
}