using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Recaptcha.Entities
{
	public class RecaptchaVerifyResponseModel
	{
		[JsonProperty(PropertyName = "success")]
		public virtual bool Success { get; set; }

		[JsonProperty(PropertyName = "challenge_ts")]
		public virtual DateTime ChallengeTime { get; set; }

		[JsonProperty(PropertyName = "hostname")]
		public virtual string Hostname { get; set; }

		[JsonProperty(PropertyName = "error-codes")]
		public virtual List<string> Errors { get; set; } = new List<string>();
	}
}
