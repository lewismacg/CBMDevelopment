using Domain.Recaptcha.Entities;
using Domain.Serialisation;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Recaptcha.Services
{
	public class RecaptchaService : IRecaptchaService
	{
		private readonly IRecaptchaConfiguration _reCaptchaConfiguration;
		private readonly HttpClient _httpClient;
		private readonly IJsonSerialisationService _jsonSerialisationService;

		public RecaptchaService(IRecaptchaConfiguration reCaptchaConfiguration, HttpClient httpClient, IJsonSerialisationService jsonSerialisationService)
		{
			_jsonSerialisationService = jsonSerialisationService;
			_httpClient = httpClient;
			_reCaptchaConfiguration = reCaptchaConfiguration;
		}

		#region IsReCaptchaValidAsync

		public async Task<IsRecaptchaValidResponseEnum> IsReCaptchaValidAsync(string responseToken)
		{
			var content = await PostToVerifyAsync(_reCaptchaConfiguration.SecretKey, responseToken);

			var reCaptchaVerifyResponseModel = _jsonSerialisationService.DeserializeObject<RecaptchaVerifyResponseModel>(content);

			return reCaptchaVerifyResponseModel.Success ? IsRecaptchaValidResponseEnum.UserIsHuman : IsRecaptchaValidResponseEnum.VerificationFailed;
		}

		#region PostToVerifyAsync

		protected internal virtual async Task<string> PostToVerifyAsync(string secret, string responseToken)
		{
			var formUrlEncodedContent = new FormUrlEncodedContent(new Dictionary<string, string> { { "secret", secret }, { "response", responseToken } });
			var response = await _httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", formUrlEncodedContent);
			return await response.Content.ReadAsStringAsync();
		}

		#endregion

		#endregion
	}
}
