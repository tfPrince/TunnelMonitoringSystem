<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScriptNote.aspx.cs" Inherits="suidaozhaoming.ScriptNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    function changeImg1(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Confirm-6B.png";
    }
    function changeback1(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Confirm-6.png";
    }
   
    </script>
<head id="Head1" runat="server">
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
            
               
            </div>  
        </div>
            <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </div>
        <div align="center" style=" width:1140px; height:800px;margin-left:-570px; position:absolute; left:50%; ">
                <div  style="text-align:center; width:600px; height:250px;background-color:transparent;float:left;margin-left:270px;  ">
                </div>
                <div style="text-align:center; width:600px; height:200px; vertical-align:middle; background-color :#E4E4E4;float:left;margin-left:270px;">
                    <asp:TextBox ID="TextBox1" style="text-align:center; vertical-align:inherit; width:550px; height:40px; border:none; margin-top:80px;background-color:transparent; font-size:40px;  color:Black "  runat="server">dd</asp:TextBox>
                </div>
                <div style="text-align:center; width:600px; height:60px;background-color:transparent;float:left;margin-left:270px;  ">
                </div>
                <div style=" width:1140px; height:68px;text-align:center; float:left; margin-left:0px; margin-top:80px"  align = "center">
                        <asp:ImageButton ID = "ButtonConfirm" onclick = "Confirm_Click"  ImageUrl= "~/pic/Confirm-6.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" runat = "server" style ="width:200px; height:68px; margin-top:0px; margin-left:0px;  text-align:center; border:none;outline:none; background-color:transparent" />    
                </div>
                        
                
               <div style="text-align:center; width:600px; height:120px;background-color:transparent;float:left;margin-left:270px;  ">
               </div> 
        

            
                
                <div style="width:980px; height:60px;text-align:center; margin-top:10px;" >
                        <img src="pic/logo2.png";alt="" />   
                </div>
        </div>
     </div>
    
    </form>
</body>
</html>

