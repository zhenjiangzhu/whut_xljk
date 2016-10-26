<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileDetail.aspx.cs" Inherits="EmptyProjectNet45_FineUI.fileDetail" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中心动态详情页</title>
    <link href="css/common/common.css" rel="stylesheet" type="text/css" />
    <link href="css/common/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/common/content.css" rel="stylesheet" type="text/css" />

</head>

<body>
 <!--#include file="head.html"--> 
    <!--主体部分-->
    <div class="main">
        <div class="content" id="content" style="width: 74vw;">
            <!--内容-->
            <div class="content_nav">
                <span class="here">当前位置:</span>
                <a href="index.aspx" style="font-size:16px"><span>首页</span></a>
                <span>></span>
                <span>下载中心</span>
            </div>
            <hr />
            <!--动态标题，需要更换-->
            <h3><%=model.FileSummary%></h3>
            <!--动态上传日期，来源，作者，阅读量，需要更换-->

            <p class="detail">
                <img src="images/content_time_icon.png" />
                <span>发布时间：<%=model.FileTime%>
                    <img src="images/content_from_icon.png" />
                    <span>来源：<%=model.FileSector %></span>
            </p>

            <div class="text">
                <%=model.FileName %>
            </div>

            <div class="download">
                    <span>附件下载：</span>
                    <a href="<%=GetFilePath(model.FilePath) %>" target="_blank"><%=model.FileName%></a>
            </div>

            <!--上下篇切换-->
            <div class="content_other">
                <span  style="float: left; margin-left: -13vw;" >上一篇：<a href="<%=lastFileHref %>"><%=lastFileTitle %></a></span>
                <span  style="float: right; margin-left: -13vw;" >下一篇：<a href="<%=nextFileHref %>"><%=nextFileTitle %></a></span>
            </div>
        </div>
    </div>

    <!--底部部分 各个页面通用*-->
    <div class="footer" id="footer">
    </div>


</body>
</html>

