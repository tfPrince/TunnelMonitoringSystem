<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page161.aspx.cs" Inherits="suidaozhaoming.Page161" %>

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
                                    <asp:Timer ID="TimerPage161" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage161" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
            
                <asp:ImageButton  ID="ButtonpP16_Exit" runat="server" OnClick = "ButtonP16_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）灯具分组信息管理</asp:Label>
        </div>
        <div align="center" style=" width:1140px; height:850px;margin-left:-570px; position:absolute; left:50%; ">
            <div style=" width:1200px; height:40px; ">   </div>
             <div style="text-align:left; width:1140px; height:600px;position:absolute;  background-color:Gray ">
                    <asp:TextBox ID="TextBox1"  style="text-align:center; width:40px; height:40px; margin-top:20px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <div></div>
                    <asp:TextBox ID="TextBox2"  style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:80px; height:auto; color:#000;  font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; " >序号:</asp:TableCell>
                    <asp:TextBox ID="TextBoxId1" style="text-align:center; width:160px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; border-color:#000; background-color:White; font-size:28px" Maxlength = "6" runat="server">00000</asp:TextBox>
                    <asp:TableCell  style="width:80px; height:auto; color:#000;  font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; " >是否特征灯具:</asp:TableCell>
                    <asp:CheckBox ID="CheckBoxId1" runat="server" Width = "10px" Height = "10px"  style = "outline:none; zoom:300%" />
                    <div></div>
                    <asp:TextBox ID="TextBox4" style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:80px;height:auto; margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >灯具UID:</asp:TableCell>
                    <asp:TextBox ID="TextBoxId2"  AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "12"  runat="server" >0000000000000</asp:TextBox>
                    <asp:TableCell style="width:100px;height:auto; padding-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >灯具代码:</asp:TableCell>                    
                    <asp:TextBox ID="TextBoxId3"   AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "20" runat="server">              </asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;padding-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; "  >集控器UID:</asp:TableCell>                   
                    <asp:TextBox ID="TextBoxId4" AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "12"  runat="server">*****2</asp:TextBox>
                    <div></div>
                    <asp:TextBox ID="TextBox8"  style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; "  >隧道代码:</asp:TableCell>                   
                    <asp:TextBox ID="TextBoxId5"  AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "13"  runat="server">*****2</asp:TextBox>
                    <asp:TableCell style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px ;margin-left:0px;margin-top:70px;" >隧道名称:</asp:TableCell>
                    <asp:TextBox ID="TextBoxId6" AutoPostBack="True"  style="text-align:center; width:400px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "20" runat="server">******4</asp:TextBox>
                    <div></div>
                    <asp:TextBox ID="TextBox11" style="text-align:center; width:40px; height:40px; margin-top:30px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px ;margin-left:0px;margin-top:70px;" >隧道位址:</asp:TableCell>
                    <asp:TextBox ID="TextBoxId7" AutoPostBack="True"  style="text-align:left; width:500px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "20" runat="server">******4</asp:TextBox>
                    
                    <div></div>
                    <asp:TextBox ID="TextBox13" style="text-align:center; width:40px; height:40px; margin-top:38px; border:none;outline:none;  background-color:transparent" runat="server" ></asp:TextBox>
                    <asp:TableCell  style="width:100px;height:auto; margin-left:0px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >安装位置:</asp:TableCell>                   
                    <asp:TextBox ID="TextBoxId8"  AutoPostBack="True"  style="text-align:left; width:500px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10"  runat="server">0000</asp:TextBox>
                    
                    <div></div>
                    <asp:TextBox ID="TextBox15"   style="text-align:center; width:40px; height:40px; margin-top:38px; border:none;outline:none;  background-color:transparent" runat="server"></asp:TextBox>
                    <asp:TableCell  style="width:100px; height:auto;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px;margin-top:70px; ">显示位置:</asp:TableCell>                   
             
                    <asp:DropDownList ID="DropDownList1" runat="server" style="width:300px; height:40;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:0px; margin-top:38px;">
                            <asp:ListItem Value="01">下行入口段</asp:ListItem>
                            <asp:ListItem Value="02">下行过渡1段</asp:ListItem>
                            <asp:ListItem Value="03">下行过渡2段</asp:ListItem>
                            <asp:ListItem Value="04">下行过渡3段</asp:ListItem>
                            <asp:ListItem Value="05">下行中间段</asp:ListItem>
                            <asp:ListItem Value="06">下行中间段后</asp:ListItem>
                            <asp:ListItem Value="07">下行出口段</asp:ListItem>
                            <asp:ListItem Value="11">上行入口段</asp:ListItem>
                            <asp:ListItem Value="12">上行过渡1段</asp:ListItem>
                            <asp:ListItem Value="13">上行过渡2段</asp:ListItem>
                            <asp:ListItem Value="14">上行过渡3段</asp:ListItem>
                            <asp:ListItem Value="15">上行中间段</asp:ListItem>
                            <asp:ListItem Value="16">上行中间段后</asp:ListItem>
                            <asp:ListItem Value="17">上行出口段</asp:ListItem>
                            
                     </asp:DropDownList>
            </div>
             <div style="width:1000px; height:30px; text-align:center; margin-top:600px;"></div>
             <asp:Table ID="firstpagecaozuo" runat="server" width="1100px" style= "border:0px;margin-top:0px">
                <asp:TableRow style="height:100px;">
                    <asp:TableCell ID="TableCell1" style="width:220px;text-align:center;float:none" runat="server" >
                    <asp:Button ID="Next_Info" OnClick = "Next_Click" runat="server" Text = "Next" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell2" style="width:220px;text-align: center" runat="server">
                    <asp:Button ID="Last_Info" OnClick = "Last_Click" runat="server" Text = "Last" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell3" style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="New_Info"   OnClick = "New_Click" runat="server" Text = "New" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell4" style="width:220px;text-align: center"  runat="server">
                    <asp:Button ID="Alt_Info"  OnClick = "Alt_Click"  runat="server" Text = "Alter" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="Del_Info"  OnClick = "Del_Click" runat="server" Text ="Del" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell6" style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="Ent_Info"  OnClick = "Ent_Click" runat="server" Text ="Enter" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                </asp:TableRow>
          </asp:Table>
           <div style="width:1000px; height:20px; text-align:center; margin-top:0px;"></div>
            <div style="width:980px; height:60px;text-align:center; margin-top:0px;" >
                    <img src="pic/logo2.png";alt="" />                 
            </div>
        </div>
    </div>
  
</form>
</body>
</html>
