<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1315.aspx.cs" Inherits="suidaozhaoming.Page1315" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Confirm-5B.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Confirm-5.png";
    }
    function changeImg1(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Confirm-6B.png";
    }
    function changeback1(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Confirm-6.png";
    }
    function changeImg2(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/ExitB.png";
    }
    function changeback2(btn)  //鼠标移出，换回原来的图片        
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
     <div id="body_full" align="center" style="width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div align = "left"; style="padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                        <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                            <asp:UpdatePanel ID="gettimeup" runat="server"  >
                            <ContentTemplate>
                                    <asp:Timer ID="TimerPage12" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage12" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
            
                <asp:ImageButton  ID="ButtonpP1315_Exit" runat="server" OnClick = "ButtonP1315_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback2(this)" onmouseover="changeImg2(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>  
        </div>
            <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </div>
        <div align="center" style=" width:1140px; height:800px;margin-left:-570px; position:absolute; left:50%; ">
                <div  style="text-align:center; width:600px; height:100px;background-color:transparent;float:left;margin-left:270px;  ">
                </div>
                <div style="text-align:center; width:600px; height:200px;background-color:#E4E4E4;float:left;margin-left:270px;">
                    <asp:TextBox ID="TextBox1" style="text-align:center; width:550px; height:80px; border:none; margin-top:20px;background-color:transparent; font-size:40px;color:Black "  runat="server">    dd          </asp:TextBox>
                    <asp:TextBox ID="TextBox2" style="text-align:center; width:550px; height:80px; margin-top:0px; border:none; background-color:transparent;color:Black; font-size:48px;" runat="server" >      dd         </asp:TextBox>
                </div>
                <div style="text-align:center; width:600px; height:60px;background-color:transparent;float:left;margin-left:270px;  ">
                </div>
                <div style=" text-align:center; width:500px; height:245px; float:left;margin-left:320px; background-image:url(pic/Confirm-3.png); margin-top:0px" >
                <div style=" width:300px; height:45px;text-align:center; float:left; margin-left:97px; margin-top:80px">
                        <asp:TextBox ID="TextBoxPassword" style = "text-align:center; width:240px; height:40px;  margin-top:0px; border:none; outline:none; background-color:transparent; font-size:38px"  Maxlength = "10" TextMode ="Password" runat="server">0000000000</asp:TextBox>                        
                </div>
            
                <asp:ImageButton ID = "ButtonCancel" onclick = "Cancel_Click" ImageUrl= "~/pic/Confirm-5.png" onmouseout="changeback(this)" onmouseover="changeImg(this)" runat = "server" style ="width:200px; height:68px; margin-top:20px; margin-left:36px; float:inherit; border:none;outline:none; background-color:transparent" />
                <asp:ImageButton ID = "ButtonConfirm" onclick = "Confirm_Click"  ImageUrl= "~/pic/Confirm-6.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" runat = "server" style ="width:200px; height:68px; margin-top:20px; margin-left:20px; float:inherit; border:none;outline:none; background-color:transparent" />    
                               
                 </div>
            <div style="text-align:center; width:600px; height:100px;background-color:transparent;float:left;margin-left:270px;  ">
            </div>

            
                
                <div style="width:980px; height:60px;text-align:center; margin-top:10px;" >
                        <img src="pic/logo2.png";alt="" />   
                </div>
        </div>
    </div>
    </form>
</body>
</html>
