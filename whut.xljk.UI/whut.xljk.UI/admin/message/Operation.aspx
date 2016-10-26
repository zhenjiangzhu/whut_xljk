<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operation.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.message.Operation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveContinue" Text="提交" runat="server" Icon="SystemSave"
                            OnClick="btnSaveContinue_Click">
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
            </toolbars>
            <rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txb_NickName" runat="server" Label="昵称"></f:TextBox>
                        <f:TextBox ID="txb_Sex" runat="server" Label="性别"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList ID="ddl_Categpry" Label="选择问题分类" runat="server"></f:DropDownList>
                        <f:DropDownList ID="ddl_Status" Label="是否移入精选" runat="server"></f:DropDownList>
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
                        <f:HtmlEditor ID="HtmlEditor1" Label="修改回复内容" Height="150px" runat="server">
                        </f:HtmlEditor>
                    </Items>
                </f:FormRow>
                
            </rows>
        </f:Form>
    </form>
</body>
</html>
