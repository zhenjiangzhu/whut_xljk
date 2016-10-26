<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleAdd.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.article.articleAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="bkgroundcss/default.css" rel="stylesheet" />
    <link href="bkgroundcss/uploadify.css" rel="stylesheet" />
    <link href="bkgroundcss/DateTimePicker.css" rel="stylesheet" />
    <script src="bkgroundjs/datepick/jquery-1.11.0.min.js"></script>
    <script src="bkgroundjs/uploadify/jquery.uploadify.v2.1.0.min.js"></script>
    <script src="bkgroundjs/uploadify/swfobject.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/kindeditor.js"></script>
    <script src="bkgroundjs/ArticleKindEditor/zh_CN.js"></script>
    <script src="bkgroundjs/DateTimePicker2.js"></script>
    <style type="text/css">
        #ArtileForm {
            margin-left: 30px;
        }

        input[type=text] {
            width: 200px;
            height: 22px;
            border: 1px solid #317eb4;
            margin: 6px 10px;
            float: left;
        }

        input[name=act_start_time] {
            width: 200px;
            height: 22px;
            border: 1px solid #317eb4;
            margin: 6px 10px;
        }

        select {
            width: 200px;
            height: 28px;
            font-size: 14px;
            border: 1px solid #317eb4;
            margin: 6px 10px;
        }

        option {
            font-size: 14px;
        }

        .des {
            display: inline;
            float: left;
            font-size: 14px;
            height: 26px;
            width: 100px;
        }

        .show_article {
            position: relative;
            top: -244px;
            left: 620px;
            width: 200px;
            height: 220px;
            border: 1px solid rgb(0, 0, 0);
            display: none;
        }

            .show_article p:first-child {
                text-align: center;
                margin: 0 auto;
                border-bottom: 1px dotted rgb(0,0,0);
                margin-bottom: 5px;
            }

            .show_article p {
                text-align: center;
                padding: 5px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="ArticlePostHandle.ashx">
        <div>

            <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
                <span class="des">文章填写标题：</span>
                <input type="text" name="txtTitle" />
            </p>

            <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
                <span class="des">文章所属类别：</span>
                <select name="txtCategory">
                    <option value="2">中心动态</option>
                    <option value="3">心协动态</option>
                    <option value="4">咨询师简介</option>
                    <option value="5">心灵驿站</option>
                </select>
            </p>

            <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
                <span class="des">文章来源：</span>
                <input type="text" name="txtSector" />
            </p>

            <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
                <span class="des">文章作者：</span>
                <input type="text" name="txtPostStaff" />
            </p>

            <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
                <span class="des">文章发布时间：</span>
                <input id="act_start_time" name="act_start_time" type="text" data-field="datetime" value="" placeholder="发布时间" title="发布时间" style="cursor: pointer;" />
            </p>

        </div>

        <div id="datetime"></div>
        <asp:Label ID="Label1" runat="server" Text="(*若要在文章中添加图片，请尽量居中放置，以免影响文章布局)" ForeColor="Red"></asp:Label>
        <textarea id="txtcontent" name="txtcontent" style="width: 750px; height: 300px"></textarea>


        <p class="show_btn" style="background-color: #8193f8; cursor: pointer; width: 600px; height: 20px; line-height: 17px; margin-top: 20px; text-align: center">附件：选择文件（可选）</p>
        <div class="show_annex">

            <div id="fileQueue"></div>

            <input type="file" name="uploadify" id="uploadify" value="浏览" />
            <input type="hidden" id="name" name="txtAnnex" />

            <p>
                <a href="javascript:$('#uploadify').uploadifyUpload()" runat="server" id="href" style="margin-right: 6px">上传</a><span>|</span>
                <a href="javascript:$('#uploadify').uploadifyClearQueue()" style="margin-right: 6px;">取消上传</a>
                <span style="color: red">(*点击BROWSE选择上传文件，选择文件后别忘了点击上传哦！)</span>
            </p>
        </div>

        <p style="font-size: 14px; width: auto; height: 34px; line-height: 34px; padding: 0; margin-bottom: 10px">
            <input type="submit" id="txtbtn" value="提交" class="stu_btn" />
        </p>
        <div class="show_article">
            <p>已上传的文件</p>
        </div>
        </div>

    </form>

    <script>
        $(document).ready(function () {
            $("#datetime").DateTimePicker({

                isPopup: false,
                dataFormat: "yyyy-MM-dd",
                dateTimeFormat: "yyyy-MM-dd hh:mm:ss"

            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $(".show_btn").click(function () {
                $(".show_annex").toggle("500");
            });

        })


        $(document).ready(function () {
            var s = "";
            $("#uploadify").uploadify({
                'uploader': 'bkgroundjs/uploadify/uploadify.swf',
                'script': 'ArticleUploadHander.ashx',
                'cancelImg': 'bkgroundjs/uploadify/cancel.png',
                'folder': 'ArticleUploadFile',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': true,
                'fileDesc': '请选择word,pdf,excel,image或压缩文件',
                'fileExt': '*.doc;*.pdf;*.rar;*.xsl;*.xslx;*.docx;*.jpg;*.jpeg;*.bmp;*.png;*.gif;*.zip;',
                'sizeLimit': 20971520,
                'onComplete': function (event, queueId, fileObj, response, data) {
                    s += fileObj.name + ",";
                    $("#name").val(s.substring(0, s.length - 1));
                    $(".show_article").css("display", "block").append("<p>" + fileObj.name + "</p>");
                    alert("文件上传成功！");
                }
            });
        });
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
