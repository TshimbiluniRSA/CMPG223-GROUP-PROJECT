<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createTournament.aspx.cs" Inherits="TournamentsWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Tournament</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" class="container-lg" runat="server">
            <h1 style="text-align:center">Create a tournament</h1>
        <div class="d-flex flex-row w-100 justify-content-between">
            <div class="w-50">
                <label for="StartDate">
                    Enter the start date:
                </label> 
                <br />
                <asp:Calendar ID="startDate" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
            </div>
            <div class="w-50">
                <label for="gameUsed">Select game:</label>
                <asp:DropDownList ID="gameUsed" CssClass="form-control" runat="server"/> 

                <br />

                <label for="platformUsed">Select platform:</label>
                <asp:DropDownList ID="platformUsed" CssClass="form-control" runat="server"/> 

                <br />

                <label for="maximumParticipants">Enter the maximum number of participants:</label>
                <asp:TextBox runat="server" type="number" ID="maximumParticipants" CssClass="form-control" min="4" max="64" step="2" value="4"/>

                <br />

                <label for="venue">Select venue:</label>
                <asp:DropDownList ID="venue" CssClass="form-control" runat="server"/> 
            </div>
        </div>
        <hr />
        <div>
            <label for="lastEnterenceDate">
                    Enter last enterence date:
            </label> 
            <br />
            <asp:Calendar ID="LastEnterenceDate" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                <DayStyle Width="14%" />
                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                <TodayDayStyle BackColor="#CCCC99" />
            </asp:Calendar>
        </div>

        <div class="d-flex justify-content-center mt-2">
            <asp:Button ID="btnCreateTournament" Text="Create tournament" CssClass="btn-outline-primary col-3 p-2 rounded" runat="server" OnClick="btnCreateTournament_Click"/>
        </div>

    </form>
</body>
</html>
