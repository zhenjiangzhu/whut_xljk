<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appointment.aspx.cs" Inherits="EmptyProjectNet45_FineUI.apppointment" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
    </title>
    <link href="css/common/common.css" rel="stylesheet" type="text/css" />
<link href="css/common/reset.css" rel="stylesheet" type="text/css" />
<link href="css/p6_appointment.css" rel="stylesheet" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
    <img src="images/tittle.png">
    <div class="search"><!--搜索框*-->
        <img  src="images/searchBorder.png">
        <img class="searchicon" src="images/searchIcon.png">
        <img src="images/search00.png">
    </div>
</div>

<!--导航部分 各个页面通用*-->
<div class="nav">
	<ul>
         <li> <!--每个li把icons和链接放在一起 达到hover的时候能将效果覆盖到icon上-->
             <img  src="images/navHomeIcon.png"><a href="index.html">首页</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p1_centersurvey.html">中心概况</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p2_center_list.html">中心动态</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p3_association_list.html">心协动态</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p4_consultor.html">咨询师简介</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p5_qaonline.html">在线问答</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p6_appointment.html">咨询预约</a>
        </li>
        <li> 
             <img  src="images/navHomeIcon.png"><a href="p7_article_list.html">心灵驿站</a>
        </li>
         <li> 
             <img  src="images/navHomeIcon.png"><a href="p8_download.html">下载专区</a>
        </li>
    </ul>
</div>
<!--主体部分-->
<div class="main">
    <div class="appoint_content">
        <div class="appoint_title">
            <img src="images/appoint_title.png" />
        </div>
        <hr />
        <div class="appoint_detail">
            <div class="appoint_describe">
                <h3>咨询预约</h3>
                <p>你好，我校心理咨询服务仅对武汉理工大学在校师生免费开放，暂不提供对外服务。您可根据自己的空闲时间选择你想要预约的时间段和咨询师，之间点击相关时段并填写相关信息后，即可预约。每人一周只能预约咨询一次，一次60分钟。</p>
                <p>蓝色时间段代表该时段可以预约，浅红色代表该时段已经被预约！</p>
                <p>将鼠标指针放到预约表中咨询师的姓名处，即可查看该咨询师的简介。</p>
            </div>
            <div class="appoint_time">
                <table class="place" id="place">
                    <tr class="campus">
                        <td colspan="2" onmouseover="change(this,'maqv')">马区</td>
                        <td colspan="2" onmouseover="change(this,'yuqv')">余区</td>
                    </tr>
                    <tr>
                        <td style="color:#F46BF9" onmouseover="change(this,'dongyuan')">东院咨询室</td>
                        <td style="color:#49D7A5" onmouseover="change(this,'nanhu')">南湖咨询室</td>
                        <td style="color:#F9855D" onmouseover="change(this,'shengsheng')">升升咨询室</td>
                        <td style="color:#746BF9" onmouseover="change(this,'xuehai')">学海咨询室</td>
                    </tr>
                </table>
                <table class="day" id="day">
                    <tr>
                        <td id="">
                            <label>星期一</label>
                        	
                            <br />
                            <!--日期-->
                            <label>2016.6.16</label>
                        </td>
                        <td>
                        	星期二
                            <br />
                            2016.6.17
                        </td>
                        <td>
                        	星期三
                            <br />
                            2016.6.18
                        </td>
                        <td>
                        	星期四
                            <br />
                            2016.6.19
                        </td>
                        <td>
                        	星期五
                            <br />
                            2016.6.20
                        </td>
                    </tr>
                      <tr>
                        <td>
                        	星期一
                            <br />
                            <!--日期-->
                            2016.6.16
                        </td>
                        <td>
                        	星期二
                            <br />
                            2016.6.17
                        </td>
                        <td>
                        	星期三
                            <br />
                            2016.6.18
                        </td>
                        <td>
                        	星期四
                            <br />
                            2016.6.19
                        </td>
                        <td>
                        	星期五
                            <br />
                            2016.6.20
                        </td>
                    </tr>

                </table>
                <table class="time dongyuan" id="dongyuan">
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[0].time %>
                            <br />
                             <%=dongyuan[0].t_name %>
                            <p hidden="hidden"><%=dongyuan[0].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[6].time %>
                            <br />
                             <%=dongyuan[6].t_name %>
                              <p hidden="hidden"><%=dongyuan[6].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[12].time %>
                            <br />
                             <%=dongyuan[12].t_name %>
                            <p hidden="hidden"><%=dongyuan[12].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[18].time %>
                            <br />
                             <%=dongyuan[18].t_name %>
                            <p hidden="hidden"><%=dongyuan[18].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[24].time %>
                            <br />
                             <%=dongyuan[24].t_name %>
                            <p hidden="hidden"><%=dongyuan[24].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[1].time %>
                            <br />
                             <%=dongyuan[1].t_name %>
                            <p hidden="hidden"><%=dongyuan[1].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[7].time %>
                            <br />
                             <%=dongyuan[7].t_name %>
                            <p hidden="hidden"><%=dongyuan[7].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[13].time %>
                            <br />
                             <%=dongyuan[13].t_name %>
                            <p hidden="hidden"><%=dongyuan[13].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[19].time %>
                            <br />
                             <%=dongyuan[19].t_name %>
                            <p hidden="hidden"><%=dongyuan[19].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[25].time %>
                            <br />
                             <%=dongyuan[25].t_name %>
                            <p hidden="hidden"><%=dongyuan[25].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[2].time %>
                            <br />
                             <%=dongyuan[2].t_name %>
                            <p hidden="hidden"><%=dongyuan[2].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[8].time %>
                            <br />
                             <%=dongyuan[8].t_name %>
                            <p hidden="hidden"><%=dongyuan[8].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[14].time %>
                            <br />
                             <%=dongyuan[14].t_name %>
                            <p hidden="hidden"><%=dongyuan[14].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[20].time %>
                            <br />
                             <%=dongyuan[20].t_name %>
                            <p hidden="hidden"><%=dongyuan[20].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[26].time %>
                            <br />
                             <%=dongyuan[26].t_name %>
                            <p hidden="hidden"><%=dongyuan[26].state %></p>
                        </td>
                    </tr>
                    <tr>
                        
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[3].time %>
                            <br />
                             <%=dongyuan[3].t_name %>
                            <p hidden="hidden"><%=dongyuan[3].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[9].time %>
                            <br />
                             <%=dongyuan[9].t_name %>
                            <p hidden="hidden"><%=dongyuan[9].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[15].time %>
                            <br />
                             <%=dongyuan[15].t_name %>
                            <p hidden="hidden"><%=dongyuan[15].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[21].time %>
                            <br />
                             <%=dongyuan[21].t_name %>
                            <p hidden="hidden"><%=dongyuan[21].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[27].time %>
                            <br />
                             <%=dongyuan[27].t_name %>
                            <p hidden="hidden"><%=dongyuan[27].state %></p>
                        </td>
                    </tr>
                    <tr>
                          <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[4].time %>
                            <br />
                             <%=dongyuan[4].t_name %>
                              <p hidden="hidden"><%=dongyuan[4].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[10].time %>
                            <br />
                             <%=dongyuan[10].t_name %>
                            <p hidden="hidden"><%=dongyuan[10].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[16].time %>
                            <br />
                             <%=dongyuan[16].t_name %>
                            <p hidden="hidden"><%=dongyuan[16].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[22].time %>
                            <br />
                             <%=dongyuan[22].t_name %>
                            <p hidden="hidden"><%=dongyuan[22].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[28].time %>
                            <br />
                             <%=dongyuan[28].t_name %>
                            <p hidden="hidden"><%=dongyuan[28].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=dongyuan[5].time %>
                            <br />
                             <%=dongyuan[5].t_name %>
                            <p hidden="hidden"><%=dongyuan[5].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[11].time %>
                            <br />
                             <%=dongyuan[11].t_name %>
                            <p hidden="hidden"><%=dongyuan[11].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[17].time %>
                            <br />
                             <%=dongyuan[17].t_name %>
                            <p hidden="hidden"><%=dongyuan[17].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[23].time %>
                            <br />
                             <%=dongyuan[23].t_name %>
                            <p hidden="hidden"><%=dongyuan[23].state %></p>
                        </td>
                        <td>
                            <%=dongyuan[29].time %>
                            <br />
                             <%=dongyuan[29].t_name %>
                            <p hidden="hidden"><%=dongyuan[29].state %></p>
                        </td>
                    </tr>
                </table>
                <table class="time nanhu" id="nanhu">
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[0].time %>
                            <br />
                             <%=nanhu[0].t_name %>
                            <p hidden="hidden"><%=nanhu[0].state %></p>
                        </td>
                        <td>
                            <%=nanhu[6].time %>
                            <br />
                             <%=nanhu[6].t_name %>
                            <p hidden="hidden"><%=nanhu[6].state %></p>
                        </td>
                        <td>
                            <%=nanhu[12].time %>
                            <br />
                             <%=nanhu[12].t_name %>
                            <p hidden="hidden"><%=nanhu[12].state %></p>
                        </td>
                        <td>
                            <%=nanhu[18].time %>
                            <br />
                             <%=nanhu[18].t_name %>
                            <p hidden="hidden"><%=nanhu[18].state %></p>
                        </td>
                        <td>
                            <%=nanhu[24].time %>
                            <br />
                             <%=nanhu[24].t_name %>
                            <p hidden="hidden"><%=nanhu[24].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[1].time %>
                            <br />
                             <%=nanhu[1].t_name %>
                            <p hidden="hidden"><%=nanhu[1].state %></p>
                        </td>
                        <td>
                            <%=nanhu[7].time %>
                            <br />
                             <%=nanhu[7].t_name %>
                            <p hidden="hidden"><%=nanhu[7].state %></p>
                        </td>
                        <td>
                            <%=nanhu[13].time %>
                            <br />
                             <%=nanhu[13].t_name %>
                            <p hidden="hidden"><%=nanhu[13].state %></p>
                        </td>
                        <td>
                            <%=nanhu[19].time %>
                            <br />
                             <%=nanhu[19].t_name %>
                            <p hidden="hidden"><%=nanhu[19].state %></p>
                        </td>
                        <td>
                            <%=nanhu[25].time %>
                            <br />
                             <%=nanhu[25].t_name %>
                            <p hidden="hidden"><%=nanhu[25].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[2].time %>
                            <br />
                             <%=nanhu[2].t_name %>
                            <p hidden="hidden"><%=nanhu[2].state %></p>
                        </td>
                        <td>
                            <%=nanhu[8].time %>
                            <br />
                             <%=nanhu[8].t_name %>
                            <p hidden="hidden"><%=nanhu[8].state %></p>
                        </td>
                        <td>
                            <%=nanhu[14].time %>
                            <br />
                             <%=nanhu[14].t_name %>
                            <p hidden="hidden"><%=nanhu[14].state %></p>
                        </td>
                        <td>
                            <%=nanhu[20].time %>
                            <br />
                             <%=nanhu[20].t_name %>
                            <p hidden="hidden"><%=nanhu[20].state %></p>
                        </td>
                        <td>
                            <%=nanhu[26].time %>
                            <br />
                             <%=nanhu[26].t_name %>
                            <p hidden="hidden"><%=nanhu[26].state %></p>
                        </td>
                    </tr>
                    <tr>

                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[3].time %>
                            <br />
                             <%=nanhu[3].t_name %>
                            <p hidden="hidden"><%=nanhu[3].state %></p>
                        </td>
                        <td>
                            <%=nanhu[9].time %>
                            <br />
                             <%=nanhu[9].t_name %>
                            <p hidden="hidden"><%=nanhu[9].state %></p>
                        </td>
                        <td>
                            <%=nanhu[15].time %>
                            <br />
                             <%=nanhu[15].t_name %>
                            <p hidden="hidden"><%=nanhu[15].state %></p>
                        </td>
                        <td>
                            <%=nanhu[21].time %>
                            <br />
                             <%=nanhu[21].t_name %>
                            <p hidden="hidden"><%=nanhu[21].state %></p>
                        </td>
                        <td >
                            <%=nanhu[27].time %>
                            <br />
                             <%=nanhu[27].t_name %>
                            <p hidden="hidden"><%=nanhu[27].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[4].time %>
                            <br />
                             <%=nanhu[4].t_name %>
                            <p hidden="hidden"><%=nanhu[4].state %></p>
                        </td>
                        <td>
                            <%=nanhu[10].time %>
                            <br />
                             <%=nanhu[10].t_name %>
                            <p hidden="hidden"><%=nanhu[10].state %></p>
                        </td>
                        <td>
                            <%=nanhu[16].time %>
                            <br />
                             <%=nanhu[16].t_name %>
                            <p hidden="hidden"><%=nanhu[16].state %></p>
                        </td>
                        <td>
                            <%=nanhu[22].time %>
                            <br />
                             <%=nanhu[22].t_name %>
                            <p hidden="hidden"><%=nanhu[22].state %></p>
                        </td>
                        <td>
                            <%=nanhu[28].time %>
                            <br />
                             <%=nanhu[28].t_name %>
                            <p hidden="hidden"><%=nanhu[28].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td  style="border-left:0.2vw solid #E4E4E4">
                            <%=nanhu[5].time %>
                            <br />
                             <%=nanhu[5].t_name %>
                            <p hidden="hidden"><%=nanhu[5].state %></p>
                        </td>
                        <td>
                            <%=nanhu[11].time %>
                            <br />
                             <%=nanhu[11].t_name %>
                            <p hidden="hidden"><%=nanhu[11].state %></p>
                        </td>
                        <td>
                            <%=nanhu[17].time %>
                            <br />
                             <%=nanhu[17].t_name %>
                            <p hidden="hidden"><%=nanhu[17].state %></p>
                        </td>
                        <td>
                            <%=nanhu[23].time %>
                            <br />
                             <%=nanhu[23].t_name %>
                            <p hidden="hidden"><%=nanhu[23].state %></p>
                        </td>
                        <td>
                            <%=nanhu[29].time %>
                            <br />
                             <%=nanhu[29].t_name %>
                            <p hidden="hidden"><%=nanhu[29].state %></p>
                        </td>
                    </tr>
                </table>
                <table class="time shengsheng" id="shengsheng">
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[0].time %>
                            <br />
                             <%=shengsheng[0].t_name %>
                            <p hidden="hidden"><%=shengsheng[0].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[6].time %>
                            <br />
                             <%=shengsheng[6].t_name %>
                            <p hidden="hidden"><%=shengsheng[6].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[12].time %>
                            <br />
                             <%=shengsheng[12].t_name %>
                            <p hidden="hidden"><%=shengsheng[12].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[18].time %>
                            <br />
                             <%=shengsheng[18].t_name %>
                            <p hidden="hidden"><%=shengsheng[18].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[24].time %>
                            <br />
                             <%=shengsheng[24].t_name %>
                            <p hidden="hidden"><%=shengsheng[24].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[1].time %>
                            <br />
                             <%=shengsheng[1].t_name %>
                            <p hidden="hidden"><%=shengsheng[1].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[7].time %>
                            <br />
                             <%=shengsheng[7].t_name %>
                            <p hidden="hidden"><%=shengsheng[7].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[13].time %>
                            <br />
                             <%=shengsheng[13].t_name %>
                            <p hidden="hidden"><%=shengsheng[13].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[19].time %>
                            <br />
                             <%=shengsheng[19].t_name %>
                            <p hidden="hidden"><%=shengsheng[19].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[25].time %>
                            <br />
                             <%=shengsheng[25].t_name %>
                            <p hidden="hidden"><%=shengsheng[25].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[2].time %>
                            <br />
                             <%=shengsheng[2].t_name %>
                            <p hidden="hidden"><%=shengsheng[2].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[8].time %>
                            <br />
                             <%=shengsheng[8].t_name %>
                            <p hidden="hidden"><%=shengsheng[8].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[14].time %>
                            <br />
                             <%=shengsheng[14].t_name %>
                            <p hidden="hidden"><%=shengsheng[14].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[20].time %>
                            <br />
                             <%=shengsheng[20].t_name %>
                            <p hidden="hidden"><%=shengsheng[20].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[26].time %>
                            <br />
                             <%=shengsheng[26].t_name %>
                            <p hidden="hidden"><%=shengsheng[26].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[3].time %>
                            <br />
                             <%=shengsheng[3].t_name %>
                            <p hidden="hidden"><%=shengsheng[3].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[9].time %>
                            <br />
                             <%=shengsheng[9].t_name %>
                            <p hidden="hidden"><%=shengsheng[9].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[15].time %>
                            <br />
                             <%=shengsheng[15].t_name %>
                            <p hidden="hidden"><%=shengsheng[15].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[21].time %>
                            <br />
                             <%=shengsheng[21].t_name %>
                            <p hidden="hidden"><%=shengsheng[21].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[27].time %>
                            <br />
                             <%=shengsheng[27].t_name %>
                            <p hidden="hidden"><%=shengsheng[27].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[4].time %>
                            <br />
                             <%=shengsheng[4].t_name %>
                            <p hidden="hidden"><%=shengsheng[4].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[10].time %>
                            <br />
                             <%=shengsheng[10].t_name %>
                            <p hidden="hidden"><%=shengsheng[10].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[16].time %>
                            <br />
                             <%=shengsheng[16].t_name %>
                            <p hidden="hidden"><%=shengsheng[16].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[22].time %>
                            <br />
                             <%=shengsheng[22].t_name %>
                            <p hidden="hidden"><%=shengsheng[22].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[28].time %>
                            <br />
                             <%=shengsheng[28].t_name %>
                            <p hidden="hidden"><%=shengsheng[28].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=shengsheng[5].time %>
                            <br />
                             <%=shengsheng[5].t_name %>
                            <p hidden="hidden"><%=shengsheng[5].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[11].time %>
                            <br />
                             <%=shengsheng[11].t_name %>
                            <p hidden="hidden"><%=shengsheng[11].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[17].time %>
                            <br />
                             <%=shengsheng[17].t_name %>
                            <p hidden="hidden"><%=shengsheng[17].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[23].time %>
                            <br />
                             <%=shengsheng[23].t_name %>
                            <p hidden="hidden"><%=shengsheng[23].state %></p>
                        </td>
                        <td>
                            <%=shengsheng[29].time %>
                            <br />
                             <%=shengsheng[29].t_name %>
                            <p hidden="hidden"><%=shengsheng[29].state %></p>
                        </td>
                    </tr>
                </table>
                <table class="time xuehai" id="xuehai">
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[0].time %>
                            <br />
                             <%=xuehai[0].t_name %>
                            <p hidden="hidden"><%=xuehai[0].state %></p>
                        </td>
                        <td>
                            <%=xuehai[6].time %>
                            <br />
                             <%=xuehai[6].t_name %>
                            <p hidden="hidden"><%=xuehai[6].state %></p>
                        </td>
                        <td>
                            <%=xuehai[12].time %>
                            <br />
                             <%=xuehai[12].t_name %>
                            <p hidden="hidden"><%=xuehai[12].state %></p>
                        </td>
                        <td>
                            <%=xuehai[18].time %>
                            <br />
                             <%=xuehai[18].t_name %>
                            <p hidden="hidden"><%=xuehai[18].state %></p>
                        </td>
                        <td>
                            <%=xuehai[24].time %>
                            <br />
                             <%=xuehai[24].t_name %>
                            <p hidden="hidden"><%=xuehai[24].state %></p>
                        </td>
                    </tr>
                    <tr>
                       <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[1].time %>
                            <br />
                             <%=xuehai[1].t_name %>
                            <p hidden="hidden"><%=xuehai[1].state %></p>
                        </td>
                        <td>
                            <%=xuehai[7].time %>
                            <br />
                             <%=xuehai[7].t_name %>
                            <p hidden="hidden"><%=xuehai[7].state %></p>
                        </td>
                        <td>
                            <%=xuehai[13].time %>
                            <br />
                             <%=xuehai[13].t_name %>
                            <p hidden="hidden"><%=xuehai[13].state %></p>
                        </td>
                        <td>
                            <%=xuehai[19].time %>
                            <br />
                             <%=xuehai[19].t_name %>
                            <p hidden="hidden"><%=xuehai[19].state %></p>
                        </td>
                        <td>
                            <%=xuehai[25].time %>
                            <br />
                             <%=xuehai[25].t_name %>
                            <p hidden="hidden"><%=xuehai[25].state %></p>
                        </td>
                    </tr>
                    <tr>
                       <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[2].time %>
                            <br />
                             <%=xuehai[2].t_name %>
                            <p hidden="hidden"><%=xuehai[2].state %></p>
                        </td>
                        <td>
                            <%=xuehai[8].time %>
                            <br />
                             <%=xuehai[8].t_name %>
                            <p hidden="hidden"><%=xuehai[8].state %></p>
                        </td>
                        <td>
                            <%=xuehai[14].time %>
                            <br />
                             <%=xuehai[14].t_name %>
                            <p hidden="hidden"><%=xuehai[14].state %></p>
                        </td>
                        <td>
                            <%=xuehai[20].time %>
                            <br />
                             <%=xuehai[20].t_name %>
                            <p hidden="hidden"><%=xuehai[20].state %></p>
                        </td>
                        <td>
                            <%=xuehai[26].time %>
                            <br />
                             <%=xuehai[26].t_name %>
                            <p hidden="hidden"><%=xuehai[26].state %></p>
                        </td>
                    </tr>
                    <tr>
                       <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[3].time %>
                            <br />
                             <%=xuehai[3].t_name %>
                            <p hidden="hidden"><%=xuehai[3].state %></p>
                        </td>
                        <td>
                            <%=xuehai[9].time %>
                            <br />
                             <%=xuehai[9].t_name %>
                            <p hidden="hidden"><%=xuehai[9].state %></p>
                        </td>
                        <td>
                            <%=xuehai[15].time %>
                            <br />
                             <%=xuehai[15].t_name %>
                            <p hidden="hidden"><%=xuehai[15].state %></p>
                        </td>
                        <td>
                            <%=xuehai[21].time %>
                            <br />
                             <%=xuehai[21].t_name %>
                            <p hidden="hidden"><%=xuehai[21].state %></p>
                        </td>
                        <td>
                            <%=xuehai[27].time %>
                            <br />
                             <%=xuehai[27].t_name %>
                            <p hidden="hidden"><%=xuehai[27].state %></p>
                        </td>
                    </tr>
                    <tr>
                       <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[4].time %>
                            <br />
                             <%=xuehai[4].t_name %>
                            <p hidden="hidden"><%=xuehai[4].state %></p>
                        </td>
                        <td>
                            <%=xuehai[10].time %>
                            <br />
                             <%=xuehai[10].t_name %>
                            <p hidden="hidden"><%=xuehai[10].state %></p>
                        </td>
                        <td>
                            <%=xuehai[16].time %>
                            <br />
                             <%=xuehai[16].t_name %>
                            <p hidden="hidden"><%=xuehai[16].state %></p>
                        </td>
                        <td>
                            <%=xuehai[22].time %>
                            <br />
                             <%=xuehai[22].t_name %>
                            <p hidden="hidden"><%=xuehai[22].state %></p>
                        </td>
                        <td>
                            <%=xuehai[28].time %>
                            <br />
                             <%=xuehai[28].t_name %>
                            <p hidden="hidden"><%=xuehai[28].state %></p>
                        </td>
                    </tr>
                    <tr>
                    <td style="border-left:0.2vw solid #E4E4E4">
                            <%=xuehai[5].time %>
                            <br />
                             <%=xuehai[5].t_name %>
                            <p hidden="hidden"><%=xuehai[5].state %></p>
                        </td>
                        <td>
                            <%=xuehai[11].time %>
                            <br />
                             <%=xuehai[11].t_name %>
                            <p hidden="hidden"><%=xuehai[11].state %></p>
                        </td>
                        <td>
                            <%=xuehai[17].time %>
                            <br />
                             <%=xuehai[17].t_name %>
                            <p hidden="hidden"><%=xuehai[17].state %></p>
                        </td>
                        <td>
                            <%=xuehai[23].time %>
                            <br />
                             <%=xuehai[23].t_name %>
                            <p hidden="hidden"><%=xuehai[23].state %></p>
                        </td>
                        <td>
                            <%=xuehai[29].time %>
                            <br />
                             <%=xuehai[29].t_name %>
                            <p hidden="hidden"><%=xuehai[29].state %></p>
                        </td>
                    </tr>
                </table>
                <table class="time yuqv" id="yuqv">
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[0].time %>
                            <br />
                             <%=yuqu[0].t_name %>
                            <p hidden="hidden"><%=yuqu[0].state %></p>
                        </td>
                        <td>
                            <%=yuqu[6].time %>
                            <br />
                             <%=yuqu[6].t_name %>
                            <p hidden="hidden"><%=yuqu[6].state %></p>
                        </td>
                        <td>
                            <%=yuqu[12].time %>
                            <br />
                             <%=yuqu[12].t_name %>
                            <p hidden="hidden"><%=yuqu[12].state %></p>
                        </td>
                        <td>
                            <%=yuqu[18].time %>
                            <br />
                             <%=yuqu[18].t_name %>
                            <p hidden="hidden"><%=yuqu[18].state %></p>
                        </td>
                        <td>
                            <%=yuqu[24].time %>
                            <br />
                             <%=yuqu[24].t_name %>
                            <p hidden="hidden"><%=yuqu[24].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[1].time %>
                            <br />
                             <%=yuqu[1].t_name %>
                            <p hidden="hidden"><%=yuqu[1].state %></p>
                        </td>
                        <td>
                            <%=yuqu[7].time %>
                            <br />
                             <%=yuqu[7].t_name %>
                            <p hidden="hidden"><%=yuqu[7].state %></p>
                        </td>
                        <td>
                            <%=yuqu[13].time %>
                            <br />
                             <%=yuqu[13].t_name %>
                            <p hidden="hidden"><%=yuqu[13].state %></p>
                        </td>
                        <td>
                            <%=yuqu[19].time %>
                            <br />
                             <%=yuqu[19].t_name %>
                            <p hidden="hidden"><%=yuqu[19].state %></p>
                        </td>
                        <td>
                            <%=yuqu[25].time %>
                            <br />
                             <%=yuqu[25].t_name %>
                            <p hidden="hidden"><%=yuqu[25].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[2].time %>
                            <br />
                             <%=yuqu[2].t_name %>
                            <p hidden="hidden"><%=yuqu[2].state %></p>
                        </td>
                        <td>
                            <%=yuqu[8].time %>
                            <br />
                             <%=yuqu[8].t_name %>
                            <p hidden="hidden"><%=yuqu[8].state %></p>
                        </td>
                        <td>
                            <%=yuqu[14].time %>
                            <br />
                             <%=yuqu[14].t_name %>
                            <p hidden="hidden"><%=yuqu[14].state %></p>
                        </td>
                        <td>
                            <%=yuqu[20].time %>
                            <br />
                             <%=yuqu[20].t_name %>
                            <p hidden="hidden"><%=yuqu[20].state %></p>
                        </td>
                        <td>
                            <%=yuqu[26].time %>
                            <br />
                             <%=yuqu[26].t_name %>
                            <p hidden="hidden"><%=yuqu[26].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[3].time %>
                            <br />
                             <%=yuqu[3].t_name %>
                            <p hidden="hidden"><%=yuqu[3].state %></p>
                        </td>
                        <td>
                            <%=yuqu[9].time %>
                            <br />
                             <%=yuqu[9].t_name %>
                            <p hidden="hidden"><%=yuqu[9].state %></p>
                        </td>
                        <td>
                            <%=yuqu[15].time %>
                            <br />
                             <%=yuqu[15].t_name %>
                            <p hidden="hidden"><%=yuqu[15].state %></p>
                        </td>
                        <td>
                            <%=yuqu[21].time %>
                            <br />
                             <%=yuqu[21].t_name %>
                            <p hidden="hidden"><%=yuqu[21].state %></p>
                        </td>
                        <td>
                            <%=yuqu[27].time %>
                            <br />
                             <%=yuqu[27].t_name %>
                            <p hidden="hidden"><%=yuqu[27].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[4].time %>
                            <br />
                             <%=yuqu[4].t_name %>
                            <p hidden="hidden"><%=yuqu[4].state %></p>
                        </td>
                        <td>
                            <%=yuqu[10].time %>
                            <br />
                             <%=yuqu[10].t_name %>
                            <p hidden="hidden"><%=yuqu[10].state %></p>
                        </td>
                        <td>
                            <%=yuqu[16].time %>
                            <br />
                             <%=yuqu[16].t_name %>
                            <p hidden="hidden"><%=yuqu[16].state %></p>
                        </td>
                        <td>
                            <%=yuqu[22].time %>
                            <br />
                             <%=yuqu[22].t_name %>
                            <p hidden="hidden"><%=yuqu[22].state %></p>
                        </td>
                        <td>
                            <%=yuqu[28].time %>
                            <br />
                             <%=yuqu[28].t_name %>
                            <p hidden="hidden"><%=yuqu[28].state %></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0.2vw solid #E4E4E4">
                            <%=yuqu[5].time %>
                            <br />
                             <%=yuqu[5].t_name %>
                            <p hidden="hidden"><%=yuqu[5].state %></p>
                        </td>
                        <td>
                            <%=yuqu[11].time %>
                            <br />
                             <%=yuqu[11].t_name %>
                            <p hidden="hidden"><%=yuqu[11].state %></p>
                        </td>
                        <td>
                            <%=yuqu[17].time %>
                            <br />
                             <%=yuqu[17].t_name %>
                            <p hidden="hidden"><%=yuqu[17].state %></p>
                        </td>
                        <td>
                            <%=yuqu[23].time %>
                            <br />
                             <%=yuqu[23].t_name %>
                            <p hidden="hidden"><%=yuqu[23].state %></p>
                        </td>
                        <td>
                            <%=yuqu[29].time %>
                            <br />
                             <%=yuqu[29].t_name %>
                            <p hidden="hidden"><%=yuqu[29].state %></p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="right"><!--右侧-->
        <!--首页轮播图右侧的三个按钮 各个页面通用-->
        <div class="button">
            <a><img src="images/button_1.png"></a>
            <a><img src="images/button_2.png"></a>
            <a><img src="images/button_3.png"></a>
        </div>    
        <div class="address">
        	<ul>
            	<li>
                	<p><img src="images/address_icon.png" />东院咨询室：B区勤工助学楼1楼;</p>
                    <p><img src="images/tel_icon.png" />023-61852657;</p>
                </li>
                <li>
                	<p><img src="images/address_icon.png" />南湖咨询室：B区勤工助学楼1楼;</p>
                    <p><img src="images/tel_icon.png" />023-61852657;</p>
                </li>
                <li>
                	<p><img src="images/address_icon.png" />升升咨询室：B区勤工助学楼1楼;</p>
                    <p><img src="images/tel_icon.png" />023-61852657;</p>
                </li>
                <li>
                	<p><img src="images/address_icon.png" />学海咨询室：B区勤工助学楼1楼;</p>
                    <p><img src="images/tel_icon.png" />023-61852657;</p>
                </li>
                <li>
                	<p><img src="images/address_icon.png" />余区咨询室：B区勤工助学楼1楼;</p>
                    <p><img src="images/tel_icon.png" />023-61852657;</p>
                </li>
            </ul>
        </div>
	</div>
</div>

<!--底部部分 各个页面通用*-->
<div class="footer" id="footer">

</div>
    </form>
    <script type="text/javascript" src="js/p6_appointment.js"></script>
    </body>
</html>
