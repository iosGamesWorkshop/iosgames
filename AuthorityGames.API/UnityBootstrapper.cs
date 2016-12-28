using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Nancy.Bootstrappers.Unity;

namespace AuthorityGames.API
{
    public class UnityBootstrapper : UnityNancyBootstrapper
    {
		#region FIELDS
		IUnityContainer _container;
		#endregion

		#region CONSTRUCTORS
		public UnityBootstrapper(IUnityContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			_container = container;
		}
		#endregion

		#region METHODS
		protected override IUnityContainer GetApplicationContainer()
		{
			return _container;
		}
		#endregion
	}
}
