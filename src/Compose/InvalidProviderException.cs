using System;

namespace Compose
{
    public class InvalidProviderException : Exception
    {
		public InvalidProviderException(Type serviceType, Exception inner)
			: base($"Provider for {serviceType.Name} was unable to resolve a {serviceType.Name}", inner)
		{ }
    }
}
