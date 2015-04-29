using System;
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
using System.IO;

/// <summary>
/// Summary description for getFileName
/// </summary>
public class getFileNameByReplace
{
    private string _fileName;

    public string FileName
    {
        get { return _fileName; }
        set { _fileName = value; }
    }

    public getFileNameByReplace(string fileName, string path)
    {   
        System.IO.FileInfo file;
        file = new FileInfo(path + "//" + fileName);
        
            FileName = fileName;
    }

   
}
