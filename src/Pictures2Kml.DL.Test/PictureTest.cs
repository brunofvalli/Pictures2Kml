using Microsoft.Extensions.DependencyInjection;
using Pictures2Kml.DL.Interfaces;

using NUnit.Framework;

namespace Pictures2Kml.DL.Test
{
    public class Tests
    {
        ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();
            DependencyInjectionDL.AddSingleton(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public void Test1()
        {
            // Resolve and use the service
            var myService = _serviceProvider.GetRequiredService<IPicture>();
            var location = myService.GetGeoLocationFromImage(@".\Picture\TestPicture.JPG");

            Assert.
        }
    }
}