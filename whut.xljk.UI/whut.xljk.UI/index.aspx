<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EmptyProjectNet45_FineUI.index" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>武汉理工大学心理健康教育网站</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/p0_index.css" rel="stylesheet" type="text/css">
    <link href="css/common/reset.css" rel="stylesheet" type="text/css">
    <link href="css/common/common.css" rel="stylesheet" type="text/css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="//cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="//cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!--[if IE 6]>
        <script type="text/javascript">
            alert("你使用的是IE6浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->
    <!--[if lte IE 7]>
        <script type="text/javascript">
            alert("你使用的是IE7浏览器，这是IE的过期版本，是时候该升级了！");
        </script>
        <![endif]-->
</head>

<body style="background-image: url(images/background.png);">

       <!--#include file="head.html"--> 

    <!--------------------------------------数据显示部分----------------------------------------------->

    <div class="main">

        <!--首页轮播图-->
        <div id="banner_tabs" class="flexslider">

            <div class="block-wrapper2 container-fuild">

                <!--轮播图-->
                <div id="carousel-example-generic" class="carousel slide zxzl-carousel" data-ride="carousel">
                    <div class="carousel-indicators-warrper"></div>
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <%=PreImg %>
                    </div>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev"></a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next"></a>
                </div>
            </div>
        </div>

        <!--首页轮播图右侧的三个按钮 各个页面通用-->
        <div class="button" style="width: 26vw; height: 25.2vw;">
            <a>
                <img src="images/button_1.png" style="width: 20vw; margin: 3.2vw auto;"></a>
            <a>
                <img src="images/button_2.png" style="width: 20vw; margin: 3.2vw auto;"></a>
            <a>
                <img src="images/button_3.png" style="width: 20vw; margin: 3.2vw auto;"></a>
        </div>

        <!--中心动态 2-->
        <div class="p0_news">
            <img src="images/xinwenIcon.png" class="newstittle" style="width: 9.5vw; height: auto">
            <hr style="border: 0.03vw solid gray;">
            <img src="images/centermain.png" style="display: block; width: 4vw;">

            <div class="newsleft">
                <%=xwdt_toutiao %>
            </div>

            <a href="#"><p style="color: #33d49d; margin-left: 44vw; cursor: pointer; font-size: 1.2vw;">more></p></a>

            <!--心协动态 3-->
            <img src="images/xinxie.png" style="display: block; clear: left; width: 4vw;">

            <div class="xinxiecontent">
                <%=xinxie_toutiao%>
            </div>

            <a href="#"><p style="color: #33d49d; margin-left: 44vw; cursor: pointer; font-size: 1.2vw;">more></p></a>
        </div>



        <!--问答案例 动态的，需要换文字-->
        <div class="p0_qa">
            <!--首页问答-->
            <img src="images/wendaIcon.png" style="width: 9.5vw; height: auto">
            <hr>
            <p>
                <img src="images/wen.png">&nbsp;好方啊，大学好迷茫。。
            </p>
            <p>
                <img src="images/da.png">&nbsp;同学你好，美好的大学在向你招手，只要...
            </p>
            <p>
                <img src="images/wen.png">&nbsp;好方啊，大学好迷茫。。
            </p>
            <hr style="margin-top: 2vw;">
        </div>


        <!--心理美文 5-->
        <div class="p0_essay">
            <img src="images/xinliIcon.png" style="width: 9.5vw; height: auto">
            <hr style="margin-bottom: 1vw; border: 0.03vw solid gray;">

            <div class="grid">
                <%=preMeiwen %>
            </div>

            <a href="#"><p style="color: #33d49d; cursor: pointer; font-size: 1.2vw; text-align:right">more></p></a>

        </div>
    </div>


    <!--底部部分 各个页面通用*-->
    <div class="footer">
    </div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery-1.9.1.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/classie.js"></script>

</body>
</html>
