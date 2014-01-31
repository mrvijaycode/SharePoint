using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace ConnectWP.StringProvider
{
    [ToolboxItemAttribute(false)]
    public class StringProvider : WebPart,ItxtboxString
    {
        private TextBox myTextBox;
        private String _textBoxString = String.Empty;
        private Button myButton;

        protected override void CreateChildControls()
        {
        }

        public string TextBoxString
        {
            get
            {
                return _textBoxString;
            }
            set
            {
                _textBoxString = value;
            }
        }
    }
}
