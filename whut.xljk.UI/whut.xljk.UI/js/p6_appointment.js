// JavaScript Document

window.onload = function () {
    auto_getdate();
    var maqv = document.getElementById("place").getElementsByTagName("tr").item(0).getElementsByTagName("td").item(0);
    var dongyuan = document.getElementById("place").getElementsByTagName("tr").item(1).getElementsByTagName("td").item(0);
    maqv.style.backgroundColor = "#FFF";
    dongyuan.style.backgroundColor = "#FFF";
    table_display("dongyuan");

    //表格内有老师的背景设为蓝色
    var tables = document.getElementsByClassName("time")
    for (var i = 0; i < tables.length; i++) {
        var rows = tables.item(i).getElementsByTagName("tr");
        for (var j = 0; j < rows.length; j++) {
            var cells = rows.item(j).getElementsByTagName("td");
            for (var k = 0; k < cells.length; k++) {
                if (cells.item(k).innerHTML == "") {
                    cells.item(k).style.backgroundColor = "#FFF";
                }
                else {
                    cells.item(k).style.backgroundColor = "#99FFFF";
                    var p = cells.item(k).childNodes;

                        if (p[3].textContent == "已预约") {
                            cells.item(k).style.backgroundColor = "#00FF99";
                        }
            }
        }
    }
    //表格已预约的改变颜色
    }


}
//自动获取日期和星期
function auto_getdate() {
    var date = new Date();
    var week = { 1: "星期一", 2: "星期二", 3: "星期三", 4: "星期四", 5: "星期五" };
    var a = date.getDay();//获取星期
    var day_child = document.getElementById("day").getElementsByTagName("tr").item(0).getElementsByTagName("td");
    var day_child1 = document.getElementById("day").getElementsByTagName("tr").item(1).getElementsByTagName("td");
    //非周末处理
    if (a != 6 && a != 0) {
        var today_date = date.toLocaleDateString();//获取今天日期
        var count = 0;//用于计算第一行的非空格数
        //初始化第一行
        for (var i = 1; i <= day_child.length; i++) {
            if (i < a) {
                day_child[i - 1].innerHTML = "";
                continue;
            }
            day_child[i - 1].innerHTML = "";
            var date2 = new Date();
            millseconds = date.getTime() + 1000 * 60 * 60 * 24 * count;
            date2.setTime(millseconds);
            var weekinfo_html = "<p>" + week[i] + "(本周)" + "<p>" + "<br/>";
            var dateinfo_html = "<p>" + date2.toLocaleDateString() + "<p>";
            day_child[i - 1].innerHTML = weekinfo_html + dateinfo_html;
            count++;
        }
        //初始化第二行
        var count2 = count;
        for (var i = 1; i <= day_child1.length; i++) {
            if (i <= 5 - count) {
                var date3 = new Date();
                millseconds = date.getTime() + 1000 * 60 * 60 * 24 * count2;
                count2++;
                date3.setTime(millseconds);
                var weekinfo_html = "<p>" + week[i] + "(下周)" + "<p>" + "<br/>";
                var dateinfo_html = "<p>" + date3.toLocaleDateString() + "<p>";
                day_child1[i - 1].innerHTML = weekinfo_html + dateinfo_html;
                continue;
            }
            day_child1[i - 1].innerHTML = "";
        }
    } else if (a == 6) {
        //处理周末
        //第一行
        var count = 2;
        for (var i = 1; i <= day_child.length; i++) {
            day_child[i - 1].innerHTML = "";
            var date2 = new Date();
            millseconds = date.getTime() + 1000 * 60 * 60 * 24 * count;
            date2.setTime(millseconds);
            var weekinfo_html = "<p>" + week[i] + "(下周)" + "<p>" + "<br/>";
            var dateinfo_html = "<p>" + date2.toLocaleDateString() + "<p>";
            day_child[i - 1].innerHTML = weekinfo_html + dateinfo_html;
            count++;
        }
        //第二行
        for (var i = 1; i <= day_child1.length; i++) {
            day_child1[i - 1].innerHTML = "";
        }
    } else {
        var count = 1;
        for (var i = 1; i <= day_child.length; i++) {
            day_child[i - 1].innerHTML = "";
            var date2 = new Date();
            millseconds = date.getTime() + 1000 * 60 * 60 * 24 * count;
            date2.setTime(millseconds);
            var weekinfo_html = "<p>" + week[i] + "(下周)" + "<p>" + "<br/>";
            var dateinfo_html = "<p>" + date2.toLocaleDateString() + "<p>";
            day_child[i - 1].innerHTML = weekinfo_html + dateinfo_html;
            count++;
        }
        //第二行
        for (var i = 1; i <= day_child1.length; i++) {
            day_child1[i - 1].innerHTML = "";
        }
    }




}

function table_display(table) {
    var tabTime = document.getElementsByClassName("time");
    for (var i = 0; i < tabTime.length; i++) {
        tabTime.item(i).style.display = "none";
    }
    if (table == 'maqv') {
        table = "dongyuan";
    }
    document.getElementById(table).style.display = "block";
}

function change(td, table) {
    var row = document.getElementById("place").getElementsByTagName("tr");
    var col1 = row.item(0).getElementsByTagName("td");
    var col2 = row.item(1).getElementsByTagName("td");
    for (var i = 0; i < col1.length; i++) {
        col1.item(i).style.backgroundColor = "#E4E4E4";
    }
    if (table != 'yuqv') {
        col1.item(0).style.backgroundColor = "#FFF";
    }
    for (var i = 0; i < col2.length; i++)
        col2.item(i).style.backgroundColor = "#F4F4F4";
    td.style.backgroundColor = "#FFF";
    if (table == 'maqv') {
        col2.item(0).style.backgroundColor = "#FFF";
    }
    table_display(table);
}


