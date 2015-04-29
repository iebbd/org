<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="EngineeringNews_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" cellspacing="1" cellpadding="4" border="0">

	<tbody><tr class="head">
		<td align="center"><span style="font-size:30px;">Engineering News (
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        ) <a href="Archive.aspx" target="_blank">Engr. News Archive</a></span>
        </td>
	</tr>
	<tr style="height:16px;"><td></td></tr>
</tbody></table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%">
    <tr>
        <td align="center">
            <asp:Label ID="lblOthers" runat="server" Text=""></asp:Label>
           
        </td>
    </tr>
    <tr>
        
        <td align="center">
            <asp:Button ID="btnStart1" runat="server" Text="1st Page" 
                onclick="btnStart_Click" />
            <asp:Button ID="btnPrevious1" runat="server" Text="<< Previous <<" 
                onclick="btnPrevious_Click" />
            <asp:TextBox ID="txtPageNo1" runat="server" Width="20px"></asp:TextBox>
            <asp:HiddenField ID="hfFileLocation" runat="server" />
            <asp:HiddenField ID="hfMaxPageNo" runat="server" />
            <asp:HiddenField ID="hfPageNo" runat="server" Value="1"/>
            <asp:Button ID="btnNext1" runat="server" Text=">> Next >>" 
                onclick="btnNext_Click" />
            <asp:Button ID="btnLast1" runat="server" Text="Last Page" 
                onclick="btnLast_Click" />
        </td>
    </tr>
    
    <tr>
        <td align="center">
            <asp:Image ID="imgPage" runat="server" Width="900px"/>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnStart2" runat="server" Text="1st Page" 
                onclick="btnStart_Click" />
            <asp:Button ID="btnPrevious2" runat="server" Text="<< Previous <<" 
                onclick="btnPrevious_Click" />
            <asp:TextBox ID="txtPageNo2" runat="server" Width="20px"></asp:TextBox>
            <asp:Button ID="btnNext2" runat="server" Text=">> Next >>" 
                onclick="btnNext_Click" />
            <asp:Button ID="btnLast2" runat="server" Text="Last Page" 
                onclick="btnLast_Click" />
        </td>
    </tr>
    
</table>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

