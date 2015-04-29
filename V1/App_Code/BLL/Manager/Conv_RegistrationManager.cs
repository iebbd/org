using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class Conv_RegistrationManager
{
	public Conv_RegistrationManager()
	{
	}

    public static List<Conv_Registration> GetAllConv_Registrations()
    {
        List<Conv_Registration> conv_Registrations = new List<Conv_Registration>();
        SqlConv_RegistrationProvider sqlConv_RegistrationProvider = new SqlConv_RegistrationProvider();
        conv_Registrations = sqlConv_RegistrationProvider.GetAllConv_Registrations();
        return conv_Registrations;
    }


    public static Conv_Registration GetConv_RegistrationByID(int id)
    {
        Conv_Registration conv_Registration = new Conv_Registration();
        SqlConv_RegistrationProvider sqlConv_RegistrationProvider = new SqlConv_RegistrationProvider();
        conv_Registration = sqlConv_RegistrationProvider.GetConv_RegistrationByID(id);
        return conv_Registration;
    }


    public static int InsertConv_Registration(Conv_Registration conv_Registration)
    {
        SqlConv_RegistrationProvider sqlConv_RegistrationProvider = new SqlConv_RegistrationProvider();
        return sqlConv_RegistrationProvider.InsertConv_Registration(conv_Registration);
    }


    public static bool UpdateConv_Registration(Conv_Registration conv_Registration)
    {
        SqlConv_RegistrationProvider sqlConv_RegistrationProvider = new SqlConv_RegistrationProvider();
        return sqlConv_RegistrationProvider.UpdateConv_Registration(conv_Registration);
    }

    public static bool DeleteConv_Registration(int conv_RegistrationID)
    {
        SqlConv_RegistrationProvider sqlConv_RegistrationProvider = new SqlConv_RegistrationProvider();
        return sqlConv_RegistrationProvider.DeleteConv_Registration(conv_RegistrationID);
    }
}
