using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Control_TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadMenu1();
            //loadMenuStatic();
        }
    }
    private void loadMenu()
    {
        lblMenu.Text = "<ul  id='amenu-list'>";
        string sql = @"
SELECT [id] as MenuID
      ,[name] as MenuTitle
      ,[link] 
      ,[type]
      ,[parent] as ParentMenuID
      ,[ordering] as MenuOrder
      ,[lft] as PageURL
      ,'' as Usered,
      'page' as FolderName
      ,'' as DefaultURL
      ,CAST(rgt as nvarchar) as ModuleName
  FROM [IEB].[dbo].[web_nalku_menu]
  where published=1
  and id not in ( 11,20,28,40,44,45,29,38,51,12,13,18,52,46,43,47,30,24,14,15)
  order by rgt,parent,ordering 
";
        DataSet dsMenu = DatabaseManager.ExecSQL(sql);

        for (int l1 = 0; l1 < dsMenu.Tables[0].Rows.Count; l1++)
        {
            if (dsMenu.Tables[0].Rows[l1]["ParentMenuID"].ToString() == "0")
            {
                if (dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() == "Home")
                {
                    lblMenu.Text += @"
                                    <li><a  href='Default.aspx' class='menuL1'>" + dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() + "</a>";
                }
                else
                {
                    lblMenu.Text += @"
                                    <li><a " + (dsMenu.Tables[0].Rows[l1]["type"].ToString() == "url" ? "target='_blank'" : "") + " href='" + (dsMenu.Tables[0].Rows[l1]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l1]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l1]["PageURL"].ToString()) + @"' class='menuL1'>" + dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() + "</a>";
                }
                
                dsMenu.Tables[0].Rows[l1]["Usered"] = "yes";
                bool has2ndLable = false;
                for (int l2 = 0; l2 < dsMenu.Tables[0].Rows.Count; l2++)
                {
                    if (dsMenu.Tables[0].Rows[l2]["Usered"] != "yes"
                        && dsMenu.Tables[0].Rows[l2]["ParentMenuID"].ToString() == dsMenu.Tables[0].Rows[l1]["MenuID"].ToString()
                        )
                    {
                        if (!has2ndLable)
                        {
                            lblMenu.Text += @"
                                    <ul>";
                        }
                        has2ndLable = true;
                        lblMenu.Text += @"
                                    <li><a " + (dsMenu.Tables[0].Rows[l2]["type"].ToString() == "url" ? "target='_blank'" : "") + " href='" + (dsMenu.Tables[0].Rows[l2]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l2]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l2]["PageURL"].ToString()) + @"' class='menuL2'>" + dsMenu.Tables[0].Rows[l2]["MenuTitle"].ToString() + "</a>";
                        dsMenu.Tables[0].Rows[l2]["Usered"] = "yes";
                        bool has3ndLable = false;
                        for (int l3 = 0; l3 < dsMenu.Tables[0].Rows.Count; l3++)
                        {
                            if (dsMenu.Tables[0].Rows[l3]["Usered"] != "yes"
                                && dsMenu.Tables[0].Rows[l3]["ParentMenuID"].ToString() == dsMenu.Tables[0].Rows[l2]["MenuID"].ToString()
                                )
                            {
                                if (!has3ndLable)
                                {
                                    lblMenu.Text += @"
                                    <ul>";
                                }
                                has3ndLable = true;
                                lblMenu.Text += @"
                                    <li><a "+(dsMenu.Tables[0].Rows[l3]["type"].ToString() == "url" ?"target='_blank'":"")+" href='" + (dsMenu.Tables[0].Rows[l3]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l3]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l3]["PageURL"].ToString()) + @"' class='menuL3'>" + dsMenu.Tables[0].Rows[l3]["MenuTitle"].ToString() + "</a>";
                                dsMenu.Tables[0].Rows[l3]["Usered"] = "yes";
                                //code for L4
                                lblMenu.Text += @"
                                    </li>";
                            }

                        }
                        if (has3ndLable)
                        {
                            lblMenu.Text += @"
                                    </ul>";
                        }

                        lblMenu.Text += @"
                                    </li>";
                    }

                }
                if (has2ndLable)
                {
                    lblMenu.Text += @"
                                    </ul>";
                }
                lblMenu.Text += @"
                                    </li>";
            }
        }

        lblMenu.Text += @"
                                    </ul>";
    }
    private void loadMenu1()
    {
        lblMenu.Text = "<div class='menu'><ul  class='menu sf-menu sf-horizontal sf-js-enabled sf-shadow'>";
        string sql = @"
SELECT [id] as MenuID
      ,[name] as MenuTitle
      ,[link] 
      ,[type]
      ,[parent] as ParentMenuID
      ,[ordering] as MenuOrder
      ,[lft] as PageURL
      ,'' as Usered,
      'page' as FolderName
      ,'' as DefaultURL
      ,CAST(rgt as nvarchar) as ModuleName
,[dbo].[getNoofSubMenu](id) as subMenuCounting
  FROM [IEB].[dbo].[web_nalku_menu]
  where published=1
  and id not in ( 11,20,28,40,44,45,29,38,51,12,13,18,52,46,43,47,30,24,14,15)
  order by rgt,parent,ordering 
";
        DataSet dsMenu = DatabaseManager.ExecSQL(sql);

        for (int l1 = 0; l1 < dsMenu.Tables[0].Rows.Count; l1++)
        {
            if (dsMenu.Tables[0].Rows[l1]["ParentMenuID"].ToString() == "0")
            {
                if (dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() == "Home")
                {
                    lblMenu.Text += @"
                                    <li " + (dsMenu.Tables[0].Rows[l1]["subMenuCounting"].ToString()!="0"?" class='parent' ":"") + @"><a  href='Default.aspx' class='menuL1'>" + dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() + "</a>";
                }
                else
                {
                    lblMenu.Text += @"
                                    <li " + (dsMenu.Tables[0].Rows[l1]["MenuID"].ToString() == "141" ? " id='myDIV'" : "") + (dsMenu.Tables[0].Rows[l1]["subMenuCounting"].ToString() != "0" ? " class='parent' " : "") + @"><a " + (dsMenu.Tables[0].Rows[l1]["MenuID"].ToString() == "141" ? "Style='font-weight:bold;'" : "") + (dsMenu.Tables[0].Rows[l1]["type"].ToString() == "url" ? "target='_blank'" : "") + " href='" + (dsMenu.Tables[0].Rows[l1]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l1]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l1]["PageURL"].ToString()) + @"' class='menuL1'>" + dsMenu.Tables[0].Rows[l1]["MenuTitle"].ToString() + "</a>";
                }

                dsMenu.Tables[0].Rows[l1]["Usered"] = "yes";
                bool has2ndLable = false;
                for (int l2 = 0; l2 < dsMenu.Tables[0].Rows.Count; l2++)
                {
                    if (dsMenu.Tables[0].Rows[l2]["Usered"] != "yes"
                        && dsMenu.Tables[0].Rows[l2]["ParentMenuID"].ToString() == dsMenu.Tables[0].Rows[l1]["MenuID"].ToString()
                        )
                    {
                        if (!has2ndLable)
                        {
                            lblMenu.Text += @"
                                    <ul>";
                        }
                        has2ndLable = true;
                        lblMenu.Text += @"
                                    <li " + (dsMenu.Tables[0].Rows[l2]["subMenuCounting"].ToString() != "0" ? " class='parent' " : "") + @"><a " + (dsMenu.Tables[0].Rows[l2]["type"].ToString() == "url" ? "target='_blank'" : "") + " href='" + (dsMenu.Tables[0].Rows[l2]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l2]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l2]["PageURL"].ToString()) + @"' class='menuL2'>" + dsMenu.Tables[0].Rows[l2]["MenuTitle"].ToString() + "</a>";
                        dsMenu.Tables[0].Rows[l2]["Usered"] = "yes";
                        bool has3ndLable = false;
                        for (int l3 = 0; l3 < dsMenu.Tables[0].Rows.Count; l3++)
                        {
                            if (dsMenu.Tables[0].Rows[l3]["Usered"] != "yes"
                                && dsMenu.Tables[0].Rows[l3]["ParentMenuID"].ToString() == dsMenu.Tables[0].Rows[l2]["MenuID"].ToString()
                                )
                            {
                                if (!has3ndLable)
                                {
                                    lblMenu.Text += @"
                                    <ul>";
                                }
                                has3ndLable = true;
                                lblMenu.Text += @"
                                    <li " + (dsMenu.Tables[0].Rows[l3]["subMenuCounting"].ToString() != "0" ? " class='parent' " : "") + @"><a " + (dsMenu.Tables[0].Rows[l3]["type"].ToString() == "url" ? "target='_blank'" : "") + " href='" + (dsMenu.Tables[0].Rows[l3]["type"].ToString() == "url" ? dsMenu.Tables[0].Rows[l3]["link"].ToString() : "Page/Default.aspx?contentid=" + dsMenu.Tables[0].Rows[l3]["PageURL"].ToString()) + @"' class='menuL3'>" + dsMenu.Tables[0].Rows[l3]["MenuTitle"].ToString() + "</a>";
                                dsMenu.Tables[0].Rows[l3]["Usered"] = "yes";
                                //code for L4
                                lblMenu.Text += @"
                                    </li>";
                            }

                        }
                        if (has3ndLable)
                        {
                            lblMenu.Text += @"
                                    </ul>";
                        }

                        lblMenu.Text += @"
                                    </li>";
                    }

                }
                if (has2ndLable)
                {
                    lblMenu.Text += @"
                                    </ul>";
                }
                lblMenu.Text += @"
                                    </li>";
            }
        }

        lblMenu.Text += @"
                                    </ul></div>";
    }
    private void loadMenuStatic()
    {
        lblMenu.Text = @"<div class='menu'><ul class='menu sf-menu sf-horizontal sf-js-enabled sf-shadow'>
                                    <li><a href='http://www.iebbd.org/Default.aspx' class='menuL1'>Home</a>
                                    </li>
                                    <li class='parent'><a target='_blank' href='' class='menuL1 sf-with-ul'>About IEB<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='float: none; width: 30em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=54' class='menuL2'>About Us</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=145' class='menuL2'>Aims &amp; Objectives</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=110' class='menuL2'>Executive Office Bearers</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=130' class='menuL2'>Central Council Members</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;' class='parent'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=70' class='menuL2 sf-with-ul'>Engineering Divisional Committees<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='left: 30em; float: none; width: 24.4286em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=122' class='menuL3'>Civil Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=125' class='menuL3'>Electrical Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=126' class='menuL3'>Mechanical Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=124' class='menuL3'>Agricultural Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=123' class='menuL3'>Chemical Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=127' class='menuL3'>Computer Engineering Divisional Committee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=128' class='menuL3'>Textile Engineering Divisional Committee</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;' class='parent'><a style='float: none; width: auto;' target='_blank' href='' class='menuL2 sf-with-ul'>Engineers Recreation Certre (ERC)<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='left: 30em; float: none; width: 10em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=129' class='menuL3'>Dhaka</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=132' class='menuL3'>Chittagong</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=133' class='menuL3'>Rajshahi</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=134' class='menuL3'>Khulna</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://iebbd.org/images_oldsite/AttachedFiles/IEB_Constitution.pdf' class='menuL2'>IEB Constitution</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;' class='parent'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=146' class='menuL2 sf-with-ul'>International Affairs<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='left: 30em; float: none; width: 22.4286em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=193' class='menuL3'>ACECC 28th ECM on 27-29 March, 2015</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.bperb.org.bd/' class='menuL2'>Bangladesh Professional Engineers Registration Board</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.baete.org.bd/' class='menuL2'>Board of Accreditation for Engineering and Technical Education</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.esc-bd.org/' class='menuL2'>Engineering Staff College</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=186' class='menuL2'>Occupational Safety Board of Bangladesh</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li class='parent'><a target='_blank' href='' class='menuL1 sf-with-ul'>Membership<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='float: none; width: 30em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=107' class='menuL2'>About Membership</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=190' class='menuL2'>Missing Photo In IEB Membership Database</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=142' class='menuL2'>Membership Criteria</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=93' class='menuL2'>How to get Membership</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=117' class='menuL2'>Accredited Programs of the various Universities &amp; Equivalent Degrees</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=137' class='menuL2'>Search your membership No.</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=179' class='menuL2'>Membership Fee</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=121' class='menuL2'>Membership Form</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li class='parent'><a target='_blank' href='' class='menuL1 sf-with-ul'>Publication<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='float: none; width: 12.0714em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;' class='parent'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=164' class='menuL2 sf-with-ul'>Journals<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='left: 12.0714em; float: none; width: 19.5em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.jce-ieb.org/' class='menuL3'>Journal of Civil Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.iebeed.org/' class='menuL3'>Journal of Electrical Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='' class='menuL3'>Journal of Mechanical Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='' class='menuL3'>Journal of Agricultural Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='' class='menuL3'>Journal of Chemical Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.jte-ieb.org/' class='menuL3'>Journal of Textile Engineering</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='' class='menuL3'>Multidisciplinary Journal</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' target='_blank' href='http://www.iebbd.org/EngineeringNews/' class='menuL2'>Engineering News</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;' class='parent'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=184' class='menuL2 sf-with-ul'>Downloads<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='left: 12.0714em; float: none; width: 30em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=188' class='menuL3'>Draft Voters List for the Term 2015 and 2016</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=194' class='menuL3'>Draft Voter List for the Term 2015 and 2016 (Scanned Copy with sign)</a>
                                    </li>
                                    </ul>
                                    </li>
                                    </ul>
                                    </li>
                                    <li id='myDIV' class='parent'><a style='font-weight:bold;' href='http://www.iebbd.org/Page/Default.aspx?contentid=180' class='menuL1 sf-with-ul'>Convention<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='float: none; width: 15.0714em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=177' class='menuL2'>55th Convention Archive</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li class='parent'><a target='_blank' href='' class='menuL1 sf-with-ul'>Centre<span class='sf-sub-indicator'> »</span></a>
                                    <ul style='float: none; width: 30em; display: none; visibility: hidden;'>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=187' class='menuL2'>Contact Information of Office Bearers of All Centres/ Sub-centres/ Overseas Chapters</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=160' class='menuL2'>IEB Centre</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=161' class='menuL2'>IEB Sub-Centre</a>
                                    </li>
                                    <li style='white-space: normal; float: left; width: 100%;'><a style='float: none; width: auto;' href='http://www.iebbd.org/Page/Default.aspx?contentid=162' class='menuL2'>IEB Overseas Chapter</a>
                                    </li>
                                    </ul>
                                    </li>
                                    <li><a href='http://www.iebbd.org/Page/Default.aspx?contentid=114' class='menuL1'>Contact</a>
                                    </li>
                                    </ul></div>";

    }
}