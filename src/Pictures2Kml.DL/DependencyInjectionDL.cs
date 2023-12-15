using Microsoft.Extensions.DependencyInjection;
using Pictures2Kml.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures2Kml.DL
{
    public static class DependencyInjectionDL
    {
        public static void AddSingleton(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPicture, Picture>();
        }
    }
}
