<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminConv_RegistrationInsertUpdate.aspx.cs" Inherits="AdminConv_RegistrationInsertUpdate" Title="Conv_Registration Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tableCss">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblConv_ConventionID" runat="server" Text="Conv_ConventionID: ">
                    </asp:Label>
                </td>
                <td>
                    
                    <asp:TextBox ID="txtConv_ConventionID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMem_MemberID" runat="server" Text="Mem_MemberID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMem_Member" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRegistrationFee" runat="server" Text="RegistrationFee: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRegistrationFee" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLunch1No" runat="server" Text="Lunch1No: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLunch1No" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLunch1Amount" runat="server" Text="Lunch1Amount: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLunch1Amount" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLunch2No" runat="server" Text="Lunch2No: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLunch2No" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLunch2Amount" runat="server" Text="Lunch2Amount: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLunch2Amount" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDinner1" runat="server" Text="Dinner1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDinner1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDinner2" runat="server" Text="Dinner2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDinner2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLadiesBag" runat="server" Text="LadiesBag: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLadiesBag" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIEBTie" runat="server" Text="IEBTie: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIEBTie" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalIEBFee" runat="server" Text="TotalIEBFee: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalIEBFee" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBKashFees" runat="server" Text="BKashFees: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBKashFees" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalPayable" runat="server" Text="TotalPayable: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalPayable" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTrxID" runat="server" Text="TrxID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTrx" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTypeID" runat="server" Text="TypeID: ">
                    </asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtType" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatusID" runat="server" Text="StatusID: ">
                    </asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtStatus" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField1" runat="server" Text="ExtraField1: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField1" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField2" runat="server" Text="ExtraField2: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField2" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField3" runat="server" Text="ExtraField3: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField3" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField4" runat="server" Text="ExtraField4: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField4" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExtraField5" runat="server" Text="ExtraField5: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraField5" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
