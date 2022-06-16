using Castle.Windsor;
using System;
using System.Collections.Generic;

namespace Domain.ServiceLocation
{
	public class CbmServiceLocator : ServiceLocationImplementationBase
	{
		public IWindsorContainer Container { get; }

		public CbmServiceLocator(IWindsorContainer container)
		{
			this.Container = container;
		}

		protected override object DoGetInstance(Type serviceType, string key)
		{
			return !string.IsNullOrEmpty(key) ? this.Container.Resolve(key, serviceType) : this.Container.Resolve(serviceType);
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			return (IEnumerable<object>)this.Container.ResolveAll(serviceType);
		}
	}
}
