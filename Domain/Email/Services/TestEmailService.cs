using Microsoft.Extensions.Hosting;
using SendGrid.Helpers.Mail;
using System;

namespace Domain.Email.Services
{
	public class TestEmailService : ISendGridEmailService
	{
		#region Properties and Fields

		private readonly IHostingEnvironment _webEnvironment;
		private readonly IEmailConfiguration _emailConfiguration;

		#endregion

		#region Constructor

		public TestEmailService(IHostingEnvironment webEnvironment, IEmailConfiguration emailConfiguration)
		{
			if (webEnvironment.IsProduction()) throw new Exception("Do not use the test email service in production.");

			_webEnvironment = webEnvironment;
			_emailConfiguration = emailConfiguration;
		}

		#endregion

		#region SendMail

		public void SendMail(string senderEmailAddress, string senderName, string senderPhoneNumber, string message)
		{
			var email = CreateEmail(senderEmailAddress, senderName, senderPhoneNumber, message);

			var webRootPath = _webEnvironment.ContentRootPath + "\\latestEmailBody.txt";
			using (var writer = System.IO.File.CreateText(webRootPath))
			{
				writer.Write(email.PlainTextContent);
			}
		}

		private SendGridMessage CreateEmail(string senderEmailAddress, string senderName, string senderPhoneNumber, string messageText)
		{
			var from = new EmailAddress(senderEmailAddress, senderName);
			var subject = $"CBM Developments: Email received from {senderName}";
			var to = new EmailAddress(_emailConfiguration.RecipientEmailAddress, "CBM Developments");
			var message = string.IsNullOrWhiteSpace(senderPhoneNumber) ? $"Message: {messageText}"
																	   : $"Message: {messageText}. Phone number: {senderPhoneNumber}";

			return MailHelper.CreateSingleEmail(from, to, subject, message, "");
		}

		#endregion

	}
}
