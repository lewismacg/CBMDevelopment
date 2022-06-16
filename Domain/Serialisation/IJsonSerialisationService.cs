namespace Domain.Serialisation
{
	public interface IJsonSerialisationService
	{
		string SerializeObject(object toSerialize);
		T DeserializeObject<T>(string toDeserialize);
	}
}
