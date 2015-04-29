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

public class Comn_DepartmentManager
{
	public Comn_DepartmentManager()
	{
	}

    public static List<Comn_Department> GetAllComn_Departments()
    {
        List<Comn_Department> comn_Departments = new List<Comn_Department>();
        SqlComn_DepartmentProvider sqlComn_DepartmentProvider = new SqlComn_DepartmentProvider();
        comn_Departments = sqlComn_DepartmentProvider.GetAllComn_Departments();
        return comn_Departments;
    }


    public static Comn_Department GetComn_DepartmentByID(int id)
    {
        Comn_Department comn_Department = new Comn_Department();
        SqlComn_DepartmentProvider sqlComn_DepartmentProvider = new SqlComn_DepartmentProvider();
        comn_Department = sqlComn_DepartmentProvider.GetComn_DepartmentByID(id);
        return comn_Department;
    }


    public static int InsertComn_Department(Comn_Department comn_Department)
    {
        SqlComn_DepartmentProvider sqlComn_DepartmentProvider = new SqlComn_DepartmentProvider();
        return sqlComn_DepartmentProvider.InsertComn_Department(comn_Department);
    }


    public static bool UpdateComn_Department(Comn_Department comn_Department)
    {
        SqlComn_DepartmentProvider sqlComn_DepartmentProvider = new SqlComn_DepartmentProvider();
        return sqlComn_DepartmentProvider.UpdateComn_Department(comn_Department);
    }

    public static bool DeleteComn_Department(int comn_DepartmentID)
    {
        SqlComn_DepartmentProvider sqlComn_DepartmentProvider = new SqlComn_DepartmentProvider();
        return sqlComn_DepartmentProvider.DeleteComn_Department(comn_DepartmentID);
    }
}
