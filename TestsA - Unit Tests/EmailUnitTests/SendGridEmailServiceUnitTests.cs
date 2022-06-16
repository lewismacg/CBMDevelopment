using Domain;
using Domain.Email.Services;
using Moq;
using NUnit.Framework;
using Tests.Shared.TestBase.Unit;

namespace Tests.Unit.EmailUnitTests
{
	[TestFixture]
	public class SendGridEmailServiceUnitTests : AbstractUnitTestBase
	{
		private Mock<SendGridEmailService> _instance;
		private Mock<IEmailConfiguration> _emailConfiguration;

		[SetUp]
		protected override void Setup()
		{
			base.Setup();

			_emailConfiguration = MoqHelpers.GenerateStrictMock<IEmailConfiguration>();

			_emailConfiguration.Setup(x => x.SendgridApiKey).Returns("fakeapikey");
			_emailConfiguration.Setup(x => x.RecipientEmailAddress).Returns("test@email.com");

			_instance = MoqHelpers.GeneratePartialMock<SendGridEmailService>(_emailConfiguration.Object);
		}

		#region SendMail

		[Test]
		public void SendMail()
		{
			//arrange
			const string senderEmailAddress = "hello@email.com";
			const string senderName = "cbm";
			const string senderPhoneNumber = "0123456789";
			const string message = "hello there!";

			//act
			_instance.Object.SendMail(senderEmailAddress, senderName, senderPhoneNumber, message);

			//assert
			// no errors
		}

		#endregion
	}
}
