<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDeletePlatform.aspx.cs" Inherits="TournamentsWebApp.addDeletePlatform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add and Delete Platforms</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
 <div class="container">
            <h2>Add Platform</h2>
            <label for="gameName">Enter the name of the game</label>
            <br />
            <asp:TextBox placeholder="Enter name of the Platform" ID="platform" CssClass="form-control" runat="server" />
            <asp:Label ID="errMsg" runat="server"/>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="addPlatform" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Add Platform" OnClick="addGame_Click"/>
            </div>
            <hr />
            <h2>Delete platform</h2>
            <label for="gameName">Select the name of the Platform</label>
            <asp:ListBox ID="existingPlatforms" CssClass="form-control" runat="server"></asp:ListBox>
            
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="deletePlatform" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Delete platform" OnClick="deleteGame_Click" />
            </div>
            <br />
        </div>
    </form>
</body>
</html>
