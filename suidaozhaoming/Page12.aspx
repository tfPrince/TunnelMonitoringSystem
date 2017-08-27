<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page12.aspx.cs" Inherits="suidaozhaoming.Page12" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<script type="text/javascript">
    function changeImg(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/ExitB.png";
    }
    function changeback(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Exit.png";
    }
    function changeImg1(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Confirm-1B.png";
    }
    function changeback1(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Confirm-1.png";
    }
    function changeImg2(btn) //鼠标移入，更换图片        
    {
        btn.src = "pic/Confirm-2B.png";
    }
    function changeback2(btn)  //鼠标移出，换回原来的图片        
    {
        btn.src = "pic/Confirm-2.png";
    }    
    </script>

<head runat="server">
    <title>隧道（道路）照明监控系统</title>
</head>
<body style="margin: 0;height:100%;width:100%;background-color:#333;">
    <form id="form1" runat="server"  >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="body_full" style="text-align:center;width:1270px; margin-left:-640px; position:absolute;left:50%;height:1014px; background-color:#000">
        <div id="head" style=" background-image:url(pic/headline.png);background-repeat:repeat-x; width:100%; height:90px " >
            <div style="text-align:left; padding-top:21px;margin-left:10px; width:540px; float:left; height:48px; border:none">
                <div style="width:540px; float:left; height:48px; float:left; margin-left:10px;">
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
            <div style="text-align:center; margin-right:15px; padding-top:11px; width:80px; float:right">
            </div>    
        </div>
        <div style="width:680px; height:40px ;margin-right:0px; padding-top:-0px;  float:right">
                <div style="height:40px; width:600px; float:right; margin-right:200px; margin-top:-56px">
                         <label style="color:#FFF; font-family:'仿宋'; font-size:28px; ">如不进行交接班其工作时间均为上一班人员!</label>
                </div>
                <div  style= "float:left; height:68px; width:97px; margin-left:540px; margin-top:-80px">
                <asp:ImageButton  ID="ButtonpP12_Exit" runat="server" OnClick = "ButtonP12_Exit_Click" ImageUrl = "~/pic/Exit.png" onmouseout="changeback(this)" onmouseover="changeImg(this)" style="height:68px; width:97px; border:none;outline:none; background-color:transparent;" />
                </div>
        </div>
        <div style="text-align:center; width:1200px; height:654px;margin-left:-600px; position:absolute; left:50%; ">
        <div style=" width:1200px; height:40px; ">

        </div>
        <div style=" width:1220px; height:80px; ">
        <label style="color:#FFF; font-family:'黑体'; font-size:54px; ">监控室值班交接班记录</label>
        </div>
        <div style="text-align:center; width:600px; height:730px; float:left; background-image:url(pic/JobLog.png); margin-top:0px" >
                <asp:TextBox  style="text-align:center;width:180px; height:36px; float:none; margin-left:20px; margin-top:6px; border:none; background-color:transparent;color:White; font-size:28px"  runat="server"> 接班时间：</asp:TextBox>
                <asp:TextBox ID="Job_time1"  style="text-align:center;width:250px; height:36px; margin-left:310px; margin-top:2px; border:none; background-color:transparent;color:White; font-size:24px"   runat="server">  -------------- </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog1" style="text-align:left;float:left; position:relative;width:380px; height:70px; margin-left:190px; margin-top:-1px; border:none;outline:none; background-color:transparent; font-size:30px"  textmode = "MultiLine"  Maxlength = "200" runat="server">               </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog2" style="text-align:left;float:left;position:relative;width:380px;  height:70px; margin-left:190px; margin-top:0px; border:none; outline:none; background-color:transparent; font-size:30px;" textmode = "MultiLine"  Maxlength = "200" runat="server" >             </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog3" style="text-align:left;float:left;position:relative;width:380px; height:70px; margin-left:190px; margin-top:4px;  border:none; outline:none;background-color:transparent; font-size:30px"  textmode = "MultiLine"  Maxlength = "200" runat="server">               </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog4" style="text-align:left;float:left;position:relative;width:380px; height:70px; margin-left:190px; margin-top:4px; border:none; outline:none;background-color:transparent; font-size:30px;" textmode = "MultiLine"  Maxlength = "200" runat="server" >              </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog5" style="text-align:left;float:left;position:relative;width:380px;  height:70px; margin-left:190px; margin-top:4px; border:none;outline:none; background-color:transparent; font-size:30px"  textmode = "MultiLine"  Maxlength = "200" runat="server">               </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog6" style="text-align:left;float:left;position:relative;width:380px;  height:70px; margin-left:190px; margin-top:4px; border:none;outline:none; background-color:transparent; font-size:30px;" textmode = "MultiLine"  Maxlength = "200" runat="server" >              </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog7" style="text-align:left;float:left;position:relative;width:380px; height:70px; margin-left:190px; margin-top:4px; border:none; outline:none;background-color:transparent; font-size:30px"  textmode = "MultiLine"  Maxlength = "200" runat="server">               </asp:TextBox>
                <asp:TextBox ID="TextBoxJoblog8" style="text-align:left;float:left;position:relative;width:380px;  height:70px; margin-left:190px;margin-top:3px; border:none;outline:none; background-color:transparent; font-size:30px;" textmode = "MultiLine"  Maxlength = "200" runat="server" >              </asp:TextBox>
                
        </div>
        <div style=" width:600px; height:270px; float:right; background-image:url(pic/Memo.png); margin-top:0px">
                <asp:TextBox ID="TextBoxMemo" style="width:560px; height:160px; margin-left:2px; margin-top:75px; border:none;outline:none; background-color:transparent; font-size:40px;" textmode="MultiLine" Maxlength = "500" runat="server" >              </asp:TextBox>
        </div>
        
        <div style=" width:600px; height:460px; float:right; background-image:url(pic/JobLog-3.png);  margin-top:-20px">
        
                
                <asp:TextBox ID ="TextBoxId1" style="text-align:center;float:left; width:120px;height:40px; margin-left:232px; margin-top:34px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server" >      </asp:TextBox>
                <asp:TextBox ID="TextBoxName1" style="text-align:center; float:left;width:140px;height:40px; margin-left:100px; margin-top:34px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server" >某某某</asp:TextBox>
               
                <asp:TextBox ID ="TextBoxId2" style="text-align:center; float:left;width:120px;height:40px; margin-left:232px; margin-top:17px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server" >      </asp:TextBox>
                <asp:TextBox ID="TextBoxName2" style="text-align:center; float:left;width:140px; height:40px; margin-left:100px; margin-top:17px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server">     </asp:TextBox>
                
                <asp:TextBox ID ="TextBoxId3" style="text-align:center; float:left;width:120px;height:40px; margin-left:232px; margin-top:18px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server" >      </asp:TextBox>
                <asp:TextBox ID="TextBoxName3" style="text-align:center; float:left;width:140px; height:40px; margin-left:100px; margin-top:18px; border:none;outline:none; background-color:transparent;color:Blue; font-size:32px"  runat="server">    </asp:TextBox>
                
                <asp:TextBox ID ="TextBoxID4" style="text-align:center; float:left;width:120px;height:40px; margin-left:232px; margin-top:30px; border:none;outline:none; background-color:transparent;font-size:32px"  runat="server" >      </asp:TextBox>
                <asp:TextBox ID="TextBoxName4" style="text-align:center;float:left; width:140px; height:40px;margin-top:30px;margin-left:100px; border:none; outline:none; background-color:transparent; font-size:32px"  runat="server">    </asp:TextBox>
                 
                 
                <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged ="DropDownList5_SelectedIndexChanged" style = "text-align:center; float:left;font-size:32px;margin-left:225px;margin-top:18px;border:none;outline:none;background-color:#E4E4E4;"
                    DataSourceID="SqlDataSource5" DataTextField="emp_No" DataValueField="emp_No">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                    
                    
                    
                    
                    
                    SelectCommand="SELECT [emp_No] FROM [employee_info] WHERE ((emp_Register_State = 'true' ) and( (emp_limited = '33' ) OR (emp_Name =' ')))">
                </asp:SqlDataSource>
                
                <div style=" width:120px; height:40px; margin-left:445px; margin-top:-38px; ">    
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode = "Always" >
                    <ContentTemplate>
                        <asp:TextBox ID="TextBoxName5" style="text-align:center;float:left; width:140px; height:40px;margin-top:18px; margin-left:10px;border:none; background-color:transparent; font-size:32px"  runat="server">    </asp:TextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>    
                </div>
                <asp:DropDownList ID="DropDownList6" runat="server" OnSelectedIndexChanged ="DropDownList6_SelectedIndexChanged"  style = "text-align:center; float:left;font-size:32px;margin-left:225px;margin-top:18px;border:none;outline:none;background-color:#E4E4E4;"
                    DataSourceID="SqlDataSource6" DataTextField="emp_No" DataValueField="emp_No">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:suidaozhaomingConnectionString3 %>" 
                    
                    
                    
                    
                    SelectCommand="SELECT [emp_No] FROM [employee_info] WHERE( (emp_Register_State = 'true' ) and( (emp_Limited = '33') OR (emp_Name = ' ' )))">
                </asp:SqlDataSource>
                   <div style=" width:120px; height:40px; margin-left:445px; margin-top:-38px; ">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode = "Always" >
                         <ContentTemplate>
                            <asp:TextBox ID="TextBoxName6" style="text-align:center;float:left; width:140px; height:40px;margin-top:18px;margin-left:10px; border:none; background-color:transparent; font-size:32px" runat="server">       </asp:TextBox>
                        </ContentTemplate>                        
                </asp:UpdatePanel>      
                </div>
                <asp:TextBox  style="text-align:center; width:170px; height:40px; margin-left:220px; margin-top:34px; border:none; background-color:transparent; font-size:28px" Maxlength = "200" runat="server"></asp:TextBox>
                <asp:ImageButton ID = "ButtonConfirm" onclick = "Confirm_Click"  ImageUrl="~/pic/Confirm-1.png" runat = "server" onmouseout="changeback1(this)" onmouseover="changeImg1(this)" style ="text-align:center;float:none; width:160px; height:70px; margin-top:25px; margin-left:-250px; border:none; background-color:transparent" />
                <asp:ImageButton ID = "ButtonSave" onclick = "Save_Click"  ImageUrl="~/pic/Confirm-2.png" runat = "server" onmouseout="changeback2(this)" onmouseover="changeImg2(this)" style ="text-align:center;float:none;width:160px; height:70px; margin-top:25px; margin-left:100px; border:none;background-color:transparent" />
                
        </div>
        
        <div style="text-align:center;float:left; width:1200px; height:20px; ">

        </div>
        <div style="text-align:center;float:inherit; width:1200px; height:80px; ">
            <img src="pic/logo2.png";alt="" /> 
        </div>
    </div>
    </div>
    </form>
</body>
</html>
