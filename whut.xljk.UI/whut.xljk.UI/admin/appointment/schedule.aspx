<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.appointment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Window ID="Window1" runat="server" Title="修改预约时间表" IsModal="true" EnableClose="false" EnableResize="true"
            Width="900px" MinHeight="350px" Layout="Fit">
            <Items>
                <f:Form ID="Form2" Width="650px" LabelAlign="Right" MessageTarget="Qtip"
                    BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server" AutoScroll="true">
                    <Items>
                        <f:GroupPanel Layout="Anchor" Title="选择时间" runat="server">
                            <Items>
                                <f:Panel ID="Panel2" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        
                                        <f:DropDownList ID="place" Label="地点" Width="180px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="东院" Value="11" />
                                            <f:ListItem Text="南湖" Value="12" />
                                            <f:ListItem Text="升升" Value="13" />
                                            <f:ListItem Text="学海" Value="14" />
                                            <f:ListItem Text="余区" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="week" Label="星期" Width="180px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="星期一" Value="1" />
                                            <f:ListItem Text="星期二" Value="2" />
                                            <f:ListItem Text="星期三" Value="3" />
                                            <f:ListItem Text="星期四" Value="4" />
                                            <f:ListItem Text="星期五" Value="5" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="time" Label="时间段" Width="220px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="第一时间段" Value="1" />
                                            <f:ListItem Text="第二时间段" Value="2" />
                                            <f:ListItem Text="第三时间段" Value="3" />
                                            <f:ListItem Text="第四时间段" Value="4" />
                                            <f:ListItem Text="第五时间段" Value="5" />
                                        </f:DropDownList>
                                        <f:Button ID="choose_time" Text="确认" runat="server" OnClick="choose_time_Click"
                                            CssClass="marginr" />
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="当前时段信息" runat="server">
                            <Items>
                                <f:Panel ID="Panel4" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="teacher" Label="值班老师"  BoxFlex="1" Required="true"  LabelWidth="40px" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:Label runat="server"></f:Label>
                                        <f:TextBox ID="work_time" Label="值班时间" BoxFlex="1" Width="50px" LabelWidth="40px"  ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:Label runat="server" BoxFlex="1"></f:Label>
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel5" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:DropDownList ID="state" Label="时间段" Width="220px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="未预约" Value="未预约" />
                                            <f:ListItem Text="已预约" Value="已预约" />
                                        </f:DropDownList>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                            <Items>
                                <f:Button ID="submit" Text="确认更改" ValidateForms="Form1" ValidateMessageBox="false" OnClick="submit_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Form>
            </Items>
        </f:Window>
    </form>
</body>
</html>
