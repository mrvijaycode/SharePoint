using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace AreaCalc.CalcArea
{
    [ToolboxItemAttribute(false)]
    public class CalcArea : WebPart
    {
        protected override void OnPreRender(EventArgs e)
        {
            //base.OnPreRender(e);
            this.Title = "Vertexcs offshore";
            this.Description = "Created for the sample";
        }

        TextBox txtRadius, txtArea;
        Button btncalcArea;

        protected override void CreateChildControls()
        {
            txtRadius = new TextBox();
            this.Controls.Add(txtRadius);

            txtArea = new TextBox();
            txtArea.ReadOnly = true;
            this.Controls.Add(txtArea);

            btncalcArea = new Button();
            btncalcArea.Text = "Calculator";
            this.Controls.Add(btncalcArea);
            btncalcArea.Click += new EventHandler(btncalcArea_Click);
        }

        void btncalcArea_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            double radius, area;

            radius = Convert.ToDouble(txtRadius.Text);
            area = Math.PI * radius * radius;

            txtArea.Text = area.ToString();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            //base.RenderContents(writer);
            writer.Write("Radius:");
            txtRadius.RenderControl(writer);

            writer.Write("<br>");
            writer.Write("Area:");
            txtArea.RenderControl(writer);

            writer.Write("<br>");

            btncalcArea.RenderControl(writer);
        }
    }
}
