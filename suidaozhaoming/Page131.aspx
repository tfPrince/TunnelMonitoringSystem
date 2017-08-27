<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page131.aspx.cs" Inherits="suidaozhaoming.Page131" %>

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
            
                <asp:ImageButton  ID="ButtonpP131_Exit" runat="server" OnClick = "ButtonP131_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>

        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
        <div align="center" style=" width:1140px; height:850px;margin-left:-570px; position:absolute; left:50%; ">
            <div style=" width:1200px; height:20px; ">

            </div>
            <div style=" width:1000px; height:600px; text-align:center;  background-image:url(pic/Jobmanage-3.png); margin-top:0px" >
                    <div style=" width:1000px; height:550px; float:left; text-align:left; margin-top:70px;">
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; ">序号：</asp:TableCell>
                    <asp:TextBox ID="Emp_Id" style="text-align:center; width:140px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; border-color:#000; background-color:White; font-size:28px"  runat="server">*****1</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >账号：</asp:TableCell>
                    <asp:TextBox ID="Emp_No" style="text-align:center; width:240px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server" >！！！1</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >姓名：</asp:TableCell>                    
                    <asp:TextBox ID="Emp_Name" style="text-align:center; width:140px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">*****2</asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; "  >管理权限：</asp:TableCell>                   
                    <asp:DropDownList ID="Emp_Lim"  OnSelectedIndexChanged = "Emp_Changed" runat="server" 
                            style="text-align:center; width:200px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White;font-size:28px" 
                            AutoPostBack="True">
                            <asp:ListItem Value="11">高级管理员</asp:ListItem>
                            <asp:ListItem Value="22">系统管理员</asp:ListItem>
                            <asp:ListItem Value="33">系统值班员</asp:ListItem>
                            <asp:ListItem Value="44">访客</asp:ListItem>
                            <asp:ListItem Value="55">上级巡查员</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >密码：</asp:TableCell>                   
                    <asp:TextBox ID="Emp_Key" style="text-align:center; width:160px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">！！！3</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >姓别：</asp:TableCell>
                    <asp:DropDownList ID="Emp_Sex" runat="server" style="text-align:center; width:60px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:38px; border:none;outline:none; background-color:White; font-size:28px;" >
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:DropDownList>
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px; " >电话号码１：</asp:TableCell>
                    <asp:TextBox ID="Emp_Tel1" style="text-align:center; width:254px; height:40px; font-family:'仿宋';margin-left:8px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px"  runat="server">******4</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >电话号码２：</asp:TableCell>
                    <asp:TextBox ID="Emp_Tel2" style="text-align:center; width:254px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:38px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">******4</asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px;  "  >注册时间：</asp:TableCell>
                    <asp:TextBox ID="Emp_RDa" style="text-align:center; width:280px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">*****5*</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >注消时间：</asp:TableCell>
                    <asp:TextBox ID="Emp_DDa" style="text-align:center; width:280px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">*****6</asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; "  >备注：</asp:TableCell>
                    <asp:TextBox  style="text-align:center; width:474px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:transparent; font-size:28px"  runat="server"></asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >审批人员：</asp:TableCell>
                    <asp:TextBox ID="Emp_Oper" style="text-align:center; width:140px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px"  runat="server">*****7</asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:0px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; "  ></asp:TableCell>
                    <asp:TextBox ID="Emp_Mark"  style="text-align:center; width:880px; height:100px;font-family:'仿宋'; margin-left:10px; margin-top:20px; border:none; outline:none;background-color:White; font-size:28px; "   runat="server">！！！</asp:TextBox>
                    </div>
             </div>
             <div style="width:1000px; height:30px; text-align:center; margin-top:0px;">
             </div>
             <asp:Table ID="firstpagecaozuo" runat="server" width="1080px" style= "border:0px;margin-top:0px">
                <asp:TableRow style="height:100px;">
                    <asp:TableCell style="width:220px;text-align:center;float:none" >
                    <asp:Button ID="Next_Emp" OnClick = "Next_Click" runat="server" Text = "Next" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center">
                    <asp:Button ID="Last_Emp" OnClick = "Last_Click" runat="server" Text = "Last" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center"  >
                    <asp:Button ID="New_Emp"   OnClick = "New_Click" runat="server" Text = "New" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" >
                    <asp:Button ID="Del_Emp"  OnClick = "Del_Click"  runat="server" Text = "Del" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" >
                    <asp:Button ID="Alt_Emp"  OnClick = "Alt_Click" runat="server" Text ="Alt" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
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
