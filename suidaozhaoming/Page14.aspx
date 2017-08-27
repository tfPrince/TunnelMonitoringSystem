<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page14.aspx.cs" Inherits="suidaozhaoming.Page14" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
    <div id="body_full" align="center" style="width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div align = "left"; style="padding-top:21px;margin-left:10px; width:1000px; float:left; height:48px; border:none">
                <div style="width:740px; float:left; height:48px; float:left; margin-left:10px;">
                        <div style="width:460px; float:left; height:48px; float:left; margin-left:10px;">
                            <asp:UpdatePanel ID="gettimeup" runat="server"  >
                            <ContentTemplate>
                                    <asp:Timer ID="TimerPage14" runat="server" Interval="1000" OnTick="GetTimer">
                                    </asp:Timer>
                                    <asp:Label ID="showtimePage14" runat="server" style=" background-color:transparent; color:#CCC; font:Tahoma, Geneva, sans-serif; font-size:44px;" >
                                    </asp:Label>              
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <div align = "right" style="margin-right:15px; padding-top:11px; height:68px; width:97px; float:right">
            
                <asp:ImageButton  ID="ButtonpP14_Exit" runat="server" OnClick = "ButtonP14_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
               
            </div>    
        </div>
        <div id="titlefeed" style="width:100%;margin-top:10px;text-align: center">
            <asp:Label ID="title" runat="server" style="color:#CCC; font:Tahoma, Geneva, sans-serif;font-size:48px; font-weight:bold; margin-left:0px;">隧道（道路）系统交班记录表</asp:Label>
            
        </div>
         
      <asp:Panel ID="pn" runat="server" Height="700px" ScrollBars="Both" Width="1270px" style="margin-top:1px;text-align: center">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="序号"  BorderWidth="4px" BorderColor = "White"  EnableModelValidation="True" 
          style="  border-color:White;  table-layout:inherit;  background-color:transparent; font-weight:bold; font-family:'仿宋'; outline:#fff; overflow:hidden">
              <Columns>
                  <asp:BoundField DataField="序号" ItemStyle-CssClass="colun" ControlStyle-Width="200px" ControlStyle-CssClass = "colun" HeaderText="序号" InsertVisible="False" ReadOnly="True" SortExpression="序号" >
                  <HeaderStyle ForeColor ="Blue"  Wrap="false"  Font-Size = "32" /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="主值班" HeaderText="主值班" SortExpression="主值班">
                  <HeaderStyle ForeColor ="Blue"  Wrap="false" Font-Size = "32"  /><ItemStyle ForeColor ="White"   Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="值班员" HeaderText="值班员" SortExpression="值班员" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28"/> </asp:BoundField>
                  <asp:BoundField DataField="值班员" HeaderText="值班员" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column2" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28"/></asp:BoundField>
                  <asp:BoundField DataField="主接班" HeaderStyle-Width="240px" HeaderText="主接班" SortExpression="主接班" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column2" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28"/></asp:BoundField>
                  <asp:BoundField DataField="接班员" HeaderText="接班员" SortExpression="接班员" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column4" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28"/></asp:BoundField>
                  <asp:BoundField DataField="接班员" HeaderText="接班员" SortExpression="接班员">
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32"  CssClass = "column2" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28"/></asp:BoundField>
                  <asp:BoundField DataField="接班时间" HeaderText="接班时间" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Font-Size = "28" Wrap ="true"/></asp:BoundField>
                  <asp:BoundField DataField="交班时间" HeaderText="交班时间"  SortExpression="交班时间">
                  <HeaderStyle ForeColor ="Blue" Wrap="false"  Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Font-Size = "28" Wrap ="true"/></asp:BoundField>
                  <asp:BoundField DataField="监控运行" HeaderText="监控运行"  SortExpression="监控运行">
                  <HeaderStyle ForeColor ="Blue" Wrap="false"  Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Font-Size = "28" Wrap="false" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="区域图象" HeaderText="区域图象" 
                      SortExpression="区域图象" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false"  Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="照明控制" HeaderText="照明控制"  
                      SortExpression="照明控制" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32"  CssClass = "column3" /><ItemStyle  ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="通风情况" HeaderText="通风情况" 
                      SortExpression="通风情况">
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="紧急情况" HeaderText="紧急情况"  
                      SortExpression="紧急情况">
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" /></asp:BoundField>
                  <asp:BoundField DataField="存在问题" HeaderText="存在问题"  
                      SortExpression="存在问题" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="卫生情况" HeaderText="卫生情况"  
                      SortExpression="卫生情况" >
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="物品交接" HeaderText="物品交接" 
                      SortExpression="物品交接">
                  <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                  <asp:BoundField DataField="备注" HeaderText="备注"  SortExpression="备注">
                   <HeaderStyle ForeColor ="Blue" Wrap="false" Font-Size = "32" CssClass = "column3" /><ItemStyle ForeColor ="White" Wrap="false" Font-Size = "28" CssClass = "column2"/></asp:BoundField>
                     
              </Columns>
          </asp:GridView>
      </asp:Panel>
           <div style=" text-align:left;  width:1270px; height:80px; margin-top:10px">
                   
                    <asp:TableCell style="text-align:left; width:100px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:30px;margin-top:20px; "  >查询月份：</asp:TableCell>                   
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged ="DropDownList1_SelectedIndexChanged"
                        DataSourceID="SqlDataSource1" DataTextField="job_month" DataValueField="job_month"  Width="300px"
                        style="width:300px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
                    </asp:DropDownList>   
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                        
                        SelectCommand="SELECT [job_month] FROM [JobLog] WHERE (([job_month] &lt;&gt; @job_month) AND ([job_month] &lt;&gt; @job_month2))">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="&quot;&quot;" Name="job_month" Type="String" />
                            <asp:Parameter DefaultValue="Null" Name="job_month2" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                    <asp:TableCell ID="TableCell1" style="width:100px; color:White; font-weight:bold; font-family:'仿宋'; font-size:34px;margin-left:200px;margin-top:20px;" >查询年份：</asp:TableCell>
                    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged ="DropDownList2_SelectedIndexChanged"
                        DataSourceID="SqlDataSource2" DataTextField="job_year" DataValueField="job_year"  Width="300px"
                        style="width:300px; color:Black; font-weight:bold; font-family:'仿宋'; font-size:34px;">
                    </asp:DropDownList>    
                    <asp:SqlDataSource ID="SqlDataSource2"  runat="server" 
                        ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                        SelectCommand="SELECT [job_year] FROM [JobLog] WHERE ([job_year] &lt;&gt; @job_year) ORDER BY [job_Id] DESC">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="null" Name="job_year" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
           </div>
        <div style="width:1270px; height:60px;text-align:center; margin-top:10px;" >
            <img src="pic/logo2.png";alt="" />
        </div>    
    </div>
    </form>
</body>
</html>
