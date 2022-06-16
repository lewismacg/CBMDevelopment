using Castle.Windsor;
using CommonServiceLocator;
using Domain.ServiceLocation;
using NUnit.Framework;

namespace Tests.Shared.TestBase.Unit
{
	public class AbstractUnitTestBase
	{
		public virtual IWindsorContainer WindsorContainer { get; set; }

		protected virtual CbmDateTimeComparer QuizDateTimeComparer
		{
			get
			{
				return new CbmDateTimeComparer()
				{
					Delta = new CbmDateTimeComparer.AcceptableDelta?(CbmDateTimeComparer.AcceptableDelta.Second)
				};
			}
		}

		[SetUp]
		protected virtual void Setup()
		{
			this.InitializeWindsorContainer();
		}
		protected virtual void InitializeWindsorContainer()
		{
			this.WindsorContainer = (IWindsorContainer)new Castle.Windsor.WindsorContainer();
			ServiceLocator.SetLocatorProvider((ServiceLocatorProvider)(() => (IServiceLocator)new CbmServiceLocator(this.WindsorContainer)));
		}
	}
}
