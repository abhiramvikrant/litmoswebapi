﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseComplete.aspx.cs" Inherits="AimBridge.WebAPI.UI.CourseComplete" ValidateRequest="false"%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.11/jquery-ui.min.js"></script>
    <style>
        tr:nth-child(even) {
  background-color: #f2f2f2;
}
 .modal
{
    position: fixed;
    z-index: 999;
    height: 100%;
    width: 100%;
    top: 0;
    background-color: Black;
    filter: alpha(opacity=60);
    opacity: 0.6;
}
.center
{
    z-index: 1000;
    margin: 300px auto;
    padding: 10px;
    width: 130px;
    background-color: White;
    border-radius: 10px;
    filter: alpha(opacity=100);
    opacity: 1;
  
}
.center img
{
    height: 128px;
    width: 128px;
}
.control{
    width: 100%;
}
control_noborder
{
    width: 100%;
    border:0px;
    table-layout: fixed;
}

.dateclass{
    width: 100%;
}


    </style>
    <title>AimBridge Course Complete</title>
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS file -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css" />
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.11/jquery-ui.min.js"></script>
   

</head>
<body>
    <script type="text/javascript">
        function SelectAllCheckboxes(chk) {
            $('#<%=gvUsers.ClientID %>').find("input:checkbox").each(function () {
                  if (this != chk) {
                      this.checked = chk.checked;
                  }
              });
          }
    </script>
 
  

    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header" ><div><h1>AimBridge Bulk Course Complete</h1>
      
                </div> <div class="align-items-lg-end"><a href="setapikey.aspx">Set Config Values</a></div></div>
            
                <div class="container">
                    <div class="row"><div class="col-md-6">          <asp:ValidationSummary ID="vsMarkComplete" ShowSummary="true" runat="server"  ValidationGroup="vgComplete" HeaderText="Fix the following errors:"/></div></div>
        <div class="row">
            <div class="col-md-6">
            Team :<br />
            <asp:DropDownList CssClass="control form-control" ID="ddlTeam" runat="server" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTeam" runat="server" ControlToValidate="ddlTeam" InitialValue="-- Select --" ValidationGroup="vgComplete" ErrorMessage="Please select a Team" Text="*" />
                </div>
            <div class="col-md-6">
            Course:<br />
            <asp:DropDownList CssClass="control form-control" ID="ddlCourse" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfvCourse" runat="server" ControlToValidate="ddlCourse" InitialValue="-- Select --" ValidationGroup="vgComplete" ErrorMessage="Please select a Course" Text="*" />
                </div>
        </div>
                    <div class="row mt-4">
                          <div class="col-md-6">
            Completion Date :<br />
                                  <asp:TextBox ID="txtDatePicker" runat="server" CssClass="control form-control" />
                             <%-- <ajaxToolkit:CalendarExtender TargetControlID="txtDatePicker" runat="server" ID="ajaxCal"/>--%><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDatePicker" PopupButtonID="Image1" />
                                <asp:RequiredFieldValidator ID="rfvDatePicker" runat="server" ControlToValidate="txtDatePicker"  ValidationGroup="vgComplete" ErrorMessage="Please select a Completion Date" Text="*" />
                        
        
                </div> 
                    </div>
        <div class="row mt-4">
            <div class="col-md-12" id="dvGrid" runat="server">
        <asp:GridView Width="100%" CellPadding="4" CellSpacing="4"   CssClass="control_noborder" ID="gvUsers" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbCoursesHeader" CssClass="chkHeader" onclick="javascript:SelectAllCheckboxes(this);"  runat="server" TextAlign="Left" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbUsers" CssClass="chkItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Username" HeaderText="UserName" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
            </Columns>
            <RowStyle Width="100%" />
            <AlternatingRowStyle Width="100%"  />
            <HeaderStyle Width="100%" />
        </asp:GridView>
            </div>
            </div>
        <div class="row">
            <div class="col-md-12 mt-4" id="dvComplete" runat="server">
        <asp:Button ID="btComplete" runat="server" CssClass="btn btn-primary" OnClick="btComplete_Click" Text="Mark Complete" ValidationGroup="vgComplete" />
                <asp:Label ID="lblmsg" runat="server" />
                </div>
            </div>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
   
        </div>
            
             
            </ContentTemplate>
  
        </asp:UpdatePanel>
            <asp:UpdateProgress runat="server"  >
        <ProgressTemplate>
           <%-- <div class="modal">
                <div class="center">--%>
             <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute;left: 35%;top: 25%;visibility:visible;vertical-align:middle;border-style:inset;border-color:black;background-color:black; opacity:initial;">
          <img src="loader4.gif" /></div>
         <%--   </div></div>--%>
        
    </div></ProgressTemplate>
    </asp:UpdateProgress>
         </form>
</body>
</html>
