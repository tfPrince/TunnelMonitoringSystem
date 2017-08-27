<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registerpage.aspx.cs" Inherits="suidaozhaoming.Registerpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
   
    function changeImg1(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Register_3.png";
    }
    function changeback1(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Register_1.png";
    }
    function changeImg2(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Register_4.png";
    }
    function changeback2(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Register_2.png";
    }  
</script>
<head id="Head1" runat="server">
    <title>隧道（道路）照明监控系统</title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333";>
    <form id="form1" runat="server">
    
    <div align="center" style="width:1270px; margin-left:-640px; position:absolute; left:50%;height:1014px; background-color:#000">
    <div id="titlefeed" style="width:100%;margin-top:20px";align="center">
        <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>  
            <div style=" width:980px; height:150px; ">

            </div>
           <div style=" width:980px; height:600px; ">
                <div style=" width:600px; height:400px; background-image:url(pic/Register.png)">
                    <asp:TextBox style="text-align:center; width:550px; height:80px; border:none; margin-top:127px;background-color:transparent; font-size:48px"  runat="server">输入工号不存在！</asp:TextBox>
                    <asp:TextBox style="text-align:center; width:550px; height:80px; margin-top:20px; border:none; background-color:transparent; font-size:40px;" runat="server" >请重新输入工号或申请新工号</asp:TextBox>
                </div>
                <div style=" width:980px; height:50px; ">

                </div>
                <div style=" width:600px; height:250px; ">
                 <asp:ImageButton ID="ImageButton1" OnClick="ButtonReturn" runat="server" ImageUrl="~/pic/Register_1.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style ="width:240px; height:82px; margin-top:5px; border:none; background-color:transparent"/>
                 <asp:TextBox runat="server" style = "width:40px;height:82px; border:none; background-color:transparent"/>
                 <asp:ImageButton ID="ImageButton2"  runat="server" OnClick="ButtonRegister" ImageUrl="~/pic/Register_2.png" onmouseout="changeback2(this)" onmouseover="changeImg2(this)" style ="width:240px; height:82px; margin-top:5px; border:none; background-color:transparent"/>
               
                </div>
            </div>
            <div style=" width:980px; height:100px; ">

            </div>
    
            <div style="width:980px; height:80px; ">
                <img src="pic/logo2.png";alt="" /> 
            </div>
    </div>
    </form>
</body>
</html>
