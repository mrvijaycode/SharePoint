using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace Branding101.ChildSiteInit {

  public class ChildSiteInit : SPWebEventReceiver {
    public override void WebProvisioned(SPWebEventProperties properties) {
      SPWeb childSite = properties.Web;
      SPWeb topSite = childSite.Site.RootWeb;
      childSite.MasterUrl = topSite.MasterUrl;
      childSite.CustomMasterUrl = topSite.CustomMasterUrl;
      childSite.AlternateCssUrl = topSite.AlternateCssUrl;
      childSite.SiteLogoUrl = topSite.SiteLogoUrl;
      childSite.Update();
    }


  }
}
