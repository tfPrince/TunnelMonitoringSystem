<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="suidaozhaoming.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    
    
    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/OK-2B.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/OK-2.png";
    }  
    </script>
<head runat="server">
    <title>隧道（道路）照明监控系统</title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333";>
    <form id="form1" runat="server">
    
    <div  style="text-align:center;width:1270px; margin-left:-640px; position:absolute; left:50%;height:1014px; background-color:#000">
            <div style=" width:1270px; height:250px;text-align:center; ">

            </div>
            <div style=" width:980px; height:520px;text-align:center;margin-left:145px">
                <div style=" width:500px; height:520px; float:left" >
                <img src="pic/login-2.png";alt="" /> 
                </div>
                <div style=" width:374px; height:400px; float:right; background-image:url(pic/login-3.png); margin-top:60px">
                <asp:TextBox ID="TextBoxEmp_No" style="text-align:center; width:254px; height:47px; margin-top:127px; border:none;outline:none; background-color:transparent; font-size:40px"  runat="server">      </asp:TextBox>
                <asp:TextBox ID="TextBoxKey" style="text-align:center; width:254px; height:47px; margin-top:62px; border:none;outline:none; background-color:transparent; font-size:40px;" textmode="Password" runat="server" >0000000001</asp:TextBox>
                <!--
                <asp:button ID = "ButtonOK" runat = "server" OnClick="ButtonOKdetail"  style =" background-image:url(pic/OK-2.png); width:160px; height:54px; margin-top:35px; margin-left:7px; border:none; background-color:transparent"></asp:button>
                    !-->
               <asp:ImageButton ID="ImageButtonOK" runat="server" OnClick="ButtonOKdetail" ImageUrl="~/pic/OK-2.png" onmouseout="changeback(this)" onmouseover="changeImg(this)" style ="width:160px; height:54px; margin-top:35px; margin-left:7px; border:none;outline:none; background-color:transparent"/>
            </div>
            </div>
    <div style="width:980px; height:150px;text-align:center;margin-left:145px ">
    </div>
    <div style="width:980px; height:80px;text-align:center;margin-left:145px ">
        <img src="pic/logo2.png";alt="" /> 
    </div>
    </div>
    </form>
</body>
</html>
