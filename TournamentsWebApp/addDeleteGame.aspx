<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDeleteGame.aspx.cs" Inherits="TournamentsWebApp.addDeletePlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add and delete game</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add Game</h2>
            <label for="gameName">Enter the name of the game</label>
            <br />
            <asp:TextBox placeholder="Enter name of the game" ID="game" CssClass="form-control" runat="server" />
            <asp:Label ID="errMsg" runat="server"/>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="addGame" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Add game" OnClick="addGame_Click"/>
            </div>
            <hr />
            <h2>Delete Game</h2>
            <label for="gameName">Select the name of the game</label>
            <asp:ListBox ID="existingGames" CssClass="form-control" runat="server"></asp:ListBox>
            
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="deleteGame" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Delete game" OnClick="deleteGame_Click"/>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
