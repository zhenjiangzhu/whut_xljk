<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/common/SingleGrid.Master" CodeBehind="fileList.aspx.cs" Inherits="EmptyProjectNet45_FineUI.admin.file.fileList" %>


<%@ MasterType VirtualPath="~/admin/common/SingleGrid.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" runat="server">
    <f:Form ID="Form6" ShowBorder="false" ShowHeader="false" runat="server">
        <Rows>

            <f:FormRow>
                <Items>
                    <f:TwinTriggerBox runat="server" EmptyText="在用户名中搜索" ShowLabel="false" ID="ttbSearch"
                        ShowTrigger1="false" OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                        Trigger1Icon="Clear" Trigger2Icon="Search">
                    </f:TwinTriggerBox>
                    <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        runat="server">
                        <f:ListItem Text="过滤条件一" Value="filter1" />
                        <f:ListItem Text="过滤条件二" Value="filter2" />
                        <f:ListItem Text="过滤条件三" Value="filter3" />
                    </f:DropDownList>
                </Items>
            </f:FormRow>
        </Rows>
    </f:Form>
    <f:Grid ID="Grid1" EnableCollapse="false" PageSize="5" ShowBorder="true" ShowHeader="false"
        BoxFlex="1"
        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="C_FileId,C_FileSummary" IsDatabasePaging="true"
        AllowSorting="true" SortField="C_FileId" SortDirection="ASC"
        OnRowDataBound="Grid1_RowDataBound">
        <Columns>
            <f:RowNumberField />
            <f:BoundField DataField="C_FileId" Width="100px" SortField="C_FileId" DataFormatString="{0}"
                HeaderText="文件ID" />

            <f:BoundField DataField="C_FileSummary" Width="100px" SortField="C_FileSummary" DataFormatString="{0}"
                HeaderText="文件描述题目" />

            <f:BoundField DataField="C_FileName" Width="100px" SortField="C_FileName" DataFormatString="{0}"
                HeaderText="文件名称" />

            <f:BoundField DataField="C_FileExt" Width="100px" SortField="C_FileExt" DataFormatString="{0}"
                HeaderText="文件扩展名" />

            <f:BoundField DataField="C_FileDowNum" Width="100px" SortField="C_FileDowNum" DataFormatString="{0}"
                HeaderText="文件下载次数" />

            <f:BoundField DataField="C_FileTime" Width="100px" SortField="C_FileTime" DataFormatString="{0}"
                HeaderText="文件上传时间" />

            <f:BoundField DataField="C_FileSector" Width="100px" SortField="C_FileSector" DataFormatString="{0}"
                HeaderText="文件来源" />

        </Columns>
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <f:Button ID="btnExport" EnableAjax="false" DisableControlBeforePostBack="false"
                        runat="server" Text="导出为Excel文件" OnClick="btnExport_Click">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
    </f:Grid>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="headCPH">
    <meta name="sourcefiles" content="~/Admin/SingleGrid.Master;~/Admin/ISingleGridPage.cs" />
</asp:Content>
