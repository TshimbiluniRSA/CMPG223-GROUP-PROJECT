<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDeleteVenue.aspx.cs" Inherits="TournamentsWebApp.addDeleteVenue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add and delete Venue</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add Venue</h2>
            <label for="venueName">Enter the name of the Venue</label>
            <br />
            <asp:TextBox placeholder="Enter name of the Venue" ID="venue" CssClass="form-control" runat="server" />

            <label for="VenueLoc">Enter the Location (City) of the Venue</label>
            <br />
            <asp:TextBox placeholder="Enter Location of the Venue" ID="location" CssClass="form-control" runat="server" />

            <asp:Label ID="errMsg" runat="server"/>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="addVenue" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Add Venue" OnClick="addVenue_Click" />
            </div>

            <h2>Delete Venue</h2>
            <label for="gameName">Select the name of the Venue</label>
            <asp:ListBox ID="existingVenues" CssClass="form-control" runat="server"></asp:ListBox>

            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="deleteVenue" CssClass="mt-2 btn-outline-primary col-3 rounded" runat="server" Text="Delete Venue" OnClick="deleteVenue_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
