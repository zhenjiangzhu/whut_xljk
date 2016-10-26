<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qaonline.aspx.cs" Inherits="EmptyProjectNet45_FineUI.qaonline" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>在线问答</title>
    <link href="css/p5_qaonline.css" rel="stylesheet" type="text/css">
    <link href="css/common/reset.css" rel="stylesheet" type="text/css">
    <link href="css/common/common.css" rel="stylesheet" type="text/css">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <form id="body" runat="server">
        <!--头部部分 各个页面通用*-->
        <div class="header">
            <img src="images/tittle.png">
            <div class="search">
                <!--搜索框*-->
                <img src="images/searchBorder.png">
                <img class="searchicon" src="images/searchIcon.png">
                <img src="images/search00.png">
            </div>
        </div>

        <!--导航部分 各个页面通用*-->
        <div class="nav">
            <ul>
                <li>
                    <!--每个li把icons和链接放在一起 达到hover的时候能将效果覆盖到icon上-->
                    <img src="images/navHomeIcon.png"><a href="index.html">首页</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p1_centersurvey.html">中心概况</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p2_center_list.html">中心动态</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p3_association_list.html">心协动态</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p4_consultor.html">咨询师简介</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p5_qaonline.html">在线问答</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p6_appointment.html">咨询预约</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p7_article_list.html">心灵驿站</a>
                </li>
                <li>
                    <img src="images/navHomeIcon.png"><a href="p8_download.html">下载专区</a>
                </li>
            </ul>
        </div>

        <!--首页主体部分 首页编码为p0-->
        <div class="main">
            <div class="p5_main">
                <img src="images/qaonline_icon.png" style="width: 9.5vw; height: auto;">
                <hr>
                <center><h1>在线咨询</h1></center>
                <p>
                    同学你好，这里是武汉理工大学心理健康教育中心的在线问答版块<br>
                    你可以在这里向我们的咨询师们倾诉你的问题，我们将尽力解答<br>
                    请同学在留言时，留下你的email或者QQ号或者手机号方便联系<br>
                    我们对这些信息将会严格保密。你的留言以及咨询师的回复将会向大家展示<br>
                    如果有需要请点击右上角粉色的在线预约按钮。预约到中心进行当面心理咨询<br>
                </p>

                <div id="dishide">
                    <div class="input-group">
                        <span class="label">昵称</span>
                        <asp:TextBox ID="txb_NickName" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="input-group">
                        <span class="label">年级</span>
                        <asp:TextBox ID="txb_Grade" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span>性别</span>
                        <asp:RadioButtonList ID="rbl_Sex" runat="server">
                            <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="input-group">
                        <span>邮箱</span>
                        <asp:TextBox ID="txb_Email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span>咨询老师</span>
                        <asp:DropDownList ID="ddl_TeacherName" runat="server" ></asp:DropDownList>
                        <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:DB_whut_xljkConnectionString %>" DeleteCommand="DELETE FROM [T_User] WHERE [Account] = @original_Account AND (([Password] = @original_Password) OR ([Password] IS NULL AND @original_Password IS NULL)) AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([Tel] = @original_Tel) OR ([Tel] IS NULL AND @original_Tel IS NULL)) AND (([Sex] = @original_Sex) OR ([Sex] IS NULL AND @original_Sex IS NULL)) AND (([Birth] = @original_Birth) OR ([Birth] IS NULL AND @original_Birth IS NULL)) AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL))" InsertCommand="INSERT INTO [T_User] ([Account], [Password], [Name], [Tel], [Sex], [Birth], [Email], [Status]) VALUES (@Account, @Password, @Name, @Tel, @Sex, @Birth, @Email, @Status)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [T_User] WHERE ([Status] = @Status)" UpdateCommand="UPDATE [T_User] SET [Password] = @Password, [Name] = @Name, [Tel] = @Tel, [Sex] = @Sex, [Birth] = @Birth, [Email] = @Email, [Status] = @Status WHERE [Account] = @original_Account AND (([Password] = @original_Password) OR ([Password] IS NULL AND @original_Password IS NULL)) AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([Tel] = @original_Tel) OR ([Tel] IS NULL AND @original_Tel IS NULL)) AND (([Sex] = @original_Sex) OR ([Sex] IS NULL AND @original_Sex IS NULL)) AND (([Birth] = @original_Birth) OR ([Birth] IS NULL AND @original_Birth IS NULL)) AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL))">
                            <DeleteParameters>
                                <asp:Parameter Name="original_Account" Type="String" />
                                <asp:Parameter Name="original_Password" Type="String" />
                                <asp:Parameter Name="original_Name" Type="String" />
                                <asp:Parameter Name="original_Tel" Type="String" />
                                <asp:Parameter Name="original_Sex" Type="String" />
                                <asp:Parameter Name="original_Birth" Type="String" />
                                <asp:Parameter Name="original_Email" Type="String" />
                                <asp:Parameter Name="original_Status" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Account" Type="String" />
                                <asp:Parameter Name="Password" Type="String" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Tel" Type="String" />
                                <asp:Parameter Name="Sex" Type="String" />
                                <asp:Parameter Name="Birth" Type="String" />
                                <asp:Parameter Name="Email" Type="String" />
                                <asp:Parameter Name="Status" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="Status" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Password" Type="String" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Tel" Type="String" />
                                <asp:Parameter Name="Sex" Type="String" />
                                <asp:Parameter Name="Birth" Type="String" />
                                <asp:Parameter Name="Email" Type="String" />
                                <asp:Parameter Name="Status" Type="String" />
                                <asp:Parameter Name="original_Account" Type="String" />
                                <asp:Parameter Name="original_Password" Type="String" />
                                <asp:Parameter Name="original_Name" Type="String" />
                                <asp:Parameter Name="original_Tel" Type="String" />
                                <asp:Parameter Name="original_Sex" Type="String" />
                                <asp:Parameter Name="original_Birth" Type="String" />
                                <asp:Parameter Name="original_Email" Type="String" />
                                <asp:Parameter Name="original_Status" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        -->
                       
                    </div>
                    <div class="input-group">
                        <span>问题简介</span>
                        <asp:TextBox ID="txb_BriefQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span>详情咨询</span>
                        <asp:TextBox ID="txb_DetailQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                        
                    </div>
                    <div class="input-group">
                        <span class="label">是否愿意将您的问题供其他同学参考？</span>、
                        <asp:RadioButtonList ID="rbl_Reference" runat="server"><asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem><asp:ListItem Text="否" Value="0"></asp:ListItem></asp:RadioButtonList>
                    </div>
                    <div class="btn-group">
                        <asp:Button ID="btn_Submit" runat="server" Text="提交" CssClass="btn btn-primary submitbtn" OnClick="btn_Submit_Click"/>
                        
                    </div>
                </div>
                <div class="btn-group">
                    <input type="button" id="iwantq" onclick="showtext()" value="我要留言" class="btn-primary">
                </div>
                <script type="text/javascript">
                    var i = 1;
                    function showtext() {
                        var shide = document.getElementById("dishide");
                        var changevalue = document.getElementById("iwantq");
                        if (i % 2 == 1) {
                            shide.style.display = 'block';
                            changevalue.value = "收起";
                        }
                        if (i % 2 == 0) {
                            shide.style.display = 'none';
                            changevalue.value = "我要留言";
                        }
                        i++;
                    }
                </script>
                <div class="tags">
                    <a href="qaonline.aspx?category=1"><img src="images/tags_1.png" class="tags_1"></a>
                    <a href="qaonline.aspx?category=2"><img src="images/tags_2.png" class="tags_2"></a>
                    <a href="qaonline.aspx?category=3"><img src="images/tags_3.png" class="tags_3"></a>
                    <a href="qaonline.aspx?category=4"><img src="images/tags_4.png" class="tags_4"></a>
                    <a href="qaonline.aspx?category=5"><img src="images/tags_5.png" class="tags_5"></a>
                    <a href="qaonline.aspx?category=6"><img src="images/tags_6.png" class="tags_6"></a>
                    <a href="qaonline.aspx?category=7"><img src="images/tags_7.png" class="tags_7"></a>
                    <a href="qaonline.aspx?category=8"><img src="images/tags_8.png" class="tags_8"></a>
                    <a href="qaonline.aspx?category=9"><img src="images/tags_9.png" class="tags_9"></a>
                    <a href="qaonline.aspx?category=10"><img src="images/tags_10.png" class="tags_10"></a>
                </div>
                <%=MessageList %>
                <!--页面切换-->
                <div><%=NavHtml %></div>
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

    </form>
</body>
</html>
