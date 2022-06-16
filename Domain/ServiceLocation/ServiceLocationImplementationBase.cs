using CommonServiceLocator;
using System;
using System.Collections.Generic;

namespace Domain.ServiceLocation
{
	public abstract class ServiceLocationImplementationBase : IServiceLocator, IServiceProvider
	{
		public virtual object GetService(Type serviceType)
		{
			return this.GetInstance(serviceType, (string)null);
		}

		public virtual object GetInstance(Type serviceType)
		{
			return this.GetInstance(serviceType, (string)null);
		}

		public virtual object GetInstance(Type serviceType, string key)
		{
			try
			{
				return this.DoGetInstance(serviceType, key);
			}
			catch (Exception ex)
			{
				throw new ActivationException(this.FormatActivationExceptionMessage(ex, serviceType, key), ex);
			}
		}

		public virtual IEnumerable<object> GetAllInstances(Type serviceType)
		{
			try
			{
				return this.DoGetAllInstances(serviceType);
			}
			catch (Exception ex)
			{
				throw new ActivationException(this.FormatActivateAllExceptionMessage(ex, serviceType), ex);
			}
		}

		public virtual TService GetInstance<TService>()
		{
			return (TService)this.GetInstance(typeof(TService), (string)null);
		}

		public virtual TService GetInstance<TService>(string key)
		{
			return (TService)this.GetInstance(typeof(TService), key);
		}

		public virtual IEnumerable<TService> GetAllInstances<TService>()
		{
			foreach (TService allInstance in this.GetAllInstances(typeof(TService)))
				yield return allInstance;
		}

		protected abstract object DoGetInstance(Type serviceType, string key);

		protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);

		protected virtual string FormatActivationExceptionMessage(
			Exception actualException,
			Type serviceType,
			string key)
		{
			return "Activation error occurred while trying to get instance of type " + serviceType.Name + ", key \"" + key + "\"";
		}

		protected virtual string FormatActivateAllExceptionMessage(
			Exception actualException,
			Type serviceType)
		{
			return "Activation error occurred while trying to get all instances of type " + serviceType.Name;
		}
	}
}
