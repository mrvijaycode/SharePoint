using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace SPEx
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite(@"http://hydpcnew00123:44393");
            /*
            foreach (SPWeb web in site.AllWebs)
            {
                Console.WriteLine("{0} is created on {1}",web.Title,web.Created);
            }
            */

            SPWeb myweb = site.OpenWeb();


            SPNavigationNodeCollection topnavbar = myweb.Navigation.TopNavigationBar;
            SPNavigationNode searchEnginesMenu = new SPNavigationNode("Search Engines","");

            
            topnavbar[0].Children.AddAsLast(searchEnginesMenu);

          //  SPNavigationNode msdnNode = new SPNavigationNode("Yahoo", "http://www.yahoo.com", true);


            searchEnginesMenu.Children.AddAsLast(new SPNavigationNode("Yahoo", "http://www.google.com", true));
            
            Console.WriteLine("Success..");
            Console.Read();
        }
    }
}
