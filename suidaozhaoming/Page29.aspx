<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page29.aspx.cs" Inherits="suidaozhaoming.Page29" %>

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
                                    <asp:Label ID="showtimePage29" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">            
                <asp:ImageButton  ID="ButtonpP29_Exit" runat="server" OnClick = "ButtonP29_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />               
            </div>    
        </div>
 
        <div id="titlefeed" style="width:100%;margin-top:20px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）照明监控系统</asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>
        <div align="center" style=" width:1140px; height:800px;margin-left:-570px;margin-top:30px; position:absolute; left:50%; ">
        
        <asp:image runat="server" ImageUrl="~/Draw2.aspx" style=" width:1000px; height:680px;" ></asp:image>

        <div style="width:1000px; height:60px; text-align:left; margin-top:20px;">
                    <asp:TableCell style="text-align:left; width:40px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:20px;margin-top:20px;" >车流量记录时间:</asp:TableCell>
                    <asp:DropDownList ID="DropDownList3" runat="server"  style="width:80px; color:Black; font-weight:bold; outline:none; font-family:'仿宋'; font-size:34px;">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem Value="0"></asp:ListItem>
                    
                   </asp:DropDownList>
                   <asp:TableCell style="width:40px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:2px;margin-top:20px;" >月</asp:TableCell>
                   <asp:DropDownList ID="DropDownList4" runat="server" style="width:80px; color:Black; font-weight:bold; outline:none; font-family:'仿宋'; font-size:34px;">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                  
                    </asp:DropDownList>
                    <asp:TableCell style="width:40px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:2px;margin-top:20px;" >日</asp:TableCell>
                    
                    <asp:TableCell style="width:220px;text-align: center;margin-left:260px;" >
                    <asp:Button ID="Search_"  OnClick = "Search_Click" runat="server" Text ="查询" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
        </div>
            <div style="width:980px; height:60px;text-align:center; margin-top:10px;" >
                    <img src="pic/logo2.png";alt="" />                 
            </div>
        </div>
    </div>
    </form>
</body>
</html>
