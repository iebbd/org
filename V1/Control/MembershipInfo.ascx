<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MembershipInfo.ascx.cs" Inherits="Control_MembershipInfo" %>
  <style type="text/css">
      .style1
      {
          width: 114px;
          height: 152px;
      }
      .style2
      {
          width: 100%;
      }
  </style>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  <asp:HiddenField ID="hfMem_MemeberID" runat="server" />
    <asp:HiddenField ID="hfLoginID" runat="server" />
    <div>
    
        <table style="padding-left: 345px" ID="tbl_SearchByMembershipNo" runat="server">
            <tr>
                <td>
                    Membership No
                </td>
                <td>
                    <asp:TextBox ID="txtSearchMembershipNo" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="tabs">
            <table>
                <tr class="tr_header" id="tr_Personal_title" runat="server">
                    <td>
                        Personal info
                    </td>
                    <td>
                        Contact Info
                    </td>
                </tr>
                <tr  id="tr_Personal_Details" runat="server">
                    <td valign="top" class="td_Details">
                        <h2>
                        </h2>
                        <div class="tabbody">
                            <table id='tbl_PersonalInfo'>
                                <tr>
                                    <td>
                                        <table>
                                        
                                <tr>
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" Text="Name: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" Text="" Font-Bold="true">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                        <tr>
                                                <td>
                                                    <asp:Label ID="lblMem_MemberTypeID" runat="server" Text="Membership Type: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="ddlMem_MemberType" runat="server" RepeatDirection="Horizontal">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr  id="tr_Upgradation" visible="false" runat="server" style='display:none;'>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                    <asp:Button ID="a_ApplyForMember" runat="server" visible="false"  Text="Apply for Member" 
                                                        onclick="a_ApplyForMember_Click" />
                                                    <asp:Button ID="a_ApplyForFellow" runat="server" visible="false"  Text="Apply for Fellow" 
                                                        onclick="a_ApplyForFellow_Click" />
                                                    <%--<a target="_blank" ID="a_ApplyForMember" visible="false" runat="server">Apply for Member</a>
                                                    <a target="_blank" ID="a_ApplyForFellow" visible="false" runat="server">Apply for Fellow</a>--%>
                                                    <asp:Label ID="lblAppliedFor" runat="server" Text="" ForeColor="Green"></asp:Label>
                                                    <asp:HiddenField ID="hfPassingYear" runat="server" />
                                                </td>
                                            </tr>
                                            <tr  id="tr_ScrollNo" visible="false" runat="server">
                                                <td>
                                                    <asp:Label ID="lblScrollNo" runat="server" Text="ScrollNo: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtScrollNo" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="tr_MembershipNo" runat="server">
                                                <td>
                                                    <asp:Label ID="lblMemberShipNo" runat="server" Text="Membership No: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMemberShipNo" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            <tr id="tr_MemberShipNoDigit" runat="server">
                                                <td>
                                                    <asp:Label ID="lblMemberShipNoDigit" runat="server" Text="MemberShip No: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMemberShipNoDigit" runat="server" Text="0">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                    <tr>
                                                    
                                                     <td colspan="3">
                                                    <asp:Label ID="lblPresentIEBMembershipNo" runat="server" Text="">
                    </asp:Label>
                                               
                                                    <asp:TextBox ID="txtPresentIEBMembershipNo" runat="server" Text="" Width="226px">
                    </asp:TextBox>
                                                </td>
                                                    </tr>
        <tr>
          
                                                <td  width="112px">
                                                    <asp:Label ID="lblComn_GenderID" runat="server" Text="Gender: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_Gender" runat="server" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
            <td rowspan="4" align="right">
                
                <asp:Image ID="imgMemberPicture" runat="server" Height="85px" />
                                        <br />
                                        <asp:FileUpload ID="fudMemeberPicture" runat="server" Visible="false"/>
                </td>
        </tr>
        
        <tr>
                                                <td>
                                                    <asp:Label ID="lblComn_BloodGroup" runat="server" Text="Blood Group: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    
                                                    <asp:DropDownList ID="ddlComn_BloodGroup" runat="server" Width="150px">
                                                    <asp:ListItem Value="" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="A+" Text="A+"></asp:ListItem>
                                                    <asp:ListItem Value="A-" Text="A-"></asp:ListItem>
                                                    <asp:ListItem Value="B+" Text="B+"></asp:ListItem>
                                                    <asp:ListItem Value="B-" Text="B-"></asp:ListItem>
                                                    <asp:ListItem Value="AB+" Text="AB+"></asp:ListItem>
                                                    <asp:ListItem Value="AB-" Text="AB-"></asp:ListItem>
                                                    <asp:ListItem Value="O-" Text="O-"></asp:ListItem>
                                                    <asp:ListItem Value="O+" Text="O+"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblComn_RowStatusID" runat="server" Text="Status: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_RowStatus" runat="server" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            
   
                                           
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDateOfBirth" runat="server" Text="" Width="80px">
                    </asp:TextBox>dd-mm-yyyy
                                                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server"
                                                        TargetControlID="txtDateOfBirth">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>
                                             </table>
                                                </td>
                                            </tr>
                                            <tr id="tr_Age" runat="server" >
                                                <td>
                                                    <asp:Label ID="lblAge" runat="server" Text="Age: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAge" runat="server" Text="0">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display:none;">
                                                <td>
                                                    <asp:Label ID="lblComn_NationalityID" runat="server" Text="Nationality: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_Nationality" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr  id="tr_PlaceOfBrith" runat="server">
                                                <td>
                                                    <asp:Label ID="lblPlaceOfBrith" runat="server" Text="Place Of Brith: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPlaceOfBrith" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            
                                            <tr style="display:none;">
                                                <td>
                                                    <asp:Label ID="lblMem_DivisionID" runat="server" Text="Division: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMem_Division" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMem_Division_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMem_SubDivisionID" runat="server" Text="Sub Division: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMem_SubDivision" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr  id="tr_DeclarationDate" runat="server">
                                                <td>
                                                    <asp:Label ID="lblDeclarationDate" runat="server" Text="Declaration Date: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDeclarationDate" runat="server" Text="">
                    </asp:TextBox>
                                                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDeclarationDate">
                                    </ajaxToolkit:CalendarExtender>--%>
                                                </td>
                                            </tr>
                                            <tr id="tr_ApprovedCouncilMeetingID" runat="server">
                                                <td>
                                                    <asp:Label ID="lblMem_ApprovedCouncilMeetingID" runat="server" Text="Council Meeting: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMem_ApprovedCouncilMeeting" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblReceiptDate" runat="server" Text="ReceiptDate: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReceiptDate" runat="server" Text="">
                    </asp:TextBox>
                                                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtReceiptDate">
                                    </ajaxToolkit:CalendarExtender>--%>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCopiesOfCertificates" runat="server" Text="CopiesOfCertificates: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbCopiesOfCertificates" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCopiesOfCertificatesComment" runat="server" Text="CopiesOfCertificatesComment: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCopiesOfCertificatesComment" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCopiesOfTranscripts" runat="server" Text="CopiesOfTranscripts: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbCopiesOfTranscripts" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblCopiesOfTranscriptsComment" runat="server" Text="CopiesOfTranscriptsComment: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCopiesOfTranscriptsComment" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblPhotoEnclosed" runat="server" Text="PhotoEnclosed: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbPhotoEnclosed" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblProfessionalRecordEnclosed" runat="server" Text="ProfessionalRecordEnclosed: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbProfessionalRecordEnclosed" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblProfessionalRecordEnclosedComment" runat="server" Text="ProfessionalRecordEnclosedComment: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtProfessionalRecordEnclosedComment" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblRecomendationOffice" runat="server" Text="RecomendationOffice: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbRecomendationOffice" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblRecomenDationCommentOffice" runat="server" Text="RecomenDationCommentOffice: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRecomenDationCommentOffice" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblAgeMembershipSection" runat="server" Text="AgeMembershipSection: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAgeMembershipSection" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblEducation" runat="server" Text="Education: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEducation" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExprerience" runat="server" Text="Exprerience: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExprerience" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblRecomendationMembershipSec" runat="server" Text="RecomendationMembershipSec: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="cbRecomendationMembershipSec" runat="server" />
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblRecomenDationCommentMembershipSec" runat="server" Text="RecomenDationCommentMembershipSec: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRecomenDationCommentMembershipSec" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblMembershipSectionEmployeeID" runat="server" Text="MembershipSectionEmployeeID: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMembershipSectionEmployee" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblComn_StatusID" runat="server" Text="Comn_StatusID: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_Status" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblMembershipCommiteeMemebershipNo" runat="server" Text="MembershipCommiteeMemebershipNo: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMembershipCommiteeMemebershipNo" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblMembershipCommiteeMemebershipTypeID" runat="server" Text="MembershipCommiteeMemebershipTypeID: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMembershipCommiteeMemebershipType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblPictureURL" runat="server" Text="PictureURL: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPictureURL" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblSignatureURL" runat="server" Text="SignatureURL: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSignatureURL" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display:none;">
                                                <td>
                                                    <asp:Label ID="lblComn_UniversityID" runat="server" Text="Institution: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_University" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblComn_DepartmentID" runat="server" Text="Comn_DepartmentID: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_Department" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display:none;">
                                                <td>
                                                    <asp:Label ID="lblPassingYear" runat="server" Text="Passing Year: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassingYear" runat="server" Text="0">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                            
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblPassportNo" runat="server" Text="PassportNo: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassportNo" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblNationalIDNo" runat="server" Text="NationalIDNo: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlNational" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblBirthRegistrationID" runat="server" Text="BirthRegistrationID: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBirthRegistration" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField6" runat="server" Text="ExtraField6: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField6" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField7" runat="server" Text="ExtraField7: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField8" runat="server" Text="ExtraField8: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField8" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField9" runat="server" Text="ExtraField9: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField9" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField10" runat="server" Text="ExtraField10: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField10" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField11" runat="server" Text="ExtraField11: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField11" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField12" runat="server" Text="ExtraField12: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField12" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField13" runat="server" Text="ExtraField13: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField13" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField14" runat="server" Text="ExtraField14: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField15" runat="server" Text="ExtraField15: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField15" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField16" runat="server" Text="ExtraField16: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField16" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField17" runat="server" Text="ExtraField17: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField17" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField18" runat="server" Text="ExtraField18: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField18" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField19" runat="server" Text="ExtraField19: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField19" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <asp:Label ID="lblExtraField20" runat="server" Text="ExtraField20: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField20" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                </tr>
                                
                            </table>
                        </div>
                    </td>
                    <td valign="top" class="td_Details">
                        <div class="tabbody">
                            <table>
                                
                                <tr style="background-color:#E4E4E4;">
                                    <td valign="top">
                                        <asp:Label ID="lblMailingAddress1" runat="server" Text="Mailing Address: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                       
                    <asp:TextBox ID="txtMailingAddress1" runat="server" Text=""
                                            Height="65px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="background-color:#E4E4E4;">
                                    <td>
                                        <asp:Label ID="lblMailingAddress2" runat="server" Text="">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMailingAddress2" runat="server" Text="">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="background-color:#E4E4E4;">
                                    <td valign="top">
                                        <asp:Label ID="lblMailingAddress3" runat="server" Text="District, Upazila<br/>Postal Code"
                                            Font-Size="10">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMailingAddress3" runat="server" Text="">
                    </asp:TextBox>
                                                <asp:DropDownList ID="ddlMailingAddressDistrict" runat="server" Visible="false" Width="150px">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMailingAddressUpozila" runat="server" Width="150px"  Visible="false">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:TextBox ID="txtExtraField7" runat="server" Text=""  Width="200px" Visible="false">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                                <td>
                                                    <asp:Label ID="lblComn_OfficeID" runat="server" Text="Center: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlComn_Office" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                <tr style="display:none;">
                                    <td>
                                        <asp:Label ID="lblMailingAddress" runat="server" Text="">
                    </asp:Label>
                    
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMailingAddress" runat="server" Text=""
                                            Height="65px" TextMode="MultiLine">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                
                                    <td>
                                        <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPermanentAddress" runat="server" Text="">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr  id="tr_PermanentAddress1" runat="server"  style="background-color:#E4E4E4;">
                                    <td>
                                        <asp:Label ID="lblPermanentAddress1" runat="server" Text="Permanent Address: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPermanentAddress1" runat="server" Text="">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr  id="tr_PermanentAddress2" runat="server" style="background-color:#E4E4E4;">
                                    <td>
                                        <asp:Label ID="lblPermanentAddress2" runat="server" Text="">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPermanentAddress2" runat="server" Text="">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr  id="tr_PermanentAddress3" runat="server" style="background-color:#E4E4E4;">
                                    <td valign="top">
                                        
                                        <asp:Label ID="lblPermanentAddress3" runat="server" Text="District, Upazila<br/>Postal Code"
                                            Font-Size="10">
                    </asp:Label>
                                    </td>
                                    <td>
                                                    <asp:TextBox ID="txtPermanentAddress3" runat="server" Text=""></asp:TextBox>
                                                    <br />
                                    <asp:DropDownList ID="ddlPermanentAddressDistrict" runat="server"   Width="150px" Visible="false">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlPermanentAddressUpozila" runat="server" Width="150px" Visible="false">
                                                    </asp:DropDownList>
                                                    <br />
                    
                    <asp:TextBox ID="txtExtraField14" runat="server" Text=""  Width="150px" Visible="false">
                    </asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr   id="tr_PhoneOffice" runat="server">
                                    <td>
                                        <asp:Label ID="lblPhoneOffice" runat="server" Text="Phone Office: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneOffice" runat="server" Text="" Width="84px">
                    </asp:TextBox>
                    H:
                    <asp:TextBox ID="txtPhoneResidence" runat="server" Text="" Width="80px">
                    </asp:TextBox>
                    Fax
                    <asp:TextBox ID="txtFax" runat="server" Text="" Width="80px">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
                    </asp:Label><span style="font-size:10px;">No need +88</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMobile" runat="server" Text="" Width="107px">
                    </asp:TextBox>
                    Alt. Mobile <asp:TextBox ID="txtOtherContactInfo" runat="server" Text="" Width="118px">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text="Email: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Text="">
                    </asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Go to: ">
                    </asp:Label>
                                    </td>
                                    <td>
                                       <a href="#ContentPlaceHolder1_MembershipInfo1_tr_History_title">Current Job Details</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr  >
                    <td class="td_Details" align="center" style="padding:5px;" colspan="2">
                        You can modify some fields by yourself. For remaining information please mail to <a href="mailto:membership@iebbd.org" target="_blank">membership@iebbd.org</a>.
                    </td>
                </tr>
                <tr>
                                                <td colspan="2" align="center">
                                                    <p style="padding:5px 0 0 5px;" class="p_button"> 
                                                    <asp:Button ID="btnAdd" runat="server" Text="Next" OnClick="btnAdd_Click" />
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update General Information" OnClick="btnUpdate_Click" />
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" Visible="false" OnClick="btnClear_Click" />
                                                </p>
                                                </td>
                                                
                                            </tr>
                                            
                <tr class="tr_header" id="tr_Fees_title" runat="server">
                    <td colspan="2">
                        Fees Payment History
                            &
                        Dues
                    </td>
                </tr>
                <tr id="tr_Fees_Details" runat="server">
                    <td class="td_Details" colspan="2">
                        <div class="tabbody">
                            <asp:GridView ID="gvMem_Fees" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                                CssClass="gridCss" align="Center" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Paid upto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidFor" runat="server" Text='<%#Eval("PaidFor") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Money Recipt # or Transaction ID(TrxID) for bKash">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRefferenceNo" runat="server" Text='<%#Eval("RefferenceNo") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDatePaid" runat="server" Text='<%#Eval("PaidDate","{0:dd MMM yyyy}") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0,0.00}") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server">
                        </asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblDues" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_CardPayment" runat="server" border='1' style="border:1px solid #33479E;" cellpadding="5" cellspacing="0">
                        <tr><td style="background-color:white; color:White;font-size:15px;" rowspan="4">
                            <img alt="Pay with DBBL Nexus/VISA/MasterCard " 
                                    class="style1" src="../images/DBBL/paywith.png" />
                            </td>
                            <td colspan="3" style="background-color:#33479E; color:White;font-size:15px;">
                                Pay your fees using any of the following card information:<br />(1)DBBL Nexus 
                                Card [issued from DBBL]
                                <br />
                                (2)VISA / MasterCard [issued form any bank]
                            </td>
                            </tr>
                        <tr>
                            <td align="right">
                                Payment for</td>
                            <td align="left" colspan="2">
                                <asp:RadioButtonList ID="rbtnPaymentFor" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Regular membership fee </asp:ListItem>
                                    <asp:ListItem Value="2">Life </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            
                        </tr>
                        <tr>
                        <td></td>
                        <td align="left" colspan="2">
                            <b style="color:Red;">Make sure your VISA / MasterCard is allowed (by Card Issuer bank) for online transaction.</b>
                            <a href='DBBLPayment.aspx' target="_blank">For More details please click here</a>.
                        </td>
                        </tr>
                            <tr>
                                <td align="right">
                                    Select card type</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rtbnCardType" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">
                                        <img src="../images/DBBL/card_dbbl.png" alt="DBBL Nexus"/>
                                    </asp:ListItem>
                                    <asp:ListItem Value="4">
                                        <img src="../images/DBBL/VISA.png" alt="VISA"/>
                                    </asp:ListItem>
                                    <asp:ListItem Value="5">
                                        <img src="../images/DBBL/mastercard.gif" alt="MasterCard"/>
                                    </asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="btnPaynow" runat="server" Text="Pay Now" 
                                        onclick="btnPaynow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
                <tr class="tr_header"  id="tr_History_title" runat="server">
                    <td>
                        Educational info
                    </td>
                    <td>
                        Present Job info
                    </td>
                </tr>
                <tr  id="tr_History_Details" runat="server">
                    <td valign="top" class="td_Details">
                        <div class="tabbody">
                            <div class="tableCss">
                                <asp:Button ID="btnAddEducationalInfoShow" runat="server" 
                                    Text="Add Educational Info" onclick="btnAddEducationalInfoShow_Click" />
                                <table ID="tblAddEducationalInfoShow" runat="server">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblComn_GegreeID" runat="server" Text="Degree:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlComn_Gegree" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Label ID="lblDegreeTitle" runat="server" Text="Degree Title:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDegreeTitle" runat="server" Text="">
                    </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblInstituteName" runat="server" Text="Institute:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInstituteName" runat="server" Text="">
                    </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="University<br/>/Board:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlComn_UniversityEducation" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Department:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubDivision" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblYearOfPassing" runat="server" Text="Passing Year:">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYearOfPassing" runat="server" Text="">
                    </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Label ID="lblComn_ResultTypeID" runat="server" Text="Result System: ">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlComn_ResultType" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblResult" runat="server" Text="Result: ">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResult" runat="server" Text="">
                    </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td>
                                            <asp:Label ID="lblDetails" runat="server" Text="Details: ">
                    </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDetails" runat="server" Text="" TextMode="MultiLine">
                    </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEducationalInfoAdd" runat="server" Text="Add Educational Info"
                                                OnClick="btnEducationalInfoAdd_Click" />
                                            <asp:Button ID="btnEducationalInfoUpdate" runat="server" Text="Update Educational Info"
                                                Visible="false" OnClick="btnEducationalInfoUpdate_Click" />
                                            <asp:Button ID="btnEducationalInfoAddLeter" runat="server" Text="Add Later" 
                                                onclick="btnEducationalInfoAddLeter_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <span style="color:Red;display:none;">If your educational information is missing then please wait<br />but if your educational information is wrong <br />then please mail to it@iebbd.org</span>
                            <asp:GridView ID="gvEducationalInfo" runat="server" AutoGenerateColumns="false" ShowFooter="false"
                                CssClass="gridCss" align="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:Label ID="Comn_GegreeName" runat="server" Text='<%#Eval("Comn_GegreeName") %>'>
                                        </asp:Label>
                                            (<asp:Label ID="Mem_SubDivisionName" runat="server" Text='<%#Eval("Mem_SubDivisionName") %>'>
                        </asp:Label>)
                                            <hr />
                                            <asp:Label ID="Comn_UniversityName" Font-Bold="True" runat="server" Text='<%#Eval("Comn_UniversityName") %>'>
                        </asp:Label>
                                            <div style="width: 350px; font-size: 10px;">
                                                (<%#Eval("Comn_UniversityFullName")%>)</div>
                                            <hr />
                                            Passing Year:
                                            <asp:Label ID="YearOfPassing" runat="server" Text='<%#Eval("YearOfPassing") %>'>
                        </asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Result:
                                            <asp:Label ID="Result" runat="server" Text='<%#Eval("Result") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Mem_EducationalInfoID") %>'
                                                OnClientClick="return confirm('Are You Sure To Delete?')" OnClick="lbDeleteEducationalInfo_Click">
                            Delete
                        </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                    <td valign="top" class="td_Details">
                        <div class="tabbody">
                        <table>
                        <tr>
                                                <td>
                                                    <asp:Label ID="lblExtraField1" runat="server" Text="Designation : ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblExtraField2" runat="server" Text="Company Name: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblExtraField3" runat="server" Text="Company Type: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblExtraField4" runat="server" Text="Company Address: ">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="District: "  Visible="false">
                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCompnayDistrict" runat="server"  Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                                <td>
                                                
                                                    <asp:DropDownList ID="ddlCompanyUpazila" runat="server" Width="200px" Visible="false">
                                                    </asp:DropDownList>
                                                    <asp:Button ID="btnUpdateAllINfo" runat="server" Text="Update"  OnClick="btnUpdate_Click"/>
                                                </td>
                                            </tr>
                        </table>
                        </div>
                    </td>
                </tr>
                <tr class="tr_header" id="tr_Files_Header" runat="server" style="display:none;">
                    <td colspan="2">
                        Files
                    </td>
                </tr>
                <tr id="tr_Files_Details" runat="server" style="display:none;">
                    <td class="td_Details" >
                        <a target="_blank" ID="a_print" runat="server" >Print Form</a><br />

                        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="false" ShowFooter="false"
                                CssClass="gridCss" align="Center">
                                <Columns>
                                    <asp:TemplateField HeaderText="Files">
                                        <ItemTemplate>
                                          <a target="_blank" href='../Files/File/membershipRegistration/MembersFiles/<%#Eval("FileName") %>'>  <asp:Label ID="Comn_GegreeName" runat="server" Text='<%#Eval("FileTypeName") %>'>
                                        </asp:Label></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Mem_EducationalInfoID") %>'
                                                OnClientClick="return confirm('Are You Sure To Delete?')" OnClick="lbDeleteEducationalInfo_Click">
                                                Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                    </td>
                    
                    <td class="td_Details" >
                        Upload Form (with recommendation part)
                        <br />
                        <asp:FileUpload ID="fudForm" runat="server" />
                        <br />
                        <asp:Button ID="btnFormUpload" runat="server" Text="Upload Form" 
                            onclick="btnFormUpload_Click" />
                    </td>
                </tr>
                <tr class="tr_header" id="tr_ProfessionalRecord_Header" runat="server" style="display:none;">
                    <td colspan="2">
                        Professional Record
                    </td>
                </tr>
                <tr id="tr_ProfessionalRecord_Details" runat="server" style="display:none;">
                    <td class="td_Details" colspan="2">
                        
                        <table class="style2" border="1" cellspacing="0" cellpadding="0">
                            <tr style="font-weight:bold;text-align:center;">
                                <td rowspan="2">
                                    SL.<br /> NO.</td>
                                <td colspan="2">
                                    PERIOD(Date)</td>
                                <td rowspan="2">
                                    DESIGNATION</td>
                                <td rowspan="2">
                                    EMPLOYER</td>
                                <td rowspan="2">
                                    BRIEF JOB DESCRIPTION</td>
                            </tr>
                            <tr style="font-weight:bold;text-align:center;">
                                <td>
                                    FROM</td>
                                <td>
                                    TO</td>
                            </tr>
                            <tr>
                                <td width="20px">
                                   1</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt1From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt1To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt1Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt1Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt1JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    2</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt2From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt2To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt2Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt2Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt2JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    3</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt3From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt3To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt3Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt3Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt3JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    4</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt4From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt4To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt4Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt4Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt4JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    5</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt5From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt5To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt5Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt5Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt5JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    6</td>
                                <td width="65px">
                                    <asp:TextBox ID="txt6From" runat="server" Width="62px"></asp:TextBox></td>
                                <td width="65px">
                                    <asp:TextBox ID="txt6To" runat="server" Width="62px"></asp:TextBox>
                                </td>
                                <td>
                                <asp:TextBox ID="txt6Designation" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                <td>
                                <asp:TextBox ID="txt6Employer" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                 <td>
                                <asp:TextBox ID="txt6JobDescription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                            </tr>
                        </table>
                        
                    </td>
                    </tr><tr style="display:none;">
                    <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Update"  OnClick="btnUpdate_Click"/>
                    </td>
                </tr>

            </table>
        </div>
   
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>