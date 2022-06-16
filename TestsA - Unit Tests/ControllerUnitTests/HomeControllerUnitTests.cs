using CbmDevelopments.MVC.Controllers;
using CbmDevelopments.MVC.Models;
using Domain.Email.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Tests.Shared.TestBase.Unit;
using Tests.Shared.TestBase.Unit.ExtensionMethods;

namespace Tests.Unit.ControllerUnitTests
{
	[TestFixture]
	public class HomeControllerUnitTests : AbstractUnitTestBase
	{
		private Mock<HomeController> _instance;
		private Mock<ISendGridEmailService> _emailService;

		[SetUp]
		protected override void Setup()
		{
			base.Setup();

			_emailService = MoqHelpers.GenerateStrictMock<ISendGridEmailService>();
			_instance = MoqHelpers.GeneratePartialMock<HomeController>(_emailService.Object);
		}

		#region Index

		[Test]
		public void Index_GET()
		{
			//act
			var actionResult = _instance.Object.Index();

			//assert
			actionResult.AssertViewRendered();
		}

		[Test]
		public void Index_POST_WHERE_model_state_is_not_valid_SHOULD_return_view()
		{
			//arrange
			var model = MoqHelpers.GenerateStrictMock<ContactUsModel>();

			_instance.Object.ModelState.AddModelError("Key", "Error");

			//act
			var actionResult = _instance.Object.Index(model.Object);

			//assert
			actionResult.AssertViewRendered().WithViewData<ContactUsModel>().ShouldBe(model.Object);
		}

		[Test]
		public void Index_POST()
		{
			//arrange
			var model = MoqHelpers.GenerateStrictMock<ContactUsModel>();

			const string email = "e@mail.com";
			model.Setup(x => x.Email).Returns(email);

			const string name = "cbm";
			model.Setup(x => x.Name).Returns(name);

			const string phoneNumber = "0123456789";
			model.Setup(x => x.PhoneNumber).Returns(phoneNumber);

			const string message = "hello there";
			model.Setup(x => x.Message).Returns(message);

			_emailService.Setup(x => x.SendMail(email, name, phoneNumber, message)).Verifiable();

			var expected = MoqHelpers.GenerateStrictMock<RedirectToActionResult>(nameof(HomeController.Thanks), "Home", null);
			_instance.Setup(x => x.RedirectToAction("Thanks", "Home")).Returns(expected.Object);

			//act
			var actionResult = _instance.Object.Index(model.Object);

			//assert
			_emailService.VerifyAll();
			Assert.That(actionResult, Is.EqualTo(expected.Object));
		}

		#endregion

		#region Thanks

		[Test]
		public void Thanks()
		{
			//act
			var actionResult = _instance.Object.Thanks();

			//assert
			actionResult.AssertViewRendered();
		}

		#endregion

		#region Previous Work

		[Test]
		public void PreviousWork()
		{
			//act
			var actionResult = _instance.Object.PreviousWork();

			//assert
			actionResult.AssertViewRendered();
		}

		#endregion

		#region Investments

		[Test]
		public void Investments()
		{
			//act
			var actionResult = _instance.Object.Investments();

			//assert
			actionResult.AssertViewRendered();
		}

		#endregion

		#region Contact Us

		[Test]
		public void ContactUs_GET()
		{
			//act
			var actionResult = _instance.Object.ContactUs();

			//assert
			actionResult.AssertViewRendered().WithViewData<ContactUsModel>();
		}

		[Test]
		public void ContactUs_POST_WHERE_model_state_is_not_valid_SHOULD_return_view()
		{
			//arrange
			var model = MoqHelpers.GenerateStrictMock<ContactUsModel>();

			_instance.Object.ModelState.AddModelError("Key", "Error");

			//act
			var actionResult = _instance.Object.ContactUs(model.Object);

			//assert
			actionResult.AssertViewRendered().WithViewData<ContactUsModel>().ShouldBe(model.Object);
		}

		[Test]
		public void ContactUs_POST()
		{
			//arrange
			var model = MoqHelpers.GenerateStrictMock<ContactUsModel>();

			const string email = "e@mail.com";
			model.Setup(x => x.Email).Returns(email);

			const string name = "cbm";
			model.Setup(x => x.Name).Returns(name);

			const string phoneNumber = "0123456789";
			model.Setup(x => x.PhoneNumber).Returns(phoneNumber);

			const string message = "hello there";
			model.Setup(x => x.Message).Returns(message);

			_emailService.Setup(x => x.SendMail(email, name, phoneNumber, message)).Verifiable();

			var expected = MoqHelpers.GenerateStrictMock<RedirectToActionResult>(nameof(HomeController.Thanks), "Home", null);
			_instance.Setup(x => x.RedirectToAction("Thanks", "Home")).Returns(expected.Object);

			//act
			var actionResult = _instance.Object.ContactUs(model.Object);

			//assert
			_emailService.VerifyAll();
			Assert.That(actionResult, Is.EqualTo(expected.Object));
		}

		#endregion

	}
}
