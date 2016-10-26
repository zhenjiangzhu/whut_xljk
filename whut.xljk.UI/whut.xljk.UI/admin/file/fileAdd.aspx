<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileAdd.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.file.fileAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="bkgroundjs/jquery-1.11.3.min.js"></script>
    <link href="bkgroundcss/stuplaza.css" rel="stylesheet" />
    <style type="text/css">
        #fileForm {
            margin-left: 180px;
        }
    </style>
</head>
<body>
    <form method="post" action="FileHandle.ashx" enctype="multipart/form-data" id="fileForm" class="row">
        <p><span class="col_span">文件标题：</span><input name="summary" type="text" class="col_input" /></p>
        <p><span class="col_span">请上传文件：</span><input name="files" type="file" id="fileUp" class="col_input" /></p>
        <input type="hidden" name="filename" />
        <input type="hidden" name="fileext" />
        <input type="hidden" name="filepath" />
        <input type="hidden" name="filetime" />
        <p><span class="col_span">请点击:</span><input id="btnUpload" name="btn" type="submit" class="stu_btn" /></p>
        <div class="filecontent" style="display: none;"></div>
    </form>
    <script type="text/javascript">
       
    </script>
    <script>

        $(":file").change(function () {
            var fileName = $(this).val();
            var ext = fileName.substr(fileName.lastIndexOf('.'));
            if (ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif") {
                alert("请不要选择图片");
                return false;
            } else {
                alert("符合正确的格式");
            }
        });

    </script>
</body>
</html>
