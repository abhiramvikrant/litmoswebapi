<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseComplete.aspx.cs" Inherits="AimBridge.WebAPI.UI.CourseComplete" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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



    </style>
    <title>AimBridge Course Complete</title>
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS file -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
   
<script type="text/javascript">    
    $(document).ready(function () {    
        $("[id *= cbCoursesHeader]").click(function () {    
            checkChildCheckbox(this);    
        });    
    
        function checkChildCheckbox(rowCheckbox) {    
            $("[id *= cbUsers]").prop("checked", $(rowCheckbox).prop("checked"));    
        }    
    });    
</script>  
</head>
<body>
 
  

    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card-header" ><div><h1>AimBridge Bulk Course Complete</h1></div> <div class="align-items-lg-end"><a href="setapikey.aspx">Set API key</a></div></div>
            
                <div class="container">
                    <div class="row"><div class="col-md-6">&nbsp;</div></div>
        <div class="row">
            <div class="col-md-6">
            Team :<br />
            <asp:DropDownList CssClass="control" ID="ddlTeam" runat="server" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="col-md-6">
            Course:<br />
            <asp:DropDownList CssClass="control" ID="ddlCourse" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>-- Select --</asp:ListItem>
            </asp:DropDownList>
                </div>
        </div>
                    <div class="row mt-4">
                          <div class="col-md-6">
            Completion Date :<br />
                             <input type="date"  class="control" />
                             
         
                </div>
                    </div>
        <div class="row mt-4">
            <div class="col-md-12">
        <asp:GridView Width="100%" CellPadding="2" CellSpacing="4"  BorderWidth="0px" CssClass="control_noborder" ID="gvUsers" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
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
            <RowStyle Width="1140px" />
            <AlternatingRowStyle Width="1140px" />
            <HeaderStyle Width="1140px" />
        </asp:GridView>
            </div>
            </div>
        <div class="row">
            <div class=" col-md-12 mt-4">
        <asp:Button ID="btComplete" runat="server" OnClick="btComplete_Click" Text="Mark Complete" />
                </div>
            </div>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
   
        </div>
             
            </ContentTemplate>
        </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
          <img src="loader4.gif" />
            Loading...
        
    </div></ProgressTemplate>
    </asp:UpdateProgress>
         </form>
</body>
</html>
