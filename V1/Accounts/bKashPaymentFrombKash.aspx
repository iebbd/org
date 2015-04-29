<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="bKashPaymentFrombKash.aspx.cs" Inherits="payment_bKashPayment" %>

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
        <td colspan="3">
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="btnSearch_Click" />
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
                        <asp:Label ID="lblInstitution" runat="server" Text='<%#Eval("Amount") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReferenceNo">
                    <ItemTemplate>
                        <asp:Label ID="lblDeprtment" runat="server" Text='<%#Eval("ReferenceNo") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReferenceNo">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCorrctReferenceNo" runat="server" Text='<%#Eval("ReferenceNo") %>'>
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" Checked="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="ExtraField1">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField2">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField3">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField4">
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
                        <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("TrancsactionTime","{0:dd MMM yyyy hh:mm tt}") %>'>
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
    <asp:Button ID="btnSaveInDB" runat="server" Text="Save" 
        onclick="btnSaveInDB_Click" />
</asp:Content>

