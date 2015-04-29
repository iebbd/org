<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="DistributionConv_RegistrationDisplay.aspx.cs" Inherits="AdminConv_RegistrationDisplay" Title="Display Conv_Registration By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
        .gridCss td{padding:5px;padding-top:15px;padding-bottom:15px;}
        .gridCss th{background-color:Gray;color:White;padding:5px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h1>Online</h1>
<hr />
    <div>
      <asp:RadioButtonList ID="rbtnlPyament" runat="server" 
             AutoPostBack="true" 
            RepeatDirection="Horizontal" 
            onselectedindexchanged="rbtnlPyament_SelectedIndexChanged" Enabled="false">
    <asp:ListItem Value="1" Selected="True">Paid Only</asp:ListItem>
    <asp:ListItem Value="2">Unpaid Only</asp:ListItem>
    <asp:ListItem Value="3">All</asp:ListItem>
    </asp:RadioButtonList>
        <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />--%>
        <asp:GridView ID="gvConv_Registration" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="SI">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                        <asp:HiddenField ID="hfConv_RegistrationID" runat="server" Value='<%#Eval("Conv_RegistrationID") %>'/>
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

                        <br />
                        <br />
                        <a href='<%#Eval("ExtraField5") %>' target="_blank">Details</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Picture">
                    <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" width="100px" ImageUrl='<%#Eval("PictureUrl") %>'/>
                        <%--<asp:Label ID="lblRegistrationFee" runat="server" Text='<%#Eval("RegistrationFee") %>'>
                        </asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="L-D#1">
                    <ItemTemplate>
                        L-1 (<asp:Label ID="lblLunch1No" runat="server" Text='<%#Eval("Lunch1No") %>' Font-Bold='<%#Eval("Lunch1E") %>'>
                        </asp:Label>
                        <asp:Label ID="Label154235" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("Lunch1E") %>'  Font-Bold='<%#Eval("Lunch1E") %>'>
                        </asp:Label>
                        )
                        <br />
    <asp:CheckBox ID="chkL1" runat="server" Enabled='<%#Eval("Lunch1E") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="tk">
                    <ItemTemplate>
                        <%#Eval("Lunch1Amount") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="L-D#3">
                    <ItemTemplate>
                        L-2 (<asp:Label ID="lblLunch2No" runat="server" Text='<%#Eval("Lunch2No") %>' Font-Bold='<%#Eval("Lunch2E") %>'>
                        </asp:Label>
                        <asp:Label ID="Label15657" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("Lunch2E") %>'  Font-Bold='<%#Eval("Lunch2E") %>'>
                        </asp:Label>
                        )
                        <br />
    <asp:CheckBox ID="chkL2" runat="server" Enabled='<%#Eval("Lunch2E") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="tk">
                    <ItemTemplate>
                        <%#Eval("Lunch2Amount") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="S. D">
                    <ItemTemplate>
                        S.D (<asp:Label ID="lblDinner1" runat="server" Text='<%#Eval("Dinner1") %>' Font-Bold='<%#Eval("Dinner1E") %>'>
                        </asp:Label>
                        <asp:Label ID="Label1ghsdf" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("Dinner1E") %>'  Font-Bold='<%#Eval("Dinner1E") %>'>
                        </asp:Label>
                        )
                        <br />
    <asp:CheckBox ID="chkD1" runat="server" Enabled='<%#Eval("Dinner1E") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C. D">
                    <ItemTemplate>
                        C.D (<asp:Label ID="lblDinner2" runat="server" Text='<%#Eval("Dinner2") %>' Font-Bold='<%#Eval("Dinner2E") %>'>
                        </asp:Label>
                        <asp:Label ID="Dinner2E1sdafd" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("Dinner2E") %>'  Font-Bold='<%#Eval("Dinner2E") %>'>
                        </asp:Label>
                        )
                        <br />
    <asp:CheckBox ID="chkD2" runat="server" Enabled='<%#Eval("Dinner2E") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="L. Bag">
                    <ItemTemplate>
                        L.B (<asp:Label ID="lblLadiesBag" runat="server" Text='<%#Eval("LadiesBag") %>' Font-Bold='<%#Eval("LadiesBagE") %>'>
                        </asp:Label>
                        
                        <asp:Label ID="LadiesBagEsdfasd1" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("LadiesBagE") %>'  Font-Bold='<%#Eval("LadiesBagE") %>'>
                        </asp:Label>
                        )
                        <br />
    <asp:CheckBox ID="chkLB" runat="server" Enabled='<%#Eval("LadiesBagE") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tie">
                    <ItemTemplate>
                        T (<asp:Label ID="lblIEBTie" runat="server" Text='<%#Eval("IEBTie") %>' Font-Bold='<%#Eval("IEBTieE") %>'>
                        </asp:Label>
                        
                        <asp:Label ID="IEBTisdfaeE1" runat="server" Text="*" Font-Size="XX-Large" ForeColor="Red" Visible='<%#Eval("IEBTieE") %>'  Font-Bold='<%#Eval("IEBTieE") %>'>
                        </asp:Label>)
                        <br />
    <asp:CheckBox ID="chkT1" runat="server" Enabled='<%#Eval("IEBTieE") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Total Payable">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalIEBFee" runat="server" Text='<%#Eval("TotalIEBFee") %>'>
                        </asp:Label>+<asp:Label ID="lblBKashFees" runat="server" Text='<%#Eval("BKashFees") %>'>
                        </asp:Label>=<asp:Label ID="lblTotalPayable" runat="server" Text='<%#Eval("TotalPayable") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="TrxID">
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
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbCompleted" runat="server" CommandArgument='<%#Eval("Conv_RegistrationID") %>' OnClick="lbSelect_Click"
                         OnClientClick="return confirm('Are You Sure?')">
                        &nbsp;&nbsp;   
        <asp:Image ID="Image1" runat="server" ImageUrl="http://iebbd.org/images/Convention/check_mark.png"/> &nbsp;&nbsp;
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark">
                    <ItemTemplate>
                        
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server"  Text='<%#Eval("ExtraField3") %>'></asp:TextBox>
                   <br />
                    <asp:LinkButton ID="lbUpdate" runat="server" CommandArgument='<%#Eval("Conv_RegistrationID") %>' OnClick="lbUpdate_Click">
                     Update
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
