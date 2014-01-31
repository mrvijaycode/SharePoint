
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext ctx = new ClientContext(@"http://sp2010");
            Web myweb = ctx.Web;

            List list = ctx.Web.Lists.GetByTitle("Students");

            /*
            CamlQuery query = new CamlQuery();
            query.ViewXml = "<View/>";
            ListItemCollection items = list.GetItems(query);
            */

//            ListItemCreationInformation newItem = new ListItemCreationInformation();
  //          ListItem listItem = list.AddItem(newItem);

            ListItem oListItem = list.GetItemById(5);
            //oListItem["Title"] = "My Updated Item.";
            oListItem.DeleteObject();
                        
            ctx.Load(list);
           //s ctx.Load(oListItem);

            ctx.ExecuteQuery();

            //foreach (ListItem itm in items)
            //  Console.WriteLine(itm["Title"].ToString());

            Console.WriteLine("Ok");
            Console.ReadLine();
        }
    }
}
