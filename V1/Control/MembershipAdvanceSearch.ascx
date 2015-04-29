<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MembershipAdvanceSearch.ascx.cs" Inherits="Control_MembershipAdvanceSearch" %>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table>
        <tr>
        <td valign="top">
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rbtnLMembershipType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Unknown" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="F" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="M" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        Membership No
                    </td>
                    <td>
                        <asp:TextBox ID="txtMemebershipNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        (Do not use <b>Engr.</b> or <b>MD.</b> Just give main name)
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
                    </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server" Text="">
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
                        <asp:Label ID="lblMem_DivisionID" runat="server" Text="Engr. Field: ">
                    </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMem_Division" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbtnlInstitutionType" runat="server" AutoPostBack="true"
                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnlInstitutionType_SelectedIndexChanged">
                            <asp:ListItem Value="BANGLADESH" Selected="True">BANGLADESH</asp:ListItem>
                            <asp:ListItem Value="FOREIGN">FOREIGN</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComn_UniversityID" runat="server" Text="Institution: ">
                    </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlComn_University" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassingYear" runat="server" Text="Passing Year: ">
                    </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassingYear" runat="server" Text="">
                    </asp:TextBox>
                    </td>
                </tr>
                
                <tr style="display: none;">
                    <td>
                        <asp:Label ID="lblMem_SubDivisionID" runat="server" Text="Sub Division: ">
                    </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMem_SubDivision" runat="server">
                        </asp:DropDownList>
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
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            </td>
            <td valign="top">
                <table>
                    <tr>
                        <td colspan="3" align="center">
                            <h1 style="padding: 0; margin: 0px;">
                                Memebers Directory</h1>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateOfBirth" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPlaceOfBrith" runat="server" Text="Place Of Brith: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPlaceOfBrith" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblComn_GenderID" runat="server" Text="Gender: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlComn_Gender" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPresentIEBMembershipNo" runat="server" Text="Present IEB<br/>Membership No: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPresentIEBMembershipNo" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <asp:Label ID="lblScrollNo" runat="server" Text="ScrollNo: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtScrollNo" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhoneOffice" runat="server" Text="Phone Office: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhoneOffice" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhoneResidence" runat="server" Text="Phone Residence: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhoneResidence" runat="server" Text="">
                    </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Address: ">
                    </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Text="">
                    </asp:TextBox>
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
                </table>
            </td>
            
        </tr>
    </table>
    <asp:GridView ID="gvMember" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:Label ID="Name" runat="server" Text='<%#Eval("Name") %>'>
                        </asp:Label>
                        <hr /><b>Address:</b>
                        <asp:Label ID="MailingAddress" runat="server" Text='<%#Eval("MailingAddress") %>'>
                        </asp:Label>
                        <hr />
                        <b>Email:</b>
                        <asp:Label ID="Email" runat="server" Text='<%#Eval("Email") %>'>
                        </asp:Label>
                        <br />
                   <b>Division:</b>
                        <asp:Label ID="Mem_SubDivisionName" runat="server" Text='<%#Eval("Mem_SubDivisionName") %>'>
                        </asp:Label>
                    &nbsp;<b>Center:</b>
                        <asp:Label ID="Comn_OfficeName" runat="server" Text='<%#Eval("Comn_OfficeName") %>'>
                        </asp:Label>
                        <hr />
                        <b>Institution:</b><asp:Label ID="Comn_UniversityName" runat="server" Text='<%#Eval("Comn_UniversityName") %>'>
                        </asp:Label>
                        (
                        <asp:Label ID="PassingYear" runat="server" Text='<%#Eval("PassingYear") %>'>
                        </asp:Label>
                        )
                        <asp:LinkButton ID="lbDelete" Visible="false" runat="server" CommandArgument='<%#Eval("Mem_MemberID") %>' OnClick="lbDelete_Click"  OnClientClick="return confirm('Are You Sure To Delete?')" >
                            In Active
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Picture">
                    <ItemTemplate>
                    <a href='<%#Eval("href") %>' target="_blank"><asp:Label ID="MemberShipNo" runat="server" Text='<%#Eval("MemberShipNo") %>'>
                        </asp:Label></a>
                        <br />
                            <asp:Image ID="Image1" runat="server" width="100px" ImageUrl='<%#Eval("PictureUrl") %>'/>
                            <br />
                            <asp:Label ID="Mobile" runat="server" Text='<%#Eval("Mobile") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    