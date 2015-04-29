<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="SummaryOfConventionData.aspx.cs" Inherits="Convention_SummaryOfConventionData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Online
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <hr />
    Offline
     <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    <hr />
    Online
    <asp:GridView ID="GridView3" runat="server">
    </asp:GridView>
    <hr />
    Offline
     <asp:GridView ID="GridView4" runat="server">
    </asp:GridView>
    <asp:Label ID="lblSummary" runat="server" Text=""></asp:Label>
</asp:Content>

