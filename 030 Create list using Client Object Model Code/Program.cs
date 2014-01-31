using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;

namespace CAML.VEIEXMLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "http://hydpcnew00123:44393";
            
            ClientContext clientContext = new ClientContext(siteUrl);
            List oList = clientContext.Web.Lists.GetByTitle("SCHOOL");
            
            ListItemCreationInformation listCreationInformation = new ListItemCreationInformation();
            ListItem oListItem = oList.AddItem(listCreationInformation);
            
            oListItem["Title"] = "Client Item";
            oListItem.Update();
            clientContext.ExecuteQuery();

            Console.WriteLine("Success...");
            Console.ReadKey(false);
        }
    }
}
