<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page121.aspx.cs" Inherits="suidaozhaoming.Page121" %>

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
    </script>
<head runat="server">
    <title></title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#ccc;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="body_full" align="center" style="width:500px; margin-left:-250px; margin-top:100px; position:absolute;left:50%;height:245px; background-color:#ccc">
        <div style=" width:500px; height:245px; float:left; background-image:url(pic/Confirm-3.png); margin-top:0px" >
            <asp:ImageButton ID = "ButtonCancel" onclick = "Cancel_Click" ImageUrl= "~/pic/Confirm-5.png" onmouseout="changeback(this)" onmouseover="changeImg(this)" runat = "server" style ="width:200px; height:68px; margin-top:132px; margin-left:40px; float:inherit; border:none; background-color:transparent" />
            <asp:ImageButton ID = "ButtonConfirm" onclick = "Confirm_Click"  ImageUrl= "~/pic/Confirm-6.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" runat = "server" style ="width:200px; height:68px; margin-top:132px; margin-left:20px; float:inherit; border:none; background-color:transparent" />    
        </div>
    </div>
    </form>
</body>
</html>
