﻿namespace Domain.Recaptcha
{
	public class RecaptchaConfiguration : IRecaptchaConfiguration
	{
		public string SiteKey { get; set; }
		public string SecretKey { get; set; }
	}
}
