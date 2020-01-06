<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseComplete.aspx.cs" Inherits="AimBridge.WebAPI.UI.CourseComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Team :
            <asp:DropDownList ID="ddlTeam" runat="server" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
            <br />
            Course:
            <asp:DropDownList ID="ddlCourse" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbCoursesHeader" CssClass="chkHeader" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbCourses" CssClass="chkItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Username" HeaderText="UserName" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="True" SortExpression="LastName" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btComplete" runat="server" OnClick="btComplete_Click" Text="Mark Complete" />
    </form>
</body>
</html>
