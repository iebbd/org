using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;

public partial class Control_MembershipInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            loadLoginInHiddenField();
            CommonManager.processSQLInjection();
            loadMem_MemberType();
            loadComn_Nationality();
            loadComn_Gender();
            loadMem_Division();
            loadMem_SubDivision();
            loadMem_ApprovedCouncilMeeting();
            loadComn_Status();
            loadComn_University();
            //loadComn_Department();
            loadComn_Office();
            loadComn_RowStatus();
            loadComn_Gegree();
            loadComn_ResultType();
            laodDistrict();
            initialLoad();

            if (Request.QueryString["mem_MemberID"] != null)
            {
                Int64 mem_MemberID = Int64.Parse(Request.QueryString["mem_MemberID"]);
                if (mem_MemberID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    if (Request.QueryString["mem_MemberID"].Contains("710307") && Request.QueryString["mem_MemberID"].Contains("034438"))
                    {
                        hfMem_MemeberID.Value = Request.QueryString["mem_MemberID"].Replace("710307", "").Replace("034438", "");
                    
                    }
                    else
                    {
                        hfMem_MemeberID.Value = Request.QueryString["mem_MemberID"];
                    
                    }

                    a_print.HRef = "../MembersArea/MembershipForm/Page.aspx?Mem_MemberID="+hfMem_MemeberID.Value;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;                    
                    loadMemberData();
                }
            }

            loadRoleWiseControl();
            btnUpdateAllINfo.Visible = btnUpdate.Visible;
        }
    }

    private void laodDistrict()
    {
        ddlCompnayDistrict.Items.Add(new ListItem("Select District", "0"));
        ddlMailingAddressDistrict.Items.Add(new ListItem("Select District", ""));
        ddlMailingAddressUpozila.Items.Add(new ListItem("Select Upozila", ""));
        ddlCompanyUpazila.Items.Add(new ListItem("Select Upozila", "0"));
        ddlPermanentAddressDistrict.Items.Add(new ListItem("Select District", ""));
        ddlPermanentAddressUpozila.Items.Add(new ListItem("Select Upozila", ""));
        
        string sql = "select DistrictName,DistrictID from  Comn_District order by DistrictName";
        DataSet ds = DatabaseManager.ExecSQL(sql);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ddlCompnayDistrict.Items.Add(new ListItem(dr["DistrictName"].ToString(), dr["DistrictID"].ToString()));
            ddlMailingAddressDistrict.Items.Add(new ListItem(dr["DistrictName"].ToString(), dr["DistrictID"].ToString()));
            ddlPermanentAddressDistrict.Items.Add(new ListItem(dr["DistrictName"].ToString(), dr["DistrictID"].ToString()));
        }
        
    }

    private void sqlInjectionChecking()
    {
        CommonManager.isInjection(txtAge.Text);
        CommonManager.isInjection(txtAgeMembershipSection.Text);
        CommonManager.isInjection(txtCopiesOfCertificatesComment.Text);
        CommonManager.isInjection(txtCopiesOfTranscriptsComment.Text);
        CommonManager.isInjection(txtDateOfBirth.Text);
        CommonManager.isInjection(txtDeclarationDate.Text);
        CommonManager.isInjection(txtDegreeTitle.Text);
        CommonManager.isInjection(txtEducation.Text);
        CommonManager.isInjection(txtEmail.Text);
        CommonManager.isInjection(txtExprerience.Text);
        CommonManager.isInjection(txtExtraField1.Text);
        CommonManager.isInjection(txtExtraField2.Text);
        CommonManager.isInjection(txtExtraField3.Text);
        CommonManager.isInjection(txtExtraField4.Text);
        CommonManager.isInjection(txtExtraField5.Text);
        CommonManager.isInjection(txtExtraField6.Text);
        CommonManager.isInjection(txtExtraField7.Text);
        CommonManager.isInjection(txtExtraField8.Text);
        CommonManager.isInjection(txtExtraField9.Text);
        CommonManager.isInjection(txtExtraField10.Text);
        CommonManager.isInjection(txtExtraField11.Text);
        CommonManager.isInjection(txtExtraField12.Text);
        CommonManager.isInjection(txtExtraField13.Text);
        CommonManager.isInjection(txtExtraField14.Text);
        CommonManager.isInjection(txtExtraField15.Text);
        CommonManager.isInjection(txtExtraField16.Text);
        CommonManager.isInjection(txtExtraField17.Text);
        CommonManager.isInjection(txtExtraField18.Text);
        CommonManager.isInjection(txtExtraField19.Text);
        CommonManager.isInjection(txtExtraField20.Text);
        CommonManager.isInjection(txtFax.Text);
        txtInstituteName.Text = txtInstituteName.Text.ToUpper().Replace("AND","&");
        CommonManager.isInjection(txtInstituteName.Text);
        txtMailingAddress1.Text = txtMailingAddress1.Text.ToUpper().Replace("AND", "&");
        txtMailingAddress2.Text = txtMailingAddress2.Text.ToUpper().Replace("AND", "&");
        txtMailingAddress3.Text = txtMailingAddress3.Text.ToUpper().Replace("AND", "&");
        CommonManager.isInjection(txtMailingAddress1.Text);
        CommonManager.isInjection(txtMailingAddress2.Text);
        CommonManager.isInjection(txtMailingAddress3.Text);
        CommonManager.isInjection(txtMembershipCommiteeMemebershipNo.Text);
        CommonManager.isInjection(txtMemberShipNo.Text);
        CommonManager.isInjection(txtMemberShipNoDigit.Text);
        CommonManager.isInjection(txtMembershipCommiteeMemebershipNo.Text);
        CommonManager.isInjection(txtMembershipCommiteeMemebershipNo.Text);
    }

    private void loadMemberData()
    {

        try
        {
        tr_Personal_Details.Visible = true;
        tr_Personal_title.Visible = true;
        tr_History_title.Visible = true;
        tr_History_Details.Visible = true;
        tr_Fees_Details.Visible = true;
        tr_Fees_title.Visible = true;
        showMem_MemberData();
        loadFeesHistory();
        loadEducationalHistory();
        loadFiles();
        loadUpgradation();
        loadProfessionalRecord();
        }
        catch (Exception ex)
        {
            showAlartMessage("No Member found");
            btnUpdate.Visible = false;
            return;
        }
    }

    private void loadUpgradation()
    {


        if (ddlMem_MemberType.SelectedValue != "1")
        {
            string sql = "Select AppliedFor from Mem_Upgradation where Status<>'Completed' and Mem_MemberID=" + hfMem_MemeberID.Value;
            DataSet ds = DatabaseManager.ExecSQL(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                tr_Upgradation.Visible = true;
                lblAppliedFor.Text = "You have applied for "+ds.Tables[0].Rows[0][0].ToString();
                return; 
            }

            int experience = int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(hfPassingYear.Value);

            int age = int.Parse(txtAge.Text);


            if (age >= 35 && experience >= 10 && ddlMem_MemberType.SelectedValue == "2")
            {
                tr_Upgradation.Visible = true;
                a_ApplyForFellow.Visible = true;
            }
            else
                if (age >= 25 && experience >= 3 && ddlMem_MemberType.SelectedValue == "3")
                {
                    tr_Upgradation.Visible = true;
                    a_ApplyForMember.Visible = true;
                }
                
        }
    }

    private void loadFiles()
    {
        string sql = @"
SELECT     Mem_Files.FileName, Mem_FileTypeName.FileTypeName
FROM    Mem_Files INNER JOIN
        Mem_FileTypeName ON Mem_Files.FileTypeID = Mem_FileTypeName.FileTypeID
Where Mem_MemberID="+hfMem_MemeberID.Value+@"
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        gvFiles.DataSource = ds.Tables[0];
        gvFiles.DataBind();

    }

    private void loadRoleWiseControl()
    {
        btnAdd.Visible = false;
        btnUpdate.Visible = false;
        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipInfo.aspx"))
        {
            bool dataEntryPermissiont = ButtonManager.GetAllButtonsByPageURLnUserIDnButtonName("btnUpdate", HttpContext.Current.Request.Url.AbsoluteUri, getLogin().LoginID.ToString());
            if (gvEducationalInfo.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in gvEducationalInfo.Rows)
                {
                    LinkButton lbDelete = (LinkButton)gvr.FindControl("lbDelete");
                    lbDelete.Enabled = dataEntryPermissiont;
                }
            }
            
            if (hfMem_MemeberID.Value == "")
            {
                btnAdd.Visible = dataEntryPermissiont;
                tblAddEducationalInfoShow.Visible = dataEntryPermissiont;
                visibilityControl("addOffice");
            }
            else if (hfMem_MemeberID.Value != "")
            {
                btnUpdate.Visible = dataEntryPermissiont;
                tblAddEducationalInfoShow.Visible = dataEntryPermissiont;
                visibilityControl("updateOffice");
            }
        }
        else if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MyProfile.aspx?NewRegistration=1&"))
        {
            if (Request.QueryString["Mem_MemberID"] == null)
            {
                visibilityControl("onlineRegistration");
            }
            else
            {
                visibilityControl("updateNonMember");
            }
        }
        else if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MyProfile.aspx"))
        {
            visibilityControl("updateMember");
        }
    }

    private void visibilityControl(string userType)
    {
        

        switch (userType)
        {
            case "onlineRegistration":
                tbl_SearchByMembershipNo.Visible = false;
                ddlMem_ApprovedCouncilMeeting.SelectedValue = "1";
                btnAdd.Visible = true;
                txtMemberShipNoDigit.Enabled = false;
                tr_MembershipNo.Visible = false;
                tr_MemberShipNoDigit.Visible = false;
                tr_Age.Visible = true;
                tr_PlaceOfBrith.Visible = true;
                lblPresentIEBMembershipNo.Text = "Present IEB Membership No: ";
                tr_DeclarationDate.Visible = false;
                tr_ApprovedCouncilMeetingID.Visible = false;
                txtMailingAddress1.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
                txtMailingAddress1.Height = System.Web.UI.WebControls.Unit.Pixel(16);
                tr_PermanentAddress1.Visible = true;
                tr_PermanentAddress2.Visible = true;
                tr_PermanentAddress3.Visible = true;
                tr_PhoneOffice.Visible = true;                
                tblAddEducationalInfoShow.Visible = false;
                btnAddEducationalInfoShow.Visible = true;
                a_ApplyForFellow.Visible = false;
                a_ApplyForMember.Visible = false;
                break;

            case "updateNonMember":
                disableFieldsForNewMember();
                tbl_SearchByMembershipNo.Visible = false;
                ddlMem_ApprovedCouncilMeeting.SelectedValue = "1";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                txtMemberShipNoDigit.Enabled = false;
                tr_MembershipNo.Visible = true;
                tr_MemberShipNoDigit.Visible = false;
                tr_Age.Visible = true;
                tr_PlaceOfBrith.Visible = true;
                lblPresentIEBMembershipNo.Text = "Present IEB Membership No: ";
                tr_DeclarationDate.Visible = false;
                tr_ApprovedCouncilMeetingID.Visible = false;
                txtMailingAddress1.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
                txtMailingAddress1.Height = System.Web.UI.WebControls.Unit.Pixel(16);
                tr_PermanentAddress1.Visible = true;
                tr_PermanentAddress2.Visible = true;
                tr_PermanentAddress3.Visible = true;
                tr_PhoneOffice.Visible = true;
                tblAddEducationalInfoShow.Visible = false;
                btnAddEducationalInfoShow.Visible = true;
                tr_Fees_Details.Visible = false;
                tr_Fees_title.Visible = false;
                tr_ScrollNo.Visible = true;
                a_ApplyForFellow.Visible = false;
                a_ApplyForMember.Visible = false;
                if (gvEducationalInfo.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in gvEducationalInfo.Rows)
                    {
                        LinkButton lbDelete = (LinkButton)gvr.FindControl("lbDelete");
                        lbDelete.Enabled = false;
                    }
                }
                break;

            case "updateMember":
                disableFields();
                tbl_SearchByMembershipNo.Visible = false;
                ddlMem_ApprovedCouncilMeeting.SelectedValue = "1";
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                txtMemberShipNoDigit.Enabled = false;
                tr_MembershipNo.Visible = true;
                tr_MemberShipNoDigit.Visible = false;
                tr_Age.Visible = true;
                tr_PlaceOfBrith.Visible = true;
                lblPresentIEBMembershipNo.Text = "Previous IEB Membership No: ";
                tr_DeclarationDate.Visible = false;
                tr_ApprovedCouncilMeetingID.Visible = false;
                txtMailingAddress1.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
                txtMailingAddress1.Height = System.Web.UI.WebControls.Unit.Pixel(16);
                tr_PermanentAddress1.Visible = true;
                tr_PermanentAddress2.Visible = true;
                tr_PermanentAddress3.Visible = true;
                tr_PhoneOffice.Visible = true;
                tblAddEducationalInfoShow.Visible = false;
                //btnAddEducationalInfoShow.Visible = true;

                if (gvEducationalInfo.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in gvEducationalInfo.Rows)
                    {
                        LinkButton lbDelete = (LinkButton)gvr.FindControl("lbDelete");
                        lbDelete.Enabled = false;
                    }
                }
                ddlComn_Office.Enabled = true;
                
                break;

            case "addOffice":
                tbl_SearchByMembershipNo.Visible = true;
                tr_MembershipNo.Visible = false;
                tr_MemberShipNoDigit.Visible = true;
                tr_PlaceOfBrith.Visible = false;
                lblPresentIEBMembershipNo.Text = "Previous IEB Membership No: ";
                tr_DeclarationDate.Visible = true;
                tr_ApprovedCouncilMeetingID.Visible = true;
                tr_PermanentAddress1.Visible = false;
                tr_PermanentAddress2.Visible = false;
                tr_PermanentAddress3.Visible = false;
                tr_PhoneOffice.Visible = false;
                tblAddEducationalInfoShow.Visible = true;
                btnAddEducationalInfoShow.Visible = false;
                a_ApplyForFellow.Visible = false;
                a_ApplyForMember.Visible = false;
                break;

            case "updateOffice":
                tr_Age.Visible = true;
                tr_MembershipNo.Visible = false;
                tr_MemberShipNoDigit.Visible = true;
                tr_PlaceOfBrith.Visible = true;
                lblPresentIEBMembershipNo.Text = "Previous IEB Membership No: ";
                tr_DeclarationDate.Visible = true;
                tr_ApprovedCouncilMeetingID.Visible = true;
                tr_PermanentAddress1.Visible = true;
                tr_PermanentAddress2.Visible = true;
                tr_PermanentAddress3.Visible = true;
                tr_PhoneOffice.Visible = true;
                tblAddEducationalInfoShow.Visible = false;
                btnAddEducationalInfoShow.Visible = btnUpdate.Visible;
                a_ApplyForFellow.Visible = false;
                a_ApplyForMember.Visible = false;
                if (gvEducationalInfo.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in gvEducationalInfo.Rows)
                    {
                        LinkButton lbDelete = (LinkButton)gvr.FindControl("lbDelete");
                        lbDelete.Enabled = btnUpdate.Visible;
                    }
                }
                break;

            default:
                break;
        }
    }

    private void showAlartMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
             "err_msg",
             "alert('" + message + "');",
             true);
    }

    private void loadLoginInHiddenField()
    {
        if (hfLoginID.Value == "")
        {
            hfLoginID.Value = getLogin().LoginID.ToString();
        }
    }

    private Login getLogin()
    {
        Login login = new Login();

        try
        {
            if (Session["Login"] != null)
            {
                login = (Login)Session["Login"];
            }
            else if (hfLoginID.Value != "")
            {
                login = LoginManager.GetLoginByID(int.Parse(hfLoginID.Value));
            }
            else
            {
                hfLoginID.Value = "1";
                login = LoginManager.GetLoginByID(1);
                //Session["PreviousPage"] = HttpContext.Current.Request.Url.AbsoluteUri; Response.Redirect("../LoginPage.aspx"); 
            }

        }
        catch (Exception ex)
        { }

        return login;
    }
    private void disableFieldsForNewMember()
    {
        txtMemberShipNo.Enabled = false;
        txtMemberShipNoDigit.Enabled = false;
        ddlMem_MemberType.Enabled = false;
        //txtName.Enabled = false;
        txtDateOfBirth.Enabled = false;
        txtAge.Enabled = false;
        //ddlComn_Nationality.Enabled = false;
        //txtPlaceOfBrith.Enabled = false;
        //txtMailingAddress1.Enabled = false;
        //txtMailingAddress2.Enabled = false;
        //txtMailingAddress3.Enabled = false;
        //txtMailingAddress.Enabled = false;
        //txtPermanentAddress.Enabled = false;
        //txtPermanentAddress1.Enabled = false;
        //txtPermanentAddress2.Enabled = false;
        //txtPermanentAddress3.Enabled = false;
        //txtPhoneOffice.Enabled = false;
        //txtPhoneResidence.Enabled = false;
        //txtMobile.Enabled = false;
        //txtEmail.Enabled = false;
        //txtFax.Enabled = false;
        //txtOtherContactInfo.Enabled = false;
        //ddlComn_Gender.Enabled = false;
        txtPresentIEBMembershipNo.Enabled = false;
        ddlMem_Division.Enabled = false;
        ddlMem_SubDivision.Enabled = false;
        txtDeclarationDate.Enabled = false;
        ddlMem_ApprovedCouncilMeeting.Enabled = false;
        txtScrollNo.Enabled = false;
        txtReceiptDate.Enabled = false;
        cbCopiesOfCertificates.Enabled = false;
        txtCopiesOfCertificatesComment.Enabled = false;
        cbCopiesOfTranscripts.Enabled = false;
        txtCopiesOfTranscriptsComment.Enabled = false;
        cbPhotoEnclosed.Enabled = false;
        cbProfessionalRecordEnclosed.Enabled = false;
        txtProfessionalRecordEnclosedComment.Enabled = false;
        cbRecomendationOffice.Enabled = false;
        txtRecomenDationCommentOffice.Enabled = false;
        txtAgeMembershipSection.Enabled = false;
        txtEducation.Enabled = false;
        txtExprerience.Enabled = false;
        cbRecomendationMembershipSec.Enabled = false;
        txtRecomenDationCommentMembershipSec.Enabled = false;
        ddlMembershipSectionEmployee.Enabled = false;
        ddlComn_Status.Enabled = false;
        txtMembershipCommiteeMemebershipNo.Enabled = false;
        ddlMembershipCommiteeMemebershipType.Enabled = false;
        txtPictureURL.Enabled = false;
        txtSignatureURL.Enabled = false;
        ddlComn_University.Enabled = false;
        ddlComn_Department.Enabled = false;
        txtPassingYear.Enabled = false;
        //ddlComn_Office.Enabled = false;
        //txtComn_BloodGroup.Enabled = false;
        txtPassportNo.Enabled = false;
        ddlNational.Enabled = false;
        ddlBirthRegistration.Enabled = false;
        //txtExtraField1.Enabled = false;
        //txtExtraField2.Enabled = false;
        //txtExtraField3.Enabled = false;
        //txtExtraField4.Enabled = false;
        //txtExtraField5.Enabled = false;
        txtExtraField6.Enabled = false;
        //txtExtraField7.Enabled = false;
        txtExtraField8.Enabled = false;
        txtExtraField9.Enabled = false;
        txtExtraField10.Enabled = false;
        txtExtraField11.Enabled = false;
        txtExtraField12.Enabled = false;
        txtExtraField13.Enabled = false;
        //txtExtraField14.Enabled = false;
        txtExtraField15.Enabled = false;
        txtExtraField16.Enabled = false;
        txtExtraField17.Enabled = false;
        txtExtraField18.Enabled = false;
        txtExtraField19.Enabled = false;
        txtExtraField20.Enabled = false;
        ddlComn_RowStatus.Enabled = false;
        btnAddEducationalInfoShow.Visible = false;
    }

    private void disableFields()
    {
        txtMemberShipNo.Enabled = false;
        txtMemberShipNoDigit.Enabled = false;
        ddlMem_MemberType.Enabled = false;
        txtName.Enabled = false;
        txtDateOfBirth.Enabled = false;
        txtAge.Enabled = false;
        ddlComn_Nationality.Enabled = false;
        //txtPlaceOfBrith.Enabled = false;
        txtMailingAddress1.Enabled = false;
        txtMailingAddress2.Enabled = false;
        txtMailingAddress3.Enabled = false;
        txtMailingAddress.Enabled = false;
        txtPermanentAddress.Enabled = false;
        //txtPermanentAddress1.Enabled = false;
        //txtPermanentAddress2.Enabled = false;
        //txtPermanentAddress3.Enabled = false;
        //txtPhoneOffice.Enabled = false;
        //txtPhoneResidence.Enabled = false;
        //txtMobile.Enabled = false;
        //txtEmail.Enabled = false;
        //txtFax.Enabled = false;
        //txtOtherContactInfo.Enabled = false;
        ddlComn_Gender.Enabled = false;
        txtPresentIEBMembershipNo.Enabled = false;
        ddlMem_Division.Enabled = false;
        ddlMem_SubDivision.Enabled = false;
        txtDeclarationDate.Enabled = false;
        ddlMem_ApprovedCouncilMeeting.Enabled = false;
        txtScrollNo.Enabled = false;
        txtReceiptDate.Enabled = false;
        cbCopiesOfCertificates.Enabled = false;
        txtCopiesOfCertificatesComment.Enabled = false;
        cbCopiesOfTranscripts.Enabled = false;
        txtCopiesOfTranscriptsComment.Enabled = false;
        cbPhotoEnclosed.Enabled = false;
        cbProfessionalRecordEnclosed.Enabled = false;
        txtProfessionalRecordEnclosedComment.Enabled = false;
        cbRecomendationOffice.Enabled = false;
        txtRecomenDationCommentOffice.Enabled = false;
        txtAgeMembershipSection.Enabled = false;
        txtEducation.Enabled = false;
        txtExprerience.Enabled = false;
        cbRecomendationMembershipSec.Enabled = false;
        txtRecomenDationCommentMembershipSec.Enabled = false;
        ddlMembershipSectionEmployee.Enabled = false;
        ddlComn_Status.Enabled = false;
        txtMembershipCommiteeMemebershipNo.Enabled = false;
        ddlMembershipCommiteeMemebershipType.Enabled = false;
        txtPictureURL.Enabled = false;
        txtSignatureURL.Enabled = false;
        ddlComn_University.Enabled = false;
        ddlComn_Department.Enabled = false;
        txtPassingYear.Enabled = false;
        ddlComn_Office.Enabled = false;
        //txtComn_BloodGroup.Enabled = false;
        txtPassportNo.Enabled = false;
        ddlNational.Enabled = false;
        ddlBirthRegistration.Enabled = false;
        //txtExtraField1.Enabled = false;
        //txtExtraField2.Enabled = false;
        //txtExtraField3.Enabled = false;
        //txtExtraField4.Enabled = false;
        //txtExtraField5.Enabled = false;
        txtExtraField6.Enabled = false;
        //txtExtraField7.Enabled = false;
        txtExtraField8.Enabled = false;
        txtExtraField9.Enabled = false;
        txtExtraField10.Enabled = false;
        txtExtraField11.Enabled = false;
        txtExtraField12.Enabled = false;
        txtExtraField13.Enabled = false;
        //txtExtraField14.Enabled = false;
        txtExtraField15.Enabled = false;
        txtExtraField16.Enabled = false;
        txtExtraField17.Enabled = false;
        txtExtraField18.Enabled = false;
        txtExtraField19.Enabled = false;
        txtExtraField20.Enabled = false;
        ddlComn_RowStatus.Enabled = false;
        btnAddEducationalInfoShow.Visible = false;
    }

    private void loadEducationalHistory()
    {
        string Applied = "";
        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        {
            //Applied = "Applied_";
            btnAddEducationalInfoShow.Visible = true;
        }

        string sql = @"
SELECT     Mem_" + Applied + @"EducationalInfo.Mem_EducationalInfoID, 
Mem_" + Applied + @"EducationalInfo.Mem_MemberID, 
Mem_" + Applied + @"EducationalInfo.Comn_GegreeID, 
                      Comn_Gegree.Comn_GegreeName, 
                      Mem_" + Applied + @"EducationalInfo.Comn_UniversityID, 
                      Comn_University.Comn_UniversityName ,
Comn_University.Comn_UniversityFullName , 
                      Mem_" + Applied + @"EducationalInfo.DegreeTitle, 
                      Mem_" + Applied + @"EducationalInfo.YearOfPassing, 
                      Mem_" + Applied + @"EducationalInfo.Comn_ResultTypeID, 
                      Comn_ResultType.Comn_ResultTypeName, 
                      Mem_" + Applied + @"EducationalInfo.Result, 
                      Mem_" + Applied + @"EducationalInfo.InstituteName, 
                      Mem_" + Applied + @"EducationalInfo.Comn_SubDivisionID, 
                      Mem_SubDivision.Mem_SubDivisionName
FROM         Mem_" + Applied + @"EducationalInfo INNER JOIN
      Mem_" + Applied + @"Member ON Mem_" + Applied + @"EducationalInfo.Mem_MemberID = Mem_" + Applied + @"Member.Mem_MemberID left outer JOIN
      Comn_Gegree ON Mem_" + Applied + @"EducationalInfo.Comn_GegreeID = Comn_Gegree.Comn_GegreeID  left outer JOIN
      Comn_ResultType ON Mem_" + Applied + @"EducationalInfo.Comn_ResultTypeID = Comn_ResultType.Comn_ResultTypeID  left outer JOIN
      Comn_University ON Mem_" + Applied + @"EducationalInfo.Comn_UniversityID = Comn_University.Comn_UniversityID left outer JOIN
      Mem_SubDivision ON Mem_" + Applied + @"EducationalInfo.Comn_SubDivisionID = Mem_SubDivision.Mem_SubDivisionID
where Mem_" + Applied + @"Member.Mem_MemberID=" + hfMem_MemeberID.Value + @" 
";

        DataSet ds = DatabaseManager.ExecSQL(sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (int.Parse(dr["Comn_SubDivisionID"].ToString()) == 22
                ||
                int.Parse(dr["Comn_SubDivisionID"].ToString()) > 25
                )
            {
                dr["Mem_SubDivisionName"] = ((dr["Comn_GegreeID"].ToString() == "3" || dr["Comn_GegreeID"].ToString() == "4") ? "Unknown" : dr["InstituteName"].ToString());
            }
            if (dr["Comn_GegreeID"].ToString() == "3")
            {
                hfPassingYear.Value = dr["YearOfPassing"].ToString();
            }

            //dr["Mem_SubDivisionName"] = ((dr["Comn_GegreeID"].ToString() == "3" || dr["Comn_GegreeID"].ToString() == "4") ? "Unknown" : "");

        }

        gvEducationalInfo.DataSource = ds.Tables[0];
        gvEducationalInfo.DataBind();

    }

    protected void lbDeleteEducationalInfo_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        {
            bool result = Mem_EducationalInfoManager.DeleteMem_Applied_EducationalInfo(Convert.ToInt32(linkButton.CommandArgument));
        }
        else
        {
            bool result = Mem_EducationalInfoManager.DeleteMem_EducationalInfo(Convert.ToInt32(linkButton.CommandArgument));        
        }
        loadEducationalHistory();
    }


    private void initialLoad()
    {
        txtDeclarationDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
        //ddlMem_MemberType.SelectedValue = "1";
        txtDateOfBirth.Text = DateTime.Today.ToString("dd-MM-yyyy");
        txtReceiptDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
        tr_Fees_Details.Visible = false;
        tr_Fees_title.Visible = false;
        tr_History_Details.Visible = false;
        tr_History_title.Visible = false;
    }

    private bool checkDropDownList()
    {
        if (ddlComn_Gender.SelectedValue == "0") return false;
        if (ddlComn_Nationality.SelectedValue == "0") return false;
        if (ddlComn_Office.SelectedValue == "0") return false;
        if (ddlComn_RowStatus.SelectedValue == "0") return false;
        if (ddlComn_Status.SelectedValue == "0") return false;
        if (ddlComn_University.SelectedValue == "0") return false;
        if (ddlMem_Division.SelectedValue == "0") return false;
        if (ddlMem_SubDivision.SelectedValue == "0") return false;

        return true;
    }

    protected void loadFeesHistory()
    {

        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        {
            tr_Fees_Details.Visible = false;
            tr_Fees_title.Visible = false;
            return;
        }
        string sql = @"
                SELECT Mem_Fees.[Amount]
                      ,Mem_FeesYear.Mem_FeesYearName as [PaidFor]
                      ,Mem_Fees.[PaidDate]
                        ,Mem_Fees.RefferenceNo
                  FROM [Mem_Fees]
                  inner join Mem_Member on Mem_Member.Mem_MemberID=Mem_Fees.Mem_MemberID
                  inner join Mem_FeesYear on Mem_FeesYear.Mem_FeesYearID=Mem_Fees.Mem_FeesYearID
                  where  Mem_Fees.Comn_RowStatusID=1 and Mem_Member.Mem_MemberID=" + hfMem_MemeberID.Value + @"
                   order by   Mem_FeesYear.Ordering  asc;
SELECT [AnnaralSubscriptionFee]
  FROM [Mem_MemberType] where Mem_MemberTypeID=" + ddlMem_MemberType.SelectedValue + @";

 SELECT top 1 [Amount]
  FROM [Mem_FeesForLife] where Mem_MembershipTypeID=" + ddlMem_MemberType.SelectedValue + @" and Age<=("+txtAge.Text+@"+1)
  order by Age Desc
";
        DataSet ds = DatabaseManager.ExecSQL(sql);
        lblDues.ForeColor = System.Drawing.Color.Red;
        lblDues.Text = "";
        decimal duesAmount = 0;
        decimal duesAmount_Current = 0;
        bool otherthanUnknown = false;
        bool unknown = false;
        bool isLife = false;
        decimal max = 0;
        string current_year_text = "2014-2015";
        int current_year = 2014;
        bool only_unknown = false;
        decimal reEnrollmentfee = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMem_Fees.DataSource = ds.Tables[0];
            gvMem_Fees.DataBind();

            decimal total = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                total += decimal.Parse(dr["Amount"].ToString());
            }
            ((Label)gvMem_Fees.FooterRow.FindControl("lblTotalAmount")).Text = total.ToString("0,0.00");
            

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["PaidFor"].ToString() == "Unknown")
                {
                    unknown = true;
                }
                else
                {
                    otherthanUnknown = true;
                }

                if (
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() == "ABOVE 66"
                    ||
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() == "LIFE"
                    )
                {
                    isLife = true;
                }
            }

            if (ddlMem_MemberType.SelectedValue == "1")
            {
                max = 1600;
                reEnrollmentfee = 400;
            }
            else if (ddlMem_MemberType.SelectedValue == "2")
            {
                max = 950;
                reEnrollmentfee = 250;
            }

            else if (ddlMem_MemberType.SelectedValue == "3")
            {
                max = 500;
                reEnrollmentfee = 150;
            }

            try
            {
                if (
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() != "ABOVE 66"
                    &&
                    ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString() != "LIFE"
                    && (otherthanUnknown))
                {
                    int yearDiffirence = (current_year+1) - int.Parse(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString().Split('-')[1]);
                    int yearDiffirence_current = current_year - int.Parse(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["PaidFor"].ToString().Split('-')[1]);
                    if (yearDiffirence > 0)
                    {
                        

                        decimal amount = decimal.Parse(yearDiffirence.ToString()) * decimal.Parse(ds.Tables[1].Rows[0][0].ToString());
                        decimal amount_current = decimal.Parse(yearDiffirence_current.ToString()) * decimal.Parse(ds.Tables[1].Rows[0][0].ToString());
                        #region When offer is invalid
                        //When the offer is invalid
                        if (yearDiffirence >= 3)
                        {
                            amount += reEnrollmentfee;
                        }
                        if (yearDiffirence_current >= 2)
                        {
                            amount_current += reEnrollmentfee;
                        }
                        max = amount;
                        #endregion
                        

                        duesAmount = (amount >= max ? max : amount);
                        duesAmount_Current = (amount_current >= max ? max : amount_current);
                        lblDues.Text = yearDiffirence + " year(s) (Incuding "+current_year_text+@") fees total: <b>" + (amount >= max ? max : amount).ToString("0,0") + "/=</b> Dues";
                    }
                }
                else if (unknown && !otherthanUnknown)
                {
                    //if (hfMem_MemeberID.Value != "26901")
                        lblDues.Text = "Fees total: <b>" + max.ToString("0,0") + "/=</b> Dues";

                    
                    duesAmount = max;
                    duesAmount_Current = max;
                    only_unknown = false;
                    
                    //when offer is invalid
                    only_unknown = true;
                    //if (hfMem_MemeberID.Value != "26901") 
                        lblDues.Text = "You have to call membership section to know your Dues";
                    tbl_CardPayment.Visible = false;
                }
                else
                {
                    
                        lblDues.Text = "You don't need to pay anymore";
                    lblDues.ForeColor = System.Drawing.Color.Green;
                    tbl_CardPayment.Visible = false;
                }
            }
            catch (Exception ex)
            { }
        }
        else
        {
            lblDues.Text = "For Dues amount please call IEB office";
            tbl_CardPayment.Visible = false;
        }

        if ((!isLife && ds.Tables[0].Rows.Count > 0 && !only_unknown) 
            //|| hfMem_MemeberID.Value=="26901"
            )
        {
            decimal OneYearFee=decimal.Parse(ds.Tables[1].Rows[0][0].ToString());
            decimal lifeAmount =decimal.Parse(ds.Tables[2].Rows[0][0].ToString());
            if (duesAmount_Current == max)
            {
                if (duesAmount_Current == 1600)
                    duesAmount_Current = 1000;
                if (duesAmount_Current == 950)
                    duesAmount_Current = 950-350;
                if (duesAmount_Current == 500)
                    duesAmount_Current = 500 - 175;
            }

            string htm = @"<table class='tbl' style='color:black; ' border='1' cellpading='5' cellspacing='0'>
<tr style='color:white;background-color:#33479E;'>
                <td style='background-color:#FFF;'>
                    &nbsp;</td>
                <td align='right'>
                    Regular Membership</td>
                <td rowspan='4' style='background-color:#FFF;color:black;'>
                    OR</td>
                <td align='right'>
                    Life Membership</td>
                <td align='Center' colspan='2'>
                    <img style='background-color: #FFFFFF; width: 56px;padding:3px;' src='http://iebbd.org/images/BKash_logo.gif'></td>
            </tr>
            <tr>
                <td>
                    Membership Fee</td>
                <td style='text-align:right;' align='right'>
                    " + duesAmount.ToString("0")+ @"</td>
                <td style='text-align:right;' align='right'>
                    (" +
                       ( txtDateOfBirth.Text!="01-01-1900"?
                       (
                       duesAmount==0?
                        lifeAmount.ToString("0") + "-" + OneYearFee.ToString("0") + ")= " + (lifeAmount - OneYearFee).ToString("0") 
                        :
                       duesAmount_Current.ToString("0") + "+" + lifeAmount.ToString("0") + ")= " + (duesAmount_Current + lifeAmount).ToString("0") 
                       )
                       : "DOB wrong"
                       )
                       + @"</td>
                <td align='Center' colspan='2'>Send total payable to the follwoing a/c. 
<a target='_blank' href='http://iebbd.org/MembersArea/bKashPayment.aspx'>Click here for detail </td>
                    </td>
            </tr>
            <tr>
                <td>
                    bKash Fee(1.25%)</td>
                <td style='text-align:right;' align='right'>
                    " + (decimal.Ceiling(duesAmount * decimal.Parse("0.0126"))).ToString("0") + @"</td>
                <td style='text-align:right;' align='right'>
                    " +
                     ( txtDateOfBirth.Text!="01-01-1900"?
                      (
                       duesAmount==0?
                        (decimal.Ceiling((lifeAmount - OneYearFee) * decimal.Parse("0.0126"))).ToString("0")
                        :
                       (decimal.Ceiling((duesAmount_Current + lifeAmount) * decimal.Parse("0.0126"))).ToString("0")
                       )
                       : "DOB wrong"
                       )
                      + @"</td>
 <td  align='right'>
                    bKash Merchant Account</td>
                <td >
                    01766674142</td>
            </tr>
            <tr>
                <td>
                    Total payable</td>
                <td style='text-align:right;' align='right'>
                    " + (decimal.Ceiling(duesAmount * decimal.Parse("1.0126"))).ToString("0") + @"</td>
                <td style='text-align:right;' align='right'>
                    " +
                      ( txtDateOfBirth.Text!="01-01-1900"?
                      (
                       duesAmount == 0 ?
                        (decimal.Ceiling((lifeAmount - OneYearFee) * decimal.Parse("1.0126"))).ToString("0")
                        :
                       (decimal.Ceiling((duesAmount_Current + lifeAmount) * decimal.Parse("1.0126"))).ToString("0")
                       )
                       : "DOB wrong"
                       )
                      + @"</td>
<td  align='right'>
                    Reference No.</td>
                <td >
                    " + txtMemberShipNo.Text.Trim().Replace("/", "") + @"DUE</td>
            </tr>
            
            <tr>
               
            </tr>
            <tr>
                <td colspan='6'>
                    <a target='_blank' href='../Payment/'>After payment, for payment confirmation click here.</a> Don't Forget to keep your 
                    Transaction ID(TrxID) which you will get in SMS from bKash</td>
            </tr>
<tr>
                <td colspan='6'>
<b style='color:red;'>If your mailing address is outside Bangladesh, above fees amount will not be applicable for you. <a target='_blank' href='../Page/Default.aspx?contentid=179'>PLease click here for details.</a></b>
                    
</td>
            </tr>
        </table>
";
            //if (hfMem_MemeberID.Value != "26901")
            lblDues.Text += htm;

            foreach (ListItem item in rbtnPaymentFor.Items)
            {
                if (item.Value == "1")
                {
                    if (duesAmount == 0)
                    {
                        item.Enabled = false;
                        item.Text += "(0)";
                    }
                    else
                    {
                        item.Text += decimal.Ceiling((duesAmount / decimal.Parse("0.98"))).ToString("0") + "( Amount Breakdown: " + duesAmount.ToString("0") + "+" + (decimal.Ceiling((duesAmount / decimal.Parse("0.98"))) - duesAmount).ToString("0") + ")";
                    }
                }

                if (item.Value == "2")
                {
                    /*
                    ( txtDateOfBirth.Text!="01-01-1900"?
                       (
                       duesAmount==0?
                        lifeAmount.ToString("0") + "-" + OneYearFee.ToString("0") + ")= " + (lifeAmount - OneYearFee).ToString("0") 
                        :
                       duesAmount_Current.ToString("0") + "+" + lifeAmount.ToString("0") + ")= " + (duesAmount_Current + lifeAmount).ToString("0") 
                       )
                       : "DOB wrong"
                       )
                     */ 
                    if (txtDateOfBirth.Text=="01-01-1900")
                    {
                        item.Enabled = false;
                        item.Text += "(DOB Wrong)";
                    }
                    else
                    {
                        /*
                        if (hfMem_MemeberID.Value == "26901")
                        {
                            lifeAmount -= 2723;
                            tbl_CardPayment.Visible = true;
                        }
                        */

                        string lifeFeeText=(duesAmount==0?
                            lifeAmount.ToString("0") + "-" + OneYearFee.ToString("0") + ")= " + (lifeAmount - OneYearFee).ToString("0") 
                            :
                           duesAmount_Current.ToString("0") + "+" + lifeAmount.ToString("0") + ")= " + (duesAmount_Current + lifeAmount).ToString("0") 
                           );
                        decimal lifeFeeAmount = (duesAmount == 0 ?
                            (lifeAmount - OneYearFee)
                            :
                           (duesAmount_Current + lifeAmount)
                           );

                        item.Text += decimal.Ceiling((lifeFeeAmount / decimal.Parse("0.98"))).ToString("0") + "( Amount Breakdown: [(" + lifeFeeText + "]+" + (decimal.Ceiling((lifeFeeAmount / decimal.Parse("0.98"))) - lifeFeeAmount).ToString("0") + ")";
                    }
                }
            }
        }
        
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //return;
        
        
        Mem_Member mem_Member = new Mem_Member();

        mem_Member.Mem_MemberTypeID = Int32.Parse(ddlMem_MemberType.SelectedValue);
        mem_Member.Name = txtName.Text.Trim();
        mem_Member.DateOfBirth = DateTime.Parse(paidDateReform(txtDateOfBirth.Text));
        mem_Member.Age = Int32.Parse((txtAge.Text == "" ? "0" : txtAge.Text));
        mem_Member.Comn_NationalityID = Int32.Parse(ddlComn_Nationality.SelectedValue);
        mem_Member.PlaceOfBrith = txtPlaceOfBrith.Text.Trim();
        mem_Member.MailingAddress1 = txtMailingAddress1.Text.Trim();
        mem_Member.MailingAddress2 = txtMailingAddress2.Text.Trim();
        mem_Member.MailingAddress3 = txtMailingAddress3.Text.Trim();
        mem_Member.MailingAddress = txtMailingAddress.Text.Trim();
        mem_Member.PermanentAddress = txtPermanentAddress.Text.Trim();
        mem_Member.PermanentAddress1 = txtPermanentAddress1.Text.Trim();
        mem_Member.PermanentAddress2 = txtPermanentAddress2.Text.Trim();
        mem_Member.PermanentAddress3 = txtPermanentAddress3.Text.Trim();
        mem_Member.PhoneOffice = txtPhoneOffice.Text.Trim();
        mem_Member.PhoneResidence = txtPhoneResidence.Text.Trim();
        mem_Member.Mobile = txtMobile.Text.Trim();
        mem_Member.Email = txtEmail.Text.Trim();
        mem_Member.Fax = txtFax.Text.Trim();
        mem_Member.OtherContactInfo = txtOtherContactInfo.Text.Trim();
        mem_Member.Comn_GenderID = Int32.Parse(ddlComn_Gender.SelectedValue);
        mem_Member.PresentIEBMembershipNo = txtPresentIEBMembershipNo.Text.Trim();
        mem_Member.Mem_SubDivisionID = Int32.Parse(ddlMem_SubDivision.SelectedValue);
        mem_Member.DeclarationDate = DateTime.Parse((txtDeclarationDate.Text == "" ? "2000-01-01" : paidDateReform(txtDeclarationDate.Text)));
        mem_Member.Mem_ApprovedCouncilMeetingID = Int32.Parse(ddlMem_ApprovedCouncilMeeting.SelectedValue);
        mem_Member.ScrollNo = Int32.Parse((txtScrollNo.Text == "" ? "0" : txtScrollNo.Text));
        mem_Member.ReceiptDate = DateTime.Parse((txtReceiptDate.Text == "" ? "2000-01-01" : paidDateReform(txtReceiptDate.Text)));
        mem_Member.CopiesOfCertificates = cbCopiesOfCertificates.Checked;
        mem_Member.CopiesOfCertificatesComment = txtCopiesOfCertificatesComment.Text.Trim();
        mem_Member.CopiesOfTranscripts = cbCopiesOfTranscripts.Checked;
        mem_Member.CopiesOfTranscriptsComment = txtCopiesOfTranscriptsComment.Text.Trim();
        mem_Member.PhotoEnclosed = cbPhotoEnclosed.Checked;
        mem_Member.ProfessionalRecordEnclosed = cbProfessionalRecordEnclosed.Checked;
        mem_Member.ProfessionalRecordEnclosedComment = txtProfessionalRecordEnclosedComment.Text.Trim();
        mem_Member.RecomendationOffice = cbRecomendationOffice.Checked;
        mem_Member.RecomenDationCommentOffice = txtRecomenDationCommentOffice.Text.Trim();
        mem_Member.AgeMembershipSection = txtAgeMembershipSection.Text.Trim();
        mem_Member.Education = txtEducation.Text.Trim();
        mem_Member.Exprerience = txtExprerience.Text.Trim();
        mem_Member.RecomendationMembershipSec = cbRecomendationMembershipSec.Checked;
        mem_Member.RecomenDationCommentMembershipSec = txtRecomenDationCommentMembershipSec.Text.Trim();
        mem_Member.MembershipSectionEmployeeID = getLogin().LoginID;
        mem_Member.Comn_StatusID = Int32.Parse(ddlComn_Status.SelectedValue);
        mem_Member.MembershipCommiteeMemebershipNo = Int32.Parse(ddlCompanyUpazila.SelectedValue);
        mem_Member.MembershipCommiteeMemebershipTypeID = 1;//Int32.Parse(ddlMembershipCommiteeMemebershipType.SelectedValue);
        mem_Member.PictureURL = txtPictureURL.Text.Trim();
        mem_Member.SignatureURL = txtSignatureURL.Text.Trim();
        mem_Member.Comn_UniversityID = Int32.Parse(ddlComn_University.SelectedValue);
        mem_Member.Comn_DepartmentID = Int32.Parse(ddlSubDivision.SelectedValue);
        mem_Member.PassingYear = Int32.Parse(txtPassingYear.Text);
        mem_Member.Comn_OfficeID = Int32.Parse(ddlComn_Office.SelectedValue);
        mem_Member.Comn_BloodGroup = ddlComn_BloodGroup.SelectedValue;
        mem_Member.PassportNo = txtPassportNo.Text.Trim();
        mem_Member.NationalIDNo = "";
        mem_Member.BirthRegistrationID = "";
        mem_Member.ExtraField1 = txtExtraField1.Text.Trim();
        mem_Member.ExtraField2 = txtExtraField2.Text.Trim();
        mem_Member.ExtraField3 = txtExtraField3.Text.Trim();
        mem_Member.ExtraField4 = txtExtraField4.Text.Trim();
        mem_Member.ExtraField5 = ddlMailingAddressDistrict.SelectedValue;//txtExtraField5.Text.Trim();
        mem_Member.ExtraField6 = ddlMailingAddressUpozila.SelectedValue;// txtExtraField6.Text.Trim();
        mem_Member.ExtraField7 = ddlPermanentAddressDistrict.SelectedValue;//txtExtraField7.Text.Trim();
        mem_Member.ExtraField8 = ddlPermanentAddressUpozila.SelectedValue;//txtExtraField8.Text.Trim();
        mem_Member.ExtraField9 = txtExtraField9.Text.Trim();
        mem_Member.MemberShipNo = mem_Member.ExtraField10;
        mem_Member.ExtraField11 = txtExtraField11.Text.Trim();
        mem_Member.ExtraField12 = txtExtraField12.Text.Trim();
        mem_Member.ExtraField13 = txtExtraField13.Text.Trim();
        mem_Member.ExtraField14 = txtExtraField14.Text.Trim();
        mem_Member.ExtraField15 = txtExtraField15.Text.Trim();
        mem_Member.ExtraField16 = txtExtraField16.Text.Trim();
        mem_Member.ExtraField17 = txtExtraField17.Text.Trim();
        mem_Member.ExtraField18 = txtExtraField18.Text.Trim();
        mem_Member.ExtraField19 = txtExtraField19.Text.Trim();
        mem_Member.ExtraField20 = txtExtraField20.Text.Trim();
        mem_Member.AddedBy = 1;
        mem_Member.AddedDate = DateTime.Now;
        mem_Member.ModifiedBy = 1;
        mem_Member.ModifiedDate = DateTime.Now;
        mem_Member.Comn_RowStatusID = Int32.Parse(ddlComn_RowStatus.SelectedValue);

        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        {
            mem_Member.MemberShipNo = "";
            mem_Member.MemberShipNoDigit = 0;
        
            mem_Member.Mem_MemberID = Mem_MemberManager.InsertMem_Applied_Member(mem_Member);        
        }
        else
        {
            if (IsMembershipNoDuplicate())
            {
                showAlartMessage("Membership No Duplicate");
                return;
            }
            mem_Member.MemberShipNo = ddlMem_MemberType.SelectedItem.Text.Substring(0, 1) + "/" + decimal.Parse(txtMemberShipNoDigit.Text).ToString("00000");
            mem_Member.MemberShipNoDigit = Int32.Parse(txtMemberShipNoDigit.Text);
            mem_Member.ExtraField10 = DateTime.Today.ToString("yyyyMMddhhmm") + mem_Member.MemberShipNoDigit.ToString();
            
            mem_Member.Mem_MemberID = Mem_MemberManager.InsertMem_Member(mem_Member);
        }
        
        hfMem_MemeberID.Value = mem_Member.Mem_MemberID.ToString();
        txtSearchMembershipNo.Text = mem_Member.MemberShipNo;
        //addEducationalHistory(mem_Member.Mem_MemberID);
        //showAlartMessage("Successfully");
        //if (!HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        //{
        //    Response.Redirect("MembershipInfo.aspx?mem_MemberID=" + mem_Member.Mem_MemberID.ToString());
        //}
        //else
        //{
            //loadMemberData();
            tr_Fees_Details.Visible = false;
            tr_Fees_title.Visible = false;
            tr_History_title.Visible = true;
            tr_History_Details.Visible = true;
            tr_Personal_Details.Visible = false;
            tr_Personal_title.Visible = false;
            btnAdd.Visible = false;
        //}

            //showAlartMessage("Added Successfully");
    }

    private string paidDateReform(string rowDate)
    {
        string datePaid = "";
        if (rowDate.Contains("-"))
        {
            datePaid = rowDate.Split('-')[2] + "-" + rowDate.Split('-')[1] + "-" + rowDate.Split('-')[0];
        }
        else if (rowDate.Contains("/"))
        {
            datePaid = rowDate.Split('/')[2] + "-" + rowDate.Split('/')[1] + "-" + rowDate.Split('/')[0];
        }

        return datePaid;
    }

    private void addEducationalHistory(int memberID)
    {
        Mem_EducationalInfo mem_EducationalInfo = new Mem_EducationalInfo();

        mem_EducationalInfo.Mem_MemberID = memberID;
        mem_EducationalInfo.Comn_GegreeID = Int32.Parse(ddlComn_Gegree.SelectedValue);
        mem_EducationalInfo.InstituteName = txtInstituteName.Text.Trim();
        mem_EducationalInfo.Comn_UniversityID = Int32.Parse(ddlComn_UniversityEducation.SelectedValue);
        mem_EducationalInfo.Comn_DepartmentID = Int32.Parse(ddlSubDivision.SelectedValue);
        mem_EducationalInfo.DegreeTitle = txtDegreeTitle.Text.Trim();
        mem_EducationalInfo.YearOfPassing = txtYearOfPassing.Text.Trim();
        mem_EducationalInfo.Comn_ResultTypeID = Int32.Parse(ddlComn_ResultType.SelectedValue);
        mem_EducationalInfo.Result = txtResult.Text.Trim();
        mem_EducationalInfo.Details = txtDetails.Text.Trim();
        mem_EducationalInfo.AddedBy = getLogin().LoginID;
        mem_EducationalInfo.AddedDate = DateTime.Now;
        mem_EducationalInfo.ModifiedBy = getLogin().LoginID;
        mem_EducationalInfo.ModifiedDate = DateTime.Now;
        mem_EducationalInfo.Comn_RowStatusID = 1;
        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        {
            int resutl = Mem_EducationalInfoManager.InsertMem_Applied_EducationalInfo(mem_EducationalInfo);
            sendMailToNewlyAppliedMember();
            if (txtEmail.Text != "")
            {
                showAlartMessage("Your Temporary Membership no and Password has sent to your email address");
            }
            else
            {
                sendSMS();
                showAlartMessage("Your Temporary Membership no and Password has sent to your email address");
            }
            Response.Redirect("MembershipRegistration.aspx?mem_MemberID=710307" + hfMem_MemeberID.Value+"034438");
        }
        else if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipInfo.aspx"))
        {
            int resutl = Mem_EducationalInfoManager.InsertMem_EducationalInfo(mem_EducationalInfo);
            showAlartMessage("Added Successfully");
            Response.Redirect("MembershipInfo.aspx?mem_MemberID="+hfMem_MemeberID.Value);
        }
        else if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MyProfile.aspx?NewRegistration=1&"))
        {
            int resutl = Mem_EducationalInfoManager.InsertMem_EducationalInfo(mem_EducationalInfo);
            showAlartMessage("Added Successfully");
            loadEducationalHistory();
        }

        
    }

    private void sendSMS()
    {
        
    }

    private void sendMailToNewlyAppliedMember()
    {
        
    }

    private bool IsMembershipNoDuplicate()
    {
        if (txtMemberShipNoDigit.Text == "" || txtMemberShipNoDigit.Text == "0")
        {
            return false;
        }
        string sql = @"
    Select Mem_MemberID from Mem_Member where MemberShipNo ='" + ddlMem_MemberType.SelectedItem.Text.Substring(0, 1) + "/" + decimal.Parse(txtMemberShipNoDigit.Text).ToString("00000") + "'" + (hfMem_MemeberID.Value == "" ? "" : " and Mem_MemberID <> " + hfMem_MemeberID.Value) + @"
";
        if (DatabaseManager.ExecSQL(sql).Tables[0].Rows.Count>0)
        {
            return true;
        }
        
        return false;

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //return;
        if (IsMembershipNoDuplicate())
        {
            showAlartMessage("Membership No Duplicate");
            return;
        }

        //if (ddlMailingAddressDistrict.SelectedValue == "" )
        //{
        //    showAlartMessage("Please select the District  of your Mailing Address");
        //    return;
        //}

        Mem_Member mem_Member = new Mem_Member();
        mem_Member = Mem_MemberManager.GetMem_MemberByID(Int32.Parse(hfMem_MemeberID.Value));
        Mem_Member tempMem_Member = new Mem_Member();
        tempMem_Member.Mem_MemberID = mem_Member.Mem_MemberID;

        tempMem_Member.MemberShipNo = ddlMem_MemberType.SelectedItem.Text.Substring(0, 1) + "/" + decimal.Parse(txtMemberShipNoDigit.Text).ToString("00000");
        tempMem_Member.MemberShipNoDigit = Int32.Parse(txtMemberShipNoDigit.Text);
        tempMem_Member.Mem_MemberTypeID = Int32.Parse(ddlMem_MemberType.SelectedValue);
        tempMem_Member.Name = txtName.Text.Trim();
        tempMem_Member.DateOfBirth = DateTime.Parse(paidDateReform(txtDateOfBirth.Text));
        tempMem_Member.Age = Int32.Parse((txtAge.Text == "" ? "0" : txtAge.Text));
        tempMem_Member.Comn_NationalityID = Int32.Parse(ddlComn_Nationality.SelectedValue);
        tempMem_Member.PlaceOfBrith = txtPlaceOfBrith.Text.Trim();
        tempMem_Member.MailingAddress1 = txtMailingAddress1.Text.Trim();
        tempMem_Member.MailingAddress2 = txtMailingAddress2.Text.Trim();
        tempMem_Member.MailingAddress3 = txtMailingAddress3.Text.Trim();
        tempMem_Member.MailingAddress = txtMailingAddress.Text.Trim();
        tempMem_Member.PermanentAddress = txtPermanentAddress.Text.Trim();
        tempMem_Member.PermanentAddress1 = txtPermanentAddress1.Text.Trim();
        tempMem_Member.PermanentAddress2 = txtPermanentAddress2.Text.Trim();
        tempMem_Member.PermanentAddress3 = txtPermanentAddress3.Text.Trim();
        tempMem_Member.PhoneOffice = txtPhoneOffice.Text.Trim();
        tempMem_Member.PhoneResidence = txtPhoneResidence.Text.Trim();
        tempMem_Member.Mobile = txtMobile.Text.Trim();
        tempMem_Member.Email = txtEmail.Text.Trim();
        tempMem_Member.Fax = txtFax.Text.Trim();
        tempMem_Member.OtherContactInfo = txtOtherContactInfo.Text.Trim();
        tempMem_Member.Comn_GenderID = Int32.Parse(ddlComn_Gender.SelectedValue);
        tempMem_Member.PresentIEBMembershipNo = txtPresentIEBMembershipNo.Text.Trim();
        tempMem_Member.Mem_SubDivisionID = Int32.Parse(ddlMem_SubDivision.SelectedValue);
        tempMem_Member.DeclarationDate = DateTime.Parse(paidDateReform(txtDeclarationDate.Text));
        tempMem_Member.Mem_ApprovedCouncilMeetingID = Int32.Parse(ddlMem_ApprovedCouncilMeeting.SelectedValue);
        tempMem_Member.ScrollNo = Int32.Parse(txtScrollNo.Text);
        tempMem_Member.ReceiptDate = DateTime.Parse(paidDateReform(txtReceiptDate.Text));
        tempMem_Member.CopiesOfCertificates = cbCopiesOfCertificates.Checked;
        tempMem_Member.CopiesOfCertificatesComment = txtCopiesOfCertificatesComment.Text.Trim();
        tempMem_Member.CopiesOfTranscripts = cbCopiesOfTranscripts.Checked;
        tempMem_Member.CopiesOfTranscriptsComment = txtCopiesOfTranscriptsComment.Text.Trim();
        tempMem_Member.PhotoEnclosed = cbPhotoEnclosed.Checked;
        tempMem_Member.ProfessionalRecordEnclosed = cbProfessionalRecordEnclosed.Checked;
        tempMem_Member.ProfessionalRecordEnclosedComment = txtProfessionalRecordEnclosedComment.Text.Trim();
        tempMem_Member.RecomendationOffice = cbRecomendationOffice.Checked;
        tempMem_Member.RecomenDationCommentOffice = txtRecomenDationCommentOffice.Text.Trim();
        tempMem_Member.AgeMembershipSection = txtAgeMembershipSection.Text.Trim();
        tempMem_Member.Education = txtEducation.Text.Trim();
        tempMem_Member.Exprerience = txtExprerience.Text.Trim();
        tempMem_Member.RecomendationMembershipSec = cbRecomendationMembershipSec.Checked;
        tempMem_Member.RecomenDationCommentMembershipSec = txtRecomenDationCommentMembershipSec.Text.Trim();
        tempMem_Member.MembershipSectionEmployeeID = 1;
        tempMem_Member.Comn_StatusID = Int32.Parse(ddlComn_Status.SelectedValue);
        tempMem_Member.MembershipCommiteeMemebershipNo = Int32.Parse(ddlCompanyUpazila.SelectedValue); 
        tempMem_Member.MembershipCommiteeMemebershipTypeID = 1;
        tempMem_Member.PictureURL = mem_Member.PictureURL;
        tempMem_Member.SignatureURL = mem_Member.SignatureURL;
        tempMem_Member.Comn_UniversityID = Int32.Parse(ddlComn_University.SelectedValue);
        tempMem_Member.Comn_DepartmentID = 1;
        tempMem_Member.PassingYear = Int32.Parse(txtPassingYear.Text);
        tempMem_Member.Comn_OfficeID = Int32.Parse(ddlComn_Office.SelectedValue);
        tempMem_Member.Comn_BloodGroup = ddlComn_BloodGroup.SelectedValue;
        tempMem_Member.PassportNo = txtPassportNo.Text.Trim();
        tempMem_Member.NationalIDNo = "";
        tempMem_Member.BirthRegistrationID = "";
        tempMem_Member.ExtraField1 = txtExtraField1.Text.Trim();
        tempMem_Member.ExtraField2 = txtExtraField2.Text.Trim();
        tempMem_Member.ExtraField3 = txtExtraField3.Text.Trim();
        tempMem_Member.ExtraField4 = txtExtraField4.Text.Trim();
        tempMem_Member.ExtraField5 = ddlMailingAddressDistrict.SelectedValue;//txtExtraField5.Text.Trim();
        tempMem_Member.ExtraField6 = ddlMailingAddressUpozila.SelectedValue;//txtExtraField6.Text.Trim();
        tempMem_Member.ExtraField7 = ddlPermanentAddressDistrict.SelectedValue;//txtExtraField7.Text.Trim();
        tempMem_Member.ExtraField8 = ddlPermanentAddressUpozila.SelectedValue;//txtExtraField8.Text.Trim();
        tempMem_Member.ExtraField9 = txtExtraField9.Text.Trim();
        tempMem_Member.ExtraField10 = mem_Member.ExtraField10;
        tempMem_Member.ExtraField11 = txtExtraField11.Text.Trim();
        tempMem_Member.ExtraField12 = txtExtraField12.Text.Trim();
        tempMem_Member.ExtraField13 = txtExtraField13.Text.Trim();
        tempMem_Member.ExtraField14 = txtExtraField14.Text.Trim();
        tempMem_Member.ExtraField15 = txtExtraField15.Text.Trim();
        tempMem_Member.ExtraField16 = txtExtraField16.Text.Trim();
        tempMem_Member.ExtraField17 = txtExtraField17.Text.Trim();
        tempMem_Member.ExtraField18 = txtExtraField18.Text.Trim();
        tempMem_Member.ExtraField19 = txtExtraField19.Text.Trim();
        tempMem_Member.ExtraField20 = txtExtraField20.Text.Trim();
        tempMem_Member.AddedBy = mem_Member.AddedBy;
        tempMem_Member.AddedDate = mem_Member.AddedDate;
        tempMem_Member.ModifiedBy = getLogin().LoginID;
        tempMem_Member.ModifiedDate = DateTime.Now;
        tempMem_Member.Comn_RowStatusID = Int32.Parse(ddlComn_RowStatus.SelectedValue);


        //if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
        //{
        //    bool result = Mem_MemberManager.UpdateMem_Applied_Member(tempMem_Member);
        //}
        //else
        //{
            bool result = Mem_MemberManager.UpdateMem_Member(tempMem_Member);
        //}

            updateProfessionalRecord();
        showAlartMessage("Information updated Successfully");
    }

    private void updateProfessionalRecord()
    {
        string sql = "Delete Mem_ProfessionalInfo where Mem_MemberID=" + hfMem_MemeberID.Value+@";
                        ";
        if (txt1From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           ("+hfMem_MemeberID.Value+@"--<Mem_MemberID, int,>
           ,'"+txt1From.Text+@"'--<FromDate, nvarchar(50),>
           ,'"+txt1To.Text+@"'--<ToDate, nvarchar(50),>
           ,'"+txt1Designation.Text+@"'--<Designation, nvarchar(100),>
           ,'"+txt1Employer.Text+@"'--<Employer, nvarchar(100),>
           ,'"+txt1JobDescription.Text+@"'--<Details, ntext,>
           ,"+getLogin().LoginID+@"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        if (txt2From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + txt2From.Text + @"'--<FromDate, nvarchar(50),>
           ,'" + txt2To.Text + @"'--<ToDate, nvarchar(50),>
           ,'" + txt2Designation.Text + @"'--<Designation, nvarchar(100),>
           ,'" + txt2Employer.Text + @"'--<Employer, nvarchar(100),>
           ,'" + txt2JobDescription.Text + @"'--<Details, ntext,>
           ," + getLogin().LoginID + @"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        if (txt3From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + txt3From.Text + @"'--<FromDate, nvarchar(50),>
           ,'" + txt3To.Text + @"'--<ToDate, nvarchar(50),>
           ,'" + txt3Designation.Text + @"'--<Designation, nvarchar(100),>
           ,'" + txt3Employer.Text + @"'--<Employer, nvarchar(100),>
           ,'" + txt3JobDescription.Text + @"'--<Details, ntext,>
           ," + getLogin().LoginID + @"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        if (txt4From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + txt4From.Text + @"'--<FromDate, nvarchar(50),>
           ,'" + txt4To.Text + @"'--<ToDate, nvarchar(50),>
           ,'" + txt4Designation.Text + @"'--<Designation, nvarchar(100),>
           ,'" + txt4Employer.Text + @"'--<Employer, nvarchar(100),>
           ,'" + txt4JobDescription.Text + @"'--<Details, ntext,>
           ," + getLogin().LoginID + @"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        if (txt5From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + txt5From.Text + @"'--<FromDate, nvarchar(50),>
           ,'" + txt5To.Text + @"'--<ToDate, nvarchar(50),>
           ,'" + txt5Designation.Text + @"'--<Designation, nvarchar(100),>
           ,'" + txt5Employer.Text + @"'--<Employer, nvarchar(100),>
           ,'" + txt5JobDescription.Text + @"'--<Details, ntext,>
           ," + getLogin().LoginID + @"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        if (txt6From.Text.Trim() != "")
        {
            sql += @"
INSERT INTO [Mem_ProfessionalInfo]
           ([Mem_MemberID]
           ,[FromDate]
           ,[ToDate]
           ,[Designation]
           ,[Employer]
           ,[Details]
           ,[AddedBy]
           ,[AddedDate]
           ,[UpdatedBy]
           ,[UpdatedDate]
           ,[Comn_RowStatusID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + txt6From.Text + @"'--<FromDate, nvarchar(50),>
           ,'" + txt6To.Text + @"'--<ToDate, nvarchar(50),>
           ,'" + txt6Designation.Text + @"'--<Designation, nvarchar(100),>
           ,'" + txt6Employer.Text + @"'--<Employer, nvarchar(100),>
           ,'" + txt6JobDescription.Text + @"'--<Details, ntext,>
           ," + getLogin().LoginID + @"--<AddedBy, int,>
           ,GETDATE()--<AddedDate, datetime,>
           ," + getLogin().LoginID + @"--<UpdatedBy, int,>
           ,GETDATE()--<UpdatedDate, datetime,>
           ,1--<Comn_RowStatusID, int,>
);
";
        }

        DatabaseManager.ExecSQL(sql);
    }

    private void loadProfessionalRecord()
    {
        string sql = @"
SELECT [Mem_ProfessionalInfoID]
      ,[Mem_MemberID]
      ,[FromDate]
      ,[ToDate]
      ,[Designation]
      ,[Employer]
      ,[Details]
      ,[AddedBy]
      ,[AddedDate]
      ,[UpdatedBy]
      ,[UpdatedDate]
      ,[Comn_RowStatusID]
  FROM [Mem_ProfessionalInfo]
  where [Mem_MemberID]="+hfMem_MemeberID.Value+@"
";

        DataSet ds = DatabaseManager.ExecSQL(sql);

        if (ds.Tables[0].Rows.Count >= 1)
        {
            txt1From.Text = ds.Tables[0].Rows[0]["FromDate"].ToString();
            txt1To.Text = ds.Tables[0].Rows[0]["ToDate"].ToString();
            txt1Designation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
            txt1Employer.Text = ds.Tables[0].Rows[0]["Employer"].ToString();
            txt1JobDescription.Text = ds.Tables[0].Rows[0]["Details"].ToString();
        }

        if (ds.Tables[0].Rows.Count >= 2)
        {
            txt2From.Text = ds.Tables[0].Rows[1]["FromDate"].ToString();
            txt2To.Text = ds.Tables[0].Rows[1]["ToDate"].ToString();
            txt2Designation.Text = ds.Tables[0].Rows[1]["Designation"].ToString();
            txt2Employer.Text = ds.Tables[0].Rows[1]["Employer"].ToString();
            txt2JobDescription.Text = ds.Tables[0].Rows[1]["Details"].ToString();
        }

        if (ds.Tables[0].Rows.Count >=3)
        {
            txt3From.Text = ds.Tables[0].Rows[2]["FromDate"].ToString();
            txt3To.Text = ds.Tables[0].Rows[2]["ToDate"].ToString();
            txt3Designation.Text = ds.Tables[0].Rows[2]["Designation"].ToString();
            txt3Employer.Text = ds.Tables[0].Rows[2]["Employer"].ToString();
            txt3JobDescription.Text = ds.Tables[0].Rows[2]["Details"].ToString();
        }

        if (ds.Tables[0].Rows.Count >= 4)
        {
            txt4From.Text = ds.Tables[0].Rows[3]["FromDate"].ToString();
            txt4To.Text = ds.Tables[0].Rows[3]["ToDate"].ToString();
            txt4Designation.Text = ds.Tables[0].Rows[3]["Designation"].ToString();
            txt4Employer.Text = ds.Tables[0].Rows[3]["Employer"].ToString();
            txt4JobDescription.Text = ds.Tables[0].Rows[3]["Details"].ToString();
        }

        if (ds.Tables[0].Rows.Count >= 5)
        {
            txt5From.Text = ds.Tables[0].Rows[4]["FromDate"].ToString();
            txt5To.Text = ds.Tables[0].Rows[4]["ToDate"].ToString();
            txt5Designation.Text = ds.Tables[0].Rows[4]["Designation"].ToString();
            txt5Employer.Text = ds.Tables[0].Rows[4]["Employer"].ToString();
            txt5JobDescription.Text = ds.Tables[0].Rows[4]["Details"].ToString();
        }

        if (ds.Tables[0].Rows.Count >= 6)
        {
            txt6From.Text = ds.Tables[0].Rows[5]["FromDate"].ToString();
            txt6To.Text = ds.Tables[0].Rows[5]["ToDate"].ToString();
            txt6Designation.Text = ds.Tables[0].Rows[5]["Designation"].ToString();
            txt6Employer.Text = ds.Tables[0].Rows[5]["Employer"].ToString();
            txt6JobDescription.Text = ds.Tables[0].Rows[5]["Details"].ToString();
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMemberShipNo.Text = "";
        txtMemberShipNoDigit.Text = "";
        ddlMem_MemberType.SelectedIndex = 0;
        txtName.Text = "";
        txtDateOfBirth.Text = "";
        txtAge.Text = "";
        ddlComn_Nationality.SelectedIndex = 0;
        txtPlaceOfBrith.Text = "";
        txtMailingAddress1.Text = "";
        txtMailingAddress2.Text = "";
        txtMailingAddress3.Text = "";
        txtMailingAddress.Text = "";
        txtPermanentAddress.Text = "";
        txtPermanentAddress1.Text = "";
        txtPermanentAddress2.Text = "";
        txtPermanentAddress3.Text = "";
        txtPhoneOffice.Text = "";
        txtPhoneResidence.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";
        txtOtherContactInfo.Text = "";
        ddlComn_Gender.SelectedIndex = 0;
        txtPresentIEBMembershipNo.Text = "";
        ddlMem_SubDivision.SelectedIndex = 0;
        txtDeclarationDate.Text = "";
        ddlMem_ApprovedCouncilMeeting.SelectedIndex = 0;
        txtScrollNo.Text = "";
        txtReceiptDate.Text = "";
        cbCopiesOfCertificates.Checked = false;
        txtCopiesOfCertificatesComment.Text = "";
        cbCopiesOfTranscripts.Checked = false;
        txtCopiesOfTranscriptsComment.Text = "";
        cbPhotoEnclosed.Checked = false;
        cbProfessionalRecordEnclosed.Checked = false;
        txtProfessionalRecordEnclosedComment.Text = "";
        cbRecomendationOffice.Checked = false;
        txtRecomenDationCommentOffice.Text = "";
        txtAgeMembershipSection.Text = "";
        txtEducation.Text = "";
        txtExprerience.Text = "";
        cbRecomendationMembershipSec.Checked = false;
        txtRecomenDationCommentMembershipSec.Text = "";
        ddlMembershipSectionEmployee.SelectedIndex = 0;
        ddlComn_Status.SelectedIndex = 0;
        txtMembershipCommiteeMemebershipNo.Text = "";
        ddlMembershipCommiteeMemebershipType.SelectedIndex = 0;
        txtPictureURL.Text = "";
        txtSignatureURL.Text = "";
        ddlComn_University.SelectedIndex = 0;
        ddlComn_Department.SelectedIndex = 0;
        txtPassingYear.Text = "";
        ddlComn_Office.SelectedIndex = 0;
        //txtComn_BloodGroup.Text = "";
        txtPassportNo.Text = "";
        ddlNational.SelectedIndex = 0;
        ddlBirthRegistration.SelectedIndex = 0;
        txtExtraField1.Text = "";
        txtExtraField2.Text = "";
        txtExtraField3.Text = "";
        txtExtraField4.Text = "";
        txtExtraField5.Text = "";
        txtExtraField6.Text = "";
        txtExtraField7.Text = "";
        txtExtraField8.Text = "";
        txtExtraField9.Text = "";
        txtExtraField10.Text = "";
        txtExtraField11.Text = "";
        txtExtraField12.Text = "";
        txtExtraField13.Text = "";
        txtExtraField14.Text = "";
        txtExtraField15.Text = "";
        txtExtraField16.Text = "";
        txtExtraField17.Text = "";
        txtExtraField18.Text = "";
        txtExtraField19.Text = "";
        txtExtraField20.Text = "";
        ddlComn_RowStatus.SelectedIndex = 0;
    }
    private void showMem_MemberData()
    {
        Mem_Member mem_Member = new Mem_Member();
        
            //if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("MembershipRegistration.aspx"))
            //{
            //    mem_Member = Mem_MemberManager.GetMem_Applied_MemberByID(Int32.Parse(hfMem_MemeberID.Value));
            //}
            //else
            //{
                mem_Member = Mem_MemberManager.GetMem_MemberByID(Int32.Parse(hfMem_MemeberID.Value));
            //}
        
        if (mem_Member == null)
        {
            showAlartMessage("No Member found");
            btnUpdate.Visible = false;
            return;
        }

        if (mem_Member.MemberShipNo.Trim() =="" && Request.QueryString["NewRegistration"] == null)
        {
            Response.Redirect("MyProfile.aspx?NewRegistration=1&Mem_MemberID=710307" + hfMem_MemeberID.Value + "034438");
        }

        txtMemberShipNo.Text = mem_Member.MemberShipNo;
        txtMemberShipNoDigit.Text = mem_Member.MemberShipNoDigit.ToString();
        ddlMem_MemberType.SelectedValue = mem_Member.Mem_MemberTypeID.ToString();
        txtName.Text = mem_Member.Name;
        txtDateOfBirth.Text = mem_Member.DateOfBirth.ToString("dd-MM-yyyy");
        txtAge.Text = CommonManager.GetAge(mem_Member.DateOfBirth).ToString();//((DateTime.Today - mem_Member.DateOfBirth).TotalDays / 365).ToString().Substring(0, ((DateTime.Today - mem_Member.DateOfBirth).TotalDays / 365).ToString().IndexOf('.'));
        ddlComn_Nationality.SelectedValue = mem_Member.Comn_NationalityID.ToString();
        txtPlaceOfBrith.Text = mem_Member.PlaceOfBrith;
        txtMailingAddress1.Text = mem_Member.MailingAddress1;
        txtMailingAddress2.Text = mem_Member.MailingAddress2;
        txtMailingAddress3.Text = mem_Member.MailingAddress3;
        txtMailingAddress.Text = mem_Member.MailingAddress;
        txtPermanentAddress.Text = mem_Member.PermanentAddress;
        txtPermanentAddress1.Text = mem_Member.PermanentAddress1;
        txtPermanentAddress2.Text = mem_Member.PermanentAddress2;
        txtPermanentAddress3.Text = mem_Member.PermanentAddress3;
        txtPhoneOffice.Text = mem_Member.PhoneOffice;
        txtPhoneResidence.Text = mem_Member.PhoneResidence;
        txtMobile.Text = mem_Member.Mobile;
        txtEmail.Text = mem_Member.Email;
        txtFax.Text = mem_Member.Fax;
        txtOtherContactInfo.Text = mem_Member.OtherContactInfo;
        ddlComn_Gender.SelectedValue = mem_Member.Comn_GenderID.ToString();
        txtPresentIEBMembershipNo.Text = mem_Member.PresentIEBMembershipNo;
        ddlMem_SubDivision.SelectedValue = mem_Member.Mem_SubDivisionID.ToString();
        ddlMem_Division.SelectedValue = DatabaseManager.ExecSQL("select Mem_DivisionID from Mem_SubDivision where Mem_SubDivisionID=" + mem_Member.Mem_SubDivisionID.ToString()).Tables[0].Rows[0][0].ToString();
        txtDeclarationDate.Text = mem_Member.DeclarationDate.ToString("dd-MM-yyyy");
        ddlMem_ApprovedCouncilMeeting.SelectedValue = mem_Member.Mem_ApprovedCouncilMeetingID.ToString();
        txtScrollNo.Text = mem_Member.ScrollNo.ToString();
        txtReceiptDate.Text = mem_Member.ReceiptDate.ToString("dd-MM-yyyy");
        cbCopiesOfCertificates.Checked = false;
        txtCopiesOfCertificatesComment.Text = mem_Member.CopiesOfCertificatesComment;
        cbCopiesOfTranscripts.Checked = mem_Member.CopiesOfTranscripts;
        txtCopiesOfTranscriptsComment.Text = mem_Member.CopiesOfTranscriptsComment;
        cbPhotoEnclosed.Checked = false;
        cbProfessionalRecordEnclosed.Checked = false;
        txtProfessionalRecordEnclosedComment.Text = mem_Member.ProfessionalRecordEnclosedComment;
        cbRecomendationOffice.Checked = false;
        txtRecomenDationCommentOffice.Text = mem_Member.RecomenDationCommentOffice;
        txtAgeMembershipSection.Text = mem_Member.AgeMembershipSection;
        txtEducation.Text = mem_Member.Education;
        txtExprerience.Text = mem_Member.Exprerience;
        cbRecomendationMembershipSec.Checked = false;
        txtRecomenDationCommentMembershipSec.Text = mem_Member.RecomenDationCommentMembershipSec;
        ddlMembershipSectionEmployee.SelectedValue = mem_Member.MembershipSectionEmployeeID.ToString();
        ddlComn_Status.SelectedValue = mem_Member.Comn_StatusID.ToString();
        //txtMembershipCommiteeMemebershipNo.Text = mem_Member.MembershipCommiteeMemebershipNo.ToString();
        loadUpajila(mem_Member.MembershipCommiteeMemebershipNo);
        ddlMembershipCommiteeMemebershipType.SelectedValue = mem_Member.MembershipCommiteeMemebershipTypeID.ToString();
        //txtPictureURL.Text = mem_Member.PictureURL;
        //if (mem_Member.PictureURL.Trim() == "")
        //{
        //    mem_Member.PictureURL = mem_Member.MemberShipNo.Replace("/","-")+".jpg" ;
        //}
        string dirURL = "../MembersArea/MemberPicture/";
        //mem_Member.PictureURL = CommonManager.getPrictureFileName(MapPath(dirURL), mem_Member.MemberShipNo, mem_Member.PresentIEBMembershipNo);
        imgMemberPicture.ImageUrl = "../MembersArea/MemberPicture/" + mem_Member.PictureURL;
        txtSignatureURL.Text = mem_Member.SignatureURL;
        ddlComn_University.SelectedValue = mem_Member.Comn_UniversityID.ToString();
        ddlComn_Department.SelectedValue = mem_Member.Comn_DepartmentID.ToString();
        txtPassingYear.Text = mem_Member.PassingYear.ToString();
        ddlComn_Office.SelectedValue = mem_Member.Comn_OfficeID.ToString();
        ddlComn_BloodGroup.SelectedValue = mem_Member.Comn_BloodGroup.ToString();
        txtPassportNo.Text = mem_Member.PassportNo;
        ddlNational.SelectedValue = mem_Member.NationalIDNo.ToString();
        ddlBirthRegistration.SelectedValue = mem_Member.BirthRegistrationID.ToString();
        txtExtraField1.Text = mem_Member.ExtraField1;
        txtExtraField2.Text = mem_Member.ExtraField2;
        txtExtraField3.Text = mem_Member.ExtraField3;
        txtExtraField4.Text = mem_Member.ExtraField4;
        ddlMailingAddressDistrict.SelectedValue = mem_Member.ExtraField5;
        ddlMailingAddressDistrictt_SelectedIndexChanged(this, new EventArgs());
        ddlMailingAddressUpozila.SelectedValue = mem_Member.ExtraField6;
        //txtExtraField5.Text = mem_Member.ExtraField5;
        //txtExtraField6.Text = mem_Member.ExtraField6;
        txtExtraField7.Text = mem_Member.ExtraField7;
        //txtExtraField8.Text = mem_Member.ExtraField8;
        ddlPermanentAddressDistrict.SelectedValue = mem_Member.ExtraField8;
        ddlPermanentAddressDistrict_SelectedIndexChanged(this, new EventArgs());
        ddlPermanentAddressUpozila.SelectedValue = mem_Member.ExtraField9;
        //txtExtraField9.Text = mem_Member.ExtraField9;
        txtExtraField10.Text = mem_Member.ExtraField10;
        txtExtraField11.Text = mem_Member.ExtraField11;
        txtExtraField12.Text = mem_Member.ExtraField12;
        txtExtraField13.Text = mem_Member.ExtraField13;
        txtExtraField14.Text = mem_Member.ExtraField14;
        txtExtraField15.Text = mem_Member.ExtraField15;
        txtExtraField16.Text = mem_Member.ExtraField16;
        txtExtraField17.Text = mem_Member.ExtraField17;
        txtExtraField18.Text = mem_Member.ExtraField18;
        txtExtraField19.Text = mem_Member.ExtraField19;
        txtExtraField20.Text = mem_Member.ExtraField20;
        ddlComn_RowStatus.SelectedValue = mem_Member.Comn_RowStatusID.ToString();
    }

    private void loadUpajila(int upajilaID)
    {
        if (upajilaID != 0)
        {
            string sql = "Select * from Comn_Upojela where UpojelaID="+upajilaID;
            DataSet ds = DatabaseManager.ExecSQL(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCompnayDistrict.SelectedValue = ds.Tables[0].Rows[0]["DistrictID"].ToString();
                ddlCompnayDistrict_SelectedIndexChanged(this, new EventArgs());
                ddlCompanyUpazila.SelectedValue = upajilaID.ToString();
            }
        }
    }
    private void loadMem_MemberType()
    {
        //ListItem li = new ListItem("Select Membership Type", "0");
        //ddlMem_MemberType.Items.Add(li);

        List<Mem_MemberType> mem_MemberTypes = new List<Mem_MemberType>();
        mem_MemberTypes = Mem_MemberTypeManager.GetAllMem_MemberTypes();
        foreach (Mem_MemberType mem_MemberType in mem_MemberTypes)
        {
            ListItem item = new ListItem(mem_MemberType.Mem_MemberTypeName.ToString(), mem_MemberType.Mem_MemberTypeID.ToString());
            ddlMem_MemberType.Items.Add(item);
        }
    }
    private void loadComn_Nationality()
    {
        //ListItem li = new ListItem("Select Nationality", "0");
        //ddlComn_Nationality.Items.Add(li);

        List<Comn_Nationality> comn_Nationalities = new List<Comn_Nationality>();
        comn_Nationalities = Comn_NationalityManager.GetAllComn_Nationalities();
        foreach (Comn_Nationality comn_Nationality in comn_Nationalities)
        {
            ListItem item = new ListItem(comn_Nationality.Comn_NationalityName.ToString(), comn_Nationality.Comn_NationalityID.ToString());
            ddlComn_Nationality.Items.Add(item);
        }
    }
    private void loadComn_Gender()
    {
        //ListItem li = new ListItem("Select Gender", "0");
        //ddlComn_Gender.Items.Add(li);

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
        ListItem li = new ListItem("Select Sub Division", "0");
        ListItem li1 = new ListItem("Select Department", "0");
        ddlMem_SubDivision.Items.Add(li);
        ddlSubDivision.Items.Add(li1);

        List<Mem_SubDivision> mem_SubDivisions = new List<Mem_SubDivision>();
        mem_SubDivisions = Mem_SubDivisionManager.GetAllMem_SubDivisions();
        foreach (Mem_SubDivision mem_SubDivision in mem_SubDivisions)
        {
            ListItem item = new ListItem(mem_SubDivision.Mem_SubDivisionName.ToString() + "------(" + mem_SubDivision.FullName + ")", mem_SubDivision.Mem_SubDivisionID.ToString());
            ListItem item1 = new ListItem(mem_SubDivision.Mem_SubDivisionName.ToString() + "-------(" + mem_SubDivision.FullName + ")", mem_SubDivision.Mem_SubDivisionID.ToString());
            ddlMem_SubDivision.Items.Add(item);
            ddlSubDivision.Items.Add(item1);
        }
        ddlSubDivision.SelectedValue = "22";
    }

    //    private int uplaodFile()
    //    {
    //        if (fupTaskFile.HasFile)
    //        {
    //            #region fileUpload
    //            string strPath = string.Empty;
    //            string dirURL = "~/files/file/";
    //            if (!Directory.Exists(MapPath(dirURL)))
    //                Directory.CreateDirectory(MapPath(dirURL));

    //            getFileName fileName = new getFileName(fupTaskFile.FileName, MapPath(dirURL));
    //            strPath = MapPath(dirURL + "/" + fileName.FileName);
    //            fupTaskFile.SaveAs(strPath);
    //            #endregion
    //            string sql = @"
    //                        INSERT INTO [PM_CommentFile]
    //                                   ([FileName]
    //                                   ,[ExtraField1]
    //                                   ,[ExtraField2])
    //                             VALUES
    //                                   ('" + fileName.FileName + @"'
    //                                   ,''
    //                                   ,'');
    //                        select SCOPE_IDENTITY() ;
    //                        ";
    //            return int.Parse(CommonManager.SQLExec(sql).Tables[0].Rows[0][0].ToString());
    //        }
    //        return 0;
    //    }

    private void loadMem_Division()
    {
        ListItem li = new ListItem("Select Division", "0");
        ddlMem_Division.Items.Add(li);

        List<Mem_Division> mem_Divisions = new List<Mem_Division>();
        mem_Divisions = Mem_DivisionManager.GetAllMem_Divisions();
        foreach (Mem_Division mem_Division in mem_Divisions)
        {
            ListItem item = new ListItem(mem_Division.Mem_DivisionName.ToString(), mem_Division.Mem_DivisionID.ToString());
            ddlMem_Division.Items.Add(item);
        }
    }

    private void loadMem_ApprovedCouncilMeeting()
    {
        //ListItem li = new ListItem("Select Meeting No", "0");
        //ddlMem_ApprovedCouncilMeeting.Items.Add(li);

        List<Mem_ApprovedCouncilMeeting> mem_ApprovedCouncilMeetings = new List<Mem_ApprovedCouncilMeeting>();
        mem_ApprovedCouncilMeetings = Mem_ApprovedCouncilMeetingManager.GetAllMem_ApprovedCouncilMeetings();
        foreach (Mem_ApprovedCouncilMeeting mem_ApprovedCouncilMeeting in mem_ApprovedCouncilMeetings)
        {
            ListItem item = new ListItem(mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingName.ToString(), mem_ApprovedCouncilMeeting.Mem_ApprovedCouncilMeetingID.ToString());
            ddlMem_ApprovedCouncilMeeting.Items.Add(item);
        }

        ddlMem_ApprovedCouncilMeeting.SelectedValue = "3";
    }

    private void loadComn_Status()
    {
        //ListItem li = new ListItem("Select Status", "0");
        //ddlComn_Status.Items.Add(li);

        List<Comn_Status> comn_Statuss = new List<Comn_Status>();
        comn_Statuss = Comn_StatusManager.GetAllComn_Statuss();
        foreach (Comn_Status comn_Status in comn_Statuss)
        {
            ListItem item = new ListItem(comn_Status.Comn_StatusName.ToString(), comn_Status.Comn_StatusID.ToString());
            ddlComn_Status.Items.Add(item);
        }
    }

    private void loadComn_University()
    {
        ListItem li = new ListItem("Select Institution", "0");
        ListItem li1 = new ListItem("Select Institution", "0");
        ddlComn_University.Items.Add(li);
        ddlComn_UniversityEducation.Items.Add(li1);

        List<Comn_University> comn_Universities = new List<Comn_University>();
        comn_Universities = Comn_UniversityManager.GetAllComn_Universities();
        foreach (Comn_University comn_University in comn_Universities)
        {
            ListItem item = new ListItem(comn_University.Comn_UniversityName.ToString(), comn_University.Comn_UniversityID.ToString());
            ListItem item1 = new ListItem(comn_University.Comn_UniversityName.ToString(), comn_University.Comn_UniversityID.ToString());
            ddlComn_University.Items.Add(item);
            ddlComn_UniversityEducation.Items.Add(item1);
        }
    }

    private void loadComn_Office()
    {
        ListItem li = new ListItem("Select Center / Sub Center", "0");
        ddlComn_Office.Items.Add(li);

        List<Comn_Office> comn_Offices = new List<Comn_Office>();
        comn_Offices = Comn_OfficeManager.GetAllComn_Offices().FindAll(x => x.Comm_OfficeTypeID == 4);
        foreach (Comn_Office comn_Office in comn_Offices)
        {
            ListItem item = new ListItem(comn_Office.Comn_OfficeName.ToString(), comn_Office.Comn_OfficeID.ToString());
            ddlComn_Office.Items.Add(item);
        }
    }

    private void loadComn_RowStatus()
    {
        //ListItem li = new ListItem("Select Row Status", "0");
        //ddlComn_RowStatus.Items.Add(li);

        List<Comn_RowStatus> comn_RowStatuss = new List<Comn_RowStatus>();
        comn_RowStatuss = Comn_RowStatusManager.GetAllComn_RowStatuss();
        foreach (Comn_RowStatus comn_RowStatus in comn_RowStatuss)
        {
            ListItem item = new ListItem(comn_RowStatus.Comn_RowStatusName.ToString(), comn_RowStatus.Comn_RowStatusID.ToString());
            ddlComn_RowStatus.Items.Add(item);
        }
    }
    protected void ddlMem_Division_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMem_Division.SelectedValue != "0")
        {
            loadSubDivision();
        }
    }

    private void loadSubDivision()
    {
        ddlMem_SubDivision.Items.Clear();
        ListItem li = new ListItem("Select Sub Division", "0");
        ddlMem_SubDivision.Items.Add(li);

        List<Mem_SubDivision> mem_SubDivisions = new List<Mem_SubDivision>();
        mem_SubDivisions = Mem_SubDivisionManager.GetAllMem_SubDivisions().FindAll(x => (x.Mem_DivisionID == int.Parse(ddlMem_Division.SelectedValue)));
        foreach (Mem_SubDivision mem_SubDivision in mem_SubDivisions)
        {
            ListItem item = new ListItem(mem_SubDivision.Mem_SubDivisionName.ToString(), mem_SubDivision.Mem_SubDivisionID.ToString());
            ddlMem_SubDivision.Items.Add(item);
        }

       
    }


    private void loadComn_ResultType()
    {
        ListItem li = new ListItem("Select Result System", "0");
        ddlComn_ResultType.Items.Add(li);

        List<Comn_ResultType> comn_ResultTypes = new List<Comn_ResultType>();
        comn_ResultTypes = Comn_ResultTypeManager.GetAllComn_ResultTypes();
        foreach (Comn_ResultType comn_ResultType in comn_ResultTypes)
        {
            ListItem item = new ListItem(comn_ResultType.Comn_ResultTypeName.ToString(), comn_ResultType.Comn_ResultTypeID.ToString());
            ddlComn_ResultType.Items.Add(item);
        }
    }

    private void loadComn_Gegree()
    {
        ListItem li = new ListItem("Select Gegree...", "0");
        ddlComn_Gegree.Items.Add(li);

        List<Comn_Gegree> comn_Gegrees = new List<Comn_Gegree>();
        comn_Gegrees = Comn_GegreeManager.GetAllComn_Gegrees();
        foreach (Comn_Gegree comn_Gegree in comn_Gegrees)
        {
            //if (comn_Gegree.Comn_GegreeID ==3)
            //{
                ListItem item = new ListItem(comn_Gegree.Comn_GegreeName.ToString(), comn_Gegree.Comn_GegreeID.ToString());
                ddlComn_Gegree.Items.Add(item);
            //}
        }
    }
    protected void btnEducationalInfoAdd_Click(object sender, EventArgs e)
    {
        addEducationalHistory(int.Parse(hfMem_MemeberID.Value));
    }
    protected void btnEducationalInfoUpdate_Click(object sender, EventArgs e)
    {
        Mem_EducationalInfo mem_EducationalInfo = new Mem_EducationalInfo();
        mem_EducationalInfo = Mem_EducationalInfoManager.GetMem_EducationalInfoByID(Int32.Parse(Request.QueryString["mem_EducationalInfoID"]));
        Mem_EducationalInfo tempMem_EducationalInfo = new Mem_EducationalInfo();
        tempMem_EducationalInfo.Mem_EducationalInfoID = mem_EducationalInfo.Mem_EducationalInfoID;

        tempMem_EducationalInfo.Mem_MemberID = 0;
        tempMem_EducationalInfo.Comn_GegreeID = Int32.Parse(ddlComn_Gegree.SelectedValue);
        tempMem_EducationalInfo.InstituteName = txtInstituteName.Text.Trim();
        tempMem_EducationalInfo.Comn_UniversityID = Int32.Parse(ddlComn_UniversityEducation.SelectedValue);
        tempMem_EducationalInfo.Comn_DepartmentID = Int32.Parse(ddlSubDivision.SelectedValue);
        tempMem_EducationalInfo.DegreeTitle = txtDegreeTitle.Text.Trim();
        tempMem_EducationalInfo.YearOfPassing = txtYearOfPassing.Text.Trim();
        tempMem_EducationalInfo.Comn_ResultTypeID = Int32.Parse(ddlComn_ResultType.SelectedValue);
        tempMem_EducationalInfo.Result = txtResult.Text.Trim();
        tempMem_EducationalInfo.Details = txtDetails.Text.Trim();
        tempMem_EducationalInfo.AddedBy = mem_EducationalInfo.AddedBy;
        tempMem_EducationalInfo.AddedDate = mem_EducationalInfo.AddedDate;
        tempMem_EducationalInfo.ModifiedBy = 1;
        tempMem_EducationalInfo.ModifiedDate = DateTime.Now;
        tempMem_EducationalInfo.Comn_RowStatusID = Int32.Parse(ddlComn_RowStatus.SelectedValue);
        bool result = Mem_EducationalInfoManager.UpdateMem_EducationalInfo(tempMem_EducationalInfo);
    }

    private void showMem_EducationalInfoData(int mem_EducationalInfoID)
    {
        Mem_EducationalInfo mem_EducationalInfo = new Mem_EducationalInfo();
        mem_EducationalInfo = Mem_EducationalInfoManager.GetMem_EducationalInfoByID(mem_EducationalInfoID);

        ddlComn_Gegree.SelectedValue = mem_EducationalInfo.Comn_GegreeID.ToString();
        txtInstituteName.Text = mem_EducationalInfo.InstituteName;
        ddlComn_University.SelectedValue = mem_EducationalInfo.Comn_UniversityID.ToString();
        ddlComn_Department.SelectedValue = mem_EducationalInfo.Comn_DepartmentID.ToString();
        txtDegreeTitle.Text = mem_EducationalInfo.DegreeTitle;
        txtYearOfPassing.Text = mem_EducationalInfo.YearOfPassing;
        ddlComn_ResultType.SelectedValue = mem_EducationalInfo.Comn_ResultTypeID.ToString();
        txtResult.Text = mem_EducationalInfo.Result;
        txtDetails.Text = mem_EducationalInfo.Details;

        ddlComn_RowStatus.SelectedValue = mem_EducationalInfo.Comn_RowStatusID.ToString();
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        showMem_EducationalInfoData(id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = Mem_EducationalInfoManager.DeleteMem_EducationalInfo(Convert.ToInt32(linkButton.CommandArgument));
        showMem_EducationalInfoGrid();
    }

    private void showMem_EducationalInfoGrid()
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchMembershipNo.Text.Trim().Contains("-"))
        {
            txtSearchMembershipNo.Text = txtSearchMembershipNo.Text.Trim().Replace("-","/");
        }

        txtSearchMembershipNo.Text = txtSearchMembershipNo.Text.Trim().Split('/')[0] +"/"+ decimal.Parse(txtSearchMembershipNo.Text.Trim().Split('/')[1]).ToString("00000");

        lblMessage.Text = "";
        string sql = @"
                Select Mem_MemberID from Mem_Member where MemberShipNo='" + txtSearchMembershipNo.Text.Trim() + @"';
                ";

        try
        {
            DataSet ds = DatabaseManager.ExecSQL(sql);
            hfMem_MemeberID.Value = ds.Tables[0].Rows[0][0].ToString();
            loadMemberData();
            loadRoleWiseControl();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "No member!!";
        }
    }
    protected void btnAddEducationalInfoShow_Click(object sender, EventArgs e)
    {
        tblAddEducationalInfoShow.Visible = true;
        btnAddEducationalInfoShow.Visible = false;
    }
    protected void btnEducationalInfoAddLeter_Click(object sender, EventArgs e)
    {
        tblAddEducationalInfoShow.Visible = false;
        btnAddEducationalInfoShow.Visible = true;
    }
    protected void ddlCompnayDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCompanyUpazila.Items.Clear();
        ddlCompanyUpazila.Items.Add(new ListItem("Select","0"));
        if (ddlCompnayDistrict.SelectedValue != "0")
        {
            string sql = "select UpojelaName,UpojelaID from  Comn_Upojela where DistrictID=" + ddlCompnayDistrict.SelectedValue + " order by UpojelaName";
            DataSet ds = DatabaseManager.ExecSQL(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCompanyUpazila.Items.Add(new ListItem(dr["UpojelaName"].ToString(), dr["UpojelaID"].ToString()));               
            }
        }
    }

    protected void ddlMailingAddressDistrictt_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMailingAddressUpozila.Items.Clear();
        ddlMailingAddressUpozila.Items.Add(new ListItem("Select Upozila", ""));
        if (ddlMailingAddressDistrict.SelectedValue != "")
        {
            string sql = "select UpojelaName,UpojelaID from  Comn_Upojela where DistrictID=" + ddlMailingAddressDistrict.SelectedValue + " order by UpojelaName";
            DataSet ds = DatabaseManager.ExecSQL(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlMailingAddressUpozila.Items.Add(new ListItem(dr["UpojelaName"].ToString(), dr["UpojelaID"].ToString()));
            }
        }
    }

    protected void ddlPermanentAddressDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPermanentAddressUpozila.Items.Clear();
        ddlPermanentAddressUpozila.Items.Add(new ListItem("Select Upozila", ""));
        if (ddlPermanentAddressDistrict.SelectedValue != "")
        {
            string sql = "select UpojelaName,UpojelaID from  Comn_Upojela where DistrictID=" + ddlMailingAddressDistrict.SelectedValue + " order by UpojelaName";
            DataSet ds = DatabaseManager.ExecSQL(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlPermanentAddressUpozila.Items.Add(new ListItem(dr["UpojelaName"].ToString(), dr["UpojelaID"].ToString()));
            }
        }
    }
    protected void a_ApplyForMember_Click(object sender, EventArgs e)
    {
        string sql = @"
INSERT INTO [Mem_Upgradation]
           ([Mem_MemberID]
           ,[AppliedFor]
           ,[AppliedDate]
           ,[Status])
     VALUES
           ("+hfMem_MemeberID.Value+@"--<Mem_MemberID, int,>
           ,'Member'--<AppliedFor, nvarchar(50),>
           ,GETDATE()--<AppliedDate, datetime,>
           ,'Applied'--<Status, nvarchar(50),>
);
";
        DatabaseManager.ExecSQL(sql);
        a_ApplyForMember.Visible = false;
        showAlartMessage("Request Accepted.");
        loadUpgradation();
    }
    protected void a_ApplyForFellow_Click(object sender, EventArgs e)
    {
        string sql = @"
INSERT INTO [Mem_Upgradation]
           ([Mem_MemberID]
           ,[AppliedFor]
           ,[AppliedDate]
           ,[Status])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'Fellow'--<AppliedFor, nvarchar(50),>
           ,GETDATE()--<AppliedDate, datetime,>
           ,'Applied'--<Status, nvarchar(50),>
);
";
        DatabaseManager.ExecSQL(sql);
        a_ApplyForFellow.Visible = false;
        showAlartMessage("Request Accepted.");
        loadUpgradation();
    }
    protected void btnPaynow_Click(object sender, EventArgs e)
    {
        bool isSelectedPaymentFor = false;
        foreach (ListItem item in rbtnPaymentFor.Items)
        {
            if (item.Selected)
            {
                isSelectedPaymentFor = true;
                break;
            }
        }

        if (!isSelectedPaymentFor)
        {
            showAlartMessage("Please select the purpose for which you are paying");
            return;
        }

        bool isCardType = false;
        foreach (ListItem item in rtbnCardType.Items)
        {
            if (item.Selected)
            {
                isCardType = true;
                break;
            }
        }

        if (!isCardType)
        {
            showAlartMessage("Please select the card type");
            return;
        }

        string amount = "";
        string desc = "_"+hfMem_MemeberID.Value+"_";
        if (rbtnPaymentFor.SelectedValue == "1")
        {
            amount = rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim().Split(' ')[3].Trim();
            desc += rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim().Split(' ')[0].Trim();
                //+ " " + rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim().Split(' ')[1].Trim()
            //+" " + rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim().Split(' ')[2].Trim();
        }
        else
        {
            amount = rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim().Split(' ')[1].Trim();
            desc += rbtnPaymentFor.SelectedItem.Text.Split('(')[0].Trim();
        }
        string transactionID = "";
        try
        {
            transactionID=CreateTransactionId(rtbnCardType.SelectedValue, double.Parse(amount), desc);
            string sql = @"
INSERT INTO [Acc_DBBL_Transaction]
           ([TransactionID]
           ,[Mem_MemberID]
           ,[PaymentFor]
           ,[StatusID]
           ,[ExtraField1]
           ,[ExtraField2]
           ,[ExtraField3]
           ,[ExtraField4]
           ,[ExtraField5]
           ,[AddedDate])
     VALUES
           ('" + transactionID + @"'--<TransactionID, nvarchar(256),>
           ," + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'"+desc+@"'--<PaymentFor, nvarchar(max),>
           ,0--<StatusID, int,>
           ,'" + rtbnCardType.SelectedValue + @"'--<ExtraField1, nvarchar(256),>
           ,'" + amount.ToString() + @"'--<ExtraField2, nvarchar(256),>
           ,''--<ExtraField3, nvarchar(256),>
           ,''--<ExtraField4, nvarchar(256),>
           ,''--<ExtraField5, nvarchar(256),>
           ,GETDATE()--<AddedDate, datetime,>
)
";
            DatabaseManager.ExecSQL(sql);
        }
        catch (Exception ex)
        {
            Sendmail.sendEmail("it@iebbd.org", "Paymnet Error", "(" + transactionID + ")(" + desc + ")");
        }

        
        Response.Redirect(Redirect(transactionID, rtbnCardType.SelectedValue));

    }

    public string CreateTransactionId(string cardType, double amount, string desc)
    {
        string amountStr = Convert.ToInt32(amount * 100).ToString();
        string clientIP = GetIPAddress();
        string transactionId = "";
        try
        {

            using (Process p = new Process())
            {
                p.StartInfo.WorkingDirectory = "D:\\000599990530000_ecom1";
                //p.StartInfo.WorkingDirectory = "D:\\000599990530000_ecom";
                //p.StartInfo.WorkingDirectory = "C:\\live";

                p.StartInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Java\\jre1.8.0_20\\bin\\java", @" -jar D:\000599990530000_ecom1\ecomm_merchant.jar D:\000599990530000_ecom1\merchant.properties -v " + amountStr + " 050 " + clientIP + " " + cardType + desc);
                //p.StartInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Java\\jre8\\bin\\java", @" -jar D:\000599990530000_ecom\ecomm_merchant.jar D:\000599990530000_ecom\merchant.properties -v " + amountStr + " 050 " + clientIP + " " + cardType + desc);
                // p.StartInfo = new ProcessStartInfo("java", @" -jar C:\live\ecomm_merchant.jar C:\live\merchant.properties -v " + amountStr + " 050 10.10.200.131 " + cardType +"^"+ desc);
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                String txnId = p.StandardOutput.ReadToEnd();
                txnId = txnId.Trim();
                transactionId = txnId.Substring(16, 28);
            }
        }
        catch(Exception ex)
        {
            txtName.Text = ex.Message;
            //LogWriter.writeToLogFile(e);
        }
        Session["transactionId"] = transactionId;
        Session["clientIP"] = clientIP;
        return transactionId;

    }


    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }
    public string Redirect(string transId, string cardType)
    {
        transId = Server.UrlEncode(transId);
        //string paymentPageUrl = "https://ecomtest.dutchbanglabank.com/ecomm2/ClientHandler?card_type=" + cardType + "&trans_id=" + transId;
        //string paymentPageUrl = "https://ecom.dutchbanglabank.com/ecomm2/ClientHandler?card_type=" + cardType + "&trans_id=" + transId;
        string paymentPageUrl = "https://ecom1.dutchbanglabank.com/ecomm2/ClientHandler?card_type=" + cardType + "&trans_id=" + transId;
        return paymentPageUrl;
    }

    protected void btnFormUpload_Click(object sender, EventArgs e)
    {
        string fudPhoto_FileName = fileUPloader(fudForm);
       string sql = @"

INSERT INTO [Mem_Files]
           ([Mem_MemberID]
           ,[FileName]
           ,[FileTypeID])
     VALUES
           (" + hfMem_MemeberID.Value + @"--<Mem_MemberID, int,>
           ,'" + fudPhoto_FileName + @"'--<FileName, nvarchar(max),>
           ,7--<FileTypeID, int,>
);

update [Mem_Member] set PictureURL='" + fudPhoto_FileName + @"' where Mem_MemberID="+hfMem_MemeberID.Value+@";
";
       DatabaseManager.ExecSQL(sql);
       showAlartMessage("Form uploaded successfully");
    }

    private string fileUPloader(FileUpload fuldStock)
    {
        if (fuldStock.HasFile)
        {
            #region fileUpload
            string strPath = string.Empty;
            string dirURL = "~/files/file/membershipRegistration/MembersFiles/";
            if (!Directory.Exists(MapPath(dirURL)))
                Directory.CreateDirectory(MapPath(dirURL));

            getFileName fileName = new getFileName(fuldStock.FileName, MapPath(dirURL));
            strPath = MapPath(dirURL + "/" + fileName.FileName);
            fuldStock.SaveAs(strPath);
            #endregion

            return fileName.FileName;
        }
        return "";
    }
}