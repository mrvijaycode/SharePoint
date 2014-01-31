using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace AreaClaculator.AreaCalc
{
    [ToolboxItemAttribute(false)]
    public class AreaCalc : WebPart
    {
        protected override void OnPreRender(EventArgs e)
        {
            this.Title = "My Area Calculator";
            this.Description = "Created by Visual Studion";
        }

      /*  protected override void RenderContents(HtmlTextWriter writer)
        {
            //base.RenderContents(writer);
            writer.Write("Welcome to the custom web part");
        }
        */

        TextBox txtradius, txtarea;
        Button btncalcarea;
        protected override void CreateChildControls()
        {
            //base.CreateChildControls();
            
            txtradius = new TextBox();
            this.Controls.Add(txtradius);

            txtarea = new TextBox();
            txtarea.ReadOnly = true;
            this.Controls.Add(txtarea);

            btncalcarea = new Button();
            btncalcarea.Text = "Calculate";
            this.Controls.Add(btncalcarea);

            // to create event type as += 
           // btncalcarea.Click += new EventHandler(btncalcarea_Click);
            btncalcarea.Click += new EventHandler(btncalcarea_Click);
        }
               
        
        void btncalcarea_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            double radius, area;
            radius = Convert.ToDouble(txtradius.Text);
            area = Math.PI * radius * radius;
            txtarea.Text = area.ToString();
        }
        
        
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<table><tr>");
            writer.Write("<th colspan=2>");
            writer.Write("AREA CALCULATOR");
            writer.Write("</th>");

            writer.Write("<tr>");
            writer.Write("<td>");
            writer.Write("Radius:");
            writer.Write("</td>");
            writer.Write("<td>");
            txtradius.RenderControl(writer);
            writer.Write("</td>");

            writer.Write("<tr>");
            writer.Write("<td>");
            writer.Write("Area:");
            writer.Write("</td>");
            writer.Write("<td>");
            txtarea.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>");
            btncalcarea.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr></table>");
        }

        
    }
}
