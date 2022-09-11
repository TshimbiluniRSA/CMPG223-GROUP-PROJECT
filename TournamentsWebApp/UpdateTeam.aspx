<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTeam.aspx.cs" Inherits="TournamentsWebApp.UpdateTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Team</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Update Team</h1>
            <lable for="SelectPlayer" />
            <asp:ListBox CssClass="form-control" ID="SelectPlayer" runat="server" />

            <br />

            <label for="SelectTeam" />
            <asp:ListBox CssClass="form-control" ID ="SelectedTeam" runat="server" Width="100%"/>

            <br/>

            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="update" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Update Team" Width="306px" OnClick="update_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
