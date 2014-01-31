using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EventHandler.StopDeletion.StopItemDelete
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class StopItemDelete : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            base.ItemDeleting(properties);

            if (properties.ListTitle == "Students")
            {
                SPListItem listItem = properties.ListItem;
                SPFieldBoolean boolField = listItem.Fields["Status"] as SPFieldBoolean;

                bool CheckBoxValue = (bool)boolField.GetFieldValue(listItem["Status"].ToString());

                if (CheckBoxValue.ToString() == "True")
                {
                    properties.Status = SPEventReceiverStatus.CancelWithError;
                    properties.ErrorMessage = "This item can't be deleted. Restricted by the Event Handler & status--" + CheckBoxValue.ToString();
                    properties.Cancel = true;
                }
            }
        }

        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            updateConformDate(properties);
        }

        protected void updateConformDate(SPItemEventProperties properties)
        {
            try
            {
                properties.Web.AllowUnsafeUpdates = true;
                //               DisableEventFiring();

                SPListItem listItem = properties.ListItem;
                string strDateJoin = listItem["Date of joining"].ToString();
                DateTime dojDate = Convert.ToDateTime(strDateJoin);
                //DateTime cnfDate = dojDate.AddMonths(6);

                listItem["Date of Conformation"] = dojDate.AddMonths(6);
                //listItem["StudentName"]="Changed";
                //properties.ListItem.SystemUpdate();
                listItem.SystemUpdate();
                //  listItem.Update();

                properties.Status = SPEventReceiverStatus.CancelWithError;
                properties.ErrorMessage = "Item Updated..";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                properties.Web.AllowUnsafeUpdates = false;
            }
        }


        public override void ItemUpdating(SPItemEventProperties properties)
        {
            base.ItemUpdating(properties);
        }

        /// <summary>
        /// An item was updated
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            updateConformDate(properties);
        }
    }
}
