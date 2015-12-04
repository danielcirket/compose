﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Compose.Tests
{
    public class TertiaryProviderTransitionTests
    {
		[Fact]
		public void WhenApplicationTransitionedThenResolvesTertiaryService()
		{
			var application = new Application();
			application.UseServices(services => services.AddTransient<Fake.Service, Fake.Implementation>());
			var provider = application.UseProvider<Fake.Service>(services => services.AddTransient<Fake.Service, Fake.AlternativeImplementation>());

			application.Transition(provider);

			application.ApplicationServices.GetRequiredService<Fake.Service>()
				.Should().BeOfType<Fake.AlternativeImplementation>();
		}
    }
}