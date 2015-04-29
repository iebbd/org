<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AMIE_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
    <link href="../css/tableView.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>AMIE</h1>
    <hr />
     <div style="padding:0 60px;text-align:left;min-height:100px;">
     
    <table width="872" cellspacing="1" cellpadding="1" border="0" align="left"  >
        <tr>
            <td  style="text-align: center;" class="head"><strong>Published Date</strong></td>
            <td  style="text-align: left;" class="head"><strong>Type</strong></td>
            <td style="text-align: left;" class="head"><strong>Title</strong></td>
            <td class="head"><strong>Details</strong></td>
        </tr>
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">04-08-2014</td>
            <td class="style2 dept" style="text-align: left;">Notice</td>
            <td class="style2 dept" style="text-align: left;">Exam notice</td>
            <td class="style2 dept" style="text-align: left;"><a href="Notice/Notice_2014-08-04_1.pdf" target="_blank">Details</a></td>
        </tr>
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">04-08-2014</td>
            <td class="style2 dept" style="text-align: left;">Notice</td>
            <td class="style2 dept" style="text-align: left;">Registration Time Limit</td>
            <td class="style2 dept" style="text-align: left;"><a href="Notice/Notice_2014-08-04_2.pdf" target="_blank">Details</a></td>
        </tr>
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">23-07-2014</td>
            <td class="style2 dept" style="text-align: left;">Result</td>
            <td class="style2 dept" style="text-align: left;">Result of Exam held on April 2014</td>
            <td class="style2 dept" style="text-align: left;"><a href="Result/RESULT_April_2014.pdf" target="_blank">Details</a></td>
        </tr>  
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">03-05-2014</td>
            <td class="style2 dept" style="text-align: left;">Student List</td>
            <td class="style2 dept" style="text-align: left;">AMIE Completed students List (celebrated on 54 & 55 Convension)</td>
            <td class="style2 dept" style="text-align: left;"><a href="Exam/PROGRAMME_FOR_APRIL_2014_EXAMINATION.pdf" target="_blank">Details</a></td>
        </tr>
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">31-03-2014</td>
            <td class="style2 dept" style="text-align: left;">Exam Schedule</td>
            <td class="style2 dept" style="text-align: left;">PROGRAMME FOR APRIL 2014 EXAMINATION</td>
            <td class="style2 dept" style="text-align: left;"><a href="../Files/file/AMIE/AMIE-54-55-Convension.pdf" target="_blank">Details</a></td>
        </tr> 
        
        <tr>
            <td height="18" class="style2 dept" style="text-align:center; padding-left:0px;">21-01-2014</td>
            <td class="style2 dept" style="text-align: left;">Result</td>
            <td class="style2 dept" style="text-align: left;">Result of Exam held on October 2013</td>
            <td class="style2 dept" style="text-align: left;"><a href="Result/RESULT_October_2013.pdf" target="_blank">Details</a></td>
        </tr>        
    </table>
    
        
    </div>
    
          <table border="1" cellpadding="5" cellspacing="0" width="100%">
          <tr>
            <td colspan="4">
            Click here to know details about <a href="Notice/Admission.pdf" target="_blank"> Admission Process</a>. For more details please talk to
            </td>
          </tr>
              
             <tr style="background-color:#79DDF4;font-weight:bold;">
                 <td>
                     Mohammad Hossain</td>
                 <td>
                     880-2-9559485 Ext:133</td>
                 <td>
                     amie@iebbd.org</td>
                 <td>
                     Senior Assistant, AMIE Examination, IEB</td>
             </tr>
         </table>
</asp:Content>

