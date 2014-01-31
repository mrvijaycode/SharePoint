using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
namespace SPEx
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite(@"http://hydpcnew00123:44393");

            foreach (SPWeb web in site.AllWebs)
            {
                Console.WriteLine("{0} is created on {1}",web.Title,web.Created);
            }
            Console.Read();
        }
    }
}
