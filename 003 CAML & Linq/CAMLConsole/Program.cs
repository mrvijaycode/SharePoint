using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.SharePoint;

namespace CAMLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite mysite = new SPSite(@"http://sp2010:8888");
            SPWeb myweb = mysite.OpenWeb();

            SPList mylist = myweb.Lists["Subra"];

           // SPQuery qry = new SPQuery();
           // qry.Query = "<Where><Or><Contains><FieldRef Name='Email' /><Value Type='Text'>yahoo</Value></Contains><Eq><FieldRef Name='Class' /><Value Type='Choice'>Class C</Value></Eq></Or></Where>";

           // SPListItemCollection itms = mylist.GetItems(qry);

            var itms = from SPListItem itm in mylist.Items
                      where Convert.ToInt32(itm["Marks"].ToString()) > 45
                       orderby itm["Title"]
                      select itm;

            foreach (SPListItem itm in itms)
            {
                Console.WriteLine("Name:{0}\nEmail:{1}\nMarks:{2}\nclass:{3}\nregion:{4}\n\n ", itm.Title, itm["Email"].ToString(), itm["Marks"].ToString(), itm["Class"].ToString(), itm["region"].ToString());
            }
            Console.ReadLine();
        }
    }
}
