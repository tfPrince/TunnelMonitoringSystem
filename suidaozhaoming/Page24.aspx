<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page24.aspx.cs" Inherits="suidaozhaoming.Page24" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
     
    
    <script language="javascript" type="text/jscript">
        function changeImg(btn) //������룬����ͼƬ        
        {
            btn.src = "pic/ExitB.png";
        }
        function changeback(btn)  //����Ƴ�������ԭ����ͼƬ        
        {
            btn.src = "pic/Exit.png";
        }  
    </script>
    

<head id="Head1" runat="server">
    <title>�������·���������ϵͳ</title>
</head>

<body style="width:1280px;height:1024px;margin: 0;height:100%;width:100%;background-color:#333;">

<form id="form1" runat="server" style = "width:100%">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div id="body_full" align="center" style="width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
    

        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div align = "left"; style="padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                    <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                    <asp:UpdatePanel ID="gettimeup" runat="server"  >
                        <ContentTemplate>
                            <asp:Timer ID="TimerSec_1" runat="server" Interval="1000" OnTick="GetTimer">
                            </asp:Timer>
                            <asp:Label ID="ShowtimeSec" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                            </asp:Label>              
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                
            </div>
            
        </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
                      
                <asp:ImageButton  ID="ButtonPage24_Exit" OnClick = "ButtonPage24_Exit_Click" ImageUrl ="/pic/Exit.png" onmouseout="changeback(this)" onmouseover="changeImg(this)"  runat="server"  style="float:left; background-color:transparent;height:68px; width:97px; border:none; background-color:transparent; margin-left: 0px" />
            
            </div>   
        </div>
        <div id="titlefeed" style="width:100%;margin-top:10px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">�������������ձ���</asp:Label>
            
            
            
        </div>
    <div style="width:1270px;height:855px;border:none" id="container" >
    <asp:Panel ID="pn" runat="server" Height="700px" ScrollBars="Both" Width="1270px"  align = "center" style="margin-top:1px;text-align:center">
        <asp:GridView ID="GridViewPage24" runat="server" AutoGenerateColumns="False"  DataKeyNames="���"  EnableModelValidation="True"   BorderWidth="4px"  BorderColor = "White"
        style="border-color:White; table-layout:inherit;  background-color:transparent; font-weight:bold; font-family:'����';  outline:#fff; border-right-width:thick; overflow:hidden" >
            <Columns>
                <asp:BoundField DataField="���" ItemStyle-CssClass = "colun" ControlStyle-Width= "200px" ControlStyle-CssClass = "colun" HeaderText="���" InsertVisible="False" ReadOnly="True" SortExpression="���" >
                <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  
                <asp:BoundField DataField="̽ͷUID���"  HeaderText="̽ͷUID���" SortExpression="̽ͷUID���" ItemStyle-CssClass = "colun" ControlStyle-Width= "200px">
                <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                <asp:BoundField DataField="��������ֵ" HeaderText="��������ֵ"   SortExpression="��������ֵ" ItemStyle-CssClass = "colun" ControlStyle-Width= "200px" >
                <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                <asp:BoundField DataField="�������ȵȼ�" HeaderText="�������ȵȼ�" SortExpression="�������ȵȼ�" ItemStyle-CssClass = "colun" ControlStyle-Width= "200px">
                <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                <asp:BoundField DataField="����ʱ��" HeaderText="����ʱ��" SortExpression="����ʱ��" ItemStyle-CssClass = "colun" ControlStyle-Width= "200px">
                <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
            SelectCommand="SELECT [id] as &quot;���&quot;, [cuid] as &quot;̽ͷUID���&quot;, [lightness] as &quot;��������ֵ&quot;, [lightlevel] as &quot;�������ȵȼ�&quot;, [dbtime] as &quot;����ʱ��&quot; FROM [LightLevel] WHERE ([cuid] = @cuid) ORDER BY [id] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="CC6012070168" Name="cuid" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </asp:Panel>
            <div style="width:1100px; height:60px; text-align:left; margin-top:20px;">
                    
                    <asp:TableCell style="text-align:left; width:40px; color:White; font-weight:bold; font-family:'����'; font-size:34px;margin-left:20px;margin-top:20px;" >����������ʱ��:</asp:TableCell>
                    <asp:DropDownList ID="DropDownList3" runat="server"  style="width:80px; color:Black; font-weight:bold; outline:none; font-family:'����'; font-size:34px;">
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
                    
                   </asp:DropDownList>
                   <asp:TableCell style="width:40px; color:White; font-weight:bold; font-family:'����'; font-size:34px;margin-left:2px;margin-top:20px;" >��</asp:TableCell>
                   <asp:DropDownList ID="DropDownList4" runat="server" style="width:80px; color:Black; font-weight:bold; outline:none; font-family:'����'; font-size:34px;">
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
                                     
                    </asp:DropDownList>
                    <asp:TableCell style="width:40px; color:White; font-weight:bold; font-family:'����'; font-size:34px;margin-left:2px;margin-top:20px;" >��</asp:TableCell>
                    
                    <asp:TableCell style="text-align:left; width:40px; color:White; font-weight:bold; font-family:'����'; font-size:34px;margin-left:20px;margin-top:20px;" >λ��:</asp:TableCell>
                    <asp:DropDownList ID="DropDownList2" runat="server" style="width:80px; color:Black; font-weight:bold; outline:none; margin-left:0px;font-family:'����'; font-size:34px;">
                            <asp:ListItem Value="0">��</asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TableCell style="text-align:left; width:40px; color:White; font-weight:bold; font-family:'����'; font-size:34px;margin-left:2px;margin-top:20px;" >��</asp:TableCell>
                    
                    <asp:TableCell style="width:220px;text-align: center;margin-left:100px;" >
                    <asp:Button ID="Search_"  OnClick = "Search_Click" runat="server" Text ="��ѯ" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'����'; font-size:30px;text-align: center " />
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