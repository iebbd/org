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

public class Mem_Member
{
    public Mem_Member()
    {
    }

    public Mem_Member
        (
        int mem_MemberID, 
        string memberShipNo, 
        int memberShipNoDigit, 
        int mem_MemberTypeID, 
        string name, 
        DateTime dateOfBirth, 
        int age, 
        int comn_NationalityID, 
        string placeOfBrith, 
        string mailingAddress1, 
        string mailingAddress2, 
        string mailingAddress3, 
        string mailingAddress, 
        string permanentAddress, 
        string permanentAddress1, 
        string permanentAddress2, 
        string permanentAddress3, 
        string phoneOffice, 
        string phoneResidence, 
        string mobile, 
        string email, 
        string fax, 
        string otherContactInfo, 
        int comn_GenderID, 
        string presentIEBMembershipNo, 
        int mem_SubDivisionID, 
        DateTime declarationDate, 
        int mem_ApprovedCouncilMeetingID, 
        int scrollNo, 
        DateTime receiptDate, 
        bool copiesOfCertificates, 
        string copiesOfCertificatesComment, 
        bool copiesOfTranscripts, 
        string copiesOfTranscriptsComment, 
        bool photoEnclosed, 
        bool professionalRecordEnclosed, 
        string professionalRecordEnclosedComment, 
        bool recomendationOffice, 
        string recomenDationCommentOffice, 
        string ageMembershipSection, 
        string education, 
        string exprerience, 
        bool recomendationMembershipSec, 
        string recomenDationCommentMembershipSec, 
        int membershipSectionEmployeeID, 
        int comn_StatusID, 
        int membershipCommiteeMemebershipNo, 
        int membershipCommiteeMemebershipTypeID, 
        string pictureURL, 
        string signatureURL, 
        int comn_UniversityID, 
        int comn_DepartmentID, 
        int passingYear, 
        int comn_OfficeID,
        string comn_BloodGroup, 
        string passportNo, 
        string nationalIDNo, 
        string birthRegistrationID, 
        string extraField1, 
        string extraField2, 
        string extraField3, 
        string extraField4, 
        string extraField5, 
        string extraField6, 
        string extraField7, 
        string extraField8, 
        string extraField9, 
        string extraField10, 
        string extraField11, 
        string extraField12, 
        string extraField13, 
        string extraField14, 
        string extraField15, 
        string extraField16, 
        string extraField17, 
        string extraField18, 
        string extraField19, 
        string extraField20, 
        int addedBy, 
        DateTime addedDate, 
        int modifiedBy, 
        DateTime modifiedDate, 
        int comn_RowStatusID
        )
    {
        this.Mem_MemberID = mem_MemberID;
        this.MemberShipNo = memberShipNo;
        this.MemberShipNoDigit = memberShipNoDigit;
        this.Mem_MemberTypeID = mem_MemberTypeID;
        this.Name = name;
        this.DateOfBirth = dateOfBirth;
        this.Age = age;
        this.Comn_NationalityID = comn_NationalityID;
        this.PlaceOfBrith = placeOfBrith;
        this.MailingAddress1 = mailingAddress1;
        this.MailingAddress2 = mailingAddress2;
        this.MailingAddress3 = mailingAddress3;
        this.MailingAddress = mailingAddress;
        this.PermanentAddress = permanentAddress;
        this.PermanentAddress1 = permanentAddress1;
        this.PermanentAddress2 = permanentAddress2;
        this.PermanentAddress3 = permanentAddress3;
        this.PhoneOffice = phoneOffice;
        this.PhoneResidence = phoneResidence;
        this.Mobile = mobile;
        this.Email = email;
        this.Fax = fax;
        this.OtherContactInfo = otherContactInfo;
        this.Comn_GenderID = comn_GenderID;
        this.PresentIEBMembershipNo = presentIEBMembershipNo;
        this.Mem_SubDivisionID = mem_SubDivisionID;
        this.DeclarationDate = declarationDate;
        this.Mem_ApprovedCouncilMeetingID = mem_ApprovedCouncilMeetingID;
        this.ScrollNo = scrollNo;
        this.ReceiptDate = receiptDate;
        this.CopiesOfCertificates = copiesOfCertificates;
        this.CopiesOfCertificatesComment = copiesOfCertificatesComment;
        this.CopiesOfTranscripts = copiesOfTranscripts;
        this.CopiesOfTranscriptsComment = copiesOfTranscriptsComment;
        this.PhotoEnclosed = photoEnclosed;
        this.ProfessionalRecordEnclosed = professionalRecordEnclosed;
        this.ProfessionalRecordEnclosedComment = professionalRecordEnclosedComment;
        this.RecomendationOffice = recomendationOffice;
        this.RecomenDationCommentOffice = recomenDationCommentOffice;
        this.AgeMembershipSection = ageMembershipSection;
        this.Education = education;
        this.Exprerience = exprerience;
        this.RecomendationMembershipSec = recomendationMembershipSec;
        this.RecomenDationCommentMembershipSec = recomenDationCommentMembershipSec;
        this.MembershipSectionEmployeeID = membershipSectionEmployeeID;
        this.Comn_StatusID = comn_StatusID;
        this.MembershipCommiteeMemebershipNo = membershipCommiteeMemebershipNo;
        this.MembershipCommiteeMemebershipTypeID = membershipCommiteeMemebershipTypeID;
        this.PictureURL = pictureURL;
        this.SignatureURL = signatureURL;
        this.Comn_UniversityID = comn_UniversityID;
        this.Comn_DepartmentID = comn_DepartmentID;
        this.PassingYear = passingYear;
        this.Comn_OfficeID = comn_OfficeID;
        this.Comn_BloodGroup = comn_BloodGroup;
        this.PassportNo = passportNo;
        this.NationalIDNo = nationalIDNo;
        this.BirthRegistrationID = birthRegistrationID;
        this.ExtraField1 = extraField1;
        this.ExtraField2 = extraField2;
        this.ExtraField3 = extraField3;
        this.ExtraField4 = extraField4;
        this.ExtraField5 = extraField5;
        this.ExtraField6 = extraField6;
        this.ExtraField7 = extraField7;
        this.ExtraField8 = extraField8;
        this.ExtraField9 = extraField9;
        this.ExtraField10 = extraField10;
        this.ExtraField11 = extraField11;
        this.ExtraField12 = extraField12;
        this.ExtraField13 = extraField13;
        this.ExtraField14 = extraField14;
        this.ExtraField15 = extraField15;
        this.ExtraField16 = extraField16;
        this.ExtraField17 = extraField17;
        this.ExtraField18 = extraField18;
        this.ExtraField19 = extraField19;
        this.ExtraField20 = extraField20;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
        this.Comn_RowStatusID = comn_RowStatusID;
    }


    private int _mem_MemberID;
    public int Mem_MemberID
    {
        get { return _mem_MemberID; }
        set { _mem_MemberID = value; }
    }

    private string _memberShipNo;
    public string MemberShipNo
    {
        get { return _memberShipNo; }
        set { _memberShipNo = value; }
    }

    private int _memberShipNoDigit;
    public int MemberShipNoDigit
    {
        get { return _memberShipNoDigit; }
        set { _memberShipNoDigit = value; }
    }

    private int _mem_MemberTypeID;
    public int Mem_MemberTypeID
    {
        get { return _mem_MemberTypeID; }
        set { _mem_MemberTypeID = value; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set { _dateOfBirth = value; }
    }

    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    private int _comn_NationalityID;
    public int Comn_NationalityID
    {
        get { return _comn_NationalityID; }
        set { _comn_NationalityID = value; }
    }

    private string _placeOfBrith;
    public string PlaceOfBrith
    {
        get { return _placeOfBrith; }
        set { _placeOfBrith = value; }
    }

    private string _mailingAddress1;
    public string MailingAddress1
    {
        get { return _mailingAddress1; }
        set { _mailingAddress1 = value; }
    }

    private string _mailingAddress2;
    public string MailingAddress2
    {
        get { return _mailingAddress2; }
        set { _mailingAddress2 = value; }
    }

    private string _mailingAddress3;
    public string MailingAddress3
    {
        get { return _mailingAddress3; }
        set { _mailingAddress3 = value; }
    }

    private string _mailingAddress;
    public string MailingAddress
    {
        get { return _mailingAddress; }
        set { _mailingAddress = value; }
    }

    private string _permanentAddress;
    public string PermanentAddress
    {
        get { return _permanentAddress; }
        set { _permanentAddress = value; }
    }

    private string _permanentAddress1;
    public string PermanentAddress1
    {
        get { return _permanentAddress1; }
        set { _permanentAddress1 = value; }
    }

    private string _permanentAddress2;
    public string PermanentAddress2
    {
        get { return _permanentAddress2; }
        set { _permanentAddress2 = value; }
    }

    private string _permanentAddress3;
    public string PermanentAddress3
    {
        get { return _permanentAddress3; }
        set { _permanentAddress3 = value; }
    }

    private string _phoneOffice;
    public string PhoneOffice
    {
        get { return _phoneOffice; }
        set { _phoneOffice = value; }
    }

    private string _phoneResidence;
    public string PhoneResidence
    {
        get { return _phoneResidence; }
        set { _phoneResidence = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _fax;
    public string Fax
    {
        get { return _fax; }
        set { _fax = value; }
    }

    private string _otherContactInfo;
    public string OtherContactInfo
    {
        get { return _otherContactInfo; }
        set { _otherContactInfo = value; }
    }

    private int _comn_GenderID;
    public int Comn_GenderID
    {
        get { return _comn_GenderID; }
        set { _comn_GenderID = value; }
    }

    private string _presentIEBMembershipNo;
    public string PresentIEBMembershipNo
    {
        get { return _presentIEBMembershipNo; }
        set { _presentIEBMembershipNo = value; }
    }

    private int _mem_SubDivisionID;
    public int Mem_SubDivisionID
    {
        get { return _mem_SubDivisionID; }
        set { _mem_SubDivisionID = value; }
    }

    private DateTime _declarationDate;
    public DateTime DeclarationDate
    {
        get { return _declarationDate; }
        set { _declarationDate = value; }
    }

    private int _mem_ApprovedCouncilMeetingID;
    public int Mem_ApprovedCouncilMeetingID
    {
        get { return _mem_ApprovedCouncilMeetingID; }
        set { _mem_ApprovedCouncilMeetingID = value; }
    }

    private int _scrollNo;
    public int ScrollNo
    {
        get { return _scrollNo; }
        set { _scrollNo = value; }
    }

    private DateTime _receiptDate;
    public DateTime ReceiptDate
    {
        get { return _receiptDate; }
        set { _receiptDate = value; }
    }

    private bool _copiesOfCertificates;
    public bool CopiesOfCertificates
    {
        get { return _copiesOfCertificates; }
        set { _copiesOfCertificates = value; }
    }

    private string _copiesOfCertificatesComment;
    public string CopiesOfCertificatesComment
    {
        get { return _copiesOfCertificatesComment; }
        set { _copiesOfCertificatesComment = value; }
    }

    private bool _copiesOfTranscripts;
    public bool CopiesOfTranscripts
    {
        get { return _copiesOfTranscripts; }
        set { _copiesOfTranscripts = value; }
    }

    private string _copiesOfTranscriptsComment;
    public string CopiesOfTranscriptsComment
    {
        get { return _copiesOfTranscriptsComment; }
        set { _copiesOfTranscriptsComment = value; }
    }

    private bool _photoEnclosed;
    public bool PhotoEnclosed
    {
        get { return _photoEnclosed; }
        set { _photoEnclosed = value; }
    }

    private bool _professionalRecordEnclosed;
    public bool ProfessionalRecordEnclosed
    {
        get { return _professionalRecordEnclosed; }
        set { _professionalRecordEnclosed = value; }
    }

    private string _professionalRecordEnclosedComment;
    public string ProfessionalRecordEnclosedComment
    {
        get { return _professionalRecordEnclosedComment; }
        set { _professionalRecordEnclosedComment = value; }
    }

    private bool _recomendationOffice;
    public bool RecomendationOffice
    {
        get { return _recomendationOffice; }
        set { _recomendationOffice = value; }
    }

    private string _recomenDationCommentOffice;
    public string RecomenDationCommentOffice
    {
        get { return _recomenDationCommentOffice; }
        set { _recomenDationCommentOffice = value; }
    }

    private string _ageMembershipSection;
    public string AgeMembershipSection
    {
        get { return _ageMembershipSection; }
        set { _ageMembershipSection = value; }
    }

    private string _education;
    public string Education
    {
        get { return _education; }
        set { _education = value; }
    }

    private string _exprerience;
    public string Exprerience
    {
        get { return _exprerience; }
        set { _exprerience = value; }
    }

    private bool _recomendationMembershipSec;
    public bool RecomendationMembershipSec
    {
        get { return _recomendationMembershipSec; }
        set { _recomendationMembershipSec = value; }
    }

    private string _recomenDationCommentMembershipSec;
    public string RecomenDationCommentMembershipSec
    {
        get { return _recomenDationCommentMembershipSec; }
        set { _recomenDationCommentMembershipSec = value; }
    }

    private int _membershipSectionEmployeeID;
    public int MembershipSectionEmployeeID
    {
        get { return _membershipSectionEmployeeID; }
        set { _membershipSectionEmployeeID = value; }
    }

    private int _comn_StatusID;
    public int Comn_StatusID
    {
        get { return _comn_StatusID; }
        set { _comn_StatusID = value; }
    }

    private int _membershipCommiteeMemebershipNo;
    /// <summary>
    /// Office Upojela ID
    /// </summary>
    public int MembershipCommiteeMemebershipNo
    {
        get { return _membershipCommiteeMemebershipNo; }
        set { _membershipCommiteeMemebershipNo = value; }
    }

    private int _membershipCommiteeMemebershipTypeID;
    public int MembershipCommiteeMemebershipTypeID
    {
        get { return _membershipCommiteeMemebershipTypeID; }
        set { _membershipCommiteeMemebershipTypeID = value; }
    }

    private string _pictureURL;
    public string PictureURL
    {
        get { return _pictureURL; }
        set { _pictureURL = value; }
    }

    private string _signatureURL;
    public string SignatureURL
    {
        get { return _signatureURL; }
        set { _signatureURL = value; }
    }

    private int _comn_UniversityID;
    public int Comn_UniversityID
    {
        get { return _comn_UniversityID; }
        set { _comn_UniversityID = value; }
    }

    private int _comn_DepartmentID;
    public int Comn_DepartmentID
    {
        get { return _comn_DepartmentID; }
        set { _comn_DepartmentID = value; }
    }

    private int _passingYear;
    public int PassingYear
    {
        get { return _passingYear; }
        set { _passingYear = value; }
    }

    private int _comn_OfficeID;
    public int Comn_OfficeID
    {
        get { return _comn_OfficeID; }
        set { _comn_OfficeID = value; }
    }

    private string _comn_BloodGroup;
    public string Comn_BloodGroup
    {
        get { return _comn_BloodGroup; }
        set { _comn_BloodGroup = value; }
    }

    private string _passportNo;
    public string PassportNo
    {
        get { return _passportNo; }
        set { _passportNo = value; }
    }

    private string _nationalIDNo;
    public string NationalIDNo
    {
        get { return _nationalIDNo; }
        set { _nationalIDNo = value; }
    }

    private string _birthRegistrationID;
    public string BirthRegistrationID
    {
        get { return _birthRegistrationID; }
        set { _birthRegistrationID = value; }
    }

    private string _extraField1;
    /// <summary>
    /// Job Designation
    /// </summary>
    public string ExtraField1
    {
        get { return _extraField1; }
        set { _extraField1 = value; }
    }

    private string _extraField2;
    /// <summary>
    /// Company Name
    /// </summary>
    public string ExtraField2
    {
        get { return _extraField2; }
        set { _extraField2 = value; }
    }

    private string _extraField3;
    /// <summary>
    /// Company Type
    /// </summary>
    public string ExtraField3
    {
        get { return _extraField3; }
        set { _extraField3 = value; }
    }

    private string _extraField4;
    /// <summary>
    /// Company Address
    /// </summary>
    public string ExtraField4
    {
        get { return _extraField4; }
        set { _extraField4 = value; }
    }

    private string _extraField5;
    /// <summary>
    /// Mailing Address District
    /// </summary>
    public string ExtraField5
    {
        get { return _extraField5; }
        set { _extraField5 = value; }
    }

    private string _extraField6;
    /// <summary>
    /// Mailing Address Upozilla
    /// </summary>
    public string ExtraField6
    {
        get { return _extraField6; }
        set { _extraField6 = value; }
    }

    private string _extraField7;
    /// <summary>
    /// Mailing Other Upozila
    /// </summary>
    public string ExtraField7
    {
        get { return _extraField7; }
        set { _extraField7 = value; }
    }

    private string _extraField8;
    /// <summary>
    /// Permanent Address District
    /// </summary>
    public string ExtraField8
    {
        get { return _extraField8; }
        set { _extraField8 = value; }
    }

    private string _extraField9;
    /// <summary>
    /// Permanent Address Upozilla
    /// </summary>
    public string ExtraField9
    {
        get { return _extraField9; }
        set { _extraField9 = value; }
    }

    private string _extraField10;
    /// <summary>
    /// Passsword
    /// </summary>
    public string ExtraField10
    {
        get { return _extraField10; }
        set { _extraField10 = value; }
    }

    private string _extraField11;
    /// <summary>
    /// Passsword recovary in email
    /// </summary>
    public string ExtraField11
    {
        get { return _extraField11; }
        set { _extraField11 = value; }
    }

    private string _extraField12;
    /// <summary>
    /// Passsword recovary in SMS
    /// </summary>
    public string ExtraField12
    {
        get { return _extraField12; }
        set { _extraField12 = value; }
    }

    private string _extraField13;
    /// <summary>
    /// Login
    /// </summary>
    public string ExtraField13
    {
        get { return _extraField13; }
        set { _extraField13 = value; }
    }

    private string _extraField14;
    /// <summary>
    /// Permanent Address Other Upozila
    /// </summary>
    public string ExtraField14
    {
        get { return _extraField14; }
        set { _extraField14 = value; }
    }

    private string _extraField15;
    public string ExtraField15
    {
        get { return _extraField15; }
        set { _extraField15 = value; }
    }

    private string _extraField16;
    public string ExtraField16
    {
        get { return _extraField16; }
        set { _extraField16 = value; }
    }

    private string _extraField17;
    public string ExtraField17
    {
        get { return _extraField17; }
        set { _extraField17 = value; }
    }

    private string _extraField18;
    public string ExtraField18
    {
        get { return _extraField18; }
        set { _extraField18 = value; }
    }

    private string _extraField19;
    /// <summary>
    /// religion
    /// </summary>
    public string ExtraField19
    {
        get { return _extraField19; }
        set { _extraField19 = value; }
    }

    private string _extraField20;
    /// <summary>
    /// Foreign
    /// </summary>
    public string ExtraField20
    {
        get { return _extraField20; }
        set { _extraField20 = value; }
    }

    private int _addedBy;
    public int AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private int _modifiedBy;
    public int ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }

    private int _comn_RowStatusID;
    public int Comn_RowStatusID
    {
        get { return _comn_RowStatusID; }
        set { _comn_RowStatusID = value; }
    }
}
