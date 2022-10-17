using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TcpBinding.Contracts;

namespace TcpBinding.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string address = "net.tcp://localhost:4345/ProductService";
            uris[0] = new Uri(address);
            IProductService productService = new ProductService();
            ServiceHost host = new ServiceHost(productService,uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IProductService), binding, "");
            host.Opened += HostOnOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOnOpened(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("wcf service is started");
        }
    }


}
