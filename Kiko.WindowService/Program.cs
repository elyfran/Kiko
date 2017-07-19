using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Kiko.WindowService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig => {
                serviceConfig.Service<ListenerService>(serviceInstance => {
                    serviceInstance.ConstructUsing(() => new ListenerService());
                    serviceInstance.WhenStarted(execute => execute.Start());
                    serviceInstance.WhenStopped(execute => execute.Stop());

                });
                serviceConfig.SetServiceName("ListenerService");
                serviceConfig.SetDisplayName("ListenerService");
                serviceConfig.SetDescription("That Service Start Socket Listener for getting upcoming requste on port ....");
                serviceConfig.StartAutomatically();
            });
        }
    }
}
