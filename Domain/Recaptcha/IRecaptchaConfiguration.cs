namespace Domain.Recaptcha
{
	public interface IRecaptchaConfiguration
	{
		string SiteKey { get; set; }
		string SecretKey { get; set; }
	}
}
