<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page28.aspx.cs" Inherits="suidaozhaoming.Page28" %>

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
                                    <asp:Timer ID="TimerPage27" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage27" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">            
                <asp:ImageButton  ID="ButtonpP27_Exit" runat="server" OnClick = "ButtonP27_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）系统故障信息</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
        <div align="center" style=" width:1140px; height:800px;margin-left:-570px;margin-top:30px; position:absolute;   left:50%; ">
        
            <div style="text-align:left; width:1140px; height:600px;position:absolute;  background-color:Gray ">
                    <asp:TextBox  style="text-align:center; width:40px; height:40px; margin-top:20px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <div></div>
                    <asp:TextBox  style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:80px; height:auto; color:#000;  font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; " >故障序号:</asp:TableCell>
                    <asp:TextBox ID="TextBox1" style="text-align:center; width:160px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; border-color:#000; background-color:White; font-size:28px" Maxlength = "6" runat="server">00000</asp:TextBox>
                    <div></div>
                    <asp:TextBox style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:80px;height:auto; margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >灯具UID:</asp:TableCell>
                    <asp:TextBox ID="TextBox2"  AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "13"  runat="server" >0000000000000</asp:TextBox>
                    <asp:TableCell style="width:100px;height:auto; padding-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >灯具代码:</asp:TableCell>                    
                    <asp:TextBox ID="TextBox3"   AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "13" runat="server">              </asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;padding-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; "  >集控器UID:</asp:TableCell>                   
                    <asp:TextBox ID="TextBox4" AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "10"  runat="server">*****2</asp:TextBox>
                    <div></div>
                    <asp:TextBox  style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; "  >隧道代码:</asp:TableCell>                   
                    <asp:TextBox ID="TextBox5"  AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "10"  runat="server">*****2</asp:TextBox>
                    <asp:TableCell style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px ;margin-left:0px;margin-top:70px;" >隧道名称:</asp:TableCell>
                    <asp:TextBox ID="TextBox6" AutoPostBack="True"  style="text-align:center; width:400px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "20" runat="server">******4</asp:TextBox>
                    <div></div>
                    <asp:TextBox style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px ;margin-left:0px;margin-top:70px;" >隧道位址:</asp:TableCell>
                    <asp:TextBox ID="TextBox7" AutoPostBack="True"  style="text-align:center; width:500px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "20" runat="server">******4</asp:TextBox>
                    
                    <div></div>
                    <asp:TextBox style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell  style="width:100px;height:auto; margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >安装位置:</asp:TableCell>                   
                    <asp:TextBox ID="TextBox8"  AutoPostBack="True"  style="text-align:center; width:500px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10"  runat="server">0000</asp:TextBox>
                    
                    <div></div>
                    <asp:TextBox   style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; "  >故障状态:</asp:TableCell>                   
                    <asp:TextBox ID="TextBox9" AutoPostBack="True"  style="text-align:center; width:100px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "10" runat="server">*****2</asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >故障类型:</asp:TableCell>                   
                    <asp:TextBox ID="TextBox10" AutoPostBack="True"  style="text-align:center; width:500px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10" runat="server">0000</asp:TextBox>
              
           
            <div style="width:1000px; height:30px; text-align:center; margin-top:60px;">
             </div>
             <asp:Table ID="firstpagecaozuo" runat="server" width="1100px" style= "border:0px;margin-top:0px">
                <asp:TableRow style="height:100px;">
                    <asp:TableCell ID="TableCell1" style="width:220px;text-align:center;float:none" runat="server" >
                    <asp:Button ID="Next_Emp" OnClick = "Next_Click" runat="server" Text = "Next" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell2" style="width:220px;text-align: center" runat="server">
                    <asp:Button ID="Last_Emp" OnClick = "Last_Click" runat="server" Text = "Last" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div style="width:1140px; height:60px;text-align:center; margin-top:20px;" >
                    <img src="pic/logo2.png";alt="" />                 
            </div>
        </div>
        </div>
    </div>
    
  </form>
</body>
</html>
