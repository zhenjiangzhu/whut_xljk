<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageNotHandled.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.message.messageNotHandled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="5px"
            Title="Panel" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
        <f:Grid ID="Grid1" Title="表格"  EnableCollapse="true" PageSize="5" ShowBorder="true" ShowHeader="true"
            AllowPaging="true" runat="server" EnableCheckBoxSelect="True" Width="850px" Height="350px"
            DataKeyNames="Id,Name" OnPageIndexChange="Grid1_PageIndexChange" EmptyText="没有数据！">
            <Columns>
                <f:RowNumberField />
                <f:BoundField TextAlign="Center" Width="100px" DataField="NickName" HeaderText="昵称" DataFormatString="{0}" />
                <f:BoundField TextAlign="Center" Width="100px" DataField="Grade" HeaderText="年级" />
                <f:BoundField TextAlign="Center" Width="100px" DataField="Sex" HeaderText="性别" />
                <f:BoundField Width="150px" DataField="QuestionTime" HeaderText="提问时间" />
                <%--<f:CheckBoxField Width="80px" RenderAsStaticField="true" DataField="Status" HeaderText="是否同意展示" />--%>
                <f:BoundField Width="400px" DataField="BriefQuestion" HeaderText="问题简介" />
                
                <f:WindowField TextAlign="Center" Width="80px" WindowID="Window1" Icon="Pencil"
                            ToolTip="编辑" DataIFrameUrlFields="Id,Name" DataIFrameUrlFormatString="../message/messageReply.aspx?id={0}&name={1}"
                            Title="编辑" IFrameUrl="~/alert.aspx" />
                <f:LinkButtonField TextAlign="Center" ConfirmText="删除选中行？" Icon="Delete" ConfirmTarget="Top"
                ColumnID="lbf_delete" HeaderText="删除" Width="60px" CommandName="delete" />
            </Columns>
        </f:Grid>
                </Items>
        </f:Panel>
    </form>
    <f:Window ID="Window1" Title="弹出窗体" Hidden="true" EnableIFrame="true"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
        IsModal="true" Width="850px" Height="550px"></f:Window>
</body>
</html>
