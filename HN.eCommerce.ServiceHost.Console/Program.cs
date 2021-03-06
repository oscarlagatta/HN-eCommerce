﻿using System.Transactions;
using System;
using HN.eCommerce.Business.Bootstrapper;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.Managers.Managers;
using Core.Common.Core;
using SM = System.ServiceModel;

namespace HN.eCommerce.ServiceHost.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            ObjectBase.Container = MEFLoader.Init();

            System.Console.WriteLine("Starting up services");
            System.Console.WriteLine("");


            SM.ServiceHost hostStyleManger = new SM.ServiceHost(typeof(StyleManager));

            SM.ServiceHost hostProductManger = new SM.ServiceHost(typeof(ProductManager));

          

            /* More services to call  */
            StartService(hostStyleManger, "StyleManger Host");
            StartService(hostProductManger, "ProductManager Host");
         
            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            System.Console.WriteLine("eCommerce Monitor has started.");

            System.Console.WriteLine("");
            System.Console.WriteLine("Press [Enter] to exit.");
            System.Console.ReadLine();

            timer.Stop();
            System.Console.WriteLine("eCommerce Monitor stopped.");

            StopService(hostStyleManger, "AccountManager Host");
            StopService(hostProductManger, "AccountManager Host");
        

        }

        private static void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            System.Console.WriteLine("Looking for Products at {0} ", DateTime.Now.ToString());

            ProductManager productManager = new ProductManager();

            var products = productManager.GetAllProducts();

            if (products != null)
            {
                foreach (var product in products)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            //productManager.DeleteProduct(product.ProductId);
                            System.Console.WriteLine("Deleting Product '{0}'.", product.Name);
                            scope.Complete();
                        }
                        catch (Exception)
                        {
                            System.Console.WriteLine("There was an excpetion when attempting to delete product {0}", product.ProductId);
                        }

                    }
                }
            }
        }

        private static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();

            System.Console.WriteLine("Service {0} started.", serviceDescription);


            foreach (var endpoint in host.Description.Endpoints)
            {
                System.Console.WriteLine(string.Format("Listening on endpoint:"));
                System.Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                System.Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                System.Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            System.Console.WriteLine();
        }

        private static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            System.Console.WriteLine("Service {0} stopped.", serviceDescription);
        }
    }
}
