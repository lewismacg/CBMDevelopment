using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Domain.Email.Services
{
	public class SendGridEmailService : ISendGridEmailService
	{
		#region Properties and Fields

		private readonly IEmailConfiguration _emailConfiguration;

		#endregion

		#region Constructor

		public SendGridEmailService(IEmailConfiguration emailConfiguration)
		{
			_emailConfiguration = emailConfiguration;
		}

		#endregion

		#region SendMail

		/// <summary>
		/// 
		/// </summary>
		/// <param name="senderEmailAddress"></param>
		/// <param name="senderName"></param>
		/// <param name="senderPhoneNumber"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public void SendMail(string senderEmailAddress, string senderName, string senderPhoneNumber, string message)
		{
			var email = CreateEmail(senderEmailAddress, senderName, senderPhoneNumber, message);

			var ionosProxy = new WebProxy("http://winproxy.server.lan:3128", true);

			var client = new SendGridClient(ionosProxy, _emailConfiguration.SendgridApiKey);
			var emailSendTask = Task.Run(() => client.SendEmailAsync(email));
			emailSendTask.Wait();
		}

		private SendGridMessage CreateEmail(string senderEmailAddress, string senderName, string senderPhoneNumber, string messageText)
		{
			var from = new EmailAddress(_emailConfiguration.SenderEmailAddress, "CBM Mailer");
			var subject = $"CBM Developments: Email received from {senderName}";
			var to = new EmailAddress(_emailConfiguration.RecipientEmailAddress, "CBM Developments");
			var message = string.IsNullOrWhiteSpace(senderPhoneNumber) ? $"Message: {messageText}. Email {senderEmailAddress}"
																	   : $"Message: {messageText}. Email {senderEmailAddress}. Phone number: {senderPhoneNumber}";

			return MailHelper.CreateSingleEmail(from, to, subject, message, "");
		}

		#endregion

	}
}
