using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Concrete;

namespace HN.eCommerce.ResourceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"Data Source=.;Initial Catalog=eCommerce;Integrated Security=True;Pooling=False"),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", filePath);         
        }
    }
}
