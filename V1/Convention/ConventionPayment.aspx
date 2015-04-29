<%@ Page Title="" Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true" CodeFile="ConventionPayment.aspx.cs" Inherits="MembersArea_ConventionPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body{padding: 0;margin: 0;font-size:12px;}');
        win.document.write('.bordered td{border:1px solid black;padding:2px;}');
        win.document.write('#dataTable td{text-align:right;}');
        win.document.write('.PurchaseHeaderCss{font-weight: bold;}');
        win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
        win.document.write(printThis);
        win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
        win.document.close();
        win.print();
        win.close();
    }

    </script>
    <style type="text/css">
       #ContentPlaceHolder1_tblCard input[type="text"] { border: 1px solid black;width:60px;text-align:right; }
       .tblMembershipNoStyle td{border:1px solid black;padding:5px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h1>Online Convention Registration</h1>
    <hr />
    
<table border="0" class='tblMembershipNoStyle'  ID="tblMembershipNo" cellpadding="0" cellspacing="0" runat="server">
    <tr>
        <td colspan="4" align="center">Please enter your membership no. and click Next</td>
    </tr>
    <tr>
        <td>Memebership No:</td>
        <td>
            <asp:RadioButtonList ID="rbtMemebershipNo" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Text="F"></asp:ListItem>
            <asp:ListItem Value="2" Text="M"></asp:ListItem>
            <asp:ListItem Value="3" Text="A"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:TextBox ID="txtMemeberShipNoSearch" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">If you forgot your Membership No please <a href="MembershipNoSearch.aspx" target="_blank">click here to Find you Membership No.</a></td>
    </tr>
    <tr>
        <td colspan="4" align="center">
            <asp:HyperLink ID="hlnkPreviousMoneyreceipt" runat="server" Visible="false">You already registered for the Convention. Click here to print your receipt</asp:HyperLink>
        </td>
    </tr>
</table>

<div style='border:1px solid black;background-color:#FDFBE6;font-family:Arial;font-size:12px;padding:10px;width:408px;'>
<table border='0' cellspacing='0' cellpadding='5' width='408px;'  id="tblInfo" runat="server"  visible="false">
    
    <tr>
        <td colspan='5' style='background-color:white;'>
            <img alt="logo" src='http://iebbd.org/images/Convention/55/formHeader.png' width='400px'/>
        </td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Name</td>
        <td colspan='4' style='border:1px solid black;'><asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Membership No.</td>
        <td colspan='4' style='border:1px solid black;'><asp:Label ID="lblMembershipNo" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="hfMem_MemberID" runat="server" />
        </td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Center</td>
        <td colspan='4' style='border:1px solid black;'><asp:Label ID="lblCenter" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Serial No.</td>
        <td colspan='4' style='border:1px solid black;'><asp:TextBox ID="txtSerialNo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Telephone No.</td>
        <td colspan='4' style='border:1px solid black;'><asp:TextBox ID="txtTelephoneNo" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Mobile</td>
        <td colspan='4' style='border:1px solid black;'><asp:TextBox ID="txtMobileN0" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td style='border:1px solid black;'>Email Address</td>
        <td colspan='4' style='border:1px solid black;'>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style='border:1px solid black;'>Picture</td>
        <td colspan='4' style='border:1px solid black;'>
        <asp:Image ID="Image1" runat="server" Height="100px"/>
        </td>
    </tr>
    
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    </table>
    <table border='0' cellspacing='0' cellpadding='5' width='408px;'  id="tblCard" runat="server" visible="false">  
    <tr>
        <td style='border:1px solid black;'>Registration</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Compulsory</td>
        <td style='border:1px solid black;text-align:right;' colspan='3'>Tk. <asp:TextBox ID="txtAmount0" ToolTip="1000" runat="server" Text="1000" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='3'>Lunch</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>03 May'14</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtQty1"  runat="server" ontextchanged="Calculate" AutoPostBack="true" ></asp:TextBox></td>
        <td style='border:1px solid black;width:60px;'><b style='color: #FF0000;'>x</b> Tk. 130 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount1"  ToolTip="130" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>04 May'14</td>
        <td style='border:1px solid black;' colspan='3'>Lunch Will be provided by IEB</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>05 May'14</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtQty2" runat="server" AutoPostBack="true" 
                ontextchanged="Calculate"></asp:TextBox></td>
        <td style='border:1px solid black;'><b style='color: #FF0000;'>x</b> Tk. 130 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount2" runat="server" Enabled="false" ToolTip="130"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'><b style='color: #FF0000;'>*</b>Dinner</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Single</td>
        <td style='border:1px solid black;text-align:center;'><asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="true" 
                OnCheckedChanged="Calculate_Single"/></td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount3" ToolTip="500" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>Couple</td>
        <td style='border:1px solid black;text-align:center;'><asp:CheckBox ID="CheckBox2" runat="server"  AutoPostBack="true" 
                OnCheckedChanged="Calculate_Couple"/></td>
        <td style='border:1px solid black;'>Tk. 800 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount4" ToolTip="800" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'><b style='color: #FF0000;'>*</b>Only for Members &amp; Spouse</td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black;' rowspan='2'>Optional Items</td>
        <td style='border:1px solid black;background-color:#FFD24A;'>Ladies Bag</td>
        <td style='border:1px solid black;text-align:center;'><asp:CheckBox ID="CheckBox3" runat="server"  AutoPostBack="true" 
                OnCheckedChanged="Calculate"/>
                <asp:TextBox ID="txtQty3" ToolTip="1200" runat="server" Text="" AutoPostBack="true" 
                ontextchanged="Calculate"></asp:TextBox>
                </td>
        <td style='border:1px solid black;'>Tk. 1200 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount5" ToolTip="1200" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#FFD24A;'>IEB Tie</td>
        <td style='border:1px solid black;text-align:center;'><asp:CheckBox ID="CheckBox4" runat="server"  AutoPostBack="true" 
                OnCheckedChanged="Calculate"/>
                <asp:TextBox ID="txtQty4" ToolTip="1200" runat="server" Text="" AutoPostBack="true" 
                ontextchanged="Calculate"></asp:TextBox>
                </td>
        <td style='border:1px solid black;'>Tk. 500 =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="txtAmount6"  ToolTip="500" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable(to IEB) =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="lblTotal" runat="server" Text="" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr style="display:none;">
        <td style='border:1px solid black; text-align:right;' colspan='4'>bKash Fee(1.25%) =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="lblbKashFee" runat="server" Text="" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr style="display:none;">
        <td style='border:1px solid black; text-align:right;' colspan='4'>Total Payable =</td>
        <td style='border:1px solid black;'><asp:TextBox ID="lbltotalPayable" runat="server" Text="" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr  ID="tr_ConfirmationEmail" runat="server" visible="false">
        <td style='border:1px solid black; text-align:left;' colspan='5'>
            <asp:Label ID="lblConfirmationEmail" runat="server" Text=""></asp:Label>
         </td>
    </tr>
    <tr>
        <td colspan='5' style='height:10px;'>&nbsp;</td>
    </tr>
    <tr ID="btnConfirm" runat="server">
        <td style='border:1px solid black; text-align:left;' colspan='4'>
        <ul style='padding-left:15px;display:none;">
            <li>Please click on submit button to send your registration form</li>
            <li>After submission you have to pay(from any personal bKash a/c) the total payable amount to bKash Merchant A/C No. <b style="color:Blue">01766674142</b> using Reference No. <asp:Label ID="lblBillNo" runat="server" Font-Bold="true" ForeColor="Blue" Text=""></asp:Label>
            
            </li>
            <li>Steps for the payment.<a target='_blank' href='../MembersArea/bKashPayment.aspx'>For detail click here.</a>
                <ul>
                    <li><b>Step-1:</b>Dial *247# and you will see menu</li>
                    <li><b>Step-2:</b>Chose '3.Pyament' [not '1.send money']</li>
                    <li><b>Step-3:</b>Enter 01766674142 [it is IEB Merchant A/C no.]</li>
                    <li><b>Step-4:</b>Enter total payable amount</li>
                    <li><b>Step-5:</b>Enter your reference no:<asp:Label ID="lblReferenceNoSteps" runat="server" Text=""></asp:Label></li>
                    <li><b>Step-6:</b>Enter counter no:0</li>
                    <li><b>Step-7:</b>Enter your (bKash mobile menu) PIN</li>
                </ul>
                <br />
                Immediately you will receive a SMS form bKash. Don't forget to keep the transaction ID(TrxID)
            </li>
        </ul>
        </td>
        <td style='border:1px solid black;'><asp:Button ID="btnConfirm_button" runat="server" Text="Submit"  OnClientClick="return confirm('Your submitted information are OK?')" 
                onclick="btnConfirm_Click" /></td>
    </tr>
    
    
    
    </table>
    <table border='0' cellspacing='0' cellpadding='5' width='408px;'  id="trConfirmation" runat="server" visible="false">  
    
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='3'>bKash Merchant A/C No.</td>
        <td style='border:1px solid black;' colspan='2'><b style="color:Blue">01766674142</b></td>
    </tr>
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='3'>Reference No.</td>
        <td style='border:1px solid black;' colspan='2'><asp:Label ID="lblBillNo_afterPrint" runat="server" Font-Bold="true" ForeColor="Blue" Text=""></asp:Label></td>
    </tr>
   <tr>
        <td style='border:1px solid black; text-align:right;' colspan='3'>Please write down here the Transaction ID(TrxID) which you will receive from bKash by SMS</td>
        <td style='border:1px solid black;' colspan='2'></td>
    </tr>
    
    <tr>
        <td style='border:1px solid black; text-align:right;' colspan='3'>Please print this document</td>
        <td style='border:1px solid black;' colspan='2'>
            <%--<asp:Button ID="btnPrint" runat="server" Text="Print" 
                onclick="btnPrint_Click" />--%>
                <a href="" id="a_print" runat="server" target="_blank">Print</a>
        </td>
    </tr>
</table>
</div>

  <table id="tblFessDetails" runat="server" visible="false" class="tbl">
             
                <tr id="tr_Fees_Details" runat="server">
                    <td class="td_Details" style="display:none;">
                        <div class="tabbody">
                            <asp:GridView ID="gvMem_Fees" runat="server" AutoGenerateColumns="false" ShowFooter="true" 
                                CssClass="gridCss" align="Center" Width="300px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Paid upto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidFor" runat="server" Text='<%#Eval("PaidFor") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Paid">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDatePaid" runat="server" Text='<%#Eval("PaidDate","{0:dd MMM yyyy}") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:0,0.00}") %>'>
                        </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server">
                        </asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                    <td class="td_Details">
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblDues" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
            </table>
<div  style="display:none;" >
<div  id='printSalesVoucher'>
        <asp:Label ID="lblPrint" runat="server" Text=""></asp:Label>  
</div>
</div>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

