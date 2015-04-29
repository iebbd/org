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

public class HR_EmpoyeeManager
{
	public HR_EmpoyeeManager()
	{
	}

    public static List<HR_Empoyee> GetAllHR_Empoyees()
    {
        List<HR_Empoyee> hR_Empoyees = new List<HR_Empoyee>();
        SqlHR_EmpoyeeProvider sqlHR_EmpoyeeProvider = new SqlHR_EmpoyeeProvider();
        hR_Empoyees = sqlHR_EmpoyeeProvider.GetAllHR_Empoyees();
        return hR_Empoyees;
    }


    public static HR_Empoyee GetHR_EmpoyeeByID(int id)
    {
        HR_Empoyee hR_Empoyee = new HR_Empoyee();
        SqlHR_EmpoyeeProvider sqlHR_EmpoyeeProvider = new SqlHR_EmpoyeeProvider();
        hR_Empoyee = sqlHR_EmpoyeeProvider.GetHR_EmpoyeeByID(id);
        return hR_Empoyee;
    }


    public static int InsertHR_Empoyee(HR_Empoyee hR_Empoyee)
    {
        SqlHR_EmpoyeeProvider sqlHR_EmpoyeeProvider = new SqlHR_EmpoyeeProvider();
        return sqlHR_EmpoyeeProvider.InsertHR_Empoyee(hR_Empoyee);
    }


    public static bool UpdateHR_Empoyee(HR_Empoyee hR_Empoyee)
    {
        SqlHR_EmpoyeeProvider sqlHR_EmpoyeeProvider = new SqlHR_EmpoyeeProvider();
        return sqlHR_EmpoyeeProvider.UpdateHR_Empoyee(hR_Empoyee);
    }

    public static bool DeleteHR_Empoyee(int hR_EmpoyeeID)
    {
        SqlHR_EmpoyeeProvider sqlHR_EmpoyeeProvider = new SqlHR_EmpoyeeProvider();
        return sqlHR_EmpoyeeProvider.DeleteHR_Empoyee(hR_EmpoyeeID);
    }
}
