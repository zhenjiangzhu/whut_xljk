<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="articleDetail.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.article.articleDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    <style>
        .stu_btn {
            background: #82b440;
            width: auto;
            height: auto;
            padding: 5px 30px;
            color: #fff;
            font-size: 14px;
            border-radius: 6px;
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            -o-border-radius: 6px;
            cursor: pointer;
        }

        #form1 p {
            margin-bottom: 15px;
        }

        #form1 input {
            width: 200px;
            height: 22px;
            border: 1px solid #317eb4;
            margin: 6px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                文章编号：
                <asp:Label ID="txtid" runat="server"></asp:Label>
            </p>
            <p>
                文章作者：
                <asp:Label ID="writer" runat="server"></asp:Label>
            </p>
            <p>
                文章来源：
                <asp:Label ID="resourse" runat="server"></asp:Label>
            </p>
            <p>
                发布时间:
                <asp:Label ID="time" runat="server"></asp:Label>
            </p>
            <p>
                文章标题：
                <asp:TextBox ID="title" runat="server"></asp:TextBox>
            </p>
            <p>
                文章类别：
                <asp:DropDownList ID="category" runat="server">
                    <asp:ListItem Value="1" Text="中心概况" Enabled="false"></asp:ListItem>
                    <asp:ListItem Value="2" Text="中心动态"></asp:ListItem>
                    <asp:ListItem Value="3" Text="心协动态"></asp:ListItem>
                    <asp:ListItem Value="4" Text="咨询师简介"></asp:ListItem>
                    <asp:ListItem Value="5" Text="心灵驿站"></asp:ListItem>
                </asp:DropDownList>
            </p>

            <p>
                文章内容:
                <asp:TextBox ID="txtcontent" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btn" runat="server" Text="修改" OnClick="btn_Click" CssClass="stu_btn" />
            </p>
        </div>
    </form>

    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#txtcontent', {
                allowFileManager: false,
                allowImageRemote: false,
                resizeType: 1,
                allowPreviewEmoticons: true,
                allowImageUpload: true,
                uploadJson: 'ArticleKindEditorProcess.ashx',
                items: [
                    'preview', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'fullscreen']
            });
        });
    </script>
</body>
</html>
