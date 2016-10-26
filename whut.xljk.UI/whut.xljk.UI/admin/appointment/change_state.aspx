<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change_state.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.appointment.change_state" %>

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
                                        <f:Label runat="server" ShowRedStar="true" Label="请选择："></f:Label>
                                        <f:DropDownList Label="地点" Width="180px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="东院" Value="11" />
                                            <f:ListItem Text="南湖" Value="12" />
                                            <f:ListItem Text="升升" Value="13" />
                                            <f:ListItem Text="学海" Value="14" />
                                            <f:ListItem Text="余区" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList Label="星期" Width="180px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="星期一" Value="1" />
                                            <f:ListItem Text="星期二" Value="2" />
                                            <f:ListItem Text="星期三" Value="3" />
                                            <f:ListItem Text="星期四" Value="4" />
                                            <f:ListItem Text="星期五" Value="5" />
                                        </f:DropDownList>
                                        <f:DropDownList Label="时间段" Width="180px" CssClass="marginr" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                            <f:ListItem Text="第一时间段" Value="1" />
                                            <f:ListItem Text="第二时间段" Value="2" />
                                            <f:ListItem Text="第三时间段" Value="3" />
                                            <f:ListItem Text="第四时间段" Value="4" />
                                            <f:ListItem Text="第五时间段" Value="5" />
                                        </f:DropDownList>
                                        <f:TextBox ID="TextBox4" ShowLabel="false" Required="true" ShowRedStar="true" BoxFlex="3" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel1" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="TextBox1" Required="true" ShowRedStar="true" Label="电子邮箱" RegexPattern="EMAIL"
                                            RegexMessage="请输入有效的邮箱地址！" BoxFlex="1" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="TextBox6" Label="电话号码" Width="200px" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="联系人地址" runat="server">
                            <Items>
                                <f:TextBox ID="TextBox7" Label="详细地址" Required="true" ShowRedStar="true" runat="server">
                                </f:TextBox>
                                <f:Panel ID="Panel4" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="TextBox9" Label="省" BoxFlex="1" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="TextBox5" Label="市" BoxFlex="1" LabelWidth="50px" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="TextBox8" Label="邮政编码" Width="200px" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                        <f:GroupPanel ID="GroupPanel2" Layout="Anchor" Title="账单地址" runat="server">
                            <Items>
                                <f:CheckBox runat="server" Checked="true" ID="cbxSameAsContactAddress" AutoPostBack="true" OnCheckedChanged="cbxSameAsContactAddress_CheckedChanged" Text="和联系人地址相同"></f:CheckBox>
                                <f:TextBox ID="tbxBillingAddress" Enabled="false" Label="详细地址" Required="true" ShowRedStar="true" runat="server">
                                </f:TextBox>
                                <f:Panel ID="Panel3" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="tbxBillingProvince" Enabled="false" Label="省" BoxFlex="1" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="tbxBillingCity" Enabled="false" Label="市" BoxFlex="1" LabelWidth="50px" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="tbxBillingPostCode" Enabled="false" Label="邮政编码" Width="200px" LabelWidth="80px" Required="true" ShowRedStar="true" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>

                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                            <Items>
                                <f:Button ID="Button1" Text="提交账单" ValidateForms="Form1" ValidateMessageBox="false" runat="server">
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
