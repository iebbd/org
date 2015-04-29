<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="RegKitDistributionDelivered.aspx.cs" Inherits="Convention_RegKitDistribution" %>

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
    
   
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
    <ItemTemplate>
    <br /><br />
        <apan style="margin:20px;"><%#Eval("ExtraField4") %></apan>
   <br /> <br /></ItemTemplate>
    </asp:DataList>
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
    <ItemTemplate>
      <br /> <br /><apan style="margin:20px;"><%#Eval("ExtraField4") %></apan>
      
    <br /><br /></ItemTemplate>
    </asp:DataList>

</asp:Content>

