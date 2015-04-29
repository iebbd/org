<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightSideMenu.ascx.cs" Inherits="Control_RightSideMenu" %>
<div class="container"><a href="http://123.49.3.254/ieb/rajuk/RAJUKApprovedList.aspx" ><img src="../images/WebMail.png" border="0"></a></div>
<div class="container"><a href="http://123.49.3.254/ieb/engineering_news/" ><img src="../images/EngineeringNews.png" border="0"></a></div>
        <div class="container"><a href="http://www.iebbd.org/index.php?option=com_content&amp;view=article&amp;id=147&amp;Itemid=77"><img src="../images/JobCell.png" border="0"></a></div>
      	<!--<div class="container">
        	<a href="/images/AttachedFiles/IEB_Constitution.pdf" target="_blank">
            	<img src="/images/IEBContitution.gif" border="0" />
            </a>
        </div>
        <div class="container"><a href="#" target="_blank"><img src="/images/ieb_membership_system.png" border="0" /></a></div>
         <div class="container">
        	<a href="/index.php?option=com_content&amp;view=article&amp;id=145&amp;Itemid=77">
            	<img src="/images/AimsObjectives.gif" border="0" />
            </a>
        </div>
		<div class="container">
        	<a href="/index.php?option=com_content&amp;view=article&amp;id=150&amp;Itemid=77">
        		<img src="/images/regulation_09.png" border="0" />
            </a>
        </div>
         		<div class="container">
        	<a href="/index.php?option=com_content&amp;view=article&amp;id=146&amp;Itemid=77">
            	<img src="/images/InternationalAffairs.gif" border="0" />
            </a>
        </div> 
                -->

        <div class="container"><a href="#" target="_blank"><img src="../images/ieb_management.png" border="0"></a></div>
        <div class="container"><a href="http://www.iebbd.org/index.php?option=com_fwgallery&amp;view=galleries"><img src="../images/ieb_photogallery.png" border="0"></a></div>
 		 <div class="container" style="display:none;">
         	<div class="photoslide">
<script type="text/javascript">
/* <![CDATA[ */

	// Initializing
	var leftrightslide	=	new Array();
	var finalslide		=	'';
	var sliderwidth		=	"216px";
	var sliderheight	=	"180px";
	var slidebgcolor	=	"transparent";
	var stopslide		=	"1";
	var imagegap		=	"&nbsp;";
	var slidespeed		=	1;

	// Starting SlideShow
	leftrightslide[0]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/CCMeeting-1.jpg" border="0" style="height: 180px;" alt="Sample Title" title="Sample Title"\/><\/a>';leftrightslide[1]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Cer_Award_civil-1.jpg" border="0" style="height: 180px;" alt="Sample Title" title="Sample Title"\/><\/a>';leftrightslide[2]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Cert_Award_EE&ME-5.jpg" border="0" style="height: 180px;" alt="Sample Title" title="Sample Title"\/><\/a>';leftrightslide[3]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/DSC_0403.jpg" border="0" style="height: 180px;" alt="Sample Title" title="Sample Title"\/><\/a>';leftrightslide[4]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/DSC_0434.jpg" border="0" style="height: 180px;" alt="Sample Title" title="Sample Title"\/><\/a>';leftrightslide[5]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/DSC_0700_resize.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[6]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/DSC_0783_resize.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[7]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Engineers Day Rally1.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[8]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Engineers Day Rally2.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[9]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Engineers Day Rally3.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[10]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Engineers Dhabi Scan-1.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[11]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Paper Scan in Somabesh news.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[12]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Press Conference1.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[13]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Press Conference2.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[14]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Round Table Discussion on Building Break Down and National Building Code-1.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[15]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Seminar on Engineers Contribution During last 65 years-1.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[16]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Seminar on Engineers Contribution During last 65 years-2.jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[17]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Seminar on Engineers Day 2013(1).jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[18]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/Seminar on Engineers Day 2013(2).jpg" border="0" style="height: 180px;"\/><\/a>';leftrightslide[19]='<a href="javascript:void(0);"><img src="http://www.iebbd.org/images/banner_sliding/home_image.jpg" border="0" style="height: 180px;"\/><\/a>';
/* ]]> */
</script>

<script src="../images/horizontal.js" type="text/javascript"></script><span id="temp" style="visibility:hidden;position:absolute;top:-100px;left:-9000px"><nobr><a href="javascript:void(0);"><img src="../images/CCMeeting-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cer_Award_civil-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cert_Award_EEME-5.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0403.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0434.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0700_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0783_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally3.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Dhabi%2520Scan-1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Paper%2520Scan%2520in%2520Somabesh%2520news.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Round%252520Table%252520Discussion%252520on%252520Building%252520Break.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During%25252.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During_002.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020131.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020132.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/home_image.jpg" style="height: 180px;" border="0"></a></nobr></span><table border="0" cellpadding="0" cellspacing="0"><tbody><tr><td><div style="position:relative;width:216px;height:180px;overflow:hidden"><div style="position:absolute;width:216px;height:180px;background-color:transparent" onmouseover="copyspeed=stopslidespeed" onmouseout="copyspeed=slidespeed"><div id="test2" style="position: absolute; left: -1101px; top: 0px;"><nobr><a href="javascript:void(0);"><img src="../images/CCMeeting-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cer_Award_civil-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cert_Award_EEME-5.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0403.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0434.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0700_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0783_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally3.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Dhabi%2520Scan-1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Paper%2520Scan%2520in%2520Somabesh%2520news.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Round%252520Table%252520Discussion%252520on%252520Building%252520Break.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During%25252.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During_002.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020131.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020132.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/home_image.jpg" style="height: 180px;" border="0"></a></nobr></div><div id="test3" style="position: absolute; left: 4603px; top: 0px;"><nobr><a href="javascript:void(0);"><img src="../images/CCMeeting-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cer_Award_civil-1.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Cert_Award_EEME-5.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0403.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0434.jpg" style="height: 180px;" alt="Sample Title" title="Sample Title" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0700_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/DSC_0783_resize.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Day%2520Rally3.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Engineers%2520Dhabi%2520Scan-1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Paper%2520Scan%2520in%2520Somabesh%2520news.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference1.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Press%2520Conference2.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Round%252520Table%252520Discussion%252520on%252520Building%252520Break.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During%25252.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%252520on%252520Engineers%252520Contribution%252520During_002.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020131.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/Seminar%2520on%2520Engineers%2520Day%252020132.jpg" style="height: 180px;" border="0"></a>&nbsp;<a href="javascript:void(0);"><img src="../images/home_image.jpg" style="height: 180px;" border="0"></a></nobr></div></div></div></td></tr></tbody></table>

</div>
        </div>
        <div class="container">
        	<a href="http://www.iebbd.org/index.php?option=com_content&amp;view=article&amp;id=141&amp;Itemid=77">
            	<img src="../images/ieb_noticeboard.png" border="0">
            </a>
        </div>      
        
        <div class="newsEvents" style="display:none;">
            
            <marquee direction="up" loop="true" onmouseout="start()" onmouseover="stop()" scrolldelay="3" scrollamount="4" height="100%" width="100%">
                             
	
					<div class="title" style="font-family:SolaimanLipi;"><a href="http://www.iebbd.org/">Call
 for Papers and Invitation for “The 6th International Civil Engineering 
Congress” organized by The Institution of Engineers, Pakistan.</a></div>
						<span>
							<img src="../images/logo_03.png"><br><p><a href="http://www.iebbd.org/iebbd.org/files/papers/iep_civil_engineering_congress.zip">Click here to download all the files we got from IEP</a></p>
<hr id="system-readmore">								<br><a href="http://www.iebbd.org/index.php?option=com_content&amp;view=article&amp;id=80&amp;notice_id=91&amp;Itemid=77">read more...</a>
					   </span><br>
				               
	
					<div class="title" style="font-family:SolaimanLipi;"><a href="http://www.iebbd.org/">Call for Papers in APMEE 2013</a></div>
						<span>
							<img src="../images/logo_03.png"><br><p>&nbsp;</p>
<p><img src="../images/EEE.png" width="75%"></p>
<hr id="system-readmore">								<br><a href="http://www.iebbd.org/index.php?option=com_content&amp;view=article&amp;id=80&amp;notice_id=92&amp;Itemid=77">read more...</a>
					   </span><br></marquee>
        </div>
      
       <!-- <div class="newsLetter">
            <form name="newsLetter" method="post" action="">
                <div class="title">News Letter</div>
                
                <div class="leble">Name:</div>
                <div class="textBox"><input type="text" name="name" id="name" /></div>
                <div class="leble">E-mail:</div>
                <div class="textBox"><input type="text" name="name" id="name" /></div>
                
                <div class="but">
                	<input type="button" name="submit" value="Scbscribe" />&nbsp;&nbsp;
                	<input type="button" name="submit2" value="Unscbscribe" />
                </div>
            </form>
        </div>-->
