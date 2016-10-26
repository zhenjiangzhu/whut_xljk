<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imgChange.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.imgchange.imgChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #imgUpload {
            margin-left: 200px;
        }

        .imgTitle {
            font-size: 18px;
            width: 570px;
            text-align: center;
        }

        .imgInfoContain {
            width: 570px;
            height: 220px;
        }

            .imgInfoContain h1 {
                font-size: 16px;
            }

            .imgInfoContain ul {
                width: 240px;
                float: left;
                margin-left: 20px;
                margin-top: 2px;
            }

            .imgInfoContain li {
                margin-bottom: 6px;
            }

            .imgInfoContain div {
                width: 300px;
                float: right;
                border: 1px solid #808080;
            }

            .imgInfoContain .btn_change {
                width: 200px;
                height: 35px;
                background-color: #318df3;
                font-size: 16px;
                -moz-border-radius: 6px;
                -webkit-border-radius: 6px;
                color: #fff;
            }

                .imgInfoContain .btn_change:visited {
                    background-color: #2981e4;
                    transition: all ease-in-out 0.5s;
                    -moz-box-shadow: 0 1px 3px rgba(0,0,0,0.6);
                    -webkit-box-shadow: 0 1px 3px rgba(0,0,0,0.6);
                    text-shadow: 0 -1px 1px rgba(0,0,0,0.25);
                    border-bottom: 1px solid rgba(0,0,0,0.25);
                    position: relative;
                }

                .imgInfoContain .btn_change:hover {
                    background-color: #2575cf;
                }

        .btn_sub {
            margin-top: 10px;
            width: 300px;
            height: 35px;
            font-size: 15px;
        }

        h1 {
            display: block;
            font-size: 2em;
            -webkit-margin-before: 0em;
            -webkit-margin-after: 0em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            font-weight: bold;
        }
                input[type=text] {
            width: 200px;
            height: 22px;
            border: 1px solid #317eb4;
            margin: 6px 10px;
        }
                select {
                        border: 1px solid #317eb4;
    margin-left: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">



        <p>
            图片描述文本：
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            图片链接地址：
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_Show" runat="server" ForeColor="Red" Text="(超链接不用写http://头)"></asp:Label>
        </p>
        <p>
            图片插入位置：<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
            </asp:DropDownList>
        </p>

        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="(您上传的图片分辨率最好为990*340)"></asp:Label>

        <p>选择图片路径：
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" /></p>
        <h3 id="imgTitle">缩略图预览效果如下(鼠标悬浮查看详情)</h3>
        <div class="imgContainer">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/banner/back1.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/banner/back2.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/banner/back3.jpg" Width="198" Height="68" /></td>
                    <td>
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/banner/back4.jpg" Width="198" Height="68" /></td>
                </tr>
                <tr>
                    <td>序号1</td>
                    <td>序号2</td>
                    <td>序号3</td>
                    <td>序号4</td>
                </tr>
            </table>
            <div>
                <asp:Label ID="Label2" runat="server" Text="(*如果无法查看预览效果，请点击刷新！)" ForeColor="Red"></asp:Label>
            </div>
        </div>

    </form>
</body>
</html>
