<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="RegKitDistribution.aspx.cs" Inherits="Convention_RegKitDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style21
        {
            width: 50%;font-size:25px;
        }
        .style22
        {
            text-align: right; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style21" border="1" cellpadding="3" cellspacing="0">
        <tr>
            <td class="menuL2">
                &nbsp;</td>
            <td>
                Offline</td>
            <td>
                Online</td>
            <td>
                Total</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="menuL2">
                Delivered</td>
            <td class="style22">
                <asp:Label ID="lblOfflineDelivered" runat="server" Text="" Font-Size="25px"></asp:Label></td>
            <td class="style22">
                <asp:Label ID="lblOnlineDelivered" runat="server" Text="" Font-Size="25px"></asp:Label></td>
            <td class="style22">
                <asp:Label ID="lblTotalDelivered" runat="server" Text="" Font-Size="25px"></asp:Label></td>
            <td class="style22">
                <asp:Label ID="lblPer" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="menuL2">
                Remaining</td>
            <td class="style22">
                <asp:Label ID="lblOfflineRemaining" runat="server" Text="" Font-Size="25px"></asp:Label></td>
            <td class="style22">
                <asp:Label ID="lblOnlineRemaining" runat="server" Text="" Font-Size="25px"></asp:Label></td>
       <td class="style22">
                <asp:Label ID="lblTotalRemaining" runat="server" Text="" Font-Size="25px"></asp:Label></td>
       <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="menuL2">
                Total</td>
            <td class="style22">
                <asp:Label ID="lblOfflineTotal" runat="server" Text="" Font-Size="25px"></asp:Label></td>
            <td class="style22">
                <asp:Label ID="lblOnlineTotal" runat="server" Text=""  Font-Size="25px"></asp:Label></td>
        <td class="style22">
                <asp:Label ID="lblTotal" runat="server" Text=""  Font-Size="25px"></asp:Label>
               </td>
        <td class="style22">
                &nbsp;</td>
        </tr>
    </table>
    
    <hr />
    <asp:Label ID="lblSummary" runat="server" Text=""></asp:Label>
    <hr />
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
    <ItemTemplate>
    <br /><br />
        <a href='DistributionConv_RegistrationOfflineDisplay.aspx?mem_MemberID=<%#Eval("Mem_MemberID") %>' ><apan style="margin:20px;"><%#Eval("ExtraField4") %></apan></a>
   <br /> <br /></ItemTemplate>
    </asp:DataList>
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
    <ItemTemplate>
      <br /> <br /> <a href='DistributionConv_RegistrationDisplay.aspx?mem_MemberID=<%#Eval("Mem_MemberID") %>'><apan style="margin:20px;"><%#Eval("ExtraField4") %></apan></a>
      <br />(<%#Eval("Mem_MemberID")%>)
    <br /></ItemTemplate>
    </asp:DataList>

</asp:Content>

