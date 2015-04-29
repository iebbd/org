using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class SqlMem_MemberProvider:DataAccessObject
{
	public SqlMem_MemberProvider()
    {
    }


    public bool DeleteMem_Member(int mem_MemberID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_DeleteMem_Member", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_MemberID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Mem_Member> GetAllMem_Members()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetAllMem_Members", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetMem_MembersFromReader(reader);
        }
    }
    public List<Mem_Member> GetMem_MembersFromReader(IDataReader reader)
    {
        List<Mem_Member> mem_Members = new List<Mem_Member>();

        while (reader.Read())
        {
            mem_Members.Add(GetMem_MemberFromReader(reader));
        }
        return mem_Members;
    }

    public Mem_Member GetMem_MemberFromReader(IDataReader reader)
    {
        
            Mem_Member mem_Member = new Mem_Member();

            try { mem_Member.Mem_MemberID = (int)reader["Mem_MemberID"]; }
            catch (Exception ex) {  }
            try { mem_Member.MemberShipNo = reader["MemberShipNo"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MemberShipNoDigit = (int)reader["MemberShipNoDigit"]; }
            catch (Exception ex) {  }
            try { mem_Member.Mem_MemberTypeID = (int)reader["Mem_MemberTypeID"]; }
            catch (Exception ex) {  }
            try { mem_Member.Name = reader["Name"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.DateOfBirth = (DateTime)reader["DateOfBirth"]; }
            catch (Exception ex) {  }
            try { mem_Member.Age = (int)reader["Age"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_NationalityID = (int)reader["Comn_NationalityID"]; }
            catch (Exception ex) {  }
            try { mem_Member.PlaceOfBrith = reader["PlaceOfBrith"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MailingAddress1 = reader["MailingAddress1"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MailingAddress2 = reader["MailingAddress2"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MailingAddress3 = reader["MailingAddress3"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MailingAddress = reader["MailingAddress"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PermanentAddress = reader["PermanentAddress"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PermanentAddress1 = reader["PermanentAddress1"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PermanentAddress2 = reader["PermanentAddress2"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PermanentAddress3 = reader["PermanentAddress3"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PhoneOffice = reader["PhoneOffice"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PhoneResidence = reader["PhoneResidence"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Mobile = reader["Mobile"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Email = reader["Email"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Fax = reader["Fax"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.OtherContactInfo = reader["OtherContactInfo"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Comn_GenderID = (int)reader["Comn_GenderID"]; }
            catch (Exception ex) {  }
            try { mem_Member.PresentIEBMembershipNo = reader["PresentIEBMembershipNo"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Mem_SubDivisionID = (int)reader["Mem_SubDivisionID"]; }
            catch (Exception ex) {  }
            try { mem_Member.DeclarationDate = (DateTime)reader["DeclarationDate"]; }
            catch (Exception ex) {  }
            try { mem_Member.Mem_ApprovedCouncilMeetingID = (int)reader["Mem_ApprovedCouncilMeetingID"]; }
            catch (Exception ex) {  }
            try { mem_Member.ScrollNo = (int)reader["ScrollNo"]; }
            catch (Exception ex) {  }
            try { mem_Member.ReceiptDate = (DateTime)reader["ReceiptDate"]; }
            catch (Exception ex) {  }
            try { mem_Member.CopiesOfCertificates = (bool)reader["CopiesOfCertificates"]; }
            catch (Exception ex) {  }
            try { mem_Member.CopiesOfCertificatesComment = reader["CopiesOfCertificatesComment"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.CopiesOfTranscripts = (bool)reader["CopiesOfTranscripts"]; }
            catch (Exception ex) {  }
            try { mem_Member.CopiesOfTranscriptsComment = reader["CopiesOfTranscriptsComment"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PhotoEnclosed = (bool)reader["PhotoEnclosed"]; }
            catch (Exception ex) {  }
            try { mem_Member.ProfessionalRecordEnclosed = (bool)reader["ProfessionalRecordEnclosed"]; }
            catch (Exception ex) {  }
            try { mem_Member.ProfessionalRecordEnclosedComment = reader["ProfessionalRecordEnclosedComment"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.RecomendationOffice = (bool)reader["RecomendationOffice"]; }
            catch (Exception ex) {  }
            try { mem_Member.RecomenDationCommentOffice = reader["RecomenDationCommentOffice"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.AgeMembershipSection = reader["AgeMembershipSection"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Education = reader["Education"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Exprerience = reader["Exprerience"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.RecomendationMembershipSec = (bool)reader["RecomendationMembershipSec"]; }
            catch (Exception ex) {  }
            try { mem_Member.RecomenDationCommentMembershipSec = reader["RecomenDationCommentMembershipSec"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.MembershipSectionEmployeeID = (int)reader["MembershipSectionEmployeeID"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_StatusID = (int)reader["Comn_StatusID"]; }
            catch (Exception ex) {  }
            try { mem_Member.MembershipCommiteeMemebershipNo = (int)reader["MembershipCommiteeMemebershipNo"]; }
            catch (Exception ex) {  }
            try { mem_Member.MembershipCommiteeMemebershipTypeID = (int)reader["MembershipCommiteeMemebershipTypeID"]; }
            catch (Exception ex) {  }
            try { mem_Member.PictureURL = reader["PictureURL"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.SignatureURL = reader["SignatureURL"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.Comn_UniversityID = (int)reader["Comn_UniversityID"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_DepartmentID = (int)reader["Comn_DepartmentID"]; }
            catch (Exception ex) {  }
            try { mem_Member.PassingYear = (int)reader["PassingYear"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_OfficeID = (int)reader["Comn_OfficeID"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_BloodGroup = reader["Comn_BloodGroup"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.PassportNo = reader["PassportNo"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.NationalIDNo = reader["NationalIDNo"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.BirthRegistrationID = reader["BirthRegistrationID"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField1 = reader["ExtraField1"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField2 = reader["ExtraField2"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField3 = reader["ExtraField3"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField4 = reader["ExtraField4"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField5 = reader["ExtraField5"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField6 = reader["ExtraField6"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField7 = reader["ExtraField7"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField8 = reader["ExtraField8"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField9 = reader["ExtraField9"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField10 = reader["ExtraField10"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField11 = reader["ExtraField11"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField12 = reader["ExtraField12"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField13 = reader["ExtraField13"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField14 = reader["ExtraField14"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField15 = reader["ExtraField15"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField16 = reader["ExtraField16"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField17 = reader["ExtraField17"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField18 = reader["ExtraField18"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField19 = reader["ExtraField19"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.ExtraField20 = reader["ExtraField20"].ToString(); }
            catch (Exception ex) {  }
            try { mem_Member.AddedBy = (int)reader["AddedBy"]; }
            catch (Exception ex) {  }
            try { mem_Member.AddedDate = (DateTime)reader["AddedDate"]; }
            catch (Exception ex) {  }
            try { mem_Member.ModifiedBy = (int)reader["ModifiedBy"]; }
            catch (Exception ex) {  }
            try { mem_Member.ModifiedDate = (DateTime)reader["ModifiedDate"]; }
            catch (Exception ex) {  }
            try { mem_Member.Comn_RowStatusID = (int)reader["Comn_RowStatusID"]; }
            catch (Exception ex) {  }
               return mem_Member;
    }

    public Mem_Member GetMem_MemberByID(int mem_MemberID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_MemberByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_MemberID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_MemberFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public Mem_Member GetMem_Applied_MemberByID(int mem_MemberID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("IEB_GetMem_Applied_MemberByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_MemberID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetMem_MemberFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }
    public int InsertMem_Applied_Member(Mem_Member mem_Member)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Applied_Member", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemberShipNo", SqlDbType.NVarChar).Value = mem_Member.MemberShipNo;
            cmd.Parameters.Add("@MemberShipNoDigit", SqlDbType.Int).Value = mem_Member.MemberShipNoDigit;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_Member.Mem_MemberTypeID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = mem_Member.Name;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = mem_Member.DateOfBirth;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_Member.Age;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = mem_Member.Comn_NationalityID;
            cmd.Parameters.Add("@PlaceOfBrith", SqlDbType.NVarChar).Value = mem_Member.PlaceOfBrith;
            cmd.Parameters.Add("@MailingAddress1", SqlDbType.NVarChar).Value = mem_Member.MailingAddress1;
            cmd.Parameters.Add("@MailingAddress2", SqlDbType.NVarChar).Value = mem_Member.MailingAddress2;
            cmd.Parameters.Add("@MailingAddress3", SqlDbType.NVarChar).Value = mem_Member.MailingAddress3;
            cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = mem_Member.MailingAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress;
            cmd.Parameters.Add("@PermanentAddress1", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress1;
            cmd.Parameters.Add("@PermanentAddress2", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress2;
            cmd.Parameters.Add("@PermanentAddress3", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress3;
            cmd.Parameters.Add("@PhoneOffice", SqlDbType.NVarChar).Value = mem_Member.PhoneOffice;
            cmd.Parameters.Add("@PhoneResidence", SqlDbType.NVarChar).Value = mem_Member.PhoneResidence;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mem_Member.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_Member.Email;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = mem_Member.Fax;
            cmd.Parameters.Add("@OtherContactInfo", SqlDbType.NVarChar).Value = mem_Member.OtherContactInfo;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = mem_Member.Comn_GenderID;
            cmd.Parameters.Add("@PresentIEBMembershipNo", SqlDbType.NVarChar).Value = mem_Member.PresentIEBMembershipNo;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_Member.Mem_SubDivisionID;
            cmd.Parameters.Add("@DeclarationDate", SqlDbType.NVarChar).Value = mem_Member.DeclarationDate;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_Member.Mem_ApprovedCouncilMeetingID;
            cmd.Parameters.Add("@ScrollNo", SqlDbType.Int).Value = mem_Member.ScrollNo;
            cmd.Parameters.Add("@ReceiptDate", SqlDbType.NVarChar).Value = mem_Member.ReceiptDate;
            cmd.Parameters.Add("@CopiesOfCertificates", SqlDbType.Bit).Value = mem_Member.CopiesOfCertificates;
            cmd.Parameters.Add("@CopiesOfCertificatesComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfCertificatesComment;
            cmd.Parameters.Add("@CopiesOfTranscripts", SqlDbType.Bit).Value = mem_Member.CopiesOfTranscripts;
            cmd.Parameters.Add("@CopiesOfTranscriptsComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfTranscriptsComment;
            cmd.Parameters.Add("@PhotoEnclosed", SqlDbType.Bit).Value = mem_Member.PhotoEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosed", SqlDbType.Bit).Value = mem_Member.ProfessionalRecordEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosedComment", SqlDbType.NVarChar).Value = mem_Member.ProfessionalRecordEnclosedComment;
            cmd.Parameters.Add("@RecomendationOffice", SqlDbType.Bit).Value = mem_Member.RecomendationOffice;
            cmd.Parameters.Add("@RecomenDationCommentOffice", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentOffice;
            cmd.Parameters.Add("@AgeMembershipSection", SqlDbType.NVarChar).Value = mem_Member.AgeMembershipSection;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mem_Member.Education;
            cmd.Parameters.Add("@Exprerience", SqlDbType.NVarChar).Value = mem_Member.Exprerience;
            cmd.Parameters.Add("@RecomendationMembershipSec", SqlDbType.Bit).Value = mem_Member.RecomendationMembershipSec;
            cmd.Parameters.Add("@RecomenDationCommentMembershipSec", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentMembershipSec;
            cmd.Parameters.Add("@MembershipSectionEmployeeID", SqlDbType.Int).Value = mem_Member.MembershipSectionEmployeeID;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = mem_Member.Comn_StatusID;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipNo", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipNo;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipTypeID", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipTypeID;
            cmd.Parameters.Add("@PictureURL", SqlDbType.NVarChar).Value = mem_Member.PictureURL;
            cmd.Parameters.Add("@SignatureURL", SqlDbType.NVarChar).Value = mem_Member.SignatureURL;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_Member.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_Member.Comn_DepartmentID;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = mem_Member.PassingYear;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_Member.Comn_OfficeID;
            cmd.Parameters.Add("@Comn_BloodGroup", SqlDbType.NVarChar).Value = mem_Member.Comn_BloodGroup;
            cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = mem_Member.PassportNo;
            cmd.Parameters.Add("@NationalIDNo", SqlDbType.NVarChar).Value = mem_Member.NationalIDNo;
            cmd.Parameters.Add("@BirthRegistrationID", SqlDbType.NVarChar).Value = mem_Member.BirthRegistrationID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = mem_Member.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = mem_Member.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = mem_Member.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = mem_Member.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = mem_Member.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = mem_Member.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = mem_Member.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = mem_Member.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = mem_Member.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = mem_Member.ExtraField10;
            cmd.Parameters.Add("@ExtraField11", SqlDbType.NVarChar).Value = mem_Member.ExtraField11;
            cmd.Parameters.Add("@ExtraField12", SqlDbType.NVarChar).Value = mem_Member.ExtraField12;
            cmd.Parameters.Add("@ExtraField13", SqlDbType.NVarChar).Value = mem_Member.ExtraField13;
            cmd.Parameters.Add("@ExtraField14", SqlDbType.NVarChar).Value = mem_Member.ExtraField14;
            cmd.Parameters.Add("@ExtraField15", SqlDbType.NVarChar).Value = mem_Member.ExtraField15;
            cmd.Parameters.Add("@ExtraField16", SqlDbType.NVarChar).Value = mem_Member.ExtraField16;
            cmd.Parameters.Add("@ExtraField17", SqlDbType.NVarChar).Value = mem_Member.ExtraField17;
            cmd.Parameters.Add("@ExtraField18", SqlDbType.NVarChar).Value = mem_Member.ExtraField18;
            cmd.Parameters.Add("@ExtraField19", SqlDbType.NVarChar).Value = mem_Member.ExtraField19;
            cmd.Parameters.Add("@ExtraField20", SqlDbType.NVarChar).Value = mem_Member.ExtraField20;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Member.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Member.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Member.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Member.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Member.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_MemberID"].Value;
        }
    }
    public int InsertMem_Member(Mem_Member mem_Member)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_InsertMem_Member", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemberShipNo", SqlDbType.NVarChar).Value = mem_Member.MemberShipNo;
            cmd.Parameters.Add("@MemberShipNoDigit", SqlDbType.Int).Value = mem_Member.MemberShipNoDigit;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_Member.Mem_MemberTypeID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = mem_Member.Name;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = mem_Member.DateOfBirth;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_Member.Age;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = mem_Member.Comn_NationalityID;
            cmd.Parameters.Add("@PlaceOfBrith", SqlDbType.NVarChar).Value = mem_Member.PlaceOfBrith;
            cmd.Parameters.Add("@MailingAddress1", SqlDbType.NVarChar).Value = mem_Member.MailingAddress1;
            cmd.Parameters.Add("@MailingAddress2", SqlDbType.NVarChar).Value = mem_Member.MailingAddress2;
            cmd.Parameters.Add("@MailingAddress3", SqlDbType.NVarChar).Value = mem_Member.MailingAddress3;
            cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = mem_Member.MailingAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress;
            cmd.Parameters.Add("@PermanentAddress1", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress1;
            cmd.Parameters.Add("@PermanentAddress2", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress2;
            cmd.Parameters.Add("@PermanentAddress3", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress3;
            cmd.Parameters.Add("@PhoneOffice", SqlDbType.NVarChar).Value = mem_Member.PhoneOffice;
            cmd.Parameters.Add("@PhoneResidence", SqlDbType.NVarChar).Value = mem_Member.PhoneResidence;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mem_Member.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_Member.Email;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = mem_Member.Fax;
            cmd.Parameters.Add("@OtherContactInfo", SqlDbType.NVarChar).Value = mem_Member.OtherContactInfo;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = mem_Member.Comn_GenderID;
            cmd.Parameters.Add("@PresentIEBMembershipNo", SqlDbType.NVarChar).Value = mem_Member.PresentIEBMembershipNo;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_Member.Mem_SubDivisionID;
            cmd.Parameters.Add("@DeclarationDate", SqlDbType.NVarChar).Value = mem_Member.DeclarationDate;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_Member.Mem_ApprovedCouncilMeetingID;
            cmd.Parameters.Add("@ScrollNo", SqlDbType.Int).Value = mem_Member.ScrollNo;
            cmd.Parameters.Add("@ReceiptDate", SqlDbType.NVarChar).Value = mem_Member.ReceiptDate;
            cmd.Parameters.Add("@CopiesOfCertificates", SqlDbType.Bit).Value = mem_Member.CopiesOfCertificates;
            cmd.Parameters.Add("@CopiesOfCertificatesComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfCertificatesComment;
            cmd.Parameters.Add("@CopiesOfTranscripts", SqlDbType.Bit).Value = mem_Member.CopiesOfTranscripts;
            cmd.Parameters.Add("@CopiesOfTranscriptsComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfTranscriptsComment;
            cmd.Parameters.Add("@PhotoEnclosed", SqlDbType.Bit).Value = mem_Member.PhotoEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosed", SqlDbType.Bit).Value = mem_Member.ProfessionalRecordEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosedComment", SqlDbType.NVarChar).Value = mem_Member.ProfessionalRecordEnclosedComment;
            cmd.Parameters.Add("@RecomendationOffice", SqlDbType.Bit).Value = mem_Member.RecomendationOffice;
            cmd.Parameters.Add("@RecomenDationCommentOffice", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentOffice;
            cmd.Parameters.Add("@AgeMembershipSection", SqlDbType.NVarChar).Value = mem_Member.AgeMembershipSection;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mem_Member.Education;
            cmd.Parameters.Add("@Exprerience", SqlDbType.NVarChar).Value = mem_Member.Exprerience;
            cmd.Parameters.Add("@RecomendationMembershipSec", SqlDbType.Bit).Value = mem_Member.RecomendationMembershipSec;
            cmd.Parameters.Add("@RecomenDationCommentMembershipSec", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentMembershipSec;
            cmd.Parameters.Add("@MembershipSectionEmployeeID", SqlDbType.Int).Value = mem_Member.MembershipSectionEmployeeID;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = mem_Member.Comn_StatusID;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipNo", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipNo;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipTypeID", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipTypeID;
            cmd.Parameters.Add("@PictureURL", SqlDbType.NVarChar).Value = mem_Member.PictureURL;
            cmd.Parameters.Add("@SignatureURL", SqlDbType.NVarChar).Value = mem_Member.SignatureURL;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_Member.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_Member.Comn_DepartmentID;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = mem_Member.PassingYear;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_Member.Comn_OfficeID;
            cmd.Parameters.Add("@Comn_BloodGroup", SqlDbType.NVarChar).Value = mem_Member.Comn_BloodGroup;
            cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = mem_Member.PassportNo;
            cmd.Parameters.Add("@NationalIDNo", SqlDbType.NVarChar).Value = mem_Member.NationalIDNo;
            cmd.Parameters.Add("@BirthRegistrationID", SqlDbType.NVarChar).Value = mem_Member.BirthRegistrationID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = mem_Member.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = mem_Member.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = mem_Member.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = mem_Member.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = mem_Member.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = mem_Member.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = mem_Member.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = mem_Member.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = mem_Member.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = mem_Member.ExtraField10;
            cmd.Parameters.Add("@ExtraField11", SqlDbType.NVarChar).Value = mem_Member.ExtraField11;
            cmd.Parameters.Add("@ExtraField12", SqlDbType.NVarChar).Value = mem_Member.ExtraField12;
            cmd.Parameters.Add("@ExtraField13", SqlDbType.NVarChar).Value = mem_Member.ExtraField13;
            cmd.Parameters.Add("@ExtraField14", SqlDbType.NVarChar).Value = mem_Member.ExtraField14;
            cmd.Parameters.Add("@ExtraField15", SqlDbType.NVarChar).Value = mem_Member.ExtraField15;
            cmd.Parameters.Add("@ExtraField16", SqlDbType.NVarChar).Value = mem_Member.ExtraField16;
            cmd.Parameters.Add("@ExtraField17", SqlDbType.NVarChar).Value = mem_Member.ExtraField17;
            cmd.Parameters.Add("@ExtraField18", SqlDbType.NVarChar).Value = mem_Member.ExtraField18;
            cmd.Parameters.Add("@ExtraField19", SqlDbType.NVarChar).Value = mem_Member.ExtraField19;
            cmd.Parameters.Add("@ExtraField20", SqlDbType.NVarChar).Value = mem_Member.ExtraField20;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Member.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Member.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Member.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Member.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Member.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Mem_MemberID"].Value;
        }
    }

    public bool UpdateMem_Member(Mem_Member mem_Member)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Member", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Member.Mem_MemberID;
            cmd.Parameters.Add("@MemberShipNo", SqlDbType.NVarChar).Value = mem_Member.MemberShipNo;
            cmd.Parameters.Add("@MemberShipNoDigit", SqlDbType.Int).Value = mem_Member.MemberShipNoDigit;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_Member.Mem_MemberTypeID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = mem_Member.Name;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = mem_Member.DateOfBirth;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_Member.Age;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = mem_Member.Comn_NationalityID;
            cmd.Parameters.Add("@PlaceOfBrith", SqlDbType.NVarChar).Value = mem_Member.PlaceOfBrith;
            cmd.Parameters.Add("@MailingAddress1", SqlDbType.NVarChar).Value = mem_Member.MailingAddress1;
            cmd.Parameters.Add("@MailingAddress2", SqlDbType.NVarChar).Value = mem_Member.MailingAddress2;
            cmd.Parameters.Add("@MailingAddress3", SqlDbType.NVarChar).Value = mem_Member.MailingAddress3;
            cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = mem_Member.MailingAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress;
            cmd.Parameters.Add("@PermanentAddress1", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress1;
            cmd.Parameters.Add("@PermanentAddress2", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress2;
            cmd.Parameters.Add("@PermanentAddress3", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress3;
            cmd.Parameters.Add("@PhoneOffice", SqlDbType.NVarChar).Value = mem_Member.PhoneOffice;
            cmd.Parameters.Add("@PhoneResidence", SqlDbType.NVarChar).Value = mem_Member.PhoneResidence;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mem_Member.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_Member.Email;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = mem_Member.Fax;
            cmd.Parameters.Add("@OtherContactInfo", SqlDbType.NVarChar).Value = mem_Member.OtherContactInfo;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = mem_Member.Comn_GenderID;
            cmd.Parameters.Add("@PresentIEBMembershipNo", SqlDbType.NVarChar).Value = mem_Member.PresentIEBMembershipNo;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_Member.Mem_SubDivisionID;
            cmd.Parameters.Add("@DeclarationDate", SqlDbType.NVarChar).Value = mem_Member.DeclarationDate;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_Member.Mem_ApprovedCouncilMeetingID;
            cmd.Parameters.Add("@ScrollNo", SqlDbType.Int).Value = mem_Member.ScrollNo;
            cmd.Parameters.Add("@ReceiptDate", SqlDbType.NVarChar).Value = mem_Member.ReceiptDate;
            cmd.Parameters.Add("@CopiesOfCertificates", SqlDbType.Bit).Value = mem_Member.CopiesOfCertificates;
            cmd.Parameters.Add("@CopiesOfCertificatesComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfCertificatesComment;
            cmd.Parameters.Add("@CopiesOfTranscripts", SqlDbType.Bit).Value = mem_Member.CopiesOfTranscripts;
            cmd.Parameters.Add("@CopiesOfTranscriptsComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfTranscriptsComment;
            cmd.Parameters.Add("@PhotoEnclosed", SqlDbType.Bit).Value = mem_Member.PhotoEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosed", SqlDbType.Bit).Value = mem_Member.ProfessionalRecordEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosedComment", SqlDbType.NVarChar).Value = mem_Member.ProfessionalRecordEnclosedComment;
            cmd.Parameters.Add("@RecomendationOffice", SqlDbType.Bit).Value = mem_Member.RecomendationOffice;
            cmd.Parameters.Add("@RecomenDationCommentOffice", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentOffice;
            cmd.Parameters.Add("@AgeMembershipSection", SqlDbType.NVarChar).Value = mem_Member.AgeMembershipSection;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mem_Member.Education;
            cmd.Parameters.Add("@Exprerience", SqlDbType.NVarChar).Value = mem_Member.Exprerience;
            cmd.Parameters.Add("@RecomendationMembershipSec", SqlDbType.Bit).Value = mem_Member.RecomendationMembershipSec;
            cmd.Parameters.Add("@RecomenDationCommentMembershipSec", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentMembershipSec;
            cmd.Parameters.Add("@MembershipSectionEmployeeID", SqlDbType.Int).Value = mem_Member.MembershipSectionEmployeeID;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = mem_Member.Comn_StatusID;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipNo", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipNo;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipTypeID", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipTypeID;
            cmd.Parameters.Add("@PictureURL", SqlDbType.NVarChar).Value = mem_Member.PictureURL;
            cmd.Parameters.Add("@SignatureURL", SqlDbType.NVarChar).Value = mem_Member.SignatureURL;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_Member.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_Member.Comn_DepartmentID;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = mem_Member.PassingYear;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_Member.Comn_OfficeID;
            cmd.Parameters.Add("@Comn_BloodGroup", SqlDbType.NVarChar).Value = mem_Member.Comn_BloodGroup;
            cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = mem_Member.PassportNo;
            cmd.Parameters.Add("@NationalIDNo", SqlDbType.NVarChar).Value = mem_Member.NationalIDNo;
            cmd.Parameters.Add("@BirthRegistrationID", SqlDbType.NVarChar).Value = mem_Member.BirthRegistrationID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = mem_Member.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = mem_Member.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = mem_Member.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = mem_Member.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = mem_Member.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = mem_Member.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = mem_Member.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = mem_Member.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = mem_Member.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = mem_Member.ExtraField10;
            cmd.Parameters.Add("@ExtraField11", SqlDbType.NVarChar).Value = mem_Member.ExtraField11;
            cmd.Parameters.Add("@ExtraField12", SqlDbType.NVarChar).Value = mem_Member.ExtraField12;
            cmd.Parameters.Add("@ExtraField13", SqlDbType.NVarChar).Value = mem_Member.ExtraField13;
            cmd.Parameters.Add("@ExtraField14", SqlDbType.NVarChar).Value = mem_Member.ExtraField14;
            cmd.Parameters.Add("@ExtraField15", SqlDbType.NVarChar).Value = mem_Member.ExtraField15;
            cmd.Parameters.Add("@ExtraField16", SqlDbType.NVarChar).Value = mem_Member.ExtraField16;
            cmd.Parameters.Add("@ExtraField17", SqlDbType.NVarChar).Value = mem_Member.ExtraField17;
            cmd.Parameters.Add("@ExtraField18", SqlDbType.NVarChar).Value = mem_Member.ExtraField18;
            cmd.Parameters.Add("@ExtraField19", SqlDbType.NVarChar).Value = mem_Member.ExtraField19;
            cmd.Parameters.Add("@ExtraField20", SqlDbType.NVarChar).Value = mem_Member.ExtraField20;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Member.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Member.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Member.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Member.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Member.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
    public bool UpdateMem_Applied_Member(Mem_Member mem_Member)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("IEB_UpdateMem_Applied_Member", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mem_MemberID", SqlDbType.Int).Value = mem_Member.Mem_MemberID;
            cmd.Parameters.Add("@MemberShipNo", SqlDbType.NVarChar).Value = mem_Member.MemberShipNo;
            cmd.Parameters.Add("@MemberShipNoDigit", SqlDbType.Int).Value = mem_Member.MemberShipNoDigit;
            cmd.Parameters.Add("@Mem_MemberTypeID", SqlDbType.Int).Value = mem_Member.Mem_MemberTypeID;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = mem_Member.Name;
            cmd.Parameters.Add("@DateOfBirth", SqlDbType.NVarChar).Value = mem_Member.DateOfBirth;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = mem_Member.Age;
            cmd.Parameters.Add("@Comn_NationalityID", SqlDbType.Int).Value = mem_Member.Comn_NationalityID;
            cmd.Parameters.Add("@PlaceOfBrith", SqlDbType.NVarChar).Value = mem_Member.PlaceOfBrith;
            cmd.Parameters.Add("@MailingAddress1", SqlDbType.NVarChar).Value = mem_Member.MailingAddress1;
            cmd.Parameters.Add("@MailingAddress2", SqlDbType.NVarChar).Value = mem_Member.MailingAddress2;
            cmd.Parameters.Add("@MailingAddress3", SqlDbType.NVarChar).Value = mem_Member.MailingAddress3;
            cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = mem_Member.MailingAddress;
            cmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress;
            cmd.Parameters.Add("@PermanentAddress1", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress1;
            cmd.Parameters.Add("@PermanentAddress2", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress2;
            cmd.Parameters.Add("@PermanentAddress3", SqlDbType.NVarChar).Value = mem_Member.PermanentAddress3;
            cmd.Parameters.Add("@PhoneOffice", SqlDbType.NVarChar).Value = mem_Member.PhoneOffice;
            cmd.Parameters.Add("@PhoneResidence", SqlDbType.NVarChar).Value = mem_Member.PhoneResidence;
            cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mem_Member.Mobile;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mem_Member.Email;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = mem_Member.Fax;
            cmd.Parameters.Add("@OtherContactInfo", SqlDbType.NVarChar).Value = mem_Member.OtherContactInfo;
            cmd.Parameters.Add("@Comn_GenderID", SqlDbType.Int).Value = mem_Member.Comn_GenderID;
            cmd.Parameters.Add("@PresentIEBMembershipNo", SqlDbType.NVarChar).Value = mem_Member.PresentIEBMembershipNo;
            cmd.Parameters.Add("@Mem_SubDivisionID", SqlDbType.Int).Value = mem_Member.Mem_SubDivisionID;
            cmd.Parameters.Add("@DeclarationDate", SqlDbType.NVarChar).Value = mem_Member.DeclarationDate;
            cmd.Parameters.Add("@Mem_ApprovedCouncilMeetingID", SqlDbType.Int).Value = mem_Member.Mem_ApprovedCouncilMeetingID;
            cmd.Parameters.Add("@ScrollNo", SqlDbType.Int).Value = mem_Member.ScrollNo;
            cmd.Parameters.Add("@ReceiptDate", SqlDbType.NVarChar).Value = mem_Member.ReceiptDate;
            cmd.Parameters.Add("@CopiesOfCertificates", SqlDbType.Bit).Value = mem_Member.CopiesOfCertificates;
            cmd.Parameters.Add("@CopiesOfCertificatesComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfCertificatesComment;
            cmd.Parameters.Add("@CopiesOfTranscripts", SqlDbType.Bit).Value = mem_Member.CopiesOfTranscripts;
            cmd.Parameters.Add("@CopiesOfTranscriptsComment", SqlDbType.NVarChar).Value = mem_Member.CopiesOfTranscriptsComment;
            cmd.Parameters.Add("@PhotoEnclosed", SqlDbType.Bit).Value = mem_Member.PhotoEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosed", SqlDbType.Bit).Value = mem_Member.ProfessionalRecordEnclosed;
            cmd.Parameters.Add("@ProfessionalRecordEnclosedComment", SqlDbType.NVarChar).Value = mem_Member.ProfessionalRecordEnclosedComment;
            cmd.Parameters.Add("@RecomendationOffice", SqlDbType.Bit).Value = mem_Member.RecomendationOffice;
            cmd.Parameters.Add("@RecomenDationCommentOffice", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentOffice;
            cmd.Parameters.Add("@AgeMembershipSection", SqlDbType.NVarChar).Value = mem_Member.AgeMembershipSection;
            cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = mem_Member.Education;
            cmd.Parameters.Add("@Exprerience", SqlDbType.NVarChar).Value = mem_Member.Exprerience;
            cmd.Parameters.Add("@RecomendationMembershipSec", SqlDbType.Bit).Value = mem_Member.RecomendationMembershipSec;
            cmd.Parameters.Add("@RecomenDationCommentMembershipSec", SqlDbType.NVarChar).Value = mem_Member.RecomenDationCommentMembershipSec;
            cmd.Parameters.Add("@MembershipSectionEmployeeID", SqlDbType.Int).Value = mem_Member.MembershipSectionEmployeeID;
            cmd.Parameters.Add("@Comn_StatusID", SqlDbType.Int).Value = mem_Member.Comn_StatusID;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipNo", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipNo;
            cmd.Parameters.Add("@MembershipCommiteeMemebershipTypeID", SqlDbType.Int).Value = mem_Member.MembershipCommiteeMemebershipTypeID;
            cmd.Parameters.Add("@PictureURL", SqlDbType.NVarChar).Value = mem_Member.PictureURL;
            cmd.Parameters.Add("@SignatureURL", SqlDbType.NVarChar).Value = mem_Member.SignatureURL;
            cmd.Parameters.Add("@Comn_UniversityID", SqlDbType.Int).Value = mem_Member.Comn_UniversityID;
            cmd.Parameters.Add("@Comn_DepartmentID", SqlDbType.Int).Value = mem_Member.Comn_DepartmentID;
            cmd.Parameters.Add("@PassingYear", SqlDbType.Int).Value = mem_Member.PassingYear;
            cmd.Parameters.Add("@Comn_OfficeID", SqlDbType.Int).Value = mem_Member.Comn_OfficeID;
            cmd.Parameters.Add("@Comn_BloodGroup", SqlDbType.NVarChar).Value = mem_Member.Comn_BloodGroup;
            cmd.Parameters.Add("@PassportNo", SqlDbType.NVarChar).Value = mem_Member.PassportNo;
            cmd.Parameters.Add("@NationalIDNo", SqlDbType.NVarChar).Value = mem_Member.NationalIDNo;
            cmd.Parameters.Add("@BirthRegistrationID", SqlDbType.NVarChar).Value = mem_Member.BirthRegistrationID;
            cmd.Parameters.Add("@ExtraField1", SqlDbType.NVarChar).Value = mem_Member.ExtraField1;
            cmd.Parameters.Add("@ExtraField2", SqlDbType.NVarChar).Value = mem_Member.ExtraField2;
            cmd.Parameters.Add("@ExtraField3", SqlDbType.NVarChar).Value = mem_Member.ExtraField3;
            cmd.Parameters.Add("@ExtraField4", SqlDbType.NVarChar).Value = mem_Member.ExtraField4;
            cmd.Parameters.Add("@ExtraField5", SqlDbType.NVarChar).Value = mem_Member.ExtraField5;
            cmd.Parameters.Add("@ExtraField6", SqlDbType.NVarChar).Value = mem_Member.ExtraField6;
            cmd.Parameters.Add("@ExtraField7", SqlDbType.NVarChar).Value = mem_Member.ExtraField7;
            cmd.Parameters.Add("@ExtraField8", SqlDbType.NVarChar).Value = mem_Member.ExtraField8;
            cmd.Parameters.Add("@ExtraField9", SqlDbType.NVarChar).Value = mem_Member.ExtraField9;
            cmd.Parameters.Add("@ExtraField10", SqlDbType.NVarChar).Value = mem_Member.ExtraField10;
            cmd.Parameters.Add("@ExtraField11", SqlDbType.NVarChar).Value = mem_Member.ExtraField11;
            cmd.Parameters.Add("@ExtraField12", SqlDbType.NVarChar).Value = mem_Member.ExtraField12;
            cmd.Parameters.Add("@ExtraField13", SqlDbType.NVarChar).Value = mem_Member.ExtraField13;
            cmd.Parameters.Add("@ExtraField14", SqlDbType.NVarChar).Value = mem_Member.ExtraField14;
            cmd.Parameters.Add("@ExtraField15", SqlDbType.NVarChar).Value = mem_Member.ExtraField15;
            cmd.Parameters.Add("@ExtraField16", SqlDbType.NVarChar).Value = mem_Member.ExtraField16;
            cmd.Parameters.Add("@ExtraField17", SqlDbType.NVarChar).Value = mem_Member.ExtraField17;
            cmd.Parameters.Add("@ExtraField18", SqlDbType.NVarChar).Value = mem_Member.ExtraField18;
            cmd.Parameters.Add("@ExtraField19", SqlDbType.NVarChar).Value = mem_Member.ExtraField19;
            cmd.Parameters.Add("@ExtraField20", SqlDbType.NVarChar).Value = mem_Member.ExtraField20;
            cmd.Parameters.Add("@AddedBy", SqlDbType.Int).Value = mem_Member.AddedBy;
            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = mem_Member.AddedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = mem_Member.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = mem_Member.ModifiedDate;
            cmd.Parameters.Add("@Comn_RowStatusID", SqlDbType.Int).Value = mem_Member.Comn_RowStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
