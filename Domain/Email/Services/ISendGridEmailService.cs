namespace Domain.Email.Services
{
	public interface ISendGridEmailService
	{
		void SendMail(string senderEmailAddress, string senderName, string senderPhoneNumber, string message);
	}
}
