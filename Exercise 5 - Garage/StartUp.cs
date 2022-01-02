using Exercise_5___Garage.Vehicles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage
{
    public class StartUp
    {
        public void SetUp()
        {

            //configuration = GetConfig();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<Manager>().Run();

        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Manager>();
            serviceCollection.AddSingleton<IUI, UI>();
            serviceCollection.AddSingleton<IGarageHandler, GarageHandler>();
            serviceCollection.AddSingleton<IGarage<Vehicle>, Garage<Vehicle>>();

        }
    }
}
