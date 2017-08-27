<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secondpage.aspx.cs" Inherits="suidaozhaoming.Secondpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="javascript" type="text/jscript">
    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/ExitB.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Exit.png";
    }

    function reClick() 
    {
       document.getElementById('Inspect').click();
    }
    window.setInterval("reClick()", 120000); //这里是60秒 按毫秒计算时间
    
    </script>

<head runat="server">
    <title>隧道（道路）照明监控系统</title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333;">

    <form id="form1" runat="server" style = "width:100%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="body_full" style="width:1270px; text-align:center; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div  style=" text-align:left; padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                    <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                    <asp:UpdatePanel ID="gettimeup" runat="server"  >
                        <ContentTemplate>
                            <asp:Timer ID="TimerSec_1" runat="server" Interval="1000" OnTick="GetTimer">
                            </asp:Timer>
                            <asp:Label ID="ShowtimeSec" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                            </asp:Label>              
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Label ID="ShowweatherSec" runat="server" style="margin-left:20px;background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                    -23℃/-28℃
                </asp:Label>
            </div>
            <asp:Image ID="ShowweatherpicSec" runat="server" ImageUrl="~/pic_weather/b0.gif" style="background-color:transparent;margin-left:40px; width:50px; height:46px; margin-top:0px;" />
        </div>
            <div style="margin-right:400px; padding-top:6px; width:100px; float:right">
            <div style="height:70px; width:160px; float:right; margin-right:-325px; margin-top:-65px">            
                <asp:ImageButton  ID="ButtonSec_Exit" OnClick = "ButtonSec_Exit_Click" ImageUrl ="/pic/Exit.png" onmouseout="changeback(this)" onmouseover="changeImg(this)"  runat="server"  style="float:left; background-color:transparent;height:68px; width:97px; border:none;outline:none; background-color:transparent; margin-left: 100px" />
            </div> 
            </div>   
        </div> 
        <table border="0" align="center">
            <tr>
                <td style="width:140px;">
                    <asp:Button ID ="Button_Left"  OnClick = "Button_Left_Click" runat="server" style="background-image:url(pic/Sunshinecurve.png); width:140px; height:100px;cursor :pointer;border:none;background-color:transparent" />
                       
                </td>   
                <td style="width:140px;" align="center">
                    <div>
                    <asp:UpdatePanel ID="UpdatePanel32" runat="server"  >                        
                        <ContentTemplate>
                            <asp:Button ID ="Button_EnergyH" runat="server"  OnClick = "EnergyH_Click"  Enabled = "true" style="background-image:url(pic/Energy.png);width:140px; height:50px;color:#FFF;font-size:28px; cursor:pointer; margin-left:-3px;float:left; border:none;background-color:transparent"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel41" runat="server"  >                        
                        <ContentTemplate>
                            <asp:Button ID ="Button_EnergyDay"  OnClick = "EnergyDay_Click" Enabled = "true" runat="server" style="background-image:url(pic/Energy.png);width:140px; height:50px; color:#FFF; font-size:28px;cursor :pointer; margin-left:-3px; float:left; border:none;background-color:transparent"/>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    </div>             
                </td>   
                <td  style="width:660px; " align="center">
                    <asp:Label ID ="LabelSec_Title" runat = "server"  style="color:#FFF; font-family:'黑体'; font-size:54px; ">女娘山隧道监控系统</asp:Label>                
                </td>
                <td style="width:140px;">
                    <div  style="width:140px; height:50px;float:right; background-image:url(pic/Energy.png)">
                    <asp:UpdatePanel ID="UpdatePanel31" runat="server"  >                        
                        <ContentTemplate>
                          <asp:TextBox ID="TextBoxPowerDay2" style="width:140px; height:32px;color:#FFF; margin-left:10px; margin-top:10px; border:none;outline:none; background-color:transparent; font-size:28px"  runat="server">00.00度</asp:TextBox>      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <div  style="width:140px; height:50px;float:right; background-image:url(pic/Energy.png)">
                    <asp:UpdatePanel ID="UpdatePanel42" runat="server"  >                        
                        <ContentTemplate>
                        <asp:TextBox ID="TextBoxPowerTotol2" style="width:140px; height:32px;color:#FFF; margin-left:10px; margin-top:10px; border:none;outline:none; background-color:transparent; font-size:28px"  runat="server">00000000</asp:TextBox>      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </td>
                <td style="width:140px;" align ="center">
                     <asp:Button ID ="Button_Right"   OnClick = "Button_Right_Click" runat="server" style="background-image:url(pic/Sunshinecurve.png); width:140px; height:100px;cursor :pointer;border:none;background-color:transparent" />
                </td>
           </tr>
           <tr>
                <td style="width:140px;">         
                    <asp:Label ID = "LabelSec_1" runat = "server" style="color:White; font-family:'宋体'; font-size:28px;">日亮度曲线</asp:Label>           
                </td>
                <td style="width:140px;" >         
                    <label style="color:#FFF; font-family:'宋体'; font-size:28px;">电表一</label>           
                </td>
                <td style="width:660px; float:right" align="center"; >
                </td>
                <td style="width:140px;">         
                     <label style="color:#FFF; font-family:'宋体'; font-size:28px;">电表二</label>           
                </td>
                <td style="width:140px; ">
                    <asp:Label ID = "LabelSec_2" runat = "server" style="color:#FFF; font-family:'宋体'; font-size:28px;">日亮度曲线</asp:Label>
                </td>
            </tr>
        </table>     

<div style="width:1270px; margin-top:40px; height:360px; margin-bottom:-58px;">
<div style="width:1070px; float:left">
<div style="width:190px; float:left" align="center">
<div style="width:190px;height:480px">
<div style="width:140px; background-image:url(pic/OutBright.png); height:480px; text-align:center" >
<div style="width:140px" >  
        <div style="width:50px;height:464px;float:left;margin-left:0px;margin-top:0px";>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server"  >                        
                <ContentTemplate>
                    <asp:Image ID ="ShowOutBrightLeft" runat ="server" ImageUrl ="~/pic/OutBright-.png" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>        
</div>
</div>
<label style="color:White; text-align:center; font-family:'仿宋'; font-size:24px;">右洞外路面亮度</label>
</div>
</div>

<div  style="width:870px; float:right; text-align:center; height:320px;margin-top:-88px" >


<table width="860px" border="0">
  <tr style="height:50px">
    <td style="width:100px">&nbsp;</td>        
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server"  >
        <ContentTemplate>  
           <asp:ImageButton ID="No7warnUp" runat="server" OnClick = "warnup_Click"  Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>     
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server"  >
        <ContentTemplate>  
            <asp:ImageButton ID="No6warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel12" runat="server"  >
        <ContentTemplate>  
            <asp:ImageButton ID="No5warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel13" runat="server"  >
        <ContentTemplate>  
            <asp:ImageButton ID="No4warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel14" runat="server"  >
        <ContentTemplate>  
             <asp:ImageButton ID="No3warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server"  >
        <ContentTemplate>  
            <asp:ImageButton ID="No2warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel16" runat="server"  >
        <ContentTemplate>  
           <asp:ImageButton ID="No1warnUp" runat="server" OnClick = "warnup_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px">&nbsp;</td>
    
  </tr>
 
  <tr style="height:110px">
    <td style="width:100px">&nbsp;</td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No7BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>    
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No6BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/> 
        </ContentTemplate>  
        </asp:UpdatePanel>       
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No5BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>        
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No4BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/> 
        </ContentTemplate>  
        </asp:UpdatePanel>               
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server"  >
        <ContentTemplate> 
            <asp:Image ID = "No3BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/> 
        </ContentTemplate>  
        </asp:UpdatePanel>               
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel8" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No2BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>                
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel9" runat="server"  >
        <ContentTemplate>  
            <asp:Image ID = "No1BrightSecUp" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>                
    </td>
    <td  style="width:100px" >
       <div  >
                <asp:Button ID ="ButtonCar"   OnClick = "Button_Car_Click" runat="server" style="background-image:url(pic/In_Left.png); width:140px; height:83px;text-align:left;margin-top:0px;cursor :pointer;border:none;background-color:transparent" />                 
                <asp:UpdatePanel ID="UpdatePanel40" runat="server"  >                        
                        <ContentTemplate>
                        <asp:TextBox ID="TextBoxCar" style="width:75px; height:32px;color:#FFF;margin-left:27px; margin-top:-57px;  border:none;outline:none; background-color:transparent; font-size:24px"  runat="server">0000</asp:TextBox>      
                        </ContentTemplate>
                </asp:UpdatePanel>                
        </div>
        <div style="width:100px; text-align:center;margin-left:30px">
        <asp:Label ID ="ShowTunnelDirLeft" runat="server" style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px;float:right; text-align:left">长阳</asp:Label>
        <label style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px;float:right; text-align:center">至</label>
        <asp:Label ID ="ShowTunnelDirLeft1" runat="server" style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px; float:right; text-align:right">宜昌</asp:Label>
        </div>  
    </td>
  </tr>
         
  <tr style="height:24px">
    <td>&nbsp;</td>
    <td  style="width:100px ;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel36" runat="server"  >
          <ContentTemplate>     
        <asp:Label ID = "LoacationU7"  runat="server">出口段</asp:Label>
         </ContentTemplate>  
    </asp:UpdatePanel> 
    </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel37" runat="server"  >
          <ContentTemplate>     
        <asp:Label ID = "LoacationU6"  runat="server">中间段</asp:Label>
        </ContentTemplate>  
    </asp:UpdatePanel> 
    </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel35" runat="server"  >
          <ContentTemplate>     
        <asp:Label ID = "LoacationU5"  runat="server">中间段</asp:Label>
         </ContentTemplate>  
    </asp:UpdatePanel> 
    </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
       <asp:UpdatePanel ID="UpdatePanel33" runat="server"  >
          <ContentTemplate>     
         <asp:Label ID = "LoacationU4"  runat="server">过渡３</asp:Label>
          </ContentTemplate>  
    </asp:UpdatePanel> 
         </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel34" runat="server"  >
          <ContentTemplate>     
            <asp:Label ID = "LoacationU3"  runat="server">过渡２</asp:Label>
          </ContentTemplate>  
    </asp:UpdatePanel> 
         </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel39" runat="server"  >
          <ContentTemplate> 
         <asp:Label ID = "LoacationU2"  runat="server">过渡１</asp:Label>
          </ContentTemplate>  
    </asp:UpdatePanel> 
    </td>
    <td  style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    <asp:UpdatePanel ID="UpdatePanel38" runat="server"  >
          <ContentTemplate> 
         <asp:Label ID = "LoacationU1"  runat="server">入口段</asp:Label>
          </ContentTemplate>  
    </asp:UpdatePanel> 
    </td> 
    <td style=" text-align:left; width:120px; color:#FFF;font-family:'仿宋'; font-size:24px;"> 左洞桩号：</td>   
    
  </tr>
  
  <tr style="height:0px">
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td>&nbsp;</td>
  <td style="width:120px;color:#FFF;font-family:'仿宋'; font-size:24px; text-align:right;">
            <asp:Label ID ="ShowLocationLeft" runat="server" > 0177 </asp:Label>
  </td>
  </tr>
  
  <tr style="height:50px">
    <td style="width:120px">&nbsp;</td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel17" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No1warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel18" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No2warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel19" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No3warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel20" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No4warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel21" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No5warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>

    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel22" runat="server"  >
        <ContentTemplate>
            <asp:ImageButton ID="No6warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>

    </td>
    <td style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel23" runat="server"  >
        <ContentTemplate>
             <asp:ImageButton ID="No7warnDown" runat="server" OnClick = "warndown_Click" Enabled="false" ImageUrl = "~/pic/not.png"  style="background-color:transparent;width:50px; height:50px; border:none"/>   
        </ContentTemplate>  
        </asp:UpdatePanel>

    </td>
    <td style="width:120px">&nbsp;</td>
  </tr>
  
  <tr style="height:120px">
    <td style="width:100px" align="left">
        <div style="width:140px;  text-align:right" ><img src="pic/In_Right.png";alt="" style="margin-bottom:5px"/></div>
        <asp:Label  ID ="ShowTunnelDirRight" runat="server" style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px;float:right; text-align:left ">宜昌     </asp:Label>
        <label style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px;float:right; text-align:center "> 至 </label>
        <asp:Label  ID ="ShowTunnelDirRight1" runat="server" style="width:100px;color:#FFF;font-family:'仿宋'; font-size:24px; margin-left:0px;float:right; text-align:right ">     长阳</asp:Label>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel24" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No1BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel25" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No2BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel26" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No3BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel27" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No4BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel28" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No5BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel29" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No6BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="center">
        <asp:UpdatePanel ID="UpdatePanel30" runat="server"  >
        <ContentTemplate>
        <asp:Image ID = "No7BrightSecDown" runat = "server" ImageUrl="~/pic/Bright-0.png"/>
        </ContentTemplate>  
        </asp:UpdatePanel>
    </td>
    <td  style="width:100px" align="right">&nbsp;</td>
  </tr>
  <tr style="height:24px">
    <td style="width:120px;color:#FFF;font-family:'仿宋'; font-size:24px;float:left; text-align:left">右洞桩号：</td>
    
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
    
        <asp:Label ID = "LoacationD1"  runat="server">入口段</asp:Label>
    </td>
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
        <asp:Label ID = "LoacationD2"  runat="server">过渡１</asp:Label>
    </td>

       
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center"> 
        <asp:Label ID = "LoacationD3"  runat="server">过渡２</asp:Label>          
    </td>
    
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
        <asp:Label ID = "LoacationD4"  runat="server">过渡３</asp:Label>
    </td>
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
        <asp:Label ID = "LoacationD5"  runat="server">中间段</asp:Label>
    </td>
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
        <asp:Label ID = "LoacationD6"  runat="server">中间段</asp:Label>
    </td>
    <td style="width:100px;color:#FFF;font-family:'仿宋'; font-size:18px;" align="center">
        <asp:Label ID = "LoacationD7"  runat="server">出口段</asp:Label>
    </td>
    <td>&nbsp;</td>
  </tr>
  <tr style="height:0px">
    <td style="width:120px; color:#FFF;font-family:'仿宋'; font-size:24px;" align="center">
       <asp:Label ID ="ShowLocationRight" runat="server" > 0177 </asp:Label>
    </td>  
  </tr>
  </table>

</div>
</div>
<div style="width:190px;  float:right" align ="center"; >
<div style="width:190px; height:480px">
<div style="width:140px; background-image:url(pic/OutBright.png); height:480px">
<div style ="width:140px";>  
        <div style="width:50px;height:464px;float:left;margin-left:0px;margin-top:0px";>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server"  >                        
                <ContentTemplate>
                    <asp:Image ID ="ShowOutBrightRight" runat ="server" ImageUrl ="~/pic/OutBright-.png" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>        
</div>
   
</div>
<label style="color:White; text-align:center; font-family:'仿宋'; font-size:24px;">左洞外路面亮度</label>
</div>
</div>
</div>


<div id="footSec" style="width:1270px; margin-Left:35px; margin-top:265px ">
<div  style=" width:1200px; float:left;  text-align:center">
<asp:Table ID = "Secondpagecaozuo" runat="server" width="1200" border="0"  >
  <asp:TableRow >        
    <asp:TableCell  style="width:240px" >
        <asp:Button ID="ButtonSystemset" runat="server" OnClick = "Systemset_Click" Text=""  style = "background-color:transparent;background-image:url(pic/Systemset.png); width:140px; height:100px; cursor :pointer;border:none" />
    </asp:TableCell>    
    <asp:TableCell  style="width:240px; padding-left:20px">
        <asp:Button ID= "ButtonEmergency" runat = "server" OnClick ="Emergency_Click" Text="" style = "background-color:transparent;background-image:url(pic/Emergencystop.png); width:140px;height:100px;cursor :pointer;border:none" />
    </asp:TableCell>
    <asp:TableCell  style="width:240px">
        <asp:Button ID="ButtonRecover" runat ="server" OnClick = "Recover_Click" Text="" style="background-color:transparent;background-image:url(pic/recover.png); width:140px;height:100px;cursor :pointer;border:none" />
    </asp:TableCell>
    <asp:TableCell  style="width:240px; padding-right:20px">
         <asp:Button ID="ButtonDayview" runat="server" OnClick="Dayview_Click" Text="" style= "background-color:transparent;background-image:url(pic/ribaochakan.png);width:140px;height:100px;cursor :pointer;border:none" />
    </asp:TableCell>
    <asp:TableCell  style="width:240px">
        <asp:Button ID="ButtonMoonview" runat = "server" OnClick="Moonview_Click" Text="" style="background-color:transparent;background-image:url(pic/Moonview.png); width:140px;height:100px;cursor :pointer;border:none" />
        <asp:Button ID="Inspect" runat = "server" OnClick="Inspect_Click" Text="" style="background-color:transparent; width:0px;height:0px;cursor :pointer;border:none" />
     
    </asp:TableCell>
  </asp:TableRow>
       
  <asp:TableRow style="height:40px" >
    <asp:TableCell  style="width:240px"><img src="pic/WordSystem.png";alt="" /></asp:TableCell>
    <asp:TableCell  style="width:240px; padding-left:20px"><img src="pic/WordEmergency.png";alt="" /></asp:TableCell>
    <asp:TableCell  style="width:240px"><img src="pic/WordRecover.png";alt="" /></asp:TableCell>
    <asp:TableCell  style="width:240px; padding-right:20px"><img src="pic/WordDayview.png";alt="" /></asp:TableCell>
    <asp:TableCell  style="width:240px"><img src="pic/WordMoonview.png";alt="" /></asp:TableCell>   
  </asp:TableRow>	
</asp:Table>
</div>	

</div>
</div>   
</form>
</body>
</html>
