<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page160.aspx.cs" Inherits="suidaozhaoming.Page160" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/KeyBoard_2.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/KeyBoard_1.png";
    }

    function changeImg1(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/ExitB.png";
    }
    function changeback1(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Exit.png";
    }
    
    </script>
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333;">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="body_full" align="center" style="width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div align = "left"; style="padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                        <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                            <asp:UpdatePanel ID="gettimeup" runat="server"  >
                            <ContentTemplate>
                                    <asp:Timer ID="TimerPage16" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage16" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
            
                <asp:ImageButton  ID="ButtonpP160_Exit" runat="server" OnClick = "ButtonP160_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
        <div align="center" style=" width:1140px; height:850px;margin-left:-570px; position:absolute; left:50%; ">
            <div style=" width:1200px; height:20px; ">

            </div>
            <asp:Table ID="firstpagecaozuo" runat="server" width="1100px" style= "border:0px;margin-top:0px">
                <asp:TableRow style="height:150px;">
                </asp:TableRow>
                <asp:TableRow style="height:100px;">
                    <asp:TableCell ID="TableCell1" style="width:500px;text-align:center;float:none" runat="server" >
                    <asp:Button ID="Fisrt" OnClick = "First_Click" runat="server" Text = "进入隧道参数管理页面" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-color:Gray;  border-width:thick; border-color:Green; padding-left:0px; width:600px; height:100px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:44px;text-align:left" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow style="height:120px;">
                </asp:TableRow>
                <asp:TableRow style="height:100px;">
                <asp:TableCell ID="TableCell2" style="width:500px;text-align: center" runat="server">
                    <asp:Button ID="Second" OnClick = "Second_Click" runat="server" Text = "进入灯具分组信息管理页面" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-color:Gray; border-color:Green; border-width:thick;padding-left:0px; width:600px; height:100px; color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:44px;text-align:left " />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow style="height:200px;">
                </asp:TableRow>
            </asp:Table>
            <div style="width:1000px; height:20px; text-align:center; margin-top:0px;">
             </div>
            <div style="width:980px; height:60px;text-align:center; margin-top:0px;" >
                    <img src="pic/logo2.png";alt="" />                 
            </div>
        </div>
    </div>
    </form>
</body>
</html>
