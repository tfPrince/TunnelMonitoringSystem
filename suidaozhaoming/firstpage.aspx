<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firstpage.aspx.cs" Inherits="suidaozhaoming._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<script language="javascript" type="text/jscript">
    
       function FClose(){
            window.opener = null;
            window.open('', '_self');
            window.close();
        }



        //var WsShell = new ActiveXObject("WScript.Shell");
        //WsShell.SendKeys("F12");
    

    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/ExitB.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Exit.png";
    }  
    
    </script>  
<head runat="server">
    <title>隧道（道路）照明监控系统</title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333;">

 <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
<div id="body_full" style="text-align: center;width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
<div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
<div  style="text-align: left;padding-top:21px;margin-left:10px; width:740px; float:left; height:48px; border:none">
<div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
<div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
<asp:UpdatePanel ID="gettimeup" runat="server"  >
        <ContentTemplate>
          <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="GetTimer">
            </asp:Timer>
<asp:Label ID="showtime" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
</asp:Label>
              
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</div>
</div>
<div style="text-align: right;margin-right:0px; padding-top:10px; width:140px; height:68px; float:right">
        <asp:ImageButton  ID="ButtonFirst_Exit"  onclientclick = "return FClose()"  ImageUrl ="/pic/Exit.png" onmouseout="changeback(this)" onmouseover="changeImg(this)"  runat="server"  style="float:left; background-color:transparent;height:68px; width:97px; border:none; outline:none; background-color:transparent; margin-left: 0px" />
        

</div>
   
</div>

<div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
    <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</div>

<div id="main" style=" height:300px;margin-Left:10px;margin-top:45px">
<div  style=" width:1080px; float:left;text-align: center ">

<asp:Table ID="suidaotable" runat="server" Width="1080px" style=" border:0px;width:1080px; float:left;text-align: center">
    <asp:TableRow style="height:120px">  
           
        <asp:TableCell style="width:360px;float:none;text-align: center">
        <asp:Button ID="No1suidao" runat="server" OnClick="No1suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
        </asp:TableCell>

        <asp:TableCell style="width:360px;text-align: center" >
        <asp:Button ID="No2suidao" runat="server" OnClick="No2suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
        <asp:TableCell style="width:360px;text-align: center" >
        <asp:Button ID="No3suidao" runat="server" OnClick="No3suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="height:80px" >
        <asp:TableCell style="width:360px;text-align: center"  >
        <asp:UpdatePanel ID="Warnningupdate" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No1warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:360px; text-align: center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No2warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent;" />
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:360px;text-align: center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No3warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="height:120px">
        <asp:TableCell style="width:320px;text-align: center">
        <asp:Button ID="No4suidao" runat="server"  OnClick="No4suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:Button ID="No5suidao" runat="server" OnClick="No5suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center">
        <asp:Button ID="No6suidao" runat="server" OnClick="No6suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="height:80px">
        <asp:TableCell style="width:320px;text-align: center"  >
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No4warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No5warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent;" />
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center"  >
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No6warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="height:120px;text-align: center"  >
        <asp:TableCell style="width:320px;" >
        <asp:Button ID="No7suidao" runat="server" OnClick="No7suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:Button ID="No8suidao" runat="server" OnClick="No8suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:Button ID="No9suidao" runat="server" OnClick="No9suidaodetail" Text="" style="background-color:transparent;background-image:url(pic/suidao_name.png);cursor:pointer; border:none; width:240px;height:80px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px "/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow style="height:80px">
        <asp:TableCell style="width:320px;text-align: center"  >
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No7warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent;"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No8warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent;" />
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell style="width:320px;text-align: center" >
        <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode= "Always"  >
        <ContentTemplate>
        <asp:Image ID="No9warning" runat="server" ImageUrl="~/pic/not.png" style="background-color:transparent"/>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

</div>
<div style="width:180px; float:right;height:300px;text-align: center" >
<asp:ImageButton ID="nextpage" runat="server" OnClick ="Nextpagedetail" ImageUrl="~/pic/goahead.png"  style="margin-top:215px;background-color: transparent; margin-right:0px; width:140px; height:100px; border:none"/>

</div>
</div>


<div id="foot" style="width:1270px; margin-Left:0px; margin-top:320px ">
<div  style=" width:1270px; float:left; text-align: center" >
<asp:Table ID="firstpagecaozuo" runat="server" width="1270px" style= "border:0px">
<asp:TableRow style="height:120px;">
    <asp:TableCell style="width:220px;text-align:center" >
    <asp:ImageButton ID="xunchajianshi" OnClick = "Xunchajianshi_Click" runat="server" ImageUrl ="~/pic/xunchajianshi.png" onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;padding-left:0px; width:140px; height:100px; border:none" />
    </asp:TableCell>
    <asp:TableCell style="width:220px;text-align: center">
    <asp:ImageButton ID="jiaojiebanjilu" OnClick = "Joblog_Click" runat="server" ImageUrl ="~/pic/jiaojiebanjilu.png" onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;padding-left:0px;width:140px; height:100px; border:none;"/>
    </asp:TableCell>
    <asp:TableCell style="width:220px;text-align: center"  >
    <asp:ImageButton ID="zhibanrenyan" OnClick = "Employee_Click" runat="server" ImageUrl = "~/pic/loginButton.png"  onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;padding-left:0px;width:140px; height:100px; border:none; "/>
    </asp:TableCell>
    <asp:TableCell style="width:220px;text-align: center" >
    <asp:ImageButton ID="caozuojiluchakan" OnClick = "JobRecord_Click" runat="server" ImageUrl = "~/pic/caozuojiluchakan.png"  onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;padding-right:0px;width:140px; height:100px; border:none"/>
    </asp:TableCell>
    <asp:TableCell style="width:220px;text-align: center" >
    <asp:ImageButton ID="ribaochakan" runat="server" OnClick = "DataRecord_Click" ImageUrl = "~/pic/ribaochakan.png"  onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;width:140px; height:100px; border:none"/>
    </asp:TableCell>
    <asp:TableCell style="width:220px;text-align: center" >
    <asp:ImageButton ID="SystemSet" runat="server" OnClick = "Set_Click" ImageUrl = "~/pic/ribaochakan.png"  onmouseover ="this.style.background = 'Green';" onmouseout ="this.style.background ='transparent';" style="background-color:transparent;width:140px; height:100px; border:none"/>
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow style="height:40px;text-align: center">
    <asp:TableCell style="width:220px; padding-left:0px;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:24px "   >巡查监视</asp:TableCell>
    <asp:TableCell style="width:220px; padding-left:0px;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:24px "   >交班记录</asp:TableCell>
    <asp:TableCell style="width:220px; padding-left:0px;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:24px "   >用户管理</asp:TableCell>    
    <asp:TableCell style="width:220px; padding-right:0px;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:24px;"  >记录查看</asp:TableCell>
    <asp:TableCell style="width:220px; padding-right:0px;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:24px;"  >报表查看</asp:TableCell>
    <asp:TableCell  >
    <asp:TextBox ID = "BottonText" runat = "server" style="text-align:center;border:none; width:220px; padding-right:0px;background-color:transparent; color:White; font-weight:bold; font-family:'仿宋'; font-size:24px;" >参数设置</asp:TextBox>
    </asp:TableCell>
</asp:TableRow>
</asp:Table>
</div>


</div>
</div>
</form>
</body>
</html>
