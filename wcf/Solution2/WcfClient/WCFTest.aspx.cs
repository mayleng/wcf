using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfClient.WcfService;  //引用WCF服务的名称空间

namespace WcfClient
{
    public partial class WCFTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnClick(object sender, EventArgs e)
        {
            UserClient user = new UserClient();
            string result = user.ShowName(this.txtName.Text);
            Thread.Sleep(100);
            Response.Write(result);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Cols1.aspx");
        }
    }
}