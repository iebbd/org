<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMarque.ascx.cs" Inherits="Control_TopMarque" %>
<marquee class='topMarque' behavior="scroll"  scrollamount="2" loop="true" onmouseout="start ()" onmouseover="stop ()">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</marquee>
