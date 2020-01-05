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
            <asp:DropDownList ID="ddlTeam" runat="server" DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
