<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileList.aspx.cs" Inherits="EmptyProjectNet45_FineUI.fileList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中心动态列表页</title>
    <link href="css/common/common.css" rel="stylesheet" type="text/css" />
    <link href="css/common/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/common/list.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
</head>

<body>

 <!--#include file="head.html"--> 


    <!--主体部分-->
    <div class="main">
        <div class="list">
            <!--列表-->
            <div class="list_title">
                <img src="images/downTittle.png" />
            </div>
            <hr />
            <ul class="list_namelist">
                <%=ListPage%>
            </ul>
            <!--页面切换-->
            <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
            <!--页面切换-->
        </div>
        <!--首页轮播图右侧的三个按钮 各个页面通用-->
        <div class="button">
            <a>
                <img src="images/button_1.png"></a>
            <a>
                <img src="images/button_2.png"></a>
            <a>
                <img src="images/button_3.png"></a>
        </div>

    </div>
    <!--底部部分 各个页面通用*-->
    <div class="footer">
    </div>
</body>
</html>