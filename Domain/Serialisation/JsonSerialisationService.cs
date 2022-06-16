using Newtonsoft.Json;

namespace Domain.Serialisation
{
	public class JsonSerialisationService : IJsonSerialisationService
	{

		#region SerializeObject

		public virtual string SerializeObject(object toSerialize)
		{
			return JsonConvert.SerializeObject(toSerialize);
		}

		#endregion

		#region DeserializeObject

		public virtual T DeserializeObject<T>(string toDeserialize)
		{
			return JsonConvert.DeserializeObject<T>(toDeserialize);
		}

		#endregion
	}
}
