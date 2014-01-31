using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace ConnectWP.StringConsumer
{
    [ToolboxItemAttribute(false)]
    public class StringConsumer : WebPart
    {
        private ItxtboxString _myprovider;
        private Label myLabel;

        protected override void OnPreRender(EventArgs e)
        {
            //base.OnPreRender(e);
            EnsureChildControls();
            if (_myprovider != null)
            {
                myLabel.Text = _myprovider.TextBoxString;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            myLabel = new Label();
            myLabel.Text = "Default text";
            Controls.Add(myLabel);
        }

        [ConnectionConsumer("String Consumer", "StringConsumer")]
        public void TextBoxStringConsumer(ItxtboxString Provider)
        {
            _myprovider = Provider;
        }
    }
}
