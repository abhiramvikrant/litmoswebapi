<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseComplete.aspx.cs" Inherits="AimBridge.WebAPI.UI.CourseComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        tr:nth-child(even) {
  background-color: #f2f2f2;
}
    </style>
    <title>AimBridge Course Complete</title>
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS file -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
    $(document).ready(function(){
$("#<%=gvUsers.ClientID%>input[id*='cbCoursesHeader']:checkbox").click(function () {                      
        //Header checkbox is checked or not
var bool = $("#<%=gvUsers.ClientID%>input[id*='cbCoursesHeader']:checkbox").is(':checked');
//check and check the checkboxes on basis of Boolean value
$("#<%=gvUsers.ClientID%> input[id*='cbUsers']:checkbox").attr('checked', bool);
 });
    }
</script>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-2 m-4">
            Team :<br />
            <asp:DropDownList ID="ddlTeam" runat="server" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="col-md-2 m-4">
            Course:<br />
            <asp:DropDownList ID="ddlCourse" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                </div>
        </div>
        <div class="row"><div class="col m-4">
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbCoursesHeader" CssClass="chkHeader" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbUsers" CssClass="chkItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Username" HeaderText="UserName" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
            </Columns>
        </asp:GridView>
            </div>
            </div>
        <div class="row">
            <div class=" col-md-12 m-4">
        <asp:Button ID="btComplete" runat="server" OnClick="btComplete_Click" Text="Mark Complete" />
                </div>
            </div>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    </form>
        </div>
</body>
</html>
