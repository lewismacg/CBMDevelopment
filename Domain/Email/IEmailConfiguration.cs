namespace Domain
{
	public interface IEmailConfiguration
	{
		string RecipientEmailAddress { get; set; }
		string SenderEmailAddress { get; set; }
		string SendgridApiKey { get; set; }
	}
}
