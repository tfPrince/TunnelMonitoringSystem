<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page16.aspx.cs" Inherits="suidaozhaoming.Page16" %>

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
            
                <asp:ImageButton  ID="ButtonpP16_Exit" runat="server" OnClick = "ButtonP16_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
        <div align="center" style=" width:1140px; height:850px;margin-left:-570px; position:absolute; left:50%; ">
            <div style=" width:1200px; height:20px; ">

            </div>
            <div style=" width:1000px; height:600px; text-align:left;  background-image:url(pic/Tunnel_M.png); margin-top:0px" >
                    <div style=" width:1000px; height:550px; float:left;  margin-top:70px;">
                    <asp:TableCell style="width:80px; color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:30px;margin-top:70px; " >序号：</asp:TableCell>
                    <asp:TextBox ID="Tunnel_No" style="text-align:center; width:60px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; border-color:#000; background-color:White; font-size:28px"  runat="server">00</asp:TextBox>
                    <asp:TableCell style="width:80px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >代码：</asp:TableCell>
                    <asp:TextBox ID="Tunnel_Code"  AutoPostBack="True"  style="text-align:center; width:190px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "13"  runat="server" >0000000000000</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >隧道名：</asp:TableCell>                    
                    <asp:TextBox ID="Tunnel_Name"   AutoPostBack="True"  style="text-align:center; width:350px; height:40px;font-family:'仿宋'; margin-left:0px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "20" runat="server">              </asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; "  >入口地址：</asp:TableCell>                   
                    <asp:TextBox ID="Tunnel_Ent_N" AutoPostBack="True"  style="text-align:center; width:400px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "10"  runat="server">*****2</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px "  >入口桩号:</asp:TableCell>                   
                    <asp:TextBox ID="Tunnel_Ent_L"  AutoPostBack="True"  style="text-align:center; width:220px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10"  runat="server">0000</asp:TextBox>
                    
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; "  >出口地址：</asp:TableCell>                   
                    <asp:TextBox ID="Tunnel_Ext_N" AutoPostBack="True"  style="text-align:center; width:400px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:30px; border:none;outline:none; background-color:White; font-size:28px" Maxlength = "10" runat="server">*****2</asp:TextBox>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px " >出口桩号:</asp:TableCell>                   
                    <asp:TextBox ID="Tunnel_Ext_L" AutoPostBack="True"  style="text-align:center; width:220px; height:40px;font-family:'仿宋'; margin-left:10px; margin-top:30px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10" runat="server">0000</asp:TextBox>
                    
                    <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px ;margin-left:20px;margin-top:70px;" >隧道位址：</asp:TableCell>
                    <asp:TextBox ID="Tunnel_Addr" AutoPostBack="True"  style="text-align:center; width:600px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "20" runat="server">******4</asp:TextBox>
                     <div></div>
                    <asp:TableCell style="width:100px; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:28px;margin-left:20px;margin-top:70px; " >气象地址：</asp:TableCell>
                    <asp:TextBox ID="Tunnel_Weather"  AutoPostBack="True"  style="text-align:center; width:600px; height:40px;font-family:'仿宋'; margin-left:8px; margin-top:38px; border:none; outline:none;background-color:White; font-size:28px" Maxlength = "10" runat="server">******4</asp:TextBox>
                    <div></div>
                    <asp:TableCell style="width:120px; text-align:left; padding-left:10px;color:#000; font-weight:bold; font-family:'仿宋'; font-size:40px;margin-left:20px;margin-top:20px; "  >备注：</asp:TableCell>
                    
                    
                    <asp:TextBox ID="Tunnel_Mark"  AutoPostBack="True" ontextchanged="TextBox_TextChanged" style="text-align:left; width:780px; height:80px;font-family:'仿宋'; margin-left:10px; margin-top:40px; border:none;outline:none; background-color:White; font-size:28px;" textmode = "MultiLine"  Maxlength = "200" runat="server">！！！</asp:TextBox>
                    </div>
             </div>
             <div style="width:1000px; height:30px; text-align:center; margin-top:0px;">
             </div>
             <asp:Table ID="firstpagecaozuo" runat="server" width="1100px" style= "border:0px;margin-top:0px">
                <asp:TableRow style="height:100px;">
                    <asp:TableCell style="width:220px;text-align:center;float:none" runat="server" >
                    <asp:Button ID="Next_Emp" OnClick = "Next_Click" runat="server" Text = "Next" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" runat="server">
                    <asp:Button ID="Last_Emp" OnClick = "Last_Click" runat="server" Text = "Last" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="New_Emp"   OnClick = "New_Click" runat="server" Text = "New" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center"  runat="server">
                    <asp:Button ID="Alt_Emp"  OnClick = "Alt_Click"  runat="server" Text = "Alter" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="Del_Emp"  OnClick = "Del_Click" runat="server" Text ="Del" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
                    <asp:TableCell style="width:220px;text-align: center" runat="server" >
                    <asp:Button ID="Ent_Emp"  OnClick = "Ent_Click" runat="server" Text ="Enter" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
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
