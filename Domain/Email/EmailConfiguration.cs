namespace Domain.Email
{
	public class EmailConfiguration : IEmailConfiguration
	{
		public string RecipientEmailAddress { get; set; }
		public string SenderEmailAddress { get; set; }
		public string SendgridApiKey { get; set; }
	}
}
