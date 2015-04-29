<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminConv_RegistrationDisplay.aspx.cs" Inherits="AdminConv_RegistrationDisplay" Title="Display Conv_Registration By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
        .gridCss td{padding:5px;}
        .gridCss th{background-color:Gray;color:White;padding:5px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h1>Convention Registration</h1>
<hr />
    <div>
      <asp:RadioButtonList ID="rbtnlPyament" runat="server" 
             AutoPostBack="true" 
            RepeatDirection="Horizontal" 
            onselectedindexchanged="rbtnlPyament_SelectedIndexChanged">
    <asp:ListItem Value="1">Paid Only</asp:ListItem>
    <asp:ListItem Value="2">Unpaid Only</asp:ListItem>
    <asp:ListItem Value="3"  Selected="True">All</asp:ListItem>
    </asp:RadioButtonList>
        <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />--%>
        <asp:GridView ID="gvConv_Registration" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="SI">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("Conv_RegistrationID") %>' OnClick="lbSelect_Click">
                            Edit
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="Conv_ConventionID">
                    <ItemTemplate>
                        <asp:Label ID="lblConv_ConventionID" runat="server" Text='<%#Eval("Conv_ConventionID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Member">
                    <ItemTemplate>
                        <a href='../MembersArea/MembershipInfo.aspx?mem_MemberID=<%#Eval("Mem_MemberID") %>' target="_blank"><asp:Label ID="lblMem_MemberID" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <%#Eval("Mobile") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reg. Fee">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationFee" runat="server" Text='<%#Eval("RegistrationFee") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="D#1">
                    <ItemTemplate>
                        <asp:Label ID="lblLunch1No" runat="server" Text='<%#Eval("Lunch1No") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="tk">
                    <ItemTemplate>
                        <%#Eval("Lunch1Amount") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="D#3">
                    <ItemTemplate>
                        <asp:Label ID="lblLunch2No" runat="server" Text='<%#Eval("Lunch2No") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="tk">
                    <ItemTemplate>
                        <%#Eval("Lunch2Amount") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S. D">
                    <ItemTemplate>
                        <asp:Label ID="lblDinner1" runat="server" Text='<%#Eval("Dinner1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C. D">
                    <ItemTemplate>
                        <asp:Label ID="lblDinner2" runat="server" Text='<%#Eval("Dinner2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="L. Bag">
                    <ItemTemplate>
                        <asp:Label ID="lblLadiesBag" runat="server" Text='<%#Eval("LadiesBag") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tie">
                    <ItemTemplate>
                        <asp:Label ID="lblIEBTie" runat="server" Text='<%#Eval("IEBTie") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Payable">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalIEBFee" runat="server" Text='<%#Eval("TotalIEBFee") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Payable">
                    <ItemTemplate>
                        <asp:Label ID="lblBKashFees" runat="server" Text='<%#Eval("BKashFees") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Payable">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPayable" runat="server" Text='<%#Eval("TotalPayable") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalFooter" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TrxID">
                    <ItemTemplate>
                        <asp:Label ID="lblTrxID" runat="server" Text='<%#Eval("TrxID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy hh:mm tt}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="TypeID">
                    <ItemTemplate>
                        <asp:Label ID="lblTypeID" runat="server" Text='<%#Eval("TypeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatusID" runat="server" Text='<%#Eval("StatusID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href='<%#Eval("ExtraField5") %>' target="_blank">Print</a>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="ExtraField2">
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
                <%--<asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Conv_RegistrationID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
