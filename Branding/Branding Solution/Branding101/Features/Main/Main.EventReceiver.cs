using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace Branding101.Features.Main {

  [Guid("990ff443-6288-4f6e-b22d-298c0881317d")]
  public class MainEventReceiver : SPFeatureReceiver {

    public override void FeatureActivated(SPFeatureReceiverProperties properties) {

      SPSite siteCollection = properties.Feature.Parent as SPSite;
      if (siteCollection != null) {
        SPWeb topLevelSite = siteCollection.RootWeb;

        // calculate relative path of site from Web Application root
        string WebAppRelativePath = topLevelSite.ServerRelativeUrl;
        if (!WebAppRelativePath.EndsWith(@"/")) {
          WebAppRelativePath += @"/";
        }

        foreach (SPWeb site in siteCollection.AllWebs) {
          site.MasterUrl = WebAppRelativePath + "_catalogs/masterpage/Branding101.master";
          site.CustomMasterUrl = WebAppRelativePath + "_catalogs/masterpage/Branding101.master";
          site.AlternateCssUrl = WebAppRelativePath + "Style%20Library/Branding101/Styles.css";
          site.SiteLogoUrl = WebAppRelativePath + "Style%20Library/Branding101/Images/Logo.gif";
          site.UIVersion = 4;
          site.UIVersionConfigurationEnabled = false;
          site.Update();
        }

      }
    }

    public override void FeatureDeactivating(SPFeatureReceiverProperties properties) {
      SPSite siteCollection = properties.Feature.Parent as SPSite;
      if (siteCollection != null) {
        SPWeb topLevelSite = siteCollection.RootWeb;

        // calculate relative path of site from Web Application root
        string WebAppRelativePath = topLevelSite.ServerRelativeUrl;
        if (!WebAppRelativePath.EndsWith(@"/")) {
          WebAppRelativePath += @"/";
        }

        foreach (SPWeb site in siteCollection.AllWebs) {
          site.MasterUrl = WebAppRelativePath + "_catalogs/masterpage/v4.master";
          site.CustomMasterUrl = WebAppRelativePath + "_catalogs/masterpage/v4.master";
          site.AlternateCssUrl = "";
          site.SiteLogoUrl = "";
          site.UIVersion = 4;
          site.Update();
        }
      }
    }
  }
}
