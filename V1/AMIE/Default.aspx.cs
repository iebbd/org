using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AMIE_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DatabaseManager.ExecSQL("update Table_1 set tmp+=1;");
            Response.Redirect("../Page/Default.aspx?contentid=189");
        }
    }
}