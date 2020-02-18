<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setapikey.aspx.cs" Inherits="AimBridge.WebAPI.UI.setapikey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Set API Key</title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style>
       .control{
           width: 100%;
       }
    </style>
</head>

<body>
    <form id="form1" runat="server">
       <div class="card-header"><div><h1>Set API Key</h1></div> <div class="align-items-lg-end"><a href="CourseComplete.aspx">Manual Course Complete</a></div></div>
          <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
   <div class="container">
       <div class="row mt-4">
           <asp:ValidationSummary runat="server" ID="vsSet" ValidationGroup="vgSet" HeaderText="Please fix the following issues:" />
       </div>
       <div class="row">
           <div class="col-md-6 mt-4">
               <label>Edit the API key below:</label>
               <asp:TextBox runat="server" ID="txtApiKey" CssClass="form-control control" />
               
              
           </div>
           <div class="col-md-1 mt-4" style="text-align:left;padding:0px; margin-left=0px;">&nbsp;<br />
               <asp:RequiredFieldValidator runat="server" ID="rfvApiKey" ControlToValidate="txtApiKey" CssClass="control"  ValidationGroup="vgSet" Text="*" ErrorMessage="API key required"/>
           </div>
          
       </div>
       <div class="row mt-4">
           <div class="col-md-3">
               <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="vgSet" />
           </div>
       </div>
   </div>
    </form>
</body>
</html>
