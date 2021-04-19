using GradProjectV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GradProjectV5.Ajax_Services
{
    public partial class AppliedpageInMiddle : System.Web.UI.Page
    {
        private MyProjectDBEntities db = new MyProjectDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            var serverTime = DateTime.Now.ToString();
            Response.Write("<time>serverTime</time>");
        var cites=db.Cities.ToList();
        JavaScriptSerializer jser = new JavaScriptSerializer();
        string jsonData=jser.Serialize(cites);
        Response.ContentType = "application/json";
        Response.Write(jsonData);




        }
    }
}