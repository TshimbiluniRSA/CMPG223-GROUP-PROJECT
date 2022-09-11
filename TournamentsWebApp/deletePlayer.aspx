<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deletePlayer.aspx.cs" Inherits="TournamentsWebApp.deletePlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete player</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Delete Player</h1>
            <label for="existingTournaments">Selecte a Player and click delete to delete the selected player</label> 
            <asp:ListBox ID="existingPlayers" runat="server" CssClass="form-control"></asp:ListBox>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="removePlayer" CssClass="mt-2 btn-outline-primary col-3" runat="server" Text="Delete Player" OnClick="removeTournament_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
