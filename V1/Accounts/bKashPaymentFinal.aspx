<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="bKashPaymentFinal.aspx.cs" Inherits="payment_bKashPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td>TrxID</td>
        <td>
            <asp:TextBox ID="txtTrxID" runat="server"></asp:TextBox>
            </td>
        <td>Sender</td>
        <td>
            <asp:TextBox ID="txtSender" runat="server"></asp:TextBox>
        
        </td>
        <td>Amount</td>
        <td>
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
        
        </td>
    </tr>
     <tr>
        <td>ReferenceNo</td>
        <td>
            <asp:TextBox ID="txtReferenceNo" runat="server"></asp:TextBox>
        
        </td>
        <td>From</td>
        <td>
            <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        
        </td>
        <td>To</td>
        <td>
            <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td>Ref No final</td>
        <td>
            <asp:TextBox ID="txtReferenceNoFinal" runat="server"></asp:TextBox>
        
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="btnSearch_Click" />
        </td>
        <td>
        
    <asp:CheckBox ID="chkAll" runat="server" Text="All" Checked="true"/>
        </td>
        <td>
            <asp:Button ID="btnClear" runat="server" Text="Clear" 
                onclick="btnClear_Click"  />
        </td>
        <td>
            <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>

    <asp:DropDownList ID="ddlPaidFor" runat="server">
    </asp:DropDownList>
<asp:GridView ID="gvbKash" Width="100%" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
            <asp:TemplateField HeaderText="SI">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("Conv_JobFairID") %>' OnClick="lbSelect_Click">
                            Edit
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="TransactionID">
                    <ItemTemplate>
                        <asp:Label ID="lblTransactionID" runat="server" Text='<%#Eval("TransactionID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sender">
                    <ItemTemplate>
                        <asp:Label ID="lblIEBMembershipNo" runat="server" Text='<%#Eval("Sender") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReferenceNo">
                    <ItemTemplate>
                        <asp:Label ID="txtReferenceNoFinal" runat="server" Text='<%#Eval("FeferenceNoFinal") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MembershipNO">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMemberShipNo" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Proces">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" Checked="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="is Life">
                    <ItemTemplate>
                        <asp:DropDownList ID="rbtnPaidUpto" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mem">
                    <ItemTemplate>
                        <a href='../MembersArea/MembershipInfo.aspx?mem_MemberID=<%#Eval("ExtraField4") %>' target="_blank">Mem</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Con">
                    <ItemTemplate>
                        <a href='../MembersArea/ConventionPaymentPrint.aspx?Confirmation=1&Conv_RegistrationID=<%#Eval("ExtraField5") %>' target="_blank">Con</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="ExtraField4">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField5">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="TrancsactionTime">
                    <ItemTemplate>
                        <asp:Label ID="lblTrancsactionTime" runat="server" Text='<%#Eval("TrancsactionTime","{0:dd MMM yyyy hh:mm tt}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Conv_JobFairID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    <asp:Button ID="btnSaveInDBForMembershipFee" runat="server" Text="Save Membership Fee" 
        onclick="btnSaveInDBForMembershipFee_Click" />

        <asp:Button ID="btnConventionFee" runat="server" Text="Save Convention Fee" 
        onclick="btnConventionFee_Click" />

        <asp:Button ID="btnJobFairFee" runat="server" Text="Save Job Fair Fee" 
        onclick="btnJobFairFee_Click" />
        <table>
            <tr>
                <td>TrxID</td>
                <td>
                            <asp:TextBox ID="txtTrxIDUpdate" runat="server"></asp:TextBox></td>
                <td>Field</td>
                <td>
                    
                                <asp:DropDownList ID="ddlField" runat="server">
                                <asp:ListItem Value="Note">Note</asp:ListItem>
                                <asp:ListItem Value="ExtraField1">ExtraField1</asp:ListItem>
                                <asp:ListItem Value="ExtraField2">ExtraField2</asp:ListItem>
                                <asp:ListItem Value="ExtraField3">ExtraField3</asp:ListItem>
                                <asp:ListItem Value="ExtraField4">ExtraField4</asp:ListItem>
                                <asp:ListItem Value="ExtraField5">ExtraField5</asp:ListItem>
                                <asp:ListItem Value="FeferenceNoFinal">FeferenceNoFinal</asp:ListItem>
                                </asp:DropDownList>
                </td>

                <td>Value</td>
                <td>
                    <asp:TextBox ID="txtValue" runat="server" Width="530px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        onclick="btnUpdate_Click" /></td>
            </tr>
        </table>
</asp:Content>

