using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace CrreateFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite mysite = new SPSite(@"http://hydpcnew00123:44393");
            SPWeb myweb = mysite.OpenWeb();
            SPList mylist = myweb.Lists.TryGetList("Mydocs");
            SPListItem foldercoll = mylist.Items.Add(mylist.RootFolder.ServerRelativeUrl, SPFileSystemObjectType.Folder,"Mycodefolder");
            //foldercoll["Title"] = "myfolder";
            foldercoll.Update();
            mylist.Update();
            Console.WriteLine("Sucess");
            Console.ReadLine();
        }
    }
}
