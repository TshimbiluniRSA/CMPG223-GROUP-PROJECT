<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteTournament.aspx.cs" Inherits="TournamentsWebApp.deleteTournament" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete a tournament</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Delete tournament</h1>
            <label for="existingTournaments">Selecte a tournament and click delete to delete the tournament</label> 
            <asp:ListBox ID="existingTournaments" runat="server" CssClass="form-control"></asp:ListBox>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="removeTournament" CssClass="mt-2 btn-outline-primary col-3" runat="server" Text="Delete tournament" OnClick="removeTournament_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
