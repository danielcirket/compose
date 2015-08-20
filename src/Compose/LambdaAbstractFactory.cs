using System;

namespace Compose
{
    internal sealed class LambdaAbstractFactory<T> : AbstractFactory<T>
    {
		private readonly Func<object> _lambda;

		public LambdaAbstractFactory(Func<object> lambda)
		{
			_lambda = lambda;
		}

		public object Create()
		{
			return _lambda();
		}
    }
}
