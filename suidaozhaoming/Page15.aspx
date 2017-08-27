<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page15.aspx.cs" Inherits="suidaozhaoming.Page15" %>

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
    <style type="text/css">
        .column1{position:relative; table-layout:fixed; white-space:nowrap;overflow:hidden;}
        .column2{white-space:normal; overflow: hidden; padding:2px}
        .column3{width:100px;}
    </style>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333;">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="body_full" style="width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" text-align:center; background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div style="text-align:left; padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                        <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                            <asp:UpdatePanel ID="gettimeup" runat="server"  >
                            <ContentTemplate>
                                    <asp:Timer ID="TimerPage15" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage15" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div style="text-align:right; margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
            
                <asp:ImageButton  ID="ButtonpP14_Exit" runat="server" OnClick = "ButtonP14_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:10px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）系统值班记录表</asp:Label>
            
        </div>
         
      <asp:Panel ID="pn" runat="server" Height="700px" ScrollBars="Both" Width="1270px" style="margin-top:1px;text-align: center">
          <asp:GridView ID="GridView1" runat="server" 
             AutoGenerateColumns="False" DataKeyNames="序号"   EnableModelValidation="True" BorderWidth="4px" BorderColor = "White" 
             style="  border-color:White;  table-layout:inherit;  background-color:transparent; font-weight:bold; font-family:'仿宋'; outline:#fff; overflow:hidden">
              <Columns>
                  <asp:BoundField DataField="序号" HeaderText="序号" InsertVisible="False" 
                     ReadOnly="True" SortExpression="序号" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="日期" HeaderText="日期" SortExpression="日期" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="工号" HeaderText="工号" SortExpression="工号" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField=" 姓名" HeaderText=" 姓名" SortExpression=" 姓名" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="上班时间" HeaderText="上班时间" SortExpression="上班时间" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="下班时间" HeaderText="下班时间" SortExpression="下班时间" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="班次" HeaderText="班次" SortExpression="班次" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
            </Columns>
          </asp:GridView>
          
      </asp:Panel>
           <div style=" text-align:left;  width:1270px; height:80px; margin-top:10px">
                   
                    
                    
                    <asp:TableCell style="text-align:left; width:100px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:30px;margin-top:20px; "  >姓名：</asp:TableCell>                   
                    
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="emp_Name" DataValueField="emp_Name" 
                        style="text-align:right; width:150px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                        SelectCommand="SELECT [emp_Name] FROM [employee_info] WHERE (([emp_Limited] = @emp_Limited) OR ([emp_Name] = @emp_Name))">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="33" Name="emp_Limited" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="emp_Name" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource> 

                    <asp:TableCell style="width:100px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:50px;margin-top:20px;" >时间：</asp:TableCell>
                      
                    <asp:DropDownList ID="DropDownList2" runat="server" 
                       DataSourceID="SqlDataSource2" DataTextField="job_year" DataValueField="job_year" width="120px"
                        style="width:120px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                        SelectCommand="SELECT [job_year] FROM [JobLog] WHERE ([job_year] &lt;&gt; @job_year) ORDER BY [job_year] DESC">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Null" Name="job_year" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:TableCell style="width:40px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:2px;margin-top:20px;" >年</asp:TableCell>
                    <asp:DropDownList ID="DropDownList3" runat="server" style="width:80px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
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
                   <asp:DropDownList ID="DropDownList4" runat="server" style="width:80px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
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
                    <asp:TableCell style="width:220px;text-align: center;margin-left:120px;" >
                    <asp:Button ID="Search_"  OnClick = "Search_Click" runat="server" Text ="查询" onmouseover= "this.style.color = '#000';" onmouseout = "this.style.color ='#FFF';" style="background-image:url(pic/KeyBoard_1.png);background-color:transparent;padding-left:0px; width:160px; height:54px; border:none;color:#FFF; font-weight:bold; font-family:'仿宋'; font-size:30px;text-align: center " />
                    </asp:TableCell>
        </div>
        <div style="width:1270px; height:60px;text-align:center; margin-top:10px;" >
            <img src="pic/logo2.png";alt="" />
        </div>    
    </div>
    
    </form>
</body>
</html>
