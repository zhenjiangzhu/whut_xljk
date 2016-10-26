<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageReply.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.message.messageReply" Async="true" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        
                        <f:Button ID="btnSaveRefresh" Text="提交并回复邮件" runat="server" Icon="SystemSave"
                            OnClick="btnSaveRefresh_Click">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
 
                        <f:ToolbarText ID="ToolbarText1" Text="提示一" runat="server">
                        </f:ToolbarText>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText2" Text="提示二&nbsp;&nbsp;" runat="server">
                        </f:ToolbarText>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txb_NickName" runat="server" Label="昵称"></f:TextBox>
                        <f:TextBox ID="txb_Sex" runat="server" Label="性别"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txb_TeacherName" runat="server" Label="指定老师"></f:TextBox>
                        <f:TextBox ID="txb_Email" runat="server" Label="用户邮箱"></f:TextBox>
                        
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txb_ReplyEmailAddress" runat="server" Label="回复所用邮箱" ></f:TextBox>
                        <f:TextBox ID="txb_ReplyEmailPwd" runat="server" label="回复所用邮箱密码"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea ID="txa_BriefQuestion" Label="问题简述" runat="server" />
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea ID="txa_DetailQuestion" Height="80px" Label="描述" runat="server"/>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor ID="HtmlEditor1" Label="回复" Height="150px" runat="server">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
  
            </Rows>
        </f:Form>
    </form>
</body>
</html>
