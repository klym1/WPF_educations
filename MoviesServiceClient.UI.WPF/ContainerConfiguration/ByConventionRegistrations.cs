using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    internal sealed class ByConventionRegistrations
    {
        public IUnityContainer AddRegistrations(IUnityContainer container)
        {
            foreach (var registrations in GetContainerRegistrationsInCurrentAssembly())
            {
                container = container.AddRegistrations(registrations.AddRegistrations);
            }
            return container;
        }

        private static IEnumerable<IContainerRegistrations> GetContainerRegistrationsInCurrentAssembly()
        {
            var registrationsConventionInterface = typeof(IContainerRegistrations);
            var result =
                from type in Assembly.GetExecutingAssembly().GetTypes()
                where registrationsConventionInterface.IsAssignableFrom(type)
                where type.IsClass && !type.IsAbstract
                select (IContainerRegistrations)Activator.CreateInstance(type);
            return result;
        }
    }
}
