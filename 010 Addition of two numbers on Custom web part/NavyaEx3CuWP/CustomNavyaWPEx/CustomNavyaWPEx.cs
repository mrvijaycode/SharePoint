using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace NavyaEx3CuWP.CustomNavyaWPEx
{
    [ToolboxItemAttribute(false)]
    public class CustomNavyaWPEx : WebPart
    {
        protected override void OnPreRender(EventArgs e)
        {
            //base.OnPreRender(e);
            this.Title = "Navya cu WebPart";
            this.Description = "Created using the VS2010";
        }

        TextBox txt1, txt2;
        Button btn1;
        Label lbl1;
        protected override void CreateChildControls()
        {
            txt1 = new TextBox();
            txt1.ToolTip = "Enter Text";
            this.Controls.Add(txt1);

            txt2 = new TextBox();
            this.Controls.Add(txt2);

            btn1 = new Button();
            btn1.Text = "Submit";
            btn1.Click += new EventHandler(mycalc);
            this.Controls.Add(btn1);
            
            lbl1 = new Label();
            lbl1.Text = "result";
            this.Controls.Add(lbl1);
        }


        void mycalc(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbl1.Text = (Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt2.Text)).ToString();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            //base.RenderContents(writer);
            writer.Write( "<b>Welcome to the custom web part</b>");

            string myweb = SPContext.Current.Web.CurrentUser.Name;
            writer.Write("My site name is: "+myweb);

            writer.Write("<table>");

            writer.Write("<tr>");
            writer.Write("<td>");
            writer.Write("Calc");
            writer.Write("</td>");
            writer.Write("</tr>");
            
            writer.Write("<tr>");
            writer.Write("<td>");
            txt1.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>");
            txt2.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>");
            btn1.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>");
            lbl1.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("</table>");


        }
    }
}
