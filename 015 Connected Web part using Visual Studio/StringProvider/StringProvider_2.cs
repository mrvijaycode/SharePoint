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
            Controls.Clear();
            myTextBox = new TextBox();
            Controls.Add(myTextBox);

            myButton = new Button();
            myButton.Text = "Change Text";
            Controls.Add(myButton);
            myButton.Click += new EventHandler(myButton_Click);
        }

        void myButton_Click(object sender, EventArgs e)
        {
            if (myTextBox.Text != String.Empty)
            {
                TextBoxString = myTextBox.Text;
                myTextBox.Text = String.Empty;
            }
        }

        [Personalizable()]
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

        [ConnectionProvider("Provider for String from Textbox","TextboxStringProvider")]
        public ItxtboxString TextBoxStringProvider()
        {
            return this;
        }
    }
}
