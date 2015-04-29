using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Control_MembershipAdvanceSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadComn_Gender();
            loadMem_Division();
            loadMem_SubDivision();
            loadComn_University();
            loadComn_Office();
            if (Request.QueryString["Mobile"] != null)
            {
                txtMobile.Text = Request.QueryString["Mobile"];
                btnSearch_Click(this, new EventArgs());
            }

        }
    }
    private void sqlInjectionChecking()
    {
        CommonManager.isInjection(txtAddress.Text);
        CommonManager.isInjection(txtName.Text);
        CommonManager.isInjection(txtDateOfBirth.Text);
        CommonManager.isInjection(txtEmail.Text);
        CommonManager.isInjection(txtMemebershipNo.Text);
        CommonManager.isInjection(txtMobile.Text);
        CommonManager.isInjection(txtPassingYear.Text);
        CommonManager.isInjection(txtPhoneOffice.Text);
        CommonManager.isInjection(txtPhoneResidence.Text);
        CommonManager.isInjection(txtPlaceOfBrith.Text);
        CommonManager.isInjection(txtPresentIEBMembershipNo.Text);
        CommonManager.isInjection(txtScrollNo.Text);
    }
    private void loadComn_Gender()
    {
        ListItem li = new ListItem("", "0");
        ddlComn_Gender.Items.Add(li);

        List<Comn_Gender> comn_Genders = new List<Comn_Gender>();
        comn_Genders = Comn_GenderManager.GetAllComn_Genders();
        foreach (Comn_Gender comn_Gender in comn_Genders)
        {
            ListItem item = new ListItem(comn_Gender.Comn_GenderName.ToString(), comn_Gender.Comn_GenderID.ToString());
            ddlComn_Gender.Items.Add(item);
        }
    }
    private void loadMem_SubDivision()
    {
        ListItem li = new ListItem("", "0");
        ddlMem_SubDivision.Items.Add(li);

        List<Mem_SubDivision> mem_SubDivisions = new List<Mem_SubDivision>();
        mem_SubDivisions = Mem_SubDivisionManager.GetAllMem_SubDivisions();
        foreach (Mem_SubDivision mem_SubDivision in mem_SubDivisions)
        {
            ListItem item = new ListItem(mem_SubDivision.Mem_SubDivisionName.ToString(), mem_SubDivision.Mem_SubDivisionID.ToString());
            ddlMem_SubDivision.Items.Add(item);
        }
    }

    private void loadMem_Division()
    {
        ListItem li = new ListItem("", "0");
        ddlMem_Division.Items.Add(li);

        List<Mem_Division> mem_Divisions = new List<Mem_Division>();
        mem_Divisions = Mem_DivisionManager.GetAllMem_Divisions();
        foreach (Mem_Division mem_Division in mem_Divisions)
        {
            ListItem item = new ListItem(mem_Division.Mem_DivisionName.ToString(), mem_Division.Mem_DivisionID.ToString());
            ddlMem_Division.Items.Add(item);
        }
    }


    private void loadComn_University()
    {
        ddlComn_University.Items.Clear();
        ListItem li = new ListItem("", "0");
        ddlComn_University.Items.Add(li);

        List<Comn_University> comn_Universities = new List<Comn_University>();
        comn_Universities = Comn_UniversityManager.GetAllComn_Universities();
        foreach (Comn_University comn_University in comn_Universities)
        {

            if (comn_University.Type==1 && rbtnlInstitutionType.SelectedValue == "BANGLADESH")
            {
                ListItem item = new ListItem(comn_University.Comn_UniversityName.ToString() , comn_University.Comn_UniversityID.ToString());
                ddlComn_University.Items.Add(item);
            }
            else
                if (rbtnlInstitutionType.SelectedValue != "BANGLADESH" && comn_University.Type==0)
                {
                    ListItem item = new ListItem(comn_University.Comn_UniversityName.ToString() + "," + comn_University.Fax.ToString(), comn_University.Comn_UniversityID.ToString());
                    ddlComn_University.Items.Add(item);
                }
        }
    }

    private void loadComn_Office()
    {
        ListItem li = new ListItem("", "0");
        ddlComn_Office.Items.Add(li);

        List<Comn_Office> comn_Offices = new List<Comn_Office>();
        comn_Offices = Comn_OfficeManager.GetAllComn_Offices().FindAll(x => (x.Comm_OfficeTypeID == 4));
        foreach (Comn_Office comn_Office in comn_Offices)
        {
            ListItem item = new ListItem(comn_Office.Comn_OfficeName.ToString(), comn_Office.Comn_OfficeID.ToString());
            ddlComn_Office.Items.Add(item);
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        string sql = @"update Mem_Member set Comn_RowStatusID=2 ,ModifiedBy=48
           ,[ModifiedDate]=GETDATE()
        where Mem_MemberID=" + id;
        DatabaseManager.ExecSQL(sql);
        btnSearch_Click(this, new EventArgs());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        sqlInjectionChecking();
        String sql = @"
SELECT   
Mem_Member.Mem_MemberID, 
Mem_Member.MemberShipNo, 
--Mem_Member.MemberShipNoDigit, 
--Mem_Member.Mem_MemberTypeID, 
--Mem_MemberType.Mem_MemberTypeName, 
Mem_Member.Name, 
--Mem_Member.DateOfBirth, 
--Mem_Member.Age, 
--Comn_Nationality.Comn_NationalityName, 
--Mem_Member.Comn_NationalityID, 
--Mem_Member.PlaceOfBrith, 
Mem_Member.MailingAddress1, 
Mem_Member.MailingAddress2, 
Mem_Member.MailingAddress3, 
Mem_Member.MailingAddress, 
--Mem_Member.PermanentAddress, 
--Mem_Member.PermanentAddress1, 
--Mem_Member.PermanentAddress2, 
--Mem_Member.PermanentAddress3, 
--Mem_Member.PhoneOffice, 
--Mem_Member.PhoneResidence, 
Mem_Member.Mobile, 
Mem_Member.Email, 
--Mem_Member.Fax, 
--Mem_Member.OtherContactInfo, 
--Mem_Member.Comn_GenderID, 
--Comn_Gender.Comn_GenderName, 
--Mem_Member.PresentIEBMembershipNo, 
--Mem_Member.Mem_SubDivisionID, 
Mem_SubDivision.Mem_SubDivisionName, 
--Mem_SubDivision.Mem_DivisionID, 
--Mem_SubDivision.FullName AS SubDivisionFullName, 
--Mem_Division.Mem_DivisionName, 
--Mem_Division.FullName, 
--Mem_Member.DeclarationDate, 
--Mem_Member.ScrollNo, 
--Mem_Member.ReceiptDate, 
--Mem_Member.Comn_StatusID, 
--Comn_Status.Comn_StatusName, 
Mem_Member.PictureURL, 
--Mem_Member.SignatureURL, 
--Mem_Member.Comn_UniversityID, 
Comn_University.Comn_UniversityName, 
Mem_EducationalInfo.YearOfPassing as PassingYear, 
--Mem_Member.Comn_OfficeID, 
Comn_Office.Comn_OfficeName, 
--Mem_Member.Comn_BloodGroup, 
--Mem_Member.PassportNo, 
--Mem_Member.NationalIDNo, 
--Mem_Member.BirthRegistrationID, 
--Mem_Member.Comn_RowStatusID, 
--Mem_Member.ExtraField20, 
--Mem_Member.ExtraField19, 
--Mem_Member.ExtraField18, 
--Mem_Member.ExtraField17, 
--Mem_Member.ExtraField16, 
--Mem_Member.ExtraField15, 
--Mem_Member.ExtraField14, 
--Mem_Member.ExtraField13, 
--Mem_Member.ExtraField12, 
--Mem_Member.ExtraField11, 
--Mem_Member.ExtraField10, 
--Mem_Member.ExtraField9, 
--Mem_Member.ExtraField8, 
--Mem_Member.ExtraField7, 
--Mem_Member.ExtraField6, 
--Mem_Member.ExtraField5, 
--Mem_Member.ExtraField4, 
--Mem_Member.ExtraField3, 
--Mem_Member.ExtraField2, 
--Mem_Member.ExtraField1, 
--Comn_RowStatus.Comn_RowStatusName,
'' as PictureUrl
,'' as href
FROM         
Mem_Member inner JOIN
Mem_MemberType ON Mem_Member.Mem_MemberTypeID = Mem_MemberType.Mem_MemberTypeID inner JOIN
Mem_MemberCategory ON Mem_MemberType.Mem_MemberCategoryID = Mem_MemberCategory.Mem_MemberCategoryID inner JOIN
Comn_Nationality ON Mem_Member.Comn_NationalityID = Comn_Nationality.Comn_NationalityID inner JOIN
Comn_Gender ON Mem_Member.Comn_GenderID = Comn_Gender.Comn_GenderID inner JOIN
Mem_SubDivision ON Mem_Member.Mem_SubDivisionID = Mem_SubDivision.Mem_SubDivisionID inner JOIN
Mem_Division ON Mem_SubDivision.Mem_DivisionID = Mem_Division.Mem_DivisionID INNER JOIN
Mem_ApprovedCouncilMeeting ON 
Mem_Member.Mem_ApprovedCouncilMeetingID = Mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingID INNER JOIN
Comn_Status ON Mem_Member.Comn_StatusID = Comn_Status.Comn_StatusID left outer JOIN
Mem_EducationalInfo ON Mem_Member.Mem_MemberID = Mem_EducationalInfo.Mem_MemberID left outer  JOIN
Comn_University ON Mem_EducationalInfo.Comn_UniversityID = Comn_University.Comn_UniversityID left outer  JOIN
Comn_Office ON Mem_Member.Comn_OfficeID = Comn_Office.Comn_OfficeID INNER JOIN
Comn_RowStatus ON Mem_Member.Comn_RowStatusID = Comn_RowStatus.Comn_RowStatusID
";
        bool CriteriaUsed = false;
        if (txtMemebershipNo.Text != "")
        {
            if (txtMemebershipNo.Text.Contains("/"))
            {
                txtMemebershipNo.Text = txtMemebershipNo.Text.Split('/')[1];
            }
            sql += where(sql) + "Mem_Member.MemberShipNoDigit=" + txtMemebershipNo.Text + @"
                                ";
            CriteriaUsed = true;
        }

        if (rbtnLMembershipType.SelectedValue != "0")
        {
            sql += where(sql) + "Mem_Member.Mem_MemberTypeID=" + rbtnLMembershipType.SelectedValue + @"
                                ";
            CriteriaUsed = true;
        }

        if (ddlComn_BloodGroup.SelectedValue != "")
        {
            sql += where(sql) + "Mem_Member.Comn_BloodGroup='" + ddlComn_BloodGroup.SelectedValue + @"'
                                ";
            CriteriaUsed = true;
        }


        if (txtName.Text != "")
        {
            sql += where(sql) + "Mem_Member.Name like '%" + txtName.Text + @"%'
                                ";
            CriteriaUsed = true;
        }


        if (txtAddress.Text != "")
        {
            sql += where(sql) + "(Mem_Member.MailingAddress1 like '%" + txtAddress.Text + @"%' 
or Mem_Member.MailingAddress2 like '%" + txtAddress.Text + @"%' 
or Mem_Member.MailingAddress3 like '%" + txtAddress.Text + @"%' 
or Mem_Member.MailingAddress like '%" + txtAddress.Text + @"%' 
or Mem_Member.PermanentAddress like '%" + txtAddress.Text + @"%' 
or Mem_Member.PermanentAddress1 like '%" + txtAddress.Text + @"%' 
or Mem_Member.PermanentAddress2 like '%" + txtAddress.Text + @"%' 
or Mem_Member.PermanentAddress3 like '%" + txtAddress.Text + @"%' 
   )                             ";
            CriteriaUsed = true;
        }

        if (txtPresentIEBMembershipNo.Text != "")
        {
            sql += where(sql) + "Mem_Member.PresentIEBMembershipNo like '%" + txtPresentIEBMembershipNo.Text + @"%'
                                ";
            CriteriaUsed = true;
        }

        if (txtDateOfBirth.Text != "")
        {
            sql += where(sql) + "Mem_Member.DateOfBirth ='" + CommonManager.DateReformation(txtDateOfBirth.Text) + @"'
                                ";
            CriteriaUsed = true;
        }


        if (ddlMem_Division.SelectedValue != "0")
        {
            sql += where(sql) + "Mem_Division.Mem_DivisionID=" + ddlMem_Division.SelectedValue + @"
                                ";
            CriteriaUsed = true;
        }

        if (ddlComn_University.SelectedValue != "0")
        {
            sql += where(sql) + "Mem_EducationalInfo.Comn_UniversityID=" + ddlComn_University.SelectedValue + @"
                                ";
            CriteriaUsed = true;
        }

        if (ddlComn_Office.SelectedValue != "0")
        {
            sql += where(sql) + "Mem_Member.Comn_OfficeID=" + ddlComn_Office.SelectedValue + @"
                                ";
            CriteriaUsed = true;
        }

        if (txtPassingYear.Text != "")
        {
            sql += where(sql) + "Mem_EducationalInfo.YearOfPassing =" + txtPassingYear.Text + @"
                                ";
            CriteriaUsed = true;
        }

        if (txtMobile.Text != "")
        {
            sql += where(sql) + "Mem_Member.Mobile like '%" + txtMobile.Text + @"%'
                                ";
            CriteriaUsed = true;
        }

        if (txtEmail.Text != "")
        {
            sql += where(sql) + "Mem_Member.Email like '%" + txtEmail.Text + @"%'
                                ";
            CriteriaUsed = true;
        }

        if (CriteriaUsed)
        {
            DataSet ds = DatabaseManager.ExecSQL(sql + " and Mem_Member.Comn_RowStatusID=1");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["MailingAddress"].ToString() == "")
                {
                    dr["MailingAddress"] = dr["MailingAddress1"].ToString() + "<br/>" + dr["MailingAddress2"].ToString() + "<br/>" + dr["MailingAddress3"].ToString() + "<br/>";
                }

                
                if (dr["PictureURL"].ToString() == "")
                {
                    dr["PictureUrl"] = "../MembersArea/MemberPicture/" + dr["MemberShipNo"].ToString().Split('/')[0] + "-" + dr["MemberShipNo"].ToString().Split('/')[1] + ".jpg";
                }
                else
                {
                    dr["PictureURL"] = "../MembersArea/MemberPicture/" + dr["PictureURL"];
                }
                

                if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembersDirectory.aspx"))
                {
                    dr["href"] = "../page/MemberDetails.aspx?memberno=" + dr["MemberShipNo"].ToString().Replace("/","_");
                }
                else
                {
                    dr["href"] = "../MembersArea/MembershipInfo.aspx?mem_MemberID=" + dr["Mem_MemberID"].ToString();
                }
            }

            gvMember.DataSource = ds.Tables[0];
            gvMember.DataBind();

            lblCount.Text = ds.Tables[0].Rows.Count + " Memeber(s)";
        }
        else
        {
            lblCount.Text = "Plesae Select any Criteria";
            gvMember.DataSource = null;
            gvMember.DataBind();
        }
    }



    private string where(string sql)
    {
        if (sql.Contains("where")) return " and ";
        else return " where ";
    }
    protected void rbtnlInstitutionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadComn_University();
    }
}