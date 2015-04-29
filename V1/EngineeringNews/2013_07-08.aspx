<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="2013_07-08.aspx.cs" Inherits="Engineering_News_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" cellspacing="1" cellpadding="4" border="0">
	<tbody><tr class="head">
		<td align="center"><span style="font-size:30px;">Engineering News (July-August 2013) <a href="Archive.aspx" target="_blank">Engr. News Archive</a></span>
        </td>
	</tr>
	<tr style="height:16px;"><td></td></tr>
</tbody></table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%">
    <tr>
        <td align="center">
            <a href="files/2013_07-08/EngineeringNews_2013_07-08.zip">Click here to download all pages</a>
            <br />
            <a href="files/2013_07-08/EngineeringNews_2013_07-08.pdf" target="_blank">Click here to view as pdf file</a>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnStart1" runat="server" Text="1st Page" 
                onclick="btnStart_Click" />
            <asp:Button ID="btnPrevious1" runat="server" Text="<< Previous <<" 
                onclick="btnPrevious_Click" />
            <asp:TextBox ID="txtPageNo1" runat="server" Width="20px"></asp:TextBox>
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

